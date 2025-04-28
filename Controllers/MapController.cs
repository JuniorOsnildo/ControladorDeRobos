using ControladorDeRobos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControladorDeRobos.Controllers;

[ApiController]
[Route("[controller]")]
public class MapController(MapaService mapaService, IConfiguration configuracao) : ControllerBase
{
    [HttpGet]
    [Route("/map")]
    public IActionResult GetMapa()
    {
        return Ok();
    }
}