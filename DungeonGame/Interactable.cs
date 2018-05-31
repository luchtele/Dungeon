using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MapObjects
{
    public abstract class Interactable : DrawEnvironment.Drawable
    {
        public DrawEnvironment.Field position;
        public Inventory.Inventory inventory;
        protected Color color;

        public abstract Form interact(Interactable i);
        public abstract void draw();

        public Interactable(ref DrawEnvironment.Field field, Inventory.Inventory inventory, Color color)
        {
            this.position = field;
            this.inventory = inventory;
            this.color = color;
        }
    }

    public abstract class Creature : Interactable
    {
        protected string name;
        public int hp; // int level.....        
        public Dungeon.Model model; // protected

        public Creature(ref DrawEnvironment.Field field, Inventory.Inventory inventory, Color color, int hp, string name, Dungeon.Model m): base(ref field, inventory, color)
        {
            this.hp = hp;
            this.name = name;
            this.model = m;
        }

        public void move(int direction)
        {
            switch (direction)
            {
                case 0:
                    if (model.board[position.posx, position.posy-1].type != DrawEnvironment.fieldtype.WALL &&
                        model.board[position.posx, position.posy - 1].type != DrawEnvironment.fieldtype.INDESTRUCTABLE)
                    {
                        position = model.board[position.posx, position.posy -1];
                    }
                    break;
                case 1:
                    if (model.board[position.posx + 1, position.posy].type != DrawEnvironment.fieldtype.WALL &&
                        model.board[position.posx + 1, position.posy].type != DrawEnvironment.fieldtype.INDESTRUCTABLE)
                    {
                        position = model.board[position.posx +1, position.posy];
                    }
                    break;
                case 2:
                    if (model.board[position.posx, position.posy + 1].type != DrawEnvironment.fieldtype.WALL &&
                        model.board[position.posx, position.posy + 1].type != DrawEnvironment.fieldtype.INDESTRUCTABLE)
                    {
                        position = model.board[position.posx, position.posy + 1];
                    }
                    break;
                case 3:
                    if (model.board[position.posx - 1, position.posy].type != DrawEnvironment.fieldtype.WALL &&
                        model.board[position.posx - 1, position.posy].type != DrawEnvironment.fieldtype.INDESTRUCTABLE)
                    {
                        position = model.board[position.posx - 1, position.posy];
                    }
                    break;
                default:
                    throw new ArgumentException("only directions 0-3 are accepted");
            }
        }
    }    
}
