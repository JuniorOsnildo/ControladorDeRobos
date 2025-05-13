using ControladorDeRobos.Controllers;
using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;
using ControladorDeRobos.Services.Buscas;

namespace ControladorDeRobos.Services;

public static class BuscaService
{
    public static (Robo melhorRobo, List<Nodo>? melhorCaminho) EncontrarRoboMaisProximo
        (IBuscaCaminho algoritmo, int xEstante, int yEstante)
    {
        var listaRobos = RoboRepository.Robos;
        Robo melhorRobo = new Robo(12, 0, EnumObjetos.Robo,"-1");
        List<Nodo>? melhorCaminho = [];
        var melhorDistancia = Int32.MaxValue;
        
        foreach (var robo in listaRobos)
        {
            var caminho = algoritmo.Busca(robo.X, robo.Y, xEstante, yEstante);
            
            if (caminho.Count == 0) continue;
            if (caminho.Count >= melhorDistancia) continue;
            
            melhorDistancia = melhorCaminho.Count;
            melhorCaminho = caminho;
            
            melhorRobo = robo.ShallowCopy();
            melhorRobo.X = xEstante;
            melhorRobo.Y = yEstante;
        }

        return (melhorRobo, melhorCaminho);
    }
}