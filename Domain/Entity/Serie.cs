namespace Domain.Entity;

public class Serie 
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public string? UrlImagen { get; set; }
    public bool Emision { get; set; }
    public DateTime? FechaEmision { get; set; }
    public int Capitulos { get; set; }
    public int CapitulosVistos { get; set; }
    public required string DondeVer { get; set; }
    public string? Observaciones { get; set; }
    public List<EmisionSerie> EmisionSerie { get; set; }


    public Serie()
    {
        EmisionSerie = new List<EmisionSerie>();
    }

    public List<EmisionSerie> CalcularFechasEmision() 
    {
        
        if (FechaEmision == null) return EmisionSerie;
        EmisionSerie.Add(AgregarSerieEmision(FechaEmision ?? DateTime.MinValue));
        var fecha = FechaEmision ?? DateTime.MinValue;
        for (int i = 0; i < Capitulos; i++)
        {
            fecha = AumentarFechaEmision(fecha);
            EmisionSerie.Add(AgregarSerieEmision(fecha));
        }
        return EmisionSerie;
    }

    private EmisionSerie AgregarSerieEmision(DateTime fecha)
    {
        return new EmisionSerie()
        {
            Serie = this,
            FechaEmision = fecha
        };
    }

    private DateTime AumentarFechaEmision(DateTime fecha) 
    {
        int daysToNextCap = 7 - (int)fecha.DayOfWeek;
        return fecha.AddDays(daysToNextCap);
    }
}