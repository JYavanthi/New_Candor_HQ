namespace IT_Portal.Domain.IT_Models;

public partial class TblInhouseMagizne
{
    public int Id { get; set; }

    public string? MagizneName { get; set; }

    public string? MagizneYear { get; set; }

    public string? MagizneUrl { get; set; }

    public string? MagazineType { get; set; }

    public string? Createdby { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? Modifiedby { get; set; }

    public DateTime? Modifiedon { get; set; }
}
