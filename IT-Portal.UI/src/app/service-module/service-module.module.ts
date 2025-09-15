import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ServiceModuleRoutingModule } from './service-module-routing.module';
import { MatTabsModule } from '@angular/material/tabs';
import { RouterModule } from '@angular/router';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { SrMasterComponent } from './sr-master/sr-master.component';
import { SrSoftwareComponent } from './sr-software/sr-software.component';
import { SrViewComponent } from './sr-view/sr-view.component';
import { SrCommonApprovalComponent } from './sr-common-approval/sr-common-approval.component';
import { SrCommonApprovetabComponent } from './sr-common-approvetab/sr-common-approvetab.component';
import { SrResolutionComponent } from './sr-resolution/sr-resolution.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SrDetailsSelfOthersGuestComponent } from './sr-details-self-others-guest/sr-details-self-others-guest.component';
import { SrApproverComponent } from './sr-approver/sr-approver.component';
import { SrApporverTabComponent } from './sr-apporver-tab/sr-apporver-tab.component';
import { SrDomainComponent } from './sr-domain/sr-domain.component';
import { SrCommonDetailsComponent } from './sr-common-details/sr-common-details.component';
import { SrDomainDetailsComponent } from './sr-domain/sr-domain-details/sr-domain-details.component';
import { SrExternalDriveAccessDetailsComponent } from './sr-external-drive-access-details/sr-external-drive-access-details.component';
import { SrFtpAccessDetailsComponent } from './sr-ftp-access-details/sr-ftp-access-details.component';
import { SrUsbAccessDetailsComponent } from './sr-usb-access-details/sr-usb-access-details.component';
import { SrWindowsLoginDetailsComponent } from './sr-windows-login-details/sr-windows-login-details.component';
import { SrCitrixAccessDetailsComponent } from './sr-citrix-access-details/sr-citrix-access-details.component';
import { SrVpnAccessDetailsComponent } from './sr-vpn-access-details/sr-vpn-access-details.component';
import { SrUrlOrInternetAccessDetailsComponent } from './sr-url-or-internet-access-details/sr-url-or-internet-access-details.component';
import { SrWifiAccessDetailsComponent } from './sr-wifi-access-details/sr-wifi-access-details.component';
import { SrFileServerOrAccessForFoldersDetailsComponent } from './sr-file-server-or-access-for-folders-details/sr-file-server-or-access-for-folders-details.component';
import { SrBackupAndRestorationDetailsComponent } from './sr-backup-and-restoration-details/sr-backup-and-restoration-details.component';
import { SrRemoteAccessDetailsComponent } from './sr-remote-access-details/sr-remote-access-details.component';
import { SrAntivirusDetailsComponent } from './sr-antivirus-details/sr-antivirus-details.component';
import { SrVirtualMeetingDetailsComponent } from './sr-virtual-meeting-details/sr-virtual-meeting-details.component';
import { SrEmailDetailsComponent } from './sr-email-details/sr-email-details.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { SrCommonHistoryComponent } from './sr-common-history/sr-common-history.component';
import { ChatBoxComponent } from './chat-box/chat-box.component';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { SrAttachMentComponent } from './sr-attach-ment/sr-attach-ment.component';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { CdkDrag, CdkDropList, CdkDropListGroup } from '@angular/cdk/drag-drop';
import { FilterPipe } from './filter.pipe';
import { ScrollingModule } from '@angular/cdk/scrolling';
// import { SoftwareComponent } from './software/softwar e.component';


@NgModule({
  declarations: [
    SrMasterComponent,
    SrSoftwareComponent,
    SrViewComponent,
    SrCommonApprovalComponent,
    SrCommonApprovetabComponent,
    SrResolutionComponent,
    SrDetailsSelfOthersGuestComponent,
    SrApproverComponent,
    SrApporverTabComponent,
    SrDomainComponent,
    SrCommonDetailsComponent,
    SrDomainDetailsComponent,
    SrExternalDriveAccessDetailsComponent,
    SrFtpAccessDetailsComponent,
    SrUsbAccessDetailsComponent,
    SrWindowsLoginDetailsComponent,
    SrCitrixAccessDetailsComponent,
    SrVpnAccessDetailsComponent,
    SrUrlOrInternetAccessDetailsComponent,
    SrWifiAccessDetailsComponent,
    SrFileServerOrAccessForFoldersDetailsComponent,
    SrBackupAndRestorationDetailsComponent,
    SrRemoteAccessDetailsComponent,
    SrAntivirusDetailsComponent,
    SrVirtualMeetingDetailsComponent,
    SrEmailDetailsComponent,
    SrCommonHistoryComponent,
    ChatBoxComponent,
    SrAttachMentComponent,
    FilterPipe,
    // SoftwareComponent
  ],
  imports: [
    CommonModule,
    ServiceModuleRoutingModule,
    MatTabsModule,
    RouterModule,
    NgMultiSelectDropDownModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatPaginatorModule,
    MatPaginator,
    MatButtonToggleModule,CdkDropList,
    CdkDrag, CdkDropListGroup, ScrollingModule
  ],
  exports: [SrDetailsSelfOthersGuestComponent, SrCommonApprovalComponent, SrResolutionComponent,
    SrAttachMentComponent
  ]
})
export class ServiceModuleModule { }
