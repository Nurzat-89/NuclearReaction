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
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.elementView4 = new KazNuclide.Views.ElementView();
            this.elementView3 = new KazNuclide.Views.ElementView();
            this.elementView2 = new KazNuclide.Views.ElementView();
            this.elementView1 = new KazNuclide.Views.ElementView();
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
            this.label1.Size = new System.Drawing.Size(648, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mendeleev Table";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.elementView4);
            this.panel1.Controls.Add(this.elementView3);
            this.panel1.Controls.Add(this.elementView2);
            this.panel1.Controls.Add(this.elementView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 412);
            this.panel1.TabIndex = 1;
            // 
            // elementView4
            // 
            this.elementView4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.elementView4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elementView4.Location = new System.Drawing.Point(130, 3);
            this.elementView4.Name = "elementView4";
            this.elementView4.Number = 0;
            this.elementView4.Size = new System.Drawing.Size(43, 45);
            this.elementView4.TabIndex = 3;
            // 
            // elementView3
            // 
            this.elementView3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.elementView3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elementView3.Location = new System.Drawing.Point(88, 3);
            this.elementView3.Name = "elementView3";
            this.elementView3.Number = 0;
            this.elementView3.Size = new System.Drawing.Size(43, 45);
            this.elementView3.TabIndex = 2;
            // 
            // elementView2
            // 
            this.elementView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.elementView2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elementView2.Location = new System.Drawing.Point(46, 3);
            this.elementView2.Name = "elementView2";
            this.elementView2.Number = 0;
            this.elementView2.Size = new System.Drawing.Size(43, 45);
            this.elementView2.TabIndex = 1;
            // 
            // elementView1
            // 
            this.elementView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.elementView1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elementView1.Location = new System.Drawing.Point(4, 3);
            this.elementView1.Name = "elementView1";
            this.elementView1.Number = 0;
            this.elementView1.Size = new System.Drawing.Size(43, 45);
            this.elementView1.TabIndex = 0;
            // 
            // MendeleevTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "MendeleevTableView";
            this.Size = new System.Drawing.Size(648, 448);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ElementView elementView4;
        private ElementView elementView3;
        private ElementView elementView2;
        private ElementView elementView1;
    }
}
