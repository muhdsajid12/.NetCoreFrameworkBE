using System;
using System.Collections.Generic;

namespace DataLayer;

public partial class DtCredit
{
    public int CreditId { get; set; }

    public int UserId { get; set; }

    public int? Limit { get; set; }
}
