namespace SalaCine___Backend.DTOs
{
    public class PeliculaDTO
    {
        public int Id_Pelicula { get; set; }

        public string Nombre { get; set; } = null!;

        public TimeOnly Duracion { get; set; }
    }
}
