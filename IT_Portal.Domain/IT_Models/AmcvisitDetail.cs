namespace IT_Portal.Domain.IT_Models;

public partial class AmcvisitDetail
{
    public int Id { get; set; }

    public int? VisitorId { get; set; }

    public string? EquipmentName { get; set; }

    public string? EquipmentId { get; set; }

    public string? ModelNo { get; set; }

    public string? ReasonforAmc { get; set; }

    public string? ActionTaken { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? TypeOfService { get; set; }

    public string? Department { get; set; }

    public string? ServiceRequestedBy { get; set; }

    public string? Status { get; set; }

    public virtual Visitor? Visitor { get; set; }
}
