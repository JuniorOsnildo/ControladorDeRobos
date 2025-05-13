using ControladorDeRobos.Enum;

namespace ControladorDeRobos.Models;

public class Robo(int y,int x, EnumObjetos enumObjeto, string valor = "")
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public EnumObjetos Objeto { get; set; } = enumObjeto;
    public string Id { get; set; } = valor;
}