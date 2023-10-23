namespace Domain.Entity;


public class EmisionSerie 
{
    public int Id { get; set; }
    public int SerieId { get; set; }
    public required DateTime FechaEmision { get; set; }
    public Serie? Serie { get; set; }
}