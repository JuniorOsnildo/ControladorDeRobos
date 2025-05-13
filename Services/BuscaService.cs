using ControladorDeRobos.Controllers;
using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;
using ControladorDeRobos.Services.Buscas;

namespace ControladorDeRobos.Services;

public static class BuscaService
{
    public static ((int, int) melhorRobo, List<Nodo>? melhorCaminho) EncontrarRoboMaisProximo(IBuscaCaminho algoritmo
        , int xEstante, int yEstante)
    {
        var listaRobos = RoboRepository.Robos;
        var melhorRobo = (1,2);
        List<Nodo>? melhorCaminho = null;

        foreach (var robo in listaRobos)
        {
            var caminho = algoritmo.Busca(robo.X, robo.Y, xEstante, yEstante);

            if (caminho.Count == 0) continue;
            if (melhorCaminho == null || caminho.Count >= melhorCaminho.Count) continue;

            melhorCaminho = caminho;
            melhorRobo.Item1 = robo.X;
            melhorRobo.Item2 = robo.Y;
            
        }

        return (melhorRobo, melhorCaminho);
    }
}