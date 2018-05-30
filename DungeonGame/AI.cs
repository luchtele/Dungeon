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
;

            if (board[monster.position.posx, monster.position.posy - 1].type == DrawEnvironment.fieldtype.EMPTY)
            {
                ants.Add(new Ant(board[monster.position.posx, monster.position.posy], 0, 0, 0)); // Ant nach oben
            }

            if (board[monster.position.posx + 1, monster.position.posy].type == DrawEnvironment.fieldtype.EMPTY)
            {
                ants.Add(new Ant(board[monster.position.posx, monster.position.posy], 1, 1, 0)); //Ant nach rechts
            }

            if (board[monster.position.posx, monster.position.posy + 1].type == DrawEnvironment.fieldtype.EMPTY)
            {
                ants.Add(new Ant(board[monster.position.posx, monster.position.posy], 2, 2, 0)); //Ant nach unten
            }
            
            if (board[monster.position.posx - 1, monster.position.posy].type == DrawEnvironment.fieldtype.EMPTY)
            {
                ants.Add(new Ant(board[monster.position.posx, monster.position.posy], 3, 3, 0)); //Ant nach links
            }
            
            while (ants.Count != 0)
            {
                List<Ant> newAnts= new List<Ant>();
                List<Ant> deadAnts = new List<Ant>();
                foreach(Ant ant in ants)
                {

                    if (!ant.alive)
                    {
                        deadAnts.Add(ant);
                        continue;
                    }

                    newAnts.AddRange(ant.crawl());

                    if (ant.position == player.position)
                    {
                        direction = ant.firstDirection;
                        return direction;
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

        public static void combat(MapObjects.Monster monster, MapObjects.Player player)
        {
            
        }
    }
}
