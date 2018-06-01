using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MapObjects
{
    public class Stash : Interactable
    {
        private string name;

        public Stash(ref DrawEnvironment.Field field, Inventory.Inventory inventory, string name ): base(ref field, inventory, Color.CadetBlue)
        {
            this.name = name;
        }

        public override void draw()
        {
            Graphics g = position.canvas.CreateGraphics();
            SolidBrush b = new SolidBrush(color);
            g.FillEllipse(b, position.rect); 
            g.Dispose();
            b.Dispose();

        }

        public override Form interact(Interactable i)
        {
            if(i.GetType() == typeof(Player))
            {
                //typecast weil system == doof tradewindow erwartet player
                return new View.ExchangeWindow((Player)i, this);
            }
            else
            {
                throw new ArgumentException("Stash must interact with a Player");
            }
        }
    }
}
