import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectManagamentModuleRoutingModule } from './project-managament-module-routing.module';
import { ProjectMasterComponent } from './project-master/project-master.component';
import { ProjectManagementDetailsComponent } from './project-management-details/project-management-details.component';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTabsModule } from '@angular/material/tabs';
import { CommonProjectTabComponent } from './common-project-tab/common-project-tab.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProMilestonesComponent } from './pro-milestones/pro-milestones.component';
import { ProTasksComponent } from './pro-tasks/pro-tasks.component';
import { ProMembersComponent } from './pro-members/pro-members.component';
import { ProHistoryComponent } from './pro-history/pro-history.component';
import { ProIssueTrackerComponent } from './pro-issue-tracker/pro-issue-tracker.component';
import { ProChecklistComponent } from './pro-checklist/pro-checklist.component';
import { ProDocumentsComponent } from './pro-documents/pro-documents.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { ProMilestoneDetailsComponent } from './pro-milestones/pro-milestone-details/pro-milestone-details.component';
import { AddTaskComponent } from './pro-tasks/add-task/add-task.component';
import { ProMemberDetailsComponent } from './pro-members/pro-member-details/pro-member-details.component';
import { AddIssueComponent } from './pro-issue-tracker/add-issue/add-issue.component';
import { AddProChecklistComponent } from './pro-checklist/add-pro-checklist/add-pro-checklist.component';
import { SrAttachMentComponent } from 'app/service-module/sr-attach-ment/sr-attach-ment.component';
import { ServiceModuleModule } from 'app/service-module/service-module.module';
import { PrAttachmentComponent } from './pr-attachment/pr-attachment.component';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { ProjectGroupMasterComponent } from './project-group-master/project-group-master.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { ProClosureComponent } from './pro-closure/pro-closure.component';
// import { CreateProjectGroupComponent } from './project-group-master/create-project-group/create-project-group.component';
// import { ProjectlessonComponent } from './projectlesson/projectlesson.component';
// import { ProjectlessonComponent } from './projectlesson/projectlesson.component';
import { FilterPipe } from './filter.pipe';
import { CreateProjectGroupComponent } from './project-group-master/create-project-group/create-project-group.component';
import { ProjectlessonComponent } from './projectlesson/projectlesson.component';
import { PrReportComponent } from './pr-report/pr-report.component';
import { ProjectreportComponent } from './pr-report/projectreport/projectreport.component';
import { IssuereportComponent } from './pr-report/issuereport/issuereport.component';
import { taskreportComponent } from './pr-report/taskreport/taskreport.component';
import { RaciReportComponent } from './pr-report/raci-report/raci-report.component';
import { ProTemplateViewComponent } from './pro-template-view/pro-template-view.component';
import { ProApproverComponent } from './pro-approver/pro-approver.component';
import { PrTemplateComponent } from './pr-template/pr-template.component';
import { CheckListTemplateComponent } from './check-list-template/check-list-template.component';
import { CheckListTempAddComponent } from './check-list-template/check-list-temp-add/check-list-temp-add.component';
import { ProLessonComponent } from './projectlesson/pro-lesson/pro-lesson.component';

@NgModule({
  declarations: [
    ProjectMasterComponent,
    ProjectManagementDetailsComponent,
    CommonProjectTabComponent,
    ProMilestonesComponent,
    ProTasksComponent,
    ProMembersComponent,
    ProHistoryComponent,
    ProjectlessonComponent,
    ProIssueTrackerComponent,
    ProChecklistComponent,ProClosureComponent,
    ProDocumentsComponent,ProjectGroupMasterComponent,ProLessonComponent,
    AddTaskComponent,ProMilestoneDetailsComponent,ProjectMasterComponent,ProMemberDetailsComponent, AddIssueComponent, AddProChecklistComponent, PrAttachmentComponent, ProjectlessonComponent,
    FilterPipe, CreateProjectGroupComponent,PrReportComponent,ProjectreportComponent,ProjectlessonComponent,taskreportComponent
        ,PrTemplateComponent, IssuereportComponent, RaciReportComponent, ProTemplateViewComponent, ProApproverComponent, CheckListTemplateComponent, CheckListTempAddComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ProjectManagamentModuleRoutingModule,
    NgMultiSelectDropDownModule.forRoot(),
    MatPaginatorModule,
    MatPaginator,
    MatTabsModule,
    MatFormFieldModule,
    MatSelectModule,
    AngularEditorModule,
  ]
})
export class ProjectManagamentModuleModule { }
