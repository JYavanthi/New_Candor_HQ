using IT_Portal.Application.Contracts;
using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Contracts.Persistence.Assets;
using IT_Portal.Application.Contracts.Persistence.RptIssue;
using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.Repositories;
using IT_Portal.Persistence.Repositories.Assets;
using IT_Portal.Persistence.Repositories.RptIssue;
using IT_Portal.Persistence.Repositories.SR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IT_Portal.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<MicroLabsDevContext>();
            services.AddScoped<ICategoryRepo, CategoryRepository>();
            services.AddScoped<IChangeRequest, ChangeRequestRepository>();
            services.AddScoped<ICRapproval, CRapproveRepository>();
            services.AddScoped<ICRexecutive, CRexecutiveRepository>();
            services.AddScoped<ICrrelease, CRreleaseRepository>();
            services.AddScoped<INatureofChange, NatureofChangeRepository>();
            services.AddScoped<IClasifications, ClassificationRepository>();
            services.AddScoped<IPlantID, PlantidRepository>();
            services.AddScoped<ISystemLandscape, SystemLandscapeRepository>();
            services.AddScoped<IReference, ReferenceRepository>();
            services.AddScoped<Icrcloser, CrcloserRepository>();
            services.AddScoped<ICategorytyp, CategoryTypRepository>();
            services.AddScoped<IEmployeeMasters, EmployeeMasterRepository>();
            services.AddScoped<ISupportTeam, SupportTeamRepository>();
            services.AddScoped<IReferenceType, ReferenceTypeRepository>();
            services.AddScoped<Ipriority, PriorityRepository>();
            services.AddScoped<IgetApprover, GetApproverRepository>();
            services.AddScoped<ICRlession, CRlessionRepository>();
            services.AddScoped<ISupportteamAssigned, SupportTeamAssigned>();
            services.AddScoped<ICRfollowUp, CRfollowUpRepository>();
            services.AddScoped<IVWcrexecute, ExecuteReportRepository>();
            services.AddScoped<IBarchartvalue, BarchartRepository>();
            services.AddScoped<IIssueList, IssueListRepository>();
            services.AddScoped<IIssueAssignedTo, IssueAssignedToRepository>();
            services.AddScoped<IissueResolution, IssueResolutionRepository>();
            services.AddScoped<IVWSupportEngineer, VwSupportengineerRepository>();
            services.AddScoped<IVWApproverCR, VwApproverCrRepository>();
            services.AddScoped<ISupportID, ITSupportRepository>();
            services.AddScoped<ICRSummary, CRSummaryRepository>();
            services.AddScoped<ICRApproverHistory, CRApproverHistoryRepository>();
            services.AddScoped<IViewChangeRequest, ViewChangeRequestRepository>();
            services.AddScoped<ICRExecutionHistory, CREexcutionHistoryRepository>();
            services.AddScoped<ISystemlandscapeSp, SystemLandscapeSpRepository>();
            services.AddScoped<ICheckList, CheckListRepository>();
            services.AddScoped<IViewChangesHistory, ViewChangesHistoryRepository>();
            services.AddScoped<ICRtemplate, CRTemplateRepository>();
            services.AddScoped<ICRTemplateExe, CRTemplateExeRepository>();
            services.AddScoped<ISlaMaster, SlaMasterRepository>();
            services.AddScoped<IServiceCitrixList, ServiceCitrixRepository>();
            services.AddScoped<IViewcremail, ViewcremailRepository>();
            services.AddScoped<IchatBox, chatBoxImplementation>();
            services.AddScoped<IGetApproverEmail, GetApprovalEmailRepository>();
            services.AddScoped<IsoftwareService, softwareService>();
            services.AddScoped<IvalidateUser, UserValidation>();
            services.AddScoped<IGetIssueReport, GetIssuseReportRepository>();
            services.AddScoped<ISupportMaster, SupportRespository>();
            services.AddScoped<ISRApprover, SRApproverRepository>();
            services.AddScoped<IserviceMaster, serviceMaster>();
            services.AddScoped<ISoftware, SRSoftwareRepository>();
            services.AddScoped<ISREmail, SREmailRepository>();
            services.AddScoped<ISRExternalDrive, SRExternalDriveRespository>();
            services.AddScoped<ISRFTPAccess, SRFTPAccessRespository>();
            services.AddScoped<ISRUSBAccess, SRUSBAccessRespository>();
            services.AddScoped<ISRWindowsLogin, SRWindowsLoginRepository>();
            services.AddScoped<ISRCitrixAccess, SRCitrixAccessRepository>();
            services.AddScoped<ISRVPNAccess, SRVPNAccessRepository>();
            services.AddScoped<ISRURLAccess, SRURLAccessRepository>();
            services.AddScoped<ISRWIFIAccess, SRWIFIAccessRespository>();
            services.AddScoped<ISRFileAccess, SRFileAccessRespository>();
            services.AddScoped<ISRRestoration, SRRestorationRespository>();
            services.AddScoped<ISRRemoteAccess, SRRemoteRepository>();
            services.AddScoped<IAntivirus, AntivirusRespository>();
            services.AddScoped<IVirtual, SRVirtualRespository>();
            services.AddScoped<IAssetRequest, AssetRepository>();
            services.AddScoped<IITSpareRequest, ITSpareRequestRepository>();
            services.AddScoped<IProjectManagement, ProjectMasterRepository>();
            services.AddScoped<IProjectManagement, Repositories.ProjectMasterRepository>();
            services.AddScoped<ISoftwareLibrary, SoftwareLibraryRepositories>();
            services.AddScoped<ISoftwareVersion, SoftwareVersionRepository>();
            services.AddScoped<IProjectClosure, ProjectClosureRepository>();
            services.AddScoped<IProjectLessons, ProjectLessonsRepository>();
            services.AddScoped<IProjectTemplate, ProjectTemplateRepository>();
            services.AddScoped<IprojectGroup, projectGroup>();
            services.AddScoped<IprojectTask, projectTaskRepository>();
            services.AddScoped<IprojectMilestone, projectMilestoneRepository>();
            services.AddScoped<IprojectIssue, projectIssueRepository>();
            services.AddScoped<IChecklistTemplate, ChecklistTemplateRepository>();
            return services;
        }
    }
}
