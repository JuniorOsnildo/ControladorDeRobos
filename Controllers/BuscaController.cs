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
       
       return Ok(new {melhorRobo, melhorCaminho}); //passar melhorCaminho para RotaController
    }
    
}