namespace IT_Portal.Domain.IT_Models;

public partial class GePoMaterialIn
{
    public int Id { get; set; }

    public int FkgeInId { get; set; }

    public string? MaterialCode { get; set; }

    public string? MaterialDescription { get; set; }

    public string? Uom { get; set; }

    public int? Qty { get; set; }

    public int? Qtyreceived { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? Modifiedby { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual GePoIn FkgeIn { get; set; } = null!;
}
