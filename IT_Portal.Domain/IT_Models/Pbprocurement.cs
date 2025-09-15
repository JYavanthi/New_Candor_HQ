namespace IT_Portal.Domain.IT_Models;

public partial class Pbprocurement
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

    public string? PossibleP2ppartner { get; set; }

    public string? Dcgistatus { get; set; }
}
