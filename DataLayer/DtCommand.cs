using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class DtCommand
{
    public int CommandId { get; set; }

    public int UserId { get; set; }

    public string? Message { get; set; }

    public bool? Auto { get; set; }

    public double? IntervalTime { get; set; }

    public string? Receiver { get; set; }

    public DateTime? CommandDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? Deleted { get; set; }
}
