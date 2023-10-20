namespace Domain.Entity;

public class Serie 
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public string? UrlImagen { get; set; }
    public bool Emision { get; set; }
    public int Capitulos { get; set; }
    public int CapitulosVistos { get; set; }
    public required string DondeVer { get; set; }
    public string? Observaciones { get; set; }
}