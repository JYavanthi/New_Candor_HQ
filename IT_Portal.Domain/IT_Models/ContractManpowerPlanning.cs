namespace IT_Portal.Domain.IT_Models;

public partial class ContractManpowerPlanning
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public int? Paygroup { get; set; }

    public int? StaffCat { get; set; }

    public int? Department { get; set; }

    public int? SubDepartment { get; set; }

    public int? Count { get; set; }

    public string? Budget { get; set; }

    public string? Contractor { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }
}
