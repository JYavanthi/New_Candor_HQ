namespace IT_Portal.Domain.IT_Models;

public partial class EssTemplate
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Path { get; set; } = null!;
}
