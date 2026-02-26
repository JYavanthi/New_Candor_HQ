using System;
using System.Collections.Generic;
using IT_Portal.Persistence.IT_Models;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.DatabaseContext;

public partial class MicroLabsDevContext : DbContext
{
    public MicroLabsDevContext()
    {
    }

    public MicroLabsDevContext(DbContextOptions<MicroLabsDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Approver> Approvers { get; set; }

    public virtual DbSet<ApproverHistory> ApproverHistories { get; set; }

    public virtual DbSet<AssetDetail> AssetDetails { get; set; }

    public virtual DbSet<AttachFile> AttachFiles { get; set; }

    public virtual DbSet<BackupSupport> BackupSupports { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryTyp> CategoryTyps { get; set; }

    public virtual DbSet<ChangeRequest> ChangeRequests { get; set; }

    public virtual DbSet<ChangeRequestHistory> ChangeRequestHistories { get; set; }

    public virtual DbSet<Checklist> Checklists { get; set; }

    public virtual DbSet<ChecklistTemplate> ChecklistTemplates { get; set; }

    public virtual DbSet<Classification> Classifications { get; set; }

    public virtual DbSet<Crapprover> Crapprovers { get; set; }

    public virtual DbSet<CrapproverHistory> CrapproverHistories { get; set; }

    public virtual DbSet<CrexecutionPlan> CrexecutionPlans { get; set; }

    public virtual DbSet<CrexecutionPlanHistory> CrexecutionPlanHistories { get; set; }

    public virtual DbSet<Crfollowup> Crfollowups { get; set; }

    public virtual DbSet<Crlesson> Crlessons { get; set; }

    public virtual DbSet<Crmilestone> Crmilestones { get; set; }

    public virtual DbSet<Crrelease> Crreleases { get; set; }

    public virtual DbSet<Crtemplate> Crtemplates { get; set; }

    public virtual DbSet<CrtemplateDtl> CrtemplateDtls { get; set; }

    public virtual DbSet<DepartmentMaster> DepartmentMasters { get; set; }

    public virtual DbSet<DesignationMaster> DesignationMasters { get; set; }

    public virtual DbSet<EmailGroup> EmailGroups { get; set; }

    public virtual DbSet<EmpCategoryMaster> EmpCategoryMasters { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<GetSlalist> GetSlalists { get; set; }

    public virtual DbSet<Isattachment> Isattachments { get; set; }

    public virtual DbSet<IssueCommentsBox> IssueCommentsBoxes { get; set; }

    public virtual DbSet<IssueList> IssueLists { get; set; }

    public virtual DbSet<IssueListHistory> IssueListHistories { get; set; }

    public virtual DbSet<IssueOnholdCat> IssueOnholdCats { get; set; }

    public virtual DbSet<IssueSla> IssueSlas { get; set; }

    public virtual DbSet<ItassetDetail> ItassetDetails { get; set; }

    public virtual DbSet<ItassetHistory> ItassetHistories { get; set; }

    public virtual DbSet<Itspare> Itspares { get; set; }

    public virtual DbSet<ItspareHistory> ItspareHistories { get; set; }

    public virtual DbSet<NatureofChange> NatureofChanges { get; set; }

    public virtual DbSet<PlantMaster> PlantMasters { get; set; }

    public virtual DbSet<PmMaster> PmMasters { get; set; }

    public virtual DbSet<Prapprover> Prapprovers { get; set; }

    public virtual DbSet<Prattachment> Prattachments { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Prlesson> Prlessons { get; set; }

    public virtual DbSet<ProjectCheckList> ProjectCheckLists { get; set; }

    public virtual DbSet<ProjectCheckListHistory> ProjectCheckListHistories { get; set; }

    public virtual DbSet<ProjectClosure> ProjectClosures { get; set; }

    public virtual DbSet<ProjectDeliverable> ProjectDeliverables { get; set; }

    public virtual DbSet<ProjectGroup> ProjectGroups { get; set; }

    public virtual DbSet<ProjectIssue> ProjectIssues { get; set; }

    public virtual DbSet<ProjectIssueHistory> ProjectIssueHistories { get; set; }

    public virtual DbSet<ProjectMember> ProjectMembers { get; set; }

    public virtual DbSet<ProjectMembersHistory> ProjectMembersHistories { get; set; }

    public virtual DbSet<ProjectMembersNew> ProjectMembersNews { get; set; }

    public virtual DbSet<ProjectMgmt> ProjectMgmts { get; set; }

    public virtual DbSet<ProjectMgmtHistory> ProjectMgmtHistories { get; set; }

    public virtual DbSet<ProjectMilestone> ProjectMilestones { get; set; }

    public virtual DbSet<ProjectMilestoneHistory> ProjectMilestoneHistories { get; set; }

    public virtual DbSet<ProjectNewMembersHistory> ProjectNewMembersHistories { get; set; }

    public virtual DbSet<ProjectTask> ProjectTasks { get; set; }

    public virtual DbSet<ProjectTaskHistory> ProjectTaskHistories { get; set; }

    public virtual DbSet<Prtemplate> Prtemplates { get; set; }

    public virtual DbSet<PrtemplateDtl> PrtemplateDtls { get; set; }

    public virtual DbSet<PrtemplateResponse> PrtemplateResponses { get; set; }

    public virtual DbSet<Reference> References { get; set; }

    public virtual DbSet<ReferenceTyp> ReferenceTyps { get; set; }

    public virtual DbSet<RiskPlan> RiskPlans { get; set; }

    public virtual DbSet<ServiceMaster> ServiceMasters { get; set; }

    public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }

    public virtual DbSet<ServiceRequestHistory> ServiceRequestHistories { get; set; }

    public virtual DbSet<Sla> Slas { get; set; }

    public virtual DbSet<SoftwareLibrary> SoftwareLibraries { get; set; }

    public virtual DbSet<SoftwareLibraryHistory> SoftwareLibraryHistories { get; set; }

    public virtual DbSet<SoftwareVersion> SoftwareVersions { get; set; }

    public virtual DbSet<SoftwareVersionHistory> SoftwareVersionHistories { get; set; }

    public virtual DbSet<Sraccess> Sraccesses { get; set; }

    public virtual DbSet<SraccessHistory> SraccessHistories { get; set; }

    public virtual DbSet<Srantivirus> Srantiviruses { get; set; }

    public virtual DbSet<SrantivirusHistory> SrantivirusHistories { get; set; }

    public virtual DbSet<Srapprover> Srapprovers { get; set; }

    public virtual DbSet<Srattachment> Srattachments { get; set; }

    public virtual DbSet<SrcitrixAccess> SrcitrixAccesses { get; set; }

    public virtual DbSet<SrcitrixAccessHistory> SrcitrixAccessHistories { get; set; }

    public virtual DbSet<Srdomain> Srdomains { get; set; }

    public virtual DbSet<SrdomainHistory> SrdomainHistories { get; set; }

    public virtual DbSet<Sremail> Sremails { get; set; }

    public virtual DbSet<SremailHistory> SremailHistories { get; set; }

    public virtual DbSet<SrexternalDrive> SrexternalDrives { get; set; }

    public virtual DbSet<SrexternalDriveHistory> SrexternalDriveHistories { get; set; }

    public virtual DbSet<Srftpaccess> Srftpaccesses { get; set; }

    public virtual DbSet<SrftpaccessHistory> SrftpaccessHistories { get; set; }

    public virtual DbSet<Srresolution> Srresolutions { get; set; }

    public virtual DbSet<SrresolutionHistory> SrresolutionHistories { get; set; }

    public virtual DbSet<SrrestorationAccess> SrrestorationAccesses { get; set; }

    public virtual DbSet<SrrestorationAccessHistory> SrrestorationAccessHistories { get; set; }

    public virtual DbSet<SrserverAccess> SrserverAccesses { get; set; }

    public virtual DbSet<SrserverAccessHistory> SrserverAccessHistories { get; set; }

    public virtual DbSet<Srsoftware> Srsoftwares { get; set; }

    public virtual DbSet<SrsoftwareHistory> SrsoftwareHistories { get; set; }

    public virtual DbSet<Srurlaccess> Srurlaccesses { get; set; }

    public virtual DbSet<SrurlaccessHistory> SrurlaccessHistories { get; set; }

    public virtual DbSet<Srusbaccess> Srusbaccesses { get; set; }

    public virtual DbSet<SrusbaccessHistory> SrusbaccessHistories { get; set; }

    public virtual DbSet<Srvirtual> Srvirtuals { get; set; }

    public virtual DbSet<SrvirtualHistory> SrvirtualHistories { get; set; }

    public virtual DbSet<Srvpnaccess> Srvpnaccesses { get; set; }

    public virtual DbSet<SrvpnaccessHistory> SrvpnaccessHistories { get; set; }

    public virtual DbSet<Srwifiaccess> Srwifiaccesses { get; set; }

    public virtual DbSet<SrwifiaccessHistory> SrwifiaccessHistories { get; set; }

    public virtual DbSet<SrwindowLogin> SrwindowLogins { get; set; }

    public virtual DbSet<SrwindowLoginHistory> SrwindowLoginHistories { get; set; }

    public virtual DbSet<Support> Supports { get; set; }

    public virtual DbSet<SupportTeam> SupportTeams { get; set; }

    public virtual DbSet<SupportTeamAssgn> SupportTeamAssgns { get; set; }

    public virtual DbSet<SysLandscape> SysLandscapes { get; set; }

    public virtual DbSet<UnitMaster> UnitMasters { get; set; }

    public virtual DbSet<UserVal> UserVals { get; set; }

    public virtual DbSet<ViewProjectGroup> ViewProjectGroups { get; set; }

    public virtual DbSet<VwApproverCr> VwApproverCrs { get; set; }

    public virtual DbSet<VwApproverView> VwApproverViews { get; set; }

    public virtual DbSet<VwAssetDetail> VwAssetDetails { get; set; }

    public virtual DbSet<VwBarchart> VwBarcharts { get; set; }

    public virtual DbSet<VwCategorytype> VwCategorytypes { get; set; }

    public virtual DbSet<VwChangeRequest> VwChangeRequests { get; set; }

    public virtual DbSet<VwChangeRequestHistory> VwChangeRequestHistories { get; set; }

    public virtual DbSet<VwChangeRequestSummary> VwChangeRequestSummaries { get; set; }

    public virtual DbSet<VwChecklist> VwChecklists { get; set; }

    public virtual DbSet<VwChecklistTemplate> VwChecklistTemplates { get; set; }

    public virtual DbSet<VwCrclosure> VwCrclosures { get; set; }

    public virtual DbSet<VwCremail> VwCremails { get; set; }

    public virtual DbSet<VwCrfollowup> VwCrfollowups { get; set; }

    public virtual DbSet<VwCrlesson> VwCrlessons { get; set; }

    public virtual DbSet<VwCrrelease> VwCrreleases { get; set; }

    public virtual DbSet<VwCrtaskEmail> VwCrtaskEmails { get; set; }

    public virtual DbSet<VwCrtemplate> VwCrtemplates { get; set; }

    public virtual DbSet<VwEmailGroup> VwEmailGroups { get; set; }

    public virtual DbSet<VwEmpCategoryMaster> VwEmpCategoryMasters { get; set; }

    public virtual DbSet<VwEmployeeDetail> VwEmployeeDetails { get; set; }

    public virtual DbSet<VwExecPlan> VwExecPlans { get; set; }

    public virtual DbSet<VwGetSrapprover> VwGetSrapprovers { get; set; }

    public virtual DbSet<VwIssueList> VwIssueLists { get; set; }

    public virtual DbSet<VwIssueListHistory> VwIssueListHistories { get; set; }

    public virtual DbSet<VwItassetsDetail> VwItassetsDetails { get; set; }

    public virtual DbSet<VwItassetsHistory> VwItassetsHistories { get; set; }

    public virtual DbSet<VwItspareDetail> VwItspareDetails { get; set; }

    public virtual DbSet<VwItspareHistory> VwItspareHistories { get; set; }

    public virtual DbSet<VwNatureofChange> VwNatureofChanges { get; set; }

    public virtual DbSet<VwPrattachment> VwPrattachments { get; set; }

    public virtual DbSet<VwPrlesson> VwPrlessons { get; set; }

    public virtual DbSet<VwProjectCheckList> VwProjectCheckLists { get; set; }

    public virtual DbSet<VwProjectClosure> VwProjectClosures { get; set; }

    public virtual DbSet<VwProjectIssue> VwProjectIssues { get; set; }

    public virtual DbSet<VwProjectMember> VwProjectMembers { get; set; }

    public virtual DbSet<VwProjectMgmt> VwProjectMgmts { get; set; }

    public virtual DbSet<VwProjectMgmtHistory> VwProjectMgmtHistories { get; set; }

    public virtual DbSet<VwProjectMilestone> VwProjectMilestones { get; set; }

    public virtual DbSet<VwProjectTask> VwProjectTasks { get; set; }

    public virtual DbSet<VwPrtemplate> VwPrtemplates { get; set; }

    public virtual DbSet<VwPrtemplateDetail> VwPrtemplateDetails { get; set; }

    public virtual DbSet<VwReference> VwReferences { get; set; }

    public virtual DbSet<VwReferenceType> VwReferenceTypes { get; set; }

    public virtual DbSet<VwRptapproverView> VwRptapproverViews { get; set; }

    public virtual DbSet<VwRptcrexecPlan> VwRptcrexecPlans { get; set; }

    public virtual DbSet<VwRptcrmilestone> VwRptcrmilestones { get; set; }

    public virtual DbSet<VwServiceMaster> VwServiceMasters { get; set; }

    public virtual DbSet<VwServiceRequest> VwServiceRequests { get; set; }

    public virtual DbSet<VwSoftwareLibrary> VwSoftwareLibraries { get; set; }

    public virtual DbSet<VwSoftwareVersion> VwSoftwareVersions { get; set; }

    public virtual DbSet<VwSrapprovedDat> VwSrapprovedDats { get; set; }

    public virtual DbSet<VwSrattachment> VwSrattachments { get; set; }

    public virtual DbSet<VwSrcommonHistory> VwSrcommonHistories { get; set; }

    public virtual DbSet<VwSrdomain> VwSrdomains { get; set; }

    public virtual DbSet<VwSrhistory> VwSrhistories { get; set; }

    public virtual DbSet<VwSrresolution> VwSrresolutions { get; set; }

    public virtual DbSet<VwSrsosftware> VwSrsosftwares { get; set; }

    public virtual DbSet<VwSupportEngineer> VwSupportEngineers { get; set; }

    public virtual DbSet<VwSupportTeamAll> VwSupportTeamAlls { get; set; }

    public virtual DbSet<VwSupportTeamDtl> VwSupportTeamDtls { get; set; }

    public virtual DbSet<VwSystemlandscape> VwSystemlandscapes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TECHVAHARA08\\SQLEXPRESS;Database=CandorHQ;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Approver>(entity =>
        {
            entity.HasKey(e => e.ItapproverId).HasName("PK_IT.Approver");

            entity.ToTable("Approver", "IT");

            entity.Property(e => e.ItapproverId).HasColumnName("ITApproverID");
            entity.Property(e => e.Approverstage).HasMaxLength(50);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CategoryTypID");
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");

            entity.HasOne(d => d.Approver1Navigation).WithMany(p => p.ApproverApprover1Navigations)
                .HasForeignKey(d => d.Approver1)
                .HasConstraintName("FK_Approver_SupportTeam");

            entity.HasOne(d => d.Approver2Navigation).WithMany(p => p.ApproverApprover2Navigations)
                .HasForeignKey(d => d.Approver2)
                .HasConstraintName("FK_Approver_Approver2");

            entity.HasOne(d => d.Approver3Navigation).WithMany(p => p.ApproverApprover3Navigations)
                .HasForeignKey(d => d.Approver3)
                .HasConstraintName("FK_Approver_Approver3");
        });

        modelBuilder.Entity<ApproverHistory>(entity =>
        {
            entity.HasKey(e => e.ItapproverHistoryId).HasName("PK_IT.ApproverHistory");

            entity.ToTable("ApproverHistory", "IT");

            entity.Property(e => e.ItapproverHistoryId).HasColumnName("ITApproverHistoryID");
            entity.Property(e => e.Approver1)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Approver2)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Approver3)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Approverstage).HasMaxLength(50);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrhistoryDt)
                .HasColumnType("datetime")
                .HasColumnName("CRHistoryDt");
            entity.Property(e => e.ItapproverId).HasColumnName("ITApproverID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<AssetDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AssetDetails", "IT");

            entity.Property(e => e.AssetNo).HasColumnName("Asset_No");
            entity.Property(e => e.AssetType)
                .HasMaxLength(50)
                .HasColumnName("Asset_Type");
            entity.Property(e => e.AssetsDetailsId).HasColumnName("AssetsDetailsID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.HostName)
                .HasMaxLength(500)
                .HasColumnName("Host_Name");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .HasColumnName("IP_Address");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<AttachFile>(entity =>
        {
            entity.HasKey(e => e.AttachId);

            entity.ToTable("AttachFile", "IT");

            entity.Property(e => e.AttachId).HasColumnName("AttachID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Stage).HasMaxLength(200);
        });

        modelBuilder.Entity<BackupSupport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BackupSupport", "IT");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.IsHodreq).HasColumnName("IsHODReq");
            entity.Property(e => e.IsRpmreq).HasColumnName("IsRPMReq");
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.SupportId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SupportID");
            entity.Property(e => e.SupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.ItcategoryId).HasName("PK_IT.Category");

            entity.ToTable("Category", "IT");

            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<CategoryTyp>(entity =>
        {
            entity.HasKey(e => e.CategoryTypeId).HasName("PK_IT.CategoryTyp");

            entity.ToTable("CategoryTyp", "IT");

            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryType).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ChangeRequest>(entity =>
        {
            entity.HasKey(e => e.Itcrid);

            entity.ToTable("ChangeRequest", "IT");

            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.AlternateConsidetation)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.BackoutPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Benefits)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.BusinessImpact)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ChangeControlNo).HasMaxLength(50);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.ClosedDt).HasColumnType("datetime");
            entity.Property(e => e.ClosedStatus).HasMaxLength(150);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrinitiatedFor).HasColumnName("CRInitiatedFor");
            entity.Property(e => e.Crowner).HasColumnName("CROwner");
            entity.Property(e => e.CrremailNotification).HasColumnName("CRREmailNotification");
            entity.Property(e => e.CrrequestedBy).HasColumnName("CRRequestedBy");
            entity.Property(e => e.CrrequestedDt)
                .HasColumnType("datetime")
                .HasColumnName("CRRequestedDt");
            entity.Property(e => e.DownTimeFromDate).HasColumnType("datetime");
            entity.Property(e => e.DownTimeToDate).HasColumnType("datetime");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EstimatedEffortUnit).HasMaxLength(50);
            entity.Property(e => e.Gxpclassification).HasColumnName("GXPClassification");
            entity.Property(e => e.GxpplantId).HasColumnName("GXPPlantID");
            entity.Property(e => e.ImactedFunc).HasMaxLength(50);
            entity.Property(e => e.ImpactNotDoing)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ImpactedDept).HasMaxLength(50);
            entity.Property(e => e.ImpactedLocation).HasMaxLength(50);
            entity.Property(e => e.IsApproved)
                .HasDefaultValue(false)
                .HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented)
                .HasDefaultValue(false)
                .HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased)
                .HasDefaultValue(false)
                .HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted)
                .HasDefaultValue(false)
                .HasColumnName("isSubmitted");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ReasonForChange)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");
            entity.Property(e => e.RollbackPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SysLandscapeId)
                .HasMaxLength(500)
                .HasColumnName("SysLandscapeID");
            entity.Property(e => e.TriggeredBy)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.ChangeRequests)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChangeRequest_Category");

            entity.HasOne(d => d.Classification).WithMany(p => p.ChangeRequests)
                .HasForeignKey(d => d.ClassificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChangeRequest_Classification");
        });

        modelBuilder.Entity<ChangeRequestHistory>(entity =>
        {
            entity.HasKey(e => e.CrhistoryId);

            entity.ToTable("ChangeRequestHistory", "IT");

            entity.Property(e => e.CrhistoryId).HasColumnName("CRHistoryID");
            entity.Property(e => e.AlternateConsidetation)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.BackoutPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Benefits)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.BusinessImpact)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ChangeControlNo).HasMaxLength(50);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassifcationId).HasColumnName("ClassifcationID");
            entity.Property(e => e.ClosedDt).HasColumnType("datetime");
            entity.Property(e => e.ClosedStatus).HasMaxLength(150);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrhistoryDt)
                .HasColumnType("datetime")
                .HasColumnName("CRHistoryDt");
            entity.Property(e => e.CrinitiatedFor).HasColumnName("CRInitiatedFor");
            entity.Property(e => e.Crowner).HasColumnName("CROwner");
            entity.Property(e => e.CrrequestedBy).HasColumnName("CRRequestedBy");
            entity.Property(e => e.CrrequestedDt)
                .HasColumnType("datetime")
                .HasColumnName("CRRequestedDt");
            entity.Property(e => e.DownTimeFromDate).HasColumnType("datetime");
            entity.Property(e => e.DownTimeToDate).HasColumnType("datetime");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EstimatedEffortUnit).HasMaxLength(50);
            entity.Property(e => e.EventName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gxpclassification).HasColumnName("GXPClassification");
            entity.Property(e => e.GxpplantId).HasColumnName("GXPPlantID");
            entity.Property(e => e.ImactedFunc).HasMaxLength(50);
            entity.Property(e => e.ImpactNotDoing)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ImpactedDept).HasMaxLength(50);
            entity.Property(e => e.ImpactedLocation).HasMaxLength(50);
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented).HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted).HasColumnName("isSubmitted");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ReasonForChange)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");
            entity.Property(e => e.RollbackPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SysLandscapeId)
                .HasMaxLength(500)
                .HasColumnName("SysLandscapeID");
            entity.Property(e => e.TriggeredBy)
                .HasMaxLength(2000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Checklist>(entity =>
        {
            entity.HasKey(e => e.ItchecklistId).HasName("PK_ITChecklist");

            entity.ToTable("Checklist", "IT");

            entity.Property(e => e.ItchecklistId).HasColumnName("ITChecklistID");
            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ChecklistDesc)
                .HasMaxLength(1500)
                .IsUnicode(false);
            entity.Property(e => e.ChecklistTitle)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<ChecklistTemplate>(entity =>
        {
            entity.HasKey(e => e.ChecklisttemplateId).HasName("PK__Checklis__19C10DC17FE5CB14");

            entity.ToTable("ChecklistTemplate", "IT");

            entity.Property(e => e.ChecklistIds)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("ChecklistIDs");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Classification>(entity =>
        {
            entity.HasKey(e => e.ItclassificationId).HasName("PK_ITClassification");

            entity.ToTable("Classification", "IT");

            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Crapprover>(entity =>
        {
            entity.HasKey(e => e.ItcrapproverId).HasName("PK_ITCRApproverID");

            entity.ToTable("CRApprover", "IT");

            entity.Property(e => e.ItcrapproverId).HasColumnName("ITCRApproverID");
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.Attachment)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Crid).HasColumnName("CRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Remarks)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Stage)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<CrapproverHistory>(entity =>
        {
            entity.HasKey(e => e.ItcrapproverHistoryId).HasName("PK_ITCRApproverHistoryID");

            entity.ToTable("CRApproverHistory", "IT");

            entity.Property(e => e.ItcrapproverHistoryId).HasColumnName("ITCRApproverHistoryID");
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.Attachment)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Comments).HasMaxLength(2000);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrhistoryDt)
                .HasColumnType("datetime")
                .HasColumnName("CRHistoryDt");
            entity.Property(e => e.Crid).HasColumnName("CRID");
            entity.Property(e => e.ItcrapproverId).HasColumnName("ITCRApproverID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Remarks)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Stage)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<CrexecutionPlan>(entity =>
        {
            entity.HasKey(e => e.ItcrexecId).HasName("PK_IT.CRExecutionPlan");

            entity.ToTable("CRExecutionPlan", "IT");

            entity.Property(e => e.ItcrexecId).HasColumnName("ITCRExecID");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.Attachments).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.DependTaskId).HasColumnName("DependTaskID");
            entity.Property(e => e.EndDt)
                .HasColumnType("datetime")
                .HasColumnName("EndDT");
            entity.Property(e => e.ExecutionStepDesc).HasMaxLength(2000);
            entity.Property(e => e.ExecutionStepName).HasMaxLength(500);
            entity.Property(e => e.ForwardStatus).HasMaxLength(50);
            entity.Property(e => e.ForwardedDt).HasColumnType("datetime");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PickedDt).HasColumnType("datetime");
            entity.Property(e => e.PickedStatus).HasMaxLength(50);
            entity.Property(e => e.ReasonForwarded).HasMaxLength(500);
            entity.Property(e => e.Remarks).HasMaxLength(2000);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Itcr).WithMany(p => p.CrexecutionPlans)
                .HasForeignKey(d => d.Itcrid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CRExecutionPlan_ChangeRequest");
        });

        modelBuilder.Entity<CrexecutionPlanHistory>(entity =>
        {
            entity.HasKey(e => e.ItcrexecHistoryId).HasName("PK_IT.CRExecutionPlanHistory");

            entity.ToTable("CRExecutionPlanHistory", "IT");

            entity.Property(e => e.ItcrexecHistoryId).HasColumnName("ITCRExecHistoryID");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.Attachments).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrhistoryDt)
                .HasColumnType("datetime")
                .HasColumnName("CRHistoryDt");
            entity.Property(e => e.DependTaskId).HasColumnName("DependTaskID");
            entity.Property(e => e.EndDt)
                .HasColumnType("datetime")
                .HasColumnName("EndDT");
            entity.Property(e => e.ExecutionStepDesc).HasMaxLength(2000);
            entity.Property(e => e.ExecutionStepName).HasMaxLength(500);
            entity.Property(e => e.ForwardStatus).HasMaxLength(50);
            entity.Property(e => e.ForwardedDt).HasColumnType("datetime");
            entity.Property(e => e.ItcrexecId).HasColumnName("ITCRExecID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PickedDt).HasColumnType("datetime");
            entity.Property(e => e.PickedStatus).HasMaxLength(50);
            entity.Property(e => e.ReasonForwarded).HasMaxLength(500);
            entity.Property(e => e.Remarks).HasMaxLength(2000);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Crfollowup>(entity =>
        {
            entity.HasKey(e => e.CrfollowupId).HasName("PK_IT.CRFollowup");

            entity.ToTable("CRFollowup", "IT");

            entity.Property(e => e.CrfollowupId).HasColumnName("CRFollowupID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.FollowupDt).HasColumnType("datetime");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");

            entity.HasOne(d => d.Itcr).WithMany(p => p.Crfollowups)
                .HasForeignKey(d => d.Itcrid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CRFollowup_ChangeRequest");
        });

        modelBuilder.Entity<Crlesson>(entity =>
        {
            entity.HasKey(e => e.CrlessonId).HasName("PK_IT.CRLesson");

            entity.ToTable("CRLesson", "IT");

            entity.Property(e => e.CrlessonId).HasColumnName("CRLessonID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.LessonDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");

            entity.HasOne(d => d.Itcr).WithMany(p => p.Crlessons)
                .HasForeignKey(d => d.Itcrid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CRLessonID_ChangeRequest");
        });

        modelBuilder.Entity<Crmilestone>(entity =>
        {
            entity.ToTable("CRMilestone", "IT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClosedDt).HasColumnType("datetime");
            entity.Property(e => e.ColApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.ColApproverLevel1Dt).HasColumnType("datetime");
            entity.Property(e => e.ColApproverLevel2Dt).HasColumnType("datetime");
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CurrStatus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ImplementedDt).HasColumnType("datetime");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.RelApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.RelApproverLevel1Dt).HasColumnType("datetime");
            entity.Property(e => e.RelApproverLevel2Dt).HasColumnType("datetime");
            entity.Property(e => e.ReleasedDt).HasColumnType("datetime");
            entity.Property(e => e.Rfcapproved).HasColumnName("RFCApproved");
            entity.Property(e => e.RfcapprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("RFCApprovedDt");
            entity.Property(e => e.RfcapproverLevel1).HasColumnName("RFCApproverLevel1");
            entity.Property(e => e.RfcapproverLevel1Dt)
                .HasColumnType("datetime")
                .HasColumnName("RFCApproverLevel1Dt");
            entity.Property(e => e.RfcapproverLevel2).HasColumnName("RFCApproverLevel2");
            entity.Property(e => e.RfcapproverLevel2Dt)
                .HasColumnType("datetime")
                .HasColumnName("RFCApproverLevel2Dt");
            entity.Property(e => e.RfccreatedDt)
                .HasColumnType("datetime")
                .HasColumnName("RFCCreatedDt");
            entity.Property(e => e.RfcsubmittedDt)
                .HasColumnType("datetime")
                .HasColumnName("RFCSubmittedDt");

            entity.HasOne(d => d.Itcr).WithMany(p => p.Crmilestones)
                .HasForeignKey(d => d.Itcrid)
                .HasConstraintName("FK_CRMilestone_ChangeRequest");
        });

        modelBuilder.Entity<Crrelease>(entity =>
        {
            entity.HasKey(e => e.CrreleaseId).HasName("PK_IT.CRRelease");

            entity.ToTable("CRRelease", "IT");

            entity.Property(e => e.CrreleaseId).HasColumnName("CRReleaseID");
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.Attachments).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ReleaseDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Itcr).WithMany(p => p.Crreleases)
                .HasForeignKey(d => d.Itcrid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CRReleaseID_ChangeRequest");
        });

        modelBuilder.Entity<Crtemplate>(entity =>
        {
            entity.HasKey(e => e.CrtemplateId).HasName("PK_IT.CRTemplate");

            entity.ToTable("CRTemplate", "IT");

            entity.Property(e => e.CrtemplateId).HasColumnName("CRTemplateID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CrtemplateDtl>(entity =>
        {
            entity.HasKey(e => e.CrtemplateDtlsId).HasName("PK_IT.CRTemplateDtls");

            entity.ToTable("CRTemplateDtls", "IT");

            entity.Property(e => e.CrtemplateDtlsId).HasColumnName("CRTemplateDtlsID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrtemplateId).HasColumnName("CRTemplateID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SysLandscapeId).HasColumnName("SysLandscapeID");
            entity.Property(e => e.TaskDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.TaskName)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Crtemplate).WithMany(p => p.CrtemplateDtls)
                .HasForeignKey(d => d.CrtemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CRTemplateDtls_CRTemplate");
        });

        modelBuilder.Entity<DepartmentMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Department_Master", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<DesignationMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Designation_Master_1");

            entity.ToTable("Designation_Master", "IT");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<EmailGroup>(entity =>
        {
            entity.HasKey(e => e.EmailGroupId).HasName("PK__EmailGro__417C23E8579ED698");

            entity.ToTable("EmailGroup", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EmailGroupName).HasMaxLength(100);
            entity.Property(e => e.MidifiedDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmpCategoryMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_emp_category_master_1");

            entity.ToTable("empCategoryMaster", "IT");

            entity.Property(e => e.Aoemail)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AOEMAIL");
            entity.Property(e => e.Bemnth)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BEMNTH");
            entity.Property(e => e.Catltxt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CATLTXT");
            entity.Property(e => e.Catstxt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CATSTXT");
            entity.Property(e => e.CostCenter)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Glno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GLNo");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Ofemail)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OFEMAIL");
            entity.Property(e => e.Prcday).HasColumnName("PRCDAY");
            entity.Property(e => e.Staffcat).HasColumnName("STAFFCAT");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee", "IT");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.ApprenticeCompletionDate).HasColumnType("datetime");
            entity.Property(e => e.Building).HasMaxLength(50);
            entity.Property(e => e.BulkUpdateDataPushToSap).HasColumnName("BulkUpdateDataPushToSAP");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CurrentCtc)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("CurrentCTC");
            entity.Property(e => e.CurrentYearKra).HasColumnName("CurrentYearKRA");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.DateOfConfirmation).HasColumnType("datetime");
            entity.Property(e => e.DateOfJoining).HasColumnType("datetime");
            entity.Property(e => e.DateOfLeaving).HasColumnType("datetime");
            entity.Property(e => e.DateOfResignation).HasColumnType("datetime");
            entity.Property(e => e.EmpNoGeneratedDate).HasColumnType("datetime");
            entity.Property(e => e.EmployeeNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EmploymentType).HasMaxLength(100);
            entity.Property(e => e.Extension).HasMaxLength(10);
            entity.Property(e => e.FirstName).HasMaxLength(500);
            entity.Property(e => e.Floor).HasMaxLength(50);
            entity.Property(e => e.Initial).HasMaxLength(500);
            entity.Property(e => e.IsSharedEmailId).HasMaxLength(5);
            entity.Property(e => e.LastName).HasMaxLength(500);
            entity.Property(e => e.LeavingType).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(500);
            entity.Property(e => e.MobileNo).HasMaxLength(20);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.OfficialEmailId).HasMaxLength(50);
            entity.Property(e => e.PersonalEmailId).HasMaxLength(50);
            entity.Property(e => e.ProfileUpdateDataPushToSap).HasColumnName("ProfileUpdateDataPushToSAP");
            entity.Property(e => e.RoomOrBlock).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TelephoneNo).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(500);
        });

        modelBuilder.Entity<GetSlalist>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetSLAList", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CategoryType).HasMaxLength(50);
            entity.Property(e => e.CategoryTypeName).HasMaxLength(50);
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Itslaid).HasColumnName("ITSLAID");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.WaitTimeUnit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WaitTimeUnitEscal1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WaitTimeUnitEscal2)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Isattachment>(entity =>
        {
            entity.HasKey(e => e.AttachId);

            entity.ToTable("ISAttachment", "IT");

            entity.Property(e => e.AttachId).HasColumnName("AttachID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Isid).HasColumnName("ISID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Stage).HasMaxLength(200);
        });

        modelBuilder.Entity<IssueCommentsBox>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__issueCom__3214EC07488DD611");

            entity.ToTable("issueCommentsBox", "IT");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IssueId).HasColumnName("issueId");
            entity.Property(e => e.TextChat).HasColumnName("textChat");
        });

        modelBuilder.Entity<IssueList>(entity =>
        {
            entity.HasKey(e => e.IssueId).HasName("PK_IT_IssueList");

            entity.ToTable("IssueList", "IT");

            entity.Property(e => e.IssueId).HasColumnName("IssueID");
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.GuestCompany).HasMaxLength(500);
            entity.Property(e => e.GuestContactNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GuestEmail).HasMaxLength(50);
            entity.Property(e => e.GuestName).HasMaxLength(50);
            entity.Property(e => e.GuestReportingManagerEmployeeId).HasMaxLength(50);
            entity.Property(e => e.IssueCode).HasMaxLength(50);
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.IssueForGuest)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IssueSelectedfor).HasMaxLength(50);
            entity.Property(e => e.IssueShotDesc).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ProposedResolutionOn).HasColumnType("datetime");
            entity.Property(e => e.ReasonId).HasColumnName("ReasonID");
            entity.Property(e => e.Remarks)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ResolutionDt).HasColumnType("datetime");
            entity.Property(e => e.ResolutionRemarks).HasMaxLength(3000);
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<IssueListHistory>(entity =>
        {
            entity.HasKey(e => e.IssueHistoryId).HasName("PK_IT_IssueListHistory");

            entity.ToTable("IssueListHistory", "IT");

            entity.Property(e => e.IssueHistoryId).HasColumnName("IssueHistoryID");
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.GuestCompany).HasMaxLength(500);
            entity.Property(e => e.IssueCode).HasMaxLength(50);
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.IssueDesc).HasMaxLength(2000);
            entity.Property(e => e.IssueForGuest)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IssueHistoryDt).HasColumnType("datetime");
            entity.Property(e => e.IssueId).HasColumnName("IssueID");
            entity.Property(e => e.IssueShotDesc).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ProposedResolutionOn).HasColumnType("datetime");
            entity.Property(e => e.ReasonId).HasColumnName("ReasonID");
            entity.Property(e => e.Remarks)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ResolutionDt).HasColumnType("datetime");
            entity.Property(e => e.ResolutionRemarks).HasMaxLength(3000);
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<IssueOnholdCat>(entity =>
        {
            entity.HasKey(e => e.IssueOnholdCatId).HasName("PK_IT.[IssueOnholdCat");

            entity.ToTable("IssueOnholdCat", "IT");

            entity.Property(e => e.IssueOnholdCatId).HasColumnName("IssueOnholdCatID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.OnholdReason).HasMaxLength(1500);
            entity.Property(e => e.SupportId).HasColumnName("supportId");
        });

        modelBuilder.Entity<IssueSla>(entity =>
        {
            entity.HasKey(e => e.IssueSlaid).HasName("PK_IT.[IssueSLA");

            entity.ToTable("IssueSLA", "IT");

            entity.Property(e => e.IssueSlaid).HasColumnName("IssueSLAID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EscalationDt).HasColumnType("datetime");
            entity.Property(e => e.EscalationId).HasColumnName("EscalationID");
            entity.Property(e => e.IssueId).HasColumnName("IssueID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Remarks).HasMaxLength(2000);
        });

        modelBuilder.Entity<ItassetDetail>(entity =>
        {
            entity.HasKey(e => e.ItassetId).HasName("PK_ReqAssets");

            entity.ToTable("ITAssetDetails", "IT");

            entity.Property(e => e.ItassetId).HasColumnName("ITAssetID");
            entity.Property(e => e.ApproximateInr).HasColumnName("ApproximateINR");
            entity.Property(e => e.AssetCode).HasMaxLength(100);
            entity.Property(e => e.AssetModel).HasMaxLength(500);
            entity.Property(e => e.AssetSerialNo).HasMaxLength(300);
            entity.Property(e => e.AssetsWarrantyEndDt)
                .HasColumnType("datetime")
                .HasColumnName("AssetsWarranty_EndDt");
            entity.Property(e => e.Assettype).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.ExistingAsset).HasMaxLength(200);
            entity.Property(e => e.GuestContactNo).HasColumnName("Guest_ContactNo");
            entity.Property(e => e.GuestEmail)
                .HasMaxLength(500)
                .HasColumnName("Guest_Email");
            entity.Property(e => e.GuestId).HasColumnName("Guest_Id");
            entity.Property(e => e.GuestName)
                .HasMaxLength(500)
                .HasColumnName("Guest_Name");
            entity.Property(e => e.GuestRmanagerId).HasColumnName("Guest_RManagerId");
            entity.Property(e => e.GxpReq).HasMaxLength(200);
            entity.Property(e => e.HodApproval)
                .HasMaxLength(200)
                .HasColumnName("HOD_Approval");
            entity.Property(e => e.HodApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("HOD_ApprovedDt");
            entity.Property(e => e.HodApproverId).HasColumnName("HOD_ApproverID");
            entity.Property(e => e.HodApproverRemarks).HasColumnName("HOD_ApproverRemarks");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.OnHoldReason).HasMaxLength(200);
            entity.Property(e => e.ProposedResolDt).HasColumnType("datetime");
            entity.Property(e => e.RequestedBy).HasColumnName("RequestedBY");
            entity.Property(e => e.Requesttype).HasMaxLength(200);
            entity.Property(e => e.ResolDt).HasColumnType("datetime");
            entity.Property(e => e.RpmApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("RPM_ApprovedDt");
            entity.Property(e => e.RpmApproverId).HasColumnName("RPM_ApproverID");
            entity.Property(e => e.RpmApproverRemarks).HasColumnName("RPM_ApproverRemarks");
            entity.Property(e => e.SelectedFor).HasMaxLength(200);
            entity.Property(e => e.SpecsRequirements)
                .HasMaxLength(200)
                .HasColumnName("Specs_Requirements");
            entity.Property(e => e.Stage).HasMaxLength(150);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SuggModel).HasMaxLength(200);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.UserRemarks).HasMaxLength(200);
        });

        modelBuilder.Entity<ItassetHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ITAssetHistory", "IT");

            entity.Property(e => e.ApproximateInr).HasColumnName("ApproximateINR");
            entity.Property(e => e.AssetCode).HasMaxLength(100);
            entity.Property(e => e.AssetModel).HasMaxLength(500);
            entity.Property(e => e.AssetSerialNo).HasMaxLength(300);
            entity.Property(e => e.AssetsWarrantyEndDt)
                .HasColumnType("datetime")
                .HasColumnName("AssetsWarranty_EndDt");
            entity.Property(e => e.Assettype).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.ExistingAsset).HasMaxLength(200);
            entity.Property(e => e.GuestContactNo).HasColumnName("Guest_ContactNo");
            entity.Property(e => e.GuestEmail)
                .HasMaxLength(500)
                .HasColumnName("Guest_Email");
            entity.Property(e => e.GuestId).HasColumnName("Guest_Id");
            entity.Property(e => e.GuestName)
                .HasMaxLength(500)
                .HasColumnName("Guest_Name");
            entity.Property(e => e.GuestRmanagerId).HasColumnName("Guest_RManagerId");
            entity.Property(e => e.GxpReq).HasMaxLength(200);
            entity.Property(e => e.HodApproval)
                .HasMaxLength(200)
                .HasColumnName("HOD_Approval");
            entity.Property(e => e.HodApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("HOD_ApprovedDt");
            entity.Property(e => e.HodApproverId).HasColumnName("HOD_ApproverID");
            entity.Property(e => e.HodApproverRemarks).HasColumnName("HOD_ApproverRemarks");
            entity.Property(e => e.ItahistoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ITAHistoryID");
            entity.Property(e => e.ItassetId).HasColumnName("ITAssetID");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProposedResolDt).HasColumnType("datetime");
            entity.Property(e => e.RequestedBy).HasColumnName("RequestedBY");
            entity.Property(e => e.Requesttype).HasMaxLength(200);
            entity.Property(e => e.ResolDt).HasColumnType("datetime");
            entity.Property(e => e.RpmApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("RPM_ApprovedDt");
            entity.Property(e => e.RpmApproverId).HasColumnName("RPM_ApproverID");
            entity.Property(e => e.RpmApproverRemarks).HasColumnName("RPM_ApproverRemarks");
            entity.Property(e => e.SelectedFor).HasMaxLength(200);
            entity.Property(e => e.SpecsRequirements)
                .HasMaxLength(200)
                .HasColumnName("Specs_Requirements");
            entity.Property(e => e.Stage).HasMaxLength(150);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SuggModel).HasMaxLength(200);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.UserRemarks).HasMaxLength(200);
        });

        modelBuilder.Entity<Itspare>(entity =>
        {
            entity.ToTable("ITSpare", "IT");

            entity.Property(e => e.ItspareId).HasColumnName("ITSpareID");
            entity.Property(e => e.AssetType)
                .HasMaxLength(300)
                .HasColumnName("Asset_Type");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.GuestContactNo).HasColumnName("Guest_ContactNo");
            entity.Property(e => e.GuestEmail)
                .HasMaxLength(500)
                .HasColumnName("Guest_Email");
            entity.Property(e => e.GuestId).HasColumnName("Guest_Id");
            entity.Property(e => e.GuestName)
                .HasMaxLength(500)
                .HasColumnName("Guest_Name");
            entity.Property(e => e.GuestRmanagerId).HasColumnName("Guest_RManagerId");
            entity.Property(e => e.GxpReq).HasMaxLength(200);
            entity.Property(e => e.HodApproval)
                .HasMaxLength(500)
                .HasColumnName("HOD_Approval");
            entity.Property(e => e.HodApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("HOD_ApprovedDt");
            entity.Property(e => e.HodApproverId).HasColumnName("HOD_ApproverID");
            entity.Property(e => e.HodApproverRemarks).HasColumnName("HOD_ApproverRemarks");
            entity.Property(e => e.ItspareCode)
                .HasMaxLength(200)
                .HasColumnName("ITSpareCode");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProposedResolDt).HasColumnType("datetime");
            entity.Property(e => e.RequestedBy).HasColumnName("RequestedBY");
            entity.Property(e => e.Requesttype).HasMaxLength(500);
            entity.Property(e => e.ResolDt).HasColumnType("datetime");
            entity.Property(e => e.RpmApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("RPM_ApprovedDt");
            entity.Property(e => e.RpmApproverId).HasColumnName("RPM_ApproverID");
            entity.Property(e => e.RpmApproverRemarks).HasColumnName("RPM_ApproverRemarks");
            entity.Property(e => e.SelectedFor).HasMaxLength(500);
            entity.Property(e => e.SpareModel)
                .HasMaxLength(500)
                .HasColumnName("Spare_Model");
            entity.Property(e => e.SpareSerialNo)
                .HasMaxLength(500)
                .HasColumnName("Spare_SerialNo");
            entity.Property(e => e.SpareType)
                .HasMaxLength(500)
                .HasColumnName("Spare_Type");
            entity.Property(e => e.SpecsRequirements)
                .HasMaxLength(500)
                .HasColumnName("Specs_Requirements");
            entity.Property(e => e.Status).HasMaxLength(200);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.UserRemarks).HasMaxLength(200);
        });

        modelBuilder.Entity<ItspareHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ITSpareHistory", "IT");

            entity.Property(e => e.AssetType)
                .HasMaxLength(300)
                .HasColumnName("Asset_Type");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.GuestContactNo).HasColumnName("Guest_ContactNo");
            entity.Property(e => e.GuestEmail)
                .HasMaxLength(500)
                .HasColumnName("Guest_Email");
            entity.Property(e => e.GuestId).HasColumnName("Guest_Id");
            entity.Property(e => e.GuestName)
                .HasMaxLength(500)
                .HasColumnName("Guest_Name");
            entity.Property(e => e.GuestRmanagerId).HasColumnName("Guest_RManagerId");
            entity.Property(e => e.GxpReq).HasMaxLength(200);
            entity.Property(e => e.HodApproval)
                .HasMaxLength(500)
                .HasColumnName("HOD_Approval");
            entity.Property(e => e.HodApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("HOD_ApprovedDt");
            entity.Property(e => e.HodApproverId).HasColumnName("HOD_ApproverID");
            entity.Property(e => e.HodApproverRemarks).HasColumnName("HOD_ApproverRemarks");
            entity.Property(e => e.ItspareCode)
                .HasMaxLength(200)
                .HasColumnName("ITSpareCode");
            entity.Property(e => e.ItspareHid)
                .ValueGeneratedOnAdd()
                .HasColumnName("ITSpareHID");
            entity.Property(e => e.ItspareId).HasColumnName("ITSpareID");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProposedResolDt).HasColumnType("datetime");
            entity.Property(e => e.RequestedBy).HasColumnName("RequestedBY");
            entity.Property(e => e.Requesttype).HasMaxLength(500);
            entity.Property(e => e.ResolDt).HasColumnType("datetime");
            entity.Property(e => e.RpmApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("RPM_ApprovedDt");
            entity.Property(e => e.RpmApproverId).HasColumnName("RPM_ApproverID");
            entity.Property(e => e.RpmApproverRemarks).HasColumnName("RPM_ApproverRemarks");
            entity.Property(e => e.SelectedFor).HasMaxLength(500);
            entity.Property(e => e.SpareModel)
                .HasMaxLength(500)
                .HasColumnName("Spare_Model");
            entity.Property(e => e.SpareSerialNo)
                .HasMaxLength(500)
                .HasColumnName("Spare_SerialNo");
            entity.Property(e => e.SpareType)
                .HasMaxLength(500)
                .HasColumnName("Spare_Type");
            entity.Property(e => e.SpecsRequirements)
                .HasMaxLength(500)
                .HasColumnName("Specs_Requirements");
            entity.Property(e => e.Status).HasMaxLength(200);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.UserRemarks).HasMaxLength(200);
        });

        modelBuilder.Entity<NatureofChange>(entity =>
        {
            entity.HasKey(e => e.NatureofChangeId).HasName("PK_IT.NatureofChangeType");

            entity.ToTable("NatureofChange", "IT");

            entity.Property(e => e.NatureofChangeId).HasColumnName("NatureofChangeID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NatureofChange1)
                .HasMaxLength(50)
                .HasColumnName("NatureofChange");
        });

        modelBuilder.Entity<PlantMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Plant_Master", "IT");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LocGroup)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.LocHead).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OutwardMail).HasMaxLength(50);
            entity.Property(e => e.PlantCode).HasMaxLength(100);
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.PrintName).HasMaxLength(500);
            entity.Property(e => e.ToMail).HasMaxLength(500);
            entity.Property(e => e.VisitorMail).HasMaxLength(50);
        });

        modelBuilder.Entity<PmMaster>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK_IT.pmMaster");

            entity.ToTable("pmMaster", "IT");

            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Deliverables)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.IsStrict).HasColumnName("isStrict");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectAccess)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ProjectDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ProjectGroup)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ProjectName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Prapprover>(entity =>
        {
            entity.HasKey(e => e.PrapproverId).HasName("PK_PRApproverID");

            entity.ToTable("PRApprover", "IT");

            entity.Property(e => e.PrapproverId).HasColumnName("PRApproverID");
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Prid).HasColumnName("PRID");
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Stage)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Prattachment>(entity =>
        {
            entity.HasKey(e => e.AttachId);

            entity.ToTable("PRAttachment", "IT");

            entity.Property(e => e.AttachId).HasColumnName("AttachID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PrcheckListId).HasColumnName("PRcheckListId");
            entity.Property(e => e.Prid).HasColumnName("PRID");
            entity.Property(e => e.PrissueId).HasColumnName("PRIssueID");
            entity.Property(e => e.PrmlId).HasColumnName("PRMlID");
            entity.Property(e => e.PrtaskId).HasColumnName("PRTaskID");
            entity.Property(e => e.Stage).HasMaxLength(200);
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.ToTable("Priority", "IT");

            entity.Property(e => e.PriorityId).HasColumnName("PriorityID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Prlesson>(entity =>
        {
            entity.HasKey(e => e.PrlessonsId).HasName("PK__PRLesson__1E35F65FBD6C21BD");

            entity.ToTable("PRLesson", "IT");

            entity.Property(e => e.PrlessonsId).HasColumnName("PRLessonsID");
            entity.Property(e => e.Category).HasMaxLength(250);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.LessonsType).HasColumnName("Lessons_Type");
            entity.Property(e => e.MilestoneId).HasColumnName("MilestoneID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjCloserAccept)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.TemplateId).HasColumnName("TemplateID");
        });

        modelBuilder.Entity<ProjectCheckList>(entity =>
        {
            entity.HasKey(e => e.CheckListId).HasName("PK__ProjectC__AA708477AA2612EC");

            entity.ToTable("ProjectCheckList", "IT");

            entity.Property(e => e.CheckListId).HasColumnName("checkListId");
            entity.Property(e => e.CheckListTitle)
                .HasMaxLength(200)
                .HasColumnName("checkListTitle");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectLevel).HasMaxLength(200);
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
        });

        modelBuilder.Entity<ProjectCheckListHistory>(entity =>
        {
            entity.HasKey(e => e.ClhistoryId);

            entity.ToTable("ProjectCheckListHistory", "IT");

            entity.Property(e => e.ClhistoryId).HasColumnName("CLHistoryID");
            entity.Property(e => e.CheckListTitle).HasMaxLength(200);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectLevel).HasMaxLength(200);
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
        });

        modelBuilder.Entity<ProjectClosure>(entity =>
        {
            entity.HasKey(e => e.ClosureId).HasName("PK__ProjectC__F1610D1F39216454");

            entity.ToTable("ProjectClosure", "IT");

            entity.Property(e => e.ClosureId).HasColumnName("ClosureID");
            entity.Property(e => e.Attachment).HasMaxLength(500);
            entity.Property(e => e.Category).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Feedback).HasMaxLength(500);
            entity.Property(e => e.Impact).HasMaxLength(500);
            entity.Property(e => e.LessonsLearnt).HasMaxLength(500);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProblemsStatement).HasMaxLength(500);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Recommendation).HasMaxLength(500);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(500);
            entity.Property(e => e.Task).HasMaxLength(500);
        });

        modelBuilder.Entity<ProjectDeliverable>(entity =>
        {
            entity.HasKey(e => e.DeliverablesId).HasName("PK_IT.ProjectDeliverables");

            entity.ToTable("ProjectDeliverables", "IT");

            entity.Property(e => e.DeliverablesId).HasColumnName("DeliverablesID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.DeliverablesText)
                .HasMaxLength(500)
                .HasColumnName("deliverablesText");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
        });

        modelBuilder.Entity<ProjectGroup>(entity =>
        {
            entity.HasKey(e => e.ProjectGroupId).HasName("PK__ProjectG__17125E7EB19C0BF4");

            entity.ToTable("ProjectGroup", "IT");

            entity.Property(e => e.ProjectGroupId).HasColumnName("ProjectGroupID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectGroupName)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProjectIssue>(entity =>
        {
            entity.HasKey(e => e.IssueId).HasName("PK__ProjectI__749E806C562C74B8");

            entity.ToTable("ProjectIssue", "IT");

            entity.Property(e => e.IssueId).HasColumnName("issueId");
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.CompletionDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.DateClosed).HasColumnType("datetime");
            entity.Property(e => e.DateOpened).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Impact).HasMaxLength(200);
            entity.Property(e => e.IssueCode).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Notes).HasMaxLength(2000);
            entity.Property(e => e.Priority).HasMaxLength(200);
            entity.Property(e => e.ProjectLevel).HasMaxLength(200);
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.Status).HasMaxLength(200);
        });

        modelBuilder.Entity<ProjectIssueHistory>(entity =>
        {
            entity.HasKey(e => e.IssueHistoryId).HasName("PK__ProjectI__9532746DAAA5668B");

            entity.ToTable("ProjectIssueHistory", "IT");

            entity.Property(e => e.IssueHistoryId).HasColumnName("IssueHistoryID");
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.DateClosed).HasColumnType("datetime");
            entity.Property(e => e.DateOpened).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Impact).HasMaxLength(200);
            entity.Property(e => e.IssueCode).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Notes).HasMaxLength(2000);
            entity.Property(e => e.Priority).HasMaxLength(200);
            entity.Property(e => e.ProjectLevel).HasMaxLength(200);
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.Status).HasMaxLength(200);
        });

        modelBuilder.Entity<ProjectMember>(entity =>
        {
            entity.HasKey(e => e.PrMemberId).HasName("PK_IT.ProjectMembers");

            entity.ToTable("ProjectMembers", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.Role).HasMaxLength(500);
            entity.Property(e => e.Type).HasMaxLength(500);
        });

        modelBuilder.Entity<ProjectMembersHistory>(entity =>
        {
            entity.HasKey(e => e.PreMemHistoryId).HasName("PK__ProjectM__FCCBCB11CC0A70A8");

            entity.ToTable("ProjectMembersHistory", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.Role).HasMaxLength(500);
            entity.Property(e => e.Type).HasMaxLength(500);
        });

        modelBuilder.Entity<ProjectMembersNew>(entity =>
        {
            entity.HasKey(e => e.PrMemberId).HasName("PK_IT.ProjectMembers_New");

            entity.ToTable("ProjectMembers_New", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
        });

        modelBuilder.Entity<ProjectMgmt>(entity =>
        {
            entity.HasKey(e => e.ProjectMgmtId).HasName("PK_IT.ProjectMgmt");

            entity.ToTable("ProjectMgmt", "IT");

            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.Activity).HasMaxLength(500);
            entity.Property(e => e.ActualCost).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.AdditionalNotes)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Deliverables)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.EstimateCost).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectAccess)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProjectCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProjectDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ProjectName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<ProjectMgmtHistory>(entity =>
        {
            entity.HasKey(e => e.ProMgmtHistoId).HasName("PK__ProjectM__1D7DE929BC6AEFE2");

            entity.ToTable("ProjectMgmtHistory", "IT");

            entity.Property(e => e.ProMgmtHistoId).HasColumnName("ProMgmtHistoID");
            entity.Property(e => e.Activity).HasMaxLength(500);
            entity.Property(e => e.ActualCost).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.AdditionalNotes)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Deliverables)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.EstimateCost).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectAccess)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProjectCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProjectDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Sponser)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<ProjectMilestone>(entity =>
        {
            entity.HasKey(e => e.ProjMilestoneId).HasName("PK_IT.ProjectMilestone");

            entity.ToTable("ProjectMilestone", "IT");

            entity.Property(e => e.ProjMilestoneId).HasColumnName("ProjMilestoneID");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualFinishEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualFinishStartDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.FinishEndDt).HasColumnType("datetime");
            entity.Property(e => e.FinishStartDt).HasColumnType("datetime");
            entity.Property(e => e.MilestoneDesc).HasMaxLength(2000);
            entity.Property(e => e.MilestoneStatus).HasMaxLength(500);
            entity.Property(e => e.MilestoneTitle).HasMaxLength(500);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Owner).HasColumnName("owner");
            entity.Property(e => e.Priority).HasMaxLength(500);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(500);
        });

        modelBuilder.Entity<ProjectMilestoneHistory>(entity =>
        {
            entity.HasKey(e => e.ProjMileHistoryId).HasName("PK__ProjectM__F013FD7A141376FC");

            entity.ToTable("ProjectMilestoneHistory", "IT");

            entity.Property(e => e.ProjMileHistoryId).HasColumnName("ProjMileHistoryID");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualFinishEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualFinishStartDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.FinishEndDt).HasColumnType("datetime");
            entity.Property(e => e.FinishStartDt).HasColumnType("datetime");
            entity.Property(e => e.MilestoneDesc).HasMaxLength(2000);
            entity.Property(e => e.MilestoneStatus).HasMaxLength(500);
            entity.Property(e => e.MilestoneTitle).HasMaxLength(500);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Owner)
                .HasMaxLength(500)
                .HasColumnName("owner");
            entity.Property(e => e.Priority).HasMaxLength(500);
            entity.Property(e => e.ProjMilestoneId).HasColumnName("ProjMilestoneID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(500);
        });

        modelBuilder.Entity<ProjectNewMembersHistory>(entity =>
        {
            entity.HasKey(e => e.PreMemHistoryId).HasName("PK__ProjectN__FCCBCB1198203B87");

            entity.ToTable("ProjectNewMembersHistory", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
        });

        modelBuilder.Entity<ProjectTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK_IT.ProjectTask");

            entity.ToTable("ProjectTask", "IT");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.ActualCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.AssignTo).HasColumnName("assignTo");
            entity.Property(e => e.CompletionDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Dependency).HasMaxLength(500);
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.MilestoneId).HasColumnName("MilestoneID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ParentTaskId).HasColumnName("parentTaskId");
            entity.Property(e => e.PlannedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Priority).HasMaxLength(2000);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Projectphase).HasMaxLength(250);
            entity.Property(e => e.Prority).HasMaxLength(2000);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(2000);
            entity.Property(e => e.TaskCode).HasMaxLength(500);
            entity.Property(e => e.TaskDesc).HasMaxLength(2000);
            entity.Property(e => e.TaskTitle).HasMaxLength(500);
            entity.Property(e => e.WorkHours).HasMaxLength(2000);
        });

        modelBuilder.Entity<ProjectTaskHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__ProjectT__4D7B4ADD25127C5C");

            entity.ToTable("ProjectTaskHistory", "IT");

            entity.Property(e => e.HistoryId).HasColumnName("HistoryID");
            entity.Property(e => e.CompletionDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.MilestoneId).HasColumnName("MilestoneID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ParentTaskId).HasColumnName("parentTaskId");
            entity.Property(e => e.Priority).HasMaxLength(2000);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Prority).HasMaxLength(2000);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(2000);
            entity.Property(e => e.TaskCode).HasMaxLength(250);
            entity.Property(e => e.TaskDesc).HasMaxLength(2000);
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.TaskTitle).HasMaxLength(500);
            entity.Property(e => e.WorkHours).HasMaxLength(2000);
        });

        modelBuilder.Entity<Prtemplate>(entity =>
        {
            entity.HasKey(e => e.PrtemplateId).HasName("PK__PRTempla__4F671342D5FA16A9");

            entity.ToTable("PRTemplate", "IT");

            entity.Property(e => e.PrtemplateId).HasColumnName("PRTemplateID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.TemplateName).HasMaxLength(300);
        });

        modelBuilder.Entity<PrtemplateDtl>(entity =>
        {
            entity.HasKey(e => e.PrtemplateDtlsId).HasName("PK__PRTempla__F0BB07AE29CD8CE2");

            entity.ToTable("PRTemplateDtls", "IT");

            entity.Property(e => e.PrtemplateDtlsId).HasColumnName("PRTemplateDtlsID");
            entity.Property(e => e.Category).HasMaxLength(2000);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.MilestoneId).HasColumnName("MilestoneID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PrtemplateId).HasColumnName("PRTemplateID");
            entity.Property(e => e.Task).HasMaxLength(3000);
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
        });

        modelBuilder.Entity<PrtemplateResponse>(entity =>
        {
            entity.HasKey(e => e.Trid).HasName("PK__PRTempla__82F3BB35E5468872");

            entity.ToTable("PRTemplateResponse", "IT");

            entity.Property(e => e.Trid).HasColumnName("TRID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.LessonLearnedId).HasColumnName("LessonLearnedID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.TemplateDtlsId).HasColumnName("TemplateDtlsID");
            entity.Property(e => e.TemplateId).HasColumnName("TemplateID");
        });

        modelBuilder.Entity<Reference>(entity =>
        {
            entity.HasKey(e => e.ReferenceId).HasName("PK_IT.Reference");

            entity.ToTable("Reference", "IT");

            entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ReferenceName).HasMaxLength(50);
        });

        modelBuilder.Entity<ReferenceTyp>(entity =>
        {
            entity.HasKey(e => e.ReferenceTypeId).HasName("PK_IT.ReferenceTyp");

            entity.ToTable("ReferenceTyp", "IT");

            entity.Property(e => e.ReferenceTypeId).HasColumnName("ReferenceTypeID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ReferenceType).HasMaxLength(50);
        });

        modelBuilder.Entity<RiskPlan>(entity =>
        {
            entity.HasKey(e => e.ItriskId);

            entity.ToTable("RiskPlan", "IT");

            entity.Property(e => e.ItriskId).HasColumnName("ITRiskID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CommunicationDays)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CommunicationPlan).HasMaxLength(2000);
            entity.Property(e => e.CommunicationPlanAttachment).IsUnicode(false);
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.TestPlan).HasMaxLength(2000);
            entity.Property(e => e.TestPlanAttachment).IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.RiskPlans)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RiskPlan_Category");
        });

        modelBuilder.Entity<ServiceMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SERVICE___3213E83F29FD6911");

            entity.ToTable("SERVICE_MASTER", "IT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AppSatus)
                .HasMaxLength(500)
                .HasColumnName("app_satus");
            entity.Property(e => e.AppValue)
                .HasMaxLength(500)
                .HasColumnName("app_value");
            entity.Property(e => e.ApprovalReamarks)
                .IsUnicode(false)
                .HasColumnName("Approval_Reamarks");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Approval_Status");
            entity.Property(e => e.ApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("approve_date");
            entity.Property(e => e.ApprovedBy).HasColumnName("Approved_By");
            entity.Property(e => e.ApprovedOn)
                .HasColumnType("datetime")
                .HasColumnName("Approved_On");
            entity.Property(e => e.Attachment)
                .HasMaxLength(500)
                .HasColumnName("attachment");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.DetailedDesc)
                .HasMaxLength(500)
                .HasColumnName("detailed_desc");
            entity.Property(e => e.Justification).HasColumnName("justification");
            entity.Property(e => e.LastApprover)
                .HasMaxLength(100)
                .HasColumnName("last_approver");
            entity.Property(e => e.MachineName)
                .HasMaxLength(500)
                .HasColumnName("machine_name");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(100)
                .HasColumnName("pending_approver");
            entity.Property(e => e.PlantCode)
                .HasMaxLength(5)
                .HasColumnName("plant_code");
            entity.Property(e => e.PurchaseGroup)
                .HasMaxLength(500)
                .HasColumnName("purchase_group");
            entity.Property(e => e.Purpose)
                .HasMaxLength(500)
                .HasColumnName("purpose");
            entity.Property(e => e.RejectedFlag)
                .HasMaxLength(50)
                .HasColumnName("rejected_flag");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("request_date");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("request_no");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(500)
                .HasColumnName("requested_by");
            entity.Property(e => e.ResolutionBy).HasColumnName("Resolution_By");
            entity.Property(e => e.ResolutionOn)
                .HasColumnType("datetime")
                .HasColumnName("Resolution_On");
            entity.Property(e => e.ResolutionReamarks)
                .IsUnicode(false)
                .HasColumnName("Resolution_Reamarks");
            entity.Property(e => e.ResolutionStatus)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Resolution_Status");
            entity.Property(e => e.SacCode)
                .HasMaxLength(50)
                .HasColumnName("SAC_Code");
            entity.Property(e => e.SapCodeExists)
                .HasMaxLength(50)
                .HasColumnName("SAP_CODE_EXISTS");
            entity.Property(e => e.SapCodeNo)
                .HasMaxLength(100)
                .HasColumnName("SAP_CODE_NO");
            entity.Property(e => e.SapCreatedby).HasColumnName("SAP_CREATEDBY");
            entity.Property(e => e.SapCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_CREATION_DATE");
            entity.Property(e => e.ServiceCatagory)
                .HasMaxLength(500)
                .HasColumnName("service_catagory");
            entity.Property(e => e.ServiceDescription).HasColumnName("service_description");
            entity.Property(e => e.ServiceGroup)
                .HasMaxLength(500)
                .HasColumnName("service_group");
            entity.Property(e => e.SrModuleId).HasColumnName("Sr_Module_ID");
            entity.Property(e => e.SrNumber)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Sr_number");
            entity.Property(e => e.StorageLocation)
                .HasMaxLength(500)
                .HasColumnName("storage_location");
            entity.Property(e => e.Uom)
                .HasMaxLength(500)
                .HasColumnName("uom");
            entity.Property(e => e.ValuationClass)
                .HasMaxLength(500)
                .HasColumnName("valuation_class");
            entity.Property(e => e.WhereUsed)
                .HasMaxLength(500)
                .HasColumnName("where_used");
        });

        modelBuilder.Entity<ServiceRequest>(entity =>
        {
            entity.HasKey(e => e.Srid).HasName("PK_IT_ServiceRequest");

            entity.ToTable("ServiceRequest", "IT");

            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.ApprovedBy).HasMaxLength(200);
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.Approverstage).HasMaxLength(200);
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.GuestCompany).HasMaxLength(500);
            entity.Property(e => e.GuestContactNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GuestEmail).HasMaxLength(50);
            entity.Property(e => e.GuestName).HasMaxLength(50);
            entity.Property(e => e.GuestReportingManagerEmployeeId).HasMaxLength(50);
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ProposedResolutionOn).HasColumnType("datetime");
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Srcode)
                .HasMaxLength(50)
                .HasColumnName("SRCode");
            entity.Property(e => e.Srdate)
                .HasColumnType("datetime")
                .HasColumnName("SRDate");
            entity.Property(e => e.Srdesc)
                .HasMaxLength(2000)
                .HasColumnName("SRDesc");
            entity.Property(e => e.SrforGuest)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SRForGuest");
            entity.Property(e => e.SrraiseFor).HasColumnName("SRRaiseFor");
            entity.Property(e => e.SrraisedBy).HasColumnName("SRRaisedBy");
            entity.Property(e => e.Srselectedfor)
                .HasMaxLength(50)
                .HasColumnName("SRSelectedfor");
            entity.Property(e => e.SrshotDesc)
                .HasMaxLength(200)
                .HasColumnName("SRShotDesc");
            entity.Property(e => e.Stage).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<ServiceRequestHistory>(entity =>
        {
            entity.HasKey(e => e.SrhistoryId).HasName("PK_IT_ServiceRequestHistory");

            entity.ToTable("ServiceRequestHistory", "IT");

            entity.Property(e => e.SrhistoryId).HasColumnName("SRHistoryID");
            entity.Property(e => e.ApprovedBy).HasMaxLength(200);
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.Approverstage).HasMaxLength(200);
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.GuestCompany).HasMaxLength(500);
            entity.Property(e => e.GuestContactNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GuestEmail).HasMaxLength(50);
            entity.Property(e => e.GuestName).HasMaxLength(50);
            entity.Property(e => e.GuestReportingManagerEmployeeId).HasMaxLength(50);
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ProposedResolutionOn).HasColumnType("datetime");
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Srcode)
                .HasMaxLength(50)
                .HasColumnName("SRCode");
            entity.Property(e => e.Srdate)
                .HasColumnType("datetime")
                .HasColumnName("SRDate");
            entity.Property(e => e.Srdesc)
                .HasMaxLength(2000)
                .HasColumnName("SRDesc");
            entity.Property(e => e.SrforGuest)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SRForGuest");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SrraiseFor).HasColumnName("SRRaiseFor");
            entity.Property(e => e.SrraisedBy).HasColumnName("SRRaisedBy");
            entity.Property(e => e.Srselectedfor)
                .HasMaxLength(50)
                .HasColumnName("SRSelectedfor");
            entity.Property(e => e.SrshotDesc)
                .HasMaxLength(200)
                .HasColumnName("SRShotDesc");
            entity.Property(e => e.Stage).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Sla>(entity =>
        {
            entity.HasKey(e => e.Itslaid);

            entity.ToTable("SLA", "IT");

            entity.Property(e => e.Itslaid).HasColumnName("ITSLAID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.WaitTimeUnit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WaitTimeUnitEscal1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WaitTimeUnitEscal2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Slas)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SLA_Category");

            entity.HasOne(d => d.Classification).WithMany(p => p.Slas)
                .HasForeignKey(d => d.ClassificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SLA_ITClassification");
        });

        modelBuilder.Entity<SoftwareLibrary>(entity =>
        {
            entity.HasKey(e => e.SoftwareLibraryId).HasName("PK__Software__3AEA91823259245C");

            entity.ToTable("SoftwareLibrary", "IT");

            entity.Property(e => e.SoftwareLibraryId).HasColumnName("SoftwareLibraryID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SoftwareName)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SoftwareLibraryHistory>(entity =>
        {
            entity.ToTable("SoftwareLibraryHistory", "IT");

            entity.Property(e => e.SoftwareLibraryHistoryId).HasColumnName("SoftwareLibraryHistoryID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SoftwareLibraryId).HasColumnName("SoftwareLibraryID");
            entity.Property(e => e.SoftwareName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SoftwareVersion>(entity =>
        {
            entity.HasKey(e => e.SoftVersionId).HasName("PK__Software__5C459484FD95F1A0");

            entity.ToTable("SoftwareVersion", "IT");

            entity.Property(e => e.SoftVersionId).HasColumnName("SoftVersionID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SoftVersionName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.SoftwareLibraryId).HasColumnName("SoftwareLibraryID");
        });

        modelBuilder.Entity<SoftwareVersionHistory>(entity =>
        {
            entity.HasKey(e => e.SoftVersionHistoryId);

            entity.ToTable("SoftwareVersionHistory", "IT");

            entity.Property(e => e.SoftVersionHistoryId).HasColumnName("SoftVersionHistoryID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SoftVersionId).HasColumnName("SoftVersionID");
            entity.Property(e => e.SoftVersionName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.SoftwareLibraryId).HasColumnName("SoftwareLibraryID");
        });

        modelBuilder.Entity<Sraccess>(entity =>
        {
            entity.HasKey(e => e.SraccessId).HasName("PK_IT_SRAccess");

            entity.ToTable("SRAccess", "IT");

            entity.Property(e => e.SraccessId).HasColumnName("SRAccessID");
            entity.Property(e => e.AccessEndTime).HasColumnType("datetime");
            entity.Property(e => e.AccessStartTime).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.DoremoteAccess)
                .HasColumnType("datetime")
                .HasColumnName("DORemoteAccess");
            entity.Property(e => e.DoremovalAccess)
                .HasColumnType("datetime")
                .HasColumnName("DORemovalAccess");
            entity.Property(e => e.DowntimeRequired).HasMaxLength(100);
            entity.Property(e => e.Ipdetails).HasColumnName("IPDetails");
            entity.Property(e => e.KindAccess).HasMaxLength(100);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.RequestType).HasMaxLength(100);
            entity.Property(e => e.SoftName).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Swremoved).HasColumnName("SWRemoved");
            entity.Property(e => e.TypeServerAccess).HasMaxLength(100);
            entity.Property(e => e.VenderFocalEmailId)
                .HasMaxLength(200)
                .HasColumnName("VenderFocalEmailID");
            entity.Property(e => e.VenderFocalName).HasMaxLength(200);
            entity.Property(e => e.VenderName).HasMaxLength(200);
        });

        modelBuilder.Entity<SraccessHistory>(entity =>
        {
            entity.HasKey(e => e.SrahistoryId).HasName("PK_IT_SRAccessHistory");

            entity.ToTable("SRAccessHistory", "IT");

            entity.Property(e => e.SrahistoryId).HasColumnName("SRAHistoryID");
            entity.Property(e => e.AccessEndTime).HasColumnType("datetime");
            entity.Property(e => e.AccessStartTime).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.DoremoteAccess)
                .HasColumnType("datetime")
                .HasColumnName("DORemoteAccess");
            entity.Property(e => e.DoremovalAccess)
                .HasColumnType("datetime")
                .HasColumnName("DORemovalAccess");
            entity.Property(e => e.DowntimeRequired).HasMaxLength(100);
            entity.Property(e => e.Ipdetails).HasColumnName("IPDetails");
            entity.Property(e => e.KindAccess).HasMaxLength(100);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.RequestType).HasMaxLength(100);
            entity.Property(e => e.SoftName).HasMaxLength(200);
            entity.Property(e => e.SraccessId).HasColumnName("SRAccessID");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Swremoved).HasColumnName("SWRemoved");
            entity.Property(e => e.TypeServerAccess).HasMaxLength(100);
            entity.Property(e => e.VenderFocalEmailId)
                .HasMaxLength(200)
                .HasColumnName("VenderFocalEmailID");
            entity.Property(e => e.VenderFocalName).HasMaxLength(200);
            entity.Property(e => e.VenderName).HasMaxLength(200);
        });

        modelBuilder.Entity<Srantivirus>(entity =>
        {
            entity.HasKey(e => e.Sravid).HasName("PK_IT_SRAntivirus");

            entity.ToTable("SRAntivirus", "IT");

            entity.Property(e => e.Sravid).HasColumnName("SRAVID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ExcDts).HasMaxLength(200);
            entity.Property(e => e.IncDts).HasMaxLength(200);
            entity.Property(e => e.InstallDts).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.RequestType).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.UninstallDts).HasMaxLength(200);
        });

        modelBuilder.Entity<SrantivirusHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SRAntivirusHistory", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ExcDts).HasMaxLength(200);
            entity.Property(e => e.IncDts).HasMaxLength(200);
            entity.Property(e => e.InstallDts).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.RequestType).HasMaxLength(200);
            entity.Property(e => e.SravhistoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SRAVHistoryID");
            entity.Property(e => e.Sravid).HasColumnName("SRAVID");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.UninstallDts).HasMaxLength(200);
        });

        modelBuilder.Entity<Srapprover>(entity =>
        {
            entity.HasKey(e => e.SrapproverId).HasName("PK_SRApproverID");

            entity.ToTable("SRApprover", "IT");

            entity.Property(e => e.SrapproverId).HasColumnName("SRApproverID");
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.Attachment)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Stage)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SupportId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SupportID");
        });

        modelBuilder.Entity<Srattachment>(entity =>
        {
            entity.HasKey(e => e.AttachId);

            entity.ToTable("SRAttachment", "IT");

            entity.Property(e => e.AttachId).HasColumnName("AttachID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Stage).HasMaxLength(200);
        });

        modelBuilder.Entity<SrcitrixAccess>(entity =>
        {
            entity.HasKey(e => e.Srcid).HasName("PK_IT_SRCitrixAccess");

            entity.ToTable("SRCitrixAccess", "IT");

            entity.Property(e => e.Srcid).HasColumnName("SRCID");
            entity.Property(e => e.Adid)
                .HasMaxLength(200)
                .HasColumnName("ADID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.HostName).HasMaxLength(200);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(200)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Oupath)
                .HasMaxLength(200)
                .HasColumnName("OUPath");
            entity.Property(e => e.ReplaceAdid)
                .HasMaxLength(200)
                .HasColumnName("ReplaceADID");
            entity.Property(e => e.RequestType).HasMaxLength(100);
            entity.Property(e => e.SoftwareRequired).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<SrcitrixAccessHistory>(entity =>
        {
            entity.HasKey(e => e.Srcahid);

            entity.ToTable("SRCitrixAccessHistory", "IT");

            entity.Property(e => e.Srcahid).HasColumnName("SRCAHID");
            entity.Property(e => e.Adid)
                .HasMaxLength(200)
                .HasColumnName("ADID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.HostName).HasMaxLength(200);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(200)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Oupath)
                .HasMaxLength(200)
                .HasColumnName("OUPath");
            entity.Property(e => e.ReplaceAdid)
                .HasMaxLength(200)
                .HasColumnName("ReplaceADID");
            entity.Property(e => e.RequestType).HasMaxLength(100);
            entity.Property(e => e.SoftwareRequired).HasMaxLength(200);
            entity.Property(e => e.Srcid).HasColumnName("SRCID");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<Srdomain>(entity =>
        {
            entity.HasKey(e => e.SrdomainId).HasName("PK_IT_SRDomain");

            entity.ToTable("SRDomain", "IT");

            entity.Property(e => e.SrdomainId).HasColumnName("SRDomainID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.DiscontinuationDate).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Justification).HasMaxLength(250);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Plant).HasMaxLength(200);
            entity.Property(e => e.PurPoseDomain).HasMaxLength(200);
            entity.Property(e => e.ReqDomainName).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.TypeofSsl)
                .HasMaxLength(250)
                .HasColumnName("TypeofSSL");
        });

        modelBuilder.Entity<SrdomainHistory>(entity =>
        {
            entity.HasKey(e => e.SrdhistoryId).HasName("PK_IT_SRDomainHistory");

            entity.ToTable("SRDomainHistory", "IT");

            entity.Property(e => e.SrdhistoryId).HasColumnName("SRDHistoryID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.DiscontinuationDate).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Justification).HasMaxLength(250);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Plant).HasMaxLength(200);
            entity.Property(e => e.PurPoseDomain).HasMaxLength(200);
            entity.Property(e => e.SrdomainId).HasColumnName("SRDomainID");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.TypeofSsl)
                .HasMaxLength(250)
                .HasColumnName("TypeofSSL");
        });

        modelBuilder.Entity<Sremail>(entity =>
        {
            entity.HasKey(e => e.SremailId).HasName("PK_IT_SREmail");

            entity.ToTable("SREmail", "IT");

            entity.Property(e => e.SremailId).HasColumnName("SREmailID");
            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.CommonEmailId)
                .HasMaxLength(200)
                .HasColumnName("CommonEmailID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Designation).HasMaxLength(200);
            entity.Property(e => e.EmailId)
                .HasMaxLength(200)
                .HasColumnName("EmailID");
            entity.Property(e => e.EmpCategory).HasMaxLength(200);
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EmpName).HasMaxLength(200);
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.Gb)
                .HasMaxLength(20)
                .HasColumnName("GB");
            entity.Property(e => e.GroupName).IsUnicode(false);
            entity.Property(e => e.Hod)
                .HasMaxLength(200)
                .HasColumnName("HOD");
            entity.Property(e => e.Intercom).HasMaxLength(200);
            entity.Property(e => e.MailAccess).HasMaxLength(50);
            entity.Property(e => e.MailGroup).HasMaxLength(200);
            entity.Property(e => e.MemberAdded).IsUnicode(false);
            entity.Property(e => e.MoblieNo).HasMaxLength(50);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.OutsideComm).HasMaxLength(20);
            entity.Property(e => e.PreEmailId)
                .HasMaxLength(200)
                .HasColumnName("PreEmailID");
            entity.Property(e => e.ReportManager).HasMaxLength(200);
            entity.Property(e => e.Requesttype).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<SremailHistory>(entity =>
        {
            entity.HasKey(e => e.SrehistoryId).HasName("PK_IT_SREmailHistory");

            entity.ToTable("SREmailHistory", "IT");

            entity.Property(e => e.SrehistoryId).HasColumnName("SREHistoryID");
            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.CommonEmailId)
                .HasMaxLength(200)
                .HasColumnName("CommonEmailID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Designation).HasMaxLength(200);
            entity.Property(e => e.EmailId)
                .HasMaxLength(200)
                .HasColumnName("EmailID");
            entity.Property(e => e.EmpCategory).HasMaxLength(200);
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EmpName).HasMaxLength(200);
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.Gb)
                .HasMaxLength(20)
                .HasColumnName("GB");
            entity.Property(e => e.GroupName).HasMaxLength(1);
            entity.Property(e => e.Hod)
                .HasMaxLength(200)
                .HasColumnName("HOD");
            entity.Property(e => e.Intercom).HasMaxLength(200);
            entity.Property(e => e.MailAccess).HasMaxLength(50);
            entity.Property(e => e.MailGroup).HasMaxLength(200);
            entity.Property(e => e.MemberAdded).HasMaxLength(1);
            entity.Property(e => e.MoblieNo).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.OutsideComm).HasMaxLength(20);
            entity.Property(e => e.PreEmailId)
                .HasMaxLength(200)
                .HasColumnName("PreEmailID");
            entity.Property(e => e.ReportManager).HasMaxLength(200);
            entity.Property(e => e.Requesttype).HasMaxLength(200);
            entity.Property(e => e.SremailId).HasColumnName("SREmailID");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<SrexternalDrive>(entity =>
        {
            entity.HasKey(e => e.Sredid).HasName("PK_IT_SRExternalDriveAccess");

            entity.ToTable("SRExternalDrive", "IT");

            entity.Property(e => e.Sredid).HasColumnName("SREDID");
            entity.Property(e => e.AccessPath).HasMaxLength(200);
            entity.Property(e => e.AccessRequired).HasMaxLength(200);
            entity.Property(e => e.AccessType).HasMaxLength(200);
            entity.Property(e => e.Attachment).HasMaxLength(500);
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Designation).HasMaxLength(200);
            entity.Property(e => e.EmpCategory).HasMaxLength(200);
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.ForSelf).HasMaxLength(200);
            entity.Property(e => e.Hod)
                .HasMaxLength(200)
                .HasColumnName("HOD");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.OnwerEmail).HasMaxLength(200);
            entity.Property(e => e.OnwerPlant).HasMaxLength(200);
            entity.Property(e => e.ReportingManager).HasMaxLength(200);
            entity.Property(e => e.ReqType).HasMaxLength(200);
            entity.Property(e => e.Role).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SubDepartment).HasMaxLength(200);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<SrexternalDriveHistory>(entity =>
        {
            entity.HasKey(e => e.Sredhid);

            entity.ToTable("SRExternalDriveHistory", "IT");

            entity.Property(e => e.Sredhid).HasColumnName("SREDHID");
            entity.Property(e => e.AccessPath).HasMaxLength(200);
            entity.Property(e => e.AccessRequired).HasMaxLength(200);
            entity.Property(e => e.AccessType).HasMaxLength(200);
            entity.Property(e => e.Attachment).HasMaxLength(500);
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Designation).HasMaxLength(200);
            entity.Property(e => e.EmpCategory).HasMaxLength(200);
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.ForSelf).HasMaxLength(200);
            entity.Property(e => e.Hod)
                .HasMaxLength(200)
                .HasColumnName("HOD");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.OnwerEmail).HasMaxLength(200);
            entity.Property(e => e.OnwerPlant).HasMaxLength(200);
            entity.Property(e => e.ReportingManager).HasMaxLength(200);
            entity.Property(e => e.ReqType).HasMaxLength(200);
            entity.Property(e => e.Role).HasMaxLength(200);
            entity.Property(e => e.Sredid).HasColumnName("SREDID");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SubDepartment).HasMaxLength(200);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<Srftpaccess>(entity =>
        {
            entity.HasKey(e => e.Srftpaid).HasName("PK_IT_SRFTPAccess");

            entity.ToTable("SRFTPAccess", "IT");

            entity.Property(e => e.Srftpaid).HasColumnName("SRFTPAID");
            entity.Property(e => e.AccessPath).HasMaxLength(200);
            entity.Property(e => e.AccessRequire).HasMaxLength(200);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.OwnerEmail).HasMaxLength(200);
            entity.Property(e => e.OwnerPlant).HasMaxLength(200);
            entity.Property(e => e.ReqType).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<SrftpaccessHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SRFTPAccessHistory", "IT");

            entity.Property(e => e.AccessPath).HasMaxLength(200);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.OwnerEmail).HasMaxLength(200);
            entity.Property(e => e.OwnerPlant).HasMaxLength(200);
            entity.Property(e => e.ReqType).HasMaxLength(200);
            entity.Property(e => e.Srftpaid).HasColumnName("SRFTPAID");
            entity.Property(e => e.Srftphid)
                .ValueGeneratedOnAdd()
                .HasColumnName("SRFTPHID");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<Srresolution>(entity =>
        {
            entity.HasKey(e => e.SrresolId).HasName("PK_IT_SRResolution");

            entity.ToTable("SRResolution", "IT");

            entity.Property(e => e.SrresolId).HasColumnName("SRResolID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.OnHoldReason).HasMaxLength(200);
            entity.Property(e => e.ProposedResolDt).HasColumnType("datetime");
            entity.Property(e => e.ResolDt).HasColumnType("datetime");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserRemarks).HasMaxLength(200);
        });

        modelBuilder.Entity<SrresolutionHistory>(entity =>
        {
            entity.HasKey(e => e.SrresolHistoryId).HasName("PK_IT_SRResolutionHistory");

            entity.ToTable("SRResolutionHistory", "IT");

            entity.Property(e => e.SrresolHistoryId).HasColumnName("SRResolHistoryID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.OnHoldReason).HasMaxLength(200);
            entity.Property(e => e.ProposedResolDt).HasColumnType("datetime");
            entity.Property(e => e.ResolDt).HasColumnType("datetime");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserRemarks).HasMaxLength(200);
        });

        modelBuilder.Entity<SrrestorationAccess>(entity =>
        {
            entity.HasKey(e => e.Srrid).HasName("PK_IT_SRRestorationAccess");

            entity.ToTable("SRRestorationAccess", "IT");

            entity.Property(e => e.Srrid).HasColumnName("SRRID");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Descriptions).HasMaxLength(200);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Ots)
                .HasMaxLength(200)
                .HasColumnName("OTS");
            entity.Property(e => e.ProvideDescription).HasMaxLength(200);
            entity.Property(e => e.RequestType).HasMaxLength(100);
            entity.Property(e => e.Restoration).HasColumnType("datetime");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<SrrestorationAccessHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SRRestorationAccessHistory", "IT");

            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Descriptions).HasMaxLength(200);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Ots)
                .HasMaxLength(200)
                .HasColumnName("OTS");
            entity.Property(e => e.ProvideDescription).HasMaxLength(200);
            entity.Property(e => e.RequestType).HasMaxLength(100);
            entity.Property(e => e.Restoration).HasColumnType("datetime");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Srrahid)
                .ValueGeneratedOnAdd()
                .HasColumnName("SRRAHID");
            entity.Property(e => e.Srrid).HasColumnName("SRRID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<SrserverAccess>(entity =>
        {
            entity.HasKey(e => e.SrserverId).HasName("PK_IT_SRServerAccess");

            entity.ToTable("SRServerAccess", "IT");

            entity.Property(e => e.SrserverId).HasColumnName("SRServerID");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.FileServerName).HasMaxLength(200);
            entity.Property(e => e.FolderPath).HasMaxLength(200);
            entity.Property(e => e.HostName).HasMaxLength(200);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(200)
                .HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.RequestType).HasMaxLength(100);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<SrserverAccessHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SRServerAccessHistory", "IT");

            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.FileServerName).HasMaxLength(200);
            entity.Property(e => e.FolderPath).HasMaxLength(200);
            entity.Property(e => e.HostName).HasMaxLength(200);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(200)
                .HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.RequestType).HasMaxLength(100);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Srsahid)
                .ValueGeneratedOnAdd()
                .HasColumnName("SRSAHID");
            entity.Property(e => e.SrserverId).HasColumnName("SRServerID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<Srsoftware>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SRSoftware", "IT");

            entity.Property(e => e.Amcappilcable).HasColumnName("AMCAppilcable");
            entity.Property(e => e.CostForAmc)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("CostForAMC");
            entity.Property(e => e.CostPerLicence).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CurrVersion).HasMaxLength(200);
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.DtlsOfDev).HasMaxLength(200);
            entity.Property(e => e.DtlsOfinstDt).HasColumnType("datetime");
            entity.Property(e => e.InstCharge).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.InstType).HasMaxLength(200);
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.LicenceType).HasMaxLength(200);
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ScopeOfAmc)
                .HasMaxLength(2000)
                .HasColumnName("ScopeOfAMC");
            entity.Property(e => e.SoftwareType).HasMaxLength(20);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Swid)
                .ValueGeneratedOnAdd()
                .HasColumnName("SWID");
            entity.Property(e => e.TareVersion).HasMaxLength(200);
            entity.Property(e => e.TotalCost).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.TypeOfDev).HasMaxLength(200);
            entity.Property(e => e.TypeOfWeb).HasMaxLength(200);
            entity.Property(e => e.UsageBy).HasColumnName("UsageBY");
            entity.Property(e => e.UserAccessFrom).HasMaxLength(200);
            entity.Property(e => e.VendorName).HasMaxLength(200);
        });

        modelBuilder.Entity<SrsoftwareHistory>(entity =>
        {
            entity.HasKey(e => e.Swhid);

            entity.ToTable("SRSoftwareHistory", "IT");

            entity.Property(e => e.Swhid).HasColumnName("SWHID");
            entity.Property(e => e.Amcappilcable).HasColumnName("AMCAppilcable");
            entity.Property(e => e.CostForAmc)
                .HasMaxLength(200)
                .HasColumnName("CostForAMC");
            entity.Property(e => e.CostPerLicence).HasMaxLength(200);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CurrVersion).HasMaxLength(200);
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.DtlsOfDev).HasMaxLength(200);
            entity.Property(e => e.DtlsOfinstDt).HasColumnType("datetime");
            entity.Property(e => e.InstCharge).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.InstType).HasMaxLength(200);
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.LicenceType).HasMaxLength(200);
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.NoOfLicence).HasMaxLength(200);
            entity.Property(e => e.NoOfUers).HasMaxLength(200);
            entity.Property(e => e.ScopeOfAmc)
                .HasMaxLength(200)
                .HasColumnName("ScopeOfAMC");
            entity.Property(e => e.SoftwareName).HasMaxLength(200);
            entity.Property(e => e.SoftwareType).HasMaxLength(20);
            entity.Property(e => e.SoftwareVersionName).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.TareVersion).HasMaxLength(200);
            entity.Property(e => e.TypeOfDev).HasMaxLength(200);
            entity.Property(e => e.TypeOfWeb).HasMaxLength(200);
            entity.Property(e => e.UsageBy).HasColumnName("UsageBY");
            entity.Property(e => e.UserAccessFrom).HasMaxLength(200);
            entity.Property(e => e.VendorName).HasMaxLength(200);
        });

        modelBuilder.Entity<Srurlaccess>(entity =>
        {
            entity.HasKey(e => e.Srurlid).HasName("PK_IT_SRURLAccess");

            entity.ToTable("SRURLAccess", "IT");

            entity.Property(e => e.Srurlid).HasColumnName("SRURLID");
            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.HostName).HasMaxLength(200);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(200)
                .HasColumnName("IPAddress");
            entity.Property(e => e.RequestType).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Urlrequired)
                .HasMaxLength(200)
                .HasColumnName("URLRequired");
        });

        modelBuilder.Entity<SrurlaccessHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SRURLAccessHistory", "IT");

            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.HostName).HasMaxLength(200);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(200)
                .HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.RequestType).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Srurlhid)
                .ValueGeneratedOnAdd()
                .HasColumnName("SRURLHID");
            entity.Property(e => e.Srurlid).HasColumnName("SRURLID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Urlrequired)
                .HasMaxLength(200)
                .HasColumnName("URLRequired");
        });

        modelBuilder.Entity<Srusbaccess>(entity =>
        {
            entity.HasKey(e => e.Srusbaid).HasName("PK_IT_SRUSBAccess");

            entity.ToTable("SRUSBAccess", "IT");

            entity.Property(e => e.Srusbaid).HasColumnName("SRUSBAID");
            entity.Property(e => e.AccessType).HasMaxLength(200);
            entity.Property(e => e.Adid)
                .HasMaxLength(200)
                .HasColumnName("ADID");
            entity.Property(e => e.AssetDetails).HasMaxLength(200);
            entity.Property(e => e.DeviceType).HasMaxLength(200);
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.HostName).HasMaxLength(200);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(200)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<SrusbaccessHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SRUSBAccessHistory", "IT");

            entity.Property(e => e.AccessType).HasMaxLength(200);
            entity.Property(e => e.Adid)
                .HasMaxLength(200)
                .HasColumnName("ADID");
            entity.Property(e => e.AssetDetails).HasMaxLength(200);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.DeviceType).HasMaxLength(200);
            entity.Property(e => e.DurationFrom).HasColumnType("datetime");
            entity.Property(e => e.DurationTo).HasColumnType("datetime");
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.HostName).HasMaxLength(200);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(200)
                .HasColumnName("IPAddress");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Srusbaid).HasColumnName("SRUSBAID");
            entity.Property(e => e.Srusbhid)
                .ValueGeneratedOnAdd()
                .HasColumnName("SRUSBHID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<Srvirtual>(entity =>
        {
            entity.HasKey(e => e.Srvmid).HasName("PK_IT_SRVirtual");

            entity.ToTable("SRVirtual", "IT");

            entity.Property(e => e.Srvmid).HasColumnName("SRVMID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmailId)
                .HasMaxLength(200)
                .HasColumnName("EmailID");
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.NoParticipants).HasMaxLength(200);
            entity.Property(e => e.RequestType).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<SrvirtualHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SRVirtualHistory", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmailId)
                .HasMaxLength(200)
                .HasColumnName("EmailID");
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.NoParticipants).HasMaxLength(200);
            entity.Property(e => e.RequestType).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Srvhid)
                .ValueGeneratedOnAdd()
                .HasColumnName("SRVHID");
            entity.Property(e => e.Srvmid).HasColumnName("SRVMID");
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<Srvpnaccess>(entity =>
        {
            entity.HasKey(e => e.Srvpnid).HasName("PK_IT_SRVPNAccess");

            entity.ToTable("SRVPNAccess", "IT");

            entity.Property(e => e.Srvpnid).HasColumnName("SRVPNID");
            entity.Property(e => e.AccessFromDt).HasColumnType("datetime");
            entity.Property(e => e.AccessList).HasMaxLength(200);
            entity.Property(e => e.AccessPermission).HasMaxLength(200);
            entity.Property(e => e.AccessToDt).HasColumnType("datetime");
            entity.Property(e => e.AccessType).HasMaxLength(200);
            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpPlant).HasMaxLength(200);
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.Location)
                .HasMaxLength(300)
                .IsFixedLength();
            entity.Property(e => e.RequestType).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<SrvpnaccessHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SRVPNAccessHistory", "IT");

            entity.Property(e => e.AccessFromDt).HasColumnType("datetime");
            entity.Property(e => e.AccessList).HasMaxLength(200);
            entity.Property(e => e.AccessPermission).HasMaxLength(200);
            entity.Property(e => e.AccessToDt).HasColumnType("datetime");
            entity.Property(e => e.AccessType).HasMaxLength(200);
            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpPlant).HasMaxLength(200);
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.Location)
                .HasMaxLength(300)
                .IsFixedLength();
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.RequestType).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Srvpnhid)
                .ValueGeneratedOnAdd()
                .HasColumnName("SRVPNHID");
            entity.Property(e => e.Srvpnid).HasColumnName("SRVPNID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<Srwifiaccess>(entity =>
        {
            entity.HasKey(e => e.Srwifiid).HasName("PK_IT_SRWIFIAccess");

            entity.ToTable("SRWIFIAccess", "IT");

            entity.Property(e => e.Srwifiid).HasColumnName("SRWIFIID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.Isactive).HasColumnName("ISActive");
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.RequestType).HasMaxLength(200);
            entity.Property(e => e.SpecifyOffice).HasMaxLength(200);
            entity.Property(e => e.SpecifyPlant).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.ToDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SrwifiaccessHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SRWIFIAccessHistory", "IT");

            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.Isactive).HasColumnName("ISActive");
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.RequestType).HasMaxLength(200);
            entity.Property(e => e.SpecifyOffice).HasMaxLength(200);
            entity.Property(e => e.SpecifyPlant).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Srwhid)
                .ValueGeneratedOnAdd()
                .HasColumnName("SRWHID");
            entity.Property(e => e.Srwifiid).HasColumnName("SRWIFIID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.ToDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SrwindowLogin>(entity =>
        {
            entity.HasKey(e => e.Srwlid).HasName("PK_IT_SRWindowLogin");

            entity.ToTable("SRWindowLogin", "IT");

            entity.Property(e => e.Srwlid).HasColumnName("SRWLID");
            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.ChangeOupath)
                .HasMaxLength(200)
                .HasColumnName("ChangeOUPath");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Eidindividual)
                .HasColumnType("datetime")
                .HasColumnName("EIDIndividual");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(200);
            entity.Property(e => e.Hod)
                .HasMaxLength(200)
                .HasColumnName("HOD");
            entity.Property(e => e.Initials).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PayGroup).HasMaxLength(200);
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ReportingTo)
                .HasMaxLength(200)
                .HasColumnName("ReportingTO");
            entity.Property(e => e.RequestType).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.StaffCategory).HasMaxLength(200);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.UserId)
                .HasMaxLength(200)
                .HasColumnName("UserID");
            entity.Property(e => e.UserType).HasMaxLength(200);
        });

        modelBuilder.Entity<SrwindowLoginHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SRWindowLoginHistory", "IT");

            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.ChangeOupath)
                .HasMaxLength(200)
                .HasColumnName("ChangeOUPath");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Eidindividual)
                .HasColumnType("datetime")
                .HasColumnName("EIDIndividual");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(200);
            entity.Property(e => e.Hod)
                .HasMaxLength(200)
                .HasColumnName("HOD");
            entity.Property(e => e.Initials).HasMaxLength(200);
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PayGroup).HasMaxLength(200);
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ReportingTo)
                .HasMaxLength(200)
                .HasColumnName("ReportingTO");
            entity.Property(e => e.RequestType).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(200);
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Srwlhid)
                .ValueGeneratedOnAdd()
                .HasColumnName("SRWLHID");
            entity.Property(e => e.Srwlid).HasColumnName("SRWLID");
            entity.Property(e => e.StaffCategory).HasMaxLength(200);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.UserId)
                .HasMaxLength(200)
                .HasColumnName("UserID");
            entity.Property(e => e.UserType).HasMaxLength(200);
        });

        modelBuilder.Entity<Support>(entity =>
        {
            entity.ToTable("Support", "IT");

            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.IsHodreq).HasColumnName("IsHODReq");
            entity.Property(e => e.IsRpmreq).HasColumnName("IsRPMReq");
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.SupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<SupportTeam>(entity =>
        {
            entity.ToTable("SupportTeam", "IT");

            entity.Property(e => e.SupportTeamId).HasColumnName("SupportTeamID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Dol)
                .HasColumnType("datetime")
                .HasColumnName("DOL");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(1000)
                .HasColumnName("First_Name");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("Img_Url");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Role).HasMaxLength(100);
        });

        modelBuilder.Entity<SupportTeamAssgn>(entity =>
        {
            entity.ToTable("SupportTeamAssgn", "IT");

            entity.Property(e => e.SupportTeamAssgnId).HasColumnName("SupportTeamAssgnID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.IsApprover).HasColumnName("isApprover");
            entity.Property(e => e.IsChangeAnalyst).HasColumnName("isChangeAnalyst");
            entity.Property(e => e.IsSuperAdmin).HasColumnName("isSuperAdmin");
            entity.Property(e => e.IsSupportEngineer).HasColumnName("isSupportEngineer");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SupportTeamId).HasColumnName("SupportTeamID");
        });

        modelBuilder.Entity<SysLandscape>(entity =>
        {
            entity.HasKey(e => e.SysLandscapeId).HasName("PK_IT.SysLandscape");

            entity.ToTable("SysLandscape", "IT");

            entity.Property(e => e.SysLandscapeId).HasColumnName("SysLandscapeID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SysLandscape1)
                .HasMaxLength(50)
                .HasColumnName("SysLandscape");

            entity.HasOne(d => d.Category).WithMany(p => p.SysLandscapes)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SysLandscape_Category");

            entity.HasOne(d => d.Classification).WithMany(p => p.SysLandscapes)
                .HasForeignKey(d => d.ClassificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SysLandscape_Classification");
        });

        modelBuilder.Entity<UnitMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Unit_Master", "IT");

            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LocGroup)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.LocHead).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.OutwardMail).HasMaxLength(50);
            entity.Property(e => e.PrintName).HasMaxLength(500);
            entity.Property(e => e.ToMail).HasMaxLength(500);
            entity.Property(e => e.VisitorMail).HasMaxLength(50);
        });

        modelBuilder.Entity<UserVal>(entity =>
        {
            entity.ToTable("UserVal", "IT");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmpNum).HasColumnName("empNum");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.SecurityCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("securityCode");
            entity.Property(e => e.ValCode).HasColumnName("valCode");
        });

        modelBuilder.Entity<ViewProjectGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewProjectGroup", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectGroupId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ProjectGroupID");
            entity.Property(e => e.ProjectGroupName)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwApproverCr>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ApproverCR ", "IT");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.CrrequestorName)
                .HasMaxLength(1502)
                .HasColumnName("CRRequestorName");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented).HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted).HasColumnName("isSubmitted");
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId)
                .HasMaxLength(100)
                .HasColumnName("PlantID");
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Taskcount).HasColumnName("taskcount");
        });

        modelBuilder.Entity<VwApproverView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ApproverView ", "IT");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.CrrequestorName)
                .HasMaxLength(1502)
                .HasColumnName("CRRequestorName");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented).HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted).HasColumnName("isSubmitted");
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.LastApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.LastApprovedId).HasColumnName("LastApprovedID");
            entity.Property(e => e.LastApproverName).HasMaxLength(1202);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId)
                .HasMaxLength(100)
                .HasColumnName("PlantID");
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Taskcount).HasColumnName("taskcount");
        });

        modelBuilder.Entity<VwAssetDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AssetDetails ", "IT");

            entity.Property(e => e.AssetNo).HasColumnName("Asset_No");
            entity.Property(e => e.AssetType)
                .HasMaxLength(50)
                .HasColumnName("Asset_Type");
            entity.Property(e => e.HostName)
                .HasMaxLength(500)
                .HasColumnName("Host_Name");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .HasColumnName("IP_Address");
        });

        modelBuilder.Entity<VwBarchart>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Barchart ", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ClassifcationId).HasColumnName("ClassifcationID");
            entity.Property(e => e.CompletedIdnum).HasColumnName("CompletedIDNum");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.Crmonth).HasColumnName("crmonth");
            entity.Property(e => e.Crowner).HasColumnName("CROwner");
            entity.Property(e => e.Itcrid)
                .ValueGeneratedOnAdd()
                .HasColumnName("ITCRID");
            entity.Property(e => e.NonCompletedIdnum).HasColumnName("NonCompletedIDNum");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
        });

        modelBuilder.Entity<VwCategorytype>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Categorytype", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryType).HasMaxLength(50);
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwChangeRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ChangeRequest ", "IT");

            entity.Property(e => e.AlternateConsidetation)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.BackoutPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Benefits)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.BusinessImpact)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryType).HasMaxLength(50);
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.CrinitiatedFor).HasColumnName("CRInitiatedFor");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.Crownerid).HasColumnName("CROwnerid");
            entity.Property(e => e.Crremail)
                .HasMaxLength(50)
                .HasColumnName("CRREmail");
            entity.Property(e => e.CrremailNotification).HasColumnName("CRREmailNotification");
            entity.Property(e => e.CrrequestedBy).HasColumnName("CRRequestedBy");
            entity.Property(e => e.CrrequestorName)
                .HasMaxLength(1502)
                .HasColumnName("CRRequestorName");
            entity.Property(e => e.DownTimeFromDate).HasColumnType("datetime");
            entity.Property(e => e.DownTimeToDate).HasColumnType("datetime");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Gxpclassification).HasColumnName("GXPClassification");
            entity.Property(e => e.GxpplantId).HasColumnName("GXPPlantID");
            entity.Property(e => e.ImactedFunc).HasMaxLength(50);
            entity.Property(e => e.ImpactNotDoing)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ImpactedDept).HasMaxLength(50);
            entity.Property(e => e.ImpactedLocation).HasMaxLength(50);
            entity.Property(e => e.InitiatedFor).HasMaxLength(1202);
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented).HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted).HasColumnName("isSubmitted");
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.NatureofChange).HasMaxLength(50);
            entity.Property(e => e.PlantId)
                .HasMaxLength(100)
                .HasColumnName("PlantID");
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");
            entity.Property(e => e.RequestorPlant).HasMaxLength(100);
            entity.Property(e => e.RollbackPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SysLandscapeId)
                .HasMaxLength(500)
                .HasColumnName("SysLandscapeID");
            entity.Property(e => e.Taskcount).HasColumnName("taskcount");
            entity.Property(e => e.TriggeredBy)
                .HasMaxLength(2000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwChangeRequestHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ChangeRequestHistory ", "IT");

            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrhistoryDt)
                .HasColumnType("datetime")
                .HasColumnName("CRHistoryDt");
            entity.Property(e => e.CrhistoryId).HasColumnName("CRHistoryID");
            entity.Property(e => e.CrinitiatedFor).HasColumnName("CRInitiatedFor");
            entity.Property(e => e.Crowner).HasColumnName("CROwner");
            entity.Property(e => e.CrrequestedBy).HasColumnName("CRRequestedBy");
            entity.Property(e => e.CrrequestedDt)
                .HasColumnType("datetime")
                .HasColumnName("CRRequestedDt");
            entity.Property(e => e.EventName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.Supptname)
                .HasMaxLength(1202)
                .HasColumnName("supptname");
        });

        modelBuilder.Entity<VwChangeRequestSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ChangeRequestSummary", "IT");

            entity.Property(e => e.AlternateConsidetation)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Attachment).HasMaxLength(200);
            entity.Property(e => e.BackoutPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Benefits)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.BusinessImpact)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryType).HasMaxLength(50);
            entity.Property(e => e.ChangeControlNo).HasMaxLength(50);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Changerequestedby)
                .HasMaxLength(1202)
                .HasColumnName("changerequestedby");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.CrrequestedDt)
                .HasColumnType("datetime")
                .HasColumnName("CRRequestedDt");
            entity.Property(e => e.DownTimeFromDate).HasColumnType("datetime");
            entity.Property(e => e.DownTimeToDate).HasColumnType("datetime");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EstimatedEffortUnit).HasMaxLength(50);
            entity.Property(e => e.Gxpplant)
                .HasMaxLength(100)
                .HasColumnName("gxpplant");
            entity.Property(e => e.ImactedFunc).HasMaxLength(50);
            entity.Property(e => e.ImpactNotDoing)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ImpactedDept).HasMaxLength(50);
            entity.Property(e => e.ImpactedLocation).HasMaxLength(50);
            entity.Property(e => e.InitiatedFor).HasMaxLength(1202);
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.NatureofChange).HasMaxLength(50);
            entity.Property(e => e.PlantId)
                .HasMaxLength(100)
                .HasColumnName("PlantID");
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.ReasonForChange)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceName).HasMaxLength(50);
            entity.Property(e => e.ReferenceType).HasMaxLength(50);
            entity.Property(e => e.RollbackPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.TriggeredBy)
                .HasMaxLength(2000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwChecklist>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Checklist", "IT");

            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.Approvername).HasMaxLength(1101);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChecklistDesc)
                .HasMaxLength(1500)
                .IsUnicode(false);
            entity.Property(e => e.ChecklistTitle)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ItchecklistId).HasColumnName("ITChecklistID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Plantname)
                .HasMaxLength(100)
                .HasColumnName("plantname");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<VwChecklistTemplate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ChecklistTemplate", "IT");

            entity.Property(e => e.ChecklistIds)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("ChecklistIDs");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(1034)
                .HasColumnName("createdByName");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwCrclosure>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CRClosure", "IT");

            entity.Property(e => e.ClosedDt).HasColumnType("datetime");
            entity.Property(e => e.ClosedStatus).HasMaxLength(150);
            entity.Property(e => e.Itcrid)
                .ValueGeneratedOnAdd()
                .HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwCremail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CREmail", "IT");

            entity.Property(e => e.ApprovedByRemarks)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedByStage)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedByStatus)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crapprover11C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover11C");
            entity.Property(e => e.Crapprover11Cdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover11CDesg");
            entity.Property(e => e.Crapprover11Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover11CEmail");
            entity.Property(e => e.Crapprover11CempId).HasColumnName("CRApprover11CEmpID");
            entity.Property(e => e.Crapprover11Crole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover11CRole");
            entity.Property(e => e.Crapprover11N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover11N");
            entity.Property(e => e.Crapprover11Ndesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover11NDesg");
            entity.Property(e => e.Crapprover11Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover11NEmail");
            entity.Property(e => e.Crapprover11NempId).HasColumnName("CRApprover11NEmpID");
            entity.Property(e => e.Crapprover11Nrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover11NRole");
            entity.Property(e => e.Crapprover11R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover11R");
            entity.Property(e => e.Crapprover11Rdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover11RDesg");
            entity.Property(e => e.Crapprover11Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover11REmail");
            entity.Property(e => e.Crapprover11RempId).HasColumnName("CRApprover11REmpID");
            entity.Property(e => e.Crapprover11Rrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover11RRole");
            entity.Property(e => e.Crapprover12C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover12C");
            entity.Property(e => e.Crapprover12Cdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover12CDesg");
            entity.Property(e => e.Crapprover12Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover12CEmail");
            entity.Property(e => e.Crapprover12CempId).HasColumnName("CRApprover12CEmpID");
            entity.Property(e => e.Crapprover12Crole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover12CRole");
            entity.Property(e => e.Crapprover12N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover12N");
            entity.Property(e => e.Crapprover12Ndesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover12NDesg");
            entity.Property(e => e.Crapprover12Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover12NEmail");
            entity.Property(e => e.Crapprover12NempId).HasColumnName("CRApprover12NEmpID");
            entity.Property(e => e.Crapprover12Nrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover12NRole");
            entity.Property(e => e.Crapprover12R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover12R");
            entity.Property(e => e.Crapprover12Rdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover12RDesg");
            entity.Property(e => e.Crapprover12Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover12REmail");
            entity.Property(e => e.Crapprover12RempId).HasColumnName("CRApprover12REmpID");
            entity.Property(e => e.Crapprover12Rrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover12RRole");
            entity.Property(e => e.Crapprover13C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover13C");
            entity.Property(e => e.Crapprover13Cdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover13CDesg");
            entity.Property(e => e.Crapprover13Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover13CEmail");
            entity.Property(e => e.Crapprover13CempId).HasColumnName("CRApprover13CEmpID");
            entity.Property(e => e.Crapprover13Crole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover13CRole");
            entity.Property(e => e.Crapprover13N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover13N");
            entity.Property(e => e.Crapprover13Ndesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover13NDesg");
            entity.Property(e => e.Crapprover13Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover13NEmail");
            entity.Property(e => e.Crapprover13NempId).HasColumnName("CRApprover13NEmpID");
            entity.Property(e => e.Crapprover13Nrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover13NRole");
            entity.Property(e => e.Crapprover13R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover13R");
            entity.Property(e => e.Crapprover13Rdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover13RDesg");
            entity.Property(e => e.Crapprover13Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover13REmail");
            entity.Property(e => e.Crapprover13RempId).HasColumnName("CRApprover13REmpID");
            entity.Property(e => e.Crapprover13Rrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover13RRole");
            entity.Property(e => e.Crapprover21C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover21C");
            entity.Property(e => e.Crapprover21Cdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover21CDesg");
            entity.Property(e => e.Crapprover21Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover21CEmail");
            entity.Property(e => e.Crapprover21CempId).HasColumnName("CRApprover21CEmpID");
            entity.Property(e => e.Crapprover21Crole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover21CRole");
            entity.Property(e => e.Crapprover21N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover21N");
            entity.Property(e => e.Crapprover21Ndesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover21NDesg");
            entity.Property(e => e.Crapprover21Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover21NEmail");
            entity.Property(e => e.Crapprover21NempId).HasColumnName("CRApprover21NEmpID");
            entity.Property(e => e.Crapprover21Nrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover21NRole");
            entity.Property(e => e.Crapprover21R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover21R");
            entity.Property(e => e.Crapprover21Rdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover21RDesg");
            entity.Property(e => e.Crapprover21Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover21REmail");
            entity.Property(e => e.Crapprover21RempId).HasColumnName("CRApprover21REmpID");
            entity.Property(e => e.Crapprover21Rrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover21RRole");
            entity.Property(e => e.Crapprover22C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover22C");
            entity.Property(e => e.Crapprover22Cdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover22CDesg");
            entity.Property(e => e.Crapprover22Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover22CEmail");
            entity.Property(e => e.Crapprover22CempId).HasColumnName("CRApprover22CEmpID");
            entity.Property(e => e.Crapprover22Crole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover22CRole");
            entity.Property(e => e.Crapprover22N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover22N");
            entity.Property(e => e.Crapprover22Ndesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover22NDesg");
            entity.Property(e => e.Crapprover22Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover22NEmail");
            entity.Property(e => e.Crapprover22NempId).HasColumnName("CRApprover22NEmpID");
            entity.Property(e => e.Crapprover22Nrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover22NRole");
            entity.Property(e => e.Crapprover22R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover22R");
            entity.Property(e => e.Crapprover22Rdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover22RDesg");
            entity.Property(e => e.Crapprover22Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover22REmail");
            entity.Property(e => e.Crapprover22RempId).HasColumnName("CRApprover22REmpID");
            entity.Property(e => e.Crapprover22Rrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover22RRole");
            entity.Property(e => e.Crapprover23C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover23C");
            entity.Property(e => e.Crapprover23Cdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover23CDesg");
            entity.Property(e => e.Crapprover23Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover23CEmail");
            entity.Property(e => e.Crapprover23CempId).HasColumnName("CRApprover23CEmpID");
            entity.Property(e => e.Crapprover23Crole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover23CRole");
            entity.Property(e => e.Crapprover23N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover23N");
            entity.Property(e => e.Crapprover23Ndesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover23NDesg");
            entity.Property(e => e.Crapprover23Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover23NEmail");
            entity.Property(e => e.Crapprover23NempId).HasColumnName("CRApprover23NEmpID");
            entity.Property(e => e.Crapprover23Nrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover23NRole");
            entity.Property(e => e.Crapprover23R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover23R");
            entity.Property(e => e.Crapprover23Rdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover23RDesg");
            entity.Property(e => e.Crapprover23Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover23REmail");
            entity.Property(e => e.Crapprover23RempId).HasColumnName("CRApprover23REmpID");
            entity.Property(e => e.Crapprover23Rrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover23RRole");
            entity.Property(e => e.Crapprover31C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover31C");
            entity.Property(e => e.Crapprover31Cdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover31CDesg");
            entity.Property(e => e.Crapprover31Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover31CEmail");
            entity.Property(e => e.Crapprover31CempId).HasColumnName("CRApprover31CEmpID");
            entity.Property(e => e.Crapprover31Crole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover31CRole");
            entity.Property(e => e.Crapprover31N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover31N");
            entity.Property(e => e.Crapprover31Ndesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover31NDesg");
            entity.Property(e => e.Crapprover31Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover31NEmail");
            entity.Property(e => e.Crapprover31NempId).HasColumnName("CRApprover31NEmpID");
            entity.Property(e => e.Crapprover31Nrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover31NRole");
            entity.Property(e => e.Crapprover31R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover31R");
            entity.Property(e => e.Crapprover31Rdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover31RDesg");
            entity.Property(e => e.Crapprover31Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover31REmail");
            entity.Property(e => e.Crapprover31RempId).HasColumnName("CRApprover31REmpID");
            entity.Property(e => e.Crapprover31Rrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover31RRole");
            entity.Property(e => e.Crapprover32C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover32C");
            entity.Property(e => e.Crapprover32Cdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover32CDesg");
            entity.Property(e => e.Crapprover32Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover32CEmail");
            entity.Property(e => e.Crapprover32CempId).HasColumnName("CRApprover32CEmpID");
            entity.Property(e => e.Crapprover32Crole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover32CRole");
            entity.Property(e => e.Crapprover32N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover32N");
            entity.Property(e => e.Crapprover32Ndesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover32NDesg");
            entity.Property(e => e.Crapprover32Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover32NEmail");
            entity.Property(e => e.Crapprover32NempId).HasColumnName("CRApprover32NEmpID");
            entity.Property(e => e.Crapprover32Nrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover32NRole");
            entity.Property(e => e.Crapprover32R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover32R");
            entity.Property(e => e.Crapprover32Rdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover32RDesg");
            entity.Property(e => e.Crapprover32Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover32REmail");
            entity.Property(e => e.Crapprover32RempId).HasColumnName("CRApprover32REmpID");
            entity.Property(e => e.Crapprover32Rrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover32RRole");
            entity.Property(e => e.Crapprover33C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover33C");
            entity.Property(e => e.Crapprover33Cdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover33CDesg");
            entity.Property(e => e.Crapprover33Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover33CEmail");
            entity.Property(e => e.Crapprover33CempId).HasColumnName("CRApprover33CEmpID");
            entity.Property(e => e.Crapprover33Crole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover33CRole");
            entity.Property(e => e.Crapprover33N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover33N");
            entity.Property(e => e.Crapprover33Ndesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover33NDesg");
            entity.Property(e => e.Crapprover33Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover33NEmail");
            entity.Property(e => e.Crapprover33NempId).HasColumnName("CRApprover33NEmpID");
            entity.Property(e => e.Crapprover33Nrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover33NRole");
            entity.Property(e => e.Crapprover33R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover33R");
            entity.Property(e => e.Crapprover33Rdesg)
                .HasMaxLength(100)
                .HasColumnName("CRApprover33RDesg");
            entity.Property(e => e.Crapprover33Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover33REmail");
            entity.Property(e => e.Crapprover33RempId).HasColumnName("CRApprover33REmpID");
            entity.Property(e => e.Crapprover33Rrole)
                .HasMaxLength(100)
                .HasColumnName("CRApprover33RRole");
            entity.Property(e => e.CrapproverBy)
                .HasMaxLength(1202)
                .HasColumnName("CRApproverBy");
            entity.Property(e => e.CrapproverByEmail)
                .HasMaxLength(100)
                .HasColumnName("CRApproverByEmail");
            entity.Property(e => e.CrapproverByEmpId).HasColumnName("CRApproverByEmpID");
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.Cridesignation)
                .HasMaxLength(100)
                .HasColumnName("CRIDesignation");
            entity.Property(e => e.Criemail)
                .HasMaxLength(100)
                .HasColumnName("CRIEmail");
            entity.Property(e => e.Criempid).HasColumnName("CRIEmpid");
            entity.Property(e => e.Crinitiator)
                .HasMaxLength(1202)
                .HasColumnName("CRInitiator");
            entity.Property(e => e.Crirole)
                .HasMaxLength(100)
                .HasColumnName("CRIRole");
            entity.Property(e => e.Crodesignation)
                .HasMaxLength(100)
                .HasColumnName("CRODesignation");
            entity.Property(e => e.Croemail)
                .HasMaxLength(100)
                .HasColumnName("CROEmail");
            entity.Property(e => e.Croempid).HasColumnName("CROEmpid");
            entity.Property(e => e.Crorole)
                .HasMaxLength(100)
                .HasColumnName("CRORole");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.Crrdesignation)
                .HasMaxLength(100)
                .HasColumnName("CRRDesignation");
            entity.Property(e => e.Crremail)
                .HasMaxLength(100)
                .HasColumnName("CRREmail");
            entity.Property(e => e.Crrempid).HasColumnName("CRREmpid");
            entity.Property(e => e.CrrequestedBy)
                .HasMaxLength(1202)
                .HasColumnName("CRRequestedBy");
            entity.Property(e => e.Crrrole)
                .HasMaxLength(100)
                .HasColumnName("CRRRole");
            entity.Property(e => e.Crstatus)
                .HasMaxLength(50)
                .HasColumnName("CRStatus");
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented).HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted).HasColumnName("isSubmitted");
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<VwCrfollowup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CRFollowup", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrfollowupId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CRFollowupID");
            entity.Property(e => e.FollowupDt).HasColumnType("datetime");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwCrlesson>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CRLesson", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrlessonId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CRLessonID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.LessonDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwCrrelease>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CRRelease", "IT");

            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.Attachments).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrreleaseId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CRReleaseID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ReleaseDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<VwCrtaskEmail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CRTaskEmail", "IT");

            entity.Property(e => e.AssgnDesignation).HasMaxLength(100);
            entity.Property(e => e.AssgnEmail).HasMaxLength(100);
            entity.Property(e => e.AssgnRole).HasMaxLength(100);
            entity.Property(e => e.AssignedDt).HasMaxLength(4000);
            entity.Property(e => e.AssignedToName).HasMaxLength(1202);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasMaxLength(4000)
                .HasColumnName("CRDate");
            entity.Property(e => e.Cridesignation)
                .HasMaxLength(100)
                .HasColumnName("CRIDesignation");
            entity.Property(e => e.Criemail)
                .HasMaxLength(100)
                .HasColumnName("CRIEmail");
            entity.Property(e => e.Criempid).HasColumnName("CRIEmpid");
            entity.Property(e => e.Crinitiator)
                .HasMaxLength(1202)
                .HasColumnName("CRInitiator");
            entity.Property(e => e.Crirole)
                .HasMaxLength(100)
                .HasColumnName("CRIRole");
            entity.Property(e => e.Crodesignation)
                .HasMaxLength(100)
                .HasColumnName("CRODesignation");
            entity.Property(e => e.Croemail)
                .HasMaxLength(100)
                .HasColumnName("CROEmail");
            entity.Property(e => e.Croempid).HasColumnName("CROEmpid");
            entity.Property(e => e.Crorole)
                .HasMaxLength(100)
                .HasColumnName("CRORole");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.Crrdesignation)
                .HasMaxLength(100)
                .HasColumnName("CRRDesignation");
            entity.Property(e => e.Crremail)
                .HasMaxLength(100)
                .HasColumnName("CRREmail");
            entity.Property(e => e.Crrempid).HasColumnName("CRREmpid");
            entity.Property(e => e.Crrequestor)
                .HasMaxLength(1202)
                .HasColumnName("CRRequestor");
            entity.Property(e => e.Crrrole)
                .HasMaxLength(100)
                .HasColumnName("CRRRole");
            entity.Property(e => e.Estatus)
                .HasMaxLength(50)
                .HasColumnName("EStatus");
            entity.Property(e => e.ForwardToDesignation).HasMaxLength(100);
            entity.Property(e => e.ForwardToEmail).HasMaxLength(100);
            entity.Property(e => e.ForwardToName).HasMaxLength(1202);
            entity.Property(e => e.ForwardToRole).HasMaxLength(100);
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.PickedDt).HasMaxLength(4000);
            entity.Property(e => e.PickedStatus).HasMaxLength(50);
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.TaskDesc).HasMaxLength(2000);
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
        });

        modelBuilder.Entity<VwCrtemplate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CRTemplate", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrtemplateDtlsId).HasColumnName("CRTemplateDtlsID");
            entity.Property(e => e.CrtemplateId).HasColumnName("CRTemplateID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SysLandscapeId).HasColumnName("SysLandscapeID");
            entity.Property(e => e.TaskDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.TaskName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TemplateName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwEmailGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_EmailGroup", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EmailGroupId).ValueGeneratedOnAdd();
            entity.Property(e => e.EmailGroupName).HasMaxLength(100);
            entity.Property(e => e.MidifiedDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwEmpCategoryMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_EmpCategoryMaster", "IT");

            entity.Property(e => e.Aoemail)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AOEmail");
            entity.Property(e => e.BillingMonth)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CategoryLongText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CategoryShortText)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CostCenter)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Glno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GLNo");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.OfficeEmail)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<VwEmployeeDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_EmployeeDetails", "IT");

            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.DateOfJoining).HasColumnType("datetime");
            entity.Property(e => e.DateOfLeaving).HasColumnType("datetime");
            entity.Property(e => e.Designation).HasMaxLength(500);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.EmployeeName).HasMaxLength(1502);
            entity.Property(e => e.FirstName)
                .HasMaxLength(500)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(500)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(500)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.Plantcode).HasMaxLength(100);
        });

        modelBuilder.Entity<VwExecPlan>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ExecPlan", "IT");

            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.AssignedTo).HasMaxLength(1203);
            entity.Property(e => e.Assignedtoid).HasColumnName("assignedtoid");
            entity.Property(e => e.Attachments).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.DependSyelanscape).HasMaxLength(50);
            entity.Property(e => e.DependTaskId).HasColumnName("DependTaskID");
            entity.Property(e => e.Depndtask)
                .HasMaxLength(500)
                .HasColumnName("depndtask");
            entity.Property(e => e.EndDt)
                .HasColumnType("datetime")
                .HasColumnName("EndDT");
            entity.Property(e => e.ExecutionStepDesc).HasMaxLength(2000);
            entity.Property(e => e.ExecutionStepName).HasMaxLength(500);
            entity.Property(e => e.ForwardedDt).HasColumnType("datetime");
            entity.Property(e => e.ForwardedTo).HasMaxLength(1202);
            entity.Property(e => e.Forwardedtoid).HasColumnName("forwardedtoid");
            entity.Property(e => e.ItcrexecId).HasColumnName("ITCRExecID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PickedDt).HasColumnType("datetime");
            entity.Property(e => e.PickedStatus).HasMaxLength(50);
            entity.Property(e => e.ReasonForwarded).HasMaxLength(500);
            entity.Property(e => e.Remarks).HasMaxLength(2000);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Sylandscape)
                .HasMaxLength(50)
                .HasColumnName("sylandscape");
        });

        modelBuilder.Entity<VwGetSrapprover>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_GetSRApprover", "IT");

            entity.Property(e => e.EmployeeNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.HodEmpId).HasColumnName("hodEmpId");
            entity.Property(e => e.Hodname)
                .HasMaxLength(1502)
                .HasColumnName("HODName");
            entity.Property(e => e.ReportingManagerName).HasMaxLength(1502);
            entity.Property(e => e.RpmEmpId).HasColumnName("rpmEmpId");
        });

        modelBuilder.Entity<VwIssueList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_IssueList", "IT");

            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignedBy).HasMaxLength(1502);
            entity.Property(e => e.AssignedDt).HasColumnType("datetime");
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.AssignedTo).HasMaxLength(1202);
            entity.Property(e => e.Assignedbyid).HasColumnName("assignedbyid");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CategoryType).HasMaxLength(50);
            entity.Property(e => e.ClosedBy).HasMaxLength(1524);
            entity.Property(e => e.ClosedDate).HasColumnType("datetime");
            entity.Property(e => e.ClosedRemark).HasMaxLength(3000);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.GuestCompany).HasMaxLength(500);
            entity.Property(e => e.GuestContactNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GuestEmail).HasMaxLength(50);
            entity.Property(e => e.GuestName).HasMaxLength(50);
            entity.Property(e => e.GuestReportingManagerEmployeeId).HasMaxLength(50);
            entity.Property(e => e.IssueCode).HasMaxLength(50);
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.IssueForGuest)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IssueId).HasColumnName("IssueID");
            entity.Property(e => e.IssueSelectedfor).HasMaxLength(50);
            entity.Property(e => e.IssueShotDesc).HasMaxLength(200);
            entity.Property(e => e.Issuerisedby)
                .HasMaxLength(1001)
                .HasColumnName("issuerisedby");
            entity.Property(e => e.Issuerisedfor)
                .HasMaxLength(1001)
                .HasColumnName("issuerisedfor");
            entity.Property(e => e.Issuerisedforid).HasColumnName("issuerisedforid");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.OnHoldReason).HasMaxLength(1500);
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Plantname)
                .HasMaxLength(100)
                .HasColumnName("plantname");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Priorityid).HasColumnName("priorityid");
            entity.Property(e => e.ProposedResolutionOn).HasColumnType("datetime");
            entity.Property(e => e.Raisedbyid).HasColumnName("raisedbyid");
            entity.Property(e => e.ReasonId).HasColumnName("ReasonID");
            entity.Property(e => e.Remarks)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ResolutionDt).HasColumnType("datetime");
            entity.Property(e => e.ResolutionRemarks).HasMaxLength(3000);
            entity.Property(e => e.ResolveRemarks).HasMaxLength(3000);
            entity.Property(e => e.ResolvedBy).HasMaxLength(1524);
            entity.Property(e => e.ResolvedOn).HasColumnType("datetime");
            entity.Property(e => e.SlaTime).HasColumnName("slaTime");
            entity.Property(e => e.Slastatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("slastatus");
            entity.Property(e => e.Slaunit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("slaunit");
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<VwIssueListHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_IssueListHistory", "IT");

            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignedBy).HasMaxLength(1502);
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.AssignedTo).HasMaxLength(1502);
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CategoryType).HasMaxLength(50);
            entity.Property(e => e.ClosedBy).HasMaxLength(1524);
            entity.Property(e => e.ClosedDate).HasColumnType("datetime");
            entity.Property(e => e.ClosedRemark).HasMaxLength(3000);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.GuestCompany).HasMaxLength(500);
            entity.Property(e => e.IssueCode).HasMaxLength(50);
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.IssueDesc).HasMaxLength(2000);
            entity.Property(e => e.IssueForGuest)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IssueId).HasColumnName("IssueID");
            entity.Property(e => e.IssueRaiseBy).HasMaxLength(1502);
            entity.Property(e => e.IssueRaisedFor).HasMaxLength(1502);
            entity.Property(e => e.IssueShotDesc).HasMaxLength(200);
            entity.Property(e => e.Issuerisedforid).HasColumnName("issuerisedforid");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Plantname).HasMaxLength(100);
            entity.Property(e => e.PriorityName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Priorityid).HasColumnName("priorityid");
            entity.Property(e => e.Remarks).HasMaxLength(3000);
            entity.Property(e => e.ResolveRemarks).HasMaxLength(3000);
            entity.Property(e => e.ResolvedBy).HasMaxLength(1524);
            entity.Property(e => e.ResolvedOn).HasColumnType("datetime");
            entity.Property(e => e.Slastatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("slastatus");
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<VwItassetsDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ITAssetsDetails", "IT");

            entity.Property(e => e.ApproximateInr).HasColumnName("ApproximateINR");
            entity.Property(e => e.AssetCode).HasMaxLength(100);
            entity.Property(e => e.AssetModel).HasMaxLength(500);
            entity.Property(e => e.AssetSerialNo).HasMaxLength(300);
            entity.Property(e => e.AssetsWarrantyEndDt)
                .HasColumnType("datetime")
                .HasColumnName("AssetsWarranty_EndDt");
            entity.Property(e => e.Assettype).HasMaxLength(500);
            entity.Property(e => e.AssignedByName).HasMaxLength(1502);
            entity.Property(e => e.AssignedToName).HasMaxLength(1502);
            entity.Property(e => e.CreatedBy).HasMaxLength(1502);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.EmployeeNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ExistingAsset).HasMaxLength(200);
            entity.Property(e => e.GuestContactNo).HasColumnName("Guest_ContactNo");
            entity.Property(e => e.GuestEmail)
                .HasMaxLength(500)
                .HasColumnName("Guest_Email");
            entity.Property(e => e.GuestId).HasColumnName("Guest_Id");
            entity.Property(e => e.GuestName)
                .HasMaxLength(500)
                .HasColumnName("Guest_Name");
            entity.Property(e => e.GuestReportingManagerEmployeeId).HasColumnName("guestReportingManagerEmployeeId");
            entity.Property(e => e.GuestReportingManagerName)
                .HasMaxLength(1502)
                .HasColumnName("guestReportingManagerName");
            entity.Property(e => e.GxpReq).HasMaxLength(200);
            entity.Property(e => e.HodApproval)
                .HasMaxLength(200)
                .HasColumnName("HOD_Approval");
            entity.Property(e => e.HodApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("HOD_ApprovedDt");
            entity.Property(e => e.HodApproverId).HasColumnName("HOD_ApproverID");
            entity.Property(e => e.HodApproverRemarks).HasColumnName("HOD_ApproverRemarks");
            entity.Property(e => e.HodEmail)
                .HasMaxLength(50)
                .HasColumnName("hodEmail");
            entity.Property(e => e.HodEmpNo).HasColumnName("hodEmpNo");
            entity.Property(e => e.HodToName)
                .HasMaxLength(1034)
                .HasColumnName("hodToName");
            entity.Property(e => e.IsHodreq).HasColumnName("IsHODReq");
            entity.Property(e => e.IsRpmreq).HasColumnName("IsRPMReq");
            entity.Property(e => e.ItassetId).HasColumnName("ITAssetID");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.ModifiedBy).HasMaxLength(1502);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.OnholdReason).HasMaxLength(1500);
            entity.Property(e => e.ProposedResolDt).HasColumnType("datetime");
            entity.Property(e => e.RequestedBy).HasColumnName("RequestedBY");
            entity.Property(e => e.RequestedByName).HasMaxLength(1502);
            entity.Property(e => e.RequestedForName).HasMaxLength(1502);
            entity.Property(e => e.Requesttype).HasMaxLength(200);
            entity.Property(e => e.ResolDt).HasColumnType("datetime");
            entity.Property(e => e.RpmApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("RPM_ApprovedDt");
            entity.Property(e => e.RpmApproverId).HasColumnName("RPM_ApproverID");
            entity.Property(e => e.RpmApproverRemarks).HasColumnName("RPM_ApproverRemarks");
            entity.Property(e => e.RpmEmail)
                .HasMaxLength(50)
                .HasColumnName("rpmEmail");
            entity.Property(e => e.RpmEmpNo).HasColumnName("rpmEmpNO");
            entity.Property(e => e.RpmToName)
                .HasMaxLength(1034)
                .HasColumnName("rpmToName");
            entity.Property(e => e.SpecsRequirements)
                .HasMaxLength(200)
                .HasColumnName("Specs_Requirements");
            entity.Property(e => e.Srselectedfor)
                .HasMaxLength(200)
                .HasColumnName("srselectedfor");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SuggModel).HasMaxLength(200);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UserRemarks).HasMaxLength(200);
        });

        modelBuilder.Entity<VwItassetsHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ITAssetsHistory", "IT");

            entity.Property(e => e.ApproximateInr).HasColumnName("ApproximateINR");
            entity.Property(e => e.AssetCode).HasMaxLength(100);
            entity.Property(e => e.AssetModel).HasMaxLength(500);
            entity.Property(e => e.AssetSerialNo).HasMaxLength(300);
            entity.Property(e => e.AssetsWarrantyEndDt)
                .HasColumnType("datetime")
                .HasColumnName("AssetsWarranty_EndDt");
            entity.Property(e => e.Assettype).HasMaxLength(500);
            entity.Property(e => e.AssignedByName).HasMaxLength(1502);
            entity.Property(e => e.AssignedToName).HasMaxLength(1502);
            entity.Property(e => e.CreatedBy).HasMaxLength(1502);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.ExistingAsset).HasMaxLength(200);
            entity.Property(e => e.GuestContactNo).HasColumnName("Guest_ContactNo");
            entity.Property(e => e.GuestEmail)
                .HasMaxLength(500)
                .HasColumnName("Guest_Email");
            entity.Property(e => e.GuestId).HasColumnName("Guest_Id");
            entity.Property(e => e.GuestName)
                .HasMaxLength(500)
                .HasColumnName("Guest_Name");
            entity.Property(e => e.GuestRmanagerId).HasColumnName("Guest_RManagerId");
            entity.Property(e => e.GuestRmanagerName)
                .HasMaxLength(1502)
                .HasColumnName("Guest_RManagerName");
            entity.Property(e => e.GxpReq).HasMaxLength(200);
            entity.Property(e => e.HodApproval)
                .HasMaxLength(200)
                .HasColumnName("HOD_Approval");
            entity.Property(e => e.HodApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("HOD_ApprovedDt");
            entity.Property(e => e.HodApproverId).HasColumnName("HOD_ApproverID");
            entity.Property(e => e.HodApproverRemarks).HasColumnName("HOD_ApproverRemarks");
            entity.Property(e => e.ItahistoryId).HasColumnName("ITAHistoryID");
            entity.Property(e => e.ItassetId).HasColumnName("ITAssetID");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.ModifiedBy).HasMaxLength(1502);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProposedResolDt).HasColumnType("datetime");
            entity.Property(e => e.RequestedBy).HasColumnName("RequestedBY");
            entity.Property(e => e.RequestedByName).HasMaxLength(1502);
            entity.Property(e => e.RequestedForName).HasMaxLength(1502);
            entity.Property(e => e.Requesttype).HasMaxLength(200);
            entity.Property(e => e.ResolDt).HasColumnType("datetime");
            entity.Property(e => e.RpmApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("RPM_ApprovedDt");
            entity.Property(e => e.RpmApproverId).HasColumnName("RPM_ApproverID");
            entity.Property(e => e.RpmApproverRemarks).HasColumnName("RPM_ApproverRemarks");
            entity.Property(e => e.SelectedFor).HasMaxLength(200);
            entity.Property(e => e.SpecsRequirements)
                .HasMaxLength(200)
                .HasColumnName("Specs_Requirements");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SuggModel).HasMaxLength(200);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.UserRemarks).HasMaxLength(200);
        });

        modelBuilder.Entity<VwItspareDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ITSpareDetails", "IT");

            entity.Property(e => e.AssetType)
                .HasMaxLength(300)
                .HasColumnName("Asset_Type");
            entity.Property(e => e.AssignedByName).HasMaxLength(1502);
            entity.Property(e => e.AssignedToName).HasMaxLength(1502);
            entity.Property(e => e.CreatedBy).HasMaxLength(1502);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.EmployeeNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GuestContactNo).HasColumnName("Guest_ContactNo");
            entity.Property(e => e.GuestEmail)
                .HasMaxLength(500)
                .HasColumnName("Guest_Email");
            entity.Property(e => e.GuestId).HasColumnName("Guest_Id");
            entity.Property(e => e.GuestName)
                .HasMaxLength(500)
                .HasColumnName("Guest_Name");
            entity.Property(e => e.GuestReportingManagerEmployeeId).HasColumnName("guestReportingManagerEmployeeId");
            entity.Property(e => e.GuestReportingManagerName)
                .HasMaxLength(1502)
                .HasColumnName("guestReportingManagerName");
            entity.Property(e => e.GxpReq).HasMaxLength(200);
            entity.Property(e => e.HodApproval)
                .HasMaxLength(500)
                .HasColumnName("HOD_Approval");
            entity.Property(e => e.HodApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("HOD_ApprovedDt");
            entity.Property(e => e.HodApproverId).HasColumnName("HOD_ApproverID");
            entity.Property(e => e.HodApproverRemarks).HasColumnName("HOD_ApproverRemarks");
            entity.Property(e => e.HodEmail)
                .HasMaxLength(50)
                .HasColumnName("hodEmail");
            entity.Property(e => e.HodEmpNo).HasColumnName("hodEmpNo");
            entity.Property(e => e.HodToName)
                .HasMaxLength(1034)
                .HasColumnName("hodToName");
            entity.Property(e => e.IsHodreq).HasColumnName("IsHODReq");
            entity.Property(e => e.IsRpmreq).HasColumnName("IsRPMReq");
            entity.Property(e => e.ItspareCode)
                .HasMaxLength(200)
                .HasColumnName("ITSpareCode");
            entity.Property(e => e.ItspareId).HasColumnName("ITSpareID");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.ModifiedBy).HasMaxLength(1502);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.OnholdReason).HasMaxLength(1500);
            entity.Property(e => e.ProposedResolDt).HasColumnType("datetime");
            entity.Property(e => e.RequestedBy).HasColumnName("RequestedBY");
            entity.Property(e => e.RequestedByName).HasMaxLength(1502);
            entity.Property(e => e.RequestedForName).HasMaxLength(1502);
            entity.Property(e => e.Requesttype).HasMaxLength(500);
            entity.Property(e => e.ResolDt).HasColumnType("datetime");
            entity.Property(e => e.RpmApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("RPM_ApprovedDt");
            entity.Property(e => e.RpmApproverId).HasColumnName("RPM_ApproverID");
            entity.Property(e => e.RpmApproverRemarks).HasColumnName("RPM_ApproverRemarks");
            entity.Property(e => e.RpmEmail)
                .HasMaxLength(50)
                .HasColumnName("rpmEmail");
            entity.Property(e => e.RpmEmpNo).HasColumnName("rpmEmpNO");
            entity.Property(e => e.RpmToName)
                .HasMaxLength(1034)
                .HasColumnName("rpmToName");
            entity.Property(e => e.SpareModel)
                .HasMaxLength(500)
                .HasColumnName("Spare_Model");
            entity.Property(e => e.SpareSerialNo)
                .HasMaxLength(500)
                .HasColumnName("Spare_SerialNo");
            entity.Property(e => e.SpareType)
                .HasMaxLength(500)
                .HasColumnName("Spare_Type");
            entity.Property(e => e.SpecsRequirements)
                .HasMaxLength(500)
                .HasColumnName("Specs_Requirements");
            entity.Property(e => e.Srselectedfor)
                .HasMaxLength(500)
                .HasColumnName("srselectedfor");
            entity.Property(e => e.Status).HasMaxLength(200);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UserRemarks).HasMaxLength(200);
        });

        modelBuilder.Entity<VwItspareHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ItspareHistories", "IT");

            entity.Property(e => e.AssetType)
                .HasMaxLength(300)
                .HasColumnName("Asset_Type");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
            entity.Property(e => e.EmpType).HasMaxLength(200);
            entity.Property(e => e.GuestContactNo).HasColumnName("Guest_ContactNo");
            entity.Property(e => e.GuestEmail)
                .HasMaxLength(500)
                .HasColumnName("Guest_Email");
            entity.Property(e => e.GuestId).HasColumnName("Guest_Id");
            entity.Property(e => e.GuestName)
                .HasMaxLength(500)
                .HasColumnName("Guest_Name");
            entity.Property(e => e.GuestRmanagerId).HasColumnName("Guest_RManagerId");
            entity.Property(e => e.GxpReq).HasMaxLength(200);
            entity.Property(e => e.HodApproval)
                .HasMaxLength(500)
                .HasColumnName("HOD_Approval");
            entity.Property(e => e.HodApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("HOD_ApprovedDt");
            entity.Property(e => e.HodApproverId).HasColumnName("HOD_ApproverID");
            entity.Property(e => e.HodApproverRemarks).HasColumnName("HOD_ApproverRemarks");
            entity.Property(e => e.ItspareCode)
                .HasMaxLength(200)
                .HasColumnName("ITSpareCode");
            entity.Property(e => e.ItspareHid)
                .ValueGeneratedOnAdd()
                .HasColumnName("ITSpareHID");
            entity.Property(e => e.ItspareId).HasColumnName("ITSpareID");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProposedResolDt).HasColumnType("datetime");
            entity.Property(e => e.RequestedBy).HasColumnName("RequestedBY");
            entity.Property(e => e.Requesttype).HasMaxLength(500);
            entity.Property(e => e.ResolDt).HasColumnType("datetime");
            entity.Property(e => e.RpmApprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("RPM_ApprovedDt");
            entity.Property(e => e.RpmApproverId).HasColumnName("RPM_ApproverID");
            entity.Property(e => e.RpmApproverRemarks).HasColumnName("RPM_ApproverRemarks");
            entity.Property(e => e.SelectedFor).HasMaxLength(500);
            entity.Property(e => e.SpareModel)
                .HasMaxLength(500)
                .HasColumnName("Spare_Model");
            entity.Property(e => e.SpareSerialNo)
                .HasMaxLength(500)
                .HasColumnName("Spare_SerialNo");
            entity.Property(e => e.SpareType)
                .HasMaxLength(500)
                .HasColumnName("Spare_Type");
            entity.Property(e => e.SpecsRequirements)
                .HasMaxLength(500)
                .HasColumnName("Specs_Requirements");
            entity.Property(e => e.Status).HasMaxLength(200);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.UserRemarks).HasMaxLength(200);
        });

        modelBuilder.Entity<VwNatureofChange>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_NatureofChange", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NatureofChange).HasMaxLength(50);
            entity.Property(e => e.NatureofChangeId).HasColumnName("NatureofChangeID");
        });

        modelBuilder.Entity<VwPrattachment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Vw_PRAttachment", "IT");

            entity.Property(e => e.AttachId).HasColumnName("AttachID");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(1024)
                .HasColumnName("createdByName");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(500);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PrcheckListId).HasColumnName("PRcheckListId");
            entity.Property(e => e.Prid).HasColumnName("PRID");
            entity.Property(e => e.PrissueId).HasColumnName("PRIssueID");
            entity.Property(e => e.PrmlId).HasColumnName("PRMlID");
            entity.Property(e => e.PrtaskId).HasColumnName("PRTaskID");
            entity.Property(e => e.Stage).HasMaxLength(200);
        });

        modelBuilder.Entity<VwPrlesson>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PRLesson", "IT");

            entity.Property(e => e.Category).HasMaxLength(250);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.LessonsType).HasColumnName("Lessons_Type");
            entity.Property(e => e.MilestoneId).HasColumnName("MilestoneID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PrlessonsId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRLessonsID");
            entity.Property(e => e.ProjCloserAccept)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.TemplateId).HasColumnName("TemplateID");
        });

        modelBuilder.Entity<VwProjectCheckList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProjectCheckList", "IT");

            entity.Property(e => e.CheckListId).HasColumnName("checkListId");
            entity.Property(e => e.CheckListTitle)
                .HasMaxLength(200)
                .HasColumnName("checkListTitle");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.MilestoneTitle).HasMaxLength(500);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectLevel).HasMaxLength(200);
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SubTaskTitle)
                .HasMaxLength(500)
                .HasColumnName("subTaskTitle");
            entity.Property(e => e.TaskTitle).HasMaxLength(500);
        });

        modelBuilder.Entity<VwProjectClosure>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProjectClosure", "IT");

            entity.Property(e => e.Attachment).HasMaxLength(500);
            entity.Property(e => e.Category).HasMaxLength(500);
            entity.Property(e => e.ClosureId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ClosureID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Feedback).HasMaxLength(500);
            entity.Property(e => e.Impact).HasMaxLength(500);
            entity.Property(e => e.LessonsLearnt).HasMaxLength(500);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProblemsStatement).HasMaxLength(500);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Recommendation).HasMaxLength(500);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(500);
            entity.Property(e => e.Task).HasMaxLength(500);
        });

        modelBuilder.Entity<VwProjectIssue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProjectIssue", "IT");

            entity.Property(e => e.AssignByName)
                .HasMaxLength(1525)
                .HasColumnName("assignByName");
            entity.Property(e => e.AssignToName)
                .HasMaxLength(1525)
                .HasColumnName("assignToName");
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.CompletionDate)
                .HasColumnType("datetime")
                .HasColumnName("completionDate");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.DateClosed).HasColumnType("datetime");
            entity.Property(e => e.DateOpened).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Impact).HasMaxLength(200);
            entity.Property(e => e.IssueCode).HasMaxLength(200);
            entity.Property(e => e.IssueId).HasColumnName("issueId");
            entity.Property(e => e.IssueOwnerName).HasMaxLength(1502);
            entity.Property(e => e.MilestoneTitle).HasMaxLength(500);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Notes).HasMaxLength(2000);
            entity.Property(e => e.Priority).HasMaxLength(200);
            entity.Property(e => e.ProjectLevel).HasMaxLength(200);
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasMaxLength(200);
            entity.Property(e => e.SubTaskTitle)
                .HasMaxLength(500)
                .HasColumnName("subTaskTitle");
            entity.Property(e => e.TaskTitle).HasMaxLength(500);
        });

        modelBuilder.Entity<VwProjectMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProjectMembers", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PrMemberId).ValueGeneratedOnAdd();
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.Role).HasMaxLength(500);
            entity.Property(e => e.Type).HasMaxLength(500);
        });

        modelBuilder.Entity<VwProjectMgmt>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProjectMgmt", "IT");

            entity.Property(e => e.ActualCost).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.AdditionalNotes)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(1501)
                .HasColumnName("createdByName");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Deliverables)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.EstimateCost).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectAccess)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProjectCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProjectDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ProjectGroupName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ProjectOwnerName).HasMaxLength(1501);
            entity.Property(e => e.ProjectStatus).HasMaxLength(100);
            entity.Property(e => e.SponserName).HasMaxLength(1501);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<VwProjectMgmtHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProjectMgmtHistory", "IT");

            entity.Property(e => e.Activity).HasMaxLength(500);
            entity.Property(e => e.ActualCost).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.AdditionalNotes)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Deliverables)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.EstimateCost).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.ModifiedByName).HasMaxLength(1502);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProMgmtHistoId).HasColumnName("ProMgmtHistoID");
            entity.Property(e => e.ProjectAccess)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProjectCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProjectDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Sponser)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<VwProjectMilestone>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProjectMilestone", "IT");

            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualFinishEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualFinishStartDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.FinishEndDt).HasColumnType("datetime");
            entity.Property(e => e.FinishStartDt).HasColumnType("datetime");
            entity.Property(e => e.MilestoneDesc).HasMaxLength(2000);
            entity.Property(e => e.MilestoneStatus).HasMaxLength(500);
            entity.Property(e => e.MilestoneTitle).HasMaxLength(500);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Owner).HasColumnName("owner");
            entity.Property(e => e.OwnerName)
                .HasMaxLength(1001)
                .HasColumnName("ownerName");
            entity.Property(e => e.Priority).HasMaxLength(500);
            entity.Property(e => e.ProjMilestoneId).HasColumnName("ProjMilestoneID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(500);
        });

        modelBuilder.Entity<VwProjectTask>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProjectTask", "IT");

            entity.Property(e => e.ActualCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.AssignTo).HasColumnName("assignTo");
            entity.Property(e => e.CompletionDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Dependency)
                .HasMaxLength(500)
                .HasColumnName("dependency");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.MilestoneId).HasColumnName("MilestoneID");
            entity.Property(e => e.MilestoneTitle).HasMaxLength(500);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ParentTaskId).HasColumnName("parentTaskId");
            entity.Property(e => e.ParentTaskTitel)
                .HasMaxLength(500)
                .HasColumnName("parentTaskTitel");
            entity.Property(e => e.PlannedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Projectphase).HasMaxLength(250);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(2000);
            entity.Property(e => e.TaskCode).HasMaxLength(500);
            entity.Property(e => e.TaskDesc).HasMaxLength(2000);
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.TaskPriority).HasMaxLength(2000);
            entity.Property(e => e.TaskTitle).HasMaxLength(500);
            entity.Property(e => e.WorkHours).HasMaxLength(2000);
        });

        modelBuilder.Entity<VwPrtemplate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PRTemplate", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CreatedName).HasMaxLength(1502);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PrtemplateId).HasColumnName("PRTemplateID");
            entity.Property(e => e.TemplateName).HasMaxLength(300);
        });

        modelBuilder.Entity<VwPrtemplateDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PRTemplateDetails", "IT");

            entity.Property(e => e.Category).HasMaxLength(2000);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.LessonLearnedId).HasColumnName("LessonLearnedID");
            entity.Property(e => e.MilestoneId).HasColumnName("MilestoneID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PrtemplateDtlsId).HasColumnName("PRTemplateDtlsID");
            entity.Property(e => e.PrtemplateId).HasColumnName("PRTemplateID");
            entity.Property(e => e.Task).HasMaxLength(3000);
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.TemplateDtlsId).HasColumnName("TemplateDtlsID");
            entity.Property(e => e.TemplateId).HasColumnName("TemplateID");
            entity.Property(e => e.Trid).HasColumnName("TRID");
        });

        modelBuilder.Entity<VwReference>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Reference", "IT");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ReferenceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ReferenceID");
            entity.Property(e => e.ReferenceName).HasMaxLength(50);
        });

        modelBuilder.Entity<VwReferenceType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ReferenceType", "IT");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ReferenceType).HasMaxLength(50);
            entity.Property(e => e.ReferenceTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ReferenceTypeID");
        });

        modelBuilder.Entity<VwRptapproverView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_RPTApproverView ", "IT");

            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.CrrequestorName)
                .HasMaxLength(1502)
                .HasColumnName("CRRequestorName");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented).HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted).HasColumnName("isSubmitted");
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId)
                .HasMaxLength(100)
                .HasColumnName("PlantID");
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Taskcount).HasColumnName("taskcount");
        });

        modelBuilder.Entity<VwRptcrexecPlan>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_RPTCRExecPlan", "IT");

            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.AssignedTo).HasMaxLength(1101);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryType).HasMaxLength(50);
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1000)
                .HasColumnName("CROwner");
            entity.Property(e => e.DependSyelanscape).HasMaxLength(50);
            entity.Property(e => e.Depndtask)
                .HasMaxLength(2000)
                .HasColumnName("depndtask");
            entity.Property(e => e.EndDt)
                .HasColumnType("datetime")
                .HasColumnName("EndDT");
            entity.Property(e => e.ForwardedTo).HasMaxLength(1101);
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.NatureofChange).HasMaxLength(50);
            entity.Property(e => e.PlantId).HasColumnName("plantId");
            entity.Property(e => e.Plantstartdate)
                .HasColumnType("datetime")
                .HasColumnName("plantstartdate");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Supportname).HasMaxLength(1101);
            entity.Property(e => e.SysLandscape).HasMaxLength(50);
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
        });

        modelBuilder.Entity<VwRptcrmilestone>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_RPTCRMilestone", "IT");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryType).HasMaxLength(50);
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClosedDt).HasColumnType("datetime");
            entity.Property(e => e.ColApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.ColApproverLevel1Dt).HasColumnType("datetime");
            entity.Property(e => e.ColApproverLevel2Dt).HasColumnType("datetime");
            entity.Property(e => e.Colapp1).HasColumnName("colapp1");
            entity.Property(e => e.Colapp1name)
                .HasMaxLength(1202)
                .HasColumnName("colapp1name");
            entity.Property(e => e.Colapp2).HasColumnName("colapp2");
            entity.Property(e => e.Colapp2name)
                .HasMaxLength(1202)
                .HasColumnName("colapp2name");
            entity.Property(e => e.Colappname)
                .HasMaxLength(1202)
                .HasColumnName("colappname");
            entity.Property(e => e.Colappved).HasColumnName("colappved");
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrinitiatedFor).HasColumnName("CRInitiatedFor");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.Crownerid).HasColumnName("CROwnerid");
            entity.Property(e => e.CrrequestedBy).HasColumnName("CRRequestedBy");
            entity.Property(e => e.CrrequestorName)
                .HasMaxLength(1502)
                .HasColumnName("CRRequestorName");
            entity.Property(e => e.DraftDt).HasColumnType("datetime");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ImplementedDt).HasColumnType("datetime");
            entity.Property(e => e.InitiatedFor).HasMaxLength(1202);
            entity.Property(e => e.IsImplemented).HasColumnName("isImplemented");
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.NatureofChange).HasMaxLength(50);
            entity.Property(e => e.PlantId)
                .HasMaxLength(100)
                .HasColumnName("PlantID");
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RelApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.RelApproverLevel1Dt).HasColumnType("datetime");
            entity.Property(e => e.RelApproverLevel2Dt).HasColumnType("datetime");
            entity.Property(e => e.Relapp1).HasColumnName("relapp1");
            entity.Property(e => e.Relapp1name)
                .HasMaxLength(1202)
                .HasColumnName("relapp1name");
            entity.Property(e => e.Relapp2).HasColumnName("relapp2");
            entity.Property(e => e.Relapp2name)
                .HasMaxLength(1202)
                .HasColumnName("relapp2name");
            entity.Property(e => e.Relappname)
                .HasMaxLength(1202)
                .HasColumnName("relappname");
            entity.Property(e => e.Relappved).HasColumnName("relappved");
            entity.Property(e => e.ReleasedDt).HasColumnType("datetime");
            entity.Property(e => e.Rfcapp1).HasColumnName("rfcapp1");
            entity.Property(e => e.Rfcapp1name)
                .HasMaxLength(1202)
                .HasColumnName("rfcapp1name");
            entity.Property(e => e.Rfcapp2).HasColumnName("rfcapp2");
            entity.Property(e => e.Rfcapp2name)
                .HasMaxLength(1202)
                .HasColumnName("rfcapp2name");
            entity.Property(e => e.Rfcappname)
                .HasMaxLength(1202)
                .HasColumnName("rfcappname");
            entity.Property(e => e.RfcapprovedDt)
                .HasColumnType("datetime")
                .HasColumnName("RFCApprovedDt");
            entity.Property(e => e.RfcapproverLevel1Dt)
                .HasColumnType("datetime")
                .HasColumnName("RFCApproverLevel1Dt");
            entity.Property(e => e.RfcapproverLevel2Dt)
                .HasColumnType("datetime")
                .HasColumnName("RFCApproverLevel2Dt");
            entity.Property(e => e.Rfcappved).HasColumnName("rfcappved");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SubmittedDt).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<VwServiceMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ServiceMaster", "IT");

            entity.Property(e => e.AppSatus)
                .HasMaxLength(500)
                .HasColumnName("app_satus");
            entity.Property(e => e.AppValue)
                .HasMaxLength(500)
                .HasColumnName("app_value");
            entity.Property(e => e.ApprovalReamarks)
                .IsUnicode(false)
                .HasColumnName("Approval_Reamarks");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Approval_Status");
            entity.Property(e => e.ApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("approve_date");
            entity.Property(e => e.ApprovedBy).HasColumnName("Approved_By");
            entity.Property(e => e.ApprovedOn)
                .HasColumnType("datetime")
                .HasColumnName("Approved_On");
            entity.Property(e => e.Attachment)
                .HasMaxLength(500)
                .HasColumnName("attachment");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.DetailedDesc)
                .HasMaxLength(500)
                .HasColumnName("detailed_desc");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Justification).HasColumnName("justification");
            entity.Property(e => e.LastApprover)
                .HasMaxLength(100)
                .HasColumnName("last_approver");
            entity.Property(e => e.MachineName)
                .HasMaxLength(500)
                .HasColumnName("machine_name");
            entity.Property(e => e.ModifiedDt).HasMaxLength(50);
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(100)
                .HasColumnName("pending_approver");
            entity.Property(e => e.PlantCode)
                .HasMaxLength(5)
                .HasColumnName("plant_code");
            entity.Property(e => e.PurchaseGroup)
                .HasMaxLength(500)
                .HasColumnName("purchase_group");
            entity.Property(e => e.Purpose)
                .HasMaxLength(500)
                .HasColumnName("purpose");
            entity.Property(e => e.RejectedFlag)
                .HasMaxLength(50)
                .HasColumnName("rejected_flag");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("request_date");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("request_no");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(500)
                .HasColumnName("requested_by");
            entity.Property(e => e.ResolutionBy).HasColumnName("Resolution_By");
            entity.Property(e => e.ResolutionOn)
                .HasColumnType("datetime")
                .HasColumnName("Resolution_On");
            entity.Property(e => e.ResolutionReamarks)
                .IsUnicode(false)
                .HasColumnName("Resolution_Reamarks");
            entity.Property(e => e.ResolutionStatus)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Resolution_Status");
            entity.Property(e => e.SacCode)
                .HasMaxLength(50)
                .HasColumnName("SAC_Code");
            entity.Property(e => e.SapCodeExists)
                .HasMaxLength(50)
                .HasColumnName("SAP_CODE_EXISTS");
            entity.Property(e => e.SapCodeNo)
                .HasMaxLength(100)
                .HasColumnName("SAP_CODE_NO");
            entity.Property(e => e.SapCreatedBy).HasColumnName("SAP_CreatedBy");
            entity.Property(e => e.SapCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_CREATION_DATE");
            entity.Property(e => e.ServiceCatagory)
                .HasMaxLength(500)
                .HasColumnName("service_catagory");
            entity.Property(e => e.ServiceDescription).HasColumnName("service_description");
            entity.Property(e => e.ServiceGroup)
                .HasMaxLength(500)
                .HasColumnName("service_group");
            entity.Property(e => e.SrModuleId).HasColumnName("Sr_Module_ID");
            entity.Property(e => e.SrNumber)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Sr_number");
            entity.Property(e => e.StorageLocation)
                .HasMaxLength(500)
                .HasColumnName("storage_location");
            entity.Property(e => e.Uom)
                .HasMaxLength(500)
                .HasColumnName("uom");
            entity.Property(e => e.ValuationClass)
                .HasMaxLength(500)
                .HasColumnName("valuation_class");
            entity.Property(e => e.WhereUsed)
                .HasMaxLength(500)
                .HasColumnName("where_used");
        });

        modelBuilder.Entity<VwServiceRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ServiceRequest", "IT");

            entity.Property(e => e.ApprovedBy).HasMaxLength(200);
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.Approverstage).HasMaxLength(200);
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignToName).HasMaxLength(1034);
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedBy).HasMaxLength(1034);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.GuestCompany).HasMaxLength(500);
            entity.Property(e => e.GuestContactNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GuestEmail).HasMaxLength(50);
            entity.Property(e => e.GuestName).HasMaxLength(50);
            entity.Property(e => e.GuestReportingManagerEmployeeId).HasMaxLength(50);
            entity.Property(e => e.GuestReportingManagerName).HasMaxLength(1002);
            entity.Property(e => e.HodEmail)
                .HasMaxLength(50)
                .HasColumnName("hodEmail");
            entity.Property(e => e.HodEmpNo).HasColumnName("hodEmpNo");
            entity.Property(e => e.HodToName)
                .HasMaxLength(1034)
                .HasColumnName("hodToName");
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsHodreq).HasColumnName("IsHODReq");
            entity.Property(e => e.IsRpmreq).HasColumnName("IsRPMReq");
            entity.Property(e => e.ModifiedBy).HasMaxLength(1034);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.OnholdReason).HasMaxLength(1500);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.ParentSupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ProposedResolutionOn).HasColumnType("datetime");
            entity.Property(e => e.RaiseforId).HasColumnName("raiseforId");
            entity.Property(e => e.RpmEmail)
                .HasMaxLength(50)
                .HasColumnName("rpmEmail");
            entity.Property(e => e.RpmEmpNo).HasColumnName("rpmEmpNO");
            entity.Property(e => e.RpmToName)
                .HasMaxLength(1034)
                .HasColumnName("rpmToName");
            entity.Property(e => e.ServiceId).HasColumnName("serviceId");
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Srcode)
                .HasMaxLength(50)
                .HasColumnName("SRCode");
            entity.Property(e => e.Srdate)
                .HasColumnType("datetime")
                .HasColumnName("SRDate");
            entity.Property(e => e.Srdesc)
                .HasMaxLength(2000)
                .HasColumnName("SRDesc");
            entity.Property(e => e.SrforGuest)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SRForGuest");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SrraiseBy)
                .HasMaxLength(1535)
                .HasColumnName("SRRaiseBy");
            entity.Property(e => e.SrraiseFor)
                .HasMaxLength(1535)
                .HasColumnName("SRRaiseFor");
            entity.Property(e => e.SrraiseForId).HasColumnName("SRRaiseForId");
            entity.Property(e => e.SrraisedByEmail)
                .HasMaxLength(50)
                .HasColumnName("SRRaisedByEmail");
            entity.Property(e => e.SrraisedById).HasColumnName("SRRaisedById");
            entity.Property(e => e.SrraisedForEmail)
                .HasMaxLength(50)
                .HasColumnName("SRRaisedForEmail");
            entity.Property(e => e.Srselectedfor)
                .HasMaxLength(50)
                .HasColumnName("SRSelectedfor");
            entity.Property(e => e.SrshotDesc)
                .HasMaxLength(200)
                .HasColumnName("SRShotDesc");
            entity.Property(e => e.Stage).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SupportCreatedDate).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SupportUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<VwSoftwareLibrary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SoftwareLibrary", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SoftwareLibraryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SoftwareLibraryID");
            entity.Property(e => e.SoftwareName)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwSoftwareVersion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SoftwareVersion", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SoftVersionId).HasColumnName("SoftVersionID");
            entity.Property(e => e.SoftVersionName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.SoftwareLibraryId).HasColumnName("SoftwareLibraryID");
            entity.Property(e => e.SoftwareName)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("softwareName");
        });

        modelBuilder.Entity<VwSrapprovedDat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SRApprovedDat", "IT");

            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.Attachment)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CreatedByEmail).HasMaxLength(50);
            entity.Property(e => e.CreatedByName).HasMaxLength(1001);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.SrapproverId).HasColumnName("SRApproverID");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Stage)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SupportId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SupportID");
        });

        modelBuilder.Entity<VwSrattachment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SRAttachment", "IT");

            entity.Property(e => e.AttachId)
                .ValueGeneratedOnAdd()
                .HasColumnName("AttachID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(500);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Stage).HasMaxLength(200);
        });

        modelBuilder.Entity<VwSrcommonHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SRCommonHistory", "IT");

            entity.Property(e => e.ApprRemarks)
                .IsUnicode(false)
                .HasColumnName("apprRemarks");
            entity.Property(e => e.CreatedByName).HasMaxLength(1503);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.ModifiedByName).HasMaxLength(1503);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Srcode)
                .HasMaxLength(50)
                .HasColumnName("SRCode");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SrresolHistoryId).HasColumnName("SRResolHistoryID");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UserRemarks).HasMaxLength(200);
        });

        modelBuilder.Entity<VwSrdomain>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SRDomain", "IT");

            entity.Property(e => e.ApprovedBy).HasMaxLength(200);
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.Approverstage).HasMaxLength(200);
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.DiscontinuationDate).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.GuestCompany).HasMaxLength(500);
            entity.Property(e => e.GuestContactNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GuestEmail).HasMaxLength(50);
            entity.Property(e => e.GuestName).HasMaxLength(50);
            entity.Property(e => e.GuestReportingManagerEmployeeId).HasMaxLength(50);
            entity.Property(e => e.GuestReportingManagerName).HasMaxLength(1002);
            entity.Property(e => e.HodEmail)
                .HasMaxLength(50)
                .HasColumnName("hodEmail");
            entity.Property(e => e.HodEmpNo).HasColumnName("hodEmpNo");
            entity.Property(e => e.HodToName)
                .HasMaxLength(1034)
                .HasColumnName("hodToName");
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsHodreq).HasColumnName("IsHODReq");
            entity.Property(e => e.IsRpmreq).HasColumnName("IsRPMReq");
            entity.Property(e => e.Justification).HasMaxLength(250);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Plant).HasMaxLength(200);
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ProposedResolutionOn).HasColumnType("datetime");
            entity.Property(e => e.PurPoseDomain).HasMaxLength(200);
            entity.Property(e => e.ReqDomainName).HasMaxLength(200);
            entity.Property(e => e.RpmEmail)
                .HasMaxLength(50)
                .HasColumnName("rpmEmail");
            entity.Property(e => e.RpmEmpNo).HasColumnName("rpmEmpNo");
            entity.Property(e => e.RpmToName)
                .HasMaxLength(1034)
                .HasColumnName("rpmToName");
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.SrCreatedBy)
                .HasMaxLength(1034)
                .HasColumnName("SR_CreatedBy");
            entity.Property(e => e.SrCreatedDt)
                .HasColumnType("datetime")
                .HasColumnName("SR_CreatedDt");
            entity.Property(e => e.SrModifiedBy)
                .HasMaxLength(1034)
                .HasColumnName("SR_ModifiedBy");
            entity.Property(e => e.SrModifiedDt)
                .HasColumnType("datetime")
                .HasColumnName("SR_ModifiedDt");
            entity.Property(e => e.Srcode)
                .HasMaxLength(50)
                .HasColumnName("SRCode");
            entity.Property(e => e.Srdate)
                .HasColumnType("datetime")
                .HasColumnName("SRDate");
            entity.Property(e => e.Srdesc)
                .HasMaxLength(2000)
                .HasColumnName("SRDesc");
            entity.Property(e => e.SrdomainId).HasColumnName("SRDomainID");
            entity.Property(e => e.SrforGuest)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SRForGuest");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SridServiceRequest).HasColumnName("SRID_ServiceRequest");
            entity.Property(e => e.SrraiseBy)
                .HasMaxLength(1535)
                .HasColumnName("SRRaiseBy");
            entity.Property(e => e.SrraiseFor)
                .HasMaxLength(1535)
                .HasColumnName("SRRaiseFor");
            entity.Property(e => e.Srselectedfor)
                .HasMaxLength(50)
                .HasColumnName("SRSelectedfor");
            entity.Property(e => e.SrshotDesc)
                .HasMaxLength(200)
                .HasColumnName("SRShotDesc");
            entity.Property(e => e.Stage).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.TypeofSsl)
                .HasMaxLength(250)
                .HasColumnName("TypeofSSL");
        });

        modelBuilder.Entity<VwSrhistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SRHistory", "IT");

            entity.Property(e => e.Amcappilcable).HasColumnName("AMCAppilcable");
            entity.Property(e => e.CostForAmc)
                .HasMaxLength(200)
                .HasColumnName("CostForAMC");
            entity.Property(e => e.CostPerLicence).HasMaxLength(200);
            entity.Property(e => e.CreatedByName).HasMaxLength(1503);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CurrVersion).HasMaxLength(200);
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.DtlsOfDev).HasMaxLength(200);
            entity.Property(e => e.DtlsOfinstDt).HasColumnType("datetime");
            entity.Property(e => e.InstCharge).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.InstType).HasMaxLength(200);
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.LicenceType).HasMaxLength(200);
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.ModifiedByName).HasMaxLength(1503);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.NoOfLicence).HasMaxLength(200);
            entity.Property(e => e.NoOfUers).HasMaxLength(200);
            entity.Property(e => e.ScopeOfAmc)
                .HasMaxLength(200)
                .HasColumnName("ScopeOfAMC");
            entity.Property(e => e.SoftwareName).HasMaxLength(200);
            entity.Property(e => e.SoftwareType).HasMaxLength(20);
            entity.Property(e => e.SoftwareVersionName).HasMaxLength(200);
            entity.Property(e => e.Srcode)
                .HasMaxLength(50)
                .HasColumnName("SRCode");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Swhid).HasColumnName("SWHID");
            entity.Property(e => e.TareVersion).HasMaxLength(200);
            entity.Property(e => e.TypeOfDev).HasMaxLength(200);
            entity.Property(e => e.TypeOfWeb).HasMaxLength(200);
            entity.Property(e => e.UsageBy).HasColumnName("UsageBY");
            entity.Property(e => e.UserAccessFrom).HasMaxLength(200);
            entity.Property(e => e.VendorName).HasMaxLength(200);
        });

        modelBuilder.Entity<VwSrresolution>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SRResolution", "IT");

            entity.Property(e => e.CreatedByName).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.OnHoldReason).HasMaxLength(200);
            entity.Property(e => e.ProposedResolDt).HasColumnType("datetime");
            entity.Property(e => e.ResolDt).HasColumnType("datetime");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SrresolId).HasColumnName("SRResolID");
            entity.Property(e => e.UserRemarks).HasMaxLength(200);
        });

        modelBuilder.Entity<VwSrsosftware>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SRSosftware", "IT");

            entity.Property(e => e.Amcappilcable).HasColumnName("AMCAppilcable");
            entity.Property(e => e.ApprovedBy).HasMaxLength(200);
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.Approverstage).HasMaxLength(200);
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CostForAmc)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("CostForAMC");
            entity.Property(e => e.CostPerLicence).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CurrVersion).HasMaxLength(200);
            entity.Property(e => e.Department).HasMaxLength(200);
            entity.Property(e => e.DtlsOfDev).HasMaxLength(200);
            entity.Property(e => e.DtlsOfinstDt).HasColumnType("datetime");
            entity.Property(e => e.GuestCompany).HasMaxLength(500);
            entity.Property(e => e.GuestContactNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GuestEmail).HasMaxLength(50);
            entity.Property(e => e.GuestName).HasMaxLength(50);
            entity.Property(e => e.GuestReportingManagerEmployeeId).HasMaxLength(50);
            entity.Property(e => e.GuestReportingManagerName).HasMaxLength(1002);
            entity.Property(e => e.HodEmail)
                .HasMaxLength(50)
                .HasColumnName("hodEmail");
            entity.Property(e => e.HodEmpNo).HasColumnName("hodEmpNo");
            entity.Property(e => e.HodToName)
                .HasMaxLength(1034)
                .HasColumnName("hodToName");
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.InstCharge).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.InstType).HasMaxLength(200);
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsHodreq).HasColumnName("IsHODReq");
            entity.Property(e => e.IsRpmreq).HasColumnName("IsRPMReq");
            entity.Property(e => e.Justification).HasMaxLength(200);
            entity.Property(e => e.LicenceType).HasMaxLength(200);
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.ParentSupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ProposedResolutionOn).HasColumnType("datetime");
            entity.Property(e => e.RaiseforId).HasColumnName("raiseforId");
            entity.Property(e => e.RpmEmail)
                .HasMaxLength(50)
                .HasColumnName("rpmEmail");
            entity.Property(e => e.RpmEmpNo).HasColumnName("rpmEmpNO");
            entity.Property(e => e.RpmToName)
                .HasMaxLength(1034)
                .HasColumnName("rpmToName");
            entity.Property(e => e.ScopeOfAmc)
                .HasMaxLength(2000)
                .HasColumnName("ScopeOfAMC");
            entity.Property(e => e.SoftwareType).HasMaxLength(20);
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Srcode)
                .HasMaxLength(50)
                .HasColumnName("SRCode");
            entity.Property(e => e.Srdate)
                .HasColumnType("datetime")
                .HasColumnName("SRDate");
            entity.Property(e => e.Srdesc)
                .HasMaxLength(2000)
                .HasColumnName("SRDesc");
            entity.Property(e => e.SrforGuest)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SRForGuest");
            entity.Property(e => e.Srid).HasColumnName("SRID");
            entity.Property(e => e.SrraiseBy)
                .HasMaxLength(1535)
                .HasColumnName("SRRaiseBy");
            entity.Property(e => e.SrraiseFor)
                .HasMaxLength(1535)
                .HasColumnName("SRRaiseFor");
            entity.Property(e => e.SrraisedByEmail)
                .HasMaxLength(50)
                .HasColumnName("SRRaisedByEmail");
            entity.Property(e => e.SrraisedById).HasColumnName("SRRaisedById");
            entity.Property(e => e.SrraisedForEmail)
                .HasMaxLength(50)
                .HasColumnName("SRRaisedForEmail");
            entity.Property(e => e.Srselectedfor)
                .HasMaxLength(50)
                .HasColumnName("SRSelectedfor");
            entity.Property(e => e.SrshotDesc)
                .HasMaxLength(200)
                .HasColumnName("SRShotDesc");
            entity.Property(e => e.Stage).HasMaxLength(200);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SupportCreatedDate).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SupportUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Swid).HasColumnName("SWID");
            entity.Property(e => e.TareVersion).HasMaxLength(200);
            entity.Property(e => e.TotalCost).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.TypeOfDev).HasMaxLength(200);
            entity.Property(e => e.TypeOfWeb).HasMaxLength(200);
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("URL");
            entity.Property(e => e.UsageBy).HasColumnName("UsageBY");
            entity.Property(e => e.UserAccessFrom).HasMaxLength(200);
            entity.Property(e => e.VendorName).HasMaxLength(200);
        });

        modelBuilder.Entity<VwSupportEngineer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SupportEngineer ", "IT");

            entity.Property(e => e.Assgigntome).HasColumnName("assgigntome");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.CrrequestedBy).HasColumnName("CRRequestedBy");
            entity.Property(e => e.CrrequestorName)
                .HasMaxLength(1502)
                .HasColumnName("CRRequestorName");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented).HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted).HasColumnName("isSubmitted");
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.ItcrexecId).HasColumnName("ITCRExecID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId)
                .HasMaxLength(100)
                .HasColumnName("PlantID");
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Taskcount).HasColumnName("taskcount");
            entity.Property(e => e.Taskstatus).HasMaxLength(50);
        });

        modelBuilder.Entity<VwSupportTeamAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SupportTeamAll ", "IT");

            entity.Property(e => e.Approverstage).HasMaxLength(50);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CategoryType).HasMaxLength(50);
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Dol)
                .HasColumnType("datetime")
                .HasColumnName("DOL");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(1000)
                .HasColumnName("First_Name");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("Img_Url");
            entity.Property(e => e.IsApprover).HasColumnName("isApprover");
            entity.Property(e => e.IsSuperAdmin).HasColumnName("isSuperAdmin");
            entity.Property(e => e.Isadmin).HasColumnName("isadmin");
            entity.Property(e => e.Ischangeanalyst).HasColumnName("ischangeanalyst");
            entity.Property(e => e.Issupportengineer).HasColumnName("issupportengineer");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SupportTeamAssgnId).HasColumnName("SupportTeamAssgnID");
            entity.Property(e => e.SupportTeamId).HasColumnName("SupportTeamID");
        });

        modelBuilder.Entity<VwSupportTeamDtl>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SupportTeamDtls ", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryType).HasMaxLength(50);
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Dol)
                .HasColumnType("datetime")
                .HasColumnName("DOL");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(1000)
                .HasColumnName("First_Name");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("Img_Url");
            entity.Property(e => e.IsApprover).HasColumnName("isApprover");
            entity.Property(e => e.IsSuperAdmin).HasColumnName("isSuperAdmin");
            entity.Property(e => e.Isadmin).HasColumnName("isadmin");
            entity.Property(e => e.Ischangeanalyst).HasColumnName("ischangeanalyst");
            entity.Property(e => e.Issupportengineer).HasColumnName("issupportengineer");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Role).HasMaxLength(100);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SupportTeamAssgnId).HasColumnName("SupportTeamAssgnID");
            entity.Property(e => e.SupportTeamId).HasColumnName("SupportTeamID");
        });

        modelBuilder.Entity<VwSystemlandscape>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Systemlandscape", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SysLandscape).HasMaxLength(50);
            entity.Property(e => e.SysLandscapeId).HasColumnName("SysLandscapeID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
