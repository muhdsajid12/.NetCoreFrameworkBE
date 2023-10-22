using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class DtUser
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Token { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Deleted { get; set; }
}
