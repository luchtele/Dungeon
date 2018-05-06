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
        bool give = false;
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

        private void Buy_Click(object sender, EventArgs e)//@todo TEST!!!
        {
            if (give) // Verkaufen/Geben
            {
                player.inventory.give(PlayerInventory.CurrentCell.RowIndex, exchangePartner);
            }
            else //Kaufen @todo für Truhen kein Geld nötig
            {
                if (!exchangePartner.inventory.give(ExchangePartnerInventory.CurrentCell.RowIndex, player))
                {
                    MessageBox.Show("Too expensive ~ sucker!");
                }
            }
            PlayerInventory.reload();
            ExchangePartnerInventory.reload();
        }

        private void TradeWindow_Load(object sender, EventArgs e)
        {

        }

        private void PlayerInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            give = true;
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

        private void ExchangePartnerInventory_CellClick(object sender, DataGridViewCellEventArgs e)//@todo rot färben wenn zu wenig geld mit affordable im inventory
        {
            give = false;
            if (exchangePartner.GetType() == typeof(MapObjects.Merchant))
            {
                Buy.Text = "Buy";
            }
            else
            {
                Buy.Text = "Take";
            }
        }
    }
}
