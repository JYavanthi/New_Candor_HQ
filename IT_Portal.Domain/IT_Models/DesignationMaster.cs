namespace IT_Portal.Domain.IT_Models;

public partial class DesignationMaster
{
    public int Id { get; set; }

    public int? Dsgid { get; set; }

    public string? Name { get; set; }

    public int? AtemId { get; set; }

    public bool? Cooff { get; set; }

    public bool? Ot { get; set; }

    public int? Gradeid { get; set; }

    public int? Bandid { get; set; }

    public int? FkParentId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetails { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<EmployeeInitialAppraisalDetail> EmployeeInitialAppraisalDetails { get; set; } = new List<EmployeeInitialAppraisalDetail>();

    public virtual ICollection<EmployeeMaster> EmployeeMasters { get; set; } = new List<EmployeeMaster>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<OfferDetail> OfferDetails { get; set; } = new List<OfferDetail>();
}
