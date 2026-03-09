import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IssueMasterComponent } from './issue-master/issue-master.component';
import { NewIssueComponent } from './new-issue/new-issue.component';

const routes: Routes = [
  { path: 'issueMaster', component: IssueMasterComponent },
  { path: 'newissue', component: NewIssueComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IssueRoutingModule { }
