namespace IT_Portal.Domain.IT_Models;

public partial class GetUserAccessForm
{
    public int Id { get; set; }

    public int? MenuId { get; set; }

    public int? SubMenuId { get; set; }

    public string? Name { get; set; }

    public string? ModuleName { get; set; }

    public string? Url { get; set; }

    public bool? IsActive { get; set; }

    public int? FkProfileId { get; set; }

    public string? Temp1 { get; set; }

    public int? ModuleEnableId { get; set; }

    public bool? IsNetWorkAccess { get; set; }
}
