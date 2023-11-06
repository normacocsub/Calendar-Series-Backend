using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Commands;
using Domain.Entity;
using Infrastructure.Data.Repositories;
using Infrastructure.ExternalServices;

namespace Aplication.Handlers;

public class AgregarSerieHandler : IRequestHandler<AgregarSerieCommand, int>
{
    private readonly ISerieRepository _seriesRepository;
    private readonly IGoogleDriveService _driveService;

    public AgregarSerieHandler(ISerieRepository seriesRepository, IGoogleDriveService driveService)
    {
        _seriesRepository = seriesRepository;
        _driveService = driveService;
    }

    public async Task<int> Handle(
        AgregarSerieCommand request,
        CancellationToken cancellationToken
    )
    {
        var newSerie = new Serie { Nombre = request.Nombre, UrlImagen = "", Emision = request.Emision,
         Capitulos = request.Capitulos, CapitulosVistos = request.CapitulosVistos, DondeVer = request.DondeVer,
          Observaciones = request.Observaciones, FechaEmision = request.FechaEmision};
        newSerie.CalcularFechasEmision();
        if (request.Imagen != null && request.Imagen.Length > 0)
        {
            await using var stream = request.Imagen.OpenReadStream();
            newSerie.UrlImagen = await _driveService.UploadImage(stream, request.Nombre, "1dqOFH-hA2_NReZdWocWUCTJ0ApiLD7kd");
            var serieReponse =  await _seriesRepository.AgregarSerie(newSerie);
            return serieReponse.Id;
        }


        return 0;
    }
}
