namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeSalaryHistory
{
    public int EmployeeSalaryHistoryId { get; set; }

    public int EmployeeId { get; set; }

    public int SalaryHeadId { get; set; }

    public decimal Amount { get; set; }

    public decimal AnnualAmount { get; set; }

    public string ObjectTypeId { get; set; } = null!;

    public int ObjectId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual SalaryStructure SalaryHead { get; set; } = null!;
}
