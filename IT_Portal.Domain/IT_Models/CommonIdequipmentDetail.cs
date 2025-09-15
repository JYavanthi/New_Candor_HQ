namespace IT_Portal.Domain.IT_Models;

public partial class CommonIdequipmentDetail
{
    public int Id { get; set; }

    public int Sid { get; set; }

    public int RequestId { get; set; }

    public string RequestNumber { get; set; } = null!;

    public string? EquipmentName { get; set; }

    public string? EquipmentId { get; set; }

    public string? AreaOrLocation { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }
}
