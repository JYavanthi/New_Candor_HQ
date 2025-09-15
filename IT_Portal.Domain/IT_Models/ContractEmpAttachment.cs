namespace IT_Portal.Domain.IT_Models;

public partial class ContractEmpAttachment
{
    public int Id { get; set; }

    public int FkContractId { get; set; }

    public string? FilePath { get; set; }

    public string? FileName { get; set; }

    public virtual ContractEmployeeM FkContract { get; set; } = null!;
}
