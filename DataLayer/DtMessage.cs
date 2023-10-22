using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class DtMessage
{
    public int CommandId { get; set; }

    public string? Message { get; set; }

    public bool? Auto { get; set; }

    public DateTime? IntervalTime { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool? Deleted { get; set; }
}
