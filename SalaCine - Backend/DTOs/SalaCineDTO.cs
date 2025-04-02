using System.ComponentModel.DataAnnotations;

namespace SalaCine___Backend.DTOs
{
    public class SalaCineDTO
    {
        [Key]
        public int Id_Sala { get; set; }

        public string Nombre { get; set; } = null!;

        public string Estado { get; set; } = null!;
    }
}
