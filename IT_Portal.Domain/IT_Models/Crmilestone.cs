using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class Crmilestone
{
    public int Id { get; set; }

    public int? Itcrid { get; set; }

    public string? Crcode { get; set; }

    public string? CurrStatus { get; set; }

    public DateTime? RfccreatedDt { get; set; }

    public DateTime? RfcsubmittedDt { get; set; }

    public int? RfcapproverLevel1 { get; set; }

    public DateTime? RfcapproverLevel1Dt { get; set; }

    public int? RfcapproverLevel2 { get; set; }

    public DateTime? RfcapproverLevel2Dt { get; set; }

    public int? Rfcapproved { get; set; }

    public DateTime? RfcapprovedDt { get; set; }

    public DateTime? ImplementedDt { get; set; }

    public int? RelApproverLevel1 { get; set; }

    public DateTime? RelApproverLevel1Dt { get; set; }

    public int? RelApproverLevel2 { get; set; }

    public DateTime? RelApproverLevel2Dt { get; set; }

    public int? RelApproved { get; set; }

    public DateTime? RelApprovedDt { get; set; }

    public int? ReleasedBy { get; set; }

    public DateTime? ReleasedDt { get; set; }

    public int? ColApproverLevel1 { get; set; }

    public DateTime? ColApproverLevel1Dt { get; set; }

    public int? ColApproverLevel2 { get; set; }

    public DateTime? ColApproverLevel2Dt { get; set; }

    public int? ColApproved { get; set; }

    public DateTime? ColApprovedDt { get; set; }

    public int? ClosedBy { get; set; }

    public DateTime? ClosedDt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public virtual ChangeRequest? Itcr { get; set; }
}
