namespace IT_Portal.Domain.IT_Models;

public partial class ErrorMaster
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public bool IsActive { get; set; }

    public string RedirectUrl { get; set; } = null!;
}
