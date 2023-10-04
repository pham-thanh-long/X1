using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
