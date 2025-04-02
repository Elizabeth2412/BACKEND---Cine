using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SalaCine___Backend.Model;

public partial class SalaCine
{
    public int Id_Sala { get; set; }

    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<PeliculaSalacine> PeliculaSalacines { get; set; } = new List<PeliculaSalacine>();
}
