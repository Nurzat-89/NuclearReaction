namespace KazNuclide
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnCalculation = new System.Windows.Forms.Button();
            this.btnNuclearData = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.holeViewPanel = new System.Windows.Forms.Panel();
            this.MainViewPanel = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.holeViewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 67);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(122, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(372, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kazakh National University";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(121, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuclear Reaction Calculation Tool";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::KazNuclide.Properties.Resources.icons8_physics_64;
            this.pictureBox2.Location = new System.Drawing.Point(55, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pictureBox2.Size = new System.Drawing.Size(52, 67);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::KazNuclide.Properties.Resources.logokaznu;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(55, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(141)))));
            this.panel2.Controls.Add(this.btnSettings);
            this.panel2.Controls.Add(this.btnCalculation);
            this.panel2.Controls.Add(this.btnNuclearData);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(227, 602);
            this.panel2.TabIndex = 1;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(141)))));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSettings.Image = global::KazNuclide.Properties.Resources.icons8_gears_40;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 124);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(227, 49);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Setting";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnCalculation
            // 
            this.btnCalculation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(141)))));
            this.btnCalculation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCalculation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCalculation.FlatAppearance.BorderSize = 0;
            this.btnCalculation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculation.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCalculation.Image = global::KazNuclide.Properties.Resources.icons8_increase_40;
            this.btnCalculation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalculation.Location = new System.Drawing.Point(0, 75);
            this.btnCalculation.Name = "btnCalculation";
            this.btnCalculation.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCalculation.Size = new System.Drawing.Size(227, 49);
            this.btnCalculation.TabIndex = 1;
            this.btnCalculation.Text = "Calculation";
            this.btnCalculation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalculation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCalculation.UseVisualStyleBackColor = false;
            this.btnCalculation.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnNuclearData
            // 
            this.btnNuclearData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(141)))));
            this.btnNuclearData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNuclearData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuclearData.FlatAppearance.BorderSize = 0;
            this.btnNuclearData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuclearData.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNuclearData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNuclearData.Image = global::KazNuclide.Properties.Resources.icons8_database_administrator_40;
            this.btnNuclearData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuclearData.Location = new System.Drawing.Point(0, 26);
            this.btnNuclearData.Name = "btnNuclearData";
            this.btnNuclearData.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnNuclearData.Size = new System.Drawing.Size(227, 49);
            this.btnNuclearData.TabIndex = 0;
            this.btnNuclearData.Text = "Nuclear Data";
            this.btnNuclearData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuclearData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuclearData.UseVisualStyleBackColor = false;
            this.btnNuclearData.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(227, 26);
            this.panel3.TabIndex = 3;
            // 
            // holeViewPanel
            // 
            this.holeViewPanel.Controls.Add(this.MainViewPanel);
            this.holeViewPanel.Controls.Add(this.TitleLabel);
            this.holeViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.holeViewPanel.Location = new System.Drawing.Point(227, 67);
            this.holeViewPanel.Name = "holeViewPanel";
            this.holeViewPanel.Size = new System.Drawing.Size(746, 602);
            this.holeViewPanel.TabIndex = 2;
            // 
            // MainViewPanel
            // 
            this.MainViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainViewPanel.Location = new System.Drawing.Point(0, 26);
            this.MainViewPanel.Name = "MainViewPanel";
            this.MainViewPanel.Size = new System.Drawing.Size(746, 576);
            this.MainViewPanel.TabIndex = 6;
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(141)))));
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TitleLabel.Location = new System.Drawing.Point(0, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(746, 26);
            this.TitleLabel.TabIndex = 5;
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(973, 669);
            this.Controls.Add(this.holeViewPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "KazNuclide";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.holeViewPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNuclearData;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnCalculation;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel holeViewPanel;
        public System.Windows.Forms.Panel MainViewPanel;
        private System.Windows.Forms.Label TitleLabel;
    }
}

