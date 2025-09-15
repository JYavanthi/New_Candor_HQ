namespace IT_Portal.Domain.IT_Models;

public partial class AllowanceMapping
{
    public int Id { get; set; }

    public int? PlantId { get; set; }

    public int? PayGroupId { get; set; }

    public int? EmployeeCategoryId { get; set; }

    public int? DesignationId { get; set; }

    public DateTime? EffectiveFrom { get; set; }

    public string? Metro { get; set; }

    public int? AllowanceTypeId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual AllowanceMaster? AllowanceType { get; set; }
}
