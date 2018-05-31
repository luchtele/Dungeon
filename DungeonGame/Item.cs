using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public enum objecttype
    {
        ARMOR, POTION, SWORD, BOW, BOMB
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
        public int range;
        public static int swordRange = 1;
        public static int bowRange = 5;
        public static int bombRange = 3;

        public Item(int value, int actionvalue, objecttype t, string name)
        {
            this.actionvalue = actionvalue;
            this.value = value;
            this.type = t;
            this.Name = name;
            if (type == objecttype.BOMB)
            {

            }
        }
 
        public Item(int o) //generiert random item
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode()); //damit seed random generiert wird-->nicht gleiche Zahlen bei erneutem aufruf props to stackoverflow
            string[] adjective;
            string[] sword;
            string[] bow;
            string[] armor;
            char[] sign = { ',' };
            string line = "";
            StreamReader swords = new StreamReader("../../res/sword.txt");// .. weil nicht in debugordner
            StreamReader adjectives = new StreamReader("../../res/adjective.txt");
            StreamReader bows = new StreamReader("../../res/bow.txt");
            StreamReader armors= new StreamReader("../../res/armor.txt");

            adjectives.Peek();
            line = adjectives.ReadLine();
            adjective = line.Split(sign);
            adjectives.Close();

            switch (o)
            {
                case 0:
                    this.type = objecttype.ARMOR;
                    this.actionvalue = rnd.Next(25, 100);
                    armors.Peek();
                    line = armors.ReadLine();
                    armor = line.Split(sign);
                    armors.Close();
                    if (actionvalue < 50)
                    {
                        this.Name = adjective[rnd.Next(0, adjective.Length)] + adjective[rnd.Next(0, adjective.Length)] + armor[rnd.Next(0, 3)];
                        this.value = 30;
                    }
                    else if (actionvalue < 75)
                    {
                        this.Name = adjective[rnd.Next(0, adjective.Length)] + adjective[rnd.Next(0, adjective.Length)] + armor[rnd.Next(4, 5)];
                        this.value = 70;
                    }
                    else
                    {
                        this.Name = adjective[rnd.Next(0, adjective.Length)] + adjective[rnd.Next(0, adjective.Length)] + armor[rnd.Next(6, 7)];
                        this.value = 120;
                    }
                    break;
                case 1:
                    this.type = objecttype.BOMB;
                    this.actionvalue = rnd.Next(5, 25);
                    this.Name = adjective[rnd.Next(0, adjective.Length)] + adjective[rnd.Next(0, adjective.Length)] + "bomb";
                    if (actionvalue < 10)
                    {
                        this.value = 5;
                    }
                    else if (actionvalue < 15)
                    {
                        this.value = 10;
                    }
                    else
                    {
                        this.value = 20;
                    }
                    break;
                case 2:
                    this.type = objecttype.BOW;
                    this.actionvalue = rnd.Next(5, 35);
                    bows.Peek();
                    line = bows.ReadLine();
                    bow = line.Split(sign);
                    bows.Close();
                    if (actionvalue < 15)
                    {
                        this.Name = adjective[rnd.Next(0, adjective.Length)] + adjective[rnd.Next(0, adjective.Length)] + bow[rnd.Next(0, 1)];
                        this.value = 15;
                    }
                    else if (actionvalue < 25)
                    {
                        this.Name = adjective[rnd.Next(0, adjective.Length)] + adjective[rnd.Next(0, adjective.Length)] + bow[rnd.Next(2, 3)];
                        this.value = 30;
                    }
                    else
                    {
                        this.Name = adjective[rnd.Next(0, adjective.Length)] + adjective[rnd.Next(0, adjective.Length)] + bow[rnd.Next(4, 5)];
                        this.value = 50;
                    }
                    break;
                case 3:
                    this.type = objecttype.POTION;
                    this.actionvalue = rnd.Next(10, 50);
                    this.Name = adjective[rnd.Next(0, adjective.Length)] + adjective[rnd.Next(0, adjective.Length)] + "potion";
                    if (actionvalue < 25)
                    {
                        this.value = 10;
                    }
                    else if (actionvalue < 40)
                    {
                        this.value = 30;
                    }
                    else
                    {
                        this.value = 50;
                    }
                    break;
                case 4:
                    this.type = objecttype.SWORD;
                    this.actionvalue = rnd.Next(10, 40);
                    swords.Peek();
                    line = swords.ReadLine();
                    sword = line.Split(sign);
                    swords.Close();
                    if (actionvalue < 20)
                    {
                        this.Name = adjective[rnd.Next(0, adjective.Length)] + adjective[rnd.Next(0, adjective.Length)] + sword[rnd.Next(0, 5)];
                        this.value = 60;
                    }
                    else if (actionvalue < 30)
                    {
                        this.Name = adjective[rnd.Next(0, adjective.Length)] + adjective[rnd.Next(0, adjective.Length)] + sword[rnd.Next(6, 11)];
                        this.value = 80;
                    }
                    else
                    {
                        this.Name = adjective[rnd.Next(0, adjective.Length)] + adjective[rnd.Next(0, adjective.Length)] + sword[rnd.Next(12, 17)];
                        this.value = 120;
                    }
                    break;
            }

        }
        public comparison compareTo(Item i)
        {
            if (type != i.type)
                return comparison.UNCOMPARABLE;
            if (actionvalue <= i.actionvalue)
                return comparison.WORSE;
            return comparison.BETTER;
        }

        public bool use(MapObjects.Creature recipient, int distance)
        {
            switch (type)
            {
                case objecttype.SWORD:
                    if(distance == 1)// swordRange)
                    {
                        recipient.hp -= actionvalue;
                        return true;
                    }
                    break;
                case objecttype.BOW:
                    if(distance == bowRange)
                    {
                        recipient.hp -= actionvalue;
                        return true;
                    }
                    break;
                case objecttype.BOMB:               //@todo range damage ??
                    if (distance == bombRange)
                    {
                        recipient.hp -= actionvalue;
                        return true;
                    }
                    break;
                case objecttype.POTION:
                    recipient.hp += actionvalue;
                    return true;
                case objecttype.ARMOR:
                    recipient.hp += actionvalue;
                    return true;
            }
            return false;
        }
    }
    
}
