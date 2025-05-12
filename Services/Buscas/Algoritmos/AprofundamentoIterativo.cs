using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;

namespace ControladorDeRobos.Services.Buscas.Algoritmos;

public class AprofundamentoIterativo : IBuscaCaminho
{
    public List<Nodo> Busca(Celula[,] mapa, int xInicio, int yInicio, int xFinal, int yFinal)
    {
        mapa[xFinal, yFinal].Objeto = EnumObjetos.Livre; //libera posição da estante para o robozinho entrar

        var iteracao = 1;
        
        while (iteracao <= 100)
        {
            var visitado = new bool[mapa.GetLength(0), mapa.GetLength(1)];
            var pilha = new Stack<Nodo>();
            pilha.Push(new Nodo(xInicio, yInicio));
            
            for (int w = 0; w < iteracao; w++)
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
                        mapa[xNovo, yNovo].Objeto != EnumObjetos.Livre) continue;

                    pilha.Push(new Nodo(xNovo, yNovo, atual));
                }
            }
            iteracao++;
            
        }
        return [];
    }
}