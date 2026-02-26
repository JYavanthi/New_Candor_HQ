using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class Reference
{
    public int ReferenceId { get; set; }

    public string? ReferenceName { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
