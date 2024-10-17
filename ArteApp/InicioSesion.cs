using MySql.Data.MySqlClient;
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
    public partial class frmInicioSesion : Form
    {
        private string connectionString = "Server=localhost;Database=Galeria;Uid=root;Pwd=admin123";

        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmRegistro().Show();
            this.Hide();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = txtUsuarioIS.Text;
            string password = mskConstraseñaIS.Text;

            string query = "SELECT * FROM Usuario WHERE Usuario = @Usuario AND Contraseña = @Contraseña";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Usuario", username);
                    command.Parameters.AddWithValue("@Contraseña", password);

                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Los datos de inicio de sesión son válidos
                            Form1 form1 = new Form1();
                            form1.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Los datos de inicio de sesión son inválidos
                            MessageBox.Show("Inicio de sesión fallido");
                        }
                    }
                }
            }
        }

    }
}
