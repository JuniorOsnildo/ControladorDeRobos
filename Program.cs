using ControladorDeRobos.Services;
using ControladorDeRobos.Services.Buscas;
using ControladorDeRobos.Services.Buscas.Algoritmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<MapaService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


/*
//TODO: implementar esse Get direito :) 
app.MapGet("/mapa", () =>
{
    var mapa = MapaService.GerarMapa();
    return Results.Ok(mapa);
});

*/

app.Run();