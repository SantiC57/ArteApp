using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArteApp
{
    internal class Recomendados
    {
            // Lista de obras de arte
            private List<string> obras = new List<string>
            {
            "La Mona Lisa", "La Noche Estrellada", "El Grito", "La Ultima Cena",
            "El Nacimiento de Venus", "Los Comedores de Patatas", "El Hombre de Vitruvio",
            "Los Girasoles", "La Niña Enferma", "El Bautismo de Cristo",
            "La Adoración de los Reyes Magos", "Autorretrato con la Oreja Vendada y Caballete",
            "Salvator Mundi", "Noche Estrellada sobre el Ródano", "Madonna",
            "Dama con un Arminio", "Palas y el Centauro", "La Casa Amarilla"
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

            // Método BFS que se ejecuta cuando se agrega una obra a favoritos
            private void EjecutarBFS(int nodoInicial)
            {
                // Cola para el recorrido BFS y listas para nodos visitados y pasos
                Queue<int> cola = new Queue<int>();
                bool[] visitados = new bool[obras.Count];
                int[] pasos = new int[obras.Count];

                cola.Enqueue(nodoInicial);
                visitados[nodoInicial] = true;

                // Mostrar la obra inicial
                MessageBox.Show($"Nodo inicial: {obras[nodoInicial]}");

                while (cola.Count > 0)
                {
                    int nodoActual = cola.Dequeue();
                    MessageBox.Show($"Nodo visitado: {obras[nodoActual]}, Pasos desde nodo inicial: {pasos[nodoActual]}");

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

                // Mostrar los pasos finales desde el nodo inicial a cada nodo
                string mensajeFinal = "Pasos totales a cada nodo:\n";
                for (int i = 0; i < obras.Count; i++)
                {
                    mensajeFinal += $"{obras[i]}: {pasos[i]} pasos\n";
                }

                MessageBox.Show(mensajeFinal);
            }

            // Evento de agregar a favoritos, llamando a EjecutarBFS
            private void AgregarAFavoritos(int indiceObra)
            {
                // Llama a la búsqueda en anchura comenzando desde la obra agregada a favoritos
                EjecutarBFS(indiceObra);
            }

            // Evento de botón o lista para seleccionar obra y agregar a favoritos
            private void btnAgregarAFavoritos_Click(object sender, EventArgs e)
            {
                // Aquí seleccionaríamos el índice de la obra a agregar
                int indiceObraSeleccionada = 5; // Ejemplo: "Los Comedores de Patatas"
                AgregarAFavoritos(indiceObraSeleccionada);
            }
        }
    }

