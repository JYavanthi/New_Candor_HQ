namespace IT_Portal.Domain.IT_Models;

public partial class AdditionalVisitor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? CompanyName { get; set; }

    public DateTime? Date { get; set; }

    public TimeOnly? ToTime { get; set; }

    public TimeOnly? FromTime { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Temp10 { get; set; }

    public string? Temp9 { get; set; }

    public string? Temp8 { get; set; }

    public string? Temp7 { get; set; }

    public string? Temp6 { get; set; }

    public string? Temp5 { get; set; }

    public string? Temp4 { get; set; }

    public string? Temp3 { get; set; }

    public string? Temp2 { get; set; }

    public string? Temp1 { get; set; }

    public int Fkid { get; set; }

    public virtual Visitor Fk { get; set; } = null!;
}
