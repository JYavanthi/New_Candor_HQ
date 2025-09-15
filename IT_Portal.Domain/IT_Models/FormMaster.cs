namespace IT_Portal.Domain.IT_Models;

public partial class FormMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ModuleName { get; set; }

    public string? FormDescription { get; set; }

    public string? Url { get; set; }

    public string? Temp1 { get; set; }

    public int? MenuId { get; set; }

    public int? SubMenuId { get; set; }

    public int? SortOrder { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public int? ModuleEnableId { get; set; }

    public bool? IsNetWorkAccess { get; set; }

    public virtual ICollection<DetailStructureInput> DetailStructureInputs { get; set; } = new List<DetailStructureInput>();

    public virtual ICollection<MastersStructureInput> MastersStructureInputs { get; set; } = new List<MastersStructureInput>();

    public virtual ICollection<ProfileFormMaintenance> ProfileFormMaintenances { get; set; } = new List<ProfileFormMaintenance>();
}
