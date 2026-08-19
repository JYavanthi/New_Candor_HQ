import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectMasterComponent } from './project-master/project-master.component';
import { ProjectManagementDetailsComponent } from './project-management-details/project-management-details.component';
import { CommonProjectTabComponent } from './common-project-tab/common-project-tab.component';
import { TasksTabComponent } from 'app/project-management/tasks-tab/tasks-tab.component';
import { MilestoneTabComponent } from 'app/project-management/milestone-tab/milestone-tab.component';
import { MembersTabComponent } from 'app/project-management/members-tab/members-tab.component';
import { IssuesTrackerTabComponent } from 'app/project-management/issues-tracker-tab/issues-tracker-tab.component';
import { ChecklistTabComponent } from 'app/project-management/checklist-tab/checklist-tab.component';
import { DocumentsTabComponent } from 'app/project-management/documents-tab/documents-tab.component';
import { HistoryTabComponent } from 'app/project-management/history-tab/history-tab.component';
import { AddTaskComponent } from './pro-tasks/add-task/add-task.component';
import { ProTasksComponent } from './pro-tasks/pro-tasks.component';
import { ProMilestoneDetailsComponent } from './pro-milestones/pro-milestone-details/pro-milestone-details.component';
import { ProMilestonesComponent } from './pro-milestones/pro-milestones.component';
import { ProMembersComponent } from './pro-members/pro-members.component';
import { ProMemberDetailsComponent } from './pro-members/pro-member-details/pro-member-details.component';
import { ProIssueTrackerComponent } from './pro-issue-tracker/pro-issue-tracker.component';
import { AddIssueComponent } from './pro-issue-tracker/add-issue/add-issue.component';
import { AddProChecklistComponent } from './pro-checklist/add-pro-checklist/add-pro-checklist.component';
import { ProChecklistComponent } from './pro-checklist/pro-checklist.component';
import { ProClosureComponent } from './pro-closure/pro-closure.component';
// import { QuillModule } from 'ngx-quill';
import { ProjectGroupMasterComponent } from './project-group-master/project-group-master.component';
import { ProjectlessonComponent } from './projectlesson/projectlesson.component';
import { CreateProjectGroupComponent } from './project-group-master/create-project-group/create-project-group.component';
// import { ProDocumentsComponent } from './pro-documents/pro-documents.component';
// import { taskreportComponent } from './pr-report/taskreport/taskreport.component';
/*import { ProDocumentsComponent } from './pro-documents/pro-documents.component';*/
import { ProHistoryComponent } from './pro-history/pro-history.component';
import { PrReportComponent } from './pr-report/pr-report.component';
import { ProjectreportComponent } from './pr-report/projectreport/projectreport.component';
import { IssuereportComponent } from './pr-report/issuereport/issuereport.component';
import { PrTemplateComponent } from './pr-template/pr-template.component';
import { ProDocumentsComponent } from './pro-documents/pro-documents.component';
import { taskreportComponent } from './pr-report/taskreport/taskreport.component';
import { RaciReportComponent } from './pr-report/raci-report/raci-report.component';
import { ProTemplateViewComponent } from './pro-template-view/pro-template-view.component';
import { ProApproverComponent } from './pro-approver/pro-approver.component';
import { ProLessonComponent } from './projectlesson/pro-lesson/pro-lesson.component';
import { CheckListTempAddComponent } from './check-list-template/check-list-temp-add/check-list-temp-add.component';

const routes: Routes = [
  { path: 'projectmaster', component: ProjectMasterComponent },
  { path: 'projectgroupmaster', component: ProjectGroupMasterComponent },
  { path: 'projectgroupadd', component: CreateProjectGroupComponent },
  {
    path: 'projectmanagement',
    component: CommonProjectTabComponent,
    children: [
      { path: '', component: ProjectManagementDetailsComponent },
      { path: 'projectdetails', component: ProjectManagementDetailsComponent },
      {
        path: 'projecttask',
        children: [
          { path: '', component: ProTasksComponent },
          { path: 'master', component: ProTasksComponent },
          { path: 'add', component: AddTaskComponent }
        ]
      },
      {
        path: 'projectmilestone',
        children: [
          { path: '', component: ProMilestonesComponent },
          { path: 'master', component: ProMilestonesComponent },
          { path: 'add', component: ProMilestoneDetailsComponent }
        ]
      },
      {
        path: 'projectmembers',
        children: [
          { path: '', component: ProMembersComponent },
          { path: 'master', component: ProMembersComponent },
          { path: 'add', component: ProMemberDetailsComponent }
        ]
      },
      {
        path: 'issuetracker',
        children: [
          { path: '', component: ProIssueTrackerComponent },
          { path: 'master', component: ProIssueTrackerComponent },
          { path: 'add', component: AddIssueComponent }
        ]
      },
      {
        path: 'checklist',
        children: [
          { path: '', component: ProChecklistComponent },
          { path: 'master', component: ProChecklistComponent },
          { path: 'add', component: AddProChecklistComponent }
        ]
      },
      
      {
        path: 'projectchecklist',
        children: [
          { path: '', component: CheckListTempAddComponent },
          { path: 'master', component: CheckListTempAddComponent },
          { path: 'add', component: CheckListTempAddComponent }
        ]
      },
      {
        path: 'lessonlearned',
        children: [
          { path: '', component: ProLessonComponent },
          { path: 'master', component: ProLessonComponent },
          { path: 'add', component: ProjectlessonComponent }
        ]
      },
      // { path: 'issuetracker', component: IssuesTrackerTabComponent },
      // { path: 'checklist', component: ChecklistTabComponent },
      { path: 'closure', component: ProClosureComponent },
      // { path: 'lessonlearned', component: ProjectlessonComponent },
      { path: 'documents', component: ProDocumentsComponent },
      { path: 'history', component: ProHistoryComponent },
      { path: 'projectgroupmaster', component: ProjectGroupMasterComponent },
      { path: 'projectgroupadd', component: ProjectGroupMasterComponent },
      { path: 'templateadd', component: PrTemplateComponent },
      // { path: 'lessonlearnedtable', component: ProLessonComponent },
      { path: 'templateview', component: ProTemplateViewComponent },
      { path: 'approval', component: ProApproverComponent },
      {
        path: 'report',
        children: [
          { path: '', component: PrReportComponent },
          { path: 'projectreport', component: ProjectreportComponent },
          { path: 'taskreport', component: taskreportComponent },
          { path: 'issuereport', component: IssuereportComponent },
          { path: 'racireport', component: RaciReportComponent },
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectManagamentModuleRoutingModule { }
