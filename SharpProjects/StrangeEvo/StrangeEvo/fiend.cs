using System;
using System.Drawing;

namespace StrangeEvo
{
    class Fiend
    {
        Random r = new Random();
        Action act = new Action(); 
        public bool Agressive { get; set; }
        public int hungry { get; set; }
        public int speed { get; set; }
        public Point pos { get; set; }
        public Color color { get; set; }
        public Fiend(Point position, bool aggr, int veloc, int energy)
        {
            if (r.Next(10) == 9)
            {
                Agressive = !aggr;
            }
            else
            {
                Agressive = aggr;
            }
            if (!Agressive)
            {
                color = Color.Green;
            }
            else
            {
                color = Color.Red;
            }

            speed = veloc;
            /* mode for speed
            int x = (veloc + r.Next(5) - 2);
            if(x < 0)
            {
                speed = 0;
            }
            else if (x > 10)
            {
                speed = 10;
            }
            else
            {
                speed = x;
            }
            */
            bool setpos = false;
            for(int i = 0; i < 9; i++)
            {
                if (setpos) break;
                switch (i)
                {
                    case 0:
                        if (Form1.vacancymap[position.X - 1, position.Y - 1])
                        {
                            pos = new Point(position.X - 1, position.Y - 1);
                            setpos = true;
                        }
                        break;
                    case 1:
                        if (Form1.vacancymap[position.X, position.Y - 1])
                        {
                            pos = new Point(position.X, position.Y - 1);
                            setpos = true;
                        }
                        break;
                    case 2:
                        if (Form1.vacancymap[position.X + 1, position.Y - 1])
                        {
                            pos = new Point(position.X + 1, position.Y - 1);
                            setpos = true;
                        }
                        break;
                    case 3:
                        if (Form1.vacancymap[position.X - 1, position.Y])
                        {
                            pos = new Point(position.X - 1, position.Y);
                            setpos = true;
                        }
                        break;
                    case 4:
                        if (Form1.vacancymap[position.X + 1, position.Y])
                        {
                            pos = new Point(position.X + 1, position.Y);
                            setpos = true;
                        }
                        break;
                    case 5:
                        if (Form1.vacancymap[position.X - 1, position.Y + 1])
                        {
                            pos = new Point(position.X - 1, position.Y + 1);
                            setpos = true;
                        }
                        break;
                    case 6:
                        if (Form1.vacancymap[position.X, position.Y + 1])
                        {
                            pos = new Point(position.X, position.Y + 1);
                            setpos = true;
                        }
                        break;
                    case 7:
                        if (Form1.vacancymap[position.X + 1, position.Y + 1])
                        {
                            pos = new Point(position.X + 1, position.Y + 1);
                            setpos = true;
                        }
                        break;
                    case 8:
                        pos = new Point(1000, 1000);
                        setpos = true;
                        break;
                }
            }
            
            hungry = 100 - energy;
        }

        public void Behavior()
        {
            hungry -= 2;
            int nav = r.Next(5);
            pos = act.Move(pos, speed, nav);
        }

        public void arrayBehavior()
        {
            /*  move      look        doSomething   end
             *  1 2 3     9  10 11    17 18 19      25
             *  4 0 5     12    13    20    21
             *  6 7 8     14 15 16    22 23 24
             */
            int[] actions = new int[]{ };

            /*
             *  0 - empty
             *  1 - wall
             *  2 - vegan
             *  3 - raptor
             *  4 - skilet
             

            for (int i = 0; i < actions.Length; i++)
            {
                switch (actions[i])
                {
                    case 0:
                }
            }
                /*
                 * 
                 * 
                 * 
                 * 
                 */
            }
    }
}
