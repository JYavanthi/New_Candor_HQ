namespace IT_Portal.Domain.IT_Models;

public partial class Pbaudit
{
    public int Id { get; set; }

    public string Pbnumber { get; set; } = null!;

    public int PbtransactionId { get; set; }

    public string FieldName { get; set; } = null!;

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public string DoneBy { get; set; } = null!;

    public DateTime? DoneOn { get; set; }
}
