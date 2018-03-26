using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public enum objectype
        {
            WEAPON, ARMOR, POTION
        }
    public class Item
    {
        public int value;
        public int actionvalue;
        public string name;
        public objectype type;
        
        public Item(int value, int actionvalue, objectype t, string name)
        {
            this.actionvalue = actionvalue;
            this.value = value;
            this.type = t;
            this.name = name;
        }
    }
}
