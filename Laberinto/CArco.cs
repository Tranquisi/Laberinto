using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto
{
    public class CArco
    {
        public CVertice Destino { get; set; }
        public int Peso { get; set; } // Representa la distancia o dificultad del pasillo

        public CArco(CVertice destino, int peso)
        {
            Destino = destino;
            Peso = peso;
        }

    }
}
