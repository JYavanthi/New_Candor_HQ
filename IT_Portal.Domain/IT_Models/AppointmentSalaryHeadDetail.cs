namespace IT_Portal.Domain.IT_Models;

public partial class AppointmentSalaryHeadDetail
{
    public int AppointmentSalaryHeadDetailsId { get; set; }

    public int SalaryHeadId { get; set; }

    public decimal Amount { get; set; }

    public decimal AnnualAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int AppointmentId { get; set; }

    public virtual AppointmentPersonalDetail Appointment { get; set; } = null!;

    public virtual SalaryStructure SalaryHead { get; set; } = null!;
}
