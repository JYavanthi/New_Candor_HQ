namespace IT_Portal.Domain.IT_Models;

public partial class ProdGateOutwardD
{
    public int Id { get; set; }

    public string Mandt { get; set; } = null!;

    public string FinYear { get; set; } = null!;

    public string PlantId { get; set; } = null!;

    public string GoGateno { get; set; } = null!;

    public string GoNo { get; set; } = null!;

    public int FkgateOutwardM { get; set; }

    public int ItemNo { get; set; }

    public string? ItemCode { get; set; }

    public string? MaterialType { get; set; }

    public string? ItemDesc { get; set; }

    public string? Uom { get; set; }

    public int? NoOfCases { get; set; }

    public decimal? Qty { get; set; }

    public string? InItemDesc { get; set; }

    public decimal? InQty { get; set; }

    public string? DelFlg { get; set; }

    public string? Remarks { get; set; }

    public string? Close { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? ItemCodeP { get; set; }

    public string? ItemDescP { get; set; }

    public string? PoNo { get; set; }

    public DateTime? ExpReturnDate { get; set; }
}
