namespace IT_Portal.Domain.IT_Models;

public partial class Pbipr
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

    public string? Ipstatus { get; set; }

    public DateTime? ProductPatentGenericExpiryDate { get; set; }

    public DateTime? ProductPatentSpecificExpiryDate { get; set; }

    public string? FormulationPatent { get; set; }

    public DateTime? EntryDate { get; set; }
}
