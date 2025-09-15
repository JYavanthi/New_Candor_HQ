namespace IT_Portal.Domain.IT_Models;

public partial class ViewProjectGroup
{
    public int ProjectGroupId { get; set; }

    public string? ProjectGroupName { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
