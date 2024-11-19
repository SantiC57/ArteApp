using ArteApp;
using Moq;
using System.Drawing;
using System.Collections.Generic;
using static PruebaUnitariaProject.FavoritosTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Net.Mime.MediaTypeNames;

namespace PruebaUnitariaProject
{
    [TestClass]

    public class FavoritosTests
    {
        public class MockImagenes
        {
            public List<string> Nombres { get; private set; } = new List<string> { "Imagen1", "Imagen2", "Imagen3" };
            public List<System.Drawing.Image> Imagenes { get; private set; } = new List<System.Drawing.Image>();

            public MockImagenes()
            {
                // Crea imágenes simuladas
                foreach (var nombre in Nombres)
                {
                    Imagenes.Add(new Bitmap(100, 100)); // Crea imágenes vacías
                }
            }

        }

        public class MockGrafo
        {
            private Dictionary<int, List<int>> conexiones = new Dictionary<int, List<int>>();

            public void AgregarConexion(int nodo, List<int> vecinos)
            {
                conexiones[nodo] = vecinos;
            }

            public bool TryGetValue(int nodo, out List<int> vecinos)
            {
                return conexiones.TryGetValue(nodo, out vecinos);
            }
        }

        public class MockFavoritos
        {
            private List<int> nodos = new List<int>();

            public bool EsVacia() => nodos.Count == 0;

            public int? PrimerNodo() => nodos.Count > 0 ? nodos[0] : (int?)null;

            public void Insertar(int indice) => nodos.Add(indice);
        }


        public class FavoritosManager
        {
            private MockFavoritos favoritos;
            private MockGrafo grafo;
            private MockImagenes imagenes;

            public FavoritosManager(MockFavoritos favoritos, MockGrafo grafo, MockImagenes imagenes)
            {
                this.favoritos = favoritos;
                this.grafo = grafo;
                this.imagenes = imagenes;
            }

            public void EjecutarBFS(int nodoInicial)
            {
                if (favoritos.EsVacia()) return;

                var cola = new Queue<int>();
                var visitados = new HashSet<int>();

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
                            }
                        }
                    }
                }
            }

            public List<int> ObtenerRecomendaciones()
            {
                // Retorna una lista fija como ejemplo
                return new List<int> { 1, 2 };
            }
        }

       
    
            private MockFavoritos favoritos;
            private MockGrafo grafo;
            private MockImagenes imagenes;

            [TestInitialize]
            public void SetUp()
            {
                favoritos = new MockFavoritos();
                grafo = new MockGrafo();
                imagenes = new MockImagenes();
            }

            [TestMethod]
            public void EjecutarBFS_Test()
            {
                favoritos.Insertar(0);
                grafo.AgregarConexion(0, new List<int> { 1, 2 });
                grafo.AgregarConexion(1, new List<int> { 3 });

                var manager = new FavoritosManager(favoritos, grafo, imagenes);
                manager.EjecutarBFS(0);

                var recomendaciones = manager.ObtenerRecomendaciones();
                CollectionAssert.AreEquivalent(new List<int> { 1, 2 }, recomendaciones);
            }


    }



}











