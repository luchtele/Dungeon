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
        View.MainWindow form;
        public Field [,] board;
        int width;
        int height;
        public MapObjects.Player player;

        public Model(View.MainWindow f, int width, int height)
        {
            this.form = f;
            board = new Field[width, height];
            this.width = width;
            this.height = height;
            mapgen();
            player = new MapObjects.Player(100, board[1, height / 2], this);
            player.inventory.equipment.Add(new Inventory.Item(10, 20, Inventory.objectype.WEAPON, "Timmie das Schaefchen"));
            player.inventory.stuff.Add(new Inventory.Item(10, 20, Inventory.objectype.POTION, "Paulchen das Ferkel"));
            player.inventory.equipment.Add(new Inventory.Item(10, 20, Inventory.objectype.WEAPON, "Peter das Schaefchen"));
            player.inventory.stuff.Add(new Inventory.Item(10, 20, Inventory.objectype.ARMOR, "Eduard das Ferkel"));
        }

        public void mapgen()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if ((i == 0) || (i == width-1) || (j == 0) || (j == height-1))
                    {
                        board[i, j] = new Field(i, j, form, fieldtype.INDESTRUCTABLE);
                    }
                    else
                    {
                        board[i, j] = new Field(i, j, form, fieldtype.WALL);
                    }
                    
                }
                    
            }

            int maxMole = 100;
            int minMole = 2;
            MapMole.setBoard(board);
            List<MapMole> mapMoles = new List<MapMole>();
            List<MapMole> newMoles = new List<MapMole>();
            List<MapMole> deadMoles = new List<MapMole>();
            mapMoles.Add(new MapMole(board[1, height / 2], 1, MapMole.maxttl, 10));

            int counter = 0;
            while (mapMoles.Count() > 0 && counter++ < 100)
            {
                foreach (MapMole m in mapMoles)
                {
                    if (m.alive)
                    {
                        MapMole manfred = m.dig();
                        if (manfred != null)
                        {
                            newMoles.Add(manfred);
                        }
                        m.position.draw();
                    }
                    else
                    {
                        deadMoles.Add(m);
                    }

                }

                if(mapMoles.Count < minMole)
                {
                    foreach (MapMole m in mapMoles)
                    {
                        newMoles.Add(new MapMole(m.position, m.direction, MapMole.maxttl, MapMole.maxProb / 2));
                    }
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
            board[0, height / 2].type = fieldtype.ENTRANCE;

        }
    }
}
