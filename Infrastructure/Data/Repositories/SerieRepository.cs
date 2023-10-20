using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Infrastructure.Data.Context;

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
}
