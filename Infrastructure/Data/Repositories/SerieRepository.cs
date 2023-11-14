using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Interfaces;

namespace Infrastructure.Data.Repositories;

public class SerieRepository : ISerieRepository 
{
    private readonly CalendarSerieContext _context;

    public SerieRepository(CalendarSerieContext context)
    {
        _context = context;
    }

    public async Task<Serie> AgregarSerie(Serie serie)
    {
        await _context.AddAsync(serie);
        await _context.SaveChangesAsync();
        return serie;
    }

    public async Task<List<Serie>> ConsultarSeries()
    {
        var seriesResponse = await _context.Series.ToListAsync();
        return seriesResponse;
    }
}
