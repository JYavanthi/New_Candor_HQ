namespace IT_Portal.Domain.IT_Models;

public partial class Npdmedical
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public string ResponsibleEmployeeId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? AssignedTo { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ProductInformation { get; set; }

    public string? TherapeuticUseCases { get; set; }

    public string? Advantages { get; set; }

    public string? Disadvantages { get; set; }

    public string? ScopeAndRecommendation { get; set; }

    public string? DcgiapprovalStatus { get; set; }

    public int? RouteOfApproval { get; set; }

    public int? TimelineForApproval { get; set; }

    public string? TimelineUnit { get; set; }

    public int? DcgiapprovalCost { get; set; }

    public string? FinalRecommendation { get; set; }

    public string? Attachments { get; set; }
}
