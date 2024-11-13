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
    public partial class Vicent_Van_gogh : Form
    {
        private Favoritos favoritosForm;
        private Form paginaDeInicioOriginal;
        private Form activeForm = null;
        public Vicent_Van_gogh(Form paginaDeInicio, Favoritos formFavoritos)
        {
            InitializeComponent();
            this.favoritosForm = formFavoritos;
            this.paginaDeInicioOriginal = paginaDeInicio;
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void lblInicioSesion_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            paginaDeInicioOriginal.Show(); // Muestra el formulario original
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string artworkName = label5.Text;
            favoritosForm.AddFavorite(pictureBox2.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string artworkName = label16.Text;
            favoritosForm.AddFavorite(pictureBox5.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string artworkName = label2.Text;
            favoritosForm.AddFavorite(pictureBox1.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string artworkName = label16.Text;
            favoritosForm.AddFavorite(pictureBox5.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string artworkName = label9.Text;
            favoritosForm.AddFavorite(pictureBox3.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string artworkName = label18.Text;
            favoritosForm.AddFavorite(pictureBox6.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
