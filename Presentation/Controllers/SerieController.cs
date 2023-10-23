using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplication.Querys;
using Aplication.Commands;


namespace Controllers;

[Route("api/[Controller]")]
[ApiController]

public class SerieController : ControllerBase 
{
    private readonly IMediator _mediator;

    public SerieController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // configurar el tema de las credenciales para subir imagenes 
    [HttpPost]
    public async Task<IActionResult> AgregarSerie([FromBody] AgregarSerieCommand command)
    {
        var serieId = await _mediator.Send(command);
        return Ok(serieId);
    }

    [HttpGet]
    public async Task<IActionResult> ConsultarSeries()
    {
        var seriesReponse = await _mediator.Send(new ObtenerSeriesQuery());
        return Ok(seriesReponse);
    }
}