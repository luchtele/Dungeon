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
    public partial class TradeWindow : Form
    {
        MapObjects.Player player;
        MapObjects.Interactable exchangePartner;
        public TradeWindow()
        {
            InitializeComponent();
        }

        public TradeWindow(MapObjects.Player player, MapObjects.Interactable interactable)
        {
            this.player = player;
            this.exchangePartner = interactable;
            InitializeComponent();
            ExchangePartnerInventory.setInventory(exchangePartner.inventory);
            PlayerInventory.setInventory(player.inventory);
            ExchangePartnerInventory.reload();
            PlayerInventory.reload();
        }

        private void Buy_Click(object sender, EventArgs e)
        {

        }

        private void TradeWindow_Load(object sender, EventArgs e)
        {

        }

        private void PlayerInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                if(exchangePartner.GetType() == typeof(MapObjects.Merchant))
                {
                    Buy.Text = "Sell";
                }
                else
                {
                    Buy.Text = "Drop";
                }
                
            }
        }
    }
}
