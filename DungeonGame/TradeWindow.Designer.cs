namespace View
{
    partial class TradeWindow
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
            this.Buy = new System.Windows.Forms.Button();
            this.PlayerInventory = new View.InventoryTable();
            this.ExchangePartnerInventory = new View.InventoryTable();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangePartnerInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // Buy
            // 
            this.Buy.Location = new System.Drawing.Point(416, 12);
            this.Buy.Name = "Buy";
            this.Buy.Size = new System.Drawing.Size(75, 23);
            this.Buy.TabIndex = 2;
            this.Buy.Text = "Buy";
            this.Buy.UseVisualStyleBackColor = true;
            this.Buy.Click += new System.EventHandler(this.Buy_Click);
            // 
            // PlayerInventory
            // 
            this.PlayerInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PlayerInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlayerInventory.Location = new System.Drawing.Point(12, 12);
            this.PlayerInventory.Name = "PlayerInventory";
            this.PlayerInventory.ShowEquippment = true;
            this.PlayerInventory.Size = new System.Drawing.Size(341, 349);
            this.PlayerInventory.TabIndex = 3;
            this.PlayerInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlayerInventory_CellClick);
            // 
            // ExchangePartnerInventory
            // 
            this.ExchangePartnerInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ExchangePartnerInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExchangePartnerInventory.Location = new System.Drawing.Point(544, 12);
            this.ExchangePartnerInventory.Name = "ExchangePartnerInventory";
            this.ExchangePartnerInventory.ShowEquippment = false;
            this.ExchangePartnerInventory.Size = new System.Drawing.Size(240, 349);
            this.ExchangePartnerInventory.TabIndex = 4;
            this.ExchangePartnerInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExchangePartnerInventory_CellClick);
            // 
            // TradeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 373);
            this.Controls.Add(this.ExchangePartnerInventory);
            this.Controls.Add(this.PlayerInventory);
            this.Controls.Add(this.Buy);
            this.Name = "TradeWindow";
            this.Text = "TradeWindow";
            this.Load += new System.EventHandler(this.TradeWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlayerInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangePartnerInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Buy;
        private InventoryTable PlayerInventory;
        private InventoryTable ExchangePartnerInventory;
    }
}