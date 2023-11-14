using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplication.Querys;
using Aplication.Commands;
using Microsoft.AspNetCore.Authorization;


namespace Controllers;

[Route("api/[Controller]")]
[ApiController]
[Authorize(Policy = "UserOnly")]

public class SerieController : ControllerBase 
{
    private readonly IMediator _mediator;

    public SerieController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // configurar el tema de las credenciales para subir imagenes 
    [HttpPost]
    public async Task<IActionResult> AgregarSerie([FromForm] AddSerieCommand command)
    {
        var serieId = await _mediator.Send(command);
        return Ok(serieId);
    }

    [HttpGet]
    public async Task<IActionResult> ConsultarSeries()
    {
        var seriesReponse = await _mediator.Send(new GetSeriesQuery());
        return Ok(seriesReponse);
    }
}