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
    public partial class MainWindow : Form
    {
        Dungeon.Model m;
        private bool equip = false;
        
        public MainWindow()
        {
            InitializeComponent();
            m = new Dungeon.Model(this, 30, 20);
            PlayerInventory.setInventory(m.player.inventory);
            PlayerInventory.reload();
            new TradeWindow(m.player, m.player).Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void button1_Click_1(object sender, EventArgs e) //EquipButton
        {
            m.mapgen();      
            foreach (DrawEnvironment.Field f in m.board)
            {
                f.draw();
            }
            try
            {
                m.player.draw();//nachher raus!!!!!!!!!!!!!!!!!!!!!!!!!!

                if (equip)
                {
                    m.player.inventory.equip(PlayerInventory.CurrentCell.RowIndex);
                }
                else
                {
                    m.player.inventory.unequip(PlayerInventory.CurrentCell.RowIndex);
                }

                PlayerInventory.reload();
            }
            catch(ArgumentOutOfRangeException ex)
            {

            }
        }

       
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'w' || e.KeyChar == 'd' || e.KeyChar == 's' || e.KeyChar == 'a')
            {
                m.player.position.draw();
            }
            switch (e.KeyChar)
            {
                case 'w':
                    m.player.move(0);
                    break;
                case 'd':
                    m.player.move(1);
                    break;
                case 's':
                    m.player.move(2);
                    break;
                case 'a':
                    m.player.move(3);
                    break;
            }
            m.player.draw();
        }

        private void PlayerInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                equip = true;
                EquipButton.Text = "equip";
            }
            else
            {
                equip = false;
                EquipButton.Text = "unequip";
            }
        }
    }
}
