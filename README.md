# Laberinto
Agregue las clases:

-CArco: Estos son las conexiones o caminos fisicos de las habitaciones, en pocas palabras la aristas, 
en el que se almacena donde llevan los pasillos y cuanto cuesta cruzarlos 

-CVertice:Este representa donde el jugador se puede parar, son los nodos que conectan, y aqui se guarda la info
de la habitacion, ya sea la lista de adyacencia y las variables de control de Dijkstra, para ver si ya paso por ahi el algoritmo o no

-CGrafo: esta es la estructura de datos general que agrupa todo el mapa del laberinto, contiene la lista de las habitacinoes y el algoritmo
de Dijkstra y ocupa el metodo "padres" para rastrear los nodos para construir la ruta final

-ControlDeLaberinto: es la barrera del programa, protege el grafo para que la interfaz grafica no interactue directamente, recibe las peticiones de los botones,
aplica validaciones y pesos para devolver respuestas procesadas
