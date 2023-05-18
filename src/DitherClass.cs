using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dither
{
    internal class DitherClass
    {
        private Image image;
        private Bitmap img;

        private Palette palette = Palette.Pastel;

        Color[][] colors = new Color[6][];

        public DitherClass()
        {
            colors[0] = new Color[] { 
                                      Color.FromArgb(12, 33, 88),
                                      Color.FromArgb(39, 77, 116),
                                      Color.FromArgb(112, 137, 144),
                                      Color.FromArgb(197, 105, 64),
                                      Color.FromArgb(213, 208, 202)
                                    };

            colors[1] = new Color[] {
                                      Color.FromArgb(43, 55, 65),
                                      Color.FromArgb(39, 77, 116),
                                      Color.FromArgb(113, 131, 140),
                                      Color.FromArgb(148, 170, 178),
                                      Color.FromArgb(183, 209, 216)
                                    };

            colors[2] = new Color[] {
                                      Color.FromArgb(139, 69, 19),
                                      Color.FromArgb(255, 160, 122),
                                      Color.FromArgb(255, 182, 193),
                                      Color.FromArgb(255, 99, 71),
                                      Color.FromArgb(255, 255, 153)
                                    };

            colors[3] = new Color[] {
                                      Color.FromArgb(99, 72, 63),
                                      Color.FromArgb(132, 99, 87),
                                      Color.FromArgb(165, 126, 112),
                                      Color.FromArgb(198, 153, 137),
                                      Color.FromArgb(231, 180, 162)
                                    };

            colors[4] = new Color[] {
                                      Color.FromArgb(100, 70, 108),
                                      Color.FromArgb(130, 94, 143),
                                      Color.FromArgb(160, 118, 178),
                                      Color.FromArgb(190, 142, 213),
                                      Color.FromArgb(220, 166, 248)
                                    };

            colors[5] = new Color[] { Color.FromArgb(0, 0, 0), 
                                      Color.FromArgb(255, 255, 255)
                                    };
        }

        /*
         SoftBlue:

            rgb(250, 218, 221)
            rgb(254, 255, 207)
            rgb(204, 228, 247)
            rgb(196, 246, 195)
            rgb(224, 195, 252)

         
         WarmTones:

            rgb(255, 160, 122)
            rgb(255, 255, 153)
            rgb(255, 182, 193)
            rgb(255, 99, 71)
            rgb(139, 69, 19)
 
         
         AutumnShades:

            rgb(128, 0, 0)
            rgb(255, 194, 14)
            rgb(204, 119, 34)
            rgb(85, 107, 47)
            rgb(210, 105, 30)

        
         SeaTones:

            rgb(135, 206, 235)
            rgb(0, 0, 128)
            rgb(64, 224, 208)
            rgb(75, 0, 130)
            rgb(46, 139, 87)
         */

        public void SetPalette(Palette num)
        {
            palette = num;
        }

        private Color ChooseColor(double c)
        {
            Color result = new Color();

            float n = 256 / colors[(int)palette].Length;

            for (int i = colors[(int)palette].Length; i >= 0; i--)
            {
                if (c > n * i)
                {
                    result = colors[(int)palette][i];
                    goto next;
                }
            }

            result = colors[(int)palette][0];

        next:
            return result;
        }

        private void MakeDithered(float noise)
        {
            Random rand = new Random();

            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    int r = 0;
                    int g = 0;
                    int b = 0;

                    r = img.GetPixel(j, i).R;
                    g = img.GetPixel(j, i).G;
                    b = img.GetPixel(j, i).B;

                    double c = 0.2989 * r + 0.5870 * g + 0.1140 * b + rand.Next((int) (-128 * noise / 10), (int)(128 * noise / 10));

                    c = c > 127 ? 255 : 0;

                    img.SetPixel(j, i, Color.FromArgb((int)c, (int)c, (int)c));
                }
            }

            for (int i = 0; i < img.Height / 2; i++)
            {
                for (int j = 0; j < img.Width / 2; j++)
                {
                    int r = 0;
                    int g = 0;
                    int b = 0;

                    for (int i1 = i * 2; i1 < i * 2 + 2; i1++)
                    {
                        for (int j1 = j * 2; j1 < j * 2 + 2; j1++)
                        {
                            r += img.GetPixel(j1, i1).R;
                            g += img.GetPixel(j1, i1).G;
                            b += img.GetPixel(j1, i1).B;
                        }
                    }

                    r /= 4;
                    g /= 4;
                    b /= 4;

                    double c = 0.2989 * r + 0.5870 * g + 0.1140 * b;

                    c = Math.Max(0, Math.Min(255, c));

                    Graphics gr = Graphics.FromImage(img);

                    Rectangle rect = new Rectangle(j * 2, i * 2, 2, 2);

                    SolidBrush brush = new SolidBrush(ChooseColor(c));

                    gr.FillRectangle(brush, rect);
                }
            }
        }

        public Image Change(string path, float noise)
        {
            image = Image.FromFile(path);
            img = new Bitmap(image);

            MakeDithered(noise);

            image.Dispose();

            return img;
        }

        public enum Palette
        {
            Pastel,
            SoftBlue,
            WarmTones,
            AutumnShades,
            FluentPurple,
            BlackAndWhite
        }
    }
}
