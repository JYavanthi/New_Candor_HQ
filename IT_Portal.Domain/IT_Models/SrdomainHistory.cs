using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class SrdomainHistory
{
    public int SrdhistoryId { get; set; }

    public int? SrdomainId { get; set; }

    public int? Support { get; set; }

    public int? Srid { get; set; }

    public string? DomainName { get; set; }

    public string? Plant { get; set; }

    public string? Department { get; set; }

    public int? NoofUser { get; set; }

    public string? PurPoseDomain { get; set; }

    public DateTime? DueDate { get; set; }

    public string? TypeofSsl { get; set; }

    public int RenewalPeriod { get; set; }

    public string? Justification { get; set; }

    public DateTime? DiscontinuationDate { get; set; }

    public bool? IsActive { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }
}
