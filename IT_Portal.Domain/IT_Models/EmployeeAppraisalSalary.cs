namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeAppraisalSalary
{
    public int EmployeeAppraisalSalaryId { get; set; }

    public int EmployeeAppraisalId { get; set; }

    public int SalaryHeadId { get; set; }

    public decimal Amount { get; set; }

    public decimal AnnualAmount { get; set; }

    public virtual EmployeeAppraisal EmployeeAppraisal { get; set; } = null!;

    public virtual SalaryStructure SalaryHead { get; set; } = null!;
}
