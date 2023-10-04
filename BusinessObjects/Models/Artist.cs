﻿using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Artist
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Country { get; set; }

    public string? Image { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    public virtual ICollection<Follow> Follows { get; set; } = new List<Follow>();

    public virtual ICollection<PerformsOnSong> PerformsOnSongs { get; set; } = new List<PerformsOnSong>();
}
