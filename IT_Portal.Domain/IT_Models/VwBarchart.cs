namespace IT_Portal.Domain.IT_Models;

public partial class VwBarchart
{
    public int Crowner { get; set; }

    public int Itcrid { get; set; }

    public int ClassifcationId { get; set; }

    public int CategoryId { get; set; }

    public int? CategoryTypeId { get; set; }

    public int? PlantId { get; set; }

    public DateTime Crdate { get; set; }

    public int? CompletedIdnum { get; set; }

    public int? NonCompletedIdnum { get; set; }

    public int? Crmonth { get; set; }
}
