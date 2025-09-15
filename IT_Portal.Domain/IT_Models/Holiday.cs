namespace IT_Portal.Domain.IT_Models;

public partial class Holiday
{
    public int Id { get; set; }

    public int? Location { get; set; }

    public string HolidayName { get; set; } = null!;

    public string DayName { get; set; } = null!;

    public string? HolidayDate { get; set; }

    public int? Year { get; set; }

    public DateOnly? Date { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public int? PayGroup { get; set; }

    public string? Type { get; set; }

    public string? TypeCode { get; set; }

    public string? TypeName { get; set; }
}
