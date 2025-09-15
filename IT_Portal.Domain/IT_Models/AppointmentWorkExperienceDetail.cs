namespace IT_Portal.Domain.IT_Models;

public partial class AppointmentWorkExperienceDetail
{
    public int AppointmentWorkExperienceId { get; set; }

    public int IndustryId { get; set; }

    public string Employer { get; set; } = null!;

    public string City { get; set; } = null!;

    public int CountryId { get; set; }

    public string Designation { get; set; } = null!;

    public string JobRole { get; set; } = null!;

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public string IsMicroLab { get; set; } = null!;

    public string? OldEmployeeNumber { get; set; }

    public string? AttachmentFileName { get; set; }

    public string? AttachmentFilePath { get; set; }

    public int AppointmentId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual AppointmentPersonalDetail Appointment { get; set; } = null!;

    public virtual Employee? Employee { get; set; }

    public virtual IndustryM Industry { get; set; } = null!;
}
