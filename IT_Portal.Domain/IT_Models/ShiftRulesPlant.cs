namespace IT_Portal.Domain.IT_Models;

public partial class ShiftRulesPlant
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public string? Paygroup { get; set; }

    public string? ShiftCode { get; set; }

    public TimeOnly? ComeLateBy { get; set; }

    public TimeOnly? GoEarlyBy { get; set; }

    public bool? Active { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
