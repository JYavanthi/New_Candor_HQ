using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class Srvirtual
{
    public int Srvmid { get; set; }

    public int Srid { get; set; }

    public int? SupportId { get; set; }

    public string? RequestType { get; set; }

    public string? EmailId { get; set; }

    public string? NoParticipants { get; set; }

    public DateTime? StartDt { get; set; }

    public DateTime? EndDt { get; set; }

    public int? Location { get; set; }

    public string? Department { get; set; }

    public string? Justification { get; set; }

    public string? Attachment { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
