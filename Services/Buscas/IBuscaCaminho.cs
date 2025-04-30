using ControladorDeRobos.Models;

namespace ControladorDeRobos.Services.Buscas;

public interface IBuscaCaminho
{
    List<Nodo> Busca(Celula[,] mapa, int xInicio, int yInicio, int xFinal, int yFinal); 
}