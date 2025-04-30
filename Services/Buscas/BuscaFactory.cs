namespace ControladorDeRobos.Services.Buscas;

using Algoritmos;

public static class BuscaFactory
{
    public static IBuscaCaminho GetAlgoritmo(string nome)
    {
        return nome.ToLower() switch
        {
            "largura" => new Largura(),
            "profundidade" => new Profundidade(),
            "aprofundamento" => new AprofundamentoIterativo(),
            "aestrela" => new Aestrela(),
            _ => throw new ArgumentException("Nome do algoritmo é inválido.")
        };
    }
}