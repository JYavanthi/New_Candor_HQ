namespace IT_Portal.Domain.IT_Models;

public partial class EducationCM
{
    public int Id { get; set; }

    public int? EducationLId { get; set; }

    public string EducationCourse { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AppointmentEducationDetail> AppointmentEducationDetails { get; set; } = new List<AppointmentEducationDetail>();
}
