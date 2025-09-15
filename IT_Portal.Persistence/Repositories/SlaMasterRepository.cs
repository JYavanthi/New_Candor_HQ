using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class SlaMasterRepository : ISlaMaster
    {
        private readonly MicroLabsDevContext _context;
        public SlaMasterRepository(MicroLabsDevContext context)
        {
            this._context = context;
            /*I Like you toooooooooooooooooooooooooo much*/
        }

        public async Task<CommonRsult> postslamaster(SPSlaMaster slaMaster)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SLA", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", slaMaster.Flag);
                    cmd.Parameters.AddWithValue("@ITSLAID", slaMaster.ITSLAID);
                    cmd.Parameters.AddWithValue("@CategoryID", slaMaster.CategoryID);
                    cmd.Parameters.AddWithValue("@ClassificationID", slaMaster.ClassificationID);
                    cmd.Parameters.AddWithValue("@CategoryTypID", slaMaster.CategoryTypID);
                    cmd.Parameters.AddWithValue("@SupportID", slaMaster.SupportID);
                    cmd.Parameters.AddWithValue("@WaitTime", slaMaster.WaitTime);
                    cmd.Parameters.AddWithValue("@WaitTimeUnit", slaMaster.WaitTimeUnit);
                    cmd.Parameters.AddWithValue("@AssignedTo", slaMaster.AssignedTo);
                    cmd.Parameters.AddWithValue("@PlantID", slaMaster.PlantID);
                    cmd.Parameters.AddWithValue("@Escalation1", slaMaster.Escalation1);
                    cmd.Parameters.AddWithValue("@WaitTimeEscal1", slaMaster.WaitTimeEscal1);
                    cmd.Parameters.AddWithValue("@WaitTimeUnitEscal1", slaMaster.WaitTimeUnitEscal1);
                    cmd.Parameters.AddWithValue("@Escalation2", slaMaster.Escalation2);
                    cmd.Parameters.AddWithValue("@WaitTimeEscal2", slaMaster.WaitTimeEscal2);
                    cmd.Parameters.AddWithValue("@WaitTimeUnitEscal2", slaMaster.WaitTimeUnitEscal2);
                    cmd.Parameters.AddWithValue("@CreatedBy", slaMaster.CreatedBy);

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";

                    }
                }
            }
            catch (Exception)
            {
                result.Type = "E";
                result.Message = "Insert failed";
            }
            return result;
        }


        public bool deleteSlaByCatId(int id)
        {
            try
            {
                var sla = _context.Slas.Where(m => m.Itslaid == id).FirstOrDefault();

                if (sla != null)
                {
                    _context.Slas.Remove(sla);

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            return true;

        }
        async Task<List<Esla>> ISlaMaster.GetSLAlist(int id)
        {
            var data = await _context.GetSlalists.Where(m => id == 0 || id == null ? true : m.Itslaid == id)
    .Join(
        _context.Employees,
        sla => sla.AssignedTo.ToString(),
        emp => emp.EmployeeNo,
        (sla, emp) => new
        {
            GetSlalist = sla,
            Employee = emp
        }
    )
    .Join(
        _context.Employees,
        slaEmp => slaEmp.GetSlalist.Escalation1.ToString(),
        escalation1 => escalation1.EmployeeNo,
        (slaEmp, escalation1) => new
        {
            GetSlalist = slaEmp.GetSlalist,
            Employee = slaEmp.Employee,
            Escalation1 = escalation1
        }
    )
    .Join(
        _context.Employees,
        slaEscalation1 => slaEscalation1.GetSlalist.Escalation2.ToString(),
        escalation2 => escalation2.EmployeeNo,
        (slaEscalation1, escalation2) => new
        {
            GetSlalist = slaEscalation1.GetSlalist,
            Employee = slaEscalation1.Employee,
            Escalation1 = slaEscalation1.Escalation1,
            Escalation2 = escalation2
        }
    )
    .Select(result => new Esla
    {
        Itslaid = result.GetSlalist.Itslaid,
        AssignedTo = result.GetSlalist.AssignedTo,
        CategoryId = result.GetSlalist.CategoryId,
        CategoryName = result.GetSlalist.CategoryName,
        CategoryType = result.GetSlalist.CategoryType,
        CategoryTypId = result.GetSlalist.CategoryTypId,
        ClassificationId = result.GetSlalist.ClassificationId,
        ClassificationName = result.GetSlalist.ClassificationName,
        CreatedBy = result.GetSlalist.CreatedBy,
        Escalation1 = result.GetSlalist.Escalation1,
        Escalation2 = result.GetSlalist.Escalation2,
        PlantId = result.GetSlalist.PlantId,
        SupportId = result.GetSlalist.SupportId,
        WaitTime = result.GetSlalist.WaitTime,
        WaitTimeEscal1 = result.GetSlalist.WaitTimeEscal1,
        WaitTimeUnit = result.GetSlalist.WaitTimeUnit,
        WaitTimeUnitEscal1 = result.GetSlalist.WaitTimeUnitEscal1,
        WaitTimeUnitEscal2 = result.GetSlalist.WaitTimeUnitEscal2,
        AssignedEmployee = $"{result.Employee.FirstName} {result.Employee.LastName}",
        Escalation1Name = $"{result.Escalation1.FirstName} {result.Escalation1.LastName}",
        Escalation2Name = $"{result.Escalation2.FirstName} {result.Escalation2.LastName}"
    })
    .ToListAsync();
            return data;
        }

        async Task<List<Esla>> ISlaMaster.getSlaByCatId(ErequestPRdate req)
        {
            var data = await _context.GetSlalists.Where(m => m.CategoryId == req.categoryId && m.CategoryTypId == req.categoryTypeId)
    .Select(result => new Esla
    {
        Itslaid = result.Itslaid,
        AssignedTo = result.AssignedTo,
        CategoryId = result.CategoryId,
        CategoryName = result.CategoryName,
        CategoryType = result.CategoryType,
        CategoryTypId = result.CategoryTypId,
        ClassificationId = result.ClassificationId,
        ClassificationName = result.ClassificationName,
        CreatedBy = result.CreatedBy,
        Escalation1 = result.Escalation1,
        Escalation2 = result.Escalation2,
        PlantId = result.PlantId,
        SupportId = result.SupportId,
        WaitTime = result.WaitTime,
        WaitTimeEscal1 = result.WaitTimeEscal1,
        WaitTimeUnit = result.WaitTimeUnit,
        WaitTimeUnitEscal1 = result.WaitTimeUnitEscal1,
        WaitTimeUnitEscal2 = result.WaitTimeUnitEscal2
    })
    .ToListAsync();
            return data;
        }
        public EworkingDayCalRes getWorkingDays(EworkingDayCalReq EworkingDayCalObj)
        {
            EworkingDayCalRes result = new EworkingDayCalRes();
            result.workngDays = 4;
            DayOfWeek currentDay = DateTime.Now.DayOfWeek;

            int value;
            switch (currentDay)
            {
                case DayOfWeek.Monday:
                    value = 5;
                    break;
                case DayOfWeek.Tuesday:
                    value = 4;
                    break;
                case DayOfWeek.Wednesday:
                    value = 3;
                    break;
                case DayOfWeek.Thursday:
                    value = 2;
                    break;
                case DayOfWeek.Friday:
                    value = 1;
                    break;
                default:
                    value = 0;
                    break;
            }

            return result;
        }
    }
}
//here is the code