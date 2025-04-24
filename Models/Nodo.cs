using ControladorDeRobos.Enums;

namespace ControladorDeRobos.Models;

public class Nodo(Categoria categoria, string id, int x, int y)
{
    private string ID { get; set; }
    private Categoria tipo { get; set; }
    private int x { get; set; }
    private int y { get; set; }
}