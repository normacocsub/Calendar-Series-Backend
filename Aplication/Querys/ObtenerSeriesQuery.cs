using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.DTOs;

namespace Aplication.Querys;

public record ObtenerSeriesQuery() : IRequest<List<SerieDTO>>;