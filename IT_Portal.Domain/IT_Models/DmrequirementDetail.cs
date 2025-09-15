namespace IT_Portal.Domain.IT_Models;

public partial class DmrequirementDetail
{
    public int Id { get; set; }

    public string? RequirementDetailsText { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
