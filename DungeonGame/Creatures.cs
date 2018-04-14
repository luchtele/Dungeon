﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MapObjects
{
    public class Player : Creature
    {
        public Player(DrawEnvironment.Field field, int hp, Dungeon.Model m) : base(field, new Inventory.Inventory(100), Color.BlueViolet, hp, "Player", m)
        {            
        }

        public override void draw()
        {
            Graphics g = position.form.CreateGraphics();
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


    class Merchant : Creature
    {
        public Merchant(DrawEnvironment.Field field, int hp, Dungeon.Model m) : base(field, new Inventory.Inventory(), Color.DarkOliveGreen, hp, "Merchant", m)
        {
        }
        public override void draw()
        {
            Graphics g = position.form.CreateGraphics();
            SolidBrush b = new SolidBrush(color);
            g.FillEllipse(b, position.rect);
            g.Dispose();
            b.Dispose();
        }

        public override void interact(Interactable p)
        {
            if(p.GetType() == typeof(Player))
            {
                new View.TradeWindow((Player)p, this).Show(); //typecast weil system == doof
                
            }
            else
            {
                throw new ArgumentException("Merchant must interact with a Player");
            }
            
        }

        public void move()
        {
            move(Misc.AI.determineDirection());
        }
    }
}