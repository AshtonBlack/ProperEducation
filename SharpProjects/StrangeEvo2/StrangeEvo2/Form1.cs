using System;
using System.Drawing;
using System.Windows.Forms;

namespace StrangeEvo2
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        World world { get; set; }
        Map map { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Rectangle mapbounds = new Rectangle(235, 12, Convert.ToInt32(textBox1.Text) * (Convert.ToInt32(textBox3.Text)+1) + 1, Convert.ToInt32(textBox2.Text) * (Convert.ToInt32(textBox3.Text) + 1) + 1);
            pictureBox1.Bounds = mapbounds;
            world = new World(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            map = new Map(pictureBox1.Bounds, Convert.ToInt32(textBox3.Text), World.worldObjects, World.fiends);
            pictureBox1.Image = map.ShowWorld();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            world.Age();
            pictureBox1.Image = map.ShowWorld();
            map = new Map(pictureBox1.Bounds, Convert.ToInt32(textBox3.Text), World.worldObjects, World.fiends);            
        }
    }
}