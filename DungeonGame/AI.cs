using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    public static class AI
    {
        public static int randomDirection()
        {
            int direction;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            direction = rnd.Next(0, 3);
            return direction;
        }
        public static int follow(MapObjects.Player player, MapObjects.Monster monster, DrawEnvironment.Field [,] board)
        {
            int direction = -1; //sth dsnt work->invalid direction
            bool found = false;

            Ant.setBoard(board);
            List<Ant> ants = new List<Ant>();
            List<Ant> newAnts= new List<Ant>();
            List<Ant> deadAnts = new List<Ant>();

            ants.Add(new Ant(board[player.position.posx, player.position.posy], 0, 0, 0)); // Ant nach oben
            ants.Add(new Ant(board[player.position.posx, player.position.posy], 1, 1, 0)); //Ant nach rechts
            ants.Add(new Ant(board[player.position.posx, player.position.posy], 2, 2, 0)); //Ant nach unten
            ants.Add(new Ant(board[player.position.posx, player.position.posy], 3, 3, 0)); //Ant nach links

            while (!found)
            {
                foreach(Ant ant in ants)
                {
                    if (ant.position == player.position)
                    {
                        direction = ant.firstDirection;
                        found = true;
                    }
                    if (!ant.alive)
                    {
                        deadAnts.Add(ant);
                    }
                    else
                    {
                        newAnts.AddRange(ant.crawl());
                    }
                }
                foreach(Ant a in deadAnts)
                {
                    ants.Remove(a);
                }
                ants.AddRange(newAnts);
            }

            return direction;
        }
    }
}
