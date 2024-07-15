using System;
using System.Collections.Generic;

namespace MyFunkoApi.Models;

public partial class FunkoPop
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ModelNumber { get; set; }

    public int SeriesId { get; set; }

    public int CategoryId { get; set; }

    public int? EditionId { get; set; }

    public int MaterialsId { get; set; }

    public int? ExclusiveStoreId { get; set; }

    public bool Owned { get; set; }

    public bool Gift { get; set; }

    public decimal? OriginalPrice { get; set; }

    public decimal? CurrentAvgPrice { get; set; }

    public decimal? MaxPrice { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public bool BobbleHead { get; set; }

    public DateOnly? DateAcquired { get; set; }

    public int? Count { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Edition? Edition { get; set; }

    public virtual ExclusiveStore? ExclusiveStore { get; set; }

    public virtual Material Materials { get; set; } = null!;

    public virtual Series Series { get; set; } = null!;
}
