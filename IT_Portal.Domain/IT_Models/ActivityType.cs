namespace IT_Portal.Domain.IT_Models;

public partial class ActivityType
{
    public int Id { get; set; }

    public string? ActivityType1 { get; set; }

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
