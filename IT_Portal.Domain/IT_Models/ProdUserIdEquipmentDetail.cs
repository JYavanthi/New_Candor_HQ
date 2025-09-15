namespace IT_Portal.Domain.IT_Models;

public partial class ProdUserIdEquipmentDetail
{
    public int Id { get; set; }

    public int? Sid { get; set; }

    public int? ReqId { get; set; }

    public string? RequestNo { get; set; }

    public string? EquipmentName { get; set; }

    public string? EquipmentId { get; set; }

    public string? AreaorLocation { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }
}
