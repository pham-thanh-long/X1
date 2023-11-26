using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models;

public partial class Genre
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AlbumGenre> AlbumGenres { get; set; } = new List<AlbumGenre>();

    public virtual ICollection<SongGenre> SongGenres { get; set; } = new List<SongGenre>();
}
