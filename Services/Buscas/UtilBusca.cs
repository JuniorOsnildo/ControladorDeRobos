using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;

namespace ControladorDeRobos.Services.Buscas;

public static class UtilBusca
{
    public static readonly (int dx, int dy)[] Direcoes = [(-1, 0), (1, 0), (0, 1), (0, -1)]; //cima, baixo, direita, esquerda
    
    public static bool EstaDentroDoMapa(int x, int y)
    {
        return x >= 0 && x < MapaRepository.Mapa.GetLength(0) && y >= 0 && y < MapaRepository.Mapa.GetLength(1);   
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