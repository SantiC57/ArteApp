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
    public partial class PaginaDeInicio3 : Form
    {
        private Favoritos favoritosForm;
        private Form activeForm = null;
        public PaginaDeInicio3(Favoritos formFavoritos)
        {
            InitializeComponent();
            this.favoritosForm = formFavoritos;
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

            private void PaginaDeInicio3_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            PaginaDeInicio paginaDeInicio = new PaginaDeInicio(favoritosForm); 
            OpenChildForm(paginaDeInicio);
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string artworkName = label2.Text;
            int indiceImagenSeleccionada = 12;
            favoritosForm.AddFavorite(pictureBox1.Image, artworkName,indiceImagenSeleccionada);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string artworkName = label5.Text;
            int indiceImagenSeleccionada = 13;
            favoritosForm.AddFavorite(pictureBox2.Image, artworkName, indiceImagenSeleccionada);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string artworkName = label8.Text;
            int indiceImagenSeleccionada = 14;
            favoritosForm.AddFavorite(pictureBox3.Image, artworkName,indiceImagenSeleccionada);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string artworkName = label12.Text;
            int indiceImagenSeleccionada = 15;
            favoritosForm.AddFavorite(pictureBox4.Image, artworkName,indiceImagenSeleccionada);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string artworkName = label18.Text;
            int indiceImagenSeleccionada = 16;
            favoritosForm.AddFavorite(pictureBox6.Image, artworkName,indiceImagenSeleccionada);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string artworkName = label16.Text;
            int indiceImagenSeleccionada = 17;
            favoritosForm.AddFavorite(pictureBox5.Image, artworkName,indiceImagenSeleccionada);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PaginaDeInicio2 paginaDeInicio2 = new PaginaDeInicio2(favoritosForm); 
            OpenChildForm(paginaDeInicio2);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            LeonardoDaVinci leonardoForm = new LeonardoDaVinci(this, favoritosForm);
            OpenChildForm(leonardoForm);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Vicent_Van_gogh vanGoghForm = new Vicent_Van_gogh(this, favoritosForm);
            OpenChildForm(vanGoghForm);
        }

     

        private void button14_Click_1(object sender, EventArgs e)
        {
            Edvard_Munch munchForm = new Edvard_Munch(this, favoritosForm);
            OpenChildForm(munchForm);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Sandro_Botticelli botticelliForm = new Sandro_Botticelli(this, favoritosForm);
            OpenChildForm(botticelliForm);
        }
    }
}
