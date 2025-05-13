using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;
using ControladorDeRobos.Services.Buscas;

namespace ControladorDeRobos.Services;

public static class RotaService
{
    public static List<Nodo> EntregarCaixaERetornar(int xEstante, int yEstante, Celula[,] mapa)
    {
        //caminho até o X
        var caminhoIda = new List<Nodo>();
        var atual = mapa[xEstante, yEstante];
        caminhoIda.Add(new Nodo(atual.X, atual.Y));

        //vai para a direita no corredor (ou esquerda se bloqueado)
        atual = mapa[atual.X, atual.Y + 1].Objeto == EnumObjetos.Livre && UtilBusca.EstaDentroDoMapa(atual.X, atual.Y + 1)
            ? mapa[atual.X, atual.Y + 1]  //direita
            : mapa[atual.X, atual.Y - 1]; //esquerda
        
        caminhoIda.Add(new Nodo(atual.X, atual.Y));

        //desce até penúltima linha
        while (atual.X < mapa.GetLength(0) - 2)
        {
            atual = mapa[atual.X + 1, atual.Y];
            caminhoIda.Add(new Nodo(atual.X, atual.Y));
        }
        
        //vai até última coluna (direita)
        while (atual.Y < mapa.GetLength(1) - 1)
        {
            atual = mapa[atual.X, atual.Y + 1];
            caminhoIda.Add(new Nodo(atual.X, atual.Y));    
        } 
        
        //inverte caminho para voltar até estante
        var caminhoVolta = caminhoIda.ToList();
        caminhoVolta.Reverse();
        
        //junta os 2 caminhos e retorna 
        var caminhoCompleto = new List<Nodo>();
        caminhoCompleto.AddRange(caminhoIda);   //ida
        caminhoCompleto.AddRange(caminhoVolta); //volta
        
        return caminhoCompleto;
    }
    
}