using Microsoft.AspNetCore.Http;

namespace Aplication.DTOs;

public class SerieDTO 
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