import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HelpdeskRoutingModule } from './helpdesk-routing.module';
import { IssuListComponent } from './Issue/issu-list/issu-list.component';
import { NewIssueComponent } from './Issue/new-issue/new-issue.component';
import { IssueResolutionComponent } from './report-issue/issue-resolution/issue-resolution.component';
import { SidebarissueComponent } from './sidebarissue/sidebarissue.component';


@NgModule({
  declarations: [
    IssuListComponent,
    NewIssueComponent,
    IssueResolutionComponent,
    SidebarissueComponent
  ],
  imports: [
    CommonModule,
    HelpdeskRoutingModule
  ]
})
export class HelpdeskModule { }
