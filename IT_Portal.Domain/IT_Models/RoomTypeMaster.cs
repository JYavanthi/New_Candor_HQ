namespace IT_Portal.Domain.IT_Models;

public partial class RoomTypeMaster
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<RoomMaster> RoomMasters { get; set; } = new List<RoomMaster>();
}
