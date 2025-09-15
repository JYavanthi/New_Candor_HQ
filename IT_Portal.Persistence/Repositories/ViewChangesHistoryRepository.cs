using AutoMapper;
using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.GetHistoryData;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class ViewChangesHistoryRepository : IViewChangesHistory
    {
        private readonly MicroLabsDevContext _context;
        private readonly IMapper _mapper;

        public ViewChangesHistoryRepository(MicroLabsDevContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<ChangeRequestHistoryResultDto>> GetChangeRequestHistory(string crID)
        {
            List<ChangeRequestHistoryResultDto> retObjList = new List<ChangeRequestHistoryResultDto>();
            ChangeRequestHistoryResultDto retObj = new ChangeRequestHistoryResultDto();
            try
            {
                var listData = await _context.ChangeRequestHistories.Where(x => x.Crcode == crID).ToListAsync();
                foreach (var item in listData)
                {
                    retObj = _mapper.Map<ChangeRequestHistoryResultDto>(item);
                    retObj.CrOwnerName = await _context.SupportTeams.Where(x => x.EmpId == item.Crowner).Select(x => x.FirstName).FirstOrDefaultAsync();
                    retObj.CreatedName = await _context.SupportTeams.Where(x => x.EmpId == item.CreatedBy).Select(x => x.FirstName).FirstOrDefaultAsync();
                    retObj.ModifiedName = await _context.SupportTeams.Where(x => x.EmpId == item.ModifiedBy).Select(x => x.FirstName).FirstOrDefaultAsync();
                    retObjList.Add(retObj);


                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retObjList;
        }

        public async Task<List<ECrApproverHistory>> GetCrApproverHistory(int crID)
        {

            List<ECrApproverHistory> retObjList = new List<ECrApproverHistory>();
            ECrApproverHistory retObj = new ECrApproverHistory();
            try
            {
                var listData = await _context.CrapproverHistories
    .Where(x => x.Crid == crID)
    .Join(
        _context.Employees,
        history => history.ApproverId.ToString(),
        emp => emp.EmployeeNo,
        (history, emp) => new
        {
            History = history,
            Employee = emp
        })
    .Join(
        _context.Employees,
        created => created.History.CreatedBy.ToString(),
        createdBy => createdBy.EmployeeNo,
        (created, createdBy) => new
        {
            created.History,
            created.Employee,
            CreatedByEmployee = createdBy
        })
    .Join(
        _context.Employees,
        modified => modified.History.ModifiedBy.ToString(),
        modifiedBy => modifiedBy.EmployeeNo,
        (modified, modifiedBy) => new ECrApproverHistory
        {
            ItcrapproverHistoryId = modified.History.ItcrapproverHistoryId,
            CrhistoryDt = modified.History.CrhistoryDt,
            ItcrapproverId = modified.History.ItcrapproverId,
            PlantId = modified.History.PlantId,
            SupportId = modified.History.SupportId,
            Crid = modified.History.Crid,
            ApproverLevel = modified.History.ApproverLevel,
            Comments = modified.History.Comments,
            Stage = modified.History.Stage,
            ApproverId = modified.History.ApproverId,
            Remarks = modified.History.Remarks,
            Status = modified.History.Status,
            Attachment = modified.History.Attachment,
            CreatedBy = modified.History.CreatedBy,
            ModifiedBy = modified.History.ModifiedBy,
            CreatedByName = modified.CreatedByEmployee.FirstName + ' ' + modified.CreatedByEmployee.MiddleName + ' ' + modified.CreatedByEmployee.LastName,
            CreatedDt = modified.History.CreatedDt,
            ModifiedDt = modified.History.ModifiedDt,
            ApprovedDt = modified.History.ApprovedDt,
            ModifiedByName = modifiedBy.FirstName + ' ' + modifiedBy.MiddleName + ' ' + modifiedBy.LastName,
            approverName = modified.Employee.FirstName + ' ' + modified.Employee.MiddleName + ' ' + modified.Employee.LastName
        })
    .ToListAsync();

                retObjList = _mapper.Map<List<ECrApproverHistory>>(listData);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retObjList;
        }

        public async Task<List<EcrExecutionPlanHistory>> GetCrExecutionPlanHistory(int crID)
        {

            List<EcrExecutionPlanHistory> retObjList = new List<EcrExecutionPlanHistory>();
            EcrExecutionPlanHistory retObj = new EcrExecutionPlanHistory();
            try
            {
                var listData = await _context.CrexecutionPlanHistories
        .Where(x => x.Itcrid == crID)
        .GroupJoin(
            _context.SupportTeams,
            history => history.AssignedTo,
            emp => emp.EmpId,
            (history, assignedToGroup) => new
            {
                History = history,
                AssignedToGroup = assignedToGroup
            })
        .SelectMany(
            historyWithAssignedTo => historyWithAssignedTo.AssignedToGroup.DefaultIfEmpty(),
            (historyWithAssignedTo, assignedToEmployee) => new
            {
                History = historyWithAssignedTo.History,
                AssignedToEmployee = assignedToEmployee
            })
        .GroupJoin(
            _context.SupportTeams,
            historyWithAssignedTo => historyWithAssignedTo.History.ForwardedTo,
            emp => emp.EmpId,
            (historyWithAssignedTo, forwardedToGroup) => new
            {
                History = historyWithAssignedTo.History,
                AssignedToEmployee = historyWithAssignedTo.AssignedToEmployee,
                ForwardedToGroup = forwardedToGroup
            })
        .SelectMany(
            historyWithAssignedTo => historyWithAssignedTo.ForwardedToGroup.DefaultIfEmpty(),
            (historyWithAssignedTo, forwardedToEmployee) => new EcrExecutionPlanHistory
            {
                ItcrexecHistoryId = historyWithAssignedTo.History.ItcrexecHistoryId,
                CrhistoryDt = historyWithAssignedTo.History.CrhistoryDt,
                Remarks = historyWithAssignedTo.History.Remarks,
                ItcrexecId = historyWithAssignedTo.History.ItcrexecId,
                Status = historyWithAssignedTo.History.Status,
                Itcrid = historyWithAssignedTo.History.Itcrid,
                ExecutionStepName = historyWithAssignedTo.History.ExecutionStepName,
                SysLandscape = historyWithAssignedTo.History.SysLandscape,
                ExecutionStepDesc = historyWithAssignedTo.History.ExecutionStepDesc,
                CreatedBy = historyWithAssignedTo.History.CreatedBy,
                ModifiedBy = historyWithAssignedTo.History.ModifiedBy,
                CreatedByName = "", // Placeholder if needed
                CreatedDt = historyWithAssignedTo.History.CreatedDt,
                ModifiedDt = historyWithAssignedTo.History.ModifiedDt,
                ModifiedByName = "", // Placeholder if needed
                AssignedTo = historyWithAssignedTo.History.AssignedTo,
                AssignedToName = historyWithAssignedTo.AssignedToEmployee != null
                    ? historyWithAssignedTo.AssignedToEmployee.FirstName + ' ' + historyWithAssignedTo.AssignedToEmployee.MiddleName + ' ' + historyWithAssignedTo.AssignedToEmployee.LastName
                    : "", // Handle null case
                ForwardedTo = historyWithAssignedTo.History.ForwardedTo,
                ForwardedToName = forwardedToEmployee != null
                    ? forwardedToEmployee.FirstName + ' ' + forwardedToEmployee.MiddleName + ' ' + forwardedToEmployee.LastName
                    : "", // Handle null case
                StartDt = historyWithAssignedTo.History.StartDt,
                EndDt = historyWithAssignedTo.History.EndDt,
                Attachments = historyWithAssignedTo.History.Attachments,
                ForwardStatus = historyWithAssignedTo.History.ForwardStatus,
                ForwardedDt = historyWithAssignedTo.History.ForwardedDt,
                ReasonForwarded = historyWithAssignedTo.History.ReasonForwarded,
                PickedStatus = historyWithAssignedTo.History.PickedStatus,
                PickedDt = historyWithAssignedTo.History.PickedDt,
                ActualStartDt = historyWithAssignedTo.History.ActualStartDt,
                ActualEndDt = historyWithAssignedTo.History.ActualEndDt,
                DependSysLandscape = historyWithAssignedTo.History.DependSysLandscape,
                DependTaskId = historyWithAssignedTo.History.DependTaskId,
            })
    .ToListAsync();
            Explanation:

                retObjList = _mapper.Map<List<EcrExecutionPlanHistory>>(listData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retObjList;
        }

    }
}
