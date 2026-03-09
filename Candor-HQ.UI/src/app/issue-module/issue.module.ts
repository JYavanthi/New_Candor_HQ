import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IssueRoutingModule } from './issue-routing.module';
import { RouterModule } from '@angular/router';
import { NewIssueComponent } from './new-issue/new-issue.component';


@NgModule({
  declarations: [
    NewIssueComponent
  ],
  imports: [
    CommonModule,
    IssueRoutingModule,RouterModule
  ]
})
export class IssueModule { }
