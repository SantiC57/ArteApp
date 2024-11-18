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
        private FavoriteItem head; 
        private int maxFavorites = 12;

        public Favoritos()
        {
            InitializeComponent();
            InitializeGroupBoxes();
        }


        public class FavoriteItem
        {
            public Image Image { get; set; }
            public string Name { get; set; }
            public FavoriteItem Next { get; set; }

            public FavoriteItem(Image image, string name)
            {
                Image = image;
                Name = name;
                Next = null;
            }
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
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; 
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage; 
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage; 
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage; 
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage; 
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage; 
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage; 
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage; 
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage; 
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage; 
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage; 
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;

        }




        public void AddFavorite(Image image, string name, int indiceImagen)
        {
            if (IsImageAlreadyAdded(image))
            {
                MessageBox.Show("Esta imagen ya está en favoritos.", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FavoriteItem newItem = new FavoriteItem(image, name);

            if (head == null)
            {
                head = newItem;
            }
            else
            {
                FavoriteItem current = head;
                int count = 1;

                while (current.Next != null)
                {
                    current = current.Next; 
                    count++;
                }

                if (count < maxFavorites)
                {
                    current.Next = newItem;
                }
                else
                {
                    MessageBox.Show("No hay más espacio para favoritos.", "Favoritos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            UpdateFavoritesUI(); 
            EjecutarBFS(indiceImagen);
        }

        private void UpdateFavoritesUI()
        {
            FavoriteItem current = head; 
            PictureBox[] pictureBoxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12 }; 
            Label[] labels = { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12 }; 
            System.Windows.Forms.GroupBox[] groups = { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6, groupBox7, groupBox8, groupBox9, groupBox10, groupBox11, groupBox12 }; 
            
            for (int i = 0; i < pictureBoxes.Length; i++) 
            { 
                if (current != null) 
                { 
                    pictureBoxes[i].Image = current.Image; 
                    labels[i].Text = current.Name; 
                    groups[i].Visible = true; 
                    current = current.Next; 
                } 
                else 
                { 
                    pictureBoxes[i].Image = null; 
                    labels[i].Text = string.Empty;
                    groups[i].Visible = false; 
                } 
                }
        }

        private List<Image> imagenes = new List<Image>
        {
                    Properties.Resources.LaMonaLisa,
                    Properties.Resources.ElGrito, // Reemplaza con los nombres correctos de las imágenes
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
                if (pasos[i] >= 1 && pasos[i] <= 2) // Si los pasos son 2 o menos, agregar la imagen
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
            // Asumimos que recommendedGroupBox1, recommendedGroupBox2, etc. están en el formulario
            System.Windows.Forms.GroupBox[] groups = { recommendedGroupBox1, recommendedGroupBox2, recommendedGroupBox3, recommendedGroupBox4, recommendedGroupBox5 };
            PictureBox[] pictureBoxes = { recommendedPictureBox1, recommendedPictureBox2, recommendedPictureBox3, recommendedPictureBox4, recommendedPictureBox5 };
            Label[] labels = { recommendedLabel1, recommendedLabel2, recommendedLabel3, recommendedLabel4, recommendedLabel5 };

            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                if (i < imagenesRecomendadas.Count)
                {
                    
                    pictureBoxes[i].Image = imagenes[imagenesRecomendadas[i]];

                    labels[i].Text = nombresImagenes[imagenesRecomendadas[i]];

                    groups[i].Visible = true;
                }

                else
                {
 
                    groups[i].Visible = false;
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
            FavoriteItem current = head; 
            
            while (current != null) 
            { 
                if (CompareImages(current.Image, image)) 
                { 
                    return true;
                } 
                current = current.Next;
            }
            return false;
        }

        private bool CompareImages(Image img1, Image img2)
        {
            byte[] img1Bytes = ImageToByteArray(img1); 
            byte[] img2Bytes = ImageToByteArray(img2); 
            return StructuralComparisons.StructuralEqualityComparer.Equals(img1Bytes, img2Bytes);
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
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

            PictureBox[] pictureBoxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12 };
            Label[] labels = { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12 };
            System.Windows.Forms.GroupBox[] groups = { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6, groupBox7, groupBox8, groupBox9, groupBox10, groupBox11, groupBox12 };

            // Guardamos los elementos visibles actuales
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                if (pictureBoxes[i].Image != null)
                {
                    favorites.Add((pictureBoxes[i].Image, labels[i].Text));
                }
            }

            // Limpiamos todos los PictureBox y Labels actuales
            foreach (var group in groups)
            {
                group.Visible = false;
            }

            // Reasignamos los favoritos a los PictureBox en orden
            for (int i = 0; i < favorites.Count; i++)
            {
                pictureBoxes[i].Image = favorites[i].Image;
                labels[i].Text = favorites[i].Name;
                groups[i].Visible = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox3, label3, groupBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox4, label4, groupBox4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox5, label5, groupBox5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox6, label6, groupBox6);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox11, label1, groupBox11);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox12, label12, groupBox12);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox10, label10, groupBox10);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox9, label9, groupBox9);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox8, label8, groupBox8);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RemoveFavorite(pictureBox7, label7, groupBox7);
        }
    }
}
