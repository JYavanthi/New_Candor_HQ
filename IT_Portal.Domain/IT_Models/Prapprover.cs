using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class Prapprover
{
    public int PrapproverId { get; set; }

    public int Prid { get; set; }

    public int ApproverLevel { get; set; }

    public string? Stage { get; set; }

    public int? EmpId { get; set; }

    public DateTime ApprovedDt { get; set; }

    public string? Remarks { get; set; }

    public int? AttachmentId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
