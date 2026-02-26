using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwSrapprovedDat
{
    public int SrapproverId { get; set; }

    public int PlantId { get; set; }

    public int Srid { get; set; }

    public string? SupportId { get; set; }

    public int ApproverLevel { get; set; }

    public string? Stage { get; set; }

    public int? ApproverId { get; set; }

    public DateTime ApprovedDt { get; set; }

    public string? Remarks { get; set; }

    public string Status { get; set; } = null!;

    public string? Attachment { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public string? CreatedByName { get; set; }

    public string? CreatedByEmail { get; set; }
}
