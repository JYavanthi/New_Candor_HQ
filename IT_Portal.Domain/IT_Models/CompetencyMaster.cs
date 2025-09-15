namespace IT_Portal.Domain.IT_Models;

public partial class CompetencyMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? FkHeadEmpId { get; set; }

    public int? FkSbuId { get; set; }

    public string? Description { get; set; }

    public int? FkParentId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual SbuMaster? FkSbu { get; set; }
}
