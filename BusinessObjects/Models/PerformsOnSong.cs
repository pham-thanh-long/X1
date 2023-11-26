using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class PerformsOnSong
{
    public int SongId { get; set; }

    public int ArtistId { get; set; }

    public bool IsMainArtist { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
