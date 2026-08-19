import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CrModuleRoutingModule } from './cr-module-routing.module';
import { CrMasterComponent } from './cr-master/cr-master.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { CrImplementComponent } from './cr-implement/cr-implement.component';
import { MatTabsModule } from '@angular/material/tabs';
import { CrApproveComponent } from './cr-approve/cr-approve.component';
import { CrExecuteComponent } from './cr-execute/cr-execute.component';
import { CrClosureComponent } from './cr-closure/cr-closure.component';
import { CrHistoryComponent } from './cr-history/cr-history.component';
import { CrAddtaskComponent } from './cr-addtask/cr-addtask.component';
import { NewCrComponent } from './new-cr/new-cr.component';
import { CrApproveTabComponent } from './cr-approve-tab/cr-approve-tab.component';
import { CrBreadCrumbComponent } from './cr-bread-crumb/cr-bread-crumb.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    CrMasterComponent,
    NewCrComponent,
    CrImplementComponent,
    CrApproveComponent,
    CrExecuteComponent,
    CrClosureComponent,
    CrHistoryComponent,
    CrAddtaskComponent,
    CrApproveTabComponent,
    CrBreadCrumbComponent
  ],
  imports: [
    CommonModule,
    CrModuleRoutingModule,
    ReactiveFormsModule,
    NgMultiSelectDropDownModule.forRoot(),
     MatTabsModule,FormsModule,MatPaginatorModule, HttpClientModule
  ]
})
export class CrModuleModule { }
