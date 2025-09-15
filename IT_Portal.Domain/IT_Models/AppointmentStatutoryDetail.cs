namespace IT_Portal.Domain.IT_Models;

public partial class AppointmentStatutoryDetail
{
    public int AppointmentStatutoryDetailsId { get; set; }

    public string? AadharNo { get; set; }

    public string? Panno { get; set; }

    public string Pfdeduction { get; set; } = null!;

    public string? Pfno { get; set; }

    public string? Uanno { get; set; }

    public string Esideduction { get; set; } = null!;

    public string? Esino { get; set; }

    public string Itdeduction { get; set; } = null!;

    public string Pt { get; set; } = null!;

    public string Leaves { get; set; } = null!;

    public string BonusPay { get; set; } = null!;

    public string Gratuity { get; set; } = null!;

    public int AppointmentId { get; set; }

    public int? EmployeeId { get; set; }

    public string? Eps { get; set; }

    public virtual Employee? Employee { get; set; }
}
