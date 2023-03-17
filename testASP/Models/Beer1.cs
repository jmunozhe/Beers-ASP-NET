using System;
using System.Collections.Generic;

namespace testASP.Models;

public partial class Beer1
{
    public int BeerId { get; set; }

    public string? Name { get; set; }

    public int BrandId { get; set; }

    public virtual Brand1 Brand { get; set; } = null!;
}
