namespace IT_Portal.Domain.IT_Models;

public partial class LeaveStructure
{
    public int Id { get; set; }

    public string? Mandt { get; set; }

    public string? Bukrs { get; set; }

    public string? Werks { get; set; }

    public int? Paygroup { get; set; }

    public int? Staffcat { get; set; }

    public string? Leavtyp { get; set; }

    public string? Leavtxt { get; set; }

    public decimal? Lnodays { get; set; }

    public bool? Laccum { get; set; }

    public decimal? Lacclt { get; set; }

    public bool? Lencash { get; set; }

    public decimal? Lenclt { get; set; }

    public decimal? Lminalw { get; set; }

    public decimal? Lmaxalw { get; set; }

    public decimal? Lmindur { get; set; }

    public bool? Lhdallow { get; set; }

    public int? Lmaxtime { get; set; }

    public decimal? Lattlt { get; set; }

    public bool? Ladv { get; set; }

    public decimal? Lmaxadv { get; set; }

    public bool? Lwkend { get; set; }

    public bool? Lihol { get; set; }

    public bool? Lpiadv { get; set; }

    public decimal? Ladvday { get; set; }

    public bool? Cldm { get; set; }

    public decimal? Month { get; set; }

    public string? Gesch { get; set; }

    public DateTime? Crdat { get; set; }

    public byte[] Cputm { get; set; } = null!;

    public string? Uname { get; set; }

    public DateTime? Aedtm { get; set; }

    public bool? Awothltyp { get; set; }

    public string? Leavetypes { get; set; }

    public string? Applicablewith { get; set; }

    public decimal? Lhalfyr { get; set; }

    public bool? AutoApprove { get; set; }

    public string? AutoApproveAfterDays { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? Showzerobalanceleave { get; set; }
}
