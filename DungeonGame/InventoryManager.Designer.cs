namespace View
{
    partial class InventoryManager
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.inventoryLayout = new System.Windows.Forms.TableLayoutPanel();
            this.equippmentListBox = new System.Windows.Forms.ListBox();
            this.stuffListBox = new System.Windows.Forms.ListBox();
            this.equipButton = new System.Windows.Forms.Button();
            this.stuffLabel = new System.Windows.Forms.Label();
            this.equipmentLabel = new System.Windows.Forms.Label();
            this.moneyBox = new System.Windows.Forms.TextBox();
            this.inventoryLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // inventoryLayout
            // 
            this.inventoryLayout.ColumnCount = 2;
            this.inventoryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.inventoryLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.inventoryLayout.Controls.Add(this.equippmentListBox, 1, 2);
            this.inventoryLayout.Controls.Add(this.stuffListBox, 0, 2);
            this.inventoryLayout.Controls.Add(this.stuffLabel, 0, 1);
            this.inventoryLayout.Controls.Add(this.equipmentLabel, 1, 1);
            this.inventoryLayout.Controls.Add(this.equipButton, 0, 0);
            this.inventoryLayout.Controls.Add(this.moneyBox, 1, 0);
            this.inventoryLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryLayout.Location = new System.Drawing.Point(0, 0);
            this.inventoryLayout.Name = "inventoryLayout";
            this.inventoryLayout.RowCount = 3;
            this.inventoryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.inventoryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.inventoryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.inventoryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.inventoryLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.inventoryLayout.Size = new System.Drawing.Size(330, 291);
            this.inventoryLayout.TabIndex = 0;
            // 
            // equippmentListBox
            // 
            this.equippmentListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.equippmentListBox.FormattingEnabled = true;
            this.equippmentListBox.Location = new System.Drawing.Point(168, 61);
            this.equippmentListBox.Name = "equippmentListBox";
            this.equippmentListBox.Size = new System.Drawing.Size(159, 227);
            this.equippmentListBox.TabIndex = 2;
            this.equippmentListBox.Click += new System.EventHandler(this.equippment_Click);
            // 
            // stuffListBox
            // 
            this.stuffListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stuffListBox.FormattingEnabled = true;
            this.stuffListBox.Location = new System.Drawing.Point(3, 61);
            this.stuffListBox.Name = "stuffListBox";
            this.stuffListBox.Size = new System.Drawing.Size(159, 227);
            this.stuffListBox.TabIndex = 0;
            this.stuffListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.stuff_MouseClick);
            // 
            // equipButton
            // 
            this.equipButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.equipButton.Location = new System.Drawing.Point(45, 3);
            this.equipButton.Name = "equipButton";
            this.equipButton.Size = new System.Drawing.Size(75, 22);
            this.equipButton.TabIndex = 0;
            this.equipButton.Text = "equip";
            this.equipButton.UseVisualStyleBackColor = true;
            this.equipButton.Click += new System.EventHandler(this.equipButton_Click);
            // 
            // stuffLabel
            // 
            this.stuffLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stuffLabel.AutoSize = true;
            this.stuffLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stuffLabel.Location = new System.Drawing.Point(58, 33);
            this.stuffLabel.Name = "stuffLabel";
            this.stuffLabel.Size = new System.Drawing.Size(49, 20);
            this.stuffLabel.TabIndex = 3;
            this.stuffLabel.Text = "Stuff";
            // 
            // equipmentLabel
            // 
            this.equipmentLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.equipmentLabel.AutoSize = true;
            this.equipmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentLabel.Location = new System.Drawing.Point(200, 33);
            this.equipmentLabel.Name = "equipmentLabel";
            this.equipmentLabel.Size = new System.Drawing.Size(95, 20);
            this.equipmentLabel.TabIndex = 4;
            this.equipmentLabel.Text = "Equipment";
            // 
            // moneyBox
            // 
            this.moneyBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.moneyBox.Location = new System.Drawing.Point(197, 4);
            this.moneyBox.Name = "moneyBox";
            this.moneyBox.ReadOnly = true;
            this.moneyBox.Size = new System.Drawing.Size(100, 20);
            this.moneyBox.TabIndex = 5;
            // 
            // InventoryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inventoryLayout);
            this.Name = "InventoryManager";
            this.Size = new System.Drawing.Size(330, 291);
            this.inventoryLayout.ResumeLayout(false);
            this.inventoryLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel inventoryLayout;
        private System.Windows.Forms.ListBox stuffListBox;
        private System.Windows.Forms.Button equipButton;
        private System.Windows.Forms.ListBox equippmentListBox;
        private System.Windows.Forms.Label stuffLabel;
        private System.Windows.Forms.Label equipmentLabel;
        private System.Windows.Forms.TextBox moneyBox;
    }
}
