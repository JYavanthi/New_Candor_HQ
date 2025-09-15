namespace IT_Portal.Domain.IT_Models;

public partial class Npdrnd
{
    public int Id { get; set; }

    public string Npdnumber { get; set; } = null!;

    public string ResponsibleEmployeeId { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? ProcurementTimeline { get; set; }

    public int? Rndtimeline { get; set; }

    public int? StabilityTimeline { get; set; }

    public int? Dcgitimeline { get; set; }

    public int? ManufacturingTimeline { get; set; }

    public int? OthersTimeline { get; set; }

    public int? TotalTimelineForLaunch { get; set; }

    public string? SuggestedPlantsForCommercialization { get; set; }

    public string? DevelopmentCost { get; set; }

    public string? EquipmentCost { get; set; }

    public string? AnalyticalCost { get; set; }

    public string? Ipcost { get; set; }

    public string? ProcurementCost { get; set; }

    public string? ManufacturingCost { get; set; }

    public string? DcgilicenseCost { get; set; }

    public string? TotalGrandCost { get; set; }

    public string? FinalRecommendation { get; set; }

    public string? Attachments { get; set; }

    public string? ProcurementTimelineUnit { get; set; }

    public string? RndtimelineUnit { get; set; }

    public string? StabilityTimelineUnit { get; set; }

    public string? DcgitimelineUnit { get; set; }

    public string? ManufacturingTimelineUnit { get; set; }

    public string? OthersTimelineUnit { get; set; }

    public string? TotalTimelineForLaunchUnit { get; set; }

    public int? DevelopmentTimeline { get; set; }

    public string? DevelopmentTimelineUnit { get; set; }

    public int? TentativeTimeline { get; set; }

    public string? TentativeTimelineUnit { get; set; }

    public int? DevelopmentApproach { get; set; }
}
