namespace IT_Portal.Domain.IT_Models;

public partial class Npdcqa
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public string ResponsibleEmployeeId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? CeilingPriceStatus { get; set; }

    public string? RequiresDcgipermission { get; set; }

    public string? CoveredUnderBannedDrugs { get; set; }

    public string? LocalFdalicense { get; set; }

    public string? ProductLicenseRequirements { get; set; }

    public int? Dcgirequirement { get; set; }

    public string? AnyOtherLicenseRequirement { get; set; }

    public string? Cqacost { get; set; }

    public string? FinalRecommendation { get; set; }

    public string? Timeline { get; set; }

    public string? Attachments { get; set; }
}
