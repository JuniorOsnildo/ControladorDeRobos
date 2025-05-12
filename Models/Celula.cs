namespace ControladorDeRobos.Models;

public class Celula(int x, int y, bool livre = true, string robo = "")
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public bool Livre { get; set; } = livre;
    public string Robo { get; } = robo;
}