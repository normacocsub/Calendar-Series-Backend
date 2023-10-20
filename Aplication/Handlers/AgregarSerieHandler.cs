using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Commands;
using Domain.Entity;
using Infrastructure.Data.Repositories;

namespace Aplication.Handlers;

public class AgregarSerieHandler : IRequestHandler<AgregarSerieCommand, int>
{
    private readonly ISerieRepository _serieRepository;

    public AgregarSerieHandler(ISerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }

    public async Task<int> Handle(
        AgregarSerieCommand request,
        CancellationToken cancellationToken
    )
    {
        var nuevaSerie = new Serie { Nombre = request.Nombre, UrlImagen = "", Emision = request.Emision,
         Capitulos = request.Capitulos, CapitulosVistos = request.CapitulosVistos, DondeVer = request.DondeVer,
          Observaciones = request.Observaciones};

        var serieReponse =  await _serieRepository.AgregarSerie(nuevaSerie);

        return serieReponse.Id;
    }
}
