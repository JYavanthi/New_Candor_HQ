using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class AssetDetail
{
    public int AssetsDetailsId { get; set; }

    public int EmpNo { get; set; }

    public int Category { get; set; }

    public int AssetNo { get; set; }

    public string HostName { get; set; } = null!;

    public string AssetType { get; set; } = null!;

    public string IpAddress { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
