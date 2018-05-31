using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class Inventory
    {
        private int money;
        public int Money {
            get { return money; }
            set
            {
                this.money = value;
                OnMoneyChanged(EventArgs.Empty); //Event ist eingetreten
            }
        }
        public BindingList<Item> stuff;
        public BindingList<Item> equipment;
        private int length = 6;
        public event EventHandler moneyChanged;
        public Inventory(int m)
        {
            this.money = m;
            stuff = new BindingList<Item>();
            equipment = new BindingList<Item>();
        }
        public Inventory()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            this.money = rnd.Next(10,1000);
            stuff = new BindingList<Item>();
            equipment = new BindingList<Item>();
            Item m;
            for(int i = 0; i <= length; i++)
            {
                int o = rnd.Next(0, 5);
                m = new Item(o);
                stuff.Add(m);
                equip(m);
            }

        }
        protected virtual void OnMoneyChanged(EventArgs e) 
        {
            EventHandler handler = moneyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public bool equip(Item i)
        {
            Item temp = null;
            foreach(var item in stuff)
            {
                if(item == i)
                {
                    temp = item;
                    break;
                }
            }
            if (temp == null)
                return false;
            foreach(var item in equipment)
            {
                if (temp.type == item.type)
                    return false;
            }
            equipment.Add(temp);
            stuff.Remove(temp);
            return true;
        }

        public bool unequip(Item i)
        {
            Item temp = null;
            foreach(var item in equipment)
            {
                if(item == i)
                {
                    temp = item;
                    break;
                }
            }
            if (temp == null)
                return false;
            stuff.Add(temp);
            equipment.Remove(temp);
            return true;
        }

        public void equip(int i) // nachher aufräumen
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
        
        public bool give(Item i, MapObjects.Interactable destination)
        {
            if(destination.GetType() == typeof(MapObjects.Merchant))
            {
                destination.inventory.stuff.Add(i);
                Money += i.value;
                stuff.Remove(i);
                return true;
            }
            else if (destination.GetType() == typeof(MapObjects.Player))
            {
                if(destination.inventory.Money >= i.value)
                {
                    destination.inventory.stuff.Add(i);
                    destination.inventory.Money -= i.value;
                    stuff.Remove(i);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                destination.inventory.stuff.Add(i);
                stuff.Remove(i);
                return true;
            }
        }
/*
        public bool give(int index, MapObjects.Interactable destination) // @todo kein index sondern objekt
        {
            Item temp = stuff[index];
            if (destination.GetType() == typeof(MapObjects.Merchant))
            {
                destination.inventory.stuff.Add(temp);
                Money += temp.value;
                stuff.Remove(temp);
                return true;
            }
            else if (destination.GetType() == typeof(MapObjects.Player)) //@todo Truhe kein Geld
            {
                if(destination.inventory.Money >= temp.value)
                {
                    destination.inventory.stuff.Add(temp);
                    destination.inventory.Money -= temp.value;
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
        }*/
    }
}
