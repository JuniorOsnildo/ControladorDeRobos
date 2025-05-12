using System.Text.Json;
using ControladorDeRobos.Models;
using ControladorDeRobos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControladorDeRobos.Controllers;

[ApiController]
[Route("[controller]")]
public class MapController(MapaService mapaService, IConfiguration configuracao) : ControllerBase
{
    [HttpGet]
    [Route("/start")]
    public IActionResult CriarMapa()
    {
        var mapa = MapaService.GerarMapa().Cast<Celula>().ToArray();
        
        return Ok(JsonSerializer.Serialize(mapa));
    }

}