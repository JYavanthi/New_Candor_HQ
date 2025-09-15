namespace IT_Portal.Domain.IT_Models;

public partial class PartnerMasterDetail
{
    public int Id { get; set; }

    public int? Vccode { get; set; }

    public string? Vcname { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Pin { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Pan { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public int? DelFlag { get; set; }

    public int? UpdateFlag { get; set; }
}
