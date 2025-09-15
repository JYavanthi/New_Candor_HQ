namespace IT_Portal.Domain.IT_Models;

public partial class TblUserLog
{
    public int Id { get; set; }

    public string? EmployeeId { get; set; }

    public string? Application { get; set; }

    public string? Activity { get; set; }

    public DateTime? DoneOn { get; set; }

    public string? IpAddress { get; set; }

    public string? HostName { get; set; }

    public string? Adid { get; set; }

    public string? BrowserName { get; set; }

    public string? Os { get; set; }

    public string? Geolocation { get; set; }

    public string? BrowserId { get; set; }

    public string? LogoutType { get; set; }

    public string? LoginTime { get; set; }

    public string? LogoutTime { get; set; }

    public string? Network { get; set; }
}
