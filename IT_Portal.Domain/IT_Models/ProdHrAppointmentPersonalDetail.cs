namespace IT_Portal.Domain.IT_Models;

public partial class ProdHrAppointmentPersonalDetail
{
    public int AppointmentId { get; set; }

    public int? OfferId { get; set; }

    public string? AppointmentNo { get; set; }

    public int? EmployeeNo { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public int MaritalStatusId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? PlaceOfBirth { get; set; }

    public string? CountryOfBirth { get; set; }

    public int ReligionId { get; set; }

    public string? Caste { get; set; }

    public int NationalityId { get; set; }

    public string BloodGroup { get; set; } = null!;

    public string? IdentificationMarks { get; set; }

    public string PhysicallyChallenged { get; set; } = null!;

    public string? PhysicallyChallengedDetails { get; set; }

    public string? PanNumber { get; set; }

    public string? Uannumber { get; set; }

    public string? TelephoneNumber { get; set; }

    public string? Website { get; set; }

    public string? Fax { get; set; }

    public string? PassportNumber { get; set; }

    public string? PlaceOfPassportIssue { get; set; }

    public DateTime? PassportIssueDate { get; set; }

    public DateTime? PassportExpiryDate { get; set; }

    public string EmergencyContactPersonName { get; set; } = null!;

    public string EmergencyContactAddressLine1 { get; set; } = null!;

    public string? EmergencyContactAddressLine2 { get; set; }

    public int EmergencyContactRelationshipId { get; set; }

    public string EmergencyContactMobileNumber { get; set; } = null!;

    public string? EmergencyContactTelephoneNumber { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? JoinedDate { get; set; }

    public int CreatedById { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ModifiedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int CountryOfBirthId { get; set; }

    public int? AccountTypeId { get; set; }

    public string? BankName { get; set; }

    public string? BranchName { get; set; }

    public string? AccountNo { get; set; }

    public string? Ifsccode { get; set; }

    public int? CurrencyId { get; set; }

    public string? SalaryCreditBranch { get; set; }

    public string? SalaryCreditAccountNo { get; set; }

    public string? SalaryCreditIfsccode { get; set; }

    public string? MobileNumber { get; set; }

    public string? EmailId { get; set; }

    public string? Esino { get; set; }

    public int? SalaryCreditBankId { get; set; }

    public int? EmployeeId { get; set; }

    public string? AadharNumber { get; set; }

    public string? Pfno { get; set; }

    public string? Gender { get; set; }

    public string? AppointmentGuid { get; set; }

    public bool IsConfidential { get; set; }
}
