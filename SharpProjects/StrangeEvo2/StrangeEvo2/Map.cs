using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace StrangeEvo2
{
    class Map
    {
        int width { get; set; }
        int height { get; set; }
        int cell { get; set; }
        List<WorldObjects> items { get; set; }
        List<Fiend> animals { get; set; }

        public Map(Rectangle rect, int cellSize, List<WorldObjects> worldObjects, List<Fiend> fiends)
        {
            width = rect.Width;
            height = rect.Height;
            cell = cellSize;
            items = worldObjects;
            animals = fiends;
        }

        public Rectangle MakeVisuality(WorldObjects something)
        {
            int x = something.X;
            int y = something.Y;
            int size = something.size;
            Rectangle rect = new Rectangle(x * size + x * 1 + 1, y * size + y * 1 + 1, size, size);
            return rect;
        }

        public Rectangle MakeVisuality(Fiend some)
        {
            int x = some.X;
            int y = some.Y;
            int size = some.size;
            Rectangle rect = new Rectangle(x * size + x * 1 + 1, y * size + y * 1 + 1, size, size);
            return rect;
        }

        public Bitmap ShowWorld()
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            Bitmap pic = new Bitmap(width, height, format);
            Graphics gdi = Graphics.FromImage(pic);
            for (int row = 0; row < pic.Width; row++) // Indicates row number
            {
                for (int column = 0; column < pic.Height; column++) // Indicate column number
                {
                    if (row % (cell +1) == 0 || column % (cell + 1) == 0)
                    {
                        pic.SetPixel(row, column, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        pic.SetPixel(row, column, Color.FromArgb(255, 255, 255));
                    }                    
                }
            }

            foreach (WorldObjects item in items)
            {
                Rectangle rect = MakeVisuality(item);
                for (int i = 0; i < rect.Width; i++)
                {
                    for (int j = 0; j < rect.Height; j++)
                    {
                        pic.SetPixel(rect.X + i, rect.Y + j, item.Colour);
                    }
                }  
            }

            foreach (Fiend animal in animals)
            {
                Rectangle rect = MakeVisuality(animal);
                for (int i = 0; i < rect.Width; i++)
                {
                    for (int j = 0; j < rect.Height; j++)
                    {
                        pic.SetPixel(rect.X + i, rect.Y + j, animal.Colour);
                    }
                }
            }

            gdi.Dispose();
            return pic;
        }
    }
}