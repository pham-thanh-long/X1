using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Album
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? Image { get; set; }

    public int ArtistId { get; set; }

    public virtual ICollection<AlbumGenre> AlbumGenres { get; set; } = new List<AlbumGenre>();

    public virtual Artist Artist { get; set; } = null!;

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
