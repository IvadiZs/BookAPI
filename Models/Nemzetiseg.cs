using System;
using System.Collections.Generic;

namespace BookAPI.Models;

public partial class Nemzetiseg
{
    public Guid Id { get; set; }

    public string? SzerzoNemz { get; set; }

    public virtual ICollection<Szerzo> Szerzos { get; } = new List<Szerzo>();
}
