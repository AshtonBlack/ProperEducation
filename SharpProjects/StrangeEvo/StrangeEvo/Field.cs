using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace StrangeEvo
{
    class Field
    {        
        int width;
        int height;

        public Field(Rectangle bounds)
        {
            width = bounds.Width;
            height = bounds.Height;
        }
        public Bitmap MakePicture(List<Point> positions, List<Color> colors)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            Bitmap pic = new Bitmap(width, height, format);
            Graphics gdi = Graphics.FromImage(pic);
            for (int row = 0; row < pic.Width; row++) // Indicates row number
            {
                for (int column = 0; column < pic.Height; column++) // Indicate column number
                {                 
                    pic.SetPixel(row, column, Color.FromArgb(255, 255, 255)); // Set the value to new pixel
                }
            }
            for(int i = 0; i < positions.Count; i++)
            {
                pic.SetPixel(positions[i].X, positions[i].Y, colors[i]);
            }
            gdi.Dispose();

            return pic;
        }
    }
}