namespace armsim
{
    partial class SimGui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimGui));
            this.resetBtn = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileLbl = new System.Windows.Forms.Label();
            this.loadBtn = new System.Windows.Forms.Button();
            this.memGrid = new System.Windows.Forms.DataGridView();
            this.Addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Byte16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memory = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.memTxt = new System.Windows.Forms.TextBox();
            this.memGo = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.stackView = new System.Windows.Forms.DataGridView();
            this.Adrress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.word1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.enterBtn = new System.Windows.Forms.Button();
            this.inputTxt = new System.Windows.Forms.TextBox();
            this.termTxt = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dissBox = new System.Windows.Forms.TextBox();
            this.regGrid = new System.Windows.Forms.DataGridView();
            this.Reg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.runBtn = new System.Windows.Forms.Button();
            this.stepBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.flagPanel = new System.Windows.Forms.CheckedListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.breakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.memGrid)).BeginInit();
            this.Memory.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stackView)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(525, 136);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 23);
            this.resetBtn.TabIndex = 0;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(64, 136);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(343, 20);
            this.output.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "MD5 Hash";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // fileLbl
            // 
            this.fileLbl.AutoSize = true;
            this.fileLbl.Location = new System.Drawing.Point(413, 139);
            this.fileLbl.Name = "fileLbl";
            this.fileLbl.Size = new System.Drawing.Size(23, 13);
            this.fileLbl.TabIndex = 4;
            this.fileLbl.Text = "File";
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(444, 110);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(75, 23);
            this.loadBtn.TabIndex = 5;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // memGrid
            // 
            this.memGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Addr,
            this.Byte1,
            this.byte2,
            this.Byte3,
            this.byte4,
            this.byte5,
            this.Byte6,
            this.Byte7,
            this.Byte8,
            this.Byte9,
            this.Byte10,
            this.Byte11,
            this.Byte12,
            this.Byte13,
            this.Byte14,
            this.Byte15,
            this.Byte16});
            this.memGrid.Location = new System.Drawing.Point(3, 3);
            this.memGrid.Name = "memGrid";
            this.memGrid.ReadOnly = true;
            this.memGrid.Size = new System.Drawing.Size(774, 135);
            this.memGrid.TabIndex = 6;
            this.memGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Addr
            // 
            this.Addr.HeaderText = "Addr";
            this.Addr.Name = "Addr";
            this.Addr.ReadOnly = true;
            this.Addr.Width = 80;
            // 
            // Byte1
            // 
            this.Byte1.HeaderText = "Byte1";
            this.Byte1.Name = "Byte1";
            this.Byte1.ReadOnly = true;
            this.Byte1.Width = 45;
            // 
            // byte2
            // 
            this.byte2.HeaderText = "Byte2";
            this.byte2.Name = "byte2";
            this.byte2.ReadOnly = true;
            this.byte2.Width = 45;
            // 
            // Byte3
            // 
            this.Byte3.HeaderText = "Byte3";
            this.Byte3.Name = "Byte3";
            this.Byte3.ReadOnly = true;
            this.Byte3.Width = 45;
            // 
            // byte4
            // 
            this.byte4.HeaderText = "byte4";
            this.byte4.Name = "byte4";
            this.byte4.ReadOnly = true;
            this.byte4.Width = 45;
            // 
            // byte5
            // 
            this.byte5.HeaderText = "Byte5";
            this.byte5.Name = "byte5";
            this.byte5.ReadOnly = true;
            this.byte5.Width = 45;
            // 
            // Byte6
            // 
            this.Byte6.HeaderText = "Byte6";
            this.Byte6.Name = "Byte6";
            this.Byte6.ReadOnly = true;
            this.Byte6.Width = 45;
            // 
            // Byte7
            // 
            this.Byte7.HeaderText = "Byte7";
            this.Byte7.Name = "Byte7";
            this.Byte7.ReadOnly = true;
            this.Byte7.Width = 45;
            // 
            // Byte8
            // 
            this.Byte8.HeaderText = "Byte8";
            this.Byte8.Name = "Byte8";
            this.Byte8.ReadOnly = true;
            this.Byte8.Width = 45;
            // 
            // Byte9
            // 
            this.Byte9.HeaderText = "Byte9";
            this.Byte9.Name = "Byte9";
            this.Byte9.ReadOnly = true;
            this.Byte9.Width = 45;
            // 
            // Byte10
            // 
            this.Byte10.HeaderText = "Byte10";
            this.Byte10.Name = "Byte10";
            this.Byte10.ReadOnly = true;
            this.Byte10.Width = 45;
            // 
            // Byte11
            // 
            this.Byte11.HeaderText = "Byte11";
            this.Byte11.Name = "Byte11";
            this.Byte11.ReadOnly = true;
            this.Byte11.Width = 45;
            // 
            // Byte12
            // 
            this.Byte12.HeaderText = "Byte12";
            this.Byte12.Name = "Byte12";
            this.Byte12.ReadOnly = true;
            this.Byte12.Width = 45;
            // 
            // Byte13
            // 
            this.Byte13.HeaderText = "Byte13";
            this.Byte13.Name = "Byte13";
            this.Byte13.ReadOnly = true;
            this.Byte13.Width = 45;
            // 
            // Byte14
            // 
            this.Byte14.HeaderText = "Byte14";
            this.Byte14.Name = "Byte14";
            this.Byte14.ReadOnly = true;
            this.Byte14.Width = 45;
            // 
            // Byte15
            // 
            this.Byte15.HeaderText = "Byte15";
            this.Byte15.Name = "Byte15";
            this.Byte15.ReadOnly = true;
            this.Byte15.Width = 45;
            // 
            // Byte16
            // 
            this.Byte16.HeaderText = "Byte16";
            this.Byte16.Name = "Byte16";
            this.Byte16.ReadOnly = true;
            this.Byte16.Width = 45;
            // 
            // Memory
            // 
            this.Memory.Controls.Add(this.tabPage1);
            this.Memory.Controls.Add(this.tabPage2);
            this.Memory.Controls.Add(this.tabPage3);
            this.Memory.Controls.Add(this.tabPage4);
            this.Memory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Memory.Location = new System.Drawing.Point(0, 0);
            this.Memory.Name = "Memory";
            this.Memory.SelectedIndex = 0;
            this.Memory.Size = new System.Drawing.Size(785, 189);
            this.Memory.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.memTxt);
            this.tabPage1.Controls.Add(this.memGo);
            this.tabPage1.Controls.Add(this.memGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(777, 163);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Memory";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // memTxt
            // 
            this.memTxt.Location = new System.Drawing.Point(3, 140);
            this.memTxt.Name = "memTxt";
            this.memTxt.Size = new System.Drawing.Size(693, 20);
            this.memTxt.TabIndex = 8;
            // 
            // memGo
            // 
            this.memGo.Location = new System.Drawing.Point(696, 141);
            this.memGo.Name = "memGo";
            this.memGo.Size = new System.Drawing.Size(81, 23);
            this.memGo.TabIndex = 7;
            this.memGo.Text = "Fill Mem";
            this.memGo.UseVisualStyleBackColor = true;
            this.memGo.Click += new System.EventHandler(this.memGo_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.stackView);
            this.tabPage2.ForeColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(777, 163);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stack";
            // 
            // stackView
            // 
            this.stackView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stackView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Adrress,
            this.word1});
            this.stackView.Location = new System.Drawing.Point(-4, -1);
            this.stackView.Name = "stackView";
            this.stackView.ReadOnly = true;
            this.stackView.Size = new System.Drawing.Size(782, 163);
            this.stackView.TabIndex = 0;
            // 
            // Adrress
            // 
            this.Adrress.HeaderText = "Address";
            this.Adrress.Name = "Adrress";
            this.Adrress.ReadOnly = true;
            // 
            // word1
            // 
            this.word1.HeaderText = "Word";
            this.word1.Name = "word1";
            this.word1.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.enterBtn);
            this.tabPage3.Controls.Add(this.inputTxt);
            this.tabPage3.Controls.Add(this.termTxt);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(777, 163);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Terminal";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // enterBtn
            // 
            this.enterBtn.Location = new System.Drawing.Point(676, 137);
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Size = new System.Drawing.Size(98, 20);
            this.enterBtn.TabIndex = 9;
            this.enterBtn.Text = "Enter";
            this.enterBtn.UseVisualStyleBackColor = true;
            this.enterBtn.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // inputTxt
            // 
            this.inputTxt.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.inputTxt.Location = new System.Drawing.Point(3, 138);
            this.inputTxt.Name = "inputTxt";
            this.inputTxt.Size = new System.Drawing.Size(673, 20);
            this.inputTxt.TabIndex = 9;
            this.inputTxt.TextChanged += new System.EventHandler(this.inputTxt_TextChanged);
            // 
            // termTxt
            // 
            this.termTxt.AcceptsReturn = true;
            this.termTxt.AcceptsTab = true;
            this.termTxt.BackColor = System.Drawing.SystemColors.MenuText;
            this.termTxt.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.termTxt.Location = new System.Drawing.Point(-1, 0);
            this.termTxt.Multiline = true;
            this.termTxt.Name = "termTxt";
            this.termTxt.ReadOnly = true;
            this.termTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.termTxt.Size = new System.Drawing.Size(782, 138);
            this.termTxt.TabIndex = 9;
            this.termTxt.Text = "I enjoy pie test";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dissBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(777, 163);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Disassembly";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dissBox
            // 
            this.dissBox.AcceptsReturn = true;
            this.dissBox.Location = new System.Drawing.Point(-1, 0);
            this.dissBox.Multiline = true;
            this.dissBox.Name = "dissBox";
            this.dissBox.ReadOnly = true;
            this.dissBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dissBox.Size = new System.Drawing.Size(778, 161);
            this.dissBox.TabIndex = 0;
            this.dissBox.Text = resources.GetString("dissBox.Text");
            this.dissBox.TextChanged += new System.EventHandler(this.dissBox_TextChanged);
            // 
            // regGrid
            // 
            this.regGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.regGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Reg,
            this.RegisterVal});
            this.regGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regGrid.Location = new System.Drawing.Point(0, 0);
            this.regGrid.Name = "regGrid";
            this.regGrid.ReadOnly = true;
            this.regGrid.Size = new System.Drawing.Size(160, 171);
            this.regGrid.TabIndex = 8;
            this.regGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.regGrid_CellContentClick);
            // 
            // Reg
            // 
            this.Reg.HeaderText = "Reg";
            this.Reg.Name = "Reg";
            this.Reg.ReadOnly = true;
            this.Reg.Width = 35;
            // 
            // RegisterVal
            // 
            this.RegisterVal.HeaderText = "Register Value";
            this.RegisterVal.Name = "RegisterVal";
            this.RegisterVal.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Memory);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(785, 364);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.regGrid);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.runBtn);
            this.splitContainer2.Panel2.Controls.Add(this.stepBtn);
            this.splitContainer2.Panel2.Controls.Add(this.stopBtn);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.flagPanel);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.fileLbl);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.loadBtn);
            this.splitContainer2.Panel2.Controls.Add(this.output);
            this.splitContainer2.Panel2.Controls.Add(this.resetBtn);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer2.Size = new System.Drawing.Size(785, 171);
            this.splitContainer2.SplitterDistance = 160;
            this.splitContainer2.TabIndex = 0;
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(525, 45);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(75, 23);
            this.runBtn.TabIndex = 14;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // stepBtn
            // 
            this.stepBtn.Location = new System.Drawing.Point(525, 78);
            this.stepBtn.Name = "stepBtn";
            this.stepBtn.Size = new System.Drawing.Size(75, 23);
            this.stepBtn.TabIndex = 13;
            this.stepBtn.Text = "Step";
            this.stepBtn.UseVisualStyleBackColor = true;
            this.stepBtn.Click += new System.EventHandler(this.stepBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(525, 107);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 12;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Flags";
            // 
            // flagPanel
            // 
            this.flagPanel.BackColor = System.Drawing.SystemColors.Menu;
            this.flagPanel.Enabled = false;
            this.flagPanel.FormattingEnabled = true;
            this.flagPanel.Items.AddRange(new object[] {
            "N",
            "C",
            "Z",
            "F"});
            this.flagPanel.Location = new System.Drawing.Point(3, 69);
            this.flagPanel.Name = "flagPanel";
            this.flagPanel.Size = new System.Drawing.Size(59, 64);
            this.flagPanel.TabIndex = 10;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(6, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(118, 27);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.runToolStripMenuItem,
            this.stepToolStripMenuItem,
            this.breakToolStripMenuItem,
            this.toggleTraceToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.runToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.stepToolStripMenuItem.Text = "Step";
            this.stepToolStripMenuItem.Click += new System.EventHandler(this.stepToolStripMenuItem_Click);
            // 
            // breakToolStripMenuItem
            // 
            this.breakToolStripMenuItem.Name = "breakToolStripMenuItem";
            this.breakToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.breakToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.breakToolStripMenuItem.Text = "Break";
            this.breakToolStripMenuItem.Click += new System.EventHandler(this.breakToolStripMenuItem_Click);
            // 
            // toggleTraceToolStripMenuItem
            // 
            this.toggleTraceToolStripMenuItem.Name = "toggleTraceToolStripMenuItem";
            this.toggleTraceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.toggleTraceToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.toggleTraceToolStripMenuItem.Text = "Toggle Trace";
            this.toggleTraceToolStripMenuItem.Click += new System.EventHandler(this.toggleTraceToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SimGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(785, 364);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SimGui";
            this.Text = "Arm Simulator";
            this.Load += new System.EventHandler(this.SimGui_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memGrid)).EndInit();
            this.Memory.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stackView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regGrid)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fileLbl;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.DataGridView memGrid;
        private System.Windows.Forms.TabControl Memory;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button enterBtn;
        private System.Windows.Forms.TextBox inputTxt;
        private System.Windows.Forms.TextBox termTxt;
        private System.Windows.Forms.DataGridView regGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reg;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterVal;
        private System.Windows.Forms.CheckedListBox flagPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Addr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte1;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte3;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte4;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Byte16;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Button stepBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.DataGridView stackView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adrress;
        private System.Windows.Forms.DataGridViewTextBoxColumn word1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox dissBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem breakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleTraceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.TextBox memTxt;
        private System.Windows.Forms.Button memGo;
        private System.Windows.Forms.Timer timer1;
    }
}