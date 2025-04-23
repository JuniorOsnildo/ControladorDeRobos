using ControladorDeRobos.Enums;

namespace ControladorDeRobos.Models;

public class Nodo(Categoria categoria, string id)
{
    private string ID { get; set; }
    private Categoria tipo { get; set; }
    private int x { get; set; }
    private int y { get; set; }
}