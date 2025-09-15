namespace IT_Portal.Domain.IT_Models;

public partial class SbuMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public int? HeadEmpId { get; set; }

    public int? FkParentId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<CompetencyMaster> CompetencyMasters { get; set; } = new List<CompetencyMaster>();
}
