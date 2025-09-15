namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeSalaryDetail
{
    public int EmployeeSalaryDetailsId { get; set; }

    public decimal OfferedSalary { get; set; }

    public string? SalaryType { get; set; }

    public string? PackageType { get; set; }

    public decimal? SecondYearCtc { get; set; }

    public decimal? ThirdYearCtc { get; set; }

    public string? Note { get; set; }

    public int? AllowanceId { get; set; }

    public int EmployeeId { get; set; }

    public virtual AllowanceMaster? Allowance { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
