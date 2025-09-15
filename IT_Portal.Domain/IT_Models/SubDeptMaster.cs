namespace IT_Portal.Domain.IT_Models;

public partial class SubDeptMaster
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public string SdptidStxt { get; set; } = null!;

    public string SdptidLtxt { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetails { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual DepartmentMaster Department { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
