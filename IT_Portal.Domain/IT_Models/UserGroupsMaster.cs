namespace IT_Portal.Domain.IT_Models;

public partial class UserGroupsMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? FkSoftwareId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual Software? FkSoftware { get; set; }

    public virtual ICollection<UserSubgroupsMaster> UserSubgroupsMasters { get; set; } = new List<UserSubgroupsMaster>();
}
