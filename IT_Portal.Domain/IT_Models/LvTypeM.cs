namespace IT_Portal.Domain.IT_Models;

public partial class LvTypeM
{
    public int Id { get; set; }

    public int LvTypeid { get; set; }

    public string LvType { get; set; } = null!;

    public string? LvShrt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
