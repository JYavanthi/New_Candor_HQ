namespace IT_Portal.Domain.IT_Models;

public partial class AppointmentFamilyDetail
{
    public int FamilyDetailsId { get; set; }

    public int RelationshipTypeId { get; set; }

    public string Title { get; set; } = null!;

    public string? Initial { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string Gender { get; set; } = null!;

    public string Occupation { get; set; } = null!;

    public string? BirthPlace { get; set; }

    public DateTime BirthDate { get; set; }

    public string? TelephoneNumber { get; set; }

    public string? MobileNumber { get; set; }

    public string? EmailAddress { get; set; }

    public string? BloodGroup { get; set; }

    public string IsDependent { get; set; } = null!;

    public string IsEmployee { get; set; } = null!;

    public string? EmployeeNumber { get; set; }

    public int AppointmentId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual AppointmentPersonalDetail Appointment { get; set; } = null!;

    public virtual ICollection<AppointmentNominationDetail> AppointmentNominationDetails { get; set; } = new List<AppointmentNominationDetail>();

    public virtual Employee? Employee { get; set; }

    public virtual RelationshipM RelationshipType { get; set; } = null!;
}
