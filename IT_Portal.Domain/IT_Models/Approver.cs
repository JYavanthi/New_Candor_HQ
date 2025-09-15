namespace IT_Portal.Domain.IT_Models;

public partial class Approver
{
    public int ItapproverId { get; set; }

    public int PlantId { get; set; }

    public int SupportId { get; set; }

    public int? CategoryId { get; set; }

    public int? ClassificationId { get; set; }

    public int? CategoryTypId { get; set; }

    public string? Approverstage { get; set; }

    public int? Approver1 { get; set; }

    public int? Approver2 { get; set; }

    public int? Approver3 { get; set; }

    public int? Level { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public virtual SupportTeam? Approver1Navigation { get; set; }

    public virtual SupportTeam? Approver2Navigation { get; set; }

    public virtual SupportTeam? Approver3Navigation { get; set; }

    public virtual Support Support { get; set; } = null!;
}
