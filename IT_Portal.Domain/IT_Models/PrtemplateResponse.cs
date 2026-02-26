using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class PrtemplateResponse
{
    public int Trid { get; set; }

    public int? PrId { get; set; }

    public int? TemplateId { get; set; }

    public int? LessonLearnedId { get; set; }

    public int? TemplateDtlsId { get; set; }

    public string? Response { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
