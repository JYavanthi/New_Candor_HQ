import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ChangeRequestComponent } from './change-request/change-request.component';
import { NewChangeRequestComponent } from './change-request/new-change-request/new-change-request.component';
import { ApproveComponent } from './change-request/approve/approve.component';
import { CrTaskComponent } from './change-request/execute/cr-task/cr-task.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HelpdeskComponent } from './helpdesk/helpdesk.component';
import { MasterSupportComponent } from './master-support/master-support.component';
import { ReportIssueComponent } from './helpdesk/report-issue/report-issue.component';
import { ReportsComponent } from './helpdesk/reports/reports.component';
import { ServiceComponent } from './helpdesk/service/service.component';
import { ItAssetsComponent } from './helpdesk/it-assets/it-assets.component';
import { IssueResolutionComponent } from './helpdesk/report-issue/issue-resolution/issue-resolution.component';
import { IssueReportComponent } from './helpdesk/report-issue/issue-report/issue-report.component';
import { IssueNewIssueComponent } from './helpdesk/report-issue/issue-new-issue/issue-new-issue.component';
import { ChangeRequestReportComponent } from './change-request/change-request-report/change-request-report.component';
import { ViewChangeComponent } from './change-request/change-request-report/view-change/view-change.component';
import { ViewTaskComponent } from './change-request/change-request-report/view-task/view-task.component';
import { ViewSummaryComponent } from './change-request/change-request-report/view-summary/view-summary.component';
import { HistoryComponent } from './change-request/history/history.component';
import { SoftwareServiceComponent } from './helpdesk/service/software-service/software-service.component';
import { DomainServiceComponent } from './helpdesk/service/domain-service/domain-service.component';
import { EmailServiceComponent } from './helpdesk/service/email-service/email-service.component';
import { ExternalDriveAcessServiceComponent } from './helpdesk/service/external-drive-acess-service/external-drive-acess-service.component';
import { FtpAccessServiceComponent } from './helpdesk/service/ftp-access-service/ftp-access-service.component';
import { UsbAccessServiceComponent } from './helpdesk/service/usb-access-service/usb-access-service.component';
import { WindowsLoginServiceComponent } from './helpdesk/service/windows-login-service/windows-login-service.component';
import { CitrixAccessServiceComponent } from './helpdesk/service/citrix-access-service/citrix-access-service.component';
import { VpnAccessServiceComponent } from './helpdesk/service/vpn-access-service/vpn-access-service.component';
import { InternetAccessServiceComponent } from './helpdesk/service/internet-access-service/internet-access-service.component';
import { WifiAccessServiceComponent } from './helpdesk/service/wifi-access-service/wifi-access-service.component';
import { AccessFolderServiceComponent } from './helpdesk/service/access-folder-service/access-folder-service.component';
import { BackupRestorationServiceComponent } from './helpdesk/service/backup-restoration-service/backup-restoration-service.component';
import { RemoteAccessServiceComponent } from './helpdesk/service/remote-access-service/remote-access-service.component';
import { AntivirusServiceComponent } from './helpdesk/service/antivirus-service/antivirus-service.component';
import { VirtualmeetServiceComponent } from './helpdesk/service/virtualmeet-service/virtualmeet-service.component';
import { ItspareComponent } from './helpdesk/it-assets/itspare/itspare.component';
import { ConsumeableComponent } from './helpdesk/it-assets/consumeable/consumeable.component';
import { AssetComponent } from './helpdesk/it-assets/asset/asset.component';
import { UpdatechangerequestComponent } from './change-request/new-change-request/updatechangerequest/updatechangerequest.component';
import { UpdateCrtaskComponent } from './change-request/execute/cr-task/update-crtask/update-crtask.component';
import { ChangerequestMasterComponent } from './master-support/changerequest-master/changerequest-master.component';
import { SupportTeamComponent } from './master-support/support-team/support-team.component';
import { UpdateSupportComponent } from './master-support/support-team/update-support/update-support.component';
import { ChangetabComponent } from './change-request/changetab/changetab.component';
import { SupportViewComponent } from './master-support/support-view/support-view.component';
import { NewMasterComponent } from './master-support/changerequest-master/new-master/new-master.component';
import { UpdateMasterComponent } from './master-support/changerequest-master/update-master/update-master.component';
import { NewCategoryMasterComponent } from './master-support/changerequest-master/new-category-master/new-category-master.component';
import { UpdateCategoryMasterComponent } from './master-support/changerequest-master/update-category-master/update-category-master.component';
import { UpdateClassificationMasterComponent } from './master-support/changerequest-master/update-classification-master/update-classification-master.component';
import { NewClassificationMasterComponent } from './master-support/changerequest-master/new-classification-master/new-classification-master.component';
import { NewNatureofchangeMasterComponent } from './master-support/changerequest-master/new-natureofchange-master/new-natureofchange-master.component';
import { UpdateNatureofchangeMasterComponent } from './master-support/changerequest-master/update-natureofchange-master/update-natureofchange-master.component';
import { NewPriorityMasterComponent } from './master-support/changerequest-master/new-priority-master/new-priority-master.component';
import { UpdatePriorityMasterComponent } from './master-support/changerequest-master/update-priority-master/update-priority-master.component';
import { NewRefrenceMasterComponent } from './master-support/changerequest-master/new-refrence-master/new-refrence-master.component';
import { UpdateRefrenceMasterComponent } from './master-support/changerequest-master/update-refrence-master/update-refrence-master.component';
import { NewRefrencetypeMasterComponent } from './master-support/changerequest-master/new-refrencetype-master/new-refrencetype-master.component';
import { UpdateRefrencetypeMasterComponent } from './master-support/changerequest-master/update-refrencetype-master/update-refrencetype-master.component';
import { NewSystemlandscopeMasterComponent } from './master-support/changerequest-master/new-systemlandscope-master/new-systemlandscope-master.component';
import { UpdateSystemlandscopeMasterComponent } from './master-support/changerequest-master/update-systemlandscope-master/update-systemlandscope-master.component';
import { Category } from '@syncfusion/ej2-angular-charts';
import { CategorytypeComponent } from './master-support/changerequest-master/categorytype/categorytype.component';
import { ClassificationComponent } from './master-support/changerequest-master/classification/classification.component';
import { NatureofchangeComponent } from './master-support/changerequest-master/natureofchange/natureofchange.component';
import { SystemlandscapeComponent } from './master-support/changerequest-master/systemlandscape/systemlandscape.component';
import { RefrenceMasterComponent } from './master-support/changerequest-master/refrence-master/refrence-master.component';
import { RefrencetypeMasterComponent } from './master-support/changerequest-master/refrencetype-master/refrencetype-master.component';
import { FilterDashboardComponent } from './dashboard/filter-dashboard/filter-dashboard.component';
import { IssueAssigntoComponent } from './helpdesk/report-issue/issue-new-issue/issue-assignto/issue-assignto.component';
import { ProjectManagementComponent } from './project-management/project-management.component';
import { ChecklistMasterComponent } from './master-support/checklist-master/checklist-master.component'
import { UpdateChecklistComponent } from './master-support/checklist-master/new-checklist/update-checklist/update-checklist.component';
import { NewChecklistComponent } from './master-support/checklist-master/new-checklist/new-checklist.component'
import { PriorityComponent } from './master-support/changerequest-master/priority/priority.component';
import { FilterCloseComponent } from './dashboard/filter-dashboard/filter-close/filter-close.component';
//import { ModuleNameComponent } from './master-support/changerequest-master/module-name/module-name.component';
//import { NewModuleComponent } from './master-support/changerequest-master/module-name/new-module/new-module.component';
//import { ViewModuleComponent } from './master-support/changerequest-master/module-name/view-module/view-module.component';
import { FilterDraftComponent } from './dashboard/filter-dashboard/filter-draft/filter-draft.component';
import { FilterPendingComponent } from './dashboard/filter-dashboard/filter-pending/filter-pending.component';
import { FilterImplementedComponent } from './dashboard/filter-dashboard/filter-implemented/filter-implemented.component';
import { FilterApprovalComponent } from './dashboard/filter-dashboard/filter-approval/filter-approval.component';
import { FilterClosureComponent } from './dashboard/filter-dashboard/filter-closure/filter-closure.component';
import { FilterReleasedComponent } from './dashboard/filter-dashboard/filter-released/filter-released.component';
import { FilterRejectedComponent } from './dashboard/filter-dashboard/filter-rejected/filter-rejected.component';
import { IssuetabComponent } from './helpdesk/report-issue/issuetab/issuetab.component';
import { NewProjectComponent } from './project-management/new-project/new-project.component';
import { NewMilestoneComponent } from './project-management/milestone-tab/new-milestone/new-milestone.component';
import { SlamasterComponent } from './master-support/SLA/slamaster/slamaster.component';
import { NewslamasterComponent } from './master-support/SLA/newslamaster/newslamaster.component';
import { ViewSupportteamComponent } from './master-support/view-supportteam/view-supportteam.component';
import { AddMemberComponent } from './project-management/members-tab/add-member/add-member.component';
import { NewTaskComponent } from './project-management/tasks-tab/new-task/new-task.component';
import { SlaresolutionComponent } from './helpdesk/slaresolution/slaresolution.component';
import { SlasummaryComponent } from './helpdesk/slasummary/slasummary.component';
import { ItengineerComponent } from './helpdesk/itengineer/itengineer.component';
import { AppComponent } from './app.component';
import { AuthGuard } from './auth.guard';
import { UpdateIssueResolutionComponent } from './helpdesk/report-issue/issue-resolution/update-issue-resolution/update-issue-resolution.component';
import { NewIssueDraftComponent } from './helpdesk/report-issue/issue-new-issue/new-issue-draft/new-issue-draft.component';
import { ViewServicesComponent } from './helpdesk/service/view-services/view-services.component';
import { ExecuteComponent } from './change-request/execute/execute.component';
import { OnHoldReasonComponent } from './master-support/on-hold-reason/on-hold-reason.component';
import { NewHoldReasonComponent } from './master-support/new-hold-reason/new-hold-reason.component';
import { SoftwaremasterComponent } from './softwaremaster/softwaremaster.component';
import { SoftwareVersionMasterComponent } from './software-version-master/software-version-master.component';
import { NewSoftwareMasterComponent } from './new-software-master/new-software-master.component';
import { NewSoftwareVersionMasterComponent } from './new-software-version-master/new-software-version-master.component';



const routes: Routes = [
  { path: 'empid/:this.empNumber', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'issue', loadChildren: () => import('./issue-module/issue.module').then(m => m.IssueModule) },
  {
    path: '',
    component: AppComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
      { path: 'page-not-found', component: ChangetabComponent },
      // Change Request
      { path: 'change-request', component: ChangeRequestComponent },
      { path: 'new-change', component: NewChangeRequestComponent },
      { path: 'updatecr/:id/edit', component: UpdatechangerequestComponent },
      { path: 'executive/:id/edit', component: ExecuteComponent },
      { path: 'executive', component: ExecuteComponent },
      { path: 'aprove', component: ApproveComponent },
      { path: 'cr-task', component: CrTaskComponent },
      { path: 'updatetask/:id/edit', component: UpdateCrtaskComponent },
      { path: 'change_request_report', component: ChangeRequestReportComponent },
      { path: 'view_change', component: ViewChangeComponent },
      { path: 'view_task', component: ViewTaskComponent },
      { path: 'view_summary', component: ViewSummaryComponent },
      { path: 'history', component: HistoryComponent },
      { path: 'ChageRequest-Masters', component: ChangerequestMasterComponent },

      // master support
      { path: 'mastersupport', component: MasterSupportComponent },
      { path: 'New-checklist', component: NewChecklistComponent },
      { path: 'update-checklist/:id/edit', component: UpdateChecklistComponent },
      { path: 'viewcheklist', component: ChecklistMasterComponent },


      // Helpdesk
      { path: 'help-desk', component: HelpdeskComponent },
      { path: 'report_issue', component: ReportIssueComponent },
      { path: 'service', component: ServiceComponent },
      { path: 'it_assets', component: ItAssetsComponent },

      // report issue
      { path: 'issuelist/:id/tab', component: IssuetabComponent },
      { path: 'issue_new_issue', component: IssueNewIssueComponent },
      { path: 'issue_resolution', component: IssueResolutionComponent },
      { path: 'issue_report', component: IssueReportComponent },
      { path: 'issueassign/:id', component: IssueAssigntoComponent },
      { path: 'new_issue_draft/:id/edit', component: NewIssueDraftComponent },
      { path: 'update_issue_resolution/:id/edit', component: UpdateIssueResolutionComponent },

      //Helpdesk service
      { path: 'software', component: SoftwareServiceComponent },
      { path: 'domain', component: DomainServiceComponent },
      { path: 'email', component: EmailServiceComponent },
      { path: 'external_drive_access', component: ExternalDriveAcessServiceComponent },
      { path: 'ftp_access', component: FtpAccessServiceComponent },
      { path: 'usb_access', component: UsbAccessServiceComponent },
      { path: 'windows_login', component: WindowsLoginServiceComponent },
      { path: 'citrix_access', component: CitrixAccessServiceComponent },
      { path: 'vpn_access', component: VpnAccessServiceComponent },
      { path: 'internet_access', component: InternetAccessServiceComponent },
      { path: 'wifi_access', component: WifiAccessServiceComponent },
      { path: 'access_for_folders', component: AccessFolderServiceComponent },
      { path: 'backup_restoration', component: BackupRestorationServiceComponent },
      { path: 'remote_access', component: RemoteAccessServiceComponent },
      { path: 'antivirus', component: AntivirusServiceComponent },
      { path: 'virtual_meet', component: VirtualmeetServiceComponent },
      { path: 'viewServices', component: ViewServicesComponent },

      //IT Asset
      { path: 'it_spare', component: ItspareComponent },
      { path: 'it_consumeable', component: ConsumeableComponent },
      { path: 'it_asset', component: AssetComponent },
      { path: 'support', component: SupportTeamComponent },
      { path: 'support_view', component: SupportViewComponent },
      { path: 'update_support', component: UpdateSupportComponent },

      { path: 'filteredCRs', component: FilterRejectedComponent },
      { path: 'categorytype', component: CategorytypeComponent },
      { path: 'classification', component: ClassificationComponent },
      { path: 'natureofchange', component: NatureofchangeComponent },
      { path: 'systemlandscape', component: SystemlandscapeComponent },
      { path: 'new_master', component: NewMasterComponent },
      { path: 'Refrencemaster', component: RefrenceMasterComponent },
      { path: 'Refrencetype', component: RefrencetypeMasterComponent },
      { path: 'Priority', component: PriorityComponent },


      { path: 'updatecategory/:id/edit', component: UpdateMasterComponent },
      { path: 'new-categorytype', component: NewCategoryMasterComponent },
      { path: 'updatecategorytype/:id/edit', component: UpdateCategoryMasterComponent },
      { path: 'newclassification', component: NewClassificationMasterComponent },
      { path: 'updateclassification/:id/edit', component: UpdateClassificationMasterComponent },
      { path: 'newnatureofchange', component: NewNatureofchangeMasterComponent },
      { path: 'updatenatureofchange/:id/edit', component: UpdateNatureofchangeMasterComponent },
      { path: 'newpriority', component: NewPriorityMasterComponent },
      { path: 'updatepriority/:id/edit', component: UpdatePriorityMasterComponent },
      { path: 'newrefrence', component: NewRefrenceMasterComponent },
      { path: 'updaterefrence/:id/edit', component: UpdateRefrenceMasterComponent },
      { path: 'newrefrencetype', component: NewRefrencetypeMasterComponent },
      { path: 'updaterefrencetype/:id/edit', component: UpdateRefrencetypeMasterComponent },
      { path: 'newsystemlandscape', component: NewSystemlandscopeMasterComponent },
      { path: 'updatesystemlandscape/:id/edit', component: UpdateSystemlandscopeMasterComponent },
      //Master
      { path: 'slamaster', component: SlamasterComponent },
      { path: 'newSlaMaster', component: NewslamasterComponent },
      { path: 'updateSlaMaster', component: NewslamasterComponent },
      { path: 'viewsupportteam/:id/view', component: ViewSupportteamComponent },

      //project management
      // { path: 'projectmanagement', component: ProjectManagementComponent },
      { path: 'new-project', component: NewProjectComponent },
      { path: 'new-milestone', component: NewMilestoneComponent },
      //Task-Tab
      { path: 'new-task', component: NewTaskComponent },
      { path: 'add-member', component: AddMemberComponent },

      { path: 'reports', component: ReportsComponent },
      { path: 'slaresolution', component: SlaresolutionComponent },
      { path: 'slasummary', component: SlasummaryComponent },
      { path: 'itengineer', component: ItengineerComponent },
      { path: 'onHoldReasonnMaster', component: OnHoldReasonComponent },
      { path: 'newonholdreasonmaster', component: NewHoldReasonComponent },
      { path: 'viewOnHoldReasonnMaster', component: NewHoldReasonComponent },


      { path: 'softwareMaster', component: SoftwaremasterComponent },
      { path: 'softwareVersionMaster', component: SoftwareVersionMasterComponent },
      { path: 'newsoftwaremaster', component: NewSoftwareMasterComponent },
      { path: 'newsoftwareVersionMaster', component: NewSoftwareVersionMasterComponent  },
      //Services
      {
        path: 'services',
        loadChildren: () => import('./service-module/service-module.module').then(m => m.ServiceModuleModule),
      },

      // Change Request
      {
        path: 'changerequest',
        loadChildren: () => import('./cr-module/cr-module.module').then(m => m.CrModuleModule),
      },

      // Issue
      {
        path: 'issue',
        loadChildren: () => import('./issue-module/issue.module').then(m => m.IssueModule),
      },

      // Master Module
      {
        path: 'mastermodule',
        loadChildren: () => import('./master-module/master-module.module').then(m => m.MasterModuleModule)
      },

      // Asset Module
      {
        path: 'assets',
        loadChildren: () => import('./asset-module/asset-module.module').then(m => m.AssetModuleModule)
      },

      // Pro Management Module
      {
        path: '',
        loadChildren: () => import('./project-managament-module/project-managament-module.module').then(m => m.ProjectManagamentModuleModule)
      },
    ]
  }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

