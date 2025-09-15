namespace IT_Portal.Domain.IT_Models;

public partial class Grade
{
    public int Id { get; set; }

    public string? Grdid { get; set; }

    public string? Grdtxt { get; set; }

    public DateTime? Crdat { get; set; }

    public byte[] Cputm { get; set; } = null!;

    public string? Uname { get; set; }

    public DateTime? Aedtm { get; set; }

    public string? Aename { get; set; }

    public virtual ICollection<ChecklistConfig> ChecklistConfigs { get; set; } = new List<ChecklistConfig>();

    public virtual ICollection<CompOtRule> CompOtRules { get; set; } = new List<CompOtRule>();
}
