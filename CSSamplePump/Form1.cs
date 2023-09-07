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
        private string[] PRIMELIPID = { "I2R", "V1200R", "A2900R", "V1200R", "I1R", "A0R" };
        private string[] PRIMECITRATE = { "I3R", "V1200R", "A750R", "V1200R", "I4R", "A0R" };
        private string[] WASHLIPID = { };
        private string[] WASHCITRATE = { };
        private string[] FORMULATE = { };
        private string[] PURGE = { };
        private int[] pumps = {1};
            


    

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
            int txtDeviceNo = Int32.Parse(pumpSetNum.Text);
            int txtDeviceNo2 = txtDeviceNo;

            string answer = "";
                //Converting values to be sent to the pump
                //asssumes a  250ul syringe
                //change this one to use the 250ul syringe
                int pump1speed = ((Int32.Parse(pump1Speed.Text)) * (3000)) / (250);
                string pump1Volume = (Int32.Parse(pump1Vol.Text) * 12).ToString();
                string pump1dispense = "M" + (Int32.Parse(pump1delay.Text)) + ",V" + pump1speed + ",A1R";
                //assumses a 250ul syringe
                int pump2speed = ((Int32.Parse(pump2Speed.Text)) * (3000)) / (1000);
                string pump2Volume = (Int32.Parse(pump2Vol.Text) * 3).ToString();
                string pump2dispense = "M" + (Int32.Parse(pump2delay.Text)) + ",V" + pump2speed + ",A1R";


                try
                {
                    

                    {
                        //pump 1 set the aspirate position to the right
                        //pumpServer2.PumpSendCommand("I2R", byte.Parse(txtDeviceNo.ToString()), answer);

                        //pump 2 set the aspirate position to the left
                        //pumpServer.PumpSendCommand("I3R", byte.Parse(txtDeviceNo2.ToString()), answer);
                        //pumpServer.PumpWaitForAll();
                        //pumpServer2.PumpWaitForAll();

                        //pre-priming the lines 
                        //pumpServer2.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo.ToString()), answer);
                        //pumpServer.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo2.ToString()), answer);
                        //line below was 800 before  converting
                        //2900 for a 250ul syringe
                        //pumpServer2.PumpSendNoWait("A2900,V1200R", byte.Parse(txtDeviceNo.ToString()));
                        //pumpServer.PumpSendCommand("A750,V1200R", byte.Parse(txtDeviceNo2.ToString()), answer);
                        //pumpServer.PumpWaitForAll();
                        //pumpServer2.PumpWaitForAll();
                        MessageBox.Show("Continue?");
                        //switching to waste port
                        //pumpServer2.PumpSendCommand("I1R", byte.Parse(txtDeviceNo.ToString()), answer);
                        //pumpServer.PumpSendCommand("I4R", byte.Parse(txtDeviceNo2.ToString()), answer);
                        //pumpServer.PumpWaitForAll();
                        //pumpServer2.PumpWaitForAll();
                        //pumpServer2.PumpSendNoWait("A0R", byte.Parse(txtDeviceNo.ToString()));
                        //pumpServer.PumpSendCommand("A0R", byte.Parse(txtDeviceNo2.ToString()), answer);
                        //pumpServer.PumpWaitForAll();
                        //pumpServer2.PumpWaitForAll();
                        Thread.Sleep(1000);
                        //switching back to the inlet
                        //pumpServer2.PumpSendCommand("I2R", byte.Parse(txtDeviceNo.ToString()), answer);
                        //pumpServer.PumpSendCommand("I3R", byte.Parse(txtDeviceNo2.ToString()), answer);
                        //pumpServer.PumpWaitForAll();
                        //pumpServer2.PumpWaitForAll();
                        Thread.Sleep(5000);

                        //pumpServer2.PumpSendCommand("?6", byte.Parse(txtDeviceNo.ToString()), answer);
                        listBox1.Items.Add(answer);
                        MessageBox.Show(answer);
                        //aspirating the phases
                        //pumpServer2.PumpSendCommand("A" + pump1Volume + "R", byte.Parse(txtDeviceNo.ToString()), answer);
                        //pumpServer.PumpSendCommand("A" + pump2Volume + "R", byte.Parse(txtDeviceNo2.ToString()), answer);
                        //pumpServer.PumpWaitForAll();
                        //pumpServer2.PumpWaitForAll();
                        //switching ports to the T
                        //pumpServer2.PumpSendCommand("I3R", byte.Parse(txtDeviceNo.ToString()), answer);
                        //pumpServer.PumpSendCommand("I2R", byte.Parse(txtDeviceNo2.ToString()), answer);
                        //pumpServer.PumpWaitForAll();
                        //pumpServer2.PumpWaitForAll();
                        //MessageBox.Show("Continue?");

                        //pumpServer2.PumpSendNoWait(pump1dispense.ToString(), byte.Parse(txtDeviceNo.ToString()));
                        //pumpServer.PumpSendNoWait(pump2dispense.ToString(), byte.Parse(txtDeviceNo2.ToString()));
                    }
                }
                catch (System.Runtime.InteropServices.COMException err)
                {
                    txtErr.Text = (err.ErrorCode & 0x3f).ToString();
                    MessageBox.Show(err.Message);
                }


            

 
                //aspirate a full syringe volume
                //pumpServer2.PumpSendNoWait("I4R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("I1R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo.ToString()), answer);
                //pumpServer.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpSendNoWait("A2900,V1200R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("A2900,V1200R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpWaitForAll();
                //pumpServer.PumpWaitForAll();
                //dispense a full syringe volume to the inlet
                //pumpServer2.PumpSendNoWait("I3R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("I2R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo.ToString()), answer);
                //pumpServer.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpSendNoWait("A0,V1200R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("A0,V1200R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer.PumpWaitForAll();
                //pumpServer2.PumpWaitForAll();
                //aspirate a full syringe volume
                //pumpServer2.PumpSendNoWait("I4R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("I1R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo.ToString()), answer);
                //pumpServer.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpSendNoWait("A2900,V2500R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("A2900,V2500R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpWaitForAll();
                //pumpServer.PumpWaitForAll();
                //dispense a full syringe volume to the inlet
                //pumpServer2.PumpSendNoWait("I2R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("I3R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo.ToString()), answer);
                //pumpServer.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpSendNoWait("A0,V1200R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("A0,V1200R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer.PumpWaitForAll();
                //pumpServer2.PumpWaitForAll();
                //begin aspirating another syringe volume
                //pumpServer2.PumpSendNoWait("I4R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("I1R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo.ToString()), answer);
                //pumpServer.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpSendNoWait("A2900,V1200R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("A2900,V1200R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer.PumpWaitForAll();
                //pumpServer2.PumpWaitForAll();
                //begin dispensing the second syringe volume to the inlet
                //pumpServer2.PumpSendNoWait("I2R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("I3R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo.ToString()), answer);
                //pumpServer.PumpSendCommand("V1200R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpSendNoWait("A0,V1500R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("A0,V1500R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpWaitForAll();
                //pumpServer.PumpWaitForAll();
                //aspirate a syringe volume to send to T
                //pumpServer2.PumpSendNoWait("A2900R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("A2900R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer.PumpWaitForAll();
                //pumpServer2.PumpWaitForAll();
                //switch the valves and dispense a full syringe volume to the T
                //pumpServer2.PumpSendNoWait("I3R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("I2R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer.PumpWaitForAll();
                //pumpServer2.PumpWaitForAll();
                //pumpServer2.PumpSendNoWait("A0R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("A0R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer.PumpWaitForAll();
                //pumpServer2.PumpWaitForAll();
                //switch the valves and aspirate another syringe volume from the inlet
                //pumpServer2.PumpSendNoWait("I2R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("I3R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer.PumpWaitForAll();
                //pumpServer2.PumpWaitForAll();
                //pumpServer2.PumpSendNoWait("A2900R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("A2900R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer.PumpWaitForAll();
                //pumpServer2.PumpWaitForAll();
                //switch the valves and dispense that volume to the T
                //pumpServer2.PumpSendNoWait("I3R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("I2R", byte.Parse(txtDeviceNo2.ToString()), answer);
                //pumpServer2.PumpSendNoWait("A0R", byte.Parse(txtDeviceNo.ToString()));
                //pumpServer.PumpSendCommand("A0R", byte.Parse(txtDeviceNo2.ToString()), answer);


                 

        }

        //Parses list of commands for action and completes one at a time
        public async Task<string> sendCommandAsync(string[] commands, string pumpNum, string pumpType)
        {
            string status = "";
            foreach (string command in commands)
            {
                //pumpserver.PumpSendCommand(command, byte.Parse(pumpNum), status);
                listBox1.Items.Add("Sending: " + command + " pump number: " + pumpNum + " pump type: " + pumpType);
                await Task.Delay(1000);
            }
            return pumpNum;
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

        private void btnInit_Click(object sender, EventArgs e)
        {
            
            InitializeAllPumps(pumps);
        }

        private void btnPrime_Click(object sender, EventArgs e)
        {
            int[] pumps = { 1, 2, 3, 4 };
            PrimeAllPumps(pumps);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = comboBox1.Text;

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
            }
        }

        private void btnEditStep_Click(object sender, EventArgs e)
        {
            string text = listBox2.SelectedItem.ToString();
            txtEditStepBox.Text = text;
        }

        private void btnSaveStep_Click(object sender, EventArgs e)
        {
            string text = txtEditStepBox.Text;
            
            int index = listBox2.SelectedIndex;
            listBox2.Items.Clear();
            txtEditStepBox.Text = "";
            string selection = comboBox1.Text;

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
            }

            listBox2.Refresh();
        }

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

        //private void (object sender, EventArgs e)
        //{

        //}

        //private void label4_Click(object sender, EventArgs e)
        //{

        //}
    }
}