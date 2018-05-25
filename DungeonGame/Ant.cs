using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc 
{
    class Ant
    {
        static DrawEnvironment.Field[,] board; //??wirklich static...
        private int stepCounter;
        public int firstDirection;
        public DrawEnvironment.Field position;
        private int direction;
        public bool alive;

        public Ant(DrawEnvironment.Field pos, int direction, int firstDir, int steps)
        {
            this.position = pos;
            this.direction = direction;
            this.firstDirection = firstDir;
            this.stepCounter = steps;
           
            if (!checkDir(direction))
            {
                this.alive = false;
            }
            else
            {
                this.alive = true;
            }
        }
        public static void setBoard(DrawEnvironment.Field [,] b) // auf Klassen ebene für alle ants 
        {
            board = b;
        }

        public List<Ant> crawl()
        {
            if (alive)
            {

                List<Ant> newAnts = new List<Ant>();

                if (checkDirRelative(0) && checkDirRelative(1) && checkDirRelative(3)) // wenn vor dir rechts links frei
                {
                    newAnts.Add(new Ant(position, turn(3), firstDirection, stepCounter));
                    newAnts.Add(new Ant(position, turn(1), firstDirection, stepCounter));
                }
                else if (checkDirRelative(0) && checkDirRelative(1)) // wenn vor dir und rechts frei
                {
                    newAnts.Add(new Ant(position, turn(1), firstDirection, stepCounter));
                }
                else if (checkDirRelative(0) && checkDirRelative(3))//wenn vor dir und links
                {
                    newAnts.Add(new Ant(position, turn(3), firstDirection, stepCounter));
                }
                else if(checkDirRelative(1) && checkDirRelative(3)) //rechts links
                {
                    direction = turn(1);
                    newAnts.Add(new Ant(position, turn(3), firstDirection, stepCounter));
                }
                else if (checkDirRelative(1)) // rechts
                {
                    direction = turn(1);
                }
                else if (checkDirRelative(3)) //links
                {
                    direction = turn(3);
                }
                else if(checkDirRelative(0)) //vorne
                {
                    direction = turn(0);
                }
                else
                {
                    alive = false;
                }

                if (stepCounter >= 10)
                {
                    alive = false;
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
                        throw new InvalidOperationException(" Ant with invalid crawling direction: " + direction);
                }
                stepCounter++;
                return newAnts;
            }
            else
            {
                throw new InvalidOperationException("dead ant can't crawl");
            }
        }

        bool checkDirRelative(int dir)
        {
            return checkDir((dir + direction) % 4);
        }
        bool checkDir(int dir)
        {
            switch (dir)
            {
                case 0: //oben
                    if (board[position.posx, position.posy - 1].type == DrawEnvironment.fieldtype.EMPTY)
                    {
                        return true;
                    }
                    break;
                case 1: // rechts
                    if (board[position.posx + 1, position.posy].type == DrawEnvironment.fieldtype.EMPTY)
                    {
                        return true;
                    }
                    break;
                case 2: // unten
                    if (board[position.posx, position.posy + 1].type == DrawEnvironment.fieldtype.EMPTY)
                    {
                        return true;
                    }
                    break;
                case 3: // links
                    if (board[position.posx - 1, position.posy].type == DrawEnvironment.fieldtype.EMPTY)
                    {
                        return true;
                    }
                    break;
                default:
                    throw new InvalidOperationException(" Ant with invalid digging direction: " + direction);
            }
            return false;
        }
        int turn(int times)
        {
            return (times + direction) % 4;
        }
    }
}
