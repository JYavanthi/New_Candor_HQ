namespace IT_Portal.Domain.IT_Models;

public partial class AppointmentSalaryHeadPayableDetail
{
    public int AppointmentSalaryHeadPayableDetailsId { get; set; }

    public int SalaryHeadId { get; set; }

    public string Month { get; set; } = null!;

    public bool Payable { get; set; }

    public int AppointmentId { get; set; }

    public virtual AppointmentPersonalDetail Appointment { get; set; } = null!;

    public virtual SalaryStructure SalaryHead { get; set; } = null!;
}
