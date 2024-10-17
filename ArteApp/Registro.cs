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
    public partial class frmRegistro : Form
    {
        private string connectionString = "Server=localhost;Database=Tienda;Uid=root;Pwd=admin123";
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmInicioSesion forminicio = new frmInicioSesion();
            forminicio.Show();
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO clientes (Usuario, Contraseña) VALUES (@Usuario, @Contraseña)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", txtU);
                command.Parameters.AddWithValue("@Contraseña", mskContraseñaR.Text);


                try
                {
                    command.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void chkContraseña_CheckedChanged(object sender, EventArgs e)
        {

            if (chkContraseña.Checked)
            {

                mskContraseñaR.PasswordChar = '\0';

            }

            else if (chkContraseña.Checked==false)
            {

                mskContraseñaR.PasswordChar = '•';


            }

        }

        private void mskCnfrC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
