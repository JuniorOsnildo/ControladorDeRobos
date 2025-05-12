using ControladorDeRobos.Controllers;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;
using ControladorDeRobos.Services.Buscas;

namespace ControladorDeRobos.Services;

public static class BuscaService
{
    public static ((int, int) melhorRobo, List<Nodo>? melhorCaminho) EncontrarRoboMaisProximo(IBuscaCaminho algoritmo
        , int xEstante, int yEstante)
    {
        var listaRobos = EncontrarRobos();
        var melhorRobo = (1,2);
        List<Nodo>? melhorCaminho = null;

        foreach (var robo in listaRobos)
        {
            var caminho = algoritmo.Busca(MapaRepository.Mapa, robo.X, robo.Y, xEstante, yEstante);

            if (caminho.Count == 0) continue;
            if (melhorCaminho == null || caminho.Count >= melhorCaminho.Count) continue;

            melhorCaminho = caminho;
            melhorRobo.Item1 = robo.X;
            melhorRobo.Item2 = robo.Y;
            
        }

        return (melhorRobo, melhorCaminho);
    }

    private static List<Celula> EncontrarRobos()
    {
        var robos = new List<Celula>();
        for (int i = 0; i < MapaRepository.Mapa.GetLength(0); i++)
        {
            for (int j = 0; j < MapaRepository.Mapa.GetLength(1); j++)
            {
                if (MapaRepository.Mapa[i, j].Robo == "") continue;
                robos.Add(MapaRepository.Mapa[i, j]);
            }
        }

        return robos;
    }
}