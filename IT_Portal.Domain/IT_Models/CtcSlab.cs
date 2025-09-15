namespace IT_Portal.Domain.IT_Models;

public partial class CtcSlab
{
    public int Id { get; set; }

    public int EmployeeCategoryId { get; set; }

    public int GradeId { get; set; }

    public double? SlabFrom { get; set; }

    public double? SlabTo { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
