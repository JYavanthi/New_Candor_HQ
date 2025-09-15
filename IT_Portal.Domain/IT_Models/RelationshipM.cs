namespace IT_Portal.Domain.IT_Models;

public partial class RelationshipM
{
    public int Id { get; set; }

    public string Relationship { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<AppointmentFamilyDetail> AppointmentFamilyDetails { get; set; } = new List<AppointmentFamilyDetail>();

    public virtual ICollection<AppointmentPersonalDetail> AppointmentPersonalDetails { get; set; } = new List<AppointmentPersonalDetail>();
}
