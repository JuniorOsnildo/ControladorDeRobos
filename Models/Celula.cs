using ControladorDeRobos.Enum;

namespace ControladorDeRobos.Models;

public class Celula(int x,int y,EnumObjetos enumObjetos, bool livre = false , string valor = "0")
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public EnumObjetos Objeto { get; set; } = enumObjetos;
    public bool Livre { get; set; } = livre;
    public string valor { get; set; } = valor;
}