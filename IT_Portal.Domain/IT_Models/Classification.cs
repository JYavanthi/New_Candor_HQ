namespace IT_Portal.Domain.IT_Models;

public partial class Classification
{
    public int ItclassificationId { get; set; }

    public string? ClassificationName { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public virtual ICollection<ChangeRequest> ChangeRequests { get; set; } = new List<ChangeRequest>();

    public virtual ICollection<Sla> Slas { get; set; } = new List<Sla>();

    public virtual ICollection<SysLandscape> SysLandscapes { get; set; } = new List<SysLandscape>();
}
