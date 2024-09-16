using System;
using static System.Console;

namespace ArteApp
{
    public class Cuadro
    {
        private string titulo;
        public string Titulo { get { return titulo; } set { titulo = value; } }
        public Artista Artista { get; set; }  // Referencia al objeto Artista
        public string Tecnica { get; set; }
        public string Estilo { get; set; }
        public string Fecha { get; set; }
        public string Dimensiones { get; set; }
        public string Ubicacion { get; set; }
        public string Propietario { get; set; }
        public string Valor { get; set; }

        public Cuadro(string titulo, Artista artista, string tecnica, string estilo, string fecha, string dimensiones, string ubicacion, string propietario, string valor)
        {
            Titulo = titulo;
            Artista = artista;  // Conectar el cuadro con el artista
            Tecnica = tecnica;
            Estilo = estilo;
            Fecha = fecha;
            Dimensiones = dimensiones;
            Ubicacion = ubicacion;
            Propietario = propietario;
            Valor = valor;

            // Añadir este cuadro a la lista de obras del artista
            artista.Obras.Add(this);
        }


        public void Mostrar()
        {
            WriteLine($"Titulo: {Titulo}");
            WriteLine($"Artista: {Artista}");
            WriteLine($"Tecnica: {Tecnica}");
            WriteLine($"Estilo: {Estilo}");
            WriteLine($"Fecha: {Fecha}");
            WriteLine($"Dimensiones: {Dimensiones}");
            WriteLine($"Ubicacion: {Ubicacion}");
            WriteLine($"Propietario: {Propietario}");
            WriteLine($"Valor: {Valor}");
        }
    }
}
