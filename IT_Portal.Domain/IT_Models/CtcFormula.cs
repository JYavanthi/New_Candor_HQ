namespace IT_Portal.Domain.IT_Models;

public partial class CtcFormula
{
    public int Id { get; set; }

    public int EmployeeCategoryId { get; set; }

    public int GradeId { get; set; }

    public int? SalarySequenceNo { get; set; }

    public int? SalaryId { get; set; }

    public double? SalaryPercentage { get; set; }

    public double? FromSlabofSalary { get; set; }

    public double? ToSlabofSalary { get; set; }

    public double? SalaryAmount { get; set; }

    public DateTime? EffectiveFrom { get; set; }

    public DateTime? EffectiveTo { get; set; }

    public string? Calculation { get; set; }

    public double? Cieling { get; set; }

    public string? CheckBox { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? SalaryStructureId { get; set; }

    public virtual SalaryStructure? SalaryStructure { get; set; }
}
