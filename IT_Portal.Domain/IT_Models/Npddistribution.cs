namespace IT_Portal.Domain.IT_Models;

public partial class Npddistribution
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

    public string? FinalRecommendation { get; set; }

    public string? Attachments { get; set; }
}
