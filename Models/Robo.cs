using ControladorDeRobos.Enum;

namespace ControladorDeRobos.Models;

public class Robo(int x, int y, EnumObjetos enumObjeto, string valor = "")
{
    public int X { get; set;  } = x;
    public int Y { get; set;  } = y;
    public EnumObjetos Objeto { get; set; } = enumObjeto;
    public string Id { get; } = valor;
    
    public Robo ShallowCopy()
    {
        return (Robo)MemberwiseClone();
    }
}