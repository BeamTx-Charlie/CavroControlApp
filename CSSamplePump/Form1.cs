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


        private string[] INIT = { "Z0R" };
        private string[] PRIMELIPID = { "I2R", "V1200R", "A2900R", "V1200R", "I1R", "A0R", "I2R", "A6000R"};
        private string[] PRIMECITRATE = { "I3R", "V1200R", "A750R", "V1200R", "I4R", "A0R", "I3R", "A501R"};
        private string[] WASHLIPID = {"I4R", "V1200R", "A2900R", "V1200R", "I2R", "A0R", "I4R", "A2900R", "I2R", "A0R",
                                        "I4R", "A2900R", "I2R", "A0R", "A2900R", "I3R", "A0R", "I2R","A2900R", "I3R", "A0R"};
        private string[] WASHCITRATE = {"I1R", "V1200R", "A2900R" , "V1200R", "I3R", "A0R", "I1R", "A2900R", "I3R", "A0R",
                                        "I1R", "A2900R", "I3R", "A0R", "A2900R", "I2R", "A0R", "I3R","A2900R", "I2R", "A0R" };
        private string[] FORMULATELIPID = {"I3R" ,"V100R" , "A1R"};
        private string[] FORMULATECITRATE = {"I2R" ,"V100R" , "A1R"};
        private string[] PURGE = { };
        private int[] pumps = {1};
        private int stopStatus = 0;

        





        //Initializes the serial port and the log window

        private void cmdOpenCom_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkLog.Checked == true)
                {
                    //pumpServer.PumpSetLogWnd(listBox1.Handle.ToInt32());
                    //pumpServer2.PumpSetLogWnd(listBox1.Handle.ToInt32());
                }

                //Specify the baud rate
                if (cmbBaudRate.Text == "38400")
                {
                    //pumpServer.BaudRate = PUMPCOMMSERVERLib.EBaudRate.Baud38400;
                    //pumpServer2.BaudRate = PUMPCOMMSERVERLib.EBaudRate.Baud38400;
                }
                else
                {
                    //pumpServer.BaudRate = PUMPCOMMSERVERLib.EBaudRate.Baud9600;
                    //pumpServer2.BaudRate = PUMPCOMMSERVERLib.EBaudRate.Baud9600;
                }

                //Open the specified COM port and declare variables for each pump
                
                string initsuccess = "";
                //pumpServer.PumpInitComm(byte.Parse(txtComPort.Text));
                //pumpServer2.PumpInitComm(byte.Parse(txtComPort2.Text));
                //pump1 - set the initialize output to the right valve when looking head on
                //port 1 is the 1pm position and remaining valves are clockwise
                //pumpServer2.PumpSendCommand("Z0R", byte.Parse(1.ToString()), initsuccess);
                //pumpServer.PumpSendCommand("Z0R", byte.Parse(1.ToString()), initsuccess);
                //pumpServer2.PumpWaitForAll();
                //pumpServer.PumpWaitForAll();
                //pumpServer2.PumpSendCommand("Z0R", byte.Parse(2.ToString()), initsuccess);
                //pumpServer.PumpSendCommand("Z0R", byte.Parse(2.ToString()), initsuccess);
            }
            catch (System.Runtime.InteropServices.COMException err)
            {
                MessageBox.Show(err.Message);
                txtErr.Text = err.ErrorCode.ToString();

            }
        
        }

        //Converting values to be sent to the pump

        private async void cmdSendCommand_Click(object sender, EventArgs e)
        {
            int pumpLipidspeed = ((Int32.Parse(pump1Speed.Text)) * (3000)) / (250);
            int pumpCitratespeed = ((Int32.Parse(pump2Speed.Text)) * (3000)) / (1000);

            FORMULATELIPID[1] = "V" + pumpLipidspeed + "R";
            FORMULATECITRATE[1] = "V" + pumpCitratespeed + "R";

            string pump1Volume =  "A" + (Int32.Parse(pump1Vol.Text) * 12).ToString() + "R" ;
            string pump2Volume =  "A" + (Int32.Parse(pump2Vol.Text) * 3).ToString() + "R" ;

            PRIMELIPID[PRIMELIPID.Length - 1] = pump1Volume;
            PRIMECITRATE[PRIMELIPID.Length - 1] = pump2Volume;
                 

        }

        //Parses list of commands for action and complete one at a time
        public async Task<string> sendCommandAsync(string[] commands, string pumpNum, string pumpType)
        {
            string status = "";
            foreach (string command in commands)
            {
                    //pumpserver.PumpSendCommand(command, byte.Parse(pumpNum), status);
                    listBox1.Items.Add("Sending: " + command + " pump number: " + pumpNum + " pump type: " + pumpType);
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                    await Task.Delay(1000);
            }
            return pumpNum;
        }

        //Init Button Click
        private void btnInit_Click(object sender, EventArgs e)
        {

            InitializeAllPumps(pumps);
        }

        //initializes pairs of pumps simultaneously
        private async void InitializeAllPumps(int[] pumps)
        {
            var tasks = new List<Task<string>>();
            foreach (int pump in pumps)
            {
                var response = sendCommandAsync(INIT, pump.ToString(), "Citrate");
                tasks.Add(response);
                response = sendCommandAsync(INIT, pump.ToString(), "Lipid");
                tasks.Add(response);
                await Task.WhenAll(tasks);
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
            var tasks = new List<Task<string>>();
            foreach (int pump in pumps)
            {
                var response = sendCommandAsync(PRIMECITRATE, pump.ToString(), "Citrate");
                tasks.Add(response);
                response = sendCommandAsync(PRIMELIPID, pump.ToString(), "Lipid");
                tasks.Add(response);
                await Task.WhenAll(tasks);
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
                var response = sendCommandAsync(WASHCITRATE, pump.ToString(), "Citrate");
                tasks.Add(response);
                response = sendCommandAsync(WASHLIPID, pump.ToString(), "Lipid");
                tasks.Add(response);
                await Task.WhenAll(tasks);
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
            int pumpLipidspeed = ((Int32.Parse(pump1Speed.Text)) * (3000)) / (250);
            int pumpCitratespeed = ((Int32.Parse(pump2Speed.Text)) * (3000)) / (1000);

            FORMULATELIPID[1] = "V" + pumpLipidspeed + "R";
            FORMULATECITRATE[1] = "V" + pumpCitratespeed + "R";

            var tasks = new List<Task<string>>();
            foreach (int pump in pumps)
            {
                var response = sendCommandAsync(FORMULATECITRATE, pump.ToString(), "Citrate");
                tasks.Add(response);
                response = sendCommandAsync(FORMULATELIPID, pump.ToString(), "Lipid");
                tasks.Add(response);
                await Task.WhenAll(tasks);
            }
        }

        //Send Manual Command Click
        private async void btnSendCommand_Click(object sender, EventArgs e)
        {
            string phaseSelect = phaseSelectDrop.SelectedItem.ToString();
            string pumpSelect = pumpNumDrop.SelectedItem.ToString();
            string[] command = { txtManCommand.Text };
            var tasks = new List<Task<string>>();

            if (phaseSelect == "Citrate")
            {
                var answer = sendCommandAsync(command, pumpSelect, "Citrate");
                tasks.Add(answer);
                await Task.WhenAll(tasks);
            }

            if (phaseSelect == "Lipid")
            {
                var answer = sendCommandAsync(command, pumpSelect, "Lipid");
                tasks.Add(answer);
                await Task.WhenAll(tasks);
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
                case "Purge":
                    foreach (string item in PURGE)
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
                case "Purge":
                    PURGE[index] = text;
                    foreach (string item in PURGE)
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
            stopStatus = 1;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            stopStatus = 0;
        }
    }
}