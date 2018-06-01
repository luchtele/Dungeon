using System;
using System.Windows.Forms;

namespace View
{
    public partial class MainWindow : Form
    {
        public Dungeon.Model m;
        FormWindowState lastWindowState; //Dirty hack!!! stolen from: https://stackoverflow.com/questions/1295999/event-when-a-window-gets-maximized-un-maximized
        private Form interactionWindow;
        private bool monsterDead = false;
        public MainWindow()
        {   InitializeComponent();
            m = new Dungeon.Model(this.canvas, 30, 20);
            inventoryManager.Inventory = m.player.inventory;
            DrawEnvironment.Field.adaptSize(m.Width, m.Height, this.canvas);
            lastWindowState = WindowState;
            m.InteractableEncounter += interactableEncounter;
        }

        private void MainWindow2_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            timer1.Interval = 500;
        }

        private void MainWindow2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 'w' || e.KeyChar == 'd' || e.KeyChar == 's' || e.KeyChar == 'a' || e.KeyChar == 'e' || e.KeyChar == 'k')
            {
                m.player.position.draw();
                if(m.merchant.position == m.player.position)
                {
                    m.merchant.draw();
                }
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
                        timer1.Stop();
                        interactionWindow = m.merchant.interact(m.player);
                        interactionWindow.Show();
                        interactionWindow.FormClosed += interactionForm_Close;
                    }
                    if(m.player.position == m.corps.position)
                    {
                        timer1.Stop();
                        interactionWindow = m.corps.interact(m.player);
                        interactionWindow.Show();
                        interactionWindow.FormClosed += interactionForm_Close;
                    }
                    break;
                case 'k':
                    timer1.Start();
                    m.redrawAll();
                    break;
            }
            m.player.draw();
        }

        private void canvas_DoubleClick(object sender, EventArgs e)
        {
            m.mapgen();
            m.redrawAll();
            timer1.Start();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState != lastWindowState) 
            {
                lastWindowState = WindowState;
                if(WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Normal)
                {
                    m.redrawAll();
                    timer1.Start();
                }
            }
        }

        private void MainWindow_ResizeEnd(object sender, EventArgs e)
        {
            m.redrawAll();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(MapObjects.Monster mo in m.monster)
            {
                mo.position.draw();
                if (m.merchant.position == mo.position)
                {
                    m.merchant.draw();
                }
                mo.move(m.player,m.board);
                mo.draw();
            }
        //    m.merchant.position.draw();
          //  m.merchant.move();
           
        }
        private void interactionForm_Close(object sender, EventArgs e)
        {
            timer1.Start();
            m.timer.Start();
            m.redrawAll();
            if (monsterDead) // hässlich gehackt @todo später anders!!!!!!
            {
                foreach(Inventory.Item item in m.corps.inventory.equipment)
                {
                    m.player.inventory.stuff.Add(item);
                }
                monsterDead = false;
            }
        }

        private void interactableEncounter(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(MapObjects.Monster))
            {
                MapObjects.Monster monster = (MapObjects.Monster)sender;
                interactionWindow = monster.interact(m.player);
                interactionWindow.Show();
                m.timer.Stop();
                timer1.Stop();
                m.interactables.Remove(monster);
                m.monster.Remove(monster);
                monsterDead = true;
                interactionWindow.FormClosed += interactionForm_Close;
            }
        }
    }
}
