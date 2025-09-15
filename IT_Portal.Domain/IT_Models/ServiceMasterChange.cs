namespace IT_Portal.Domain.IT_Models;

public partial class ServiceMasterChange
{
    public int Id { get; set; }

    public string? DetailedServiceDescription { get; set; }

    public string? SacCode { get; set; }

    public string? ServiceDescription { get; set; }

    public string? PurchaseGroup { get; set; }

    public DateTime? RequestedDate { get; set; }

    public string? RequestedBy { get; set; }

    public string? PlantCode { get; set; }

    public string? Reason { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingApprover { get; set; }

    public string? Status { get; set; }

    public string? ServiceCategory { get; set; }

    public string? ServiceCode { get; set; }

    public string? Uom { get; set; }

    public string? ServiceGroup { get; set; }

    public string? ValuationClass { get; set; }
}
