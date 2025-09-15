namespace IT_Portal.Domain.IT_Models;

public partial class Npdaudit
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public int NpdtransactionId { get; set; }

    public string FieldName { get; set; } = null!;

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public string DoneBy { get; set; } = null!;

    public DateTime? DoneOn { get; set; }
}
