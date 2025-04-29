namespace ControladorDeRobos.Models;

public class Celula(int x, int y, bool livre = true)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public bool Livre { get; set; }
}