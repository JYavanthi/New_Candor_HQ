namespace IT_Portal.Domain.IT_Models;

public partial class TaskAttachment
{
    public int TaskAttachmentId { get; set; }

    public int TaskId { get; set; }

    public string FilePath { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public virtual TaskManager Task { get; set; } = null!;
}
