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
            Robo melhorRobo = RoboRepository.Robos[0];
            List<Nodo>? melhorCaminho = [];
            var melhorDistancia = Int32.MaxValue;
            
            foreach (var robo in listaRobos)
            {
                var caminho = algoritmo.Busca(robo.X, robo.Y, xEstante, yEstante);
                
                if (caminho.Count == 0) continue;
                if (caminho.Count >= melhorDistancia) continue;
                
                melhorCaminho = caminho;
                melhorDistancia = melhorCaminho.Count;
                
                melhorRobo = robo.ShallowCopy();

                robo.X = xEstante;
                robo.Y = yEstante;
            }

            return (melhorRobo, melhorCaminho);
        }
    }