namespace IT_Portal.Domain.IT_Models;

public partial class TdsSectionM
{
    public int Id { get; set; }

    public string TdsSectionId { get; set; } = null!;

    public string? TdsSectionDesc { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
