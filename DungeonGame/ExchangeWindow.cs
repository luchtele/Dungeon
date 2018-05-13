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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            
        }

        private void inventoryManager_Click(object sender, EventArgs e)
        {
            buy = false;
            buyButton.Text = "sell";
        }

        private void exchangePartnerList_Click(object sender, EventArgs e)
        {
            buy = true;
            buyButton.Text = "buy";
        }

    }
}
