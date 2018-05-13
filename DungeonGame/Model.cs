using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawEnvironment;

namespace Dungeon
{
    public class Model
    {
        System.Windows.Forms.Panel canvas;
        public Field [,] board;
        public int Width { get; set; }
        public int Height { get; set; }
        public MapObjects.Player player;

        public Model(System.Windows.Forms.Panel canvas, int width, int height)
        {
            this.canvas = canvas;
            board = new Field[width, height];
            this.Width = width;
            this.Height = height;
            Field.adaptSize(Width, Height, canvas);
            mapgen();
            player = new MapObjects.Player(ref board[1, height / 2],100, this);
            player.inventory.equipment.Add(new Inventory.Item(10, 20, Inventory.objecttype.WEAPON, "Timmie das Schaefchen"));
            player.inventory.stuff.Add(new Inventory.Item(10, 20, Inventory.objecttype.POTION, "Paulchen das Ferkel"));
            player.inventory.equipment.Add(new Inventory.Item(10, 20, Inventory.objecttype.WEAPON, "Peter das Schaefchen"));
            player.inventory.stuff.Add(new Inventory.Item(10, 20, Inventory.objecttype.ARMOR, "Eduard das Ferkel"));
        }

        public void drawMap()
        {
            canvas.Refresh();
            foreach (Field f in board)
            {
                f.draw();
            }
        }

        public void redrawAll()
        {
            Field.adaptSize(Width, Height, canvas);
            drawMap();
            player.draw();//Todo: alle mapobjects zeichnen
        }

        public void mapgen()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if ((i == 0) || (i == Width-1) || (j == 0) || (j == Height-1))
                    {
                        board[i, j] = new Field(i, j, canvas, fieldtype.INDESTRUCTABLE);
                    }
                    else
                    {
                        board[i, j] = new Field(i, j, canvas, fieldtype.WALL);
                    }
                    
                }
                    
            }

            int maxMole = 100;
            int minMole = 4;
            MapMole.setBoard(board);
            List<MapMole> mapMoles = new List<MapMole>();
            List<MapMole> newMoles = new List<MapMole>();
            List<MapMole> deadMoles = new List<MapMole>();
            mapMoles.Add(new MapMole(board[1, Height / 2], 1, MapMole.maxttl, 10));

            bool exit = false;

            while (!exit)
            {
                foreach (MapMole m in mapMoles)
                {
                    if (m.alive)
                    {
                        MapMole maybeNewMole = m.dig();
                        if (maybeNewMole != null)
                        {
                            newMoles.Add(maybeNewMole);
                        }                                              
                    }
                    else
                    {
                        deadMoles.Add(m);
                    }

                }
                for(int i = 0; i < Height; i++)
                {
                    if (board[Width-2,i].type == fieldtype.EMPTY)
                    {
                        exit = true;
                        board[Width-2,i].type = fieldtype.EXIT;
                    }
                }

                if (mapMoles.Count < minMole) //Notmoles
                {
                    Field maxField = board[0, 0];
                    foreach (Field f in board)
                    {
                        if ((f.type == fieldtype.EMPTY) && (f.posx > maxField.posx))
                        {
                            maxField = f;
                        }
                    }
                    newMoles.Add(new MapMole(maxField, 1, MapMole.maxttl, MapMole.maxProb / 2)); // läuft nach rechts
                    newMoles.Add(new MapMole(maxField, 0, MapMole.maxttl, MapMole.maxProb / 2)); // läuft nach oben 
                    newMoles.Add(new MapMole(maxField, 2, MapMole.maxttl, MapMole.maxProb / 2)); // läuft nach unten
                }

                foreach (MapMole m in deadMoles)
                {
                    mapMoles.Remove(m);
                }

                if(mapMoles.Count < maxMole)
                {
                    mapMoles.AddRange(newMoles);
                }

                newMoles.Clear();
                deadMoles.Clear();
            }
            board[1, Height / 2].type = fieldtype.ENTRANCE;

        }
    }
}