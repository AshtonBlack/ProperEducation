using System;
using System.Drawing;

namespace StrangeEvo2
{
    class Fiend
    {
        public Color Colour { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int size { get; set; }
        public int speed { get; set; }
        public int energy { get; set; }
        public int health { get; set; }

        Random r = new Random();

        public Fiend(int x, int y, int s, int v)
        {
            if (r.Next(5) == 0)
            {
                if (v == 0) v = 1;
                else v = 0;
            }
            health = 100;
            energy = 50;
            size = s;
            speed = v;
            X = x;
            Y = y;
            Colour = Color.FromName("Green");
            World.worldmatrix[X, Y] = 2;
        }

        public void Move(int nav)
        {
            int energycost = 20;
            /*
             *   1 2 3
             *   4 0 5
             *   6 7 8
             */
            if(speed > 0)
            {
                Point newLoc;
                switch (nav)
                {
                    case 1:
                        newLoc = new Point(X - 1, Y - 1);
                        break;
                    case 2:
                        newLoc = new Point(X, Y - 1);
                        break;
                    case 3:
                        newLoc = new Point(X + 1, Y - 1);
                        break;
                    case 4:
                        newLoc = new Point(X - 1, Y);
                        break;
                    case 5:
                        newLoc = new Point(X + 1, Y);
                        break;
                    case 6:
                        newLoc = new Point(X - 1, Y + 1);
                        break;
                    case 7:
                        newLoc = new Point(X, Y + 1);
                        break;
                    case 8:
                        newLoc = new Point(X + 1, Y + 1);
                        break;
                    default:
                        newLoc = new Point(X, Y);
                        break;
                }
                if (World.worldmatrix[newLoc.X, newLoc.Y] == 0)
                {
                    World.worldmatrix[X, Y] = 0;
                    X = newLoc.X;
                    Y = newLoc.Y;
                    World.worldmatrix[X, Y] = 2;
                    energy -= energycost;
                }
            }           
        }

        public void Regeneration()
        {
            int energycost = 2;
            int heal = 1;
            if(energy > 30 || health < 100)
            {
                energy -= energycost;
                health += heal;
            }
        }

        public bool Mitosis()
        {
            int energycost = 50;
            bool done = false;
            bool emptyspace = false;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int x1 = X - 1 + i;
                    int y1 = Y - 1 + j;
                    if (World.worldmatrix[x1, y1] == 0)
                    {
                        emptyspace = true;
                        break;
                    }                   
                }
            }

            if (emptyspace)
            {
                Point newLoc = new Point(X, Y);
                int nav;
                do
                {
                    nav = r.Next(1, 9);
                    switch (nav)
                    {
                        case 1:
                            newLoc = new Point(X - 1, Y - 1);
                            break;
                        case 2:
                            newLoc = new Point(X, Y - 1);
                            break;
                        case 3:
                            newLoc = new Point(X + 1, Y - 1);
                            break;
                        case 4:
                            newLoc = new Point(X - 1, Y);
                            break;
                        case 5:
                            newLoc = new Point(X + 1, Y);
                            break;
                        case 6:
                            newLoc = new Point(X - 1, Y + 1);
                            break;
                        case 7:
                            newLoc = new Point(X, Y + 1);
                            break;
                        case 8:
                            newLoc = new Point(X + 1, Y + 1);
                            break;
                    }

                    if (World.worldmatrix[newLoc.X, newLoc.Y] == 0)
                    {                        
                        Fiend newbie = new Fiend(newLoc.X, newLoc.Y, size, speed);
                        World.fiends.Add(newbie);
                        done = true;
                    }

                } while (!done);

                energy -= energycost;                
            }
            
            return done;
        }

        public void Die()
        {                        
            World.fiends.Remove(this);
            WorldObjects skillet = new Skillet(X, Y, size);
            World.worldObjects.Add(skillet);
            World.worldmatrix[X, Y] = 3;
        }

        public void Mind()
        {
            energy += 10;
            Regeneration();
            bool mitosisDone = false;
            if(energy >= 100)
            {
                mitosisDone = Mitosis();
            }
            if (energy <= 0)
            {
                Die();
            }
            else if(!mitosisDone)
            {
               // Move(1);
            }
        }
    }
}