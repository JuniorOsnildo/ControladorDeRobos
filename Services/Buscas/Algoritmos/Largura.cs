using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;

namespace ControladorDeRobos.Services.Buscas.Algoritmos;

public class Largura : IBuscaCaminho
{
    public List<Nodo> Busca(Celula[,] mapa, int xInicio, int yInicio, int xFinal, int yFinal)
    {
        var visitado = new bool[mapa.GetLength(0), mapa.GetLength(1)];
        var fila = new Queue<Nodo>();
        
        fila.Enqueue(new Nodo(xInicio, yInicio));;
        visitado[xInicio, yInicio] = true;
        mapa[xFinal, yFinal].Objeto = EnumObjetos.Livre; //libera posição da estante para o robozinho entrar
 
        while (fila.Count > 0)
        {
            var atual = fila.Dequeue();
            if (atual.X == xFinal && atual.Y == yFinal) return UtilBusca.ReconstruirCaminho(atual); 

            foreach (var (dx, dy) in UtilBusca.Direcoes)
            {
                var xNovo = atual.X + dx;
                var yNovo = atual.Y + dy;

                if (!UtilBusca.EstaDentroDoMapa(mapa, xNovo, yNovo) || visitado[xNovo, yNovo] ||
                    mapa[xNovo, yNovo].Objeto != EnumObjetos.Livre) continue;
                
                visitado[xNovo, yNovo] = true;
                fila.Enqueue(new Nodo(xNovo, yNovo, atual));
            }
        }
        return [];
    }
}