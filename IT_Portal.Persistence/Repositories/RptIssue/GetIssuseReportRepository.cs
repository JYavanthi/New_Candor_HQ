using IT_Portal.Application.Contracts.Persistence.RptIssue;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories.RptIssue
{
    public class GetIssuseReportRepository : IGetIssueReport
    {
        private readonly MicroLabsDevContext _context;

        public GetIssuseReportRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }
        public async Task<CommonRsult> GetIssueReport(EcrFilterRequest filterRquest)
        {
            var result = new CommonRsult();
            try
            {
                var totalCount = await _context.VwIssueLists.CountAsync();
                var a = from m in _context.VwIssueLists
                        join employee in _context.Employees on m.Raisedbyid.ToString() equals employee.EmployeeNo into e
                        from employee in e.DefaultIfEmpty()
                            //
                        join RaisedByEmp in _context.Employees on m.Raisedbyid.ToString() equals RaisedByEmp.EmployeeNo into Rais
                        from RaisedByEmp in Rais.DefaultIfEmpty()
                        join IssuerisedEmp in _context.Employees on m.Issuerisedforid.ToString() equals IssuerisedEmp.EmployeeNo into Issue
                        from IssuerisedEmp in Issue.DefaultIfEmpty()
                        join UpdateEmp in _context.Employees on m.ModifiedBy.ToString() equals UpdateEmp.EmployeeNo into up
                        from UpdateEmp in up.DefaultIfEmpty()
                            /*join issuseHis in _context.VwIssueListHistories on m.IssueId equals issuseHis.IssueId
*/
                            //join ClosedBy in _context.Employees on m.ClosedBY.ToString() equals ClosedBy.EmployeeNo

                            //
                        join payGroup in _context.PaygroupMasters on employee.PaygroupId equals payGroup.Paygroup into pg
                        from payGroup in pg.DefaultIfEmpty()
                        join category in _context.EmpCategoryMasters on employee.EmployeeCategoryid equals category.Staffcat into cat
                        from category in cat.DefaultIfEmpty()
                        select new
                        {
                            IssueId = m.IssueId,
                            IssueCode = m.IssueCode,
                            RaisedById = m.Raisedbyid,
                            RaisedByEmp = RaisedByEmp.FirstName + " " + RaisedByEmp.LastName,
                            IssueDate = m.IssueDate,
                            IssueShotDesc = m.IssueShotDesc,
                            IssueDesc = m.IssueDesc,
                            IssuerisedForId = m.Issuerisedforid,
                            Issuerisedfor = IssuerisedEmp.FirstName + " " + IssuerisedEmp.LastName,
                            IssueForGuest = m.IssueForGuest,
                            Type = m.Type,
                            PlantId = m.PlantId,
                            PlantName = m.Plantname,
                            Paygroup = payGroup.ShortDesc,
                            empcategory = category.Catltxt,
                            AssignedToId = m.AssignedToid,
                            AssignedTo = m.AssignedTo,
                            UpdateBy = UpdateEmp.FirstName + ' ' + UpdateEmp.LastName,
                            UpdateDt = m.ModifiedDt,
                            ResolveBy = m.ResolvedBy,
                            ResolveDt = m.ResolvedOn,
                            ResolveRemarks = m.ResolveRemarks,
                            ClosedBY = m.ClosedBy,
                            ClosedRemark = m.ClosedRemark,
                            ClosedDate = m.ClosedDate,
                            CategoryId = m.CategoryId,
                            CategoryName = m.CategoryName, // Get category name from the category table category.Catltxt
                            CategoryTypId = m.CategoryTypId,
                            CategoryType = m.CategoryType,
                            PriorityId = m.Priorityid,
                            PriorityName = m.PriorityName,
                            Status = m.Status,
                            AssignedById = m.Assignedbyid,
                            AssignedBy = m.AssignedBy,
                            AssignedOn = m.AssignedOn,
                            Remarks = m.Remarks,
                            CreatedBy = m.CreatedBy,
                            CreatedDt = m.CreatedDt,
                            ModifiedBy = m.ModifiedBy,
                            ModifiedDt = m.ModifiedDt,
                            SlaTime = m.SlaTime,
                            SlaUnit = m.Slaunit,
                            SlaDt = m.ProposedResolutionOn,
                            RaisedByFirstName = employee.FirstName,

                        };


                /* var paginatedResult = await a
                     .Skip((filterRquest.pageNumber - 1) * filterRquest.pageSize)
                     .Take(filterRquest.pageSize)
                     .ToListAsync();*/

                result.Data = a.OrderByDescending(m => m.IssueId).ToList();
                result.Count = totalCount;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }

        }
        public async Task<CommonRsult> GetIssueResolutoin(EcrFilterRequest filterRquest)
        {
            var result = new CommonRsult();
            try
            {

                var IssueResolutionvalue = _context.VwIssueListHistories.Where(d => d.Status == "Resolved");
                var a = from m in IssueResolutionvalue
                        join employee in _context.Employees on m.Raisedbyid.ToString() equals employee.EmployeeNo
                        join RaisedByEmp in _context.Employees on m.Raisedbyid.ToString() equals RaisedByEmp.EmployeeNo
                        join IssuerisedEmp in _context.Employees on m.Issuerisedforid.ToString() equals IssuerisedEmp.EmployeeNo
                        join UpdateEmp in _context.Employees on m.ModifiedBy.ToString() equals UpdateEmp.EmployeeNo
                        /*join ResolveEmp in _context.Employees on m.ResolvedBy.ToString() equals ResolveEmp.EmployeeNo*/

                        join payGroup in _context.PaygroupMasters on employee.PaygroupId equals payGroup.Paygroup into pg
                        from payGroup in pg.DefaultIfEmpty()
                        join category in _context.EmpCategoryMasters on employee.EmployeeCategoryid equals category.Staffcat into cat
                        from category in cat.DefaultIfEmpty()

                        orderby m.IssueCode descending

                        select new
                        {
                            IssueId = m.IssueId,
                            IssueCode = m.IssueCode,
                            RaisedById = m.Raisedbyid,
                            RaisedByEmp = RaisedByEmp.FirstName + " " + RaisedByEmp.LastName,
                            IssueDate = m.IssueDate,
                            IssueShotDesc = m.IssueShotDesc,
                            IssueDesc = m.IssueDesc,
                            IssuerisedForId = m.Issuerisedforid,
                            Issuerisedfor = IssuerisedEmp.FirstName + " " + IssuerisedEmp.LastName,
                            IssueForGuest = m.IssueForGuest,
                            Type = m.Type,
                            PlantId = m.PlantId,
                            PlantName = m.Plantname,
                            Paygroup = payGroup.ShortDesc,
                            empcategory = category.Catltxt,
                            AssignedToId = m.AssignedToid,
                            AssignedTo = m.AssignedTo,
                            UpdateBy = UpdateEmp.FirstName + ' ' + UpdateEmp.LastName,
                            UpdateDt = m.ModifiedDt,
                            ResolveById = m.ResolvedBy,
                            ResolveDt = m.ResolvedOn,
                            ResolveRemarks = m.ResolveRemarks,
                            ClosedBY = m.ClosedBy,
                            ClosedRemark = m.ClosedRemark,
                            ClosedDate = m.ClosedDate,
                            CategoryId = m.CategoryId,
                            CategoryName = m.CategoryName, // Get category name from the category table category.Catltxt
                            CategoryTypId = m.CategoryTypId,
                            CategoryType = m.CategoryType,
                            PriorityId = m.Priorityid,
                            PriorityName = m.PriorityName,
                            Status = m.Status,
                            AssignedById = m.Assignedbyid,
                            AssignedBy = m.AssignedBy,
                            /*AssignedOn = m.ass,*/
                            Remarks = m.Remarks,
                            CreatedBy = m.CreatedBy,
                            CreatedDt = m.CreatedDt,
                            ModifiedBy = m.ModifiedBy,
                            ModifiedDt = m.ModifiedDt,
                            SlaStatus = m.Slastatus,
                            /*   SlaTime = m.SlaTime,
                               SlaUnit = m.Slaunit,*/
                            RaisedByFirstName = employee.FirstName,

                        };

                result.Data = a.ToList();
                /*result.Count = totalCount;*/
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }

        }
    }
}
