using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookAPI.Models;

public partial class Szerzo
{
    public Guid Id { get; set; }

    public string? Nev { get; set; }

    public string? Nem { get; set; }

    public Guid NemzId { get; set; }

    public virtual ICollection<Konyv> Konyvs { get; } = new List<Konyv>();

    [JsonIgnore]
    public virtual Nemzetiseg? Nemz { get; set; }
}
