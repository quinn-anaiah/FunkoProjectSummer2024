using System;
using System.Collections.Generic;

namespace MyFunkoApi.Models;

public partial class Material
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<FunkoPop> FunkoPops { get; set; } = new List<FunkoPop>();
}
