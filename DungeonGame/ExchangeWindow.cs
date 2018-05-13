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

        public ExchangeWindow(MapObjects.Player player, MapObjects.Interactable interactable)
        {
            InitializeComponent();
            this.player = player;
            this.exchangePartner = interactable;
            //partyInventoryManager.Inventory = this.player.inventory;
        }
    }
}
