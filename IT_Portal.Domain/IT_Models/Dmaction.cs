namespace IT_Portal.Domain.IT_Models;

public partial class Dmaction
{
    public int Id { get; set; }

    public int? Stage1DiscrepancyRequestId { get; set; }

    public string? ActionType { get; set; }

    public string? Stage { get; set; }

    public int? StageId { get; set; }

    public int? DeprecatedRequestId { get; set; }

    public int? DeprecatedStageId { get; set; }

    public int? Revision { get; set; }

    public string? EmployeeId { get; set; }

    public string? Comments { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? EmployeeName { get; set; }

    public string? EmployeeRole { get; set; }

    public string? ReturnComments { get; set; }
}
