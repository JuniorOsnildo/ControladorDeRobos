using System.Text.Json;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;
using ControladorDeRobos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControladorDeRobos.Controllers;

[ApiController]
[Route("[controller]")]
public class MapController(IConfiguration configuracao) : ControllerBase
{
    [HttpGet]
    [Route("/start")]
    public IActionResult CriarMapa()
    {
        var mapa = MapaRepository.Mapa.Cast<Celula>().ToArray();
        
        return Ok(JsonSerializer.Serialize(mapa));
    }
    
    [HttpGet]
    [Route("/start-robots")]
    public IActionResult IniciarRobos()
    {
        var robos = RoboRepository.Robos;
        
        return Ok(JsonSerializer.Serialize(robos));
    }

    [HttpGet]
    [Route("/reset")]
    public IActionResult reset()
    {
        RoboSevice.PosicionarRobos();
        var robos = RoboRepository.Robos;
        
        return Ok(JsonSerializer.Serialize(robos));
    }
    
}