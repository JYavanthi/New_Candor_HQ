namespace IT_Portal.Domain.IT_Models;

public partial class IssueOnholdCat
{
    public int IssueOnholdCatId { get; set; }

    public int? CategoryId { get; set; }

    public int? CategoryTypeId { get; set; }

    public string? OnholdReason { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? SupportId { get; set; }
}
