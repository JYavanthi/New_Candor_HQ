namespace IT_Portal.Domain.IT_Models;

public partial class ItPolicy
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public string? Category { get; set; }

    public string? BriefDescription { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public string? Attachments { get; set; }
}
