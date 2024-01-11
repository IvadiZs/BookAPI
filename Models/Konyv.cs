using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookAPI.Models;

public partial class Konyv
{
    public Guid Id { get; set; }

    public string? Cim { get; set; }

    public int Oldalszam { get; set; }

    public int Kiadev { get; set; }

    public Guid SzerzoId { get; set; }

    [JsonIgnore]
    public Szerzo? Szerzo { get; set; }
}
