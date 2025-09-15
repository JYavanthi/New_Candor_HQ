namespace IT_Portal.Domain.IT_Models;

public partial class VwGetSrapprover
{
    public string EmployeeNo { get; set; } = null!;

    public int ReportingManagerId { get; set; }

    public int ApprovingManagerId { get; set; }

    public string? RpmEmpId { get; set; }

    public string? HodEmpId { get; set; }

    public string ReportingManagerName { get; set; } = null!;

    public string? ReportingManagerEmail { get; set; }

    public string Hodname { get; set; } = null!;

    public string? HodEmail { get; set; }
}
