namespace IT_Portal.Domain.IT_Models;

public partial class ExternalUserIdmaster
{
    public int Id { get; set; }

    public int Sid { get; set; }

    public int LocationId { get; set; }

    public bool? IsActive { get; set; }

    public string? RequestNumber { get; set; }

    public string? UserId { get; set; }

    public string? SoftwareRole { get; set; }

    public string? SoftwareType { get; set; }

    public string? Name { get; set; }

    public string? Company { get; set; }

    public string? Remarks { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Status { get; set; }

    public string? Category { get; set; }
}
