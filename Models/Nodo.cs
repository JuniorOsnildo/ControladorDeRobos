namespace ControladorDeRobos.Models;

public class Nodo(int x, int y, Nodo? pai = null)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y; 
    public Nodo? Pai { get; set; }
}