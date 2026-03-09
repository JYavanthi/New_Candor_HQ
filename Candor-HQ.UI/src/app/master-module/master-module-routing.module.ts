import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserConfigurationComponent } from './user-configuration/user-configuration.component';
import { UserConfigTreeviewComponent } from './user-config-treeview/user-config-treeview.component';
import { SupportMasterComponent } from './support-master/support-master.component';
import { NewsupportmasterComponent } from './support-master/newsupportmaster/newsupportmaster.component';

const routes: Routes = [
  { path: 'userconfiguration', component: UserConfigurationComponent },
  { path: 'usertree', component: UserConfigTreeviewComponent },
  { path: 'supportmaster', component: SupportMasterComponent },
  { path: 'newsupportmaster', component: NewsupportmasterComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MasterModuleRoutingModule { }
