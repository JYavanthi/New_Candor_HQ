namespace IT_Portal.Domain.IT_Models;

public partial class TblManagementDetail
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Designation { get; set; }

    public string? Descrption { get; set; }

    public string? Photopath { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? Createdby { get; set; }

    public string? Modifiedby { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
