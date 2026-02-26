using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class VwChecklist
{
    public int ItchecklistId { get; set; }

    public int? PlantId { get; set; }

    public string? Plantname { get; set; }

    public string Status { get; set; } = null!;

    public int SupportId { get; set; }

    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public int ClassificationId { get; set; }

    public string? ClassificationName { get; set; }

    public string ChecklistTitle { get; set; } = null!;

    public string ChecklistDesc { get; set; } = null!;

    public bool? MandatoryFlag { get; set; }

    public int? ApproverId { get; set; }

    public string? Approvername { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
