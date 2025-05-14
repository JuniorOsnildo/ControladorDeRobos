using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;

namespace ControladorDeRobos.Services.Buscas.Algoritmos;

public class Largura : IBuscaCaminho
{
    public List<Nodo> Busca (int xInicio, int yInicio, int xFinal, int yFinal)
    {
        var visitado = new bool[MapaRepository.Mapa.GetLength(0), MapaRepository.Mapa.GetLength(1)];
        var fila = new Queue<Nodo>();
        
        fila.Enqueue(new Nodo(xInicio, yInicio));;
        visitado[xInicio, yInicio] = true;
        MapaRepository.Mapa[xFinal, yFinal].Livre = true; //libera posição da estante para o robozinho entrar
 
        while (fila.Count > 0)
        {
            var atual = fila.Dequeue();
            if (atual.X == xFinal && atual.Y == yFinal) return UtilBusca.ReconstruirCaminho(atual); 

            foreach (var (dx, dy) in UtilBusca.Direcoes)
            {
                var xNovo = atual.X + dx;
                var yNovo = atual.Y + dy;

                if (!UtilBusca.EstaDentroDoMapa(xNovo, yNovo) || visitado[xNovo, yNovo] ||
                    !MapaRepository.Mapa[xNovo, yNovo].Livre || RoboSevice.TemRobo(xNovo,yNovo)) continue;
                
                visitado[xNovo, yNovo] = true;
                fila.Enqueue(new Nodo(xNovo, yNovo, atual));
            }
        }
        return [];
    }
}