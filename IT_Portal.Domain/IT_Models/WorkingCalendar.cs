namespace IT_Portal.Domain.IT_Models;

public partial class WorkingCalendar
{
    public int Id { get; set; }

    public int? Cyear { get; set; }

    public int? Location { get; set; }

    public int? PayGroup { get; set; }

    public int? EmpCat { get; set; }

    public int? Day { get; set; }

    public string? Jan { get; set; }

    public string? Feb { get; set; }

    public string? Mar { get; set; }

    public string? Apr { get; set; }

    public string? May { get; set; }

    public string? Jun { get; set; }

    public string? Jul { get; set; }

    public string? Aug { get; set; }

    public string? Sep { get; set; }

    public string? Oct { get; set; }

    public string? Nov { get; set; }

    public string? Dec { get; set; }

    public string? Type { get; set; }

    public string? TypeCode { get; set; }

    public string? TypeName { get; set; }

    public string? HolidayTypeCode { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
