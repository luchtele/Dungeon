namespace Inventory
{
    public enum objecttype
    {
        WEAPON, ARMOR, POTION
    }

    public enum comparison
    {
        BETTER, WORSE, UNCOMPARABLE
    }

    public class Item
    {
        public int value;
        public int actionvalue;
        public string Name { get; set; }
        public objecttype type;
        
        public Item(int value, int actionvalue, objecttype t, string name)
        {
            this.actionvalue = actionvalue;
            this.value = value;
            this.type = t;
            this.Name = name;
        }

        public comparison compareTo(Item i)
        {
            if (type != i.type)
                return comparison.UNCOMPARABLE;
            if (actionvalue <= i.actionvalue)
                return comparison.WORSE;
            return comparison.BETTER;
        }
    }
    
}
