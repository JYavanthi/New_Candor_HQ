namespace IT_Portal.Domain.IT_Models;

public partial class AccClerkM
{
    public int Id { get; set; }

    public string AccClerkId { get; set; } = null!;

    public string? AccClerkDesc { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
