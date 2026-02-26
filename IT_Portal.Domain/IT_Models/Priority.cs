using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class Priority
{
    public int PriorityId { get; set; }

    public string PriorityName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
