namespace IT_Portal.Domain.IT_Models;

public partial class DetailStructureInput
{
    public int Id { get; set; }

    public int FkFormId { get; set; }

    public string? Header { get; set; }

    public string? HeaderTitle { get; set; }

    public string? Subheader { get; set; }

    public string? SubheaderTitle { get; set; }

    public string? Breadcrumb { get; set; }

    public string? BreadcrumbAddUpdate { get; set; }

    public string? Name { get; set; }

    public string? Temp1 { get; set; }

    public string? State { get; set; }

    public string? Approver { get; set; }

    public string? Temp2 { get; set; }

    public string? Temp3 { get; set; }

    public string? Temp4 { get; set; }

    public string? Temp5 { get; set; }

    public string? Temp6 { get; set; }

    public string? Temp7 { get; set; }

    public string? Temp8 { get; set; }

    public string? Temp9 { get; set; }

    public string? Temp10 { get; set; }

    public string? Temp11 { get; set; }

    public string? Temp12 { get; set; }

    public string? Temp13 { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual FormMaster FkForm { get; set; } = null!;
}
