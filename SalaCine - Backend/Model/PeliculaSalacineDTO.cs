namespace SalaCine___Backend.Model
{
    public class PeliculaSalacineDTO
    {
        public string? Mensaje { get; set; }
        public int TotalSalas { get; set; }
        public IEnumerable<PeliculaSalacine>? Salas { get; set; }
    }
}
