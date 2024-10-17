using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace ArteApp
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmInicioSesion());


            // Crear instancias de artistas
            Artista a1 = new Artista("Pablo Picasso", "Español", "Cubismo", new DateTime(1881, 10, 25), "Pintor, escultor, grabador, ceramista, escenógrafo y poeta español.");
            Artista a2 = new Artista("Vincent van Gogh", "Holandés", "Postimpresionismo", new DateTime(1853, 3, 30), "Pintor neerlandés, uno de los principales exponentes del postimpresionismo.");

            // Crear instancias de cuadros y asociarlos a los artistas
            Cuadro cuadro1 = new Cuadro("Guernica", a1, "Óleo sobre lienzo", "Cubismo", "1937", "349 cm × 776 cm", "Museo Reina Sofía, Madrid", "España", "Invaluable");
            Cuadro cuadro2 = new Cuadro("La noche estrellada", a2, "Óleo sobre lienzo", "Postimpresionismo", "1889", "73.7 cm × 92.1 cm", "Museo de Arte Moderno, Nueva York", "Estados Unidos", "Invaluable");

            // Mostrar información de los artistas y sus obras
            a1.Mostrar();
            a2.Mostrar();
            Queue<string> solicitudesVerObras = new Queue<string>();

            // Agregar solicitudes de los usuarios para ver obras
            solicitudesVerObras.Enqueue("Usuario 1 quiere ver 'La noche estrellada'");
            solicitudesVerObras.Enqueue("Usuario 2 quiere ver 'Guernica'");
            solicitudesVerObras.Enqueue("Usuario 3 quiere ver 'El Grito'");

            // Procesar las solicitudes en orden
            while (solicitudesVerObras.Count > 0)
            {
                string solicitudActual = solicitudesVerObras.Dequeue();
                WriteLine($"Procesando solicitud: {solicitudActual}");
            }

        }


    }
}
