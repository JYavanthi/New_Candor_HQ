namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeSalaryHeadPayableDetail
{
    public int EmployeeSalaryHeadPayableDetailsId { get; set; }

    public int SalaryHeadId { get; set; }

    public string Month { get; set; } = null!;

    public bool Payable { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual SalaryStructure SalaryHead { get; set; } = null!;
}
