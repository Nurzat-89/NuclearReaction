namespace KazNuclide.Views
{
    partial class ElementView
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
            this.ElementName = new System.Windows.Forms.Label();
            this.ZNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ElementName
            // 
            this.ElementName.AutoSize = true;
            this.ElementName.BackColor = System.Drawing.Color.Transparent;
            this.ElementName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ElementName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElementName.Location = new System.Drawing.Point(4, 12);
            this.ElementName.Name = "ElementName";
            this.ElementName.Size = new System.Drawing.Size(32, 19);
            this.ElementName.TabIndex = 0;
            this.ElementName.Text = "He";
            this.ElementName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElementName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ElementName_MouseDown);
            this.ElementName.MouseEnter += new System.EventHandler(this.ElementName_MouseEnter);
            this.ElementName.MouseLeave += new System.EventHandler(this.ElementName_MouseLeave);
            // 
            // ZNumber
            // 
            this.ZNumber.AutoSize = true;
            this.ZNumber.BackColor = System.Drawing.Color.Transparent;
            this.ZNumber.Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ZNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ZNumber.Location = new System.Drawing.Point(-1, 0);
            this.ZNumber.Name = "ZNumber";
            this.ZNumber.Size = new System.Drawing.Size(19, 15);
            this.ZNumber.TabIndex = 1;
            this.ZNumber.Text = "82";
            this.ZNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ZNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ElementName_MouseDown);
            this.ZNumber.MouseEnter += new System.EventHandler(this.ElementName_MouseEnter);
            this.ZNumber.MouseLeave += new System.EventHandler(this.ElementName_MouseLeave);
            // 
            // ElementView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.ZNumber);
            this.Controls.Add(this.ElementName);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "ElementView";
            this.Size = new System.Drawing.Size(38, 38);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ElementName_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label ElementName;
        public System.Windows.Forms.Label ZNumber;
    }
}
