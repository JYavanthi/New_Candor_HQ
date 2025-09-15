namespace IT_Portal.Domain.IT_Models;

public partial class RoomPicture
{
    public int Id { get; set; }

    public int FkRoomMasterId { get; set; }

    public string? FileName { get; set; }

    public string? Description { get; set; }

    public string Path { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual RoomMaster FkRoomMaster { get; set; } = null!;
}
