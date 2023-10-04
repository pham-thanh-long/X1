using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Song
{
    public int Id { get; set; }

    public string FileId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public string? Image { get; set; }

    public string? Image2 { get; set; }

    public int ListenCount { get; set; }

    public int AlbumId { get; set; }

    public virtual Album Album { get; set; } = null!;

    public virtual ICollection<PerformsOnSong> PerformsOnSongs { get; set; } = new List<PerformsOnSong>();

    public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new List<PlaylistTrack>();

    public virtual ICollection<SongGenre> SongGenres { get; set; } = new List<SongGenre>();
}
