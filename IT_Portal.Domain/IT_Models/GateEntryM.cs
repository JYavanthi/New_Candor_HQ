namespace IT_Portal.Domain.IT_Models;

public partial class GateEntryM
{
    public int Id { get; set; }

    public string Mandt { get; set; } = null!;

    public string FinYear { get; set; } = null!;

    public string PlantId { get; set; } = null!;

    public string GiGateno { get; set; } = null!;

    public string GiNo { get; set; } = null!;

    public string? GoNo { get; set; }

    public string Recid { get; set; } = null!;

    public string? GiType { get; set; }

    public DateTime? GiDate { get; set; }

    public string? GoFinYear { get; set; }

    public string? Lifnr { get; set; }

    public string? Name1 { get; set; }

    public string? Ort01 { get; set; }

    public string? Regio { get; set; }

    public string? Landx { get; set; }

    public string? Deliverymode { get; set; }

    public string? Deliveryperson { get; set; }

    public string? CourierName { get; set; }

    public string? CourierNum { get; set; }

    public DateTime? CourierDate { get; set; }

    public string? Vehicleno { get; set; }

    public DateTime? InTime { get; set; }

    public string? PersonName { get; set; }

    public string? DocNo { get; set; }

    public DateTime? DocDate { get; set; }

    public string? DelFlg { get; set; }

    public string? DelReason { get; set; }

    public bool? Ack { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? ReceivedBy { get; set; }

    public DateTime? ReceivedDate { get; set; }

    public string? Comments { get; set; }

    public string? Remarks { get; set; }

    public bool? IsActive { get; set; }

    public string? TransporterName { get; set; }

    public string? LrNo { get; set; }

    public string? DriverName { get; set; }

    public string? Status { get; set; }

    public string? RevertReason { get; set; }
}
