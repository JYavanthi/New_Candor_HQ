namespace IT_Portal.Domain.IT_Models;

public partial class ItTraining
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public string? AreaOfTraining { get; set; }

    public string? Agenda { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? FromTime { get; set; }

    public TimeOnly? ToTime { get; set; }

    public string? ModeOfTraining { get; set; }

    public string? LocationOfTraining { get; set; }

    public string? VirtualMeetingTool { get; set; }

    public string? VirtualMeetingLink { get; set; }

    public string? VirtualMeetingPassword { get; set; }

    public string? IntendedAudience { get; set; }

    public string? ScheduleOfTraining { get; set; }

    public string? TrainedBy { get; set; }

    public string? DetailsOfTrainer { get; set; }

    public string? TrainingFrequency { get; set; }

    public bool? SendEmail { get; set; }

    public string? EmailId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? EndDate { get; set; }
}
