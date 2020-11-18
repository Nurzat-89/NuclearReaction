namespace KazNuclide.Views
{
    partial class DecayInfoView
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
            this.label1 = new System.Windows.Forms.Label();
            this.DecayTypeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Probability = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.EnergyLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Decay type:";
            // 
            // DecayTypeLabel
            // 
            this.DecayTypeLabel.AutoSize = true;
            this.DecayTypeLabel.Location = new System.Drawing.Point(97, 4);
            this.DecayTypeLabel.Name = "DecayTypeLabel";
            this.DecayTypeLabel.Size = new System.Drawing.Size(50, 19);
            this.DecayTypeLabel.TabIndex = 1;
            this.DecayTypeLabel.Text = "Alpha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Probability:";
            // 
            // Probability
            // 
            this.Probability.AutoSize = true;
            this.Probability.Location = new System.Drawing.Point(96, 23);
            this.Probability.Name = "Probability";
            this.Probability.Size = new System.Drawing.Size(44, 19);
            this.Probability.TabIndex = 3;
            this.Probability.Text = "100%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 19);
            this.label13.TabIndex = 4;
            this.label13.Text = "Decay energy:";
            // 
            // EnergyLabel
            // 
            this.EnergyLabel.AutoSize = true;
            this.EnergyLabel.Location = new System.Drawing.Point(121, 42);
            this.EnergyLabel.Name = "EnergyLabel";
            this.EnergyLabel.Size = new System.Drawing.Size(62, 19);
            this.EnergyLabel.TabIndex = 5;
            this.EnergyLabel.Text = "100 keV";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 1);
            this.panel1.TabIndex = 6;
            // 
            // DecayInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(179)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EnergyLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.Probability);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DecayTypeLabel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "DecayInfoView";
            this.Size = new System.Drawing.Size(197, 69);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DecayTypeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Probability;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label EnergyLabel;
        private System.Windows.Forms.Panel panel1;
    }
}
