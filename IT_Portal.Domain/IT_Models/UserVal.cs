namespace IT_Portal.Domain.IT_Models;

public partial class UserVal
{
    public int Id { get; set; }

    public int? EmpNum { get; set; }

    public string? ValCode { get; set; }

    public bool? IsActive { get; set; }

    public string? SecurityCode { get; set; }
}
