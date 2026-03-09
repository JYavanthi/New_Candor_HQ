import { Component, Input, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-pro-issue-tracker',
  templateUrl: './pro-issue-tracker.component.html',
  styleUrls: ['./pro-issue-tracker.component.css', '../promanagement.css']
})

export class ProIssueTrackerComponent {
  issueTrackerForm!: FormGroup;
  @Input() proData: any;
  projectId:any
  issueList:any
  projectdetails:any

  constructor(private fb: FormBuilder,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute,
  ) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.projectId = m['projectId'];
    });
  }


  ngOnInit() {
    this.getIssueList()
    this.getProjectDetails()
  }

  getIssueList() {
    this.httpSer.httpGet('/projectIssue/getProIssueByProId' ,{id :  this.projectId}).subscribe((response: any) => {
      this.issueList = response.data;
    })
  }

  navigateTo(id=null){
    this.router.navigate(['/projectmanagement/issuetracker/add'], { queryParams: { projectId: this.projectId,issueId:id?id:''}})
  }

  
  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', {id :  this.projectId}).subscribe((response: any) => {
      this.projectdetails = response.data;
      // if(this.projectdetails?.projectStatus=='Cancel'||this.projectdetails?.projectStatus=='Discontinue'||this.projectdetails?.projectStatus=='Completed'){
      //   this.issueForm.disable()
      // }
    })
  }

  deleteIssue(issueId: number){
    this.httpSer.httpGet('/projectIssue/deleteProjectIssueById?issueId='+ issueId).subscribe((res: any)=> {
      alert('Deleted Successfully');
      this.issueList = this.issueList.filter((m : any)=> m.issueId != issueId);
    })
  }
}
