using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class DtCommandGroup
{
    public int CommandGroupId { get; set; }

    public int CommandId { get; set; }

    public string? ContactList { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreateadDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool? Deleted { get; set; }
}
