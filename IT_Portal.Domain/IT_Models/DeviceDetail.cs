namespace IT_Portal.Domain.IT_Models;

public partial class DeviceDetail
{
    public Guid? FkDeviceId { get; set; }

    public string? Model { get; set; }

    public Guid Id { get; set; }

    public virtual Device? FkDevice { get; set; }
}
