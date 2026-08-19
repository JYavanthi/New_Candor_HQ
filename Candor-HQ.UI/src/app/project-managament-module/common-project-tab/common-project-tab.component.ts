import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';
import { FormValidationService } from 'app/services/form-validation.service';
import { DataTransferServiceService } from 'app/data-transfer-service.service';


@Component({
  selector: 'app-common-project-tab',
  templateUrl: './common-project-tab.component.html',
  styleUrls: ['./common-project-tab.component.css', '../promanagement.css']
})

export class CommonProjectTabComponent {

  selectedTabIndex: number = 0;
  proData: any;
  projectID: any;
  currentUrl: any;
  projectdetails: any;
  mileStoneList: any;

  constructor(private location: Location, private router: Router, public formValidationSer: FormValidationService,
    private activeRoute: ActivatedRoute, private httpSer: HttpServiceService,
    public dataTransferSer: DataTransferServiceService) {

    this.getSelectedTab(this.router.url?.split('?')[0].split('/')[2])
    this.currentUrl = this.router.url.split('?')[0];

    this.activeRoute.queryParams.subscribe((m: any) => {
      this.projectID = m.projectId;
      if (this.projectID) {
        this.getProjectDetails();
      }
    });
    this.getMileStoneList()
  }

  navigateToBack() {
    this.router.navigate(['/projectmaster']);
    this.location.back();
  }

  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.projectID }).subscribe((response: any) => {
      this.projectdetails = response.data;
    })
  }

  getTitle(): string {
    const proInfo = this.dataTransferSer.proManagementTitles[this.currentUrl];
    const baseTitle = proInfo ? proInfo.title : 'Report';
    return baseTitle;
  }

  getSelectedTab(url: any) {
    switch (url) {
      case "projectdetails":
        this.selectedTabIndex = 0;
        break;
      case "projecttask":
        this.selectedTabIndex = 3;
        break;
      case "projectmilestone":
        this.selectedTabIndex = 2;
        break;
      case "projectmembers":
        this.selectedTabIndex = 1;
        break;
      case "issuetracker":
        this.selectedTabIndex = 4;
        break;
      case "checklist" || 'projectchecklist':
        this.selectedTabIndex = 5;
        break;
      case "closure":
        this.selectedTabIndex = 6;
        break;

      case "approval":
        this.selectedTabIndex = 7;
        break;
      case "documents":
        this.selectedTabIndex = 8;
        break;
      case "history":
        this.selectedTabIndex = 9;
        break;
      case "lessonlearned":
        this.selectedTabIndex = 10;
        break;
      default:
        this.selectedTabIndex = 0;
        break;
    }
  }

  getSelectedUrl(selectedIndex: number) {
    switch (selectedIndex) {
      case 0:
        return "/projectdetails";
      case 2:
        return "/projectmilestone";
      case 1:
        return "/projectmembers";
      case 3:
        return "/projecttask";
      case 4:
        return "/issuetracker";
      case 5:
        return "/checklist";
      case 6:
        return "/closure";
      case 7:
        return "/approval";
      case 8:
        return "/documents";
      case 9:
        return "/history";
      case 10:
        return "/lessonlearned";
      default:
        return "/projectdetails";
    }
  }


  getMileStoneList() {
    this.httpSer.httpGet('/projectMilestone/getMilestoneByProjectId?id=' + this.projectID).subscribe((response: any) => {
      this.mileStoneList = response.data?.filter((m:any)=>{
        return m.milestoneStatus != 'Completed' && m.milestoneStatus != 'Cancelled'
      });
    })
  }

  
  onTabChange(event: any) {
    this.router.navigate(['projectmanagement' + this.getSelectedUrl(event?.index)], { queryParams: { projectId: this.projectID } });
  }
}