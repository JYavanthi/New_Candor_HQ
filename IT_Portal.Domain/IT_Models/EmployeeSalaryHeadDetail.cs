namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeSalaryHeadDetail
{
    public int EmployeeSalaryHeadDetailsId { get; set; }

    public int SalaryHeadId { get; set; }

    public decimal Amount { get; set; }

    public decimal AnnualAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual SalaryStructure SalaryHead { get; set; } = null!;
}
