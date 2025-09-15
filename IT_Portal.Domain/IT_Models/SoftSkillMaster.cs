namespace IT_Portal.Domain.IT_Models;

public partial class SoftSkillMaster
{
    public int Id { get; set; }

    public int? FkCalendarId { get; set; }

    public int? FkRoleId { get; set; }

    public int? FkAssesmentId { get; set; }

    public string? Skills { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<AssesmentDetail> AssesmentDetails { get; set; } = new List<AssesmentDetail>();

    public virtual AssesmentMaster? FkAssesment { get; set; }

    public virtual CalendarMaster? FkCalendar { get; set; }

    public virtual SubRole? FkRole { get; set; }
}
