namespace IT_Portal.Domain.IT_Models;

public partial class OnDutyEmpDocument
{
    public int Id { get; set; }

    public int RequestNo { get; set; }

    public string? UserId { get; set; }

    public string? FileName { get; set; }

    public string? OnDutyType { get; set; }
}
