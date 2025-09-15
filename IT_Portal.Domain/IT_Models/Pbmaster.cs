namespace IT_Portal.Domain.IT_Models;

public partial class Pbmaster
{
    public int Id { get; set; }

    public string Pbnumber { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int Priority { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Comments { get; set; }

    public string? GenericName { get; set; }

    public string? Composition { get; set; }

    public int? DosageForm { get; set; }

    public string? DosageDetails { get; set; }

    public string? ProductNames { get; set; }

    public int? Category { get; set; }

    public int? TherapeuticArea { get; set; }

    public int? DosageType { get; set; }

    public int? SubDosageType { get; set; }

    public int? ProposedDivision { get; set; }

    public string? Npdnumber { get; set; }

    public int? TherapeuticCategory { get; set; }
}
