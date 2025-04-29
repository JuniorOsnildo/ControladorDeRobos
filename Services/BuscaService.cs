using ControladorDeRobos.Models;

namespace ControladorDeRobos.Services;

public class BuscaService
{
    private static readonly (int dx, int dy)[] Direcoes = [(-1, 0), (1, 0), (0, 1), (0, -1)]; //cima, baixo, direita, esquerda

    public static List<Nodo> BuscaLargura(Celula[,] mapa, int xInicio, int yInicio, int xFinal, int yFinal)
    {
        var visitado = new bool[mapa.GetLength(0), mapa.GetLength(1)];
        var fila = new Queue<Nodo>();
        
        fila.Enqueue(new Nodo(xInicio, yInicio));;
        visitado[xInicio, yInicio] = true;
        mapa[xFinal, yFinal].Livre = true; //libera posição da estante para o robozinho entrar

        while (fila.Count > 0)
        {
            var atual = fila.Dequeue();
            if (atual.X == xFinal && atual.Y == yFinal) return ReconstruirCaminho(atual);

            foreach (var (dx, dy) in Direcoes)
            {
                var xNovo = atual.X + dx;
                var yNovo = atual.Y + dy;

                if (!EstaDentroDoMapa(mapa, xNovo, yNovo) || visitado[xNovo, yNovo] ||
                    !mapa[xNovo, yNovo].Livre) continue;
                
                visitado[xNovo, yNovo] = true;
                fila.Enqueue(new Nodo(xNovo, yNovo, atual));
            }
        }
        return [];
    }
    
    private static bool EstaDentroDoMapa(Celula[,] mapa, int x, int y)
    {
        return x >= 0 && x < mapa.GetLength(0) && y >= 0 && y < mapa.GetLength(1);   
    }

    private static List<Nodo> ReconstruirCaminho(Nodo destino)
    {
        var caminho = new List<Nodo>();
        var atual = destino;

        while (atual != null)
        {
            caminho.Add(atual);
            atual = atual.Pai;
        }
        
        caminho.Reverse();
        return caminho;   
    }
}