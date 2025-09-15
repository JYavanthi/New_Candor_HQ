namespace IT_Portal.Domain.IT_Models;

public partial class NpdRndDeptDetail
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public string? SubmitedBy { get; set; }

    public DateTime SubmitedDate { get; set; }

    public string? Location { get; set; }

    public string? Division { get; set; }

    public string? ApiSourceAvailability { get; set; }

    public string? FormulationShelfLifeMonths { get; set; }

    public string? DevelopmentCost { get; set; }

    public string? SpecialEquipmentCost { get; set; }

    public string? TotalTimlineCompleteProject { get; set; }

    public string? SuggestedPlantCommercialisation { get; set; }

    public string? ApprvrStatus { get; set; }

    public string? RemarksRnd { get; set; }

    public string? FinalRecommendation { get; set; }
}
