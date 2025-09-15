namespace IT_Portal.Domain.IT_Models;

public partial class TimeSheetActivity
{
    public int Id { get; set; }

    public string? EmployeeId { get; set; }

    public string? ProjectCode { get; set; }

    public string? ProjectCategory { get; set; }

    public string? ActivityType { get; set; }

    public DateTime? TaskDate { get; set; }

    public decimal? Time { get; set; }

    public DateTime? FromTime { get; set; }

    public DateTime? ToTime { get; set; }

    public string? TotalTime { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? WorkedOn { get; set; }

    public string? WorkedWith { get; set; }

    public string? OtherDetails { get; set; }

    public string? ApplicableUsers { get; set; }

    public string? ApplicablePlants { get; set; }
}
