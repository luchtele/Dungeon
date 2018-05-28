using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MapObjects
{
    public class Player : Creature
    {
        public Player(ref DrawEnvironment.Field field, int hp, Dungeon.Model m) : base(ref field, new Inventory.Inventory(100), Color.DarkRed, hp, "Player", m)
        {            
        }

        public override void draw()
        {
            Graphics g = position.canvas.CreateGraphics();
            SolidBrush b = new SolidBrush(color);
            g.FillEllipse(b, position.rect); 
            g.Dispose();
            b.Dispose();
        }

        public override void interact(Interactable i)
        {
            throw new NotImplementedException();
        }
    }


    public class Merchant : Creature
    {
        public Merchant(ref DrawEnvironment.Field field, int hp, Dungeon.Model m) : base(ref field, new Inventory.Inventory(), Color.DarkOliveGreen, hp, "Merchant", m)
        {
        }
        public override void draw()
        {
            Graphics g = position.canvas.CreateGraphics();
            SolidBrush b = new SolidBrush(color);
            g.FillEllipse(b, position.rect);
            g.Dispose();
            b.Dispose();
        }

        public override void interact(Interactable p)
        {
            if(p.GetType() == typeof(Player))
            {
                //typecast weil system == doof tradewindow erwartet player
                new View.ExchangeWindow((Player)p, this).Show();
            }
            else
            {
                throw new ArgumentException("Merchant must interact with a Player");
            }
            
        }

        public void move() //@todo unnötig?? stehender merchant?
        {
            move(Misc.AI.randomDirection());
        }
    }


    public class Monster : Creature
    {
        public Monster(ref DrawEnvironment.Field field, int hp, Dungeon.Model m) : base(ref field, new Inventory.Inventory(), Color.Crimson, hp, "Monster", m)
        {

        }
        public override void draw()
        {
            Graphics g = position.canvas.CreateGraphics();
            SolidBrush b = new SolidBrush(color);
            g.FillEllipse(b, position.rect);
            g.Dispose();
            b.Dispose();
        }

        public override void interact(Interactable i)//@todo popup window für kampf
        {
            throw new NotImplementedException();
        }

        public void move(Player player, DrawEnvironment.Field[,] board)
        {
            int distance = Math.Abs(player.position.posx - position.posx) + Math.Abs(player.position.posy - position.posy); //Abstand monster+player
            int maxDistance = 10;

                if (distance <= maxDistance)
                {
                    move(Misc.AI.follow(player, this, board));
                }
               /* else
                {
                    move(Misc.AI.randomDirection());
                }*/
        }
    }
}
