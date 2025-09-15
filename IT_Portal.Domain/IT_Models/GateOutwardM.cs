namespace IT_Portal.Domain.IT_Models;

public partial class GateOutwardM
{
    public int Id { get; set; }

    public string Mandt { get; set; } = null!;

    public string FinYear { get; set; } = null!;

    public string PlantId { get; set; } = null!;

    public string GoGateno { get; set; } = null!;

    public string GoNo { get; set; } = null!;

    public string Recid { get; set; } = null!;

    public string? GoType { get; set; }

    public DateTime? GoDate { get; set; }

    public DateTime? ExpReturnDate { get; set; }

    public string? SendingDeptNm { get; set; }

    public string? SendingPerson { get; set; }

    public string? SendingReason { get; set; }

    public string? DcNo { get; set; }

    public DateTime? DcDate { get; set; }

    public string? DocNo { get; set; }

    public DateTime? DocDate { get; set; }

    public string? DestinationNm { get; set; }

    public string? Deliverymode { get; set; }

    public string? Deliveryperson { get; set; }

    public string? CourierName { get; set; }

    public string? CourierNum { get; set; }

    public DateTime? CourierDate { get; set; }

    public string? Vehicleno { get; set; }

    public DateTime? OutTime { get; set; }

    public DateTime? OutDate { get; set; }

    public DateTime? ExpOutTime { get; set; }

    public string? PersonName { get; set; }

    public string? GoFlg { get; set; }

    public string? DelFlg { get; set; }

    public string? DelReason { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? Remarks { get; set; }

    public bool? IsActive { get; set; }

    public string? Comments { get; set; }

    public string? TransporterName { get; set; }

    public string? LrNo { get; set; }

    public string? DriverName { get; set; }

    public string? Status { get; set; }

    public string? PendingWith { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public string? VendorGstin { get; set; }

    public string? MaterialType { get; set; }
}
