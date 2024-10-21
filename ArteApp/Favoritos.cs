using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArteApp
{
    public partial class Favoritos : Form
    {
        public Favoritos()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void AddFavorite(Image image, string name)
        {
            if (IsImageAlreadyAdded(image))
            {
                MessageBox.Show("Esta imagen ya está en favoritos.", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = image;
                label1.Text = name;
            }
            else if (pictureBox2.Image == null)
            {
                pictureBox2.Image = image;
                label2.Text = name;
            }
            else if (pictureBox3.Image == null)
            {
                pictureBox3.Image = image;
                label3.Text = name;
            }
            else if (pictureBox4.Image == null)
            {
                pictureBox4.Image = image;
                label4.Text = name;
            }
            else if (pictureBox5.Image == null)
            {
                pictureBox5.Image = image;
                label5.Text = name;
            }
            else if (pictureBox6.Image == null)
            {
                pictureBox6.Image = image;
                label6.Text = name;
            }
            else if (pictureBox7.Image == null)
            {
                pictureBox7.Image = image;
                label7.Text = name;
            }
            else if (pictureBox8.Image == null)
            {
                pictureBox8.Image = image;
                label8.Text = name;
            }
            else if (pictureBox9.Image == null)
            {
                pictureBox9.Image = image;
                label9.Text = name;
            }
            else if (pictureBox10.Image == null)
            {
                pictureBox10.Image = image;
                label10.Text = name;
            }
            else if (pictureBox11.Image == null)
            {
                pictureBox11.Image = image;
                label11.Text = name;
            }
            else if (pictureBox12.Image == null)
            {
                pictureBox12.Image = image;
                label12.Text = name;
            }
            else
            {
                MessageBox.Show("No hay más espacio para favoritos.", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool IsImageAlreadyAdded(Image image)
        {
            Image[] existingImages = { pictureBox1.Image, pictureBox2.Image, pictureBox3.Image, pictureBox4.Image, pictureBox5.Image, pictureBox6.Image, pictureBox7.Image, pictureBox8.Image, pictureBox9.Image, pictureBox10.Image, pictureBox11.Image, pictureBox12.Image };

            foreach (var existingImage in existingImages)
            {
                if (existingImage != null && CompareImages(existingImage, image))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CompareImages(Image img1, Image img2)
        {
            byte[] img1Bytes = ImageToByteArray(img1);
            byte[] img2Bytes = ImageToByteArray(img2);
            return StructuralComparisons.StructuralEqualityComparer.Equals(img1Bytes, img2Bytes);
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    


    private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Favoritos_Load(object sender, EventArgs e)
        {

        }
    }
}
