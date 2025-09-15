namespace IT_Portal.Domain.IT_Models;

public partial class ItsolutionsLikesAndDisLikesTable
{
    public int Id { get; set; }

    public int? FkSolId { get; set; }

    public bool? LikedOrDisLiked { get; set; }

    public string? LikedOrDisLikedBy { get; set; }

    public DateTime? LikedOrDisLikedOn { get; set; }
}
