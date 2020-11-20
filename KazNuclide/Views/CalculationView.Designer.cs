﻿namespace KazNuclide.Views
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
            this.calculateBtn = new System.Windows.Forms.Button();
            this.burnUpBtn = new System.Windows.Forms.Button();
            this.radiationTimeTextBox = new System.Windows.Forms.TextBox();
            this.timesComBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.isotopesList = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.isotopesRange = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.temperTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fluxTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.densityTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.densityTextBox);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.calculateBtn);
            this.panel1.Controls.Add(this.burnUpBtn);
            this.panel1.Controls.Add(this.radiationTimeTextBox);
            this.panel1.Controls.Add(this.timesComBox);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.isotopesList);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.isotopesRange);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.temperTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.fluxTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 607);
            this.panel1.TabIndex = 0;
            // 
            // calculateBtn
            // 
            this.calculateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.calculateBtn.FlatAppearance.BorderSize = 0;
            this.calculateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculateBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.calculateBtn.Location = new System.Drawing.Point(111, 394);
            this.calculateBtn.Name = "calculateBtn";
            this.calculateBtn.Size = new System.Drawing.Size(90, 28);
            this.calculateBtn.TabIndex = 16;
            this.calculateBtn.Text = "Calculate";
            this.calculateBtn.UseVisualStyleBackColor = false;
            this.calculateBtn.Click += new System.EventHandler(this.calculateBtn_Click);
            // 
            // burnUpBtn
            // 
            this.burnUpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.burnUpBtn.FlatAppearance.BorderSize = 0;
            this.burnUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.burnUpBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.burnUpBtn.Location = new System.Drawing.Point(7, 394);
            this.burnUpBtn.Name = "burnUpBtn";
            this.burnUpBtn.Size = new System.Drawing.Size(90, 28);
            this.burnUpBtn.TabIndex = 15;
            this.burnUpBtn.Text = "BurnUP";
            this.burnUpBtn.UseVisualStyleBackColor = false;
            this.burnUpBtn.Click += new System.EventHandler(this.burnUpBtn_Click);
            // 
            // radiationTimeTextBox
            // 
            this.radiationTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.radiationTimeTextBox.Location = new System.Drawing.Point(82, 344);
            this.radiationTimeTextBox.Name = "radiationTimeTextBox";
            this.radiationTimeTextBox.Size = new System.Drawing.Size(100, 23);
            this.radiationTimeTextBox.TabIndex = 14;
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
            this.timesComBox.Location = new System.Drawing.Point(198, 343);
            this.timesComBox.Name = "timesComBox";
            this.timesComBox.Size = new System.Drawing.Size(95, 25);
            this.timesComBox.TabIndex = 13;
            this.timesComBox.Text = "sec";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 345);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 19);
            this.label9.TabIndex = 12;
            this.label9.Text = "Time:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 19);
            this.label8.TabIndex = 11;
            this.label8.Text = "Isotopes: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(77, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(221, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "e.g. Pb-209, Pb-210, Pb-211, Bi-210 ....";
            // 
            // isotopesList
            // 
            this.isotopesList.Location = new System.Drawing.Point(9, 92);
            this.isotopesList.Multiline = true;
            this.isotopesList.Name = "isotopesList";
            this.isotopesList.Size = new System.Drawing.Size(289, 124);
            this.isotopesList.TabIndex = 9;
            this.isotopesList.Text = "Pb-206, Pb-207, Pb-208, Pb-209, Bi-208, Bi-209, Bi-210, Po-210, Po-211";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "e.g. Pb-Bi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "K";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "1/cm2 s";
            // 
            // isotopesRange
            // 
            this.isotopesRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.isotopesRange.Location = new System.Drawing.Point(80, 222);
            this.isotopesRange.Name = "isotopesRange";
            this.isotopesRange.Size = new System.Drawing.Size(100, 23);
            this.isotopesRange.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Isotopes: ";
            // 
            // temperTextBox
            // 
            this.temperTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.temperTextBox.Location = new System.Drawing.Point(116, 39);
            this.temperTextBox.Name = "temperTextBox";
            this.temperTextBox.Size = new System.Drawing.Size(100, 23);
            this.temperTextBox.TabIndex = 3;
            this.temperTextBox.Text = "300.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Temperature: ";
            // 
            // fluxTextBox
            // 
            this.fluxTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fluxTextBox.Location = new System.Drawing.Point(116, 10);
            this.fluxTextBox.Name = "fluxTextBox";
            this.fluxTextBox.Size = new System.Drawing.Size(100, 23);
            this.fluxTextBox.TabIndex = 1;
            this.fluxTextBox.Text = "1.0E14";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Neutron flux:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 250);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 19);
            this.label10.TabIndex = 17;
            this.label10.Text = "Density: ";
            // 
            // densityTextBox
            // 
            this.densityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.densityTextBox.Location = new System.Drawing.Point(9, 272);
            this.densityTextBox.Multiline = true;
            this.densityTextBox.Name = "densityTextBox";
            this.densityTextBox.Size = new System.Drawing.Size(288, 58);
            this.densityTextBox.TabIndex = 18;
            this.densityTextBox.Text = "Pb-209=1.0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(72, 251);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "e.g. Pb-209=0.9 Bi210=0.1";
            // 
            // CalculationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(179)))));
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "CalculationView";
            this.Size = new System.Drawing.Size(1011, 607);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}