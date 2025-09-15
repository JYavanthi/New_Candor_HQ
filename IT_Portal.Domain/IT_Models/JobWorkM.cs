namespace IT_Portal.Domain.IT_Models;

public partial class JobWorkM
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public string? ChallenNo { get; set; }

    public DateTime? ChallenDate { get; set; }

    public string? ShippingAddress { get; set; }

    public string? BillingAddress { get; set; }

    public string? TransporterName { get; set; }

    public string? VehicleNo { get; set; }

    public string? LrNo { get; set; }

    public DateTime? LrDate { get; set; }

    public string? EWayBillNo { get; set; }

    public string? Remarks { get; set; }

    public string? PlaceOfSupply { get; set; }

    public string? DoneBy { get; set; }

    public DateTime? DoneOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public string? Reasonforcancellation { get; set; }

    public string? Ponumber { get; set; }

    public string? Reference { get; set; }

    public string? Pieces { get; set; }

    public string? ModeOfTransport { get; set; }
}
