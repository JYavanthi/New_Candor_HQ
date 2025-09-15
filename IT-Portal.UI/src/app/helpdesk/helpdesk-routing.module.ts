import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IssuListComponent } from './Issue/issu-list/issu-list.component';
import { NewIssueComponent } from './Issue/new-issue/new-issue.component';
import { IssueReportComponent } from './report-issue/issue-report/issue-report.component';

const routes: Routes = [
  { path: 'issue', component: IssuListComponent },
  { path: 'newIssue', component: NewIssueComponent },
  { path: 'IssueResolution', component: IssueReportComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HelpdeskRoutingModule { }
