namespace IT_Portal.Domain.IT_Models;

public partial class RoomBooking
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public int FkEmployeeId { get; set; }

    public string? EmployeeNumber { get; set; }

    public int FkRoomId { get; set; }

    public int Fkpurpose { get; set; }

    public int? EmpoloyeeLocation { get; set; }

    public int? RoomLocation { get; set; }

    public int? NumberOfPerson { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public TimeOnly FromTime { get; set; }

    public TimeOnly ToTime { get; set; }

    public string? Comments { get; set; }

    public bool IsApprovalReq { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Status { get; set; }

    public bool? AllDay { get; set; }

    public string? PendingWithRequest { get; set; }

    public string? CancelComments { get; set; }

    public virtual ICollection<BookingParticipant> BookingParticipants { get; set; } = new List<BookingParticipant>();

    public virtual BookPurposeMaster FkpurposeNavigation { get; set; } = null!;
}
