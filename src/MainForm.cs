using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dither
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            StyleBox.SelectedIndex = 0;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files (*.jpg;*.png;*jpeg)|*.jpg;*.png;*jpeg";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = fileDialog.FileName;

                filePath = path;

                Image img = Image.FromFile(path);

                Width = img.Width + 40;
                Height = img.Height + 117;

                LoadButton.Location = new Point(12, 24 + img.Height);
                SaveButton.Location = new Point(108, 24 + img.Height);
                NoiseLevel.Location = new Point(206, 24 + img.Height);
                StyleBox.Location = new Point(581, 24 + img.Height);
                
                Image shownImg = dither.Change(path, 0);

                EditedPicture.Height = img.Height;
                EditedPicture.Width = img.Width;
                EditedPicture.Image = shownImg;
            }
        }

        private void NoiseLevel_Scroll(object sender, EventArgs e)
        {
            if (EditedPicture.Image != null && StyleBox.SelectedIndex != -1)
            {
                int noise = NoiseLevel.Value;
                Image shownImg = dither.Change(filePath, noise);
                EditedPicture.Image = shownImg;
            }
        }

        private void StyleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dither.SetPalette((DitherClass.Palette)StyleBox.SelectedIndex);
            if (EditedPicture.Image != null)
            {
                int noise = NoiseLevel.Value;
                Image shownImg = dither.Change(filePath, noise);
                EditedPicture.Image = shownImg;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (EditedPicture.Image != null)
            {
                Bitmap img = new Bitmap(EditedPicture.Image);
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "Image Files|*.png";
                saveFileDialog.Title = "Save your picture";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    img.Save(saveFileDialog.FileName);
                    img.Dispose();
                }
            }
        }
    }
}
