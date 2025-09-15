namespace IT_Portal.Domain.IT_Models;

public partial class Device
{
    public Guid DeviceId { get; set; }

    public string DeviceTitle { get; set; } = null!;

    public virtual ICollection<DeviceDetail> DeviceDetails { get; set; } = new List<DeviceDetail>();
}
