using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class PlaylistTrack
{
    public int TrackNo { get; set; }

    public int PlaylistId { get; set; }

    public int SongId { get; set; }

    public virtual Playlist Playlist { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}
