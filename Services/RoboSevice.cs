using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;

namespace ControladorDeRobos.Services;

public class RoboSevice
{
    public void PosicionarRobos()
    {
        Robo[] robos = new Robo[5];

        for (int i = 0; i < 5; i++) robos[i] = new Robo(12, i, EnumObjetos.Robo, $"R{i}");
        
        RoboRepository.Robos = robos;
    }
}