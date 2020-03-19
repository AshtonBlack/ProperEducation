using System;
using System.Collections.Generic;

namespace StrangeEvo2
{
    class World
    {
        int width { get; set; }
        int height { get; set; }
        int cell { get; set; }
        public static List<WorldObjects> worldObjects { get; set; }
        public static List<Fiend> fiends { get; set; }
        public static int[,] worldmatrix { get; set; }
        /*
         * 0 - empty
         * 1 - wall
         * 2 - fiend
         * 3 - skillet
         */        
        public World(int x, int y, int o)
        {
            width = x;
            height = y;
            cell = o;
            worldObjects = new List<WorldObjects>();
            fiends = new List<Fiend>();
            worldmatrix = new int[width, height];
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    worldmatrix[i, j] = 0; 
                }
            }

            for(int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || j == 0 || i == width - 1 || j == height - 1)
                    {
                        WorldObjects item = new Wall(i, j, cell);
                        worldObjects.Add(item); 
                    }
                }
            }
            Fiend theFirst = new Fiend(20, 20, cell, 0);
            fiends.Add(theFirst);
        }

        public void Age()
        {
            Fiend[] fiend = new Fiend[fiends.Count];
            fiends.CopyTo(fiend);
            foreach (Fiend some in fiend)
            {
                some.Mind();
            }
        }
    }
}