namespace IT_Portal.Domain.IT_Models;

public partial class BookPurposeMaster
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string Purpose { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<CabBooking> CabBookings { get; set; } = new List<CabBooking>();

    public virtual ICollection<GuestHouseBooking> GuestHouseBookings { get; set; } = new List<GuestHouseBooking>();

    public virtual ICollection<RoomBooking> RoomBookings { get; set; } = new List<RoomBooking>();
}
