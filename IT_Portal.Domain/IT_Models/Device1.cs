namespace IT_Portal.Domain.IT_Models;

public partial class Device1
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public string DeviceFname { get; set; } = null!;

    public string DeviceSname { get; set; } = null!;

    public string? DeviceDirection { get; set; }

    public string? SerialNumber { get; set; }

    public string? ConnectionType { get; set; }

    public string? IpAddress { get; set; }

    public string? BaudRate { get; set; }

    public string CommKey { get; set; } = null!;

    public string? ComPort { get; set; }

    public DateTime? LastLogDownloadDate { get; set; }

    public string? C1 { get; set; }

    public string? C2 { get; set; }

    public string? C3 { get; set; }

    public string? C4 { get; set; }

    public string? C5 { get; set; }

    public string? C6 { get; set; }

    public string? C7 { get; set; }

    public string? Transactionstamp { get; set; }

    public DateTime? LastPing { get; set; }

    public string? DeviceType { get; set; }

    public string? OpStamp { get; set; }

    public int? DownloadType { get; set; }

    public string? Timezone { get; set; }

    public string? DeviceLocation { get; set; }

    public string? TimeOut { get; set; }

    public string? FaceDeviceType { get; set; }

    public int? MasterId { get; set; }

    public string? AttPhotoStamp { get; set; }

    public string? DeviceActivationCode { get; set; }

    public string? EmailId { get; set; }
}
