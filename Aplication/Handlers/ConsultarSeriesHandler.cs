using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Querys;
using Domain.Entity;
using Aplication.DTOs;
using Infrastructure.Data.Repositories;

namespace Aplication.Handlers;

public class ConsultarSeriesHandler : IRequestHandler<ObtenerSeriesQuery, List<SerieDTO>>
{
    private readonly ISerieRepository _serieRepository;

    public ConsultarSeriesHandler(ISerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }

    public async Task<List<SerieDTO>> Handle(
        ObtenerSeriesQuery query,
        CancellationToken cancellationToken
    )
    {
        var serieResponse = await _serieRepository.ConsultarSeries();
        return serieResponse.Select(serie => ConvertToSerieDTO(serie)).ToList();
    }

    private SerieDTO ConvertToSerieDTO(Serie serie)
    {
        return new SerieDTO
        {
            Nombre = serie.Nombre,
            Imagen = null, 
            Emision = serie.Emision,
            Capitulos = serie.Capitulos,
            CapitulosVistos = serie.CapitulosVistos,
            DondeVer = serie.DondeVer,
            Observaciones = serie.Observaciones
        };
    }
}
