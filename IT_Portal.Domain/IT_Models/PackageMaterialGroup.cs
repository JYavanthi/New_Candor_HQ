namespace IT_Portal.Domain.IT_Models;

public partial class PackageMaterialGroup
{
    public int Id { get; set; }

    public string? PackingMaterialGroupId { get; set; }

    public string? PackingMaterialGroupName { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
