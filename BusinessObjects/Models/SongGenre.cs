using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class SongGenre
{
    public int SongId { get; set; }

    public int GenreId { get; set; }

    public string? Description { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
