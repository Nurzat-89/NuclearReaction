namespace KazNuclide.Views
{
    partial class IsotopeInfoView
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
            this.IsotopeName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AtomicMassLabel = new System.Windows.Forms.Label();
            this.HalfLifeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.decaysPanel = new System.Windows.Forms.Panel();
            this.crossSectionPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IsotopeName
            // 
            this.IsotopeName.AutoSize = true;
            this.IsotopeName.Location = new System.Drawing.Point(12, 10);
            this.IsotopeName.Name = "IsotopeName";
            this.IsotopeName.Size = new System.Drawing.Size(65, 21);
            this.IsotopeName.TabIndex = 0;
            this.IsotopeName.Text = "Pb-208";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Atomic mass:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Halflife:";
            // 
            // AtomicMassLabel
            // 
            this.AtomicMassLabel.AutoSize = true;
            this.AtomicMassLabel.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AtomicMassLabel.Location = new System.Drawing.Point(109, 31);
            this.AtomicMassLabel.Name = "AtomicMassLabel";
            this.AtomicMassLabel.Size = new System.Drawing.Size(81, 19);
            this.AtomicMassLabel.TabIndex = 3;
            this.AtomicMassLabel.Text = "1.009 aem";
            // 
            // HalfLifeLabel
            // 
            this.HalfLifeLabel.AutoSize = true;
            this.HalfLifeLabel.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HalfLifeLabel.Location = new System.Drawing.Point(73, 50);
            this.HalfLifeLabel.Name = "HalfLifeLabel";
            this.HalfLifeLabel.Size = new System.Drawing.Size(58, 19);
            this.HalfLifeLabel.TabIndex = 4;
            this.HalfLifeLabel.Text = "1.9 min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(14, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Decay types";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.IsotopeName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.HalfLifeLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.AtomicMassLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 96);
            this.panel1.TabIndex = 6;
            // 
            // decaysPanel
            // 
            this.decaysPanel.AutoScroll = true;
            this.decaysPanel.AutoSize = true;
            this.decaysPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.decaysPanel.Location = new System.Drawing.Point(0, 96);
            this.decaysPanel.Name = "decaysPanel";
            this.decaysPanel.Size = new System.Drawing.Size(215, 0);
            this.decaysPanel.TabIndex = 7;
            // 
            // crossSectionPanel
            // 
            this.crossSectionPanel.AutoScroll = true;
            this.crossSectionPanel.AutoSize = true;
            this.crossSectionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.crossSectionPanel.Location = new System.Drawing.Point(0, 96);
            this.crossSectionPanel.Name = "crossSectionPanel";
            this.crossSectionPanel.Size = new System.Drawing.Size(215, 0);
            this.crossSectionPanel.TabIndex = 8;
            // 
            // IsotopeInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(179)))));
            this.Controls.Add(this.crossSectionPanel);
            this.Controls.Add(this.decaysPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "IsotopeInfoView";
            this.Size = new System.Drawing.Size(215, 349);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IsotopeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label AtomicMassLabel;
        private System.Windows.Forms.Label HalfLifeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel decaysPanel;
        private System.Windows.Forms.Panel crossSectionPanel;
    }
}
