namespace IT_Portal.Domain.IT_Models;

public partial class NpdHodDetail
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public string? SubmitedBy { get; set; }

    public DateTime? SubmitedDate { get; set; }

    public string? Location { get; set; }

    public string? Division { get; set; }

    public string? Hodremarks { get; set; }

    public DateTime? FinalRecommendationSubmitedDate { get; set; }

    public string? FinalRecommendationHod { get; set; }

    public string? FinalrecommendationHoddate { get; set; }

    public string? Totaldevelopmenttime { get; set; }

    public string? Drugdevelopmentcost { get; set; }

    public string? Equipmentcost { get; set; }

    public string? Regulatoryapprovalcost { get; set; }

    public string? Cqacost { get; set; }

    public string? Totalgrandcost { get; set; }
}
