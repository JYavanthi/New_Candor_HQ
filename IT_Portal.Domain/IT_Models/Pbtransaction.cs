namespace IT_Portal.Domain.IT_Models;

public partial class Pbtransaction
{
    public int Id { get; set; }

    public string Pbnumber { get; set; } = null!;

    public string Section { get; set; } = null!;

    public string? TransactionType { get; set; }

    public string DoneBy { get; set; } = null!;

    public DateTime? DoneOn { get; set; }

    public string? Comments { get; set; }
}
