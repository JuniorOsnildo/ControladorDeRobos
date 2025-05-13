using ControladorDeRobos.Models;
using ControladorDeRobos.Services;
using ControladorDeRobos.Services.Buscas;
using Microsoft.AspNetCore.Mvc;

namespace ControladorDeRobos.Controllers;

[ApiController]
[Route("[controller]")]
public class RotaController(IConfiguration configuracao) : ControllerBase
{
    [HttpGet]
    [Route("/busca/{xEstante:int}/{yEstante:int}/{tipoBusca}")]
    public IActionResult EncontrarRoboECaminho(int xEstante, int yEstante, string tipoBusca)
    {
        var algoritmo = BuscaFactory.GetAlgoritmo(tipoBusca);
        var (melhorRobo, melhorCaminho) = BuscaService.EncontrarRoboMaisProximo(algoritmo, xEstante, yEstante);
        
        if (melhorCaminho == null) return NotFound();
        
        var rota = RotaService.GerarRotaCompleta(melhorCaminho, xEstante, yEstante);
        return Ok(new {melhorRobo, rota});
    }
}