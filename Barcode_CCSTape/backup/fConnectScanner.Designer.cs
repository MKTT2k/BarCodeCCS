
namespace Barcode_CCSTape.GUI
{
    partial class fConnectScanner
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.btnTrigger2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCclose = new System.Windows.Forms.Button();
            this.btnopen = new System.Windows.Forms.Button();
            this.ckbRTSsEnable = new System.Windows.Forms.CheckBox();
            this.ckbDTREnable = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbStopBits = new System.Windows.Forms.ComboBox();
            this.cbbParityBits = new System.Windows.Forms.ComboBox();
            this.cbbDataBits = new System.Windows.Forms.ComboBox();
            this.cbbBaudRate = new System.Windows.Forms.ComboBox();
            this.cbbComPort = new System.Windows.Forms.ComboBox();
            this.btnTrigger1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearScan1 = new System.Windows.Forms.Button();
            this.ckbPort1_Status = new System.Windows.Forms.CheckBox();
            this.lblPort1_Name = new System.Windows.Forms.Label();
            this.lblPort1_BaudRate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClearScan2 = new System.Windows.Forms.Button();
            this.ckbPort2_Status = new System.Windows.Forms.CheckBox();
            this.lblPort2_Name = new System.Windows.Forms.Label();
            this.lblPort2_BaudRate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnTrigger2
            // 
            this.btnTrigger2.Enabled = false;
            this.btnTrigger2.Location = new System.Drawing.Point(104, 94);
            this.btnTrigger2.Margin = new System.Windows.Forms.Padding(2);
            this.btnTrigger2.Name = "btnTrigger2";
            this.btnTrigger2.Size = new System.Drawing.Size(66, 24);
            this.btnTrigger2.TabIndex = 15;
            this.btnTrigger2.Text = "TG Test";
            this.btnTrigger2.UseVisualStyleBackColor = true;
            this.btnTrigger2.Click += new System.EventHandler(this.btnTrigger2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 202);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(186, 12);
            this.progressBar1.TabIndex = 79;
            // 
            // btnCclose
            // 
            this.btnCclose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCclose.Location = new System.Drawing.Point(115, 219);
            this.btnCclose.Margin = new System.Windows.Forms.Padding(2);
            this.btnCclose.Name = "btnCclose";
            this.btnCclose.Size = new System.Drawing.Size(87, 29);
            this.btnCclose.TabIndex = 11;
            this.btnCclose.Text = "&Save && Lose";
            this.btnCclose.UseVisualStyleBackColor = true;
            this.btnCclose.Click += new System.EventHandler(this.btnCclose_Click);
            // 
            // btnopen
            // 
            this.btnopen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnopen.Location = new System.Drawing.Point(16, 219);
            this.btnopen.Margin = new System.Windows.Forms.Padding(2);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(87, 29);
            this.btnopen.TabIndex = 10;
            this.btnopen.Text = "&Open";
            this.btnopen.UseVisualStyleBackColor = true;
            this.btnopen.Click += new System.EventHandler(this.btnopen_Click);
            // 
            // ckbRTSsEnable
            // 
            this.ckbRTSsEnable.AutoSize = true;
            this.ckbRTSsEnable.Location = new System.Drawing.Point(115, 180);
            this.ckbRTSsEnable.Margin = new System.Windows.Forms.Padding(2);
            this.ckbRTSsEnable.Name = "ckbRTSsEnable";
            this.ckbRTSsEnable.Size = new System.Drawing.Size(93, 17);
            this.ckbRTSsEnable.TabIndex = 9;
            this.ckbRTSsEnable.Text = "RTS ENABLE";
            this.ckbRTSsEnable.UseVisualStyleBackColor = true;
            // 
            // ckbDTREnable
            // 
            this.ckbDTREnable.AutoSize = true;
            this.ckbDTREnable.Location = new System.Drawing.Point(16, 180);
            this.ckbDTREnable.Margin = new System.Windows.Forms.Padding(2);
            this.ckbDTREnable.Name = "ckbDTREnable";
            this.ckbDTREnable.Size = new System.Drawing.Size(94, 17);
            this.ckbDTREnable.TabIndex = 8;
            this.ckbDTREnable.Text = "DTR ENABLE";
            this.ckbDTREnable.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 73;
            this.label5.Text = "PARITY BITS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 155);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "STOP BITS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "DATA BITS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "BAUD RATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "COM PORT";
            // 
            // cbbStopBits
            // 
            this.cbbStopBits.FormattingEnabled = true;
            this.cbbStopBits.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.cbbStopBits.Location = new System.Drawing.Point(96, 152);
            this.cbbStopBits.Margin = new System.Windows.Forms.Padding(2);
            this.cbbStopBits.Name = "cbbStopBits";
            this.cbbStopBits.Size = new System.Drawing.Size(92, 21);
            this.cbbStopBits.TabIndex = 7;
            this.cbbStopBits.Text = "One";
            // 
            // cbbParityBits
            // 
            this.cbbParityBits.FormattingEnabled = true;
            this.cbbParityBits.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cbbParityBits.Location = new System.Drawing.Point(96, 124);
            this.cbbParityBits.Margin = new System.Windows.Forms.Padding(2);
            this.cbbParityBits.Name = "cbbParityBits";
            this.cbbParityBits.Size = new System.Drawing.Size(92, 21);
            this.cbbParityBits.TabIndex = 6;
            this.cbbParityBits.Text = "None";
            // 
            // cbbDataBits
            // 
            this.cbbDataBits.FormattingEnabled = true;
            this.cbbDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.cbbDataBits.Location = new System.Drawing.Point(96, 95);
            this.cbbDataBits.Margin = new System.Windows.Forms.Padding(2);
            this.cbbDataBits.Name = "cbbDataBits";
            this.cbbDataBits.Size = new System.Drawing.Size(92, 21);
            this.cbbDataBits.TabIndex = 5;
            this.cbbDataBits.Text = "8";
            // 
            // cbbBaudRate
            // 
            this.cbbBaudRate.FormattingEnabled = true;
            this.cbbBaudRate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "14400"});
            this.cbbBaudRate.Location = new System.Drawing.Point(96, 67);
            this.cbbBaudRate.Margin = new System.Windows.Forms.Padding(2);
            this.cbbBaudRate.Name = "cbbBaudRate";
            this.cbbBaudRate.Size = new System.Drawing.Size(92, 21);
            this.cbbBaudRate.TabIndex = 4;
            this.cbbBaudRate.Text = "9600";
            // 
            // cbbComPort
            // 
            this.cbbComPort.FormattingEnabled = true;
            this.cbbComPort.Location = new System.Drawing.Point(96, 39);
            this.cbbComPort.Margin = new System.Windows.Forms.Padding(2);
            this.cbbComPort.Name = "cbbComPort";
            this.cbbComPort.Size = new System.Drawing.Size(92, 21);
            this.cbbComPort.TabIndex = 2;
            // 
            // btnTrigger1
            // 
            this.btnTrigger1.Enabled = false;
            this.btnTrigger1.Location = new System.Drawing.Point(104, 104);
            this.btnTrigger1.Margin = new System.Windows.Forms.Padding(2);
            this.btnTrigger1.Name = "btnTrigger1";
            this.btnTrigger1.Size = new System.Drawing.Size(66, 24);
            this.btnTrigger1.TabIndex = 13;
            this.btnTrigger1.Text = "TG Test";
            this.btnTrigger1.UseVisualStyleBackColor = true;
            this.btnTrigger1.Click += new System.EventHandler(this.btnTrigger1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearScan1);
            this.groupBox1.Controls.Add(this.ckbPort1_Status);
            this.groupBox1.Controls.Add(this.lblPort1_Name);
            this.groupBox1.Controls.Add(this.lblPort1_BaudRate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnTrigger1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(188, 132);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SCANNER 1";
            // 
            // btnClearScan1
            // 
            this.btnClearScan1.Location = new System.Drawing.Point(14, 104);
            this.btnClearScan1.Name = "btnClearScan1";
            this.btnClearScan1.Size = new System.Drawing.Size(66, 24);
            this.btnClearScan1.TabIndex = 12;
            this.btnClearScan1.Text = "Clear";
            this.btnClearScan1.UseVisualStyleBackColor = true;
            this.btnClearScan1.Click += new System.EventHandler(this.btnClearScan1_Click);
            // 
            // ckbPort1_Status
            // 
            this.ckbPort1_Status.AutoSize = true;
            this.ckbPort1_Status.Enabled = false;
            this.ckbPort1_Status.Location = new System.Drawing.Point(76, 77);
            this.ckbPort1_Status.Margin = new System.Windows.Forms.Padding(2);
            this.ckbPort1_Status.Name = "ckbPort1_Status";
            this.ckbPort1_Status.Size = new System.Drawing.Size(15, 14);
            this.ckbPort1_Status.TabIndex = 95;
            this.ckbPort1_Status.UseVisualStyleBackColor = true;
            // 
            // lblPort1_Name
            // 
            this.lblPort1_Name.AutoSize = true;
            this.lblPort1_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPort1_Name.Location = new System.Drawing.Point(74, 22);
            this.lblPort1_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPort1_Name.Name = "lblPort1_Name";
            this.lblPort1_Name.Size = new System.Drawing.Size(91, 13);
            this.lblPort1_Name.TabIndex = 90;
            this.lblPort1_Name.Text = ".....................";
            // 
            // lblPort1_BaudRate
            // 
            this.lblPort1_BaudRate.AutoSize = true;
            this.lblPort1_BaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPort1_BaudRate.Location = new System.Drawing.Point(74, 49);
            this.lblPort1_BaudRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPort1_BaudRate.Name = "lblPort1_BaudRate";
            this.lblPort1_BaudRate.Size = new System.Drawing.Size(91, 13);
            this.lblPort1_BaudRate.TabIndex = 91;
            this.lblPort1_BaudRate.Text = ".....................";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 93;
            this.label6.Text = "Port Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 77);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 94;
            this.label14.Text = "Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 94;
            this.label7.Text = "Baud Rate";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClearScan2);
            this.groupBox2.Controls.Add(this.ckbPort2_Status);
            this.groupBox2.Controls.Add(this.lblPort2_Name);
            this.groupBox2.Controls.Add(this.lblPort2_BaudRate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnTrigger2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 132);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(188, 121);
            this.groupBox2.TabIndex = 86;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SCANNER 2";
            // 
            // btnClearScan2
            // 
            this.btnClearScan2.Location = new System.Drawing.Point(14, 94);
            this.btnClearScan2.Name = "btnClearScan2";
            this.btnClearScan2.Size = new System.Drawing.Size(66, 24);
            this.btnClearScan2.TabIndex = 14;
            this.btnClearScan2.Text = "Clear";
            this.btnClearScan2.UseVisualStyleBackColor = true;
            this.btnClearScan2.Click += new System.EventHandler(this.btnClearScan2_Click);
            // 
            // ckbPort2_Status
            // 
            this.ckbPort2_Status.AutoSize = true;
            this.ckbPort2_Status.Enabled = false;
            this.ckbPort2_Status.Location = new System.Drawing.Point(77, 71);
            this.ckbPort2_Status.Margin = new System.Windows.Forms.Padding(2);
            this.ckbPort2_Status.Name = "ckbPort2_Status";
            this.ckbPort2_Status.Size = new System.Drawing.Size(15, 14);
            this.ckbPort2_Status.TabIndex = 95;
            this.ckbPort2_Status.UseVisualStyleBackColor = true;
            // 
            // lblPort2_Name
            // 
            this.lblPort2_Name.AutoSize = true;
            this.lblPort2_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPort2_Name.Location = new System.Drawing.Point(74, 22);
            this.lblPort2_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPort2_Name.Name = "lblPort2_Name";
            this.lblPort2_Name.Size = new System.Drawing.Size(91, 13);
            this.lblPort2_Name.TabIndex = 85;
            this.lblPort2_Name.Text = ".....................";
            // 
            // lblPort2_BaudRate
            // 
            this.lblPort2_BaudRate.AutoSize = true;
            this.lblPort2_BaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPort2_BaudRate.Location = new System.Drawing.Point(74, 48);
            this.lblPort2_BaudRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPort2_BaudRate.Name = "lblPort2_BaudRate";
            this.lblPort2_BaudRate.Size = new System.Drawing.Size(91, 13);
            this.lblPort2_BaudRate.TabIndex = 86;
            this.lblPort2_BaudRate.Text = ".....................";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 22);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 87;
            this.label9.Text = "Port Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 71);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 88;
            this.label16.Text = "Status";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 48);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 88;
            this.label13.Text = "Baud Rate";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.77778F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.22222F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(405, 257);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(215, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 253);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.cbbBaudRate);
            this.panel2.Controls.Add(this.ckbDTREnable);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbbDataBits);
            this.panel2.Controls.Add(this.btnCclose);
            this.panel2.Controls.Add(this.cbbParityBits);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.ckbRTSsEnable);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbbStopBits);
            this.panel2.Controls.Add(this.cbbComPort);
            this.panel2.Controls.Add(this.btnopen);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 253);
            this.panel2.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(7, 7);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(63, 24);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // fConnectScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(405, 257);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "fConnectScanner";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect_Scanner";
            this.Load += new System.EventHandler(this.fConnectScanner_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Button btnTrigger2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCclose;
        private System.Windows.Forms.Button btnopen;
        private System.Windows.Forms.CheckBox ckbRTSsEnable;
        private System.Windows.Forms.CheckBox ckbDTREnable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbStopBits;
        private System.Windows.Forms.ComboBox cbbParityBits;
        private System.Windows.Forms.ComboBox cbbDataBits;
        private System.Windows.Forms.ComboBox cbbBaudRate;
        private System.Windows.Forms.ComboBox cbbComPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPort2_Name;
        private System.Windows.Forms.Label lblPort2_BaudRate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPort1_Name;
        private System.Windows.Forms.Label lblPort1_BaudRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTrigger1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox ckbPort2_Status;
        private System.Windows.Forms.CheckBox ckbPort1_Status;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClearScan1;
        private System.Windows.Forms.Button btnClearScan2;
    }
}