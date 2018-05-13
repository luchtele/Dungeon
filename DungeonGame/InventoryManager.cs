using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Inventory;

namespace View
{
    public partial class InventoryManager : UserControl
    {
        private bool equip = true;
        private Inventory.Inventory inventory;
        public InventoryManager()
        {
            InitializeComponent();
            stuffListBox.Click += stuffListClick; // Handle Methode der Listbox delegate -> Platzhalter für viele Funktionen
        }

        public Inventory.Inventory Inventory
        {
            get { return inventory; }
            set
            {
                if(value != null)
                {
                    inventory = value;
                    stuffListBox.DataSource = inventory.stuff;
                    stuffListBox.DisplayMember = "Name";
                    equippmentListBox.DataSource = inventory.equipment;
                    equippmentListBox.DisplayMember = "Name";
                    moneyBox.Text = Convert.ToString(inventory.Money);
                }
            }
        }

        private void equipButton_Click(object sender, EventArgs e)
        {
            Item temp;
            if (equip)
            {
                temp = (Item)stuffListBox.SelectedItem;
                if(temp != null)
                {
                    if (!inventory.equip(temp)){
                        MessageBox.Show("Already equipped item of type " + temp.type);
                    }
                }
            }
            else
            {
                temp = (Item)equippmentListBox.SelectedItem;
                if(temp != null)
                {
                    inventory.unequip(temp);
                }
            }
        }

        private void stuff_MouseClick(object sender, MouseEventArgs e)
        {
            equip = true;
            equipButton.Text = "equip";
        }

        private void equippment_Click(object sender, EventArgs e)
        {
            equip = false;
            equipButton.Text = "unequip";
        }

        private void stuffListClick(object sender, EventArgs e) 
        {
            this.InvokeOnClick(this, EventArgs.Empty); // lässt OnCLick Event feuern vom Inventorymanager
        }
    }
}
