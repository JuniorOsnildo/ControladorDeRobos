using ControladorDeRobos.Services;
using ControladorDeRobos.Services.Buscas;
using Microsoft.AspNetCore.Mvc;

namespace ControladorDeRobos.Controllers;

[ApiController]
[Route("[controller]")]
public class RotaController(IConfiguration configuracao) : ControllerBase
{
    [HttpGet]
    //[Route("/busca/{xEstante:int}/{yEstante:int}")]
    public IActionResult EncontrarRoboECaminho(int xEstante, int yEstante)
    {
       var rota = RotaService.EntregarCaixaERetornar(xEstante, yEstante, MapaService.GerarMapa());
       if (rota.Count == 0) return NotFound("Rota não gerada");
       return Ok(rota);
    }
}