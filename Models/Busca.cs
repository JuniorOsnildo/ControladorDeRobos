using ControladorDeRobos.Services;

namespace ControladorDeRobos.Models;

public class Busca
{
    private Nodo[,] mapa = MapaService.GerarMapa();
    
    public void AlgoritimoDeProfundiade(int x, int y)
    {
        var tupla = (new List<int>(), new List<int>());
        
        
    }
}