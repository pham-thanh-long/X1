using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Follow
{
    public int UserId { get; set; }

    public int ArtistId { get; set; }

    public byte[] Timestamp { get; set; } = null!;

    public virtual Artist Artist { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
