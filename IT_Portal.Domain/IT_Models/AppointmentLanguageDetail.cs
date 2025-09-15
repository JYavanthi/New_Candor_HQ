namespace IT_Portal.Domain.IT_Models;

public partial class AppointmentLanguageDetail
{
    public int AppointmentLanguageId { get; set; }

    public int LanguageId { get; set; }

    public string MotherTongue { get; set; } = null!;

    public string Speaking { get; set; } = null!;

    public string Reading { get; set; } = null!;

    public string Writing { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int AppointmentId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual AppointmentPersonalDetail Appointment { get; set; } = null!;

    public virtual Employee? Employee { get; set; }

    public virtual LanguageM Language { get; set; } = null!;
}
