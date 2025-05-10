namespace ControladorDeRobos.Models;

public class Nodo(int x, int y, Nodo? pai = null, int g = 0, int h = 0)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public Nodo? Pai { get; } = pai; 
    //próximos atributos são usados em A* 
    public int G { get; init; } = g;
    public int H { get; init; } = h; 
    public int F => G + H;
}