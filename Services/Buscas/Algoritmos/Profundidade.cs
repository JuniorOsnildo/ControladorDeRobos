using ControladorDeRobos.Models;

namespace ControladorDeRobos.Services.Buscas.Algoritmos;

public class Profundidade : IBuscaCaminho
{
    public List<Nodo> Busca(Celula[,] mapa, int xInicio, int yInicio, int xFinal, int yFinal)
    {
        var visitado = new bool[mapa.GetLength(0), mapa.GetLength(1)];
        var pilha = new Stack<Nodo>();

        pilha.Push(new Nodo(xInicio, yInicio));
        mapa[xFinal, yFinal].Livre = true; //libera posição da estante para o robozinho entrar

        while (pilha.Count > 0)
        {
            var atual = pilha.Pop();
            if (visitado[atual.X, atual.Y]) continue; //evita loop infinito visitando a mesma celula várias vezes

            visitado[atual.X, atual.Y] = true;

            if (atual.X == xFinal && atual.Y == yFinal) return UtilBusca.ReconstruirCaminho(atual);

            foreach (var (dx, dy) in UtilBusca.Direcoes)
            {
                var xNovo = atual.X + dx;
                var yNovo = atual.Y + dy;

                if (!UtilBusca.EstaDentroDoMapa(mapa, xNovo, yNovo) || visitado[xNovo, yNovo] ||
                    !mapa[xNovo, yNovo].Livre) continue;

                pilha.Push(new Nodo(xNovo, yNovo, atual));
            }
        }
        return [];
    }
}