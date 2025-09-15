namespace IT_Portal.Domain.IT_Models;

public partial class AllowanceMaster
{
    public int Id { get; set; }

    public string? AllowanceType { get; set; }

    public int? Status { get; set; }

    public DateOnly? EffectiveFrom { get; set; }

    public string? Metro { get; set; }

    public double? Hq { get; set; }

    public double? Exhq { get; set; }

    public double? Os { get; set; }

    public double? Hs { get; set; }

    public double? Ma { get; set; }

    public double? Ia { get; set; }

    public double? Sa { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AllowanceMapping> AllowanceMappings { get; set; } = new List<AllowanceMapping>();

    public virtual ICollection<AppointmentSalaryDetail> AppointmentSalaryDetails { get; set; } = new List<AppointmentSalaryDetail>();

    public virtual ICollection<EmployeeSalaryDetail> EmployeeSalaryDetails { get; set; } = new List<EmployeeSalaryDetail>();
}
