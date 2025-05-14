using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;

namespace ControladorDeRobos.Services;

public class MapaService
{
    public void GerarMapa()
    {
        var mapa = new Celula[13, 15];

        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                var valor = MapaRepository.DadosMapa[i, j];

                mapa[i, j] = valor switch
                {
                    " " => new Celula(i, j, EnumObjetos.Fim, true),
                    "-1" => new Celula(i, j, EnumObjetos.Solido),
                    "R" => new Celula(i, j, EnumObjetos.Solido),
                    "" => new Celula(i, j, EnumObjetos.Tile, true),
                    _ => new Celula(i,j, EnumObjetos.Estante, false , valor)
                };
                
            }
        }
        
        MapaRepository.Mapa = mapa;
        
    }
    
}