using ControladorDeRobos.Enums;

namespace ControladorDeRobos.Models;

public class Celula(Categoria categoria, string valor, bool ehLivre = true)
{
    public bool EhLivre { get; set; } = ehLivre;
    public Categoria Categoria { get; set; } = categoria;
    public string Valor {get; set;} = valor;  //"11", "R1", "X"
    
}