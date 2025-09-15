namespace IT_Portal.Domain.IT_Models;

public partial class TblLoginHisDetail
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? DeviceIp { get; set; }

    public string? LoginTime { get; set; }

    public string? LogoutTime { get; set; }

    public string? BrowserId { get; set; }

    public bool? IsActive { get; set; }

    public string? Tvalue { get; set; }
}
