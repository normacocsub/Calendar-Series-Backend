using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Aplication.Commands;

public class AgregarSerieCommand : IRequest<int>
{
    public required string Nombre { get; set; }
    public IFormFile? Imagen { get; set; }
    public bool Emision { get; set; }
    public DateTime? FechaEmision { get; set; }
    public int Capitulos { get; set; }
    public int CapitulosVistos { get; set; }
    public required string DondeVer { get; set; }
    public string? Observaciones { get; set; }
}