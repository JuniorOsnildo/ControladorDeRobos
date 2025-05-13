using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;
using ControladorDeRobos.Services.Buscas;

namespace ControladorDeRobos.Services;

public static class RotaService
{
    public static (int x, int y)[] GerarRotaCompleta(List<Nodo> busca, int xEstante, int yEstante)
    {
        var caminho = new List<Nodo>();
        caminho.AddRange(busca); 
        caminho.AddRange(EntregarCaixaERetornar(xEstante, yEstante));
        
        return OrdemDeMovimentos(caminho);
    }

    private static List<Nodo> EntregarCaixaERetornar(int xEstante, int yEstante)
    {
        //caminho até o X
        var caminhoIda = new List<Nodo>();
        var atual = MapaRepository.Mapa[xEstante, yEstante];
        caminhoIda.Add(new Nodo(atual.X, atual.Y));

        //vai para a direita no corredor (ou esquerda se bloqueado)
        atual = MapaRepository.Mapa[atual.X, atual.Y + 1].Objeto == EnumObjetos.Livre &&
                UtilBusca.EstaDentroDoMapa(atual.X, atual.Y + 1)
            ? MapaRepository.Mapa[atual.X, atual.Y + 1] //direita
            : MapaRepository.Mapa[atual.X, atual.Y - 1]; //esquerda
        caminhoIda.Add(new Nodo(atual.X, atual.Y));

        //desce até penúltima linha
        while (atual.X < MapaRepository.Mapa.GetLength(0) - 2)
        {
            atual = MapaRepository.Mapa[atual.X + 1, atual.Y];
            caminhoIda.Add(new Nodo(atual.X, atual.Y));
        }

        //vai até última coluna (direita)
        while (atual.Y < MapaRepository.Mapa.GetLength(1) - 1)
        {
            atual = MapaRepository.Mapa[atual.X, atual.Y + 1];
            caminhoIda.Add(new Nodo(atual.X, atual.Y));
        }

        //inverte caminho para voltar até estante
        var caminhoVolta = caminhoIda.ToList();
        caminhoVolta.Reverse();

        //junta os 2 caminhos e retorna 
        var caminhoCompleto = new List<Nodo>();
        caminhoCompleto.AddRange(caminhoIda); //ida
        caminhoCompleto.AddRange(caminhoVolta); //volta

        return caminhoCompleto;
    }

    private static (int x, int y)[] OrdemDeMovimentos(List<Nodo>? nodos)
    {
        if (nodos == null) return [];
        
        (int, int)[] movimentos = new (int, int)[nodos.Count - 1];

        for (int i = 0; i < nodos.Count - 1; i++)
        {
            movimentos[i] = (nodos[i + 1].X - nodos[i].X, nodos[i + 1].Y - nodos[i].Y);
        }

        return movimentos;

    }
}