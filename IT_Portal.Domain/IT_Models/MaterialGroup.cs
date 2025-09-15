namespace IT_Portal.Domain.IT_Models;

public partial class MaterialGroup
{
    public int Id { get; set; }

    public string? MaterialGroupId { get; set; }

    public string? Stxt { get; set; }

    public string? Ltxt { get; set; }

    public string? MaterialType { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
