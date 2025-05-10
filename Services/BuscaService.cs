using ControladorDeRobos.Controllers;
using ControladorDeRobos.Models;
using ControladorDeRobos.Services.Buscas;

namespace ControladorDeRobos.Services;

public static class BuscaService
{
    public static (string melhorRobo, List<Nodo>? melhorCaminho) EncontrarRoboMaisProximo(IBuscaCaminho algoritmo, Celula[,] mapa ,int xEstante, int yEstante)
    { 
        var listaRobos = EncontrarRobos(mapa);
        var melhorRobo = "";
        List<Nodo>? melhorCaminho = null; 

        foreach (var robo in listaRobos)
        {
            var caminho = algoritmo.Busca(mapa, robo.X, robo.Y, xEstante, yEstante);
            
            if (caminho.Count == 0) continue;
            if (melhorCaminho == null || caminho.Count >= melhorCaminho.Count) continue;
            
            melhorCaminho = caminho;
            melhorRobo = robo.Robo;
        }
        return (melhorRobo, melhorCaminho);
    }

    private static List<Celula> EncontrarRobos(Celula[,] mapa)
    {
        var robos = new List<Celula>();
        for (int i = 0; i < mapa.GetLength(0); i++)
        {
            for (int j = 0; j < mapa.GetLength(1); j++)
            {
                if(mapa[i, j].Robo != "") continue;
                robos.Add(mapa[i, j]);
            }
        }
        return robos;
    }
    
    private static List<Celula> EntregarCaixa(Celula estante, Celula[,] mapa)
    {
        var caminho = new List<Celula>();
        var atual = estante;
        caminho.Add(atual);
        
        
        if (mapa[atual.X + 1, atual.Y].Livre && UtilBusca.EstaDentroDoMapa(mapa, atual.X + 1, atual.Y))
        {
            atual = mapa[atual.X + 1, atual.Y];
        }
        else
        {
            atual = mapa[atual.X - 1, atual.Y];
        }
        
        caminho.Add(atual);

        while (atual.X != 11)
        {
            atual = mapa[atual.X+1, atual.Y];
            caminho.Add(atual);
        }
        while (atual.Y != 14)
        {
            atual = mapa[atual.X+1, atual.Y];
            caminho.Add(atual);       
        }
        
        return caminho;

    }
    
}