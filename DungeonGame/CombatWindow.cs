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
    public partial class CombatWindow : Form
    {
        Dungeon.Model m;
        FormWindowState lastWindowState; //Dirty hack!!! stolen from: https://stackoverflow.com/questions/1295999/event-when-a-window-gets-maximized-un-maximized
        int turn = 0;
       
        public CombatWindow(ref MapObjects.Player player) 
        {
            InitializeComponent();
            this.m = new Dungeon.Model(this.panel1, 20, 10, player);
            DrawEnvironment.Field.adaptSize(m.Width, m.Height, this.panel1);
            lastWindowState = WindowState;
        }

        private void CombatWindow_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            timer1.Start();
            timer1.Interval = 500; 
        }

        private void CombatWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
           // turn = 0; // nacher raus!!!!!!!!!!!!!!!!!!!!!!!!!
            if (turn == 0)
            {
                m.player.position.draw();
                if(e.KeyChar == 'w' || e.KeyChar == 'd' || e.KeyChar == 's' || e.KeyChar == 'a' || e.KeyChar == 'e' || e.KeyChar == 'k' || e.KeyChar == 'b' || e.KeyChar == 'h')
                {
                    switch (e.KeyChar)
                    {
                        case 'w':
                            m.player.move(0);
                            turn = 1;
                            break;
                        case 'd':
                            m.player.move(1);
                            turn = 1;
                            break;
                        case 's':
                            m.player.move(2);
                            turn = 1;
                            break;
                        case 'a':
                            m.player.move(3);
                            turn = 1;
                            break;
                        case 'k':
                            if (m.player.attack(m.monster, Inventory.objecttype.SWORD))
                            {
                                turn = 1;
                                break;
                            }
                            break;
                        case 'e':
                            if (m.player.attack(m.monster, Inventory.objecttype.BOMB))
                            {
                                turn = 1;
                                break;
                            }
                            break;
                        case 'b':
                            if (m.player.attack(m.monster, Inventory.objecttype.BOW))
                            {
                                turn = 1;
                                break;
                            }
                            break;
                        case 'h':
                            if(m.player.heal())
                            {
                                turn = 1;
                                break;
                            }
                            break;
                    }

                }
                int hp = m.monster[0].hp;
                m.player.draw();
                m.monster[0].draw();
                textBox1.Text = Convert.ToString(hp);
            }
        }

        private void CombatWindow_ResizeEnd(object sender, EventArgs e)
        {
           m.redrawAll();
        }

        private void CombatWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState != lastWindowState) 
            {
                lastWindowState = WindowState;
                if(WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Normal)
                {
                    m.redrawAll();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (turn == 1)
            {
                foreach(MapObjects.Monster mo in m.monster)
                {
                    mo.position.draw();
                   
                    mo.combat(m.player);
                    mo.draw();
                }
                turn = 0;
            }
            textBox2.Text = Convert.ToString(m.player.hp);
        }
    }
}
