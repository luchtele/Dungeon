using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class Inventory
    {
        int money;
        public List<Item> stuff;
        public List<Item> equipment;

        public Inventory(int m)
        {
            this.money = m;
            stuff = new List<Item>();
            equipment = new List<Item>();
        }
        public Inventory()
        {
            Random rnd = new Random();

            this.money = rnd.Next(10,1000);
            //@todo rndm Items generieren
            stuff = new List<Item>();
            equipment = new List<Item>();

        }
        
        
        public void add(Item o)
        {
            stuff.Add(o);
        }



    /*    public void equip(string s)
        {
            foreach (Item o in stuff)
            {
                if (o.name.Equals(s))
                {
                    equipment.Add(o);
                    stuff.Remove(o);
                }
            }
        }*/

        public void equip(int i)
        {
            Item temp = stuff[i];
            foreach(Item e in equipment)
            {
                if (e.type == temp.type)
                {
                    return;
                }                
            }
            equipment.Add(temp);
            stuff.Remove(temp);
            
        }

        public void unequip(int i)
        {
            stuff.Add(equipment[i]);
            equipment.Remove(equipment[i]);
          
        }

        public Item sell(string s)
        {
            foreach (Item o in stuff)
            {
                if (o.name.Equals(s))
                {
                    money += o.value;
                    stuff.Remove(o);
                    return o;
                }
            }
            return null; ////////////////////////////////////////////////////////////////////////////////////////////////////////////könnte Probleme machen 
        }
       
        public void buy(Item o)
        {
            if (money >= o.value)
            {
                money -= o.value;
                add(o);
            }
            else
            {
                ///////////////////////////////////////////////////////////////////////////////message box fehlt noch!!!!!!!!!!!!
            }
        }
    }
}
