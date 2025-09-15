namespace IT_Portal.Domain.IT_Models;

public partial class AppointmentEducationDetail
{
    public int AppointmentEducationId { get; set; }

    public int EducationLevelId { get; set; }

    public int CourseId { get; set; }

    public string Specialisation { get; set; } = null!;

    public string University { get; set; } = null!;

    public string City { get; set; } = null!;

    public int StateId { get; set; }

    public int CountryId { get; set; }

    public string DurationofCourse { get; set; } = null!;

    public string YearOfPassing { get; set; } = null!;

    public string FullorPartTime { get; set; } = null!;

    public decimal Percentage { get; set; }

    public string? AttachmentFileName { get; set; }

    public string? AttachmentFilePath { get; set; }

    public int AppointmentId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual AppointmentPersonalDetail Appointment { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual EducationCM Course { get; set; } = null!;

    public virtual EducationLM EducationLevel { get; set; } = null!;

    public virtual Employee? Employee { get; set; }

    public virtual State State { get; set; } = null!;
}
