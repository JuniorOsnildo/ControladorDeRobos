using ControladorDeRobos.Models;

namespace ControladorDeRobos.Services.Buscas;

public static class UtilBusca
{
    public static readonly (int dx, int dy)[] Direcoes = [(-1, 0), (1, 0), (0, 1), (0, -1)]; //cima, baixo, direita, esquerda
    
    public static bool EstaDentroDoMapa(Celula[,] mapa, int x, int y)
    {
        return x >= 0 && x < mapa.GetLength(0) && y >= 0 && y < mapa.GetLength(1);   
    }

    public static List<Nodo> ReconstruirCaminho(Nodo destino)
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