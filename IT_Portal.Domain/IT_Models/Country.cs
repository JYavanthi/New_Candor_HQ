namespace IT_Portal.Domain.IT_Models;

public partial class Country
{
    public int Id { get; set; }

    public string? Land1 { get; set; }

    public string? Landx { get; set; }

    public string? Landx50 { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<AppointmentAddressDetail> AppointmentAddressDetails { get; set; } = new List<AppointmentAddressDetail>();

    public virtual ICollection<AppointmentEducationDetail> AppointmentEducationDetails { get; set; } = new List<AppointmentEducationDetail>();

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetails { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<AppointmentPersonalDetail> AppointmentPersonalDetails { get; set; } = new List<AppointmentPersonalDetail>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
