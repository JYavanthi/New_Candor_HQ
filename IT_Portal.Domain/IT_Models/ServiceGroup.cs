namespace IT_Portal.Domain.IT_Models;

public partial class ServiceGroup
{
    public int GroupId { get; set; }

    public string? Stxt { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
