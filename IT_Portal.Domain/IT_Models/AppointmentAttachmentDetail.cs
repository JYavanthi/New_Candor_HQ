namespace IT_Portal.Domain.IT_Models;

public partial class AppointmentAttachmentDetail
{
    public int AttachmentId { get; set; }

    public string AttachmentType { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public int AppointmentId { get; set; }

    public string? Note { get; set; }

    public int? EmployeeId { get; set; }

    public virtual AppointmentPersonalDetail Appointment { get; set; } = null!;

    public virtual Employee? Employee { get; set; }
}
