namespace IT_Portal.Domain.IT_Models;

public partial class LocationMaster
{
    public int Id { get; set; }

    public int? Locid { get; set; }

    public string? Name { get; set; }

    public string StateId { get; set; } = null!;

    public string? Country { get; set; }

    public bool? Metro { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetails { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<EmailNotificationMapping> EmailNotificationMappings { get; set; } = new List<EmailNotificationMapping>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<OfferDetail> OfferDetails { get; set; } = new List<OfferDetail>();

    public virtual ICollection<UserIdMasterDetail> UserIdMasterDetails { get; set; } = new List<UserIdMasterDetail>();
}
