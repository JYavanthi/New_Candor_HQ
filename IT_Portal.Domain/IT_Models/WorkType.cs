namespace IT_Portal.Domain.IT_Models;

public partial class WorkType
{
    public int Id { get; set; }

    public string? WorkTypeShortDesc { get; set; }

    public string? WorkTypeLongDesc { get; set; }

    public bool? Active { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
