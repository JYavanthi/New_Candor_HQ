namespace IT_Portal.Domain.IT_Models;

public partial class User
{
    public int Id { get; set; }

    public string EmployeeId { get; set; } = null!;

    public string? PwdQuestion { get; set; }

    public string? PwdAnswer { get; set; }

    public DateTime? Doj { get; set; }
}
