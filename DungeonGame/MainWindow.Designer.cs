namespace View
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.EquipButton = new System.Windows.Forms.Button();
            this.PlayerInventory = new View.InventoryTable();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // EquipButton
            // 
            this.EquipButton.Location = new System.Drawing.Point(1071, 283);
            this.EquipButton.Name = "EquipButton";
            this.EquipButton.Size = new System.Drawing.Size(75, 23);
            this.EquipButton.TabIndex = 0;
            this.EquipButton.Text = "Equip";
            this.EquipButton.UseVisualStyleBackColor = true;
            this.EquipButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // PlayerInventory
            // 
            this.PlayerInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PlayerInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlayerInventory.Location = new System.Drawing.Point(996, 321);
            this.PlayerInventory.Name = "PlayerInventory";
            this.PlayerInventory.ShowEquippment = true;
            this.PlayerInventory.Size = new System.Drawing.Size(240, 150);
            this.PlayerInventory.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 632);
            this.Controls.Add(this.PlayerInventory);
            this.Controls.Add(this.EquipButton);
            this.Name = "MainWindow";
            this.Text = "DungeonGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.PlayerInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EquipButton;
        private InventoryTable PlayerInventory;
    }
}

