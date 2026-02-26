using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class SrrestorationAccess
{
    public int? Srid { get; set; }

    public int? SupportId { get; set; }

    public int Srrid { get; set; }

    public string? RequestType { get; set; }

    public string? Ots { get; set; }

    public string? Descriptions { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? Date { get; set; }

    public DateTime? EndDate { get; set; }

    public string? ProvideDescription { get; set; }

    public string? TransferingData { get; set; }

    public DateTime? Restoration { get; set; }

    public string? Attachment { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
