﻿namespace View 
{
    partial class ExchangeWindow
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
            this.exchangeLayout = new System.Windows.Forms.TableLayoutPanel();
            this.inventoryManager = new View.InventoryManager();
            this.buyButton = new System.Windows.Forms.Button();
            this.partyMemberSelection = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exchangePartnerList = new System.Windows.Forms.ListBox();
            this.compareTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exchangeLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compareTable)).BeginInit();
            this.SuspendLayout();
            // 
            // exchangeLayout
            // 
            this.exchangeLayout.ColumnCount = 2;
            this.exchangeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.exchangeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.exchangeLayout.Controls.Add(this.inventoryManager, 0, 1);
            this.exchangeLayout.Controls.Add(this.buyButton, 1, 0);
            this.exchangeLayout.Controls.Add(this.partyMemberSelection, 0, 0);
            this.exchangeLayout.Controls.Add(this.panel1, 1, 1);
            this.exchangeLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exchangeLayout.Location = new System.Drawing.Point(0, 0);
            this.exchangeLayout.Name = "exchangeLayout";
            this.exchangeLayout.RowCount = 2;
            this.exchangeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.exchangeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.exchangeLayout.Size = new System.Drawing.Size(800, 450);
            this.exchangeLayout.TabIndex = 0;
            // 
            // inventoryManager
            // 
            this.inventoryManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryManager.Inventory = null;
            this.inventoryManager.Location = new System.Drawing.Point(3, 48);
            this.inventoryManager.Name = "inventoryManager";
            this.inventoryManager.Size = new System.Drawing.Size(451, 399);
            this.inventoryManager.TabIndex = 0;
            this.inventoryManager.Click += new System.EventHandler(this.inventoryManager_Click);
            // 
            // buyButton
            // 
            this.buyButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buyButton.Location = new System.Drawing.Point(591, 11);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(75, 23);
            this.buyButton.TabIndex = 1;
            this.buyButton.Text = "buy";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // partyMemberSelection
            // 
            this.partyMemberSelection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.partyMemberSelection.FormattingEnabled = true;
            this.partyMemberSelection.Location = new System.Drawing.Point(108, 12);
            this.partyMemberSelection.Name = "partyMemberSelection";
            this.partyMemberSelection.Size = new System.Drawing.Size(241, 21);
            this.partyMemberSelection.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.exchangePartnerList);
            this.panel1.Controls.Add(this.compareTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(460, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 399);
            this.panel1.TabIndex = 5;
            // 
            // exchangePartnerList
            // 
            this.exchangePartnerList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exchangePartnerList.FormattingEnabled = true;
            this.exchangePartnerList.Location = new System.Drawing.Point(50, 164);
            this.exchangePartnerList.Name = "exchangePartnerList";
            this.exchangePartnerList.Size = new System.Drawing.Size(251, 212);
            this.exchangePartnerList.TabIndex = 3;
            this.exchangePartnerList.Click += new System.EventHandler(this.exchangePartnerList_Click);
            // 
            // compareTable
            // 
            this.compareTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.compareTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.compareTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.compareTable.Location = new System.Drawing.Point(16, 17);
            this.compareTable.Name = "compareTable";
            this.compareTable.Size = new System.Drawing.Size(312, 127);
            this.compareTable.TabIndex = 2;
            this.compareTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.HeaderText = "Description";
            this.Column1.Name = "Column1";
            this.Column1.Width = 85;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "Item";
            this.Column2.Name = "Column2";
            this.Column2.Width = 52;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Equipped Item";
            this.Column3.Name = "Column3";
            // 
            // ExchangeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exchangeLayout);
            this.Name = "ExchangeWindow";
            this.Text = "ExchangeWindow";
            this.exchangeLayout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.compareTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private View.InventoryManager inventoryManager1;
        private System.Windows.Forms.TableLayoutPanel exchangeLayout;
        private InventoryManager inventoryManager;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.DataGridView compareTable;
        private System.Windows.Forms.ComboBox partyMemberSelection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox exchangePartnerList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}