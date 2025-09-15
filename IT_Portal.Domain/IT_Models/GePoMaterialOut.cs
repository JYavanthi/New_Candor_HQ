namespace IT_Portal.Domain.IT_Models;

public partial class GePoMaterialOut
{
    public int Id { get; set; }

    public int FkgeOutId { get; set; }

    public string? MaterialCode { get; set; }

    public string? MaterialDescription { get; set; }

    public string? Uom { get; set; }

    public int? Qty { get; set; }

    public int? NoCases { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? Modifiedby { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual GePoOut FkgeOut { get; set; } = null!;
}
