using SalaCine___Backend.Model;

namespace SalaCine___Backend.DTOs
{
    public class PeliculaSalacineDTO
    {
        public string? Mensaje { get; set; }
        public int TotalSalas { get; set; }
        public IEnumerable<PeliculaSalacine>? Salas { get; set; }
    }
}
