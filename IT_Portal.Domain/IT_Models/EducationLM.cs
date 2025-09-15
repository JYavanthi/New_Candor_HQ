namespace IT_Portal.Domain.IT_Models;

public partial class EducationLM
{
    public int Id { get; set; }

    public string EducationLevel { get; set; } = null!;

    public int? Priority { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AppointmentEducationDetail> AppointmentEducationDetails { get; set; } = new List<AppointmentEducationDetail>();
}
