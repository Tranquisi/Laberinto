using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto
{
    public class CVertice
    {
        public string Nombre { get; set; }
        public List<CArco> ListaAdyacencia { get; set; }

        // Propiedades para el algoritmo de Dijkstra
        public bool Visitado { get; set; }
        public int DistanciaMinima { get; set; }
        public CVertice Padre { get; set; } // Esencial para la ruta de salida

        // Coordenadas para renderizar el mapa en el panel
        public int PosicionX { get; set; }
        public int PosicionY { get; set; }

        public CVertice(string nombre, int x, int y)
        {
            Nombre = nombre;
            PosicionX = x;
            PosicionY = y;
            ListaAdyacencia = new List<CArco>();
            ResetearEstado();
        }

        public void ResetearEstado()
        {
            Visitado = false;
            DistanciaMinima = int.MaxValue; // Simula el infinito matemático
            Padre = null;
        }

    }
}
