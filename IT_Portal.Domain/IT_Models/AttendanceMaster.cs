namespace IT_Portal.Domain.IT_Models;

public partial class AttendanceMaster
{
    public string? Id { get; set; }

    public DateOnly? Date { get; set; }

    public string? Location { get; set; }

    public string? Floor { get; set; }

    public string? Wing { get; set; }

    public DateTime LogDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? UserId { get; set; }

    public int DeviceLogId { get; set; }

    public int? ProcessFlag { get; set; }

    public DateTime? ProcessDate { get; set; }

    public string? DeviceName { get; set; }
}
