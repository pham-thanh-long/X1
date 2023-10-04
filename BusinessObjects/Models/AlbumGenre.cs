using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class AlbumGenre
{
    public int AlbumId { get; set; }

    public int GenreId { get; set; }

    public string? Description { get; set; }

    public virtual Album Album { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;
}
