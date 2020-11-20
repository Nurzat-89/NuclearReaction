namespace KazNuclide.Views
{
    partial class GraphControlView
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
            this.ZedGraph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // ZedGraph
            // 
            this.ZedGraph.IsShowPointValues = false;
            this.ZedGraph.Location = new System.Drawing.Point(3, 3);
            this.ZedGraph.Name = "ZedGraph";
            this.ZedGraph.PointValueFormat = "G";
            this.ZedGraph.Size = new System.Drawing.Size(618, 544);
            this.ZedGraph.TabIndex = 0;
            // 
            // GraphControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ZedGraph);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "GraphControlView";
            this.Size = new System.Drawing.Size(624, 550);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl ZedGraph;
    }
}
