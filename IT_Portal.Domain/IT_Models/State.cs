namespace IT_Portal.Domain.IT_Models;

public partial class State
{
    public int Id { get; set; }

    public string? Land1 { get; set; }

    public string? Bland { get; set; }

    public string? Bezei { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public virtual ICollection<AppointmentAddressDetail> AppointmentAddressDetails { get; set; } = new List<AppointmentAddressDetail>();

    public virtual ICollection<AppointmentEducationDetail> AppointmentEducationDetails { get; set; } = new List<AppointmentEducationDetail>();

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetails { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<OfferDetail> OfferDetails { get; set; } = new List<OfferDetail>();
}
