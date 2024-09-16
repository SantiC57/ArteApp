using System;
using System.Collections;
using static System.Console;

namespace ArteApp
{
    public class Artista
    {
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }
        public string Estilo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Biografia { get; set; }
        public ArrayList Obras { get; set; } = new ArrayList();  // Inicializar la lista de obras

        public Artista(string nombre, string nac, string estilo, DateTime fecN, string bio)
        {
            Nombre = nombre;
            Nacionalidad = nac;
            Estilo = estilo;
            FechaNacimiento = fecN;
            Biografia = bio;
        }

        public void Mostrar()
        {
            WriteLine($"Nombre: {Nombre}");
            WriteLine($"Nacionalidad: {Nacionalidad}");
            WriteLine($"Estilo: {Estilo}");
            WriteLine($"Fecha de nacimiento: {FechaNacimiento:D}");
            WriteLine($"Biografía: {Biografia}");
            WriteLine();

            WriteLine("Obras:");
            foreach (Cuadro obra in Obras)
            {
                WriteLine($"- {obra.Titulo} ({obra.Fecha})");
            }
            WriteLine();
        }
    }  
}
