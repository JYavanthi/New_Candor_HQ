using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class SrwifiaccessHistory
{
    public int Srwhid { get; set; }

    public int? Srid { get; set; }

    public int? SupportId { get; set; }

    public int? Srwifiid { get; set; }

    public string? RequestType { get; set; }

    public string? SpecifyPlant { get; set; }

    public string? Location { get; set; }

    public string? SpecifyOffice { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string? Attachment { get; set; }

    public string? Justification { get; set; }

    public string? Description { get; set; }

    public bool? Isactive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
