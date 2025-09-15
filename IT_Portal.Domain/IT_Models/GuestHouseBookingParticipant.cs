namespace IT_Portal.Domain.IT_Models;

public partial class GuestHouseBookingParticipant
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? MobileCode { get; set; }

    public string? Type { get; set; }

    public string? EmployeeId { get; set; }

    public int FkBookingId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual GuestHouseBooking FkBooking { get; set; } = null!;
}
