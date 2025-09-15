namespace IT_Portal.Domain.IT_Models;

public partial class ItSolutionsCommentsTable
{
    public int Id { get; set; }

    public int FkSolutionId { get; set; }

    public string? Comments { get; set; }

    public string? CommentedBy { get; set; }

    public DateTime? CommentedOn { get; set; }

    public virtual ItSolution FkSolution { get; set; } = null!;

    public virtual ICollection<ItSolutionsReplyTbl> ItSolutionsReplyTbls { get; set; } = new List<ItSolutionsReplyTbl>();
}
