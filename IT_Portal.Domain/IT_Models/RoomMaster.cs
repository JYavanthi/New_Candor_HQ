namespace IT_Portal.Domain.IT_Models;

public partial class RoomMaster
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Capacity { get; set; }

    public int FkLocation { get; set; }

    public int FkType { get; set; }

    public bool? ManagerApproval { get; set; }

    public bool? AdminApproval { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual PlantMaster FkLocationNavigation { get; set; } = null!;

    public virtual RoomTypeMaster FkTypeNavigation { get; set; } = null!;

    public virtual ICollection<RoomFacility> RoomFacilities { get; set; } = new List<RoomFacility>();

    public virtual ICollection<RoomPicture> RoomPictures { get; set; } = new List<RoomPicture>();
}
