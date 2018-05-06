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
            //@todo random Items generieren
            stuff = new List<Item>();
            equipment = new List<Item>();

        }

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

        public bool give(int index, MapObjects.Interactable destination)
        {
            Item temp = stuff[index];
            if (destination.GetType() == typeof(MapObjects.Merchant))
            {
                destination.inventory.stuff.Add(temp);
                money += temp.value;
                stuff.Remove(temp);
                return true;
            }
            else if (destination.GetType() == typeof(MapObjects.Player)) //@todo Truhe kein Geld
            {
                if(destination.inventory.money >= temp.value)
                {
                    destination.inventory.stuff.Add(temp);
                    destination.inventory.money -= temp.value;
                    stuff.Remove(temp);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                destination.inventory.stuff.Add(temp);
                stuff.Remove(temp);
                return true;
            }
        }
    }
}
