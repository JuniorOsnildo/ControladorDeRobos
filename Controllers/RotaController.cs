using System.Text.Json;
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
        var intrucao = new Instrucao()
        {
            X = algoritimoDto.X,
            Y = algoritimoDto.Y,
            TipoAlgoritimo = algoritimoDto.TipoBusca
        };
        
        var algoritmo = BuscaFactory.GetAlgoritmo(intrucao.TipoAlgoritimo);
        
        var (melhorRobo, melhorCaminho) =
            BuscaService.EncontrarRoboMaisProximo(algoritmo,intrucao.X, intrucao.Y);
        
        if (melhorCaminho == null) return NotFound();
        if (melhorRobo.Id == "-1") return NotFound("Robot not Found");
        
        var rota = RotaService.GerarRotaCompleta(melhorCaminho, intrucao.X, intrucao.Y);

        var melhorRoboJson = JsonSerializer.Serialize(melhorRobo);
        
        var result = rota.Select(t => new { t.x, t.y });
        var rotaJson = JsonSerializer.Serialize(result);
        
        return Ok(new {melhorRoboJson, rotaJson});
    }
}