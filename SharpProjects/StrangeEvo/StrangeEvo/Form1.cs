using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace StrangeEvo
{
    public partial class Form1 : Form
    {
        public static int x = 0;
        public static int y = 0;
        public static Point pBLoc = new Point(x + 30, y + 30);
        public static Size pBSize = new Size(400, 200);
        public static bool[,] vacancymap = new bool[pBSize.Width, pBSize.Height];

        public Form1()
        {
            InitializeComponent();
            
            for(int i = 0; i < pBSize.Width; i++)
            {
                for(int j = 0; j < pBSize.Height; j++)
                {
                    vacancymap[i, j] = true;
                }
            }
            
            Point loc = new Point(x, y);
            Location = loc;
            ClientSize = new Size(Screen.GetBounds(loc).Width, Screen.GetBounds(loc).Height);            
            
            pictureBox1.Location = pBLoc;
            pictureBox1.Size = pBSize;

            Timer t = new Timer();
            t.Interval = 250;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        private List<Fiend> fiends = new List<Fiend>();
        static Field field;
        private List<Fiend> newfiends = new List<Fiend>(); 
        int population = 0;

        public void Form1_Load(object sender, EventArgs e)
        {
            Point startPoint = new Point(100, 100);            
            Fiend first = new Fiend(startPoint, false, 1, 50);
            fiends.Add(first);
            field = new Field(pictureBox1.Bounds);
        }

        public void t_Tick(object sender, EventArgs e)
        {
            List<Point> position = new List<Point>();
            List<Color> color = new List<Color>();
            foreach (Fiend animal in fiends)
            {
                if(animal.hungry < 1 && population < 500)
                {
                    animal.hungry = 50;
                    Fiend little = new Fiend(animal.pos, animal.Agressive, animal.speed, 50);
                    if(little.pos.X != 1000)
                    {
                        vacancymap[little.pos.X, little.pos.Y] = false;
                        newfiends.Add(little);
                        population++;
                    }                                       
                }
                else
                {
                    vacancymap[animal.pos.X, animal.pos.Y] = true;
                    animal.Behavior(); 
                    vacancymap[animal.pos.X, animal.pos.Y] = false;
                }
                position.Add(animal.pos);
                color.Add(animal.color);
            }
            foreach (Fiend animal in newfiends)
            {
                fiends.Add(animal);                            
            }
            try
            {
                pictureBox1.Image.Dispose();
            }
            catch { }
            
            pictureBox1.Image = field.MakePicture(position, color);
        }
    }
}