using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwEmailGroup
{
    public int EmailGroupId { get; set; }

    public string? EmailGroupName { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? MidifiedDt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }
}
