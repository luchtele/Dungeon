using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    class MapMole
    {
        static DrawEnvironment.Field[,] board;
        static Random rnd;

        public static int maxttl = 10;
        public static int maxProb = 20;
        const int dirChangePrb = 25;

        public int direction;
        public DrawEnvironment.Field position;
        int moleSpawnProb;


        int ttl;                        //time to live
        public bool alive;

        public MapMole(DrawEnvironment.Field pos, int dir, int ttl, int moleSpawnProb)
        {
            this.position = pos;
            this.direction = dir;
            this.ttl = ttl;
            this.moleSpawnProb = moleSpawnProb;
            alive = true;
        }

        public static void setBoard(DrawEnvironment.Field [,] b)
        {
            board = b;
            rnd = new Random();
        }

        bool checkDir(int dir)
        {
            switch (dir)
            {
                case 0: //oben
                    if (board[position.posx, position.posy - 1].type == DrawEnvironment.fieldtype.WALL)
                    {
                        return true;
                    }
                    break;
                case 1: // rechts
                    if (board[position.posx + 1, position.posy].type == DrawEnvironment.fieldtype.WALL)
                    {
                        return true;
                    }
                    break;
                case 2: // unten
                    if (board[position.posx, position.posy + 1].type == DrawEnvironment.fieldtype.WALL)
                    {
                        return true;
                    }
                    break;
                case 3: // links
                    if (board[position.posx - 1, position.posy].type == DrawEnvironment.fieldtype.WALL)
                    {
                        return true;
                    }
                    break;
                default:
                    throw new InvalidOperationException(" mole with invalid digging direction: " + direction);
            }
            return false;
        }

        int turn(int times)
        {
            int ret = (direction + times) % 4;
            if(ret < 0)
            {
                ret += 4;
            }
            return ret;
        }

        bool changeDir()
        {
            int left = turn(-1);
            int right = turn(1);
            
            if(checkDir(left) && checkDir(right)) // Beide frei
            {
                int diceroll = rnd.Next(1, 100);
                if (diceroll > 50) // 50/50 left/right 
                {
                    direction = turn(1);
                }
                else
                {
                    direction = turn(-1);
                }
            }
            else if (checkDir(left)) // Nur links frei
            {
                direction = turn(-1);
            }
            else if(checkDir(right))
            {
                direction = turn(1);
            }
            else
            {
                return false;
            }
            return true;
        }

        public MapMole dig()
        {
            if (!alive)
            {
                throw new InvalidOperationException("RIP mole");
            }
            position.type = DrawEnvironment.fieldtype.EMPTY;
            if(!checkDir(direction) && !changeDir())
            {
                alive = false;
                return null;
            }
            switch (direction)
            {
                case 0: 
                    position = board[position.posx, position.posy - 1];
                    break;
                case 1:
                    position = board[position.posx + 1, position.posy];
                    break;
                case 2:
                    position = board[position.posx, position.posy + 1];
                    break;
                case 3:
                    position = board[position.posx - 1, position.posy];
                    break;
                default:
                    throw new InvalidOperationException(" mole with invalid digging direction: " + direction);
            }
            //position.type = DrawEnvironment.fieldtype.EMPTY;

            if (--ttl <= 0) // RIP mole
            {
                alive = false;
                return null;
            }
            int diceroll = rnd.Next(1, 100);
            if(diceroll <= dirChangePrb)
            {
                changeDir();
            }
            if (diceroll <= moleSpawnProb)
            {
                int spawn = rnd.Next(0, 50);
                return new MapMole(position, diceroll % 4, diceroll % maxttl + 1, spawn); //+1 für Totgeburten
            }
            return null;
        }
    }
}
