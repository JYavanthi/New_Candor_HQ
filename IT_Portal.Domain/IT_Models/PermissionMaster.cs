namespace IT_Portal.Domain.IT_Models;

public partial class PermissionMaster
{
    public int Id { get; set; }

    public int? PerCalyear { get; set; }

    public string? PerEmpcode { get; set; }

    public int? PerOpbal { get; set; }

    public int? PerAvailed { get; set; }

    public int? PerClbal { get; set; }

    public int? PerAwtBal { get; set; }

    public string? SapStatus { get; set; }

    public DateTime? SapApprovedDate { get; set; }

    public string? SapMessage { get; set; }

    public bool? Prodata { get; set; }
}
