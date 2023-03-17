using System;
using System.Collections.Generic;

namespace testASP.Models;

public partial class Brand1
{
    public int BrandId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Beer1> Beer1s { get; } = new List<Beer1>();
}
