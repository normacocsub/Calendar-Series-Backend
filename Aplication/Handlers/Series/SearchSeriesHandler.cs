using MediatR;
using Aplication.Querys;
using Domain.Entity;
using Aplication.DTOs;
using Infrastructure.Data.Repositories.Interfaces;

namespace Aplication.Handlers;

public class SearchSeriesHandler : IRequestHandler<GetSeriesQuery, List<SerieDTO>>
{
    private readonly ISerieRepository _serieRepository;

    public SearchSeriesHandler(ISerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }

    public async Task<List<SerieDTO>> Handle(
        GetSeriesQuery query,
        CancellationToken cancellationToken
    )
    {
        var serieResponse = await _serieRepository.ConsultarSeries();
        return serieResponse.Select(serie => ConvertToSerieDto(serie)).ToList();
    }

    private static SerieDTO ConvertToSerieDto(Serie serie)
    {
        return new SerieDTO
        {
            Nombre = serie.Nombre,
            Imagen = null, 
            Emision = serie.Emision,
            Capitulos = serie.Capitulos,
            CapitulosVistos = serie.CapitulosVistos,
            DondeVer = serie.DondeVer,
            Observaciones = serie.Observaciones,
            UrlImagen = serie.UrlImagen,
            FechaEmision = serie.FechaEmision
        };
    }
}
