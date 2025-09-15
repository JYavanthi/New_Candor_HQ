namespace IT_Portal.Domain.IT_Models;

public partial class ItSolutionsCommentsLikesAndDisLikesTable
{
    public int Id { get; set; }

    public int? FkReplyId { get; set; }

    public bool? LikedOrDisLiked { get; set; }

    public string? LikedOrDisLikedBy { get; set; }

    public DateOnly? LikedOrDisLikedOn { get; set; }
}
