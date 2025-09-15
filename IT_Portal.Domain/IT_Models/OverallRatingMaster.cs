namespace IT_Portal.Domain.IT_Models;

public partial class OverallRatingMaster
{
    public int Id { get; set; }

    public int? FkCalenderId { get; set; }

    public string? Rating { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual CalendarMaster? FkCalender { get; set; }
}
