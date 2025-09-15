namespace IT_Portal.Domain.IT_Models;

public partial class SoftwareCategoryMaster
{
    public int Id { get; set; }

    public string? SoftwareCategory { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedOn { get; set; }
}
