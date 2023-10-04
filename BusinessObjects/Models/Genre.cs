using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Genre
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AlbumGenre> AlbumGenres { get; set; } = new List<AlbumGenre>();

    public virtual ICollection<SongGenre> SongGenres { get; set; } = new List<SongGenre>();
}
