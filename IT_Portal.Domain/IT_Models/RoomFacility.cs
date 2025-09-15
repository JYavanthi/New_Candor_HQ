namespace IT_Portal.Domain.IT_Models;

public partial class RoomFacility
{
    public int Id { get; set; }

    public int FkRoomId { get; set; }

    public int? FkFacilityId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual RoomFacilityMaster? FkFacility { get; set; }

    public virtual RoomMaster FkRoom { get; set; } = null!;
}
