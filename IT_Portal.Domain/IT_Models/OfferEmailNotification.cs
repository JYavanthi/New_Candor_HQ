namespace IT_Portal.Domain.IT_Models;

public partial class OfferEmailNotification
{
    public int OfferEmailNotificationId { get; set; }

    public int PlantId { get; set; }

    public int PayGroupId { get; set; }

    public int EmployeeCategoryId { get; set; }

    public string EmailType { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string? StateId { get; set; }
}
