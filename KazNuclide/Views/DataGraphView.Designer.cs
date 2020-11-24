
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.TableTab = new MetroFramework.Controls.MetroTabPage();
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.GraphTab = new MetroFramework.Controls.MetroTabPage();
            this.ZedGraph = new ZedGraph.ZedGraphControl();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBar = new System.Windows.Forms.Button();
            this.btnPoints = new System.Windows.Forms.Button();
            this.btnLinePoints = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.Label();
            this.xlog = new System.Windows.Forms.CheckBox();
            this.ylog = new System.Windows.Forms.CheckBox();
            this.metroTabControl1.SuspendLayout();
            this.TableTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.GraphTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.metroTabControl1.Controls.Add(this.TableTab);
            this.metroTabControl1.Controls.Add(this.GraphTab);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(0, 37);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(534, 494);
            this.metroTabControl1.TabIndex = 0;
            // 
            // TableTab
            // 
            this.TableTab.Controls.Add(this.DataTable);
            this.TableTab.HorizontalScrollbarBarColor = true;
            this.TableTab.HorizontalScrollbarSize = 0;
            this.TableTab.Location = new System.Drawing.Point(4, 4);
            this.TableTab.Name = "TableTab";
            this.TableTab.Size = new System.Drawing.Size(526, 451);
            this.TableTab.TabIndex = 1;
            this.TableTab.Text = "Table";
            this.TableTab.VerticalScrollbarBarColor = true;
            this.TableTab.VerticalScrollbarSize = 0;
            // 
            // DataTable
            // 
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataTable.Location = new System.Drawing.Point(0, 0);
            this.DataTable.Name = "DataTable";
            this.DataTable.RowHeadersWidth = 51;
            this.DataTable.RowTemplate.Height = 24;
            this.DataTable.Size = new System.Drawing.Size(526, 451);
            this.DataTable.TabIndex = 2;
            // 
            // GraphTab
            // 
            this.GraphTab.Controls.Add(this.ZedGraph);
            this.GraphTab.Controls.Add(this.zedGraphControl1);
            this.GraphTab.Controls.Add(this.panel1);
            this.GraphTab.HorizontalScrollbarBarColor = true;
            this.GraphTab.HorizontalScrollbarSize = 0;
            this.GraphTab.Location = new System.Drawing.Point(4, 4);
            this.GraphTab.Name = "GraphTab";
            this.GraphTab.Size = new System.Drawing.Size(526, 451);
            this.GraphTab.TabIndex = 2;
            this.GraphTab.Text = "Graphics";
            this.GraphTab.VerticalScrollbarBarColor = true;
            this.GraphTab.VerticalScrollbarSize = 0;
            // 
            // ZedGraph
            // 
            this.ZedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZedGraph.IsShowPointValues = false;
            this.ZedGraph.Location = new System.Drawing.Point(0, 0);
            this.ZedGraph.Name = "ZedGraph";
            this.ZedGraph.PointValueFormat = "G";
            this.ZedGraph.Size = new System.Drawing.Size(526, 426);
            this.ZedGraph.TabIndex = 4;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.IsShowPointValues = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.PointValueFormat = "G";
            this.zedGraphControl1.Size = new System.Drawing.Size(526, 426);
            this.zedGraphControl1.TabIndex = 2;
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
            this.panel1.Location = new System.Drawing.Point(0, 426);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 25);
            this.panel1.TabIndex = 3;
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
            this.Header.Size = new System.Drawing.Size(534, 37);
            this.Header.TabIndex = 1;
            this.Header.Text = "Header";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // DataGraphView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.Header);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "DataGraphView";
            this.Size = new System.Drawing.Size(534, 531);
            this.metroTabControl1.ResumeLayout(false);
            this.TableTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.GraphTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage TableTab;
        private System.Windows.Forms.DataGridView DataTable;
        private MetroFramework.Controls.MetroTabPage GraphTab;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Button btnBar;
        private System.Windows.Forms.Button btnPoints;
        private System.Windows.Forms.Button btnLinePoints;
        private ZedGraph.ZedGraphControl ZedGraph;
        private System.Windows.Forms.CheckBox ylog;
        private System.Windows.Forms.CheckBox xlog;
    }
}
