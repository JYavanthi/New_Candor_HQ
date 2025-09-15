namespace IT_Portal.Domain.IT_Models;

public partial class IndustryM
{
    public int Id { get; set; }

    public string IndDesc { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AppointmentWorkExperienceDetail> AppointmentWorkExperienceDetails { get; set; } = new List<AppointmentWorkExperienceDetail>();
}
