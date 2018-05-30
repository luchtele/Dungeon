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

            
        public bool bow(List<Monster> monster)
        {
            foreach (Inventory.Item i in this.inventory.equipment)
            {
                if (i.type == Inventory.objecttype.BOW)
                {
                    foreach (Monster mo in monster)
                    {
                        int distance = Math.Abs(mo.position.posx - this.position.posx) + Math.Abs(mo.position.posy - this.position.posy);
                        if (i.use(mo, distance))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool bomb(List<Monster> monster)
        {
            foreach (Inventory.Item i in this.inventory.equipment)
            {
                if (i.type == Inventory.objecttype.BOMB)
                {
                    foreach (Monster mo in monster)
                    {
                        int distance = Math.Abs(mo.position.posx - this.position.posx) + Math.Abs(mo.position.posy - this.position.posy);
                        if (i.use(mo, distance))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool sword(List<Monster> monster)
        {
            foreach (Inventory.Item i in this.inventory.equipment)
            {
                if (i.type == Inventory.objecttype.SWORD)
                {
                    foreach (Monster mo in monster)
                    {
                        int distance = Math.Abs(mo.position.posx - this.position.posx) + Math.Abs(mo.position.posy - this.position.posy);
                        if (i.use(mo, distance))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
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

        public void move(Player player, DrawEnvironment.Field[,] board) //@todo model.board statt extra board
        {
            int distance = Math.Abs(player.position.posx - position.posx) + Math.Abs(player.position.posy - position.posy); //Abstand monster+player
            int maxDistance = 10;

               if (distance <= maxDistance)
               {
                    int direction = Misc.AI.follow(player, this, board);
                    if (direction != -1)
                    {

                        move(direction);
                    }
                    else
                    {
                        move(Misc.AI.randomDirection());
                    }
               }
               else
               {
                    move(Misc.AI.randomDirection());
               }
        }
        public void combat(int distance, Player p)
        {
            if(distance == Inventory.Item.bombRange || distance == Inventory.Item.bowRange || distance == Inventory.Item.swordRange)
            {
                Misc.AI.combat(this, p);
            }
            else
            {
                move(Misc.AI.follow(p, this, model.board));
            }
            //AI
        }
    }
}
