using ControladorDeRobos.Enum;

namespace ControladorDeRobos.Models;

public class Robo(int y,int x, EnumObjetos enumObjeto, string valor = "")
{
    public int X { get; set;  } = x;
    public int Y { get; set;  } = y;
    public EnumObjetos Objeto { get; set; } = enumObjeto;
    public string Id { get; set; } = valor;
    
    public Robo ShallowCopy()
    {
        return (Robo)MemberwiseClone();
    }
}