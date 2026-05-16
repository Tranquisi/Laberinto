using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto
{
    internal class CGrafo
    {

        public List<CVertice> Vertices { get; set; }

        public CGrafo()
        {
            Vertices = new List<CVertice>();
        }

        public void CalcularDijkstra(CVertice nodoInicio)
        {
            // Inicializar todos los nodos en "infinito"
            foreach (var v in Vertices)
            {
                v.ResetearEstado();
            }

            // La distancia al punto de partida del laberinto siempre es 0
            nodoInicio.DistanciaMinima = 0;

            while (true)
            {
                CVertice nodoActual = null;
                int distanciaMenor = int.MaxValue;

                // Buscar el nodo no visitado con la menor distancia acumulada hasta ahora
                foreach (var v in Vertices)
                {
                    if (!v.Visitado && v.DistanciaMinima < distanciaMenor)
                    {
                        distanciaMenor = v.DistanciaMinima;
                        nodoActual = v;
                    }
                }

                // Si ya no hay nodos alcanzables, terminamos el cálculo
                if (nodoActual == null) break;

                nodoActual.Visitado = true;

                // Evaluar pasillos adyacentes
                foreach (var arco in nodoActual.ListaAdyacencia)
                {
                    CVertice vecino = arco.Destino;

                    if (!vecino.Visitado)
                    {
                       //para no permitir costos negativos
                        if (arco.Peso < 0)
                            throw new InvalidOperationException("Dijkstra no admite pesos negativos.");

                        int distanciaPotencial = nodoActual.DistanciaMinima + arco.Peso;

                        if (distanciaPotencial < vecino.DistanciaMinima)
                        {
                            vecino.DistanciaMinima = distanciaPotencial;
                            vecino.Padre = nodoActual; // Guardamos el rastro del camino
                        }
                    }
                }
            }
        }

        public List<CVertice> ObtenerRutaOptima(CVertice nodoMeta)
        {
            List<CVertice> ruta = new List<CVertice>();
            CVertice actual = nodoMeta;

            // Reconstrucción del camino inverso saltando de padre en padre
            while (actual != null)
            {
                ruta.Insert(0, actual);
                actual = actual.Padre;
            }

            // Si el origen del camino no coincide con el nodo inicial (distancia != 0), es inalcanzable
            if (ruta.Count == 0 || ruta[0].DistanciaMinima != 0)
            {
                return new List<CVertice>();
            }

            return ruta;
        }


    }
}
