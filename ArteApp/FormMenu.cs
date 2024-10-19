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
    public partial class FormMenu : Form
    {

        private Form activeForm;
        private Queue<Image> ColaImagenes;

        public FormMenu()
        {
            InitializeComponent();

            ColaImagenes = new Queue<Image>();

            ColaImagenes.Enqueue(Properties.Resources.LaUltimaCena);
            ColaImagenes.Enqueue(Properties.Resources.LaNocheEstrellada);
            ColaImagenes.Enqueue(Properties.Resources.LosComederosDePatatas);

            pictureBox1.Image = ColaImagenes.Peek();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
           
        }


        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            btnClose.Visible = true;
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ArteApp.PaginaDeInicio(), sender);
        }

        private void btnFavoritos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ArteApp.Favoritos(), sender);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            frmInicioSesion forminicio = new frmInicioSesion();
            forminicio.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                Reset();
            }
        }

        private void Reset()
        {
            lblTitle.Text = "HOME";
            btnClose.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Image imgActual = ColaImagenes.Dequeue();
            ColaImagenes.Enqueue(imgActual);

            // Mostrar la nueva imagen al frente de la cola
            pictureBox1.Image = ColaImagenes.Peek();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ColaImagenes.Count - 1; i++)
            {
                Image imgActual = ColaImagenes.Dequeue();
                ColaImagenes.Enqueue(imgActual);
            }

            // Mostrar la imagen que ahora está al frente de la cola (la imagen anterior)
            pictureBox1.Image = ColaImagenes.Peek();
        }
    }
}
