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

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boolSimulate = new System.Windows.Forms.CheckBox();
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
            this.btnPrime = new System.Windows.Forms.Button();
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
            this.lipidPrimeVol = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.citratePrimeVol = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lipidPrimeVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.citratePrimeVol)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.boolSimulate);
            this.groupBox1.Controls.Add(this.btnResume);
            this.groupBox1.Controls.Add(this.btnStop);
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
            // boolSimulate
            // 
            this.boolSimulate.AutoSize = true;
            this.boolSimulate.Location = new System.Drawing.Point(17, 78);
            this.boolSimulate.Name = "boolSimulate";
            this.boolSimulate.Size = new System.Drawing.Size(66, 17);
            this.boolSimulate.TabIndex = 15;
            this.boolSimulate.Text = "Simulate";
            this.boolSimulate.UseVisualStyleBackColor = true;
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(427, 79);
            this.btnResume.Margin = new System.Windows.Forms.Padding(2);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(92, 22);
            this.btnResume.TabIndex = 14;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(427, 55);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(92, 22);
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
            this.pumpNumDrop.Location = new System.Drawing.Point(130, 109);
            this.pumpNumDrop.MaxDropDownItems = 2;
            this.pumpNumDrop.Name = "pumpNumDrop";
            this.pumpNumDrop.Size = new System.Drawing.Size(91, 21);
            this.pumpNumDrop.TabIndex = 12;
            this.pumpNumDrop.Text = "Pump Number";
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
            // txtManCommand
            // 
            this.txtManCommand.Location = new System.Drawing.Point(227, 109);
            this.txtManCommand.Name = "txtManCommand";
            this.txtManCommand.Size = new System.Drawing.Size(191, 20);
            this.txtManCommand.TabIndex = 8;
            this.txtManCommand.Text = "Manual Command";
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
            // txtComPort2
            // 
            this.txtComPort2.Location = new System.Drawing.Point(227, 67);
            this.txtComPort2.Name = "txtComPort2";
            this.txtComPort2.Size = new System.Drawing.Size(58, 20);
            this.txtComPort2.TabIndex = 6;
            this.txtComPort2.Text = "5";
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Checked = true;
            this.chkLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLog.Location = new System.Drawing.Point(17, 55);
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
            this.txtComPort.Text = "6";
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
            // btnPrime
            // 
            this.btnPrime.Location = new System.Drawing.Point(104, 14);
            this.btnPrime.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrime.Name = "btnPrime";
            this.btnPrime.Size = new System.Drawing.Size(95, 24);
            this.btnPrime.TabIndex = 14;
            this.btnPrime.Text = "Prime";
            this.btnPrime.UseVisualStyleBackColor = true;
            this.btnPrime.Click += new System.EventHandler(this.btnPrime_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(5, 15);
            this.btnInit.Margin = new System.Windows.Forms.Padding(2);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(95, 24);
            this.btnInit.TabIndex = 13;
            this.btnInit.Text = "Initialize";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.citratePrimeVol);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lipidPrimeVol);
            this.groupBox2.Controls.Add(this.btnPurge);
            this.groupBox2.Controls.Add(this.btnWash);
            this.groupBox2.Controls.Add(this.btnFormulate);
            this.groupBox2.Controls.Add(this.btnPrime);
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
            this.groupBox2.Location = new System.Drawing.Point(21, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 122);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pump Controls";
            // 
            // btnPurge
            // 
            this.btnPurge.Location = new System.Drawing.Point(402, 15);
            this.btnPurge.Margin = new System.Windows.Forms.Padding(2);
            this.btnPurge.Name = "btnPurge";
            this.btnPurge.Size = new System.Drawing.Size(95, 24);
            this.btnPurge.TabIndex = 26;
            this.btnPurge.Text = "Purge";
            this.btnPurge.UseVisualStyleBackColor = true;
            this.btnPurge.Click += new System.EventHandler(this.btnPurge_Click);
            // 
            // btnWash
            // 
            this.btnWash.Location = new System.Drawing.Point(303, 15);
            this.btnWash.Margin = new System.Windows.Forms.Padding(2);
            this.btnWash.Name = "btnWash";
            this.btnWash.Size = new System.Drawing.Size(95, 24);
            this.btnWash.TabIndex = 25;
            this.btnWash.Text = "Wash";
            this.btnWash.UseVisualStyleBackColor = true;
            this.btnWash.Click += new System.EventHandler(this.btnWash_Click);
            // 
            // btnFormulate
            // 
            this.btnFormulate.Location = new System.Drawing.Point(203, 14);
            this.btnFormulate.Margin = new System.Windows.Forms.Padding(2);
            this.btnFormulate.Name = "btnFormulate";
            this.btnFormulate.Size = new System.Drawing.Size(95, 24);
            this.btnFormulate.TabIndex = 24;
            this.btnFormulate.Text = "Formulate";
            this.btnFormulate.UseVisualStyleBackColor = true;
            this.btnFormulate.Click += new System.EventHandler(this.btnFormulate_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(106, 79);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Payload Velocity (mL/min)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Lipid Velocity (mL/min)";
            // 
            // pump2Vol
            // 
            this.pump2Vol.Location = new System.Drawing.Point(7, 90);
            this.pump2Vol.Margin = new System.Windows.Forms.Padding(2);
            this.pump2Vol.Name = "pump2Vol";
            this.pump2Vol.Size = new System.Drawing.Size(68, 20);
            this.pump2Vol.TabIndex = 14;
            this.pump2Vol.Text = "600";
            // 
            // pump1Vol
            // 
            this.pump1Vol.Location = new System.Drawing.Point(9, 56);
            this.pump1Vol.Margin = new System.Windows.Forms.Padding(2);
            this.pump1Vol.Name = "pump1Vol";
            this.pump1Vol.Size = new System.Drawing.Size(68, 20);
            this.pump1Vol.TabIndex = 13;
            this.pump1Vol.Text = "200";
            // 
            // P
            // 
            this.P.AutoSize = true;
            this.P.Location = new System.Drawing.Point(5, 75);
            this.P.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P.Name = "P";
            this.P.Size = new System.Drawing.Size(83, 13);
            this.P.TabIndex = 12;
            this.P.Text = "Payload Volume";
            // 
            // pump2Speed
            // 
            this.pump2Speed.Location = new System.Drawing.Point(106, 96);
            this.pump2Speed.Margin = new System.Windows.Forms.Padding(2);
            this.pump2Speed.Name = "pump2Speed";
            this.pump2Speed.Size = new System.Drawing.Size(102, 20);
            this.pump2Speed.TabIndex = 11;
            this.pump2Speed.Text = "6";
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
            this.cmdSendCommand.Location = new System.Drawing.Point(419, 92);
            this.cmdSendCommand.Name = "cmdSendCommand";
            this.cmdSendCommand.Size = new System.Drawing.Size(115, 24);
            this.cmdSendCommand.TabIndex = 5;
            this.cmdSendCommand.Text = "Update Commands";
            this.cmdSendCommand.UseVisualStyleBackColor = true;
            this.cmdSendCommand.Click += new System.EventHandler(this.cmdSendCommand_Click);
            // 
            // pump1Speed
            // 
            this.pump1Speed.Location = new System.Drawing.Point(106, 56);
            this.pump1Speed.Name = "pump1Speed";
            this.pump1Speed.Size = new System.Drawing.Size(102, 20);
            this.pump1Speed.TabIndex = 4;
            this.pump1Speed.Text = "2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Lipid Volume";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Location = new System.Drawing.Point(21, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(695, 326);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logging";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(681, 303);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(575, 46);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(114, 199);
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
            this.stepSelect.Location = new System.Drawing.Point(575, 21);
            this.stepSelect.Margin = new System.Windows.Forms.Padding(2);
            this.stepSelect.Name = "stepSelect";
            this.stepSelect.Size = new System.Drawing.Size(114, 21);
            this.stepSelect.TabIndex = 4;
            this.stepSelect.SelectedIndexChanged += new System.EventHandler(this.stepSelect_SelectedIndexChanged);
            // 
            // btnEditStep
            // 
            this.btnEditStep.Location = new System.Drawing.Point(574, 273);
            this.btnEditStep.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditStep.Name = "btnEditStep";
            this.btnEditStep.Size = new System.Drawing.Size(113, 21);
            this.btnEditStep.TabIndex = 5;
            this.btnEditStep.Text = "Edit";
            this.btnEditStep.UseVisualStyleBackColor = true;
            this.btnEditStep.Click += new System.EventHandler(this.btnEditStep_Click);
            // 
            // btnSaveStep
            // 
            this.btnSaveStep.Location = new System.Drawing.Point(575, 298);
            this.btnSaveStep.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveStep.Name = "btnSaveStep";
            this.btnSaveStep.Size = new System.Drawing.Size(113, 21);
            this.btnSaveStep.TabIndex = 6;
            this.btnSaveStep.Text = "Save";
            this.btnSaveStep.UseVisualStyleBackColor = true;
            this.btnSaveStep.Click += new System.EventHandler(this.btnSaveStep_Click);
            // 
            // txtEditStepBox
            // 
            this.txtEditStepBox.Location = new System.Drawing.Point(574, 249);
            this.txtEditStepBox.Margin = new System.Windows.Forms.Padding(2);
            this.txtEditStepBox.Name = "txtEditStepBox";
            this.txtEditStepBox.Size = new System.Drawing.Size(114, 20);
            this.txtEditStepBox.TabIndex = 7;
            // 
            // pSet1Check
            // 
            this.pSet1Check.AutoSize = true;
            this.pSet1Check.Checked = true;
            this.pSet1Check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pSet1Check.Location = new System.Drawing.Point(31, 164);
            this.pSet1Check.Margin = new System.Windows.Forms.Padding(2);
            this.pSet1Check.Name = "pSet1Check";
            this.pSet1Check.Size = new System.Drawing.Size(51, 17);
            this.pSet1Check.TabIndex = 8;
            this.pSet1Check.Text = "Set 1";
            this.pSet1Check.UseVisualStyleBackColor = true;
            this.pSet1Check.CheckedChanged += new System.EventHandler(this.pSet1Check_CheckedChanged);
            // 
            // pSet4Check
            // 
            this.pSet4Check.AutoSize = true;
            this.pSet4Check.Location = new System.Drawing.Point(187, 164);
            this.pSet4Check.Margin = new System.Windows.Forms.Padding(2);
            this.pSet4Check.Name = "pSet4Check";
            this.pSet4Check.Size = new System.Drawing.Size(51, 17);
            this.pSet4Check.TabIndex = 9;
            this.pSet4Check.Text = "Set 4";
            this.pSet4Check.UseVisualStyleBackColor = true;
            this.pSet4Check.CheckedChanged += new System.EventHandler(this.pSet4Check_CheckedChanged);
            // 
            // pSet3Check
            // 
            this.pSet3Check.AutoSize = true;
            this.pSet3Check.Location = new System.Drawing.Point(135, 164);
            this.pSet3Check.Margin = new System.Windows.Forms.Padding(2);
            this.pSet3Check.Name = "pSet3Check";
            this.pSet3Check.Size = new System.Drawing.Size(51, 17);
            this.pSet3Check.TabIndex = 10;
            this.pSet3Check.Text = "Set 3";
            this.pSet3Check.UseVisualStyleBackColor = true;
            this.pSet3Check.CheckedChanged += new System.EventHandler(this.pSet3Check_CheckedChanged);
            // 
            // pSet2Check
            // 
            this.pSet2Check.AutoSize = true;
            this.pSet2Check.Location = new System.Drawing.Point(82, 164);
            this.pSet2Check.Margin = new System.Windows.Forms.Padding(2);
            this.pSet2Check.Name = "pSet2Check";
            this.pSet2Check.Size = new System.Drawing.Size(51, 17);
            this.pSet2Check.TabIndex = 11;
            this.pSet2Check.Text = "Set 2";
            this.pSet2Check.UseVisualStyleBackColor = true;
            this.pSet2Check.CheckedChanged += new System.EventHandler(this.pSet2Check_CheckedChanged);
            // 
            // lipidPrimeVol
            // 
            this.lipidPrimeVol.Location = new System.Drawing.Point(243, 55);
            this.lipidPrimeVol.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.lipidPrimeVol.Name = "lipidPrimeVol";
            this.lipidPrimeVol.Size = new System.Drawing.Size(120, 20);
            this.lipidPrimeVol.TabIndex = 27;
            this.lipidPrimeVol.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(240, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Lipid Prime Volume";
            // 
            // citratePrimeVol
            // 
            this.citratePrimeVol.Location = new System.Drawing.Point(243, 96);
            this.citratePrimeVol.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.citratePrimeVol.Name = "citratePrimeVol";
            this.citratePrimeVol.Size = new System.Drawing.Size(120, 20);
            this.citratePrimeVol.TabIndex = 29;
            this.citratePrimeVol.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(240, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Citrate Prime Volume";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 646);
            this.Controls.Add(this.pSet2Check);
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lipidPrimeVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.citratePrimeVol)).EndInit();
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
        private Button btnPrime;
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
        private CheckBox boolSimulate;
        private Label label10;
        private NumericUpDown citratePrimeVol;
        private Label label9;
        private NumericUpDown lipidPrimeVol;
    }
}

