using ArteApp.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;  // Para la clase Image
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ArteApp
{
    public partial class Favoritos : Form
    {
        private readonly PictureBox[] pictureBoxes;
        private readonly Label[] labels;
        private readonly System.Windows.Forms.GroupBox[] groups;
        public LSL favoritos;
        private int maxFavorites = 12;

        public Favoritos()
        {
            InitializeComponent();
            InitializeGroupBoxes();
            favoritos = new LSL();
            pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6,
                          pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12 };
            labels = new[] { label1, label2, label3, label4, label5, label6,
                    label7, label8, label9, label10, label11, label12 };
            groups = new[] { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6,
                    groupBox7, groupBox8, groupBox9, groupBox10, groupBox11, groupBox12 };
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
                MessageBox.Show("Esta imagen ya está en favoritos.", "Favoritos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (favoritos.PrimerNodo() == null || !IsMaxFavoritesReached())
            {
                // Insertar en la lista ligada
                favoritos.Insertar(indiceImagen);

                // Actualizar la interfaz
                UpdateFavoritesUI();

                // Ejecutar BFS para recomendaciones
                EjecutarBFS(indiceImagen);
            }
            else
            {
                MessageBox.Show("No hay más espacio para favoritos.", "Favoritos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private bool IsMaxFavoritesReached()
        {
            int count = 0; NS current = favoritos.PrimerNodo();
            while (current != null)
            {
                count++; current = current.RetornaLiga();
            }
            return count >= maxFavorites;
        }

        private bool IsImageAlreadyAdded(Image image)
        {
            int indiceImagen = imagenes.IndexOf(image);
            NS current = favoritos.PrimerNodo();

            while (current != null)
            {
                if (current.RetornaIndiceImagen() == indiceImagen)
                {
                    return true;
                }
                current = current.RetornaLiga();
            }
            return false;
        }




        private void UpdateFavoritesUI()
        {
            NS current = favoritos.PrimerNodo();

            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                if (current != null)
                {
                    pictureBoxes[i].Image = imagenes[current.RetornaIndiceImagen()];
                    labels[i].Text = nombresImagenes[current.RetornaIndiceImagen()];
                    groups[i].Visible = true;
                    current = current.RetornaLiga();
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
                    Resources.LaMonaLisa,
                    Resources.ElGrito, // Reemplaza con los nombres correctos de las imágenes
                    Resources.LaNocheEstrellada,
                    Resources.LaUltimaCena,
                    Resources.LosComederosDePatatas,
                    Resources.images,
                    Resources.El_Hombre_de_Vitruvio,
                    Resources.Los_girasoles,
                    Resources.La_niña_enferma,
                    Resources.El_Bautismo_de_Cristo,
                    Resources.La_adoración_de_los_Reyes_Magos,
                    Resources.Autorretrato_con_la_oreja_vendada_y_caballete,
                    Resources.Salvator_Mundi,
                    Resources.Noche_estrellada_sobre_el_Ródano,
                    Resources.Madonna,
                    Resources.Dama_con_un_Armino,
                    Resources.Palas_y_el_Centauro,
                    Resources.La_casa_amarilla
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
            // Si no hay nodos en favoritos, limpiar recomendaciones
            if (favoritos.EsVacia())
            {
                LimpiarRecomendaciones();
                return;
            }

            var cola = new Queue<int>();
            var visitados = new HashSet<int>();
            var pasos = new int[imagenes.Count];

            cola.Enqueue(nodoInicial);
            visitados.Add(nodoInicial);

            while (cola.Count > 0)
            {
                int nodoActual = cola.Dequeue();

                if (grafo.TryGetValue(nodoActual, out var vecinos))
                {
                    foreach (int vecino in vecinos)
                    {
                        if (!visitados.Contains(vecino))
                        {
                            visitados.Add(vecino);
                            cola.Enqueue(vecino);
                            pasos[vecino] = pasos[nodoActual] + 1;
                        }
                    }
                }
            }

            var imagenesRecomendadas = new List<int>();
            for (int i = 0; i < imagenes.Count; i++)
            {
                if (pasos[i] >= 1 && pasos[i] <= 2)
                {
                    imagenesRecomendadas.Add(i);
                }
            }

            MostrarImagenesRecomendadas(imagenesRecomendadas, imagenes, nombresImagenes);
        }





        private void MostrarImagenesRecomendadas(List<int> imagenesRecomendadas, List<Image> imagenes, List<string> nombresImagenes)
        {
            // Si no hay imágenes recomendadas, limpiar todo
            if (imagenesRecomendadas.Count == 0)
            {
                LimpiarRecomendaciones();
                return;
            }

            System.Windows.Forms.GroupBox[] groups = { recommendedGroupBox1, recommendedGroupBox2, recommendedGroupBox3, recommendedGroupBox4, recommendedGroupBox5 };
            PictureBox[] pictureBoxes = { recommendedPictureBox1, recommendedPictureBox2, recommendedPictureBox3, recommendedPictureBox4, recommendedPictureBox5 };
            Label[] labels = { recommendedLabel1, recommendedLabel2, recommendedLabel3, recommendedLabel4, recommendedLabel5 };

            // Filtrar las imágenes que ya están en favoritos
            var imagenesNoFavoritas = imagenesRecomendadas.Where(i => !IsImageAlreadyAdded(imagenes[i])).ToList();

            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                if (i < imagenesNoFavoritas.Count)
                {
                    pictureBoxes[i].Image = imagenes[imagenesNoFavoritas[i]];
                    labels[i].Text = nombresImagenes[imagenesNoFavoritas[i]];
                    groups[i].Visible = true;
                }
                else
                {
                    pictureBoxes[i].Image = null;
                    labels[i].Text = string.Empty;
                    groups[i].Visible = false;
                }
            }
        }


        private void LimpiarRecomendaciones()
        {
            System.Windows.Forms.GroupBox[] groups = { recommendedGroupBox1, recommendedGroupBox2, recommendedGroupBox3, recommendedGroupBox4, recommendedGroupBox5 };
            PictureBox[] pictureBoxes = { recommendedPictureBox1, recommendedPictureBox2, recommendedPictureBox3, recommendedPictureBox4, recommendedPictureBox5 };
            Label[] labels = { recommendedLabel1, recommendedLabel2, recommendedLabel3, recommendedLabel4, recommendedLabel5 };

            for (int i = 0; i < groups.Length; i++)
            {
                groups[i].Visible = false;
                pictureBoxes[i].Image = null;
                labels[i].Text = string.Empty;
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
            if (pictureBox.Image == null) return;

            int indiceABorrar = imagenes.IndexOf(pictureBox.Image);
            if (indiceABorrar != -1)
            {
                try
                {
                    favoritos.Borrar(indiceABorrar);
                    UpdateFavoritesUI();

                    // Actualizar recomendaciones basadas en el nuevo primer nodo
                    if (favoritos.PrimerNodo() != null)
                    {
                        EjecutarBFS(favoritos.PrimerNodo().RetornaIndiceImagen());
                    }
                    else
                    {
                        // Si no hay más favoritos, limpiar las recomendaciones
                        LimpiarRecomendaciones();
                    }
                }
                catch (Exception)
                {
                    // Manejar el caso donde la imagen no está en la lista
                }
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

        public class NS
        {
            public int IndiceImagen { get; set; }
            public NS Liga { get; set; }

            public NS(int indiceImagen)
            {
                IndiceImagen = indiceImagen;
                Liga = null;
            }

            public void AsignaLiga(NS nodoALigar)
            {
                Liga = nodoALigar;
            }

            public void AsignaIndiceImagen(int indiceImagen)
            {
                IndiceImagen = indiceImagen;
            }

            public NS RetornaLiga()
            {
                return Liga;
            }

            public int RetornaIndiceImagen()
            {
                return IndiceImagen;
            }
        }

        public class LSL
        {
            public NS primero;
            public NS ultimo;

            public LSL()
            {
                primero = null;
                ultimo = null;
            }

            public bool EsVacia()
            {
                return primero == null;
            }

            public NS PrimerNodo()
            {
                return primero;
            }

            public NS UltimoNodo()
            {
                return ultimo;
            }

            public NS Anterior(NS posterior)
            {
                NS iterador = PrimerNodo();
                NS nodoAnt = null;
                while (iterador != posterior && iterador != null)
                {
                    nodoAnt = iterador;
                    iterador = iterador.RetornaLiga();
                }
                if (iterador == null)
                {
                    throw new Exception("No se encontró el nodo en la lista");
                }
                return nodoAnt;
            }

            public NS BuscaDondeInsertar(int candidato)
            {
                NS iterador = PrimerNodo();
                NS nodoAnt = null;
                while (iterador != null && iterador.RetornaIndiceImagen() < candidato)
                {
                    nodoAnt = iterador;
                    iterador = iterador.RetornaLiga();
                }
                return nodoAnt;
            }

            public void Conectar(NS nodoAConectar, NS nodoAnterior)
            {
                if (nodoAnterior == null)
                {
                    nodoAConectar.AsignaLiga(primero);
                    if (primero == null)
                    {
                        ultimo = nodoAConectar;
                    }
                    primero = nodoAConectar;
                }
                else
                {
                    nodoAConectar.AsignaLiga(nodoAnterior.RetornaLiga());
                    nodoAnterior.AsignaLiga(nodoAConectar);
                    if (nodoAnterior == ultimo)
                    {
                        ultimo = nodoAConectar;
                    }
                }
            }

            public void Insertar(int dato)
            {
                NS nodoAnterior = BuscaDondeInsertar(dato);
                NS nuevoNodo = new NS(dato);
                Conectar(nuevoNodo, nodoAnterior);
            }

            public void Recorrer()
            {
                NS iterador = PrimerNodo();
                while (iterador != null)
                {
                    Console.WriteLine(iterador.RetornaIndiceImagen());
                    iterador = iterador.RetornaLiga();
                }
            }

            public NS BuscarDato(int dato)
            {
                NS iterador = PrimerNodo();
                while (iterador != null && iterador.RetornaIndiceImagen() != dato)
                {
                    iterador = iterador.RetornaLiga();
                }
                return iterador;
            }

            public void Desconectar(NS nodoADesconectar)
            {
                NS nodoAnterior = Anterior(nodoADesconectar);
                if (nodoADesconectar == primero)
                {
                    primero = primero.RetornaLiga();
                    if (primero == null)
                    {
                        ultimo = null;
                    }
                }
                else
                {
                    nodoAnterior.AsignaLiga(nodoADesconectar.RetornaLiga());
                    if (nodoADesconectar == ultimo)
                    {
                        ultimo = nodoAnterior;
                    }
                }
            }

            public void Borrar(int datoABorrar)
            {
                NS nodoABorrar = BuscarDato(datoABorrar);
                if (nodoABorrar == null)
                {
                    throw new Exception("Dato inexistente en la lista");
                }
                Desconectar(nodoABorrar);
            }
        }


    }
}

