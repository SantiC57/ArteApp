using ArteApp.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ArteApp
{
    public partial class Favoritos : Form
    {
        public Favoritos()
        {
            InitializeComponent();
            InitializeGroupBoxes();
        }


        private void InitializeGroupBoxes()
        {
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
            groupBox9.Visible = false;
            groupBox10.Visible = false;
            groupBox11.Visible = false;
            groupBox12.Visible = false;

        }

        


        public void AddFavorite(Image image, string name, int indiceImagen)
        {
            if (IsImageAlreadyAdded(image))
            {
                MessageBox.Show("Esta imagen ya está en favoritos.", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = image;
                label1.Text = name;
                groupBox1.Visible = true;
            }
            else if (pictureBox2.Image == null)
            {
                pictureBox2.Image = image;
                label2.Text = name;
                groupBox2.Visible = true;
            }
            else if (pictureBox3.Image == null)
            {
                pictureBox3.Image = image;
                label3.Text = name;
                groupBox3.Visible = true;
            }
            else if (pictureBox4.Image == null)
            {
                pictureBox4.Image = image;
                label4.Text = name;
                groupBox4.Visible = true;
            }
            else if (pictureBox5.Image == null)
            {
                pictureBox5.Image = image;
                label5.Text = name;
                groupBox5.Visible = true;
            }
            else if (pictureBox6.Image == null)
            {
                pictureBox6.Image = image;
                label6.Text = name;
                groupBox6.Visible = true;
            }
            else if (pictureBox7.Image == null)
            {
                pictureBox7.Image = image;
                label7.Text = name;
                groupBox7.Visible = true;
            }
            else if (pictureBox8.Image == null)
            {
                pictureBox8.Image = image;
                label8.Text = name;
                groupBox8.Visible = true;
            }
            else if (pictureBox9.Image == null)
            {
                pictureBox9.Image = image;
                label9.Text = name;
                groupBox9.Visible = true;
            }
            else if (pictureBox10.Image == null)
            {
                pictureBox10.Image = image;
                label10.Text = name;
                groupBox10.Visible = true;
            }
            else if (pictureBox11.Image == null)
            {
                pictureBox11.Image = image;
                label11.Text = name;
                groupBox11.Visible = true;
            }
            else if (pictureBox12.Image == null)
            {
                pictureBox12.Image = image;
                label12.Text = name;
                groupBox12.Visible = true;
            }
            else
            {
                MessageBox.Show("No hay más espacio para favoritos.", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
                EjecutarBFS(indiceImagen);
            
        }

        private List<Image> imagenes = new List<Image>
        {
                                Resources.LaMonaLisa,
                               Resources.ElGrito, // Reemplaza con los nombres correctos de las imágenes
                    Properties.Resources.LaNocheEstrellada,
                    Properties.Resources.LaUltimaCena,
                    Properties.Resources.LosComederosDePatatas,
                    Properties.Resources.LaMonaLisa,
                    Properties.Resources.images,
                    Properties.Resources.El_Hombre_de_Vitruvio,
                    Properties.Resources.Los_girasoles,
                    Properties.Resources.La_niña_enferma,
                    Properties.Resources.El_Bautismo_de_Cristo,
                    Properties.Resources.La_adoración_de_los_Reyes_Magos,
                    Properties.Resources.Autorretrato_con_la_oreja_vendada_y_caballete,
                    Properties.Resources.Salvator_Mundi,
                    Properties.Resources.Noche_estrellada_sobre_el_Ródano,
                    Properties.Resources.Madonna,
                    Properties.Resources.Dama_con_un_Armino,
                    Properties.Resources.Palas_y_el_Centauro,
                    Properties.Resources.La_casa_amarilla
        };

        // Grafo de relaciones entre obras de arte
        private Dictionary<int, List<int>> grafo = new Dictionary<int, List<int>>
{
    { 0, new List<int> { 1, 3 } },
    { 1, new List<int> { 0, 2, 7 } },
    { 2, new List<int> { 1, 4, 5 } },
    { 3, new List<int> { 0, 6, 12 } },
    { 4, new List<int> { 2, 5, 14 } },
    { 5, new List<int> { 2, 4, 9 } },
    { 6, new List<int> { 3, 12 } },
    { 7, new List<int> { 1, 13 } },
    { 8, new List<int> { 10, 11 } },
    { 9, new List<int> { 5, 11 } },
    { 10, new List<int> { 8, 15 } },
    { 11, new List<int> { 8, 9, 16 } },
    { 12, new List<int> { 3, 6 } },
    { 13, new List<int> { 7, 14 } },
    { 14, new List<int> { 4, 13 } },
    { 15, new List<int> { 10 } },
    { 16, new List<int> { 11, 17 } },
    { 17, new List<int> { 16 } }
};

        List<string> nombresImagenes = new List<string>
{
    "LaMonaLisa",
    "ElGrito",
    "LaNocheEstrellada",
    "LaUltimaCena",
    "LosComederosDePatatas",
    "LaMonaLisa",
    "NacimientodeVenus",
    "ElHombreDeVitruvio",
    "LosGirasoles",
    "LaNiñaEnferma",
    "ElBautismoDeCristo",
    "LosReyesMagos",
    "LaOrejaVendada",
    "SalvatorMundi",
    "ElRódano",
    "Madonna",
    "DamaConUnArmino",
    "PalasYElCentauro",
    "LaCasaAmarilla"
};

        private void EjecutarBFS(int nodoInicial)
        {
            Queue<int> cola = new Queue<int>();
            bool[] visitados = new bool[imagenes.Count];
            int[] pasos = new int[imagenes.Count];
            cola.Enqueue(nodoInicial);
            visitados[nodoInicial] = true;

            // Recorrido BFS
            while (cola.Count > 0)
            {
                int nodoActual = cola.Dequeue();

                foreach (int vecino in grafo[nodoActual])
                {
                    if (!visitados[vecino])
                    {
                        visitados[vecino] = true;
                        cola.Enqueue(vecino);
                        pasos[vecino] = pasos[nodoActual] + 1;
                    }
                }
            }

            // Recorrer las imágenes recomendadas
            List<Image> imagenesRecomendadas = new List<Image>();
            for (int i = 0; i < imagenes.Count; i++)
            {
                if (pasos[i] <= 2) // Si los pasos son 2 o menos, agregar la imagen
                {
                    imagenesRecomendadas.Add(imagenes[i]);
                }
            }

            // Mostrar las imágenes recomendadas en los PictureBox
            MostrarImagenesRecomendadas(imagenesRecomendadas, imagenes, nombresImagenes);
        }

        private void MostrarImagenesRecomendadas(List<Image> imagenesRecomendadas, List<Image> imagenes, List<string> nombresImagenes)
        {
            MostrarImagenesRecomendadas(imagenesRecomendadas.Select(imagen => imagenes.IndexOf(imagen)).ToList(), imagenes, nombresImagenes);
        }

        private void MostrarImagenesRecomendadas(List<int> imagenesRecomendadas, List<Image> imagenes, List<string> nombresImagenes)
        {
            // Asumimos que recommendedPictureBox1, recommendedPictureBox2, etc. y sus respectivos labels están en el formulario
            PictureBox[] pictureBoxes = { recommendedPictureBox1, recommendedPictureBox2, recommendedPictureBox3, recommendedPictureBox4, recommendedPictureBox5 };
            Label[] labels = { recommendedLabel1, recommendedLabel2, recommendedLabel3, recommendedLabel4, recommendedLabel5 };

            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                if (i < imagenesRecomendadas.Count)
                {
                    // Aquí cargamos la imagen
                    pictureBoxes[i].Image = imagenes[imagenesRecomendadas[i]];
                    pictureBoxes[i].Visible = true;

                    // Aquí actualizamos el texto del label con el nombre de la imagen
                    labels[i].Text = nombresImagenes[imagenesRecomendadas[i]];
                    labels[i].Visible = true;
                }
                else
                {
                    pictureBoxes[i].Visible = false;
                    labels[i].Visible = false;
                }
            }
        }




        private List<(Image image, string name)> GetFavorites()
        {
            List<(Image, string)> favorites = new List<(Image, string)>();

            if (pictureBox1.Image != null) favorites.Add((pictureBox1.Image, label1.Text));
            if (pictureBox2.Image != null) favorites.Add((pictureBox2.Image, label2.Text));
            if (pictureBox3.Image != null) favorites.Add((pictureBox3.Image, label3.Text));
            if (pictureBox4.Image != null) favorites.Add((pictureBox4.Image, label4.Text));
            if (pictureBox5.Image != null) favorites.Add((pictureBox5.Image, label5.Text));
            if (pictureBox6.Image != null) favorites.Add((pictureBox6.Image, label6.Text));
            if (pictureBox7.Image != null) favorites.Add((pictureBox7.Image, label7.Text));
            if (pictureBox8.Image != null) favorites.Add((pictureBox8.Image, label8.Text));
            if (pictureBox9.Image != null) favorites.Add((pictureBox9.Image, label9.Text));
            if (pictureBox10.Image != null) favorites.Add((pictureBox10.Image, label10.Text));
            if (pictureBox11.Image != null) favorites.Add((pictureBox11.Image, label11.Text));
            if (pictureBox12.Image != null) favorites.Add((pictureBox12.Image, label12.Text));

            return favorites;
        }
    


        private bool IsImageAlreadyAdded(Image image)
        {
            Image[] existingImages = { pictureBox1.Image, pictureBox2.Image, pictureBox3.Image, pictureBox4.Image, pictureBox5.Image, pictureBox6.Image, pictureBox7.Image, pictureBox8.Image, pictureBox9.Image, pictureBox10.Image, pictureBox11.Image, pictureBox12.Image };

            foreach (var existingImage in existingImages)
            {
                if (existingImage != null && CompareImages(existingImage, image))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CompareImages(Image img1, Image img2)
        {

            byte[] img1Bytes = ConvertirImagenABytes(img1);
            byte[] img2Bytes = ConvertirImagenABytes(img2);
            return StructuralComparisons.StructuralEqualityComparer.Equals(img1Bytes, img2Bytes);
        }

        private byte[] ConvertirImagenABytes(Image imagen)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imagen.Save(ms, imagen.RawFormat);
                return ms.ToArray();
            }
        }




        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Favoritos_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox1, label1, groupBox1);
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox2, label2, groupBox2);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox3, label3, groupBox3);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox4, label4, groupBox4);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox5, label5, groupBox5);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox6, label6, groupBox6);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox7, label7, groupBox7);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox8, label8, groupBox8);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox9, label9, groupBox9);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox10, label10, groupBox10);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox11, label11, groupBox11);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox12, label12, groupBox12);
        }

        private void RemoveFavorite(PictureBox pictureBox, Label label, System.Windows.Forms.GroupBox groupBox)
        {
            pictureBox.Image = null;
            label.Text = string.Empty;
            groupBox.Visible = false;

            // Reorganizar favoritos
            ReorganizeFavorites();
            

           
        }


        private void ReorganizeFavorites()
        {
            List<(Image Image, string Name)> favorites = new List<(Image, string)>();

            // Guardamos los elementos visibles actuales
            if (pictureBox1.Image != null) favorites.Add((pictureBox1.Image, label1.Text));
            if (pictureBox2.Image != null) favorites.Add((pictureBox2.Image, label2.Text));
            if (pictureBox3.Image != null) favorites.Add((pictureBox3.Image, label3.Text));
            if (pictureBox4.Image != null) favorites.Add((pictureBox4.Image, label4.Text));
            if (pictureBox5.Image != null) favorites.Add((pictureBox5.Image, label5.Text));
            if (pictureBox6.Image != null) favorites.Add((pictureBox6.Image, label6.Text));
            if (pictureBox7.Image != null) favorites.Add((pictureBox7.Image, label7.Text));
            if (pictureBox8.Image != null) favorites.Add((pictureBox8.Image, label8.Text));
            if (pictureBox9.Image != null) favorites.Add((pictureBox9.Image, label9.Text));
            if (pictureBox10.Image != null) favorites.Add((pictureBox10.Image, label10.Text));
            if (pictureBox11.Image != null) favorites.Add((pictureBox11.Image, label11.Text));
            if (pictureBox12.Image != null) favorites.Add((pictureBox12.Image, label12.Text));

            // Limpiamos todos los PictureBox y Labels actuales
            pictureBox1.Image = null; label1.Text = string.Empty; groupBox1.Visible = false;
            pictureBox2.Image = null; label2.Text = string.Empty; groupBox2.Visible = false;
            pictureBox3.Image = null; label3.Text = string.Empty; groupBox3.Visible = false;
            pictureBox4.Image = null; label4.Text = string.Empty; groupBox4.Visible = false;
            pictureBox5.Image = null; label5.Text = string.Empty; groupBox5.Visible = false;
            pictureBox6.Image = null; label6.Text = string.Empty; groupBox6.Visible = false;
            pictureBox7.Image = null; label7.Text = string.Empty; groupBox7.Visible = false;
            pictureBox8.Image = null; label8.Text = string.Empty; groupBox8.Visible = false;
            pictureBox9.Image = null; label9.Text = string.Empty; groupBox9.Visible = false;
            pictureBox10.Image = null; label10.Text = string.Empty; groupBox10.Visible = false;
            pictureBox11.Image = null; label11.Text = string.Empty; groupBox11.Visible = false;
            pictureBox12.Image = null; label12.Text = string.Empty; groupBox12.Visible = false;

            // Reasignamos los favoritos a los PictureBox en orden
            for (int i = 0; i < favorites.Count; i++)
            {
                switch (i)
                {
                    case 0: pictureBox1.Image = favorites[i].Image; label1.Text = favorites[i].Name; groupBox1.Visible = true; break;
                    case 1: pictureBox2.Image = favorites[i].Image; label2.Text = favorites[i].Name; groupBox2.Visible = true; break;
                    case 2: pictureBox3.Image = favorites[i].Image; label3.Text = favorites[i].Name; groupBox3.Visible = true; break;
                    case 3: pictureBox4.Image = favorites[i].Image; label4.Text = favorites[i].Name; groupBox4.Visible = true; break;
                    case 4: pictureBox5.Image = favorites[i].Image; label5.Text = favorites[i].Name; groupBox5.Visible = true; break;
                    case 5: pictureBox6.Image = favorites[i].Image; label6.Text = favorites[i].Name; groupBox6.Visible = true; break;
                    case 6: pictureBox7.Image = favorites[i].Image; label7.Text = favorites[i].Name; groupBox7.Visible = true; break;
                    case 7: pictureBox8.Image = favorites[i].Image; label8.Text = favorites[i].Name; groupBox8.Visible = true; break;
                    case 8: pictureBox9.Image = favorites[i].Image; label9.Text = favorites[i].Name; groupBox9.Visible = true; break;
                    case 9: pictureBox10.Image = favorites[i].Image; label10.Text = favorites[i].Name; groupBox10.Visible = true; break;
                    case 10: pictureBox11.Image = favorites[i].Image; label11.Text = favorites[i].Name; groupBox11.Visible = true; break;
                    case 11: pictureBox12.Image = favorites[i].Image; label12.Text = favorites[i].Name; groupBox12.Visible = true; break;
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void recommendedLabel2_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
