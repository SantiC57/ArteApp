using System;
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
    public partial class PaginaDeInicio : Form
    {
        private Favoritos favoritosForm;


        public PaginaDeInicio(Favoritos formFavoritos)
        {
            InitializeComponent();
            this.favoritosForm = formFavoritos;
        }



        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }


        private void Button1_Click(object sender, EventArgs e)
        {
            string artworkName = label2.Text;
            favoritosForm.AddFavorite(pictureBox1.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string artworkName = label5.Text;
            favoritosForm.AddFavorite(pictureBox2.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string artworkName = label8.Text;
            favoritosForm.AddFavorite(pictureBox3.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string artworkName = label12.Text;
            favoritosForm.AddFavorite(pictureBox4.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string artworkName = label18.Text;
            favoritosForm.AddFavorite(pictureBox5.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string artworkName = label16.Text;
            favoritosForm.AddFavorite(pictureBox6.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

