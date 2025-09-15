namespace IT_Portal.Domain.IT_Models;

public partial class ProdSoftware
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public string? SoftwareType { get; set; }

    public string? Location { get; set; }
}
