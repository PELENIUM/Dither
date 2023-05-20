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
            if (StyleBox.SelectedIndex == -1)
                StyleBox.SelectedIndex = 0;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files (*.jpg;*.png;*jpeg)|*.jpg;*.png;*jpeg";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = fileDialog.FileName;

                filePath = path;

                Image img = Image.FromFile(path);

                Width = Math.Max(723, img.Width * 2 + 46);
                Height = Math.Max(158, img.Height + 114);

                LoadButton.Location = new Point(11, Height - LoadButton.Height - 50);
                SaveButton.Location = new Point(107, Height - LoadButton.Height - 50);
                NoiseLevel.Location = new Point(205, Height - LoadButton.Height - 50);
                StyleBox.Location = new Point(580, Height - LoadButton.Height - 40);

                int noise = NoiseLevel.Value;
                Image editedImg = dither.Change(path, noise);

                Picture.Image = img;
                Picture.Height = img.Height;
                Picture.Width = img.Width;

                EditedPicture.Height = img.Height;
                EditedPicture.Width = img.Width;
                EditedPicture.Image = editedImg;
                EditedPicture.Location = new Point(12 + img.Width + 6, 12);
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

        private void Pixeled_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
