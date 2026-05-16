using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto
{
    public class ControladorDeLaberinto
    {
        private CGrafo grafo;

        public ControladorDeLaberinto()
        {
            grafo = new CGrafo();
        }

        
        public bool AgregarHabitacion(string nombre, int x, int y, out string error)
        {
            error = "";
            if (grafo.Vertices.Exists(v => v.Nombre.ToUpper() == nombre.ToUpper()))
            {
                error = "Error: Ya existe una habitación con ese nombre.";
                return false;
            }

            grafo.Vertices.Add(new CVertice(nombre, x, y));
            return true;
        }

        
        public bool ConectarHabitaciones(string origen, string destino, int peso, out string error)
        {
            error = "";
            if (peso < 0)
            {
                error = "Error: La distancia del pasillo no puede ser negativa.";
                return false;
            }

            CVertice vOrigen = grafo.Vertices.Find(v => v.Nombre == origen);
            CVertice vDestino = grafo.Vertices.Find(v => v.Nombre == destino);

            if (vOrigen == null || vDestino == null)
            {
                error = "Error: Una o ambas habitaciones no existen.";
                return false;
            }

            // Conexión del pasillo (Laberinto dirigido o bidireccional)
            vOrigen.ListaAdyacencia.Add(new CArco(vDestino, peso));
            return true;
        }

        public (bool Exito, List<CVertice> Camino, int Costo, string Mensaje) Resolver(string inicio, string fin)
        {
            CVertice vInicio = grafo.Vertices.Find(v => v.Nombre == inicio);
            CVertice vFin = grafo.Vertices.Find(v => v.Nombre == fin);

            if (vInicio == null || vFin == null)
                return (false, null, 0, "Puntos de control inválidos.");

            grafo.CalcularDijkstra(vInicio);
            List<CVertice> camino = grafo.ObtenerRutaOptima(vFin);

            if (camino.Count == 0)
                return (false, null, 0, "¡No hay salida posible en este laberinto!");

            return (true, camino, vFin.DistanciaMinima, "Laberinto resuelto con éxito.");
        }

        public List<CVertice> ObtenerEstructura() => grafo.Vertices;
        public void Reiniciar() => grafo.Vertices.Clear(); // Funcion para reiniciar el grafo
    }

}

