using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Infrastructure.Data.Repositories;

public interface ISerieRepository
{
    Task<Serie> AgregarSerie(Serie serie);
    Task<List<Serie>> ConsultarSeries();
}