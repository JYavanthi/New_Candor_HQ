namespace IT_Portal.Domain.IT_Models;

public partial class ValuationClassConfig
{
    public int Id { get; set; }

    public int MaterialGroupId { get; set; }

    public int ValuationClassId { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
