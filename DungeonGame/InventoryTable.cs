using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    class InventoryTable : DataGridView
    {
        Inventory.Inventory inventory;
        bool showEq;
        int colCount = 1;

        //Füge neue property hinzu
        [Description("Gibt an, ob das Equippment des Inventars angezeigt werden soll"), Category("Inventareinstellungen")]
        public bool ShowEquippment
        {
            get { return showEq; }
            set
            {
                showEq = value;
                if (value)
                {
                    colCount = 2;
                }
                else
                {
                    colCount = 1;
                }
            }
        }

        public InventoryTable()
        {
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void setInventory(Inventory.Inventory i)
        {
            this.inventory= i;
        }

        public void reload()
        {
            Columns.Clear();
            ColumnCount = colCount;

            if (showEq)
            {
                RowCount = Math.Max(inventory.stuff.Count, inventory.equipment.Count);
            }
            else
            {
                RowCount = inventory.stuff.Count;
            }

            int counter = 0;
            Columns[0].HeaderText = "Inventory";

            if (showEq)
            {
                Columns[1].HeaderText = "Equipment";
            }
            
            foreach (Inventory.Item i in inventory.stuff)
            {
                Rows[counter++].Cells[0].Value = i.name;
            }

            if (showEq)
            {
                counter = 0;
                foreach (Inventory.Item i in inventory.equipment)
                {
                    Rows[counter++].Cells[1].Value = i.name;
                }
            }
        }
    }
}
