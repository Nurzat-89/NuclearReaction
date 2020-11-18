namespace KazNuclide.Views
{
    partial class MendeleevTableView
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
            this.MendeleevTablePanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.isotopesListView = new System.Windows.Forms.ListBox();
            this.ElementNameLabel = new System.Windows.Forms.Label();
            this.isotopeInfoPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1224, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mendeleev Table";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MendeleevTablePanel
            // 
            this.MendeleevTablePanel.AutoScroll = true;
            this.MendeleevTablePanel.AutoSize = true;
            this.MendeleevTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MendeleevTablePanel.Location = new System.Drawing.Point(166, 38);
            this.MendeleevTablePanel.Name = "MendeleevTablePanel";
            this.MendeleevTablePanel.Size = new System.Drawing.Size(1058, 594);
            this.MendeleevTablePanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.isotopesListView);
            this.panel1.Controls.Add(this.ElementNameLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 594);
            this.panel1.TabIndex = 2;
            // 
            // isotopesListView
            // 
            this.isotopesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.isotopesListView.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isotopesListView.FormattingEnabled = true;
            this.isotopesListView.ItemHeight = 20;
            this.isotopesListView.Location = new System.Drawing.Point(0, 34);
            this.isotopesListView.Name = "isotopesListView";
            this.isotopesListView.Size = new System.Drawing.Size(162, 558);
            this.isotopesListView.TabIndex = 0;
            this.isotopesListView.SelectedIndexChanged += new System.EventHandler(this.isotopesListView_SelectedIndexChanged);
            // 
            // ElementNameLabel
            // 
            this.ElementNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ElementNameLabel.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ElementNameLabel.Location = new System.Drawing.Point(0, 0);
            this.ElementNameLabel.Name = "ElementNameLabel";
            this.ElementNameLabel.Size = new System.Drawing.Size(162, 34);
            this.ElementNameLabel.TabIndex = 0;
            this.ElementNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // isotopeInfoPanel
            // 
            this.isotopeInfoPanel.AutoSize = true;
            this.isotopeInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.isotopeInfoPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.isotopeInfoPanel.Location = new System.Drawing.Point(164, 38);
            this.isotopeInfoPanel.Name = "isotopeInfoPanel";
            this.isotopeInfoPanel.Size = new System.Drawing.Size(2, 594);
            this.isotopeInfoPanel.TabIndex = 3;
            // 
            // MendeleevTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(179)))));
            this.Controls.Add(this.MendeleevTablePanel);
            this.Controls.Add(this.isotopeInfoPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "MendeleevTableView";
            this.Size = new System.Drawing.Size(1224, 632);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel MendeleevTablePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox isotopesListView;
        private System.Windows.Forms.Label ElementNameLabel;
        private System.Windows.Forms.Panel isotopeInfoPanel;
    }
}
