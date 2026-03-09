import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-pro-approver',
  templateUrl: './pro-approver.component.html',
  styleUrl: './pro-approver.component.css'
})
export class ProApproverComponent {
  approverForm: any
  approverForm1: any
  projectdetails: any
  projectID: any
  loggedInUserDetails: any
  selectedTabIndex: any = 0
  constructor(public fb: FormBuilder, public httpSer: HttpServiceService, public router: Router,
    public activeRoute: ActivatedRoute, public userInfoSer: UserInfoSerService
  ) {
    this.formInit()

    this.activeRoute.queryParams.subscribe((m: any) => {
      this.projectID = m.projectId;
      if (this.projectID) {
        this.getProjectDetails();
      }
    });
    this.loggedInUserDetails = this.userInfoSer.getUser()
  }

  formInit() {
    this.approverForm = this.fb.group({
      apprvedDate: [''],
      remarks: ['']
    });

    this.approverForm1 = this.fb.group({
      apprvedDate: [''],
      remarks: ['']
    });
     
  }

  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.projectID }).subscribe((response: any) => {
      this.projectdetails = response.data;
      if (this.projectdetails?.status == 'Pending Sponsor Approval') {
        this.selectedTabIndex = 1
      }
      if (this.projectdetails?.approver1Remark) {
        this.approverForm.patchValue({
          remarks: this.projectdetails?.approver1Remark
        })
        this.approverForm.disable()
      }
      if (
        this.projectdetails?.projectOwner.toString() == this.loggedInUserDetails.empData.employeeNo
        && (this.projectdetails.projectStatus == 'Discontinue'
          || this.projectdetails.projectStatus == 'Cancel'
          || this.projectdetails.projectStatus == 'Completed')) {
        this.approverForm.enable()
      }
      if (this.projectdetails?.approver2Remark) {
        this.approverForm1.patchValue({
          remarks: this.projectdetails?.approver2Remark
        })
        this.approverForm1.disable()
      }
      if (this.projectdetails?.projectStatus == 'Approved'
      ) {
        this.approverForm1.disable()
        this.approverForm.disable()
      }
      if (this.projectdetails?.sponser.toString() == this.loggedInUserDetails.empData.employeeNo
        && this.projectdetails.projectStatus == 'Pending Sponsor Approval') {
        this.approverForm1.enable()
      }
    })
  }

 remarks: any;
  approve(status: any, flag: any) {
    this.remarks=this.approverForm.value.remarks;
    if(this.remarks == ''){
      alert('Enter Remarks');
      return;
    }

     let requestBody = {
      "flag": flag,
      "projectMgmtID": this.projectID,
      "supportID": 0,
      "projectName": "string",
      "status": status,
      "projectDesc": "string",
      "projectOwner": 0,
      "startDt": "2025-03-06T02:51:48.353Z",
      "endDt": "2025-03-06T02:51:48.353Z",
      "actualStartDt": "2025-03-06T02:51:48.353Z",
      "actualEndDt": "2025-03-06T02:51:48.353Z",
      "isActive": true,
      "estimateHrs": 0,
      "estimateCost": 0,
      "actualHrs": 0,
      "actualCost": 0,
      "createdBy": parseInt(this.loggedInUserDetails.empData.employeeNo),
      "createdDt": "2025-03-06T02:51:48.353Z",
      "modifiedBy": 0,
      "modifiedDt": "2025-03-06T02:51:48.353Z",
      "planId": 0,
      "sponser": 0,
      "projectGroupId": 0,
      "projectAccess": "string",
      "deliverables": "string",
      "additionalNotes": "string",
      "approver1Remark": this.approverForm.value.remarks,
      "approver2Remark": "string",
      "attachmentIds": [
        0
      ],
      "delivarables": [
        "string"
      ]
    }

    this.httpSer.httpPost('/projectManagement/saveProjectMaster', requestBody).subscribe((response: any) => {
      if (response.type = 'S') {
        alert('Submitted Successfully!')
        this.router.navigate(['/projectmaster'])
      } else {
        alert('Submit failed')
      }
    })
  }

  approve1(status: any, flag: any) {

    this.remarks=this.approverForm1.value.remarks;
    if(this.remarks == ''){
      alert('Enter Remarks');
      return;
    }
     let requestBody = {
      "flag": flag,
      "projectMgmtID": this.projectID,
      "supportID": 0,
      "projectName": "string",
      "status": status,
      "projectDesc": "string",
      "projectOwner": 0,
      "startDt": "2025-03-06T02:51:48.353Z",
      "endDt": "2025-03-06T02:51:48.353Z",
      "actualStartDt": "2025-03-06T02:51:48.353Z",
      "actualEndDt": "2025-03-06T02:51:48.353Z",
      "isActive": true,
      "estimateHrs": 0,
      "estimateCost": 0,
      "actualHrs": 0,
      "actualCost": 0,
      "createdBy": parseInt(this.loggedInUserDetails.empData.employeeNo),
      "createdDt": "2025-03-06T02:51:48.353Z",
      "modifiedBy": 0,
      "modifiedDt": "2025-03-06T02:51:48.353Z",
      "planId": 0,
      "sponser": 0,
      "projectGroupId": 0,
      "projectAccess": "string",
      "deliverables": "string",
      "additionalNotes": "string",
      "approver1Remark": this.approverForm1.value.remarks,
      "approver2Remark": this.approverForm1.value.remarks,
      "attachmentIds": [
        0
      ],
      "delivarables": [
        "string"
      ]
    }

    this.httpSer.httpPost('/projectManagement/saveProjectMaster', requestBody).subscribe((response: any) => {
      if (response.type = 'S') {
        alert('Submitted Successfully!')
        this.router.navigate(['/projectmaster'])
      } else {
        alert('Submit failed')
      }
    })
  }
  
}