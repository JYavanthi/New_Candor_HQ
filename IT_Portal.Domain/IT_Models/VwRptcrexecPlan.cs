namespace IT_Portal.Domain.IT_Models;

public partial class VwRptcrexecPlan
{
    public int Itcrid { get; set; }

    public string Crcode { get; set; } = null!;

    public int SupportId { get; set; }

    public string? Crowner { get; set; }

    public string? ChangeDesc { get; set; }

    public int ItcategoryId { get; set; }

    public string? CategoryName { get; set; }

    public int ItclassificationId { get; set; }

    public string? ClassificationName { get; set; }

    public DateTime Crdate { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public string? Stage { get; set; }

    public int CategoryTypeId { get; set; }

    public string? CategoryType { get; set; }

    public string? NatureofChange { get; set; }

    public string? Supportname { get; set; }

    public string? AssignedTo { get; set; }

    public string? ForwardedTo { get; set; }

    public string? Status { get; set; }

    public int? PriorityType { get; set; }

    public string PriorityName { get; set; } = null!;

    public string? SysLandscape { get; set; }

    public string? DependSyelanscape { get; set; }

    public string? Depndtask { get; set; }

    public int TaskId { get; set; }

    public DateTime? Plantstartdate { get; set; }

    public DateTime? EndDt { get; set; }

    public DateTime? ActualStartDt { get; set; }

    public DateTime? ActualEndDt { get; set; }

    public string? Code { get; set; }

    public int? PlantId { get; set; }
}
