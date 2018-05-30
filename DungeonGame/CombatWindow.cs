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

        public CombatWindow(ref MapObjects.Player player) 
        {
            InitializeComponent();
            this.m = new Dungeon.Model(this.panel1, 30, 20, ref player);
            DrawEnvironment.Field.adaptSize(m.Width, m.Height, this.panel1);
            lastWindowState = WindowState;
        }

        private void CombatWindow_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void CombatWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'q')
            {
                m.drawMap();
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
    }
}
