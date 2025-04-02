using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SalaCine___Backend.Model;

public partial class Pelicula
{
    public int Id_Pelicula { get; set; }

    public string Nombre { get; set; } = null!;

    public TimeOnly Duracion { get; set; }

    [JsonIgnore]
    public virtual ICollection<PeliculaSalacine> PeliculaSalacines { get; set; } = new List<PeliculaSalacine>();
}
