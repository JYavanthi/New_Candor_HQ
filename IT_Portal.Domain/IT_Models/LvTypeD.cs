namespace IT_Portal.Domain.IT_Models;

public partial class LvTypeD
{
    public int Id { get; set; }

    public int? LvTypeid { get; set; }

    public int? LvCalyear { get; set; }

    public string? LvEmpcode { get; set; }

    public double? LvOpbal { get; set; }

    public double? LvAvailed { get; set; }

    public double? LvClbal { get; set; }

    public double? LvAwtBal { get; set; }

    public string? SapStatus { get; set; }

    public DateTime? SapApprovedDate { get; set; }

    public string? SapMessage { get; set; }

    public bool? Prodata { get; set; }
}
