using System.Text.Json;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;
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
        MapaService mapaService = new MapaService();
        mapaService.GerarMapa();
        var mapa = MapaRepository.Mapa.Cast<Celula>().ToArray();
        
        return Ok(JsonSerializer.Serialize(mapa));
    }
    
    [HttpGet]
    [Route("/start-robots")]
    public IActionResult IniciarRobos()
    {
        RoboSevice roboSevice = new RoboSevice();
        roboSevice.PosicionarRobos();
        var robos = RoboRepository.Robos;
        
        return Ok(JsonSerializer.Serialize(robos));
    }

}