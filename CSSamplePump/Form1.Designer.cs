using System;
using System.Diagnostics.Tracing;
using System.Windows.Forms;

namespace CSSample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 

        public event EventHandler Shown;
        private void FormShown (object sender, EventArgs e)
        {
            MessageBox.Show("Did we go here Form.Shown event");
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.txtComPort = new System.Windows.Forms.TextBox();
            this.cmdOpenCom = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.runwash = new System.Windows.Forms.CheckBox();
            this.pump2delay = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pump1delay = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pump2Vol = new System.Windows.Forms.TextBox();
            this.pump1Vol = new System.Windows.Forms.TextBox();
            this.P = new System.Windows.Forms.Label();
            this.pump2Speed = new System.Windows.Forms.TextBox();
            this.txtErr = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReply = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdSendCommand = new System.Windows.Forms.Button();
            this.pump1Speed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.txtComPort2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pumpSetNum = new System.Windows.Forms.TextBox();
            this.txtManCommand = new System.Windows.Forms.TextBox();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.phaseSelectDrop = new System.Windows.Forms.ComboBox();
            this.pumpNumDrop = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pumpNumDrop);
            this.groupBox1.Controls.Add(this.phaseSelectDrop);
            this.groupBox1.Controls.Add(this.btnSendCommand);
            this.groupBox1.Controls.Add(this.txtManCommand);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtComPort2);
            this.groupBox1.Controls.Add(this.chkLog);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbBaudRate);
            this.groupBox1.Controls.Add(this.txtComPort);
            this.groupBox1.Controls.Add(this.cmdOpenCom);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 147);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initialize";
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Checked = true;
            this.chkLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLog.Location = new System.Drawing.Point(17, 67);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(94, 17);
            this.chkLog.TabIndex = 5;
            this.chkLog.Text = "Log Serial Info";
            this.chkLog.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Baud Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "COM Port 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "9600",
            "38400"});
            this.cmbBaudRate.Location = new System.Drawing.Point(382, 31);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(122, 21);
            this.cmbBaudRate.TabIndex = 2;
            this.cmbBaudRate.Text = "9600";
            // 
            // txtComPort
            // 
            this.txtComPort.Location = new System.Drawing.Point(227, 32);
            this.txtComPort.Name = "txtComPort";
            this.txtComPort.Size = new System.Drawing.Size(58, 20);
            this.txtComPort.TabIndex = 1;
            this.txtComPort.Text = "3";
            // 
            // cmdOpenCom
            // 
            this.cmdOpenCom.Location = new System.Drawing.Point(17, 30);
            this.cmdOpenCom.Name = "cmdOpenCom";
            this.cmdOpenCom.Size = new System.Drawing.Size(129, 22);
            this.cmdOpenCom.TabIndex = 0;
            this.cmdOpenCom.Text = "Open COM port";
            this.cmdOpenCom.UseVisualStyleBackColor = true;
            this.cmdOpenCom.Click += new System.EventHandler(this.cmdOpenCom_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pumpSetNum);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.runwash);
            this.groupBox2.Controls.Add(this.pump2delay);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.pump1delay);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.pump2Vol);
            this.groupBox2.Controls.Add(this.pump1Vol);
            this.groupBox2.Controls.Add(this.P);
            this.groupBox2.Controls.Add(this.pump2Speed);
            this.groupBox2.Controls.Add(this.txtErr);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtReply);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmdSendCommand);
            this.groupBox2.Controls.Add(this.pump1Speed);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(21, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 145);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set Parameters";
            // 
            // runwash
            // 
            this.runwash.AutoSize = true;
            this.runwash.Cursor = System.Windows.Forms.Cursors.No;
            this.runwash.Location = new System.Drawing.Point(427, 18);
            this.runwash.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.runwash.Name = "runwash";
            this.runwash.Size = new System.Drawing.Size(83, 17);
            this.runwash.TabIndex = 21;
            this.runwash.Text = "Run Wash?";
            this.runwash.UseVisualStyleBackColor = true;
            // 
            // pump2delay
            // 
            this.pump2delay.Location = new System.Drawing.Point(251, 96);
            this.pump2delay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pump2delay.Name = "pump2delay";
            this.pump2delay.Size = new System.Drawing.Size(68, 20);
            this.pump2delay.TabIndex = 20;
            this.pump2delay.Text = "1000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(249, 79);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Pump 2 Delay (ms)";
            // 
            // pump1delay
            // 
            this.pump1delay.Location = new System.Drawing.Point(251, 56);
            this.pump1delay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pump1delay.Name = "pump1delay";
            this.pump1delay.Size = new System.Drawing.Size(68, 20);
            this.pump1delay.TabIndex = 18;
            this.pump1delay.Text = "1100";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(249, 41);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Pump 1 Delay (ms)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(106, 79);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Pump 2 Velocity (ul/sec)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Pump 1 Velocity (ul/sec)";
            // 
            // pump2Vol
            // 
            this.pump2Vol.Location = new System.Drawing.Point(7, 90);
            this.pump2Vol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pump2Vol.Name = "pump2Vol";
            this.pump2Vol.Size = new System.Drawing.Size(68, 20);
            this.pump2Vol.TabIndex = 14;
            this.pump2Vol.Text = "167";
            // 
            // pump1Vol
            // 
            this.pump1Vol.Location = new System.Drawing.Point(9, 56);
            this.pump1Vol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pump1Vol.Name = "pump1Vol";
            this.pump1Vol.Size = new System.Drawing.Size(68, 20);
            this.pump1Vol.TabIndex = 13;
            this.pump1Vol.Text = "500";
            // 
            // P
            // 
            this.P.AutoSize = true;
            this.P.Location = new System.Drawing.Point(5, 75);
            this.P.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P.Name = "P";
            this.P.Size = new System.Drawing.Size(81, 13);
            this.P.TabIndex = 12;
            this.P.Text = "Pump 2 Volume";
            // 
            // pump2Speed
            // 
            this.pump2Speed.Location = new System.Drawing.Point(106, 96);
            this.pump2Speed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pump2Speed.Name = "pump2Speed";
            this.pump2Speed.Size = new System.Drawing.Size(102, 20);
            this.pump2Speed.TabIndex = 11;
            this.pump2Speed.Text = "167";
            // 
            // txtErr
            // 
            this.txtErr.Location = new System.Drawing.Point(475, 122);
            this.txtErr.Name = "txtErr";
            this.txtErr.Size = new System.Drawing.Size(43, 20);
            this.txtErr.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(441, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Error";
            // 
            // txtReply
            // 
            this.txtReply.Location = new System.Drawing.Point(105, 122);
            this.txtReply.Name = "txtReply";
            this.txtReply.Size = new System.Drawing.Size(303, 20);
            this.txtReply.TabIndex = 7;
            this.txtReply.TextChanged += new System.EventHandler(this.txtReply_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Reply";
            // 
            // cmdSendCommand
            // 
            this.cmdSendCommand.Location = new System.Drawing.Point(403, 86);
            this.cmdSendCommand.Name = "cmdSendCommand";
            this.cmdSendCommand.Size = new System.Drawing.Size(115, 24);
            this.cmdSendCommand.TabIndex = 5;
            this.cmdSendCommand.Text = "Send Command";
            this.cmdSendCommand.UseVisualStyleBackColor = true;
            this.cmdSendCommand.Click += new System.EventHandler(this.cmdSendCommand_Click);
            // 
            // pump1Speed
            // 
            this.pump1Speed.Location = new System.Drawing.Point(106, 56);
            this.pump1Speed.Name = "pump1Speed";
            this.pump1Speed.Size = new System.Drawing.Size(102, 20);
            this.pump1Speed.TabIndex = 4;
            this.pump1Speed.Text = "500";
            this.pump1Speed.TextChanged += new System.EventHandler(this.txtCommand_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Pump 1 Volume";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Location = new System.Drawing.Point(21, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(541, 120);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logging";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(494, 82);
            this.listBox1.TabIndex = 0;
            // 
            // txtComPort2
            // 
            this.txtComPort2.Location = new System.Drawing.Point(227, 67);
            this.txtComPort2.Name = "txtComPort2";
            this.txtComPort2.Size = new System.Drawing.Size(58, 20);
            this.txtComPort2.TabIndex = 6;
            this.txtComPort2.Text = "8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "COM Port 2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(390, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Pump Set #";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // pumpSetNum
            // 
            this.pumpSetNum.Location = new System.Drawing.Point(459, 56);
            this.pumpSetNum.Name = "pumpSetNum";
            this.pumpSetNum.Size = new System.Drawing.Size(29, 20);
            this.pumpSetNum.TabIndex = 23;
            this.pumpSetNum.Text = "1";
            // 
            // txtManCommand
            // 
            this.txtManCommand.Location = new System.Drawing.Point(227, 109);
            this.txtManCommand.Name = "txtManCommand";
            this.txtManCommand.Size = new System.Drawing.Size(191, 20);
            this.txtManCommand.TabIndex = 8;
            this.txtManCommand.Text = "Manual Command";
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Location = new System.Drawing.Point(427, 106);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(92, 23);
            this.btnSendCommand.TabIndex = 9;
            this.btnSendCommand.Text = "Send Command";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // phaseSelectDrop
            // 
            this.phaseSelectDrop.FormattingEnabled = true;
            this.phaseSelectDrop.Items.AddRange(new object[] {
            "Lipid",
            "Citrate"});
            this.phaseSelectDrop.Location = new System.Drawing.Point(20, 109);
            this.phaseSelectDrop.MaxDropDownItems = 2;
            this.phaseSelectDrop.Name = "phaseSelectDrop";
            this.phaseSelectDrop.Size = new System.Drawing.Size(91, 21);
            this.phaseSelectDrop.TabIndex = 10;
            this.phaseSelectDrop.Text = "Phase Pump";
            // 
            // pumpNumDrop
            // 
            this.pumpNumDrop.FormattingEnabled = true;
            this.pumpNumDrop.Items.AddRange(new object[] {
            "1",
            "2"});
            this.pumpNumDrop.Location = new System.Drawing.Point(130, 109);
            this.pumpNumDrop.MaxDropDownItems = 2;
            this.pumpNumDrop.Name = "pumpNumDrop";
            this.pumpNumDrop.Size = new System.Drawing.Size(91, 21);
            this.pumpNumDrop.TabIndex = 12;
            this.pumpNumDrop.Text = "Pump Number";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 448);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdOpenCom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtComPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSendCommand;
        private System.Windows.Forms.TextBox pump1Speed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReply;
        private System.Windows.Forms.TextBox txtErr;

        public PUMPCOMMSERVERLib.PumpCommClass pumpServer = new PUMPCOMMSERVERLib.PumpCommClass();
        public PUMPCOMMSERVERLib.PumpCommClass pumpServer2 = new PUMPCOMMSERVERLib.PumpCommClass();
        private System.Windows.Forms.TextBox pump2Speed;
        private System.Windows.Forms.Label P;
        private System.Windows.Forms.TextBox pump2Vol;
        private System.Windows.Forms.TextBox pump1Vol;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox pump1delay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox pump2delay;
        private CheckBox runwash;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Label label4;
        private TextBox txtComPort2;
        private Label label11;
        private TextBox pumpSetNum;
        private ComboBox pumpNumDrop;
        private ComboBox phaseSelectDrop;
        private Button btnSendCommand;
        private TextBox txtManCommand;
    }
}

