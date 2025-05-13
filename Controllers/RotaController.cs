using ControladorDeRobos.DTOs;
using ControladorDeRobos.Models;
using ControladorDeRobos.Services;
using ControladorDeRobos.Services.Buscas;
using Microsoft.AspNetCore.Mvc;

namespace ControladorDeRobos.Controllers;

[ApiController]
[Route("[controller]")]
public class RotaController(IConfiguration configuracao) : ControllerBase
{
    [HttpPost]
    [Route("/busca")]
    public IActionResult EncontrarRoboECaminho([FromBody] AlgoritimoDto algoritimoDto)
    {
        
        
        var algoritmo = BuscaFactory.GetAlgoritmo(algoritimoDto.TipoBusca);
        var (melhorRobo, melhorCaminho) = BuscaService.EncontrarRoboMaisProximo(algoritmo, algoritimoDto.X, algoritimoDto.Y);
        
        if (melhorCaminho == null) return NotFound();
        
        var rota = RotaService.GerarRotaCompleta(melhorCaminho, algoritimoDto.X, algoritimoDto.Y);
        return Ok(new {melhorRobo, rota});
    }
}