using System.Drawing;

namespace StrangeEvo2
{
    abstract class WorldObjects
    {
        public Color Colour { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int size { get; set; }
        public int speed { get; set; }          
    }

    class Wall : WorldObjects
    {        
        public Wall(int x, int y, int s)
        {
            size = s;
            X = x;
            Y = y;            
            Colour = Color.FromName("Black");
            World.worldmatrix[X, Y] = 1;
        }
    } 
    class Skillet : WorldObjects
    {
        public Skillet(int x, int y, int s)
        {
            size = s;
            X = x;
            Y = y;
            Colour = Color.FromName("Gray");
            World.worldmatrix[X, Y] = 3;
        }
    }
}