using ControladorDeRobos.Models;

namespace ControladorDeRobos.Services.Buscas;

public interface IBuscaCaminho
{
    List<Nodo> Busca(int xInicio, int yInicio, int xFinal, int yFinal); 
}