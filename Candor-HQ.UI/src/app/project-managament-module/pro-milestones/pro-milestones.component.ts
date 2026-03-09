import { Component, Input, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { parse } from 'path/posix';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-pro-milestones',
  templateUrl: './pro-milestones.component.html',
  styleUrls: ['./pro-milestones.component.css', '../promanagement.css']
})

export class ProMilestonesComponent {

  milestoneForm!: FormGroup
  @Input() proData: any;
  loggedInUserDetails: any;
  projectID: any;
  milestoneList: any;
  milestoneID: any;
  allMilestoneList : any;
  isOpenIssues = true;
  paginatedTableData: any
  taskListData:any
  pageSize = 5
  pageIndex = 0
  paginatedData: any;
  projectdetails:any

  constructor(private fb: FormBuilder,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute,
    public formValidationService: FormValidationService,
    public userInfo: UserInfoSerService
  ) {
    this.loggedInUserDetails = this.userInfo.getUser();
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.projectID = m.projectId;
      this.getMilestones(this.projectID);
    });
    this.getProjectDetails()
    this.getParentTaskList()
  }

  navigateToAdd(projectID: any) {
    this.router.navigate(['projectmanagement/projectmilestone/add'], { queryParams: { projectId: projectID } });
  }

  navigateToView(projectID: any, milestoneId: any) {
    this.router.navigate(['projectmanagement/projectmilestone/add'], { queryParams: { projectId: projectID, milestoneId: milestoneId } });
  }

  getMilestones(projectID: any) {
    this.httpSer.httpGet('/projectMilestone/getMilestoneByProjectId', { id: Number(projectID) }).subscribe((response: any) => {
      this.allMilestoneList = response.data;
      this.milestoneID = this.allMilestoneList.projMilestoneId;
      this.filterMilestoneList('Pending');

    })
  }

  filterMilestoneList(status: string) {
    if (status == 'Pending') {
        this.milestoneList =''
      this.isOpenIssues = true
      this.milestoneList = this.allMilestoneList?.filter((m: any) => m.milestoneStatus != 'Cancelled' && m.milestoneStatus != 'Completed')
    }
    if (status == 'Closed') {
      this.milestoneList =''
      this.isOpenIssues = false
      this.milestoneList = this.allMilestoneList.filter( (m:any) => m.milestoneStatus == 'Completed'  || m.milestoneStatus == 'Cancelled')
    }
    this.onPageChange(undefined, true)
  }

  onPageChange(event: any, defaultPage: any) {
    if (defaultPage) {
      this.paginatedData = this.milestoneList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
    }
    else {
      this.pageIndex = event?.pageIndex;
      this.pageSize = event?.pageSize;
      this.paginatedData = this.milestoneList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)

    }
  }
  

  
  getParentTaskList() {
    this.httpSer.httpGet('/projectTask/getTask?proId=' + this.projectID).subscribe((response: any) => {
      this.taskListData = response.data;
    })
  }
  
  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.projectID }).subscribe((response: any) => {
      this.projectdetails = response.data;
    })
  }
  delete(milestonID: any) {
    let relatedTask = this.taskListData.filter(a=>a.milestoneId==milestonID&&a.status!="Completed")

    if(relatedTask?.length>0){
      alert("Milestone can't be deleted,as there are associated Tasks")
      return
    }
    this.httpSer.httpGet('/projectMilestone/DeleteMilestoneById', { milestoneId: milestonID }).subscribe((res: any) => {
      alert('Milestone Deleted Successfully.')
      
      this.milestoneList = this.milestoneList.filter((m: any) => m.projMilestoneId != milestonID)
      this.getMilestones(this.projectID);
    })
  }
}
