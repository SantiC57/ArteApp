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
    public partial class PaginaDeInicio2 : Form
    {
        private Favoritos favoritosForm;
        private Form activeForm = null;
        public PaginaDeInicio2(Favoritos formFavoritos)
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
            private void PaginaDeInicio2_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            PaginaDeInicio paginaDeInicio = new PaginaDeInicio(favoritosForm); 
            OpenChildForm(paginaDeInicio);
        }
    

        private void button9_Click(object sender, EventArgs e)
        {
            PaginaDeInicio3 paginaDeInicio3 = new PaginaDeInicio3(favoritosForm); 
            OpenChildForm(paginaDeInicio3);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string artworkName = label2.Text;
            favoritosForm.AddFavorite(pictureBox1.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string artworkName = label5.Text;
            favoritosForm.AddFavorite(pictureBox2.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
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
            favoritosForm.AddFavorite(pictureBox6.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string artworkName = label16.Text;
            favoritosForm.AddFavorite(pictureBox5.Image, artworkName);
            MessageBox.Show($"{artworkName} se ha añadido a favoritos", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
