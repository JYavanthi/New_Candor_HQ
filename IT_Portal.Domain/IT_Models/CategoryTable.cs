namespace IT_Portal.Domain.IT_Models;

public partial class CategoryTable
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }
}
