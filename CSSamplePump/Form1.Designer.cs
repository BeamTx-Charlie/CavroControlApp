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
            this.btnResume = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pumpNumDrop = new System.Windows.Forms.ComboBox();
            this.phaseSelectDrop = new System.Windows.Forms.ComboBox();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.txtManCommand = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComPort2 = new System.Windows.Forms.TextBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.txtComPort = new System.Windows.Forms.TextBox();
            this.cmdOpenCom = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPurge = new System.Windows.Forms.Button();
            this.btnWash = new System.Windows.Forms.Button();
            this.btnFormulate = new System.Windows.Forms.Button();
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
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.stepSelect = new System.Windows.Forms.ComboBox();
            this.btnEditStep = new System.Windows.Forms.Button();
            this.btnSaveStep = new System.Windows.Forms.Button();
            this.txtEditStepBox = new System.Windows.Forms.TextBox();
            this.pSet1Check = new System.Windows.Forms.CheckBox();
            this.pSet4Check = new System.Windows.Forms.CheckBox();
            this.pSet3Check = new System.Windows.Forms.CheckBox();
            this.pSet2Check = new System.Windows.Forms.CheckBox();
            this.worklistSelectDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtWorklisFpth = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnResume);
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
            this.groupBox1.Location = new System.Drawing.Point(32, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(812, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initialize";
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(640, 122);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(138, 34);
            this.btnResume.TabIndex = 14;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(452, 22);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(138, 34);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pumpNumDrop
            // 
            this.pumpNumDrop.FormattingEnabled = true;
            this.pumpNumDrop.Items.AddRange(new object[] {
            "1",
            "2"});
            this.pumpNumDrop.Location = new System.Drawing.Point(195, 168);
            this.pumpNumDrop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pumpNumDrop.MaxDropDownItems = 2;
            this.pumpNumDrop.Name = "pumpNumDrop";
            this.pumpNumDrop.Size = new System.Drawing.Size(134, 28);
            this.pumpNumDrop.TabIndex = 12;
            this.pumpNumDrop.Text = "Pump Number";
            // 
            // phaseSelectDrop
            // 
            this.phaseSelectDrop.FormattingEnabled = true;
            this.phaseSelectDrop.Items.AddRange(new object[] {
            "Lipid",
            "Citrate"});
            this.phaseSelectDrop.Location = new System.Drawing.Point(30, 168);
            this.phaseSelectDrop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.phaseSelectDrop.MaxDropDownItems = 2;
            this.phaseSelectDrop.Name = "phaseSelectDrop";
            this.phaseSelectDrop.Size = new System.Drawing.Size(134, 28);
            this.phaseSelectDrop.TabIndex = 10;
            this.phaseSelectDrop.Text = "Phase Pump";
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Location = new System.Drawing.Point(640, 163);
            this.btnSendCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(138, 35);
            this.btnSendCommand.TabIndex = 9;
            this.btnSendCommand.Text = "Send Command";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // txtManCommand
            // 
            this.txtManCommand.Location = new System.Drawing.Point(340, 168);
            this.txtManCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtManCommand.Name = "txtManCommand";
            this.txtManCommand.Size = new System.Drawing.Size(284, 26);
            this.txtManCommand.TabIndex = 8;
            this.txtManCommand.Text = "Manual Command";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 109);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "COM Port 2";
            // 
            // txtComPort2
            // 
            this.txtComPort2.Location = new System.Drawing.Point(340, 103);
            this.txtComPort2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtComPort2.Multiline = true;
            this.txtComPort2.Name = "txtComPort2";
            this.txtComPort2.Size = new System.Drawing.Size(85, 53);
            this.txtComPort2.TabIndex = 6;
            this.txtComPort2.Text = "8\r\n9\r\n";
            this.txtComPort2.TextChanged += new System.EventHandler(this.txtComPort2_TextChanged);
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Checked = true;
            this.chkLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLog.Location = new System.Drawing.Point(26, 103);
            this.chkLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(138, 24);
            this.chkLog.TabIndex = 5;
            this.chkLog.Text = "Log Serial Info";
            this.chkLog.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Baud Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
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
            this.cmbBaudRate.Location = new System.Drawing.Point(623, 14);
            this.cmbBaudRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(181, 28);
            this.cmbBaudRate.TabIndex = 2;
            this.cmbBaudRate.Text = "9600";
            // 
            // txtComPort
            // 
            this.txtComPort.Location = new System.Drawing.Point(340, 49);
            this.txtComPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtComPort.Multiline = true;
            this.txtComPort.Name = "txtComPort";
            this.txtComPort.Size = new System.Drawing.Size(85, 44);
            this.txtComPort.TabIndex = 1;
            this.txtComPort.Text = "3\r\n4";
            // 
            // cmdOpenCom
            // 
            this.cmdOpenCom.Location = new System.Drawing.Point(26, 46);
            this.cmdOpenCom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdOpenCom.Name = "cmdOpenCom";
            this.cmdOpenCom.Size = new System.Drawing.Size(194, 34);
            this.cmdOpenCom.TabIndex = 0;
            this.cmdOpenCom.Text = "Open COM port";
            this.cmdOpenCom.UseVisualStyleBackColor = true;
            this.cmdOpenCom.Click += new System.EventHandler(this.cmdOpenCom_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(156, 22);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(142, 37);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(8, 23);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(142, 37);
            this.btnInit.TabIndex = 13;
            this.btnInit.Text = "Initialize";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtWorklisFpth);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.btnFormulate);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Controls.Add(this.btnInit);
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
            this.groupBox2.Location = new System.Drawing.Point(32, 289);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(810, 188);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pump Controls";
            // 
            // btnPurge
            // 
            this.btnPurge.Location = new System.Drawing.Point(1515, 912);
            this.btnPurge.Name = "btnPurge";
            this.btnPurge.Size = new System.Drawing.Size(142, 37);
            this.btnPurge.TabIndex = 26;
            this.btnPurge.Text = "Purge";
            this.btnPurge.UseVisualStyleBackColor = true;
            this.btnPurge.Click += new System.EventHandler(this.btnPurge_Click);
            // 
            // btnWash
            // 
            this.btnWash.Location = new System.Drawing.Point(1515, 869);
            this.btnWash.Name = "btnWash";
            this.btnWash.Size = new System.Drawing.Size(142, 37);
            this.btnWash.TabIndex = 25;
            this.btnWash.Text = "Wash";
            this.btnWash.UseVisualStyleBackColor = true;
            this.btnWash.Click += new System.EventHandler(this.btnWash_Click);
            // 
            // btnFormulate
            // 
            this.btnFormulate.Location = new System.Drawing.Point(304, 22);
            this.btnFormulate.Name = "btnFormulate";
            this.btnFormulate.Size = new System.Drawing.Size(142, 37);
            this.btnFormulate.TabIndex = 24;
            this.btnFormulate.Text = "Seected Start";
            this.btnFormulate.UseVisualStyleBackColor = true;
            this.btnFormulate.Click += new System.EventHandler(this.btnFormulate_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(498, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Pump 2 Velocity (mL/min)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Pump 1 Velocity (mL/min)";
            // 
            // pump2Vol
            // 
            this.pump2Vol.Location = new System.Drawing.Point(366, 154);
            this.pump2Vol.Name = "pump2Vol";
            this.pump2Vol.Size = new System.Drawing.Size(100, 26);
            this.pump2Vol.TabIndex = 14;
            this.pump2Vol.Text = "167";
            // 
            // pump1Vol
            // 
            this.pump1Vol.Location = new System.Drawing.Point(14, 152);
            this.pump1Vol.Name = "pump1Vol";
            this.pump1Vol.Size = new System.Drawing.Size(100, 26);
            this.pump1Vol.TabIndex = 13;
            this.pump1Vol.Text = "500";
            // 
            // P
            // 
            this.P.AutoSize = true;
            this.P.Location = new System.Drawing.Point(362, 127);
            this.P.Name = "P";
            this.P.Size = new System.Drawing.Size(121, 20);
            this.P.TabIndex = 12;
            this.P.Text = "Pump 2 Volume";
            // 
            // pump2Speed
            // 
            this.pump2Speed.Location = new System.Drawing.Point(502, 152);
            this.pump2Speed.Name = "pump2Speed";
            this.pump2Speed.Size = new System.Drawing.Size(151, 26);
            this.pump2Speed.TabIndex = 11;
            this.pump2Speed.Text = "167";
            // 
            // txtErr
            // 
            this.txtErr.Location = new System.Drawing.Point(712, 188);
            this.txtErr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtErr.Name = "txtErr";
            this.txtErr.Size = new System.Drawing.Size(62, 26);
            this.txtErr.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(662, 189);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Error";
            // 
            // txtReply
            // 
            this.txtReply.Location = new System.Drawing.Point(158, 188);
            this.txtReply.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReply.Name = "txtReply";
            this.txtReply.Size = new System.Drawing.Size(452, 26);
            this.txtReply.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 189);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Reply";
            // 
            // cmdSendCommand
            // 
            this.cmdSendCommand.Location = new System.Drawing.Point(630, 81);
            this.cmdSendCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdSendCommand.Name = "cmdSendCommand";
            this.cmdSendCommand.Size = new System.Drawing.Size(172, 37);
            this.cmdSendCommand.TabIndex = 5;
            this.cmdSendCommand.Text = "Select Worklist";
            this.cmdSendCommand.UseVisualStyleBackColor = true;
            this.cmdSendCommand.Click += new System.EventHandler(this.cmdSendCommand_Click);
            // 
            // pump1Speed
            // 
            this.pump1Speed.Location = new System.Drawing.Point(156, 152);
            this.pump1Speed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pump1Speed.Name = "pump1Speed";
            this.pump1Speed.Size = new System.Drawing.Size(151, 26);
            this.pump1Speed.TabIndex = 4;
            this.pump1Speed.Text = "500";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Pump 1 Volume";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Location = new System.Drawing.Point(32, 486);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(1042, 502);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logging";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(12, 29);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1020, 464);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(862, 71);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(626, 304);
            this.listBox2.TabIndex = 3;
            // 
            // stepSelect
            // 
            this.stepSelect.FormattingEnabled = true;
            this.stepSelect.Items.AddRange(new object[] {
            "Initialize",
            "Prime Lipid",
            "Prime Citrate",
            "Formulate Lipid",
            "Formulate Citrate",
            "Wash Lipid",
            "Wash Citrate",
            "Purge"});
            this.stepSelect.Location = new System.Drawing.Point(862, 32);
            this.stepSelect.Name = "stepSelect";
            this.stepSelect.Size = new System.Drawing.Size(626, 28);
            this.stepSelect.TabIndex = 4;
            this.stepSelect.SelectedIndexChanged += new System.EventHandler(this.stepSelect_SelectedIndexChanged);
            // 
            // btnEditStep
            // 
            this.btnEditStep.Location = new System.Drawing.Point(1318, 416);
            this.btnEditStep.Name = "btnEditStep";
            this.btnEditStep.Size = new System.Drawing.Size(170, 32);
            this.btnEditStep.TabIndex = 5;
            this.btnEditStep.Text = "Edit";
            this.btnEditStep.UseVisualStyleBackColor = true;
            this.btnEditStep.Click += new System.EventHandler(this.btnEditStep_Click);
            // 
            // btnSaveStep
            // 
            this.btnSaveStep.Location = new System.Drawing.Point(1318, 454);
            this.btnSaveStep.Name = "btnSaveStep";
            this.btnSaveStep.Size = new System.Drawing.Size(170, 32);
            this.btnSaveStep.TabIndex = 6;
            this.btnSaveStep.Text = "Save";
            this.btnSaveStep.UseVisualStyleBackColor = true;
            this.btnSaveStep.Click += new System.EventHandler(this.btnSaveStep_Click);
            // 
            // txtEditStepBox
            // 
            this.txtEditStepBox.Location = new System.Drawing.Point(861, 383);
            this.txtEditStepBox.Name = "txtEditStepBox";
            this.txtEditStepBox.Size = new System.Drawing.Size(627, 26);
            this.txtEditStepBox.TabIndex = 7;
            // 
            // pSet1Check
            // 
            this.pSet1Check.AutoSize = true;
            this.pSet1Check.Checked = true;
            this.pSet1Check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pSet1Check.Location = new System.Drawing.Point(46, 252);
            this.pSet1Check.Name = "pSet1Check";
            this.pSet1Check.Size = new System.Drawing.Size(73, 24);
            this.pSet1Check.TabIndex = 8;
            this.pSet1Check.Text = "Set 1";
            this.pSet1Check.UseVisualStyleBackColor = true;
            this.pSet1Check.CheckedChanged += new System.EventHandler(this.pSet1Check_CheckedChanged);
            // 
            // pSet4Check
            // 
            this.pSet4Check.AutoSize = true;
            this.pSet4Check.Enabled = false;
            this.pSet4Check.Location = new System.Drawing.Point(280, 252);
            this.pSet4Check.Name = "pSet4Check";
            this.pSet4Check.Size = new System.Drawing.Size(73, 24);
            this.pSet4Check.TabIndex = 9;
            this.pSet4Check.Text = "Set 4";
            this.pSet4Check.UseVisualStyleBackColor = true;
            this.pSet4Check.CheckedChanged += new System.EventHandler(this.pSet4Check_CheckedChanged);
            // 
            // pSet3Check
            // 
            this.pSet3Check.AutoSize = true;
            this.pSet3Check.Enabled = false;
            this.pSet3Check.Location = new System.Drawing.Point(202, 252);
            this.pSet3Check.Name = "pSet3Check";
            this.pSet3Check.Size = new System.Drawing.Size(73, 24);
            this.pSet3Check.TabIndex = 10;
            this.pSet3Check.Text = "Set 3";
            this.pSet3Check.UseVisualStyleBackColor = true;
            this.pSet3Check.CheckedChanged += new System.EventHandler(this.pSet3Check_CheckedChanged);
            // 
            // pSet2Check
            // 
            this.pSet2Check.AutoSize = true;
            this.pSet2Check.Enabled = false;
            this.pSet2Check.Location = new System.Drawing.Point(123, 252);
            this.pSet2Check.Name = "pSet2Check";
            this.pSet2Check.Size = new System.Drawing.Size(73, 24);
            this.pSet2Check.TabIndex = 11;
            this.pSet2Check.Text = "Set 2";
            this.pSet2Check.UseVisualStyleBackColor = true;
            this.pSet2Check.CheckedChanged += new System.EventHandler(this.pSet2Check_CheckedChanged);
            // 
            // worklistSelectDialog
            // 
            this.worklistSelectDialog.FileName = "worklistSelectDialog";
            // 
            // txtWorklisFpth
            // 
            this.txtWorklisFpth.Location = new System.Drawing.Point(26, 86);
            this.txtWorklisFpth.Name = "txtWorklisFpth";
            this.txtWorklisFpth.Size = new System.Drawing.Size(596, 26);
            this.txtWorklisFpth.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 994);
            this.Controls.Add(this.pSet2Check);
            this.Controls.Add(this.btnWash);
            this.Controls.Add(this.btnPurge);
            this.Controls.Add(this.pSet3Check);
            this.Controls.Add(this.pSet4Check);
            this.Controls.Add(this.pSet1Check);
            this.Controls.Add(this.txtEditStepBox);
            this.Controls.Add(this.btnSaveStep);
            this.Controls.Add(this.btnEditStep);
            this.Controls.Add(this.stepSelect);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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

        public PUMPCOMMSERVERLib.PumpCommClass citratePumps = new PUMPCOMMSERVERLib.PumpCommClass();
        public PUMPCOMMSERVERLib.PumpCommClass lipidPumps = new PUMPCOMMSERVERLib.PumpCommClass();
        public PUMPCOMMSERVERLib.PumpCommClass citratePumps2 = new PUMPCOMMSERVERLib.PumpCommClass();
        public PUMPCOMMSERVERLib.PumpCommClass lipidPumps2 = new PUMPCOMMSERVERLib.PumpCommClass();
        private System.Windows.Forms.TextBox pump2Speed;
        private System.Windows.Forms.Label P;
        private System.Windows.Forms.TextBox pump2Vol;
        private System.Windows.Forms.TextBox pump1Vol;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Label label4;
        private TextBox txtComPort2;
        private ComboBox pumpNumDrop;
        private ComboBox phaseSelectDrop;
        private Button btnSendCommand;
        private TextBox txtManCommand;
        private Button btnInit;
        private Button btnStart;
        private ListBox listBox2;
        private ComboBox stepSelect;
        private Button btnEditStep;
        private Button btnSaveStep;
        private TextBox txtEditStepBox;
        private Button btnPurge;
        private Button btnWash;
        private Button btnFormulate;
        private CheckBox pSet1Check;
        private CheckBox pSet4Check;
        private CheckBox pSet3Check;
        private CheckBox pSet2Check;
        private Button btnStop;
        private Button btnResume;
        private TextBox txtWorklisFpth;
        private OpenFileDialog worklistSelectDialog;
    }
}

