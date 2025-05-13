using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;

namespace ControladorDeRobos.Services;

public class MapaService
{
    public static void GerarMapa()
    {
        var mapa = new Celula[13, 15];

        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                var valor = MapaRepository.DadosMapa[i, j];

                mapa[i, j] = valor switch
                {
                    " " => new Celula(i, j, EnumObjetos.Fim),
                    "-1" => new Celula(i, j, EnumObjetos.Solido),
                    "R" => new Celula(i, j, EnumObjetos.Solido),
                    "" => new Celula(i, j, EnumObjetos.Livre),
                    _ => new Celula(i,j, EnumObjetos.Estante, valor)
                };
                
            }
        }
        
        MapaRepository.Mapa = mapa;
        
    }

    public static void PosicionarRobos()
    {
        Robo[] robos = new Robo[5];

        for (int i = 0; i < 5; i++) robos[0] = new Robo(12, i, EnumObjetos.Solido, $"R{i}");
        
        RoboRepository.Robos = robos;
    }
    
}