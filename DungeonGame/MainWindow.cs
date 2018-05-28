using System;
using System.Windows.Forms;

namespace View
{
    public partial class MainWindow : Form
    {
        Dungeon.Model m;
        FormWindowState lastWindowState; //Dirty hack!!! stolen from: https://stackoverflow.com/questions/1295999/event-when-a-window-gets-maximized-un-maximized
        public MainWindow()
{           InitializeComponent();
            m = new Dungeon.Model(this.canvas, 30, 20);
            inventoryManager.Inventory = m.player.inventory;
            DrawEnvironment.Field.adaptSize(m.Width, m.Height, this.canvas);
            lastWindowState = WindowState;
            //new ExchangeWindow(m.player, m.merchant).Show();
        }

        private void MainWindow2_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            timer1.Interval = 500;
            timer1.Start();
        }

        private void MainWindow2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 'w' || e.KeyChar == 'd' || e.KeyChar == 's' || e.KeyChar == 'a' || e.KeyChar == 'e' || e.KeyChar == 'k')
            {
                m.player.position.draw();
                m.monster.position.draw();
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
                case 'e':
                    if(m.player.position == m.merchant.position)
                    {
                        m.merchant.interact(m.player);
                    }
                    break;
                case 'k':
                    // m.monster.move(m.player, m.board);
                    break;
            }
            m.player.draw();
            m.monster.draw();
        }

        private void canvas_DoubleClick(object sender, EventArgs e)
        {
            m.mapgen();
            m.redrawAll();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
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

        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {
            m.redrawAll();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m.monster.position.draw();
            //m.merchant.position.draw();
          //  m.merchant.move();
            m.monster.move(m.player,m.board);//@todo alle monster moven
            m.monster.draw();
           // m.merchant.draw();
        }
    }
}
