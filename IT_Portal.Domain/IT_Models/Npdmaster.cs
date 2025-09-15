namespace IT_Portal.Domain.IT_Models;

public partial class Npdmaster
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public string Pbnumber { get; set; } = null!;

    public string ResponsibleEmployeeId { get; set; } = null!;

    public int ResponsibleDivision { get; set; }

    public string Status { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? FinalDocNumber { get; set; }

    public DateTime? FinalDocDate { get; set; }

    public string? FinalCmdapprovalComments { get; set; }

    public string? Attachments { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
