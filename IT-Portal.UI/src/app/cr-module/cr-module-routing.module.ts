import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CrMasterComponent } from './cr-master/cr-master.component';
import { NewCrComponent } from './new-cr/new-cr.component';
import { CrImplementComponent } from './cr-implement/cr-implement.component';
import { CrAddtaskComponent } from './cr-addtask/cr-addtask.component';

const routes: Routes = [
  {path: 'cr-master', component:CrMasterComponent},
  {path: 'newchangerequest', component:NewCrComponent},
  {path: 'cr-implement', component:CrImplementComponent},
  { path: 'cr-addtask', component: CrAddtaskComponent },
  { path: 'cr-updateTask', component: CrAddtaskComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CrModuleRoutingModule { }
