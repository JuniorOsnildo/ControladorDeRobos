using ControladorDeRobos.Services;
using ControladorDeRobos.Services.Buscas;
using Microsoft.AspNetCore.Mvc;

namespace ControladorDeRobos.Controllers;

[ApiController]
[Route("[controller]")]
public class BuscaController(IConfiguration configuracao) : ControllerBase
{
    [HttpGet]
    [Route("/busca/{xEstante:int}/{yEstante:int}")]
    public IActionResult EncontrarRoboECaminho(int xEstante, int yEstante, [FromQuery] string tipoBusca)
    {
       var algoritmo = BuscaFactory.GetAlgoritmo(tipoBusca);
       var (melhorRobo, melhorCaminho) = BuscaService.EncontrarRoboMaisProximo(algoritmo, xEstante, yEstante);
       var caminho =  UtilBusca.OrdemDeMovimentos(melhorCaminho);
       return Ok(new {melhorRobo, caminho});
    }
    
}