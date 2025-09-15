namespace IT_Portal.Domain.IT_Models;

public partial class AppointmentPersonalDetail
{
    public int AppointmentId { get; set; }

    public int? OfferId { get; set; }

    public int MaritalStatusId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? PlaceOfBirth { get; set; }

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

    public int CreatedById { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ModifiedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public DateTime? JoinedDate { get; set; }

    public string? AppointmentNo { get; set; }

    public int? EmployeeNo { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public int CountryOfBirthId { get; set; }

    public string? BankName { get; set; }

    public string? BranchName { get; set; }

    public string? AccountNo { get; set; }

    public string? Ifsccode { get; set; }

    public string? SalaryCreditBranch { get; set; }

    public string? SalaryCreditAccountNo { get; set; }

    public string? SalaryCreditIfsccode { get; set; }

    public int? AccountTypeId { get; set; }

    public int? CurrencyId { get; set; }

    public string? MobileNumber { get; set; }

    public string? EmailId { get; set; }

    public string? Esino { get; set; }

    public int? SalaryCreditBankId { get; set; }

    public int? EmployeeId { get; set; }

    public string? AppointmentGuid { get; set; }

    public virtual BankAccType? AccountType { get; set; }

    public virtual ICollection<AppointmentAddressDetail> AppointmentAddressDetails { get; set; } = new List<AppointmentAddressDetail>();

    public virtual ICollection<AppointmentAssetDetail> AppointmentAssetDetails { get; set; } = new List<AppointmentAssetDetail>();

    public virtual ICollection<AppointmentAttachmentDetail> AppointmentAttachmentDetails { get; set; } = new List<AppointmentAttachmentDetail>();

    public virtual ICollection<AppointmentEducationDetail> AppointmentEducationDetails { get; set; } = new List<AppointmentEducationDetail>();

    public virtual ICollection<AppointmentFamilyDetail> AppointmentFamilyDetails { get; set; } = new List<AppointmentFamilyDetail>();

    public virtual ICollection<AppointmentLanguageDetail> AppointmentLanguageDetails { get; set; } = new List<AppointmentLanguageDetail>();

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetails { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<AppointmentSalaryDetail> AppointmentSalaryDetails { get; set; } = new List<AppointmentSalaryDetail>();

    public virtual ICollection<AppointmentSalaryHeadDetail> AppointmentSalaryHeadDetails { get; set; } = new List<AppointmentSalaryHeadDetail>();

    public virtual ICollection<AppointmentSalaryHeadPayableDetail> AppointmentSalaryHeadPayableDetails { get; set; } = new List<AppointmentSalaryHeadPayableDetail>();

    public virtual ICollection<AppointmentWorkExperienceDetail> AppointmentWorkExperienceDetails { get; set; } = new List<AppointmentWorkExperienceDetail>();

    public virtual Country CountryOfBirth { get; set; } = null!;

    public virtual Currency? Currency { get; set; }

    public virtual RelationshipM EmergencyContactRelationship { get; set; } = null!;

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual MaritalM MaritalStatus { get; set; } = null!;

    public virtual NationalityM Nationality { get; set; } = null!;

    public virtual OfferDetail? Offer { get; set; }

    public virtual ReligionM Religion { get; set; } = null!;

    public virtual BankTypeM? SalaryCreditBank { get; set; }
}
