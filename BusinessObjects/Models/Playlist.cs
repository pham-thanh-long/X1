using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Playlist
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new List<PlaylistTrack>();

    public virtual User User { get; set; } = null!;
}
