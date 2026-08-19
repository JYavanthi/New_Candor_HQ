import { Component, HostListener, ViewEncapsulation } from '@angular/core';
import { HttpServiceService } from 'shared/services/http-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

@Component({
  selector: 'app-sr-software',
  templateUrl: './sr-software.component.html',
  styleUrls: ['./sr-software.component.css', '../servicemodule.css']
})

export class SrSoftwareComponent {
  showBackIcon: boolean = false;
  selectedTabIndex: number = 0;
  srId: any;
  srData: any;
  currentUrl: any;
  disableResolution: boolean = false;
  serviceTitlesWithAPI: any

  constructor(public httpSer: HttpServiceService, public activeRoute: ActivatedRoute, private location: Location,
    public router: Router, public emailSer: SendEmailServiceService) {
    this.currentUrl = this.router.url.split('?')[0];

    this.serviceTitlesWithAPI = emailSer.serviceTitlesWithAPI
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.srId = m.srId;
      if (this.srId) {
        this.getData();
      }
    });
    this.serviceTitlesWithAPI = emailSer.serviceTitlesWithAPI
  }

  changingTabs() {
    if (this.srId) {
      const notShowingApprovalTab = this.srData?.status?.trim() == "Approval not required";
      if (notShowingApprovalTab) {
        this.selectedTabIndex = 1;
      }
      if (this.srData?.status?.trim() == 'Resolved') {
        this.selectedTabIndex = 0;
        this.disableResolution = false;
      }
      else if (this.srData?.status?.trim() == 'Approved' ||
        this.srData?.status?.trim() == 'Seek Clarification' ||
        this.srData?.status?.trim() == 'Open' ||
        this.srData?.status?.trim() == 'In Progress' ||
        this.srData?.status?.trim() == 'On Hold' ||
        this.srData?.status?.trim() == 'Submit Clarification'
      ) {
        if (!this.srData?.isRpmreq && !this.srData?.isHodreq) {
          this.selectedTabIndex = 1;
          this.disableResolution = false;
        }else{
          this.selectedTabIndex = 2;
          this.disableResolution = false;
        }
      }
      else if (this.srData?.status?.trim() == 'Pending Approval' || this.srData?.status?.trim() == 'Rejected' || this.srData?.status?.trim() == 'Pending HOD Approval') {
        this.selectedTabIndex = 1;
        this.disableResolution = true;
      }
    }
  }

  @HostListener('window:scroll', [])
  onWindowScroll() {
    this.showBackIcon = window.scrollY > 200;
  }

  getData() {
    const serviceInfo = this.serviceTitlesWithAPI[this.currentUrl];
    if (serviceInfo) {
      const apiUrl = serviceInfo.apiUrl;
      this.httpSer.httpGet(apiUrl, { 'srid': this.srId }).subscribe((res: any) => {
        this.srData = res.data;
        this.changingTabs();
      });
    } else {
      console.error('API endpoint not found for the current URL:', this.currentUrl);
    }
  }

  getTitle(): string {
    const serviceInfo = this.serviceTitlesWithAPI[this.currentUrl];
    const baseTitle = serviceInfo ? serviceInfo.title : 'Service';
    return this.srId ? `Update ${baseTitle}` : baseTitle;
  }

  navigateToBack() {
    this.location.back();
  }

}
