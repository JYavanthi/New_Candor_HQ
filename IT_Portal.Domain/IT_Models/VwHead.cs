namespace IT_Portal.Domain.IT_Models;

public partial class VwHead
{
    public long? SlNo { get; set; }

    public string Name { get; set; } = null!;

    public string? Designation { get; set; }

    public string? Role { get; set; }

    public string? Division { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Email { get; set; }

    public string? ImgUrl { get; set; }

    public string? PlantCode { get; set; }

    public string? PlantName { get; set; }

    public string PlantAddress { get; set; } = null!;

    public string? Pincode { get; set; }

    public string? Group { get; set; }
}
