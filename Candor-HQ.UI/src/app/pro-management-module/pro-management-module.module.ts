import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProManagementModuleRoutingModule } from './pro-management-module-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTabsModule } from '@angular/material/tabs';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
// import { TaskreportComponent } from 'app/project-managament-module/pr-report/taskreport/taskreport.component';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ProManagementModuleRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatTabsModule,
    MatPaginatorModule,
    MatPaginator,
    // TaskreportComponent,
    
  ]
})
export class ProManagementModuleModule {
  
}
