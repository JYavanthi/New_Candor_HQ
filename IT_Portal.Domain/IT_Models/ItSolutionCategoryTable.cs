namespace IT_Portal.Domain.IT_Models;

public partial class ItSolutionCategoryTable
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? CreatedOn { get; set; }

    public DateOnly? ModifiedOn { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }
}
