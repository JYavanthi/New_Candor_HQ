namespace IT_Portal.Domain.IT_Models;

public partial class RatingMaster
{
    public int Id { get; set; }

    public int? FkCalendarId { get; set; }

    public string? Scale { get; set; }

    public string? Definition { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual CalendarMaster? FkCalendar { get; set; }
}
