using ControladorDeRobos.Controllers;
using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;
using ControladorDeRobos.Services.Buscas;

namespace ControladorDeRobos.Services;

public static class BuscaService
{
    public static (Robo melhorRobo, List<Nodo>? melhorCaminho) EncontrarRoboMaisProximo(IBuscaCaminho algoritmo
        , int xEstante, int yEstante)
    {
        var listaRobos = RoboRepository.Robos;
        Robo melhorRobo = new Robo(0,0, EnumObjetos.Robo,"0");
        List<Nodo>? melhorCaminho = null;

        foreach (var robo in listaRobos)
        {
            var caminho = algoritmo.Busca(robo.X, robo.Y, xEstante, yEstante);

            if (caminho.Count == 0) continue;
            if (melhorCaminho == null || caminho.Count >= melhorCaminho.Count) continue;

            melhorCaminho = caminho;
            melhorRobo = robo.ShallowCopy();
            robo.X = xEstante;
            robo.Y = yEstante;
        }

        return (melhorRobo, melhorCaminho);
    }
}