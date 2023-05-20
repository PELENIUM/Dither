using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Dither
{
    internal class DitherClass
    {
        private Image image;
        private Bitmap imageBitmap;
        private Bitmap img;

        private Palette palette = Palette.Pastel;

        Color[][] colors = new Color[6][];

        public DitherClass()
        {
            colors[0] = new Color[] {
                                      Color.FromArgb(0,0,0),
                                      Color.FromArgb(0, 0, 0),
                                      Color.FromArgb(128, 0, 0),
                                      Color.FromArgb(0, 128, 0),
                                      Color.FromArgb(128, 128, 0),
                                      Color.FromArgb(0, 0, 128),
                                      Color.FromArgb(128, 0, 128),
                                      Color.FromArgb(0, 128, 128),
                                      Color.FromArgb(192, 192, 192),
                                      Color.FromArgb(128, 128, 128),
                                      Color.FromArgb(255, 0, 0),
                                      Color.FromArgb(0, 255, 0),
                                      Color.FromArgb(255, 255, 0),
                                      Color.FromArgb(0, 0, 255),
                                      Color.FromArgb(255, 0, 255),
                                      Color.FromArgb(0, 255, 255),
                                      Color.FromArgb(255, 255, 255),
                                      Color.FromArgb(0, 0, 64),
                                      Color.FromArgb(0, 0, 192),
                                      Color.FromArgb(0, 64, 0),
                                      Color.FromArgb(0, 64, 128),
                                      Color.FromArgb(0, 128, 64),
                                      Color.FromArgb(0, 128, 192),
                                      Color.FromArgb(64, 0, 0),
                                      Color.FromArgb(64, 0, 128),
                                      Color.FromArgb(64, 64, 0),
                                      Color.FromArgb(64, 64, 192),
                                      Color.FromArgb(64, 128, 0),
                                      Color.FromArgb(64, 128, 128),
                                      Color.FromArgb(128, 0, 64),
                                      Color.FromArgb(128, 0, 192),
                                      Color.FromArgb(128, 64, 0),
                                      Color.FromArgb(128, 64, 128),
                                      Color.FromArgb(128, 128, 64),
                                      Color.FromArgb(128, 128, 192)
                                    };

            colors[1] = new Color[] {
                                      Color.FromArgb(0, 0, 0),
                                      Color.FromArgb(34, 32, 52),
                                      Color.FromArgb(69, 40, 60),
                                      Color.FromArgb(102, 57, 49),
                                      Color.FromArgb(143, 86, 59),
                                      Color.FromArgb(223, 113, 38),
                                      Color.FromArgb(217, 160, 102),
                                      Color.FromArgb(238, 195, 154),
                                      Color.FromArgb(251, 242, 54),
                                      Color.FromArgb(153, 229, 80),
                                      Color.FromArgb(106, 190, 48),
                                      Color.FromArgb(55, 148, 110),
                                      Color.FromArgb(75, 105, 47),
                                      Color.FromArgb(82, 75, 36),
                                      Color.FromArgb(50, 60, 57),
                                      Color.FromArgb(63, 63, 116),
                                      Color.FromArgb(48, 96, 130),
                                      Color.FromArgb(91, 110, 225),
                                      Color.FromArgb(99, 155, 255),
                                      Color.FromArgb(95, 205, 228),
                                      Color.FromArgb(203, 219, 252),
                                      Color.FromArgb(255, 255, 255)
                                    };

            colors[2] = new Color[] {
                                      Color.FromArgb(144, 12, 63),
                                      Color.FromArgb(244, 67, 54),
                                      Color.FromArgb(233, 30, 99),
                                      Color.FromArgb(156, 39, 176),
                                      Color.FromArgb(103, 58, 183),
                                      Color.FromArgb(63, 81, 181),
                                      Color.FromArgb(33, 150, 243),
                                      Color.FromArgb(3, 169, 244),
                                      Color.FromArgb(0, 188, 212),
                                      Color.FromArgb(0, 150, 136),
                                      Color.FromArgb(76, 175, 80),
                                      Color.FromArgb(139, 195, 74),
                                      Color.FromArgb(205, 220, 57),
                                      Color.FromArgb(255, 235, 59),
                                      Color.FromArgb(255, 193, 7),
                                      Color.FromArgb(255, 152, 0),
                                      Color.FromArgb(255, 87, 34),
                                      Color.FromArgb(121, 85, 72),
                                      Color.FromArgb(158, 158, 158),
                                      Color.FromArgb(96, 125, 139),
                                      Color.FromArgb(38, 50, 56),
                                      Color.FromArgb(0, 0, 0),
                                      Color.FromArgb(255, 255, 255),
                                      Color.FromArgb(236, 239, 241),
                                      Color.FromArgb(189, 189, 189),
                                      Color.FromArgb(117, 117, 117),
                                      Color.FromArgb(97, 97, 97),
                                      Color.FromArgb(66, 66, 66),
                                      Color.FromArgb(33, 33, 33),
                                      Color.FromArgb(25, 25, 25)
                                    };

            colors[3] = new Color[] {
                                      Color.FromArgb(255, 0, 0),
                                      Color.FromArgb(255, 128, 128),
                                      Color.FromArgb(255, 255, 0),
                                      Color.FromArgb(255, 255, 128),
                                      Color.FromArgb(0, 255, 0),
                                      Color.FromArgb(128, 255, 128),
                                      Color.FromArgb(0, 255, 255),
                                      Color.FromArgb(128, 255, 255),
                                      Color.FromArgb(0, 0, 255),
                                      Color.FromArgb(128, 128, 255),
                                      Color.FromArgb(255, 0, 255),
                                      Color.FromArgb(255, 128, 255),
                                      Color.FromArgb(128, 0, 0),
                                      Color.FromArgb(192, 0, 0),
                                      Color.FromArgb(64, 0, 0),
                                      Color.FromArgb(255, 64, 64),
                                      Color.FromArgb(192, 64, 64),
                                      Color.FromArgb(128, 64, 64),
                                      Color.FromArgb(64, 64, 64),
                                      Color.FromArgb(128, 128, 128),
                                      Color.FromArgb(192, 192, 192),
                                      Color.FromArgb(255, 255, 255),
                                      Color.FromArgb(0, 0, 0),
                                      Color.FromArgb(51, 51, 51),
                                      Color.FromArgb(102, 102, 102),
                                      Color.FromArgb(153, 153, 153),
                                      Color.FromArgb(204, 204, 204),
                                      Color.FromArgb(255, 255, 254),
                                      Color.FromArgb(255, 255, 253),
                                      Color.FromArgb(255, 255, 252),
                                      Color.FromArgb(255, 255, 251)
                                    };

            colors[4] = new Color[] {
                                      Color.FromArgb(0, 0, 0),
                                      Color.FromArgb(128, 0, 0),
                                      Color.FromArgb(0, 128, 0),
                                      Color.FromArgb(128, 128, 0),
                                      Color.FromArgb(0, 0, 128),
                                      Color.FromArgb(128, 0, 128),
                                      Color.FromArgb(0, 128, 128),
                                      Color.FromArgb(192, 192, 192),
                                      Color.FromArgb(128, 128, 128),
                                      Color.FromArgb(255, 0, 0),
                                      Color.FromArgb(0, 255, 0),
                                      Color.FromArgb(255, 255, 0),
                                      Color.FromArgb(0, 0, 255),
                                      Color.FromArgb(255, 0, 255),
                                      Color.FromArgb(0, 255, 255),
                                      Color.FromArgb(255, 255, 255),
                                      Color.FromArgb(255, 255, 254),
                                      Color.FromArgb(255, 255, 253),
                                      Color.FromArgb(255, 255, 252),
                                      Color.FromArgb(255, 255, 251),
                                      Color.FromArgb(255, 255, 250),
                                      Color.FromArgb(255, 255, 249),
                                      Color.FromArgb(255, 255, 248),
                                      Color.FromArgb(255, 255, 247),
                                      Color.FromArgb(255, 255, 246),
                                      Color.FromArgb(255, 255, 245),
                                      Color.FromArgb(255, 255, 244),
                                      Color.FromArgb(255, 255, 243),
                                      Color.FromArgb(255, 255, 242),
                                      Color.FromArgb(255, 255, 241),
                                      Color.FromArgb(255, 255, 240),
                                      Color.FromArgb(255, 255, 239)
                                    };

            colors[5] = new Color[] { 
                                      Color.FromArgb(0, 0, 0), 
                                      Color.FromArgb(255, 255, 255)
                                    };
        }

        public void SetPalette(Palette num)
        {
            palette = num;
        }

        private Color ClosestColor(int r, int g, int b)
        {
            Color color = new Color();

            double minDistance = 10000000000000000000;
            for (int i = 0; i < colors[(int)palette].Length; i++)
            {

                int r1 = colors[(int)palette][i].R;
                int g1 = colors[(int)palette][i].G;
                int b1 = colors[(int)palette][i].B;

                double distance = Math.Sqrt( Math.Pow((r - r1), 2) + Math.Pow((g - g1), 2) + Math.Pow((b - b1), 2) );

                if (distance < minDistance)
                {
                    minDistance = distance;
                    color = Color.FromArgb(r1, g1, b1);
                }
            }

            return color;
        }

        private void MakeDithered(float noise)
        {

            Random rand = new Random();
            for (int i = 0; i < imageBitmap.Height; i++)
            {
                for (int j = 0; j < imageBitmap.Width; j++)
                {
                    int n = rand.Next((int)(-100 * noise / 50), (int)(100 * noise / 50));

                    int[,] bayer = new int[2, 2] { 
                                                   { 0, 2 },
                                                   { 3, 1 } 
                                                  };

                    int r = imageBitmap.GetPixel(j, i).R + n + bayer[j % 2, i % 2];
                    int g = imageBitmap.GetPixel(j, i).G + n + bayer[j % 2, i % 2];
                    int b = imageBitmap.GetPixel(j, i).B + n + bayer[j % 2, i % 2];

                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));


                    Color newColor = ClosestColor(r, g, b);

                    img.SetPixel(j, i, newColor);
                }
            }
        }

        public Image Change(string path, float noise)
        {
            image = Image.FromFile(path);
            img = new Bitmap(image.Width, image.Height);
            imageBitmap = new Bitmap(image);

            MakeDithered(noise);

            image.Dispose();
            imageBitmap.Dispose();

            return img;
        }

        public enum Palette
        {
            Pastel,
            SoftYellow,
            WarmTones,
            AutumnShades,
            FluentPurple,
            BlackAndWhite
        }
    }
}
