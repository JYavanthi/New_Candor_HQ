namespace IT_Portal.Domain.IT_Models;

public partial class TempEmpLeaveDocument
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string? FileName { get; set; }

    public string? LeaveType { get; set; }

    public string? ReqNo { get; set; }
}
