namespace IT_Portal.Domain.IT_Models;

public partial class Band
{
    public int Id { get; set; }

    public string? Bandid { get; set; }

    public string? Bandtxt { get; set; }

    public DateTime? Crdat { get; set; }

    public byte[] Cputm { get; set; } = null!;

    public string? Uname { get; set; }

    public DateTime? Aedtm { get; set; }

    public string? Aename { get; set; }
}
