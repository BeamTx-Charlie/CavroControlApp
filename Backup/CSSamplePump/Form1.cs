using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Initializes the serial port and the log window
        private void cmdOpenCom_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkLog.Checked == true)
                {
                    pumpServer.PumpSetLogWnd(listBox1.Handle.ToInt32());
                }

                //Specify the baud rate
                if (cmbBaudRate.Text == "38400")
                {
                    pumpServer.BaudRate = PUMPCOMMSERVERLib.EBaudRate.Baud38400;
                }
                else
                {
                    pumpServer.BaudRate = PUMPCOMMSERVERLib.EBaudRate.Baud9600;
                }

                //Open the specified COM port
                pumpServer.PumpInitComm(byte.Parse(txtComPort.Text));

            }
            catch (System.Runtime.InteropServices.COMException err)
            {
                MessageBox.Show(err.Message);
                txtErr.Text = err.ErrorCode.ToString();
            }
        }

        private void cmdSendCommand_Click(object sender, EventArgs e)
        {
            try
            {
                string answer = "";
                //send the specified command to the specified device address
                pumpServer.PumpSendCommand(txtCommand.Text, byte.Parse(txtDeviceNo.Text), ref answer);

                // display device answer
                txtReply.Text = answer;
            }
            catch (System.Runtime.InteropServices.COMException err)
            {
                txtErr.Text = (err.ErrorCode & 0x3f).ToString();
                MessageBox.Show(err.Message);
            }

        }

    }
}