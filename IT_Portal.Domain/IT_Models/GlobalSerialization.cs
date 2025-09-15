namespace IT_Portal.Domain.IT_Models;

public partial class GlobalSerialization
{
    public int Id { get; set; }

    public string? SerializationReqNo { get; set; }

    public string? ReqNo { get; set; }

    public string? Aun { get; set; }

    public int? PackLevel { get; set; }

    public int? Quantity { get; set; }

    public string? Gtin { get; set; }

    public string? NationalCode { get; set; }

    public string? NCodeT { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
