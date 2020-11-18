namespace KazNuclide.Views
{
    partial class ReactionInfoView
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
            this.reactionNameLabel = new System.Windows.Forms.Label();
            this.PlotButtton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.endfName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reactionNameLabel
            // 
            this.reactionNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.reactionNameLabel.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reactionNameLabel.Location = new System.Drawing.Point(0, 0);
            this.reactionNameLabel.Name = "reactionNameLabel";
            this.reactionNameLabel.Size = new System.Drawing.Size(90, 20);
            this.reactionNameLabel.TabIndex = 0;
            this.reactionNameLabel.Text = "(n,gamma)";
            this.reactionNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlotButtton
            // 
            this.PlotButtton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PlotButtton.Dock = System.Windows.Forms.DockStyle.Right;
            this.PlotButtton.FlatAppearance.BorderSize = 0;
            this.PlotButtton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlotButtton.Font = new System.Drawing.Font("Century Gothic", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlotButtton.Location = new System.Drawing.Point(342, 0);
            this.PlotButtton.Margin = new System.Windows.Forms.Padding(10);
            this.PlotButtton.Name = "PlotButtton";
            this.PlotButtton.Size = new System.Drawing.Size(41, 20);
            this.PlotButtton.TabIndex = 1;
            this.PlotButtton.Text = "plot";
            this.PlotButtton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PlotButtton.UseVisualStyleBackColor = false;
            this.PlotButtton.Click += new System.EventHandler(this.PlotButtton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 1);
            this.panel1.TabIndex = 2;
            // 
            // endfName
            // 
            this.endfName.Dock = System.Windows.Forms.DockStyle.Left;
            this.endfName.Font = new System.Drawing.Font("Century Gothic", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endfName.Location = new System.Drawing.Point(90, 0);
            this.endfName.Name = "endfName";
            this.endfName.Size = new System.Drawing.Size(90, 20);
            this.endfName.TabIndex = 3;
            this.endfName.Text = "ENDF-B";
            this.endfName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReactionInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(179)))));
            this.Controls.Add(this.endfName);
            this.Controls.Add(this.PlotButtton);
            this.Controls.Add(this.reactionNameLabel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "ReactionInfoView";
            this.Size = new System.Drawing.Size(383, 21);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label reactionNameLabel;
        private System.Windows.Forms.Button PlotButtton;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label endfName;
    }
}
