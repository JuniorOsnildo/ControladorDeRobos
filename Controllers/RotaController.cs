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
        var rota = UtilBusca.OrdemDeMovimentos(
            RotaService.EntregarCaixaERetornar(xEstante, yEstante, MapaService.GerarMapa()));
       return Ok(rota);
    }
}