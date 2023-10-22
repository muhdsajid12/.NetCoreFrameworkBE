using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class DtUserContact
{
    public int UserContactId { get; set; }

    public int UserId { get; set; }

    public string? ContactNo { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool? Deleted { get; set; }
}
