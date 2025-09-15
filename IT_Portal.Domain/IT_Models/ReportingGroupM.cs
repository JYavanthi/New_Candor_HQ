namespace IT_Portal.Domain.IT_Models;

public partial class ReportingGroupM
{
    public int Id { get; set; }

    public int ReportingGroup { get; set; }

    public string? ReportingGroupSt { get; set; }

    public string? ReportingGroupLt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
