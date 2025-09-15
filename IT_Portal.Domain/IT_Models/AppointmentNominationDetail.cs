namespace IT_Portal.Domain.IT_Models;

public partial class AppointmentNominationDetail
{
    public int AppointmentNominationDetailsId { get; set; }

    public int? EmployeeId { get; set; }

    public int AppointmentId { get; set; }

    public int AppointmentFamilyDetailsId { get; set; }

    public decimal Pfpercent { get; set; }

    public decimal Esipercent { get; set; }

    public decimal GratuityPercent { get; set; }

    public virtual AppointmentFamilyDetail AppointmentFamilyDetails { get; set; } = null!;

    public virtual Employee? Employee { get; set; }
}
