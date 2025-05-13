using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;

namespace ControladorDeRobos.Services.Buscas.Algoritmos;

public class Aestrela : IBuscaCaminho
{
    public List<Nodo> Busca (int xInicio, int yInicio, int xFinal, int yFinal)
    {
        var visitado = new bool[MapaRepository.Mapa.GetLength(0), MapaRepository.Mapa.GetLength(1)];
        var fila = new PriorityQueue<Nodo, int>();

        var custoMinimo = new Dictionary<(int, int), int>(); // guarda menor G por posição

        var inicio = (new Nodo(xInicio, yInicio, null, 0,
            CalcularDistanciaManhattan(xInicio, yInicio, xFinal, yFinal)));

        fila.Enqueue(inicio, inicio.F);
        custoMinimo[(xInicio, yInicio)] = inicio.G;

        MapaRepository.Mapa[xFinal, yFinal].Objeto = EnumObjetos.Livre; //libera posição da estante para o robozinho entrar

        while (fila.Count > 0)
        {
            var atual = fila.Dequeue();
            if (visitado[atual.X, atual.Y]) continue; //evita loop infinito visitando a mesma celula várias vezes

            visitado[atual.X, atual.Y] = true;

            if (atual.X == xFinal && atual.Y == yFinal) return UtilBusca.ReconstruirCaminho(atual);

            foreach (var (dx, dy) in UtilBusca.Direcoes)
            {
                var xNovo = atual.X + dx;
                var yNovo = atual.Y + dy;

                if (!UtilBusca.EstaDentroDoMapa(xNovo, yNovo) || visitado[xNovo, yNovo] ||
                    MapaRepository.Mapa[xNovo, yNovo].Objeto != EnumObjetos.Livre) continue;

                var novoG = atual.G + 1;
                
                // verifica se existe um caminho (G) melhor ou igual na lista para essa posição (xNovo, yNovo)
                if (custoMinimo.TryGetValue((xNovo, yNovo), out var gExistente) && novoG >= gExistente) continue;

                //adiciona Nodo com custo novo G de G+1 e calcula heurística H
                var vizinho = new Nodo(xNovo, yNovo, atual)
                {
                    G = novoG,
                    H = CalcularDistanciaManhattan(xNovo, yNovo, xFinal, yFinal)
                };

                fila.Enqueue(vizinho, vizinho.F);
            }
        }

        return [];
    }

    private static int CalcularDistanciaManhattan(int x1, int y1, int x2, int y2)
    {
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }
}