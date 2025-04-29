using ControladorDeRobos.Enums;

namespace ControladorDeRobos.Models;

public class Celula(Categoria categoria, string id, int x, int y)
{
    public string Id { get; set; }
    public Categoria Tipo { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}