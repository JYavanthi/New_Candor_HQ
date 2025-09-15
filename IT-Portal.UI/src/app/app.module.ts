import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChangeRequestComponent } from './change-request/change-request.component';
import { SideBarComponent } from './side-bar/side-bar.component';
import { HeaderComponent } from './header/header.component';
import { HelpdeskComponent } from './helpdesk/helpdesk.component';
import { ProjectManagementComponent } from './project-management/project-management.component';
import { NewChangeRequestComponent } from './change-request/new-change-request/new-change-request.component';
import { ApproveComponent } from './change-request/approve/approve.component';
import { ExecuteComponent } from './change-request/execute/execute.component';
import { HomeComponent } from './home/home.component';
import { CrTaskComponent } from './change-request/execute/cr-task/cr-task.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonComponent } from './common/common.component';
import { MasterSupportComponent } from './master-support/master-support.component';
import { ServiceComponent } from './helpdesk/service/service.component';
import { ReportIssueComponent } from './helpdesk/report-issue/report-issue.component';
import { ItAssetsComponent } from './helpdesk/it-assets/it-assets.component';
import { IssueResolutionComponent } from './helpdesk/report-issue/issue-resolution/issue-resolution.component';
import { IssueReportComponent } from './helpdesk/report-issue/issue-report/issue-report.component';
import { IssueNewIssueComponent } from './helpdesk/report-issue/issue-new-issue/issue-new-issue.component';
import { ChangeRequestReportComponent } from './change-request/change-request-report/change-request-report.component';
import { ViewChangeComponent } from './change-request/change-request-report/view-change/view-change.component';
import { ViewTaskComponent } from './change-request/change-request-report/view-task/view-task.component';
import { ViewSummaryComponent } from './change-request/change-request-report/view-summary/view-summary.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ChangetabComponent } from './change-request/changetab/changetab.component';
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
import { SeekclerificatonsComponent } from './change-request/approve/seekclerificatons/seekclerificatons.component';
import { ImplemetComponent } from './change-request/execute/implemet/implemet.component';
import { ReleaserComponent } from './change-request/execute/releaser/releaser.component';
import { ClosureComponent } from './change-request/execute/closure/closure.component';
import { ExecuteApproveComponent } from './change-request/execute/execute-approve/execute-approve.component';
import { ValidationComponent } from './validation/validation.component';
import { UpdateCrtaskComponent } from './change-request/execute/cr-task/update-crtask/update-crtask.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
//import { MatDialogModule } from '@angular/material/dialog';
import { CanvasJSAngularChartsModule } from '@canvasjs/angular-charts';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

//chart modueles
import { NgChartsModule } from 'ng2-charts';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { ChangerequestMasterComponent } from './master-support/changerequest-master/changerequest-master.component';
import { SupportTeamComponent } from './master-support/support-team/support-team.component';
import { SupportViewComponent } from './master-support/support-view/support-view.component';
import { NewMasterComponent } from './master-support/changerequest-master/new-master/new-master.component';
import { UpdateMasterComponent } from './master-support/changerequest-master/update-master/update-master.component';
import { NewCategoryMasterComponent } from './master-support/changerequest-master/new-category-master/new-category-master.component';
import { UpdateCategoryMasterComponent } from './master-support/changerequest-master/update-category-master/update-category-master.component';
import { NewClassificationMasterComponent } from './master-support/changerequest-master/new-classification-master/new-classification-master.component';
import { UpdateClassificationMasterComponent } from './master-support/changerequest-master/update-classification-master/update-classification-master.component';
import { UpdateNatureofchangeMasterComponent } from './master-support/changerequest-master/update-natureofchange-master/update-natureofchange-master.component';
import { NewNatureofchangeMasterComponent } from './master-support/changerequest-master/new-natureofchange-master/new-natureofchange-master.component';
import { NewPriorityMasterComponent } from './master-support/changerequest-master/new-priority-master/new-priority-master.component';
import { UpdatePriorityMasterComponent } from './master-support/changerequest-master/update-priority-master/update-priority-master.component';
import { UpdateRefrenceMasterComponent } from './master-support/changerequest-master/update-refrence-master/update-refrence-master.component';
import { NewRefrenceMasterComponent } from './master-support/changerequest-master/new-refrence-master/new-refrence-master.component';
import { NewRefrencetypeMasterComponent } from './master-support/changerequest-master/new-refrencetype-master/new-refrencetype-master.component';
import { UpdateRefrencetypeMasterComponent } from './master-support/changerequest-master/update-refrencetype-master/update-refrencetype-master.component';
import { UpdateSystemlandscopeMasterComponent } from './master-support/changerequest-master/update-systemlandscope-master/update-systemlandscope-master.component';
import { NewSystemlandscopeMasterComponent } from './master-support/changerequest-master/new-systemlandscope-master/new-systemlandscope-master.component';
import { CategorytypeComponent } from './master-support/changerequest-master/categorytype/categorytype.component';
import { ClassificationComponent } from './master-support/changerequest-master/classification/classification.component';
import { NatureofchangeComponent } from './master-support/changerequest-master/natureofchange/natureofchange.component';
import { SystemlandscapeComponent } from './master-support/changerequest-master/systemlandscape/systemlandscape.component';
import { RefrenceMasterComponent } from './master-support/changerequest-master/refrence-master/refrence-master.component';
import { RefrencetypeMasterComponent } from './master-support/changerequest-master/refrencetype-master/refrencetype-master.component';
import { FilterDashboardComponent } from './dashboard/filter-dashboard/filter-dashboard.component';
import { HeadersComponent } from './headers/headers.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { IssueAssigntoComponent } from './helpdesk/report-issue/issue-new-issue/issue-assignto/issue-assignto.component';
import { ChecklistMasterComponent } from './master-support/checklist-master/checklist-master.component'
import { UpdateChecklistComponent } from './master-support/checklist-master/new-checklist/update-checklist/update-checklist.component';
import { NewChecklistComponent } from './master-support/checklist-master/new-checklist/new-checklist.component'
import { PriorityComponent } from './master-support/changerequest-master/priority/priority.component';
import { FilterCloseComponent } from './dashboard/filter-dashboard/filter-close/filter-close.component';
//import { ModuleNameComponent } from './master-support/changerequest-master/module-name/module-name.component';
//import { ViewModuleComponent } from './master-support/changerequest-master/module-name/view-module/view-module.component';
//import  { NewModuleComponent } from './master-support/changerequest-master/module-name/new-module/new-module.component';
import { FilterDraftComponent } from './dashboard/filter-dashboard/filter-draft/filter-draft.component';
import { FilterPendingComponent } from './dashboard/filter-dashboard/filter-pending/filter-pending.component';
import { FilterApprovalComponent } from './dashboard/filter-dashboard/filter-approval/filter-approval.component';
import { FilterImplementedComponent } from './dashboard/filter-dashboard/filter-implemented/filter-implemented.component';
import { FilterReleasedComponent } from './dashboard/filter-dashboard/filter-released/filter-released.component';
import { FilterClosureComponent } from './dashboard/filter-dashboard/filter-closure/filter-closure.component';
import { FilterRejectedComponent } from './dashboard/filter-dashboard/filter-rejected/filter-rejected.component';
import { IssuetabComponent } from './helpdesk/report-issue/issuetab/issuetab.component';
import { UpdateIssueComponent } from './helpdesk/report-issue/update-issue/update-issue.component';
import { NewProjectComponent } from './project-management/new-project/new-project.component';
import { DetailsTabComponent } from './project-management/details-tab/details-tab.component';
import { MilestoneTabComponent } from './project-management/milestone-tab/milestone-tab.component';
import { TasksTabComponent } from './project-management/tasks-tab/tasks-tab.component';
import { MembersTabComponent } from './project-management/members-tab/members-tab.component';
import { IssuesTrackerTabComponent } from './project-management/issues-tracker-tab/issues-tracker-tab.component';
import { ChecklistTabComponent } from './project-management/checklist-tab/checklist-tab.component';
import { DocumentsTabComponent } from './project-management/documents-tab/documents-tab.component';
import { HistoryTabComponent } from './project-management/history-tab/history-tab.component';
import { NewMilestoneComponent } from './project-management/milestone-tab/new-milestone/new-milestone.component';
import { IssueHistoryComponent } from './helpdesk/report-issue/issue-history/issue-history.component';
import { ViewSupportteamComponent } from './master-support/view-supportteam/view-supportteam.component';
import { SlamasterComponent } from './master-support/SLA/slamaster/slamaster.component';
import { NewslamasterComponent } from './master-support/SLA/newslamaster/newslamaster.component';
import { UpdateSupportComponent } from './master-support/support-team/update-support/update-support.component';
import { NewTaskComponent } from './project-management/tasks-tab/new-task/new-task.component';
import { AddMemberComponent } from './project-management/members-tab/add-member/add-member.component';
//import { ReportsComponent } from './helpdesk/reports/reports.component';
import { SlaresolutionComponent } from './helpdesk/slaresolution/slaresolution.component';
import { SlasummaryComponent } from './helpdesk/slasummary/slasummary.component';
import { ReportsComponent } from './helpdesk/reports/reports.component';
import { ItengineerComponent } from './helpdesk/itengineer/itengineer.component';
//import { PaginationComponent } from './master-support/pagination/pagination.component';
import { DatePipe } from '@angular/common';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaginationComponent } from './pagination/pagination.component';
import { UpdateIssueResolutionComponent } from './helpdesk/report-issue/issue-resolution/update-issue-resolution/update-issue-resolution.component';
//import { ItengineerComponent } from './helpdesk/itengineer/itengineer.component';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { MatFormFieldModule } from '@angular/material/form-field';
import { NewIssueDraftComponent } from './helpdesk/report-issue/issue-new-issue/new-issue-draft/new-issue-draft.component';
import { SoftSerResolutionComponent } from './helpdesk/service/soft-ser-resolution/soft-ser-resolution.component';
import { MatInputModule } from '@angular/material/input';
import { InterceptorApiService } from './helper/interceptor-api.service';
import { IssueListComponent } from './issue-list/issue-list.component';
import { MatTabsModule } from '@angular/material/tabs';
import { RouterModule } from '@angular/router';
import { ViewServicesComponent } from './helpdesk/service/view-services/view-services.component';
import { AddFilePopUpComponent } from './change-request/add-file-pop-up/add-file-pop-up.component';
import {MatDialogModule } from '@angular/material/dialog';
import { InvalidFieldDirective } from './directives/invalid-field.directive';
import { CrApprovedReportComponent } from './change-request/change-request-report/cr-approved-report/cr-approved-report.component';
import { MileStoneReportComponent } from './change-request/change-request-report/mile-stone-report/mile-stone-report.component';
import { OnHoldReasonComponent } from './master-support/on-hold-reason/on-hold-reason.component';
import { NewHoldReasonComponent } from './master-support/new-hold-reason/new-hold-reason.component';
import { SoftwaremasterComponent } from './softwaremaster/softwaremaster.component';
import { SoftwareVersionMasterComponent } from './software-version-master/software-version-master.component';
import { NewSoftwareMasterComponent } from './new-software-master/new-software-master.component';
import { NewSoftwareVersionMasterComponent } from './new-software-version-master/new-software-version-master.component';
import { CdkDrag, CdkDropList, DragDropModule } from '@angular/cdk/drag-drop';

@NgModule({
  declarations: [
    AppComponent,
    ChangeRequestComponent,
    SideBarComponent,
    HeaderComponent,
    HelpdeskComponent,
    ProjectManagementComponent,
    NewChangeRequestComponent,
    ApproveComponent,
    ExecuteComponent,
    HomeComponent,
    CrTaskComponent,
    DashboardComponent,
    CommonComponent,
    MasterSupportComponent,
    ServiceComponent,
    ReportIssueComponent,
    ItAssetsComponent,
    IssueResolutionComponent,
    IssueReportComponent,
    IssueNewIssueComponent,
    ChangeRequestReportComponent,
    ViewTaskComponent,
    ViewSummaryComponent,
    ChangetabComponent,
    HistoryComponent,
    SoftwareServiceComponent,
    DomainServiceComponent,
    EmailServiceComponent,
    ViewChangeComponent,
    ExternalDriveAcessServiceComponent,
    FtpAccessServiceComponent,
    UsbAccessServiceComponent,
    WindowsLoginServiceComponent,
    CitrixAccessServiceComponent,
    VpnAccessServiceComponent,
    InternetAccessServiceComponent,
    WifiAccessServiceComponent,
    AccessFolderServiceComponent,
    BackupRestorationServiceComponent,
    RemoteAccessServiceComponent,
    AntivirusServiceComponent,
    VirtualmeetServiceComponent,
    ItspareComponent,
    ConsumeableComponent,
    AssetComponent,
    UpdatechangerequestComponent,
    SeekclerificatonsComponent,
    ImplemetComponent,
    ReleaserComponent,
    ClosureComponent,
    ExecuteApproveComponent,
    ValidationComponent,
    UpdateCrtaskComponent,
    ChangerequestMasterComponent,
    SupportTeamComponent,
    SupportViewComponent,
    NewMasterComponent,
    UpdateMasterComponent,
    NewCategoryMasterComponent,
    UpdateCategoryMasterComponent,
    NewClassificationMasterComponent,
    UpdateClassificationMasterComponent,
    UpdateNatureofchangeMasterComponent,
    NewNatureofchangeMasterComponent,
    NewPriorityMasterComponent,
    UpdatePriorityMasterComponent,
    UpdateRefrenceMasterComponent,
    NewRefrenceMasterComponent,
    NewRefrencetypeMasterComponent,
    UpdateRefrencetypeMasterComponent,
    UpdateSystemlandscopeMasterComponent,
    NewSystemlandscopeMasterComponent,
    CategorytypeComponent,
    ClassificationComponent,
    NatureofchangeComponent,
    SystemlandscapeComponent,
    RefrenceMasterComponent,
    RefrencetypeMasterComponent,
    FilterDashboardComponent,
    ChecklistMasterComponent,
    UpdateChecklistComponent,
    HeadersComponent,
    IssueAssigntoComponent,
    NewChecklistComponent,
    PriorityComponent,
    FilterCloseComponent,
    FilterDraftComponent,
    FilterPendingComponent,
    FilterApprovalComponent,
    FilterImplementedComponent,
    FilterReleasedComponent,
    FilterClosureComponent,
    FilterRejectedComponent,
    IssuetabComponent,
    UpdateIssueComponent,
    UpdateIssueResolutionComponent,
    IssueHistoryComponent,
    IssueAssigntoComponent,
    NewProjectComponent,
    DetailsTabComponent,
    MilestoneTabComponent,
    TasksTabComponent,
    MembersTabComponent,
    IssuesTrackerTabComponent,
    ChecklistTabComponent,
    DocumentsTabComponent,
    HistoryTabComponent,
    NewMilestoneComponent,
    ViewSupportteamComponent,
    SlamasterComponent,
    NewslamasterComponent,
    NewTaskComponent,
    UpdateSupportComponent,
    AddMemberComponent,
    //ReportsComponent,
    ReportsComponent,
    SlaresolutionComponent,
    SlasummaryComponent,
    //ItengineerComponent,
    ItengineerComponent,
    PaginationComponent,
    NewIssueDraftComponent,
    SoftSerResolutionComponent,
    IssueListComponent,
    ViewServicesComponent,
    AddFilePopUpComponent,
    InvalidFieldDirective,
    CrApprovedReportComponent,
    MileStoneReportComponent,
    OnHoldReasonComponent,
    NewHoldReasonComponent,
    SoftwaremasterComponent,
    SoftwareVersionMasterComponent,
    NewSoftwareMasterComponent,
    NewSoftwareVersionMasterComponent
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    MatDialogModule,
    HttpClientModule,
    NgChartsModule,
    NgxChartsModule,
    NgMultiSelectDropDownModule.forRoot(),
    NgxPaginationModule,
    RouterModule,
    MatPaginatorModule,
    MatPaginator,
    MatFormFieldModule,
    BrowserAnimationsModule,
    AngularEditorModule,MatTabsModule,
    CanvasJSAngularChartsModule,ReactiveFormsModule,MatAutocompleteModule,MatInputModule,MatProgressSpinnerModule, DragDropModule, CdkDropList,
    CdkDrag
  ],
  providers: [provideClientHydration(), provideAnimationsAsync(), DatePipe,
    { provide: HTTP_INTERCEPTORS, useClass: InterceptorApiService, multi: true }],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}

