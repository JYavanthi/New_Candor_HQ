namespace IT_Portal.Domain.IT_Models;

public partial class SalaryStructure
{
    public int Id { get; set; }

    public string? Client { get; set; }

    public int? SalaryId { get; set; }

    public string? SalarySt { get; set; }

    public string? SalaryLt { get; set; }

    public string? DescriptionInPaySlip { get; set; }

    public int? Salarysequencenumber { get; set; }

    public string? SalaryType { get; set; }

    public string? InvestmentCode { get; set; }

    public int? PerquisiteId { get; set; }

    public int? SalaryCalculationType { get; set; }

    public string? Lwpisapplicable { get; set; }

    public string? ShowSalaryinPaySlip { get; set; }

    public string? SalaryPayableFrequency { get; set; }

    public int? SalaryRoundingTo { get; set; }

    public string? EligibleforPfdeduction { get; set; }

    public string? EligibleforEsideduction { get; set; }

    public string? EligibleforPtdeduction { get; set; }

    public string? EligibleforBonusPayment { get; set; }

    public string? EligibleforItdeduction { get; set; }

    public string? EligibleforItprojectionCalculation { get; set; }

    public string? ComponentpartofCtc { get; set; }

    public string? GroupingSalaryHeadsforItprocessing { get; set; }

    public string? EligibleforGratuityCalculation { get; set; }

    public string? Status { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AppointmentSalaryHeadDetail> AppointmentSalaryHeadDetails { get; set; } = new List<AppointmentSalaryHeadDetail>();

    public virtual ICollection<AppointmentSalaryHeadPayableDetail> AppointmentSalaryHeadPayableDetails { get; set; } = new List<AppointmentSalaryHeadPayableDetail>();

    public virtual ICollection<CtcFormula> CtcFormulas { get; set; } = new List<CtcFormula>();

    public virtual ICollection<EmployeeAppraisalSalary> EmployeeAppraisalSalaries { get; set; } = new List<EmployeeAppraisalSalary>();

    public virtual ICollection<EmployeeSalaryHeadDetail> EmployeeSalaryHeadDetails { get; set; } = new List<EmployeeSalaryHeadDetail>();

    public virtual ICollection<EmployeeSalaryHeadPayableDetail> EmployeeSalaryHeadPayableDetails { get; set; } = new List<EmployeeSalaryHeadPayableDetail>();

    public virtual ICollection<EmployeeSalaryHistory> EmployeeSalaryHistories { get; set; } = new List<EmployeeSalaryHistory>();

    public virtual ICollection<OfferSalaryHeadDetail> OfferSalaryHeadDetails { get; set; } = new List<OfferSalaryHeadDetail>();
}
