using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ArteApp
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=localhost;Database=Galeria;Uid=root;Pwd=admin123";
        Queue<string> obrasDeArte;
        Favoritos favoritos;
        public Form1()
        {
            InitializeComponent();

            obrasDeArte = new Queue<string>();
            obrasDeArte.Enqueue("La Noche Estrellada");
            obrasDeArte.Enqueue("Guernica");
            obrasDeArte.Enqueue("El Grito");

        }

        bool menuExpand = false;


        private void button1_Click(object sender, EventArgs e)
        {

            string obraBuscada = textBoxObra.Text.Trim();

            if (string.IsNullOrEmpty(obraBuscada))
            {
                Resultado.Text = "Por favor, ingresa el nombre de la obra.";
                return;
            }

            string obraEncontrada = obrasDeArte.FirstOrDefault(obra => obra.Equals(obraBuscada, StringComparison.OrdinalIgnoreCase));

            if (obraEncontrada != null)
            {
                Resultado.Text = "Obra encontrada: " + obraEncontrada;
            }
            else
            {
                Resultado.Text = "Obra no encontrada.";

            }

        }


        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

      

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Abrir_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();

        }

        bool sidebarExpand = true;

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (favoritos == null)
            {
                favoritos = new Favoritos();
                favoritos.FormClosed += Favoritos_FormClosed;
                favoritos.MdiParent = this;
                favoritos.Show();
            }
            else
            {
                favoritos.Activate();
            }
        }
        private void Favoritos_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            favoritos = null;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            frmInicioSesion inicio = new frmInicioSesion();
            inicio.Show();
            this.Hide();
        }

        private void sidebarTransition_Tick_1(object sender, EventArgs e)
        {

            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 50)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }


            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 229)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }

            }
        }
    }
}
