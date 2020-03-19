using System.Drawing;

namespace StrangeEvo
{
    class Action
    {
        public void EatSun()
        {

        }

        public void Eat()
        {

        }

        public Point Move(Point p, int speed, int nav)
        {          
            int x = p.X;
            int y = p.Y;
            Point pos = p;
            Point movement;
            if (nav == 1 && (y - speed) > 0 )
            {       
                movement = new Point(x, (y - speed));
                if (Form1.vacancymap[movement.X, movement.Y])
                    pos = movement;
            }                
            if (nav == 2 && (y + speed) < Form1.pBSize.Height)
            {
                movement = new Point(x, (y + speed));
                if (Form1.vacancymap[movement.X, movement.Y])
                    pos = movement;
            }               
            if (nav == 3 && (x + speed) < Form1.pBSize.Width)
            {
                movement = new Point((x + speed), y);
                if (Form1.vacancymap[movement.X, movement.Y])
                    pos = movement;
            }                
            if (nav == 4 && (x - speed) > 0)
            {
                movement = new Point((x - speed), y);
                if (Form1.vacancymap[movement.X, movement.Y])
                    pos = movement;
            }

            return pos;
        }

        public void Die()
        {

        }
    }   
}