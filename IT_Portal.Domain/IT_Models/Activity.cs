namespace IT_Portal.Domain.IT_Models;

public partial class Activity
{
    public int ActivityId { get; set; }

    public string ActivityType { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int ObjectId { get; set; }

    public string ObjectType { get; set; } = null!;

    public DateTime ActivityDate { get; set; }

    public int ActivityById { get; set; }
}
