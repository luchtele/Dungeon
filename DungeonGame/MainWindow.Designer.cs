namespace View
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.canvas = new System.Windows.Forms.Panel();
            this.controlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.statsView = new System.Windows.Forms.DataGridView();
            this.Stats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Values = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventoryManager = new View.InventoryManager();
            this.mainLayout.SuspendLayout();
            this.controlLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statsView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainLayout.Controls.Add(this.canvas, 0, 0);
            this.mainLayout.Controls.Add(this.controlLayout, 1, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(1391, 761);
            this.mainLayout.TabIndex = 0;
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(3, 3);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1037, 755);
            this.canvas.TabIndex = 0;
            this.canvas.DoubleClick += new System.EventHandler(this.canvas_DoubleClick);
            // 
            // controlLayout
            // 
            this.controlLayout.ColumnCount = 1;
            this.controlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.controlLayout.Controls.Add(this.statsView, 0, 0);
            this.controlLayout.Controls.Add(this.inventoryManager, 0, 1);
            this.controlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlLayout.Location = new System.Drawing.Point(1046, 3);
            this.controlLayout.Name = "controlLayout";
            this.controlLayout.RowCount = 2;
            this.controlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.36842F));
            this.controlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.63158F));
            this.controlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.controlLayout.Size = new System.Drawing.Size(342, 755);
            this.controlLayout.TabIndex = 1;
            // 
            // statsView
            // 
            this.statsView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.statsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stats,
            this.Values});
            this.statsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsView.Location = new System.Drawing.Point(3, 3);
            this.statsView.Name = "statsView";
            this.statsView.Size = new System.Drawing.Size(336, 351);
            this.statsView.TabIndex = 0;
            // 
            // Stats
            // 
            this.Stats.HeaderText = "Stats";
            this.Stats.Name = "Stats";
            this.Stats.ReadOnly = true;
            // 
            // Values
            // 
            this.Values.HeaderText = "Values";
            this.Values.Name = "Values";
            this.Values.ReadOnly = true;
            // 
            // inventoryManager
            // 
            this.inventoryManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryManager.Inventory = null;
            this.inventoryManager.Location = new System.Drawing.Point(3, 360);
            this.inventoryManager.Name = "inventoryManager";
            this.inventoryManager.Size = new System.Drawing.Size(336, 392);
            this.inventoryManager.TabIndex = 1;
            // 
            // MainWindow2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1391, 761);
            this.Controls.Add(this.mainLayout);
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.Name = "MainWindow2";
            this.Text = "DungeonGame";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow2_Load);
            this.ResizeEnd += new System.EventHandler(this.MainWindow_ResizeEnd);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainWindow2_KeyPress);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.mainLayout.ResumeLayout(false);
            this.controlLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statsView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.TableLayoutPanel controlLayout;
        private System.Windows.Forms.DataGridView statsView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stats;
        private System.Windows.Forms.DataGridViewTextBoxColumn Values;
        private InventoryManager inventoryManager;
    }
}