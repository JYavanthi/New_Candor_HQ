namespace IT_Portal.Domain.IT_Models;

public partial class ItProjectManagmentMaster
{
    public int ProjectId { get; set; }

    public int? ProjectNumber { get; set; }

    public int? Location { get; set; }

    public string? ProjectName { get; set; }

    public string? Owner { get; set; }

    public string? Sponsor { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Status { get; set; }

    public bool? IsStrict { get; set; }

    public string? ProejctGroup { get; set; }

    public string? Deliverables { get; set; }

    public string? Discription { get; set; }

    public string? AdditionalNotes { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CreatedBy { get; set; }
}
