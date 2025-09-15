namespace IT_Portal.Domain.IT_Models;

public partial class RoleMaster
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string? RoleStxt { get; set; }

    public string? RoleLtxt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetails { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<EmployeeInitialAppraisalDetail> EmployeeInitialAppraisalDetails { get; set; } = new List<EmployeeInitialAppraisalDetail>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<OfferDetail> OfferDetails { get; set; } = new List<OfferDetail>();
}
