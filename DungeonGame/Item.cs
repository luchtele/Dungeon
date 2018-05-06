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
        public static bool operator ==(Item a, Item b) => a.actionvalue == b.actionvalue && a.value == b.value && a.type == b.type && a.name == b.name;

        public static bool operator !=(Item a, Item b) => !(a == b);
    }
    
}
