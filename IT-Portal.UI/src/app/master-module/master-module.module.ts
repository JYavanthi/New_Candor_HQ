import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MasterModuleRoutingModule } from './master-module-routing.module';
import { UserConfigurationComponent } from './user-configuration/user-configuration.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SupportMasterComponent } from './support-master/support-master.component';
import { NewsupportmasterComponent } from './support-master/newsupportmaster/newsupportmaster.component';
import { UserConfigTreeviewComponent } from './user-config-treeview/user-config-treeview.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import {MatDialogModule} from '@angular/material/dialog';
import { DialogComponent } from 'app/dialog/dialog.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';

@NgModule({
  declarations: [
    UserConfigurationComponent,
    UserConfigTreeviewComponent,
    SupportMasterComponent,
    NewsupportmasterComponent,
    DialogComponent
  ],
  imports: [
    CommonModule,
    MasterModuleRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatPaginatorModule,
    MatDialogModule,
    NgMultiSelectDropDownModule.forRoot(),
  ]
})
export class MasterModuleModule { }
