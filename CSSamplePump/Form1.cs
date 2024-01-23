using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private string[] PRIMELIPID = { "I2R", "V1200R", "A2900R", "V1200R", "I1R", "A0R", "I2R", "A1000R"};
        private string[] PRIMECITRATE = { "I3R", "V1200R", "A750R", "V1200R", "I4R", "A0R", "I3R", "A501R"};
        private string[] WASHLIPID = {"I4R","V1200R","A2900R","I2R","A0R","I4R","A2900R","I2R","A0R",
                                         "A2900R","I3R","A0R","I2R","A2900R","I3R","A0R"};
        private string[] WASHCITRATE = {"I1R", "V1200R", "A2900R", "I3R", "A0R", "I1R", "A2900R", "I3R", "A0R",
                                         "A2900R", "I2R", "A0R","I3R", "A2900R", "I2R", "A0R"};
        private string[] FORMULATELIPID = {"I3R" ,"V100R" , "A1R"};
        private string[] FORMULATECITRATE = {"I2R" ,"V100R" , "A1R"};
        private string[] PURGELIPID = { "I2R","V1200R","A2900R","I1R","A0R","I3R","A2900R","I1R","A0R"};
        private string[] PURGECITRATE = { "I3R","V1200R","A2900R","I4R","A0R","I2R","A2900R","I4R","A0R"};
        private int[] pumps = {1};
        private int stopStatus = 0;

        





        //Initializes the serial port and the log window

        private void cmdOpenCom_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkLog.Checked == true)
                {
                    citratePumps.PumpSetLogWnd(listBox1.Handle.ToInt32());
                    citratePumps2.PumpSetLogWnd(listBox1.Handle.ToInt32());
                    lipidPumps.PumpSetLogWnd(listBox1.Handle.ToInt32());
                    lipidPumps2.PumpSetLogWnd(listBox1.Handle.ToInt32());
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
                    citratePumps2.BaudRate = PUMPCOMMSERVERLib.EBaudRate.Baud9600;
                    lipidPumps.BaudRate = PUMPCOMMSERVERLib.EBaudRate.Baud9600;
                    lipidPumps2.BaudRate = PUMPCOMMSERVERLib.EBaudRate.Baud9600;
                }

                //Open the specified COM port and declare variables for each pump
                char[] citrateCOM = txtComPort.Text.ToCharArray();
                char[] lipidCOM = txtComPort2.Text.ToCharArray();

                citratePumps.PumpInitComm(byte.Parse(citrateCOM[0].ToString()));
                //citratePumps2.PumpInitComm(byte.Parse(citrateCOM[1].ToString()));
                lipidPumps.PumpInitComm(byte.Parse(lipidCOM[0].ToString()));
                //lipidPumps2.PumpInitComm(byte.Parse(lipidCOM[1].ToString()));


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
            listBox2.Items.Clear();

            worklistSelectDialog.ShowDialog();
            txtWorklisFpth.Text = worklistSelectDialog.FileName;


            string [] worklistRows = File.ReadAllLines(txtWorklisFpth.Text);

            foreach (string row in worklistRows)
            {
                listBox2.Items.Add(row);
            }
        }

        //Parses list of commands for action and complete one at a time
        private async Task<string> sendCommandAsync(string[] commands, string pumpNum, PUMPCOMMSERVERLib.PumpCommClass pumpserver, PUMPCOMMSERVERLib.PumpCommClass pumpservertwin, CancellationToken c, CancellationTokenSource cts)
        {
            
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
                        await Task.Delay(4000);
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

            await InitializeAllPumps(pumps);
            
        }

        //initializes pairs of pumps simultaneously
        private async Task InitializeAllPumps(int[] pumps)
        {

            foreach (int pump in pumps)
            {
                CancellationTokenSource cts = new CancellationTokenSource();

                if (pump == 1 || pump == 2)
                {
                    var taskCitrate = sendCommandAsync(INIT, pump.ToString(), citratePumps, lipidPumps, cts.Token, cts);
                    var taskLipid = sendCommandAsync(INIT, pump.ToString(), lipidPumps, citratePumps, cts.Token, cts);
                    await Task.WhenAll(taskCitrate, taskLipid);
                }
                if (pump == 3 || pump == 4)
                {
                    var taskCitrate = sendCommandAsync(INIT, pump.ToString(), citratePumps2, lipidPumps2, cts.Token, cts);
                    var taskLipid = sendCommandAsync(INIT, pump.ToString(), lipidPumps2, citratePumps2, cts.Token, cts);
                    await Task.WhenAll(taskCitrate, taskLipid);
                }

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
                    }
                }
                catch (Exception ex)
                {
                    cts.Cancel();
                    listBox1.Items.Add(ex.ToString());
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
                
            }
            listBox1.Items.Add("Init Complete");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        //Init Prime Click
        private async void btnStart_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Parsing formulation worklist...");

            if (!File.Exists(txtWorklisFpth.Text))
            {
                listBox1.Items.Add("ERROR!: Could ot find the file specified. Please select a valid filepath and retry");
                return;
            }

            if (listBox2.Items.Count < 1)
            {
                listBox1.Items.Add("ERROR!: No Active worklist. Please import a worklist forthe fomulation(s).");
                return;
            }

            string [] conditions = File.ReadAllLines(txtWorklisFpth.Text);
            int numconditions = conditions.Length - 1;
            listBox1.Items.Add("Preparing to run " + numconditions + " Formulations");

            int index = 1;

            foreach(string condition in conditions)
            {
                string[] settings = condition.Split(',');

                if(!settings[0].Contains("Lipid"))
                {
                    listBox2.SelectedIndex = index;

                    pump1Vol.Text = settings[1];
                    pump2Vol.Text = settings[3];

                    pump1Speed.Text = (Convert.ToDouble(settings[4]) / 4).ToString();
                    pump2Speed.Text = ((Convert.ToDouble(settings[4]) / 4) * 3).ToString(); 

                    listBox1.Items.Add("Priming...");

                    var primeTask = PrimeAllPumps();

                    await Task.WhenAll(primeTask);

                    listBox1.Items.Add("Formulating...");

                    var frunFormulate = runFormulation();

                    await Task.WhenAll(frunFormulate);

                    for (int i = 0; i < Convert.ToInt32(settings[5]); i++)
                    {
                        listBox1.Items.Add("Washing " + (i + 1) + " of " + settings[5] + " times...");

                        var runWash = WashAllPumps();

                        await Task.WhenAll(runWash);
                    }

                    index++;

                }
            }

            listBox1.Items.Add("All Formulations Complete!");

            listBox2.Items.Clear();
        }

        //Primes Pairs of Pumps Simultaneously
        private async Task<string> PrimeAllPumps()
        {
            double pumpLipidVol = ((Int32.Parse(pump1Vol.Text) / 250) * (3000));
            double pumpCitrateVol = ((Int32.Parse(pump2Vol.Text) / 1000) * (3000));

            PRIMELIPID[PRIMELIPID.Length-1] = "A" + pumpLipidVol + "R";
            PRIMECITRATE[PRIMECITRATE.Length-1] = "A" + pumpCitrateVol + "R";

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
            return "complete";
        }

        //Wash Button Click
        private void btnWash_Click(object sender, EventArgs e)
        {
            WashAllPumps();
        }

        //Washed Pairs of Pumps Simultaneously
        private async Task<string> WashAllPumps()
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

            return "complete";
        }

        //Formulation Button Click
        private void btnFormulate_Click(object sender, EventArgs e)
        {
            runFormulation();
        }

        //Formulate Pairs of Pumps Simultaneously
        private async Task<string> runFormulation()
        {
            double pumpLipidspeed = ((Double.Parse(pump1Speed.Text)/60) * (3000/.25));
            double pumpCitratespeed = ((Double.Parse(pump2Speed.Text)/60) * (3000));

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

            return "complete";
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
        private void btnSendCommand_Click(object sender, EventArgs e)
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
            stopStatus = 0;
        }

        private void txtComPort2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}