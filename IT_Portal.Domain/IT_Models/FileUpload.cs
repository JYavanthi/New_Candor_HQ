namespace IT_Portal.Domain.IT_Models;

public partial class FileUpload
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Path { get; set; }

    public string? FileImage { get; set; }

    public string? Size { get; set; }

    public string? UploadedProfile { get; set; }

    public int? FkEmpId { get; set; }

    public string? EmployeeId { get; set; }

    public int? FkAssesmentId { get; set; }

    public string? Temp { get; set; }

    public string? Temp9 { get; set; }

    public string? Temp8 { get; set; }

    public string? Temp7 { get; set; }

    public string? Temp6 { get; set; }

    public string? Temp5 { get; set; }

    public string? Temp4 { get; set; }

    public string? Temp3 { get; set; }

    public string? Temp2 { get; set; }

    public string? Temp1 { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual AssesmentMaster? FkAssesment { get; set; }

    public virtual EmployeeMaster? FkEmp { get; set; }
}
