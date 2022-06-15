namespace KazNuclide.Views
{
    partial class CalculationView
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.calculationStatus = new System.Windows.Forms.ProgressBar();
            this.groupBoxCalculation = new System.Windows.Forms.GroupBox();
            this.calculateFluxMeshBtn = new System.Windows.Forms.Button();
            this.calculateMeshBtn = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.methodComBox = new System.Windows.Forms.ComboBox();
            this.heatDensity = new System.Windows.Forms.Button();
            this.densityTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timesComBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.radiationTimeTextBox = new System.Windows.Forms.TextBox();
            this.calculateBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.neutronFluxTxt = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.totIsotopes = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comBoxDataLibs = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxKt = new System.Windows.Forms.TextBox();
            this.fluxTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.temperTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.isotopesRange = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.burnUpBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.isotopesList = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mainViewPanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.terminal = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.groupBoxCalculation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.calculationStatus);
            this.panel1.Controls.Add(this.groupBoxCalculation);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 663);
            this.panel1.TabIndex = 0;
            // 
            // calculationStatus
            // 
            this.calculationStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.calculationStatus.ForeColor = System.Drawing.Color.Red;
            this.calculationStatus.Location = new System.Drawing.Point(0, 641);
            this.calculationStatus.Name = "calculationStatus";
            this.calculationStatus.Size = new System.Drawing.Size(307, 10);
            this.calculationStatus.TabIndex = 2;
            // 
            // groupBoxCalculation
            // 
            this.groupBoxCalculation.Controls.Add(this.calculateFluxMeshBtn);
            this.groupBoxCalculation.Controls.Add(this.calculateMeshBtn);
            this.groupBoxCalculation.Controls.Add(this.label18);
            this.groupBoxCalculation.Controls.Add(this.methodComBox);
            this.groupBoxCalculation.Controls.Add(this.heatDensity);
            this.groupBoxCalculation.Controls.Add(this.densityTextBox);
            this.groupBoxCalculation.Controls.Add(this.label11);
            this.groupBoxCalculation.Controls.Add(this.label9);
            this.groupBoxCalculation.Controls.Add(this.timesComBox);
            this.groupBoxCalculation.Controls.Add(this.label10);
            this.groupBoxCalculation.Controls.Add(this.radiationTimeTextBox);
            this.groupBoxCalculation.Controls.Add(this.calculateBtn);
            this.groupBoxCalculation.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCalculation.Enabled = false;
            this.groupBoxCalculation.Location = new System.Drawing.Point(0, 360);
            this.groupBoxCalculation.Name = "groupBoxCalculation";
            this.groupBoxCalculation.Size = new System.Drawing.Size(307, 281);
            this.groupBoxCalculation.TabIndex = 1;
            this.groupBoxCalculation.TabStop = false;
            this.groupBoxCalculation.Text = "Calculation";
            // 
            // calculateFluxMeshBtn
            // 
            this.calculateFluxMeshBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.calculateFluxMeshBtn.FlatAppearance.BorderSize = 0;
            this.calculateFluxMeshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculateFluxMeshBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.calculateFluxMeshBtn.Location = new System.Drawing.Point(80, 243);
            this.calculateFluxMeshBtn.Name = "calculateFluxMeshBtn";
            this.calculateFluxMeshBtn.Size = new System.Drawing.Size(211, 28);
            this.calculateFluxMeshBtn.TabIndex = 33;
            this.calculateFluxMeshBtn.Text = "Calculate flux mesh";
            this.calculateFluxMeshBtn.UseVisualStyleBackColor = false;
            this.calculateFluxMeshBtn.Click += new System.EventHandler(this.calculateFluxMeshBtn_Click);
            // 
            // calculateMeshBtn
            // 
            this.calculateMeshBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.calculateMeshBtn.FlatAppearance.BorderSize = 0;
            this.calculateMeshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculateMeshBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.calculateMeshBtn.Location = new System.Drawing.Point(80, 212);
            this.calculateMeshBtn.Name = "calculateMeshBtn";
            this.calculateMeshBtn.Size = new System.Drawing.Size(211, 28);
            this.calculateMeshBtn.TabIndex = 32;
            this.calculateMeshBtn.Text = "Calculate time mesh";
            this.calculateMeshBtn.UseVisualStyleBackColor = false;
            this.calculateMeshBtn.Click += new System.EventHandler(this.calculateMeshBtn_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(122, 113);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 19);
            this.label18.TabIndex = 31;
            this.label18.Text = "Method:";
            // 
            // methodComBox
            // 
            this.methodComBox.FormattingEnabled = true;
            this.methodComBox.Items.AddRange(new object[] {
            "MMPA",
            "CRAM",
            "PADE",
            "TAYLOR"});
            this.methodComBox.Location = new System.Drawing.Point(196, 110);
            this.methodComBox.Name = "methodComBox";
            this.methodComBox.Size = new System.Drawing.Size(95, 25);
            this.methodComBox.TabIndex = 30;
            this.methodComBox.Text = "MMPA";
            // 
            // heatDensity
            // 
            this.heatDensity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.heatDensity.FlatAppearance.BorderSize = 0;
            this.heatDensity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.heatDensity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.heatDensity.Location = new System.Drawing.Point(80, 181);
            this.heatDensity.Name = "heatDensity";
            this.heatDensity.Size = new System.Drawing.Size(112, 28);
            this.heatDensity.TabIndex = 20;
            this.heatDensity.Text = "Heat density";
            this.heatDensity.UseVisualStyleBackColor = false;
            this.heatDensity.Click += new System.EventHandler(this.heatDensity_Click);
            // 
            // densityTextBox
            // 
            this.densityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.densityTextBox.Location = new System.Drawing.Point(6, 46);
            this.densityTextBox.Multiline = true;
            this.densityTextBox.Name = "densityTextBox";
            this.densityTextBox.Size = new System.Drawing.Size(288, 58);
            this.densityTextBox.TabIndex = 18;
            this.densityTextBox.Text = "Fe-56=1.0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(69, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "e.g. Pb-209=0.9 Bi210=0.1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 19);
            this.label9.TabIndex = 12;
            this.label9.Text = "Time:";
            // 
            // timesComBox
            // 
            this.timesComBox.FormattingEnabled = true;
            this.timesComBox.Items.AddRange(new object[] {
            "sec",
            "mins",
            "hours",
            "days",
            "months",
            "years"});
            this.timesComBox.Location = new System.Drawing.Point(196, 150);
            this.timesComBox.Name = "timesComBox";
            this.timesComBox.Size = new System.Drawing.Size(95, 25);
            this.timesComBox.TabIndex = 13;
            this.timesComBox.Text = "years";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 19);
            this.label10.TabIndex = 17;
            this.label10.Text = "Density: ";
            // 
            // radiationTimeTextBox
            // 
            this.radiationTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.radiationTimeTextBox.Location = new System.Drawing.Point(92, 150);
            this.radiationTimeTextBox.Name = "radiationTimeTextBox";
            this.radiationTimeTextBox.Size = new System.Drawing.Size(100, 23);
            this.radiationTimeTextBox.TabIndex = 14;
            this.radiationTimeTextBox.Text = "50000";
            // 
            // calculateBtn
            // 
            this.calculateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.calculateBtn.FlatAppearance.BorderSize = 0;
            this.calculateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculateBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.calculateBtn.Location = new System.Drawing.Point(201, 181);
            this.calculateBtn.Name = "calculateBtn";
            this.calculateBtn.Size = new System.Drawing.Size(90, 28);
            this.calculateBtn.TabIndex = 16;
            this.calculateBtn.Text = "Calculate";
            this.calculateBtn.UseVisualStyleBackColor = false;
            this.calculateBtn.Click += new System.EventHandler(this.calculateBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.neutronFluxTxt);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.totIsotopes);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.comBoxDataLibs);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBoxKt);
            this.groupBox1.Controls.Add(this.fluxTextBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.temperTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.isotopesRange);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.burnUpBtn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.isotopesList);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 360);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BurnUp";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(10, 75);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 19);
            this.label16.TabIndex = 27;
            this.label16.Text = "Neutron flux:";
            // 
            // neutronFluxTxt
            // 
            this.neutronFluxTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.neutronFluxTxt.Location = new System.Drawing.Point(112, 75);
            this.neutronFluxTxt.Name = "neutronFluxTxt";
            this.neutronFluxTxt.Size = new System.Drawing.Size(100, 23);
            this.neutronFluxTxt.TabIndex = 28;
            this.neutronFluxTxt.Text = "1.0E14";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(218, 75);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 19);
            this.label17.TabIndex = 29;
            this.label17.Text = "1/cm2 s";
            // 
            // totIsotopes
            // 
            this.totIsotopes.AutoSize = true;
            this.totIsotopes.Location = new System.Drawing.Point(110, 324);
            this.totIsotopes.Name = "totIsotopes";
            this.totIsotopes.Size = new System.Drawing.Size(17, 19);
            this.totIsotopes.TabIndex = 26;
            this.totIsotopes.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 324);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 19);
            this.label15.TabIndex = 25;
            this.label15.Text = "Total isotopes:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(11, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 19);
            this.label14.TabIndex = 24;
            this.label14.Text = "Data library:";
            // 
            // comBoxDataLibs
            // 
            this.comBoxDataLibs.FormattingEnabled = true;
            this.comBoxDataLibs.Location = new System.Drawing.Point(112, 145);
            this.comBoxDataLibs.Name = "comBoxDataLibs";
            this.comBoxDataLibs.Size = new System.Drawing.Size(101, 25);
            this.comBoxDataLibs.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(219, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 19);
            this.label12.TabIndex = 22;
            this.label12.Text = "keV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Neut density:";
            // 
            // txtBoxKt
            // 
            this.txtBoxKt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxKt.Location = new System.Drawing.Point(112, 46);
            this.txtBoxKt.Name = "txtBoxKt";
            this.txtBoxKt.Size = new System.Drawing.Size(100, 23);
            this.txtBoxKt.TabIndex = 21;
            this.txtBoxKt.Text = "30";
            this.txtBoxKt.TextChanged += new System.EventHandler(this.txtBoxKt_TextChanged);
            // 
            // fluxTextBox
            // 
            this.fluxTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fluxTextBox.Location = new System.Drawing.Point(112, 16);
            this.fluxTextBox.Name = "fluxTextBox";
            this.fluxTextBox.Size = new System.Drawing.Size(100, 23);
            this.fluxTextBox.TabIndex = 1;
            this.fluxTextBox.Text = "1.0E14";
            this.fluxTextBox.TextChanged += new System.EventHandler(this.fluxTextBox_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(76, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 19);
            this.label13.TabIndex = 20;
            this.label13.Text = "kT:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(3, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Temperature: ";
            // 
            // temperTextBox
            // 
            this.temperTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.temperTextBox.Location = new System.Drawing.Point(113, 115);
            this.temperTextBox.Name = "temperTextBox";
            this.temperTextBox.ReadOnly = true;
            this.temperTextBox.Size = new System.Drawing.Size(100, 23);
            this.temperTextBox.TabIndex = 3;
            this.temperTextBox.Text = "35000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Isotopes: ";
            // 
            // isotopesRange
            // 
            this.isotopesRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.isotopesRange.Location = new System.Drawing.Point(113, 178);
            this.isotopesRange.Name = "isotopesRange";
            this.isotopesRange.Size = new System.Drawing.Size(100, 23);
            this.isotopesRange.TabIndex = 5;
            this.isotopesRange.Text = "Fe-Po";
            this.isotopesRange.TextChanged += new System.EventHandler(this.isotopesRange_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(218, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "1/cm3";
            // 
            // burnUpBtn
            // 
            this.burnUpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.burnUpBtn.FlatAppearance.BorderSize = 0;
            this.burnUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.burnUpBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.burnUpBtn.Location = new System.Drawing.Point(208, 318);
            this.burnUpBtn.Name = "burnUpBtn";
            this.burnUpBtn.Size = new System.Drawing.Size(90, 28);
            this.burnUpBtn.TabIndex = 15;
            this.burnUpBtn.Text = "BurnUP";
            this.burnUpBtn.UseVisualStyleBackColor = false;
            this.burnUpBtn.Click += new System.EventHandler(this.burnUpBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(220, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "K";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(218, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "e.g. Pb-Bi";
            // 
            // isotopesList
            // 
            this.isotopesList.Location = new System.Drawing.Point(9, 230);
            this.isotopesList.Multiline = true;
            this.isotopesList.Name = "isotopesList";
            this.isotopesList.Size = new System.Drawing.Size(289, 82);
            this.isotopesList.TabIndex = 9;
            this.isotopesList.Text = "Tl-206, Tl-207, Pb-204, Pb-205, Pb-206, Pb-207, Pb-208, Pb-209, Pb-210, Pb-211, B" +
    "i-209, Bi-210, Bi-211, Po-210, Po-211";
            this.isotopesList.TextChanged += new System.EventHandler(this.isotopesList_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(79, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(221, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "e.g. Pb-209, Pb-210, Pb-211, Bi-210 ....";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(38, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 19);
            this.label8.TabIndex = 11;
            this.label8.Text = "Isotopes: ";
            // 
            // mainViewPanel
            // 
            this.mainViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainViewPanel.Location = new System.Drawing.Point(3, 3);
            this.mainViewPanel.Name = "mainViewPanel";
            this.mainViewPanel.Size = new System.Drawing.Size(690, 627);
            this.mainViewPanel.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(307, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(704, 663);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mainViewPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(696, 633);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Result";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.terminal);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(696, 633);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Console";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // terminal
            // 
            this.terminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminal.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.terminal.Location = new System.Drawing.Point(3, 3);
            this.terminal.Name = "terminal";
            this.terminal.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.terminal.Size = new System.Drawing.Size(690, 627);
            this.terminal.TabIndex = 0;
            this.terminal.Text = "";
            this.terminal.WordWrap = false;
            // 
            // CalculationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(179)))));
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "CalculationView";
            this.Size = new System.Drawing.Size(1011, 663);
            this.panel1.ResumeLayout(false);
            this.groupBoxCalculation.ResumeLayout(false);
            this.groupBoxCalculation.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button calculateBtn;
        private System.Windows.Forms.Button burnUpBtn;
        private System.Windows.Forms.TextBox radiationTimeTextBox;
        private System.Windows.Forms.ComboBox timesComBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox isotopesList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox isotopesRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox temperTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fluxTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox densityTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBoxKt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel mainViewPanel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox terminal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxCalculation;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comBoxDataLibs;
        private System.Windows.Forms.ProgressBar calculationStatus;
        private System.Windows.Forms.Label totIsotopes;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button heatDensity;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox neutronFluxTxt;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox methodComBox;
        private System.Windows.Forms.Button calculateMeshBtn;
        private System.Windows.Forms.Button calculateFluxMeshBtn;
    }
}
