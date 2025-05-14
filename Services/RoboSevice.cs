using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;

namespace ControladorDeRobos.Services;

public static class RoboSevice
{
    public static void PosicionarRobos()
    {
        Robo[] robos = new Robo[5];

        for (int i = 0; i < 5; i++) robos[i] = new Robo(12, i, EnumObjetos.Robo, $"R{i}");
        
        RoboRepository.Robos = robos;
    }
    
    public static bool TemRobo(int x, int y) => RoboRepository.Robos.Any(r => r.X == x && r.Y == y);
    
}