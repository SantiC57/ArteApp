using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private string connectionString = "Server=localhost;Database=Galeria;Uid=root;Pwd=admin123";
        private Favoritos favoritosForm;


        public FormMenu()
        {
            InitializeComponent();

            ColaImagenes = new Queue<Image>();
            GuardarImagenesEnBaseDeDatos();

            CargarImagenesDesdeBaseDeDatos();

            if (ColaImagenes.Count > 0)
            {
                pictureBox1.Image = ColaImagenes.Peek(); // Muestra la primera imagen
            }

            favoritosForm = new Favoritos();
        }


        private void Limpiar()
        {

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Imagenes"; // Eliminar todos los registros de la tabla Clientes
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.ExecuteNonQuery(); // Ejecutar la consulta de eliminación
                        }


                        
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show($"Error al eliminar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
        }



        private void GuardarImagenesEnBaseDeDatos()
        {

            // Conexión a MySQL
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Limpiar();

                // Cargar imágenes desde los recursos
                Image[] imagenes = {
                    Properties.Resources.ElGrito, // Reemplaza con los nombres correctos de las imágenes
                    Properties.Resources.LaNocheEstrellada,
                    Properties.Resources.LaUltimaCena,
                    Properties.Resources.LosComederosDePatatas,
                    Properties.Resources.LaMonaLisa,
                    Properties.Resources.images
                };

                // Insertar imágenes en la base de datos
                for (int i = 0; i < imagenes.Length; i++)
                {
                    byte[] imagenBytes = ConvertirImagenABytes(imagenes[i]);

                    string query = "INSERT INTO imagenes (nombre, imagen) VALUES (@nombre, @imagen)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", "imagen" + (i + 1));
                        cmd.Parameters.AddWithValue("@imagen", imagenBytes);

                        cmd.ExecuteNonQuery();
                    }
                }

                

            }
        }

        private byte[] ConvertirImagenABytes(Image imagen)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imagen.Save(ms, imagen.RawFormat);
                return ms.ToArray();
            }
        }




        private Image ConvertirBytesAImagen(byte[] bytes)
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }

            private void CargarImagenesDesdeBaseDeDatos()
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT imagen FROM imagenes LIMIT 3";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                byte[] imagenBytes = (byte[])reader["imagen"];
                                Image imagen = ConvertirBytesAImagen(imagenBytes);
                                ColaImagenes.Enqueue(imagen);
                            }
                        }
                    }
                }
            }


            private void FormMenu_Load(object sender, EventArgs e)
            {

            }


            private void OpenChildForm(Form childForm, object btnSender)
            {
                if (activeForm != null)
                {
                    activeForm.Hide();
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
                OpenChildForm(new ArteApp.PaginaDeInicio(favoritosForm), sender);
            }

            private void btnFavoritos_Click(object sender, EventArgs e)
            {
             if (favoritosForm != null && !favoritosForm.Visible)
             {
                favoritosForm.Show();  // Muestra el formulario si estaba oculto
              }
            
            OpenChildForm(favoritosForm, sender);
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
                    activeForm.Hide();
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
                if (ColaImagenes.Count > 0)
                {
                    // Sacar la imagen actual de la cola y volverla a encolar al final
                    Image imgActual = ColaImagenes.Dequeue();
                    ColaImagenes.Enqueue(imgActual);

                    // Mostrar la nueva imagen al frente de la cola
                    pictureBox1.Image = ColaImagenes.Peek();
                }
            }

            private void btnAnterior_Click(object sender, EventArgs e)
            {
                if (ColaImagenes.Count > 0)
                {
                    // Rotar todas las imágenes excepto la última para simular "retroceder"
                    for (int i = 0; i < ColaImagenes. Count - 1; i++)
                    {
                        Image imgActual = ColaImagenes.Dequeue();
                        ColaImagenes.Enqueue(imgActual);
                    }

                    // Mostrar la imagen que ahora está al frente de la cola (la imagen anterior)
                    pictureBox1.Image = ColaImagenes.Peek();
                }
            }
        
    }
}
