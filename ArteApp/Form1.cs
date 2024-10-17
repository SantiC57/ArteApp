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
        
        public Form1()
        {
            InitializeComponent();

            obrasDeArte = new Queue<string>();
            obrasDeArte.Enqueue("La Noche Estrellada");
            obrasDeArte.Enqueue("Guernica");
            obrasDeArte.Enqueue("El Grito");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

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
    }
}
