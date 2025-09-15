namespace IT_Portal.Domain.IT_Models;

public partial class MicroLabsPoMaster
{
    public int Id { get; set; }

    public string PoNo { get; set; } = null!;

    public string SupplierCode { get; set; } = null!;

    public string? SupplierName { get; set; }

    public string? SupplierPlace { get; set; }

    public string? SupplierCountry { get; set; }

    public string MaterialCode { get; set; } = null!;

    public string? MaterialDescription { get; set; }

    public string Uom { get; set; } = null!;

    public int Qty { get; set; }

    public bool? IsActive { get; set; }
}
