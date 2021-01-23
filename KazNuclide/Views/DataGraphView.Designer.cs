
namespace KazNuclide.Views
{
    partial class DataGraphView<T>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.ZedGraph = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ylog = new System.Windows.Forms.CheckBox();
            this.xlog = new System.Windows.Forms.CheckBox();
            this.btnBar = new System.Windows.Forms.Button();
            this.btnPoints = new System.Windows.Forms.Button();
            this.btnLinePoints = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.Label();
            this.metroTabControl2 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.importData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.metroTabControl2.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataTable
            // 
            this.DataTable.AllowUserToResizeColumns = false;
            this.DataTable.AllowUserToResizeRows = false;
            this.DataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataTable.BackgroundColor = System.Drawing.Color.White;
            this.DataTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.DataTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(201)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataTable.ColumnHeadersHeight = 40;
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataTable.EnableHeadersVisualStyles = false;
            this.DataTable.Location = new System.Drawing.Point(0, 0);
            this.DataTable.MultiSelect = false;
            this.DataTable.Name = "DataTable";
            this.DataTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.DataTable.RowHeadersVisible = false;
            this.DataTable.RowHeadersWidth = 51;
            this.DataTable.RowTemplate.Height = 24;
            this.DataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataTable.Size = new System.Drawing.Size(472, 458);
            this.DataTable.TabIndex = 2;
            // 
            // ZedGraph
            // 
            this.ZedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZedGraph.IsShowPointValues = false;
            this.ZedGraph.Location = new System.Drawing.Point(0, 0);
            this.ZedGraph.Name = "ZedGraph";
            this.ZedGraph.PointValueFormat = "G";
            this.ZedGraph.Size = new System.Drawing.Size(472, 469);
            this.ZedGraph.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ylog);
            this.panel1.Controls.Add(this.xlog);
            this.panel1.Controls.Add(this.btnBar);
            this.panel1.Controls.Add(this.btnPoints);
            this.panel1.Controls.Add(this.btnLinePoints);
            this.panel1.Controls.Add(this.btnLine);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 469);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 25);
            this.panel1.TabIndex = 3;
            // 
            // ylog
            // 
            this.ylog.AutoSize = true;
            this.ylog.Dock = System.Windows.Forms.DockStyle.Left;
            this.ylog.Location = new System.Drawing.Point(165, 0);
            this.ylog.Name = "ylog";
            this.ylog.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ylog.Size = new System.Drawing.Size(70, 25);
            this.ylog.TabIndex = 5;
            this.ylog.Text = "ylog";
            this.ylog.UseVisualStyleBackColor = true;
            this.ylog.CheckedChanged += new System.EventHandler(this.ylog_CheckedChanged);
            // 
            // xlog
            // 
            this.xlog.AutoSize = true;
            this.xlog.Dock = System.Windows.Forms.DockStyle.Left;
            this.xlog.Location = new System.Drawing.Point(96, 0);
            this.xlog.Name = "xlog";
            this.xlog.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.xlog.Size = new System.Drawing.Size(69, 25);
            this.xlog.TabIndex = 4;
            this.xlog.Text = "xlog";
            this.xlog.UseVisualStyleBackColor = true;
            this.xlog.CheckedChanged += new System.EventHandler(this.xlog_CheckedChanged);
            // 
            // btnBar
            // 
            this.btnBar.BackgroundImage = global::KazNuclide.Properties.Resources.icons8_bar_chart_26;
            this.btnBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBar.Location = new System.Drawing.Point(72, 0);
            this.btnBar.Name = "btnBar";
            this.btnBar.Size = new System.Drawing.Size(24, 25);
            this.btnBar.TabIndex = 3;
            this.btnBar.UseVisualStyleBackColor = true;
            this.btnBar.Click += new System.EventHandler(this.btnBar_Click);
            // 
            // btnPoints
            // 
            this.btnPoints.BackgroundImage = global::KazNuclide.Properties.Resources.points;
            this.btnPoints.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPoints.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPoints.Location = new System.Drawing.Point(48, 0);
            this.btnPoints.Name = "btnPoints";
            this.btnPoints.Size = new System.Drawing.Size(24, 25);
            this.btnPoints.TabIndex = 2;
            this.btnPoints.UseVisualStyleBackColor = true;
            this.btnPoints.Click += new System.EventHandler(this.btnPoints_Click);
            // 
            // btnLinePoints
            // 
            this.btnLinePoints.BackgroundImage = global::KazNuclide.Properties.Resources.linepoints;
            this.btnLinePoints.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLinePoints.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLinePoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLinePoints.Location = new System.Drawing.Point(24, 0);
            this.btnLinePoints.Name = "btnLinePoints";
            this.btnLinePoints.Size = new System.Drawing.Size(24, 25);
            this.btnLinePoints.TabIndex = 1;
            this.btnLinePoints.UseVisualStyleBackColor = true;
            this.btnLinePoints.Click += new System.EventHandler(this.btnLinePoints_Click);
            // 
            // btnLine
            // 
            this.btnLine.BackgroundImage = global::KazNuclide.Properties.Resources.lineorgin;
            this.btnLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLine.Location = new System.Drawing.Point(0, 0);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(24, 25);
            this.btnLine.TabIndex = 0;
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // Header
            // 
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(480, 37);
            this.Header.TabIndex = 1;
            this.Header.Text = "Header";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroTabControl2
            // 
            this.metroTabControl2.Controls.Add(this.metroTabPage1);
            this.metroTabControl2.Controls.Add(this.metroTabPage2);
            this.metroTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl2.Location = new System.Drawing.Point(0, 37);
            this.metroTabControl2.Name = "metroTabControl2";
            this.metroTabControl2.SelectedIndex = 0;
            this.metroTabControl2.Size = new System.Drawing.Size(480, 537);
            this.metroTabControl2.TabIndex = 2;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.DataTable);
            this.metroTabPage1.Controls.Add(this.panel2);
            this.metroTabPage1.HorizontalScrollbarSize = 0;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(472, 494);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Table";
            this.metroTabPage1.VerticalScrollbarSize = 0;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.ZedGraph);
            this.metroTabPage2.Controls.Add(this.panel1);
            this.metroTabPage2.HorizontalScrollbarSize = 0;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(472, 494);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Graph";
            this.metroTabPage2.VerticalScrollbarSize = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.importData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 458);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 36);
            this.panel2.TabIndex = 3;
            // 
            // importData
            // 
            this.importData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.importData.Dock = System.Windows.Forms.DockStyle.Right;
            this.importData.FlatAppearance.BorderSize = 0;
            this.importData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importData.ForeColor = System.Drawing.Color.White;
            this.importData.Location = new System.Drawing.Point(382, 0);
            this.importData.Name = "importData";
            this.importData.Size = new System.Drawing.Size(90, 36);
            this.importData.TabIndex = 0;
            this.importData.Text = "Import";
            this.importData.UseVisualStyleBackColor = false;
            this.importData.Click += new System.EventHandler(this.importData_Click);
            // 
            // DataGraphView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.metroTabControl2);
            this.Controls.Add(this.Header);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "DataGraphView";
            this.Size = new System.Drawing.Size(480, 574);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.metroTabControl2.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DataTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Button btnBar;
        private System.Windows.Forms.Button btnPoints;
        private System.Windows.Forms.Button btnLinePoints;
        private ZedGraph.ZedGraphControl ZedGraph;
        private System.Windows.Forms.CheckBox ylog;
        private System.Windows.Forms.CheckBox xlog;
        private MetroFramework.Controls.MetroTabControl metroTabControl2;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button importData;
    }
}
