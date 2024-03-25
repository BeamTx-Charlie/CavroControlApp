using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Lipid Valve Positions (I):
        //1 = Waste
        //2 = Reservoire
        //3 = T-junction
        //4 = Wash
        //Citrate Valve Positions (I):
        //1 = Wash
        //2 = T-Junction
        //3 = Reservoire
        //4 = Waste

        private string[] INIT = { "Z0R" };
        private string[] PRIMELIPID = {"V1000R","I2R","A700R","I3R","V100R","A550R"};
        private string[] PRIMECITRATE = {"V1000R","I3R","A1800R","I2R","V100R","A1650R"};
        private string[] WASHLIPID = {"I4R","V1200R","A2900R","I3R","A0R","I4R","V1200R","A2900R","I2R","A0R","I4R","A2900R","I2R","A0R","A2900R","I3R","A0R","I2R","A2900R","I3R","A0R"};
        private string[] WASHCITRATE = {"I1R", "V1200R", "A2900R", "I2R", "A0R","I1R", "V1200R", "A2900R", "I3R", "A0R", "I1R", "A2900R", "I3R", "A0R", "A2900R", "I2R", "A0R","I3R", "A2900R", "I2R", "A0R"};
        private string[] FORMULATELIPID = {"I3R" , "V100R" , "A700R"};
        private string[] FORMULATECITRATE = {"I2R" , "V100R" , "A700R"};
        private string[] PURGELIPID = { "I2R","V1200R","A2900R","I1R","A0R","I3R","A2900R","I1R","A0R"};
        private string[] PURGECITRATE = { "I3R","V1200R","A2900R","I4R","A0R","I2R","A2900R","I4R","A0R"};
        private int[] pumps = {1};




        //Initializes the serial port and the log window

        private void cmdOpenCom_Click(object sender, EventArgs e)
        {
            if (boolSimulate.Checked)
            {
                listBox1.Items.Add("*************Simulating Pumps**************");
                return;
            }
            try
            {

                if (chkLog.Checked == true)
                {
                    citratePumps.PumpSetLogWnd(listBox1.Handle.ToInt32());
                    lipidPumps.PumpSetLogWnd(listBox1.Handle.ToInt32());
                }

                //Specify the baud rate
                if (cmbBaudRate.Text == "38400")
                {
                    citratePumps.BaudRate = PUMPCOMMSERVERLib.EBaudRate.Baud38400;
                    lipidPumps.BaudRate = PUMPCOMMSERVERLib.EBaudRate.Baud38400;
                }
                else
                {
                    citratePumps.BaudRate = PUMPCOMMSERVERLib.EBaudRate.Baud9600;
                    lipidPumps.BaudRate = PUMPCOMMSERVERLib.EBaudRate.Baud9600;
                }

                //Open the specified COM port and declare variables for each pump
                citratePumps.PumpInitComm(byte.Parse(txtComPort.Text));
                lipidPumps.PumpInitComm(byte.Parse(txtComPort2.Text));


            }
            catch (System.Runtime.InteropServices.COMException err)
            {
                MessageBox.Show(err.Message);
                txtErr.Text = err.ErrorCode.ToString();

            }
        
        }

        //Converting values to be sent to the pump

        private void cmdSendCommand_Click(object sender, EventArgs e)
        {
            //******Remove .25 if 1mL syringe is installed
            var pumpLipidspeed = ((double.Parse(pump1Speed.Text) / 60) * (3000))*2;
            var pumpCitratespeed = ((double.Parse(pump2Speed.Text) / 60) * (3000))*2;

            listBox1.Items.Add(pumpLipidspeed);
            listBox1.Items.Add(pumpCitratespeed);

            FORMULATELIPID[1] = "V" + pumpLipidspeed + "R";
            FORMULATECITRATE[1] = "V" + pumpCitratespeed + "R";

            //*****Change 250 to 1000 is 1mL syringe is installed
            var pump2Volume = Math.Round((decimal.Parse(pump2Vol.Text) / 1000) * 3000);

            listBox1.Items.Add("Citrate Volume in Steps: " + pump2Volume);

            var primeStepsCitrate = Math.Round((citratePrimeVol.Value / 1000) * 3000);

            
            var finalCitratePos = pump2Volume - primeStepsCitrate;
            //USe final citrate position to calculate corrected lipid position to account for priming volume in the tubes
            var finalLipidPos = Math.Round((finalCitratePos / 3) + (lipidPrimeVol.Value*3));

            var pump1Volume = Math.Round(finalLipidPos + lipidPrimeVol.Value);

            listBox1.Items.Add("Lipid Volume in Steps: " + pump1Volume);

            //set position for air gap no prime
            PRIMELIPID[PRIMELIPID.Length - 3] = "A" + pump1Volume.ToString() + "R";
            PRIMECITRATE[PRIMELIPID.Length - 3] = "A"+ pump2Volume.ToString() + "R";


            //Set position for full prime to Tee
            PRIMELIPID[PRIMELIPID.Length - 1] = "A" + finalLipidPos.ToString() + "R";
            PRIMECITRATE[PRIMELIPID.Length - 1] = "A" + finalCitratePos.ToString() + "R";

        }

        //Parses list of commands for action and complete one at a time
        private async Task<string> sendCommandAsync(string[] commands, string pumpNum, PUMPCOMMSERVERLib.PumpCommClass pumpserver, PUMPCOMMSERVERLib.PumpCommClass pumpservertwin, CancellationToken c, CancellationTokenSource cts)
        {
            if (boolSimulate.Checked) return "*C*";
            
            string status = "";
            try
            {
                foreach (string command in commands)
                {
                    c.ThrowIfCancellationRequested();
                    await Task.Delay(100);
                    pumpserver.PumpSendNoWait(command, byte.Parse(pumpNum));
                    await Task.Delay(1000);
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                    var twinstatus = pumpservertwin.PumpCheckDevStatus(byte.Parse(pumpNum));
                    if (twinstatus != 1)
                    {
                        await Task.Delay(5000);
                        pumpservertwin.PumpWaitForDevice(byte.Parse(pumpNum));
                    }
                    if (status != "")
                    {
                        listBox1.Items.Add("Error! - " + status);
                        listBox1.TopIndex = listBox1.Items.Count - 1;
                        cts.Cancel();
                        throw new Exception(status);
                    }
                    c.ThrowIfCancellationRequested();
                }
            }
            catch when (c.IsCancellationRequested)
            {
                listBox1.Items.Add("Operation cancelled successfully");
                status = "error";
            }
                

            return status;
        }

        //Init Button Click
        private async void btnInit_Click(object sender, EventArgs e)
        {
            var pumpAction = new List<Task>();
            if (pumps.Contains(1))
            {
                pumpAction.Add(InitializeAllPumps(1));
            }
            if (pumps.Contains(2))
            {
                pumpAction.Add(InitializeAllPumps(2));
            }

            await Task.WhenAll(pumpAction);

            listBox1.Items.Add("Init Complete");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        //initializes pairs of pumps simultaneously
        private async Task InitializeAllPumps(int pump)
        {

                CancellationTokenSource cts = new CancellationTokenSource();
                var taskCitrate = sendCommandAsync(INIT, pump.ToString(), citratePumps, lipidPumps, cts.Token, cts);
                var taskLipid = sendCommandAsync(INIT, pump.ToString(), lipidPumps, citratePumps, cts.Token, cts);
                try
                {
                    await Task.WhenAll(taskCitrate, taskLipid);
                    if (cts.IsCancellationRequested)
                    {
                        cts.Dispose();
                        cts = new CancellationTokenSource();
                    }
                    else
                    {
                        cts.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    cts.Cancel();
                    listBox1.Items.Add(ex.ToString());
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
        }

        //Init Prime Click
        private void btnPrime_Click(object sender, EventArgs e)
        {
            PrimeAllPumps(pumps);
        }

        //Primes Pairs of Pumps Simultaneously
        private async void PrimeAllPumps(int[] pumps)
        {
            var pump1Volume = Math.Round(((decimal.Parse(pump1Vol.Text) / 1000) * 3000)+700);
            var pump2Volume = Math.Round(((decimal.Parse(pump2Vol.Text) / 1000) * 3000)+700);

            listBox1.Items.Add("Lipid Volume in Steps: " + pump1Volume);
            listBox1.Items.Add("Citrate Volume in Steps: " + pump2Volume);

            var primeStepsLipid = Math.Round((lipidPrimeVol.Value / 1000) * 3000);
            var primeStepsCitrate = Math.Round((citratePrimeVol.Value / 1000) * 3000);

            var finalLipidPos = pump1Volume - primeStepsLipid;
            var finalCitratePos = pump2Volume - primeStepsCitrate;

            PRIMELIPID[PRIMELIPID.Length - 4] = "A" + (pump1Volume).ToString() + "R";
            PRIMECITRATE[PRIMELIPID.Length - 4] = "A" + (pump2Volume).ToString() + "R";

            PRIMELIPID[PRIMELIPID.Length - 1] = "A" + finalLipidPos.ToString() + "R";
            PRIMECITRATE[PRIMELIPID.Length - 1] = "A" + finalCitratePos.ToString() + "R";

            var tasks = new List<Task<string>>();
            foreach (int pump in pumps)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                var taskCitrate = sendCommandAsync(PRIMECITRATE, pump.ToString(), citratePumps, lipidPumps, cts.Token, cts);
                var taskLipid = sendCommandAsync(PRIMELIPID, pump.ToString(), lipidPumps, citratePumps, cts.Token, cts);
                try
                {
                    await Task.WhenAll(taskCitrate, taskLipid);
                    if (cts.IsCancellationRequested)
                    {
                        cts.Dispose();
                        cts = new CancellationTokenSource();
                    }
                    else
                    {
                        cts.Dispose();
                        listBox1.Items.Add("Prime Complete");
                        listBox1.TopIndex = listBox1.Items.Count - 1;
                    }
                }
                catch (Exception ex)
                {
                    cts.Cancel();
                    listBox1.Items.Add(ex.ToString());
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
            }
        }

        //Wash Button Click
        private void btnWash_Click(object sender, EventArgs e)
        {
            WashAllPumps(pumps);
        }

        //Washed Pairs of Pumps Simultaneously
        private async void WashAllPumps(int[] pumps)
        {
            var tasks = new List<Task<string>>();
            foreach (int pump in pumps)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                var taskCitrate = sendCommandAsync(WASHCITRATE, pump.ToString(), citratePumps, lipidPumps, cts.Token, cts);
                var taskLipid = sendCommandAsync(WASHLIPID, pump.ToString(), lipidPumps, citratePumps, cts.Token, cts);
                try
                {
                    await Task.WhenAll(taskCitrate, taskLipid);
                    if (cts.IsCancellationRequested)
                    {
                        cts.Dispose();
                        cts = new CancellationTokenSource();
                    }
                    else
                    {
                        cts.Dispose();
                        listBox1.Items.Add("Wash Complete");
                        listBox1.TopIndex = listBox1.Items.Count - 1;
                    }
                }
                catch (Exception ex)
                {
                    cts.Cancel();
                    listBox1.Items.Add(ex.ToString());
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
            }
        }

        //Formulation Button Click
        private void btnFormulate_Click(object sender, EventArgs e)
        {
            runFormulation(pumps);
        }

        //Formulate Pairs of Pumps Simultaneously
        private async void runFormulation(int[] pumps)
        {
            double pumpLipidspeed = ((double.Parse(pump1Speed.Text)/60) * (3000))*2;
            MessageBox.Show("Lipid Speed: " + pumpLipidspeed.ToString());
            double pumpCitratespeed = ((double.Parse(pump2Speed.Text)/60) * (3000))*2;
            MessageBox.Show("Citrate Speed: " + pumpCitratespeed.ToString());

            FORMULATELIPID[1] = "V" + pumpLipidspeed + "R";
            FORMULATECITRATE[1] = "V" + pumpCitratespeed + "R";

            var tasks = new List<Task<string>>();
            foreach (int pump in pumps)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                var taskCitrate = sendCommandAsync(FORMULATECITRATE, pump.ToString(), citratePumps, lipidPumps, cts.Token, cts);
                var taskLipid = sendCommandAsync(FORMULATELIPID, pump.ToString(), lipidPumps, citratePumps, cts.Token, cts);
                try
                {
                    await Task.WhenAll(taskCitrate, taskLipid);
                    if (cts.IsCancellationRequested)
                    {
                        cts.Dispose();
                        cts = new CancellationTokenSource();
                    }
                    else
                    {
                        cts.Dispose();
                        listBox1.Items.Add("Formulation Complete");
                        listBox1.TopIndex = listBox1.Items.Count - 1;
                    }
                }
                catch (Exception ex)
                {
                    cts.Cancel();
                    listBox1.Items.Add(ex.ToString());
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
            }
        }

        private void btnPurge_Click(object sender, EventArgs e)
        {
            PurgeAllPumps(pumps);
        }

        //Washed Pairs of Pumps Simultaneously
        private async void PurgeAllPumps(int[] pumps)
        {
            var tasks = new List<Task<string>>();
            foreach (int pump in pumps)
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                var taskCitrate = sendCommandAsync(PURGECITRATE, pump.ToString(), citratePumps, lipidPumps, cts.Token, cts);
                var taskLipid = sendCommandAsync(PURGELIPID, pump.ToString(), lipidPumps, citratePumps, cts.Token, cts);
                try
                {
                    await Task.WhenAll(taskCitrate, taskLipid);
                    if (cts.IsCancellationRequested)
                    {
                        cts.Dispose();
                        cts = new CancellationTokenSource();
                    }
                    else
                    {
                        cts.Dispose();
                        listBox1.Items.Add("Wash Complete");
                        listBox1.TopIndex = listBox1.Items.Count - 1;
                    }
                }
                catch (Exception ex)
                {
                    cts.Cancel();
                    listBox1.Items.Add(ex.ToString());
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
            }
        }

        //Send Manual Command Click
        private async void btnSendCommand_Click(object sender, EventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            string phaseSelect = phaseSelectDrop.SelectedItem.ToString();
            string pumpSelect = pumpNumDrop.SelectedItem.ToString();
            string command = txtManCommand.Text;
            var tasks = new List<Task<string>>();
            var answer = "";

            if (phaseSelect == "Citrate")
            {
                citratePumps.PumpSendCommand(command, byte.Parse(pumpSelect),answer);
                
                try
                {
                    if (cts.IsCancellationRequested)
                    {
                        cts.Dispose();
                        cts = new CancellationTokenSource();
                    }
                    else
                    {
                        cts.Dispose();
                        listBox1.Items.Add("Command Complete");
                        listBox1.TopIndex = listBox1.Items.Count - 1;
                    }
                }
                catch (Exception ex)
                {
                    cts.Cancel();
                    listBox1.Items.Add(ex.ToString());
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
            }

            if (phaseSelect == "Lipid")
            {
                lipidPumps.PumpSendCommand(command, byte.Parse(pumpSelect), answer);
                
                try
                {
                    if (cts.IsCancellationRequested)
                    {
                        cts.Dispose();
                        cts = new CancellationTokenSource();
                    }
                    else
                    {
                        cts.Dispose();
                        listBox1.Items.Add("Command Complete");
                        listBox1.TopIndex = listBox1.Items.Count - 1;
                    }
                }
                catch (Exception ex)
                {
                    cts.Cancel();
                    listBox1.Items.Add(ex.ToString());
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
            }
        }

        //Shows individual steps for selected item from drop down
        private void stepSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = stepSelect.Text;

            listBox2.Items.Clear();

            switch (selection)
            {
                case "Initialize":
                    foreach (string item in INIT)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Prime Lipid":
                    foreach (string item in PRIMELIPID)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Prime Citrate":
                    foreach (string item in PRIMECITRATE)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Formulate Lipid":
                    foreach (string item in FORMULATELIPID)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Formulate Citrate":
                    foreach (string item in FORMULATECITRATE)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Wash Lipid":
                    foreach (string item in WASHLIPID)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Wash Citrate":
                    foreach (string item in WASHCITRATE)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Purge Lipid":
                    foreach (string item in PURGELIPID)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Purge Citrate":
                    foreach (string item in PURGECITRATE)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
            }
        }

        //Allows editing in the text box for selected step
        private void btnEditStep_Click(object sender, EventArgs e)
        {
            string text = listBox2.SelectedItem.ToString();
            txtEditStepBox.Text = text;
        }

        //Save edited text from text box to step and refresh steps in window
        private void btnSaveStep_Click(object sender, EventArgs e)
        {
            string text = txtEditStepBox.Text;
            
            int index = listBox2.SelectedIndex;
            listBox2.Items.Clear();
            txtEditStepBox.Text = "";
            string selection = stepSelect.Text;

            switch (selection)
            {
                case "Initialize":
                    INIT[index] = text;
                    foreach (string item in INIT)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Prime Lipid":
                    PRIMELIPID[index] = text;
                    foreach (string item in PRIMELIPID)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Prime Citrate":
                    PRIMECITRATE[index] = text;
                    foreach (string item in PRIMECITRATE)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Formulate Lipid":
                    FORMULATELIPID[index] = text;
                    foreach (string item in FORMULATELIPID)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Formulate Citrate":
                    FORMULATECITRATE[index] = text;
                    foreach (string item in FORMULATECITRATE)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Wash Lipid":
                    WASHLIPID[index] = text;
                    foreach (string item in WASHLIPID)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Wash Citrate":
                    WASHCITRATE[index] = text;
                    foreach (string item in WASHCITRATE)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Purge Lipid":
                    PURGELIPID[index] = text;
                    foreach (string item in PURGELIPID)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
                case "Purge Citrate":
                    PURGECITRATE[index] = text;
                    foreach (string item in PURGECITRATE)
                    {
                        listBox2.Items.Add(item);
                    }
                    break;
            }

            listBox2.Refresh();
        }

        //Update pump 1 active status
        private void pSet1Check_CheckedChanged(object sender, EventArgs e)
        {
            if (pSet1Check.Checked)
            {
                var pumpList = new List<int>(pumps);
                pumpList.Add(1);
                pumpList.Sort();
                pumps = pumpList.ToArray();
            }
            if (!pSet1Check.Checked)
            {
                var pumpList = new List<int>(pumps);
                pumpList.Remove(1);
                pumps = pumpList.ToArray();
            }
        }

        //Update pump 2 active status
        private void pSet2Check_CheckedChanged(object sender, EventArgs e)
        {
            if (pSet2Check.Checked)
            {
                var pumpList = new List<int>(pumps);
                pumpList.Add(2);
                pumpList.Sort();
                pumps = pumpList.ToArray();
            }
            if (!pSet2Check.Checked)
            {
                var pumpList = new List<int>(pumps);
                pumpList.Remove(2);
                pumps = pumpList.ToArray();
            }
        }

        //Update pump 3 active status
        private void pSet3Check_CheckedChanged(object sender, EventArgs e)
        {
            if (pSet3Check.Checked)
            {
                var pumpList = new List<int>(pumps);
                pumpList.Add(3);
                pumpList.Sort();
                pumps = pumpList.ToArray();
            }
            if (!pSet3Check.Checked)
            {
                var pumpList = new List<int>(pumps);
                pumpList.Remove(3);
                pumps = pumpList.ToArray();
            }
        }

        //Update pump 4 active status
        private void pSet4Check_CheckedChanged(object sender, EventArgs e)
        {
            if (pSet4Check.Checked)
            {
                var pumpList = new List<int>(pumps);
                pumpList.Add(4);
                pumpList.Sort();
                pumps = pumpList.ToArray();
            }
            if (!pSet4Check.Checked)
            {
                var pumpList = new List<int>(pumps);
                pumpList.Remove(4);
                pumps = pumpList.ToArray();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            //stopStatus = 0;
        }
    }
}