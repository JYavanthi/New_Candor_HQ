namespace IT_Portal.Domain.IT_Models;

public partial class AddrTypM
{
    public int Id { get; set; }

    public string AddressType { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Sapid { get; set; }

    public virtual ICollection<AppointmentAddressDetail> AppointmentAddressDetails { get; set; } = new List<AppointmentAddressDetail>();

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetails { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
