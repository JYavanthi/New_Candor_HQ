namespace IT_Portal.Domain.IT_Models;

public partial class VwChangeRequestHistory
{
    public int CrhistoryId { get; set; }

    public DateTime? CrhistoryDt { get; set; }

    public int Itcrid { get; set; }

    public string Crcode { get; set; } = null!;

    public string EventName { get; set; } = null!;

    public int? Crowner { get; set; }

    public int? CrrequestedBy { get; set; }

    public DateTime? CrrequestedDt { get; set; }

    public int? CrinitiatedFor { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string Supptname { get; set; } = null!;
}
