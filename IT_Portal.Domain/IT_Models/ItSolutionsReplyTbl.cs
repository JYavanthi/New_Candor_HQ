namespace IT_Portal.Domain.IT_Models;

public partial class ItSolutionsReplyTbl
{
    public int Id { get; set; }

    public int FkCommentsId { get; set; }

    public string? Replies { get; set; }

    public string? ReplyedBy { get; set; }

    public DateTime? ReplyedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ItSolutionsCommentsTable FkComments { get; set; } = null!;
}
