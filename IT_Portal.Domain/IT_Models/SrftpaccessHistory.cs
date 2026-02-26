using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class SrftpaccessHistory
{
    public int Srftphid { get; set; }

    public int? Srid { get; set; }

    public int? SupportId { get; set; }

    public int? Srftpaid { get; set; }

    public string? ReqType { get; set; }

    public int? AccessRequire { get; set; }

    public string? AccessType { get; set; }

    public string? AccessPath { get; set; }

    public string? Description { get; set; }

    public string? OwnerEmail { get; set; }

    public string? OwnerPlant { get; set; }

    public string? EmpType { get; set; }

    public string? Justification { get; set; }

    public string? Attachment { get; set; }

    public bool? IsActive { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }
}
