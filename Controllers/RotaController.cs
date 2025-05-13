using ControladorDeRobos.Models;
using ControladorDeRobos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControladorDeRobos.Controllers;

[ApiController]
[Route("[controller]")]
public class RotaController(IConfiguration configuracao) : ControllerBase
{
    [HttpGet]
    //[Route("/busca/{xEstante:int}/{yEstante:int}")]
    public IActionResult EncontrarRoboECaminho(List<Nodo> busca, int xEstante, int yEstante)
    {
        var rota = RotaService.GerarRotaCompleta(busca, xEstante, yEstante);
       return Ok(rota);
    }
}