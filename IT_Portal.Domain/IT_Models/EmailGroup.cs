namespace IT_Portal.Domain.IT_Models;

public partial class EmailGroup
{
    public int EmailGroupId { get; set; }

    public string? EmailGroupName { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? MidifiedDt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }
}
