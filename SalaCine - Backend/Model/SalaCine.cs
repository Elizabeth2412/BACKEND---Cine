using System;
using System.Collections.Generic;

namespace SalaCine___Backend.Model;

public partial class SalaCine
{
    public int IdSala { get; set; }

    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<PeliculaSalacine> PeliculaSalacines { get; set; } = new List<PeliculaSalacine>();
}
