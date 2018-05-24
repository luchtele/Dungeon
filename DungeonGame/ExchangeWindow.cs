using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class ExchangeWindow : Form
    {
        MapObjects.Player player;
        MapObjects.Interactable exchangePartner;
        bool buy = false;
        public ExchangeWindow(MapObjects.Player player, MapObjects.Interactable interactable)
        {
            InitializeComponent();
            this.player = player;
            this.exchangePartner = interactable;
            inventoryManager.Inventory = player.inventory;
            exchangePartnerList.DataSource = exchangePartner.inventory.stuff;
            exchangePartnerList.DisplayMember = "Name";
            compareTable.Rows.Add(2);
            compareTable.Rows[0].Cells[0].Value = "Name";
            compareTable.Rows[1].Cells[0].Value = "Value";
            compareTable.Rows[2].Cells[0].Value = "Actionvalue";
            compareTable.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            if (buy)
            {
                try
                {
                    if (!exchangePartner.inventory.give((Inventory.Item)exchangePartnerList.SelectedItem, player))
                    {
                        MessageBox.Show("Too expensive ~ sucker!");
                    }
                }
                catch(ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show("Nothing to buy");
                }
            }
            else
            {
                try
                {
                    player.inventory.give(inventoryManager.item, exchangePartner);
                }
                catch(ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show("Nothing to sell");
                }
            }
        }

        private void inventoryManager_Click(object sender, EventArgs e)
        {
            buy = false;
            buyButton.Text = "sell";
            Inventory.Item i = (Inventory.Item)inventoryManager.StuffListBox.SelectedItem;
            setCompareTable(1, i);
            findCompareable(i, player.inventory.equipment);
        }

        private void exchangePartnerList_Click(object sender, EventArgs e)
        {
            buy = true;
            buyButton.Text = "buy";
            Inventory.Item i = (Inventory.Item)exchangePartnerList.SelectedItem;
            setCompareTable(1, i);
            findCompareable(i, player.inventory.equipment);
        }

        private void setCompareTable(int i, Inventory.Item item)
        {
            compareTable.Rows[0].Cells[i].Value = item.Name;
            compareTable.Rows[1].Cells[i].Value = Convert.ToString(item.value);
            compareTable.Rows[2].Cells[i].Value = Convert.ToString(item.actionvalue);
        }
        private void findCompareable(Inventory.Item item, BindingList<Inventory.Item> equippment)
        {
            foreach (Inventory.Item i in equippment)
            {
                if (item.type == i.type)
                {
                    setCompareTable(2, i);
                }
            }
        }

    }
}
