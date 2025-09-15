namespace IT_Portal.Domain.IT_Models;

public partial class Material
{
    public int Id { get; set; }

    public int FkMaterialType { get; set; }

    public string? MaterialCode { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual MaterialType FkMaterialTypeNavigation { get; set; } = null!;
}
