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

        public CombatWindow(MapObjects.Player player) 
        {
            InitializeComponent();
            m = new Dungeon.Model(this.panel1, 30, 20, player);
            DrawEnvironment.Field.adaptSize(m.Width, m.Height, this.panel1);
            lastWindowState = WindowState;
        }
    }
}
