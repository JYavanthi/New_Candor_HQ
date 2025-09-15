namespace IT_Portal.Domain.IT_Models;

public partial class AppointmentAddressDetail
{
    public int AddressId { get; set; }

    public int AppointmentId { get; set; }

    public int AddressTypeId { get; set; }

    public string? CareOf { get; set; }

    public string HouseNo { get; set; } = null!;

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string? AddressLine3 { get; set; }

    public string PostalCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public int StateId { get; set; }

    public int CountryId { get; set; }

    public string OwnOrRented { get; set; } = null!;

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public int? EmployeeId { get; set; }

    public virtual AddrTypM AddressType { get; set; } = null!;

    public virtual AppointmentPersonalDetail Appointment { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual Employee? Employee { get; set; }

    public virtual State State { get; set; } = null!;
}
