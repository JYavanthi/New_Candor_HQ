import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SrMasterComponent } from './sr-master/sr-master.component';
import { SrSoftwareComponent } from './sr-software/sr-software.component';
import { SrViewComponent } from './sr-view/sr-view.component';
import { SrCommonDetailsComponent } from './sr-common-details/sr-common-details.component';

const routes: Routes = [
  { path: 'servicemaster', component: SrMasterComponent },
  { path: 'software', component: SrSoftwareComponent },
  { path: 'newsoftware', component: SrCommonDetailsComponent },
  { path: 'viewservices', component: SrViewComponent },
  { path: 'domain', component: SrSoftwareComponent },
  { path: 'externaldriveaccess', component: SrSoftwareComponent },
  { path: 'ftpaccess', component: SrSoftwareComponent },
  { path: 'usbaccess', component: SrSoftwareComponent },
  { path: 'urlorinternetaccess', component: SrSoftwareComponent },
  { path: 'citrixaccess', component: SrSoftwareComponent },
  { path: 'windowslogin', component: SrSoftwareComponent },
  { path: 'vpnaccess', component: SrSoftwareComponent },
  { path: 'wifiaccess', component: SrSoftwareComponent },
  { path: 'email', component: SrSoftwareComponent },
  { path: 'fileserveroraccessforfolderaccess', component: SrSoftwareComponent },
  { path: 'backuprestoration', component: SrSoftwareComponent },
  { path: 'virtualmeeting', component: SrSoftwareComponent },
  { path: 'antivirus', component: SrSoftwareComponent },
  { path: 'remoteaccess', component: SrSoftwareComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ServiceModuleRoutingModule { }
