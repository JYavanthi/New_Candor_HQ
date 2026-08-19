import { Component, Input, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-sr-common-approvetab',
  templateUrl: './sr-common-approvetab.component.html',
  styleUrl: './sr-common-approvetab.component.css'
})

export class SrCommonApprovetabComponent {
  @Input() srData: any
  @Input() data: any
  @Input() apprName: any
  user: any
  @Input() apprId: any
  @Input() Status: any
  @Input() sameRpmNhod: any
  @Input() isAsset: any
  @Input() isSpare: any


  approverData: any;
  currentDate: string;
  remarks: any
  approvedData: any;
  apprvedDate: any
  approverForm: FormGroup

  constructor(public httpSer: HttpServiceService, public fb: FormBuilder, public userInfo: UserInfoSerService,
    public router: Router
  ) {
    const today = new Date();
    this.user = this.userInfo.getUser()
    const yyyy = today.getFullYear();
    const mm = String(today.getMonth() + 1).padStart(2, '0');
    const dd = String(today.getDate()).padStart(2, '0');

    this.currentDate = `${yyyy}-${mm}-${dd}`;
    this.apprvedDate = this.currentDate

    this.approverForm = this.fb.group({
      apprvedDate: [''],
      remarks: ['']
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['srData']) {
      if (this.srData != undefined) {
        this.getApprovedData()
      }
      this.approverForm.patchValue({
        remarks: this.Status == 'Pending Approval'?this.srData?.rpmApproverRemarks:this.srData?.hodApproverRemarks
      })
    }
    if (changes['apprId']) {
      // if (!((this.srData?.status.trim() == this.Status
      //  || (!this.sameRpmNhod && this.srData?.status?.trim() == 'Pending Approval')) &&
      if((this.srData?.status?.trim()==this.Status||this.sameRpmNhod&&this.srData?.status?.trim()=='Pending Approval')&&
      (this.user?.empData?.employeeNo==this.apprId?.toString()||((this.srData?.guestReportingManagerEmployeeId?.toString()==this.user?.empData?.employeeNo||
      this.srData?.guestRmanagerId?.toString()==this.user?.empData?.employeeNo)&&(this.srData?.srselectedfor=='guest'||this.srData?.selectedFor=='guest'))))
        {
          this.approverForm.enable()
      } else {
        this.approverForm.disable()
      }
    }
  }


  approve(rejected = false, message: any) {
    if(!this.approverForm.value.remarks){
       return alert("Enter Remarks!");
    }
    let param1={
      "flag": this.isSpare?"S":"A",
      "itAssetID": this.srData?.itassetId || 0 ,
      "itSpareID":this.srData?.itspareId || 0,
      "ishod": !(this.Status == 'Pending Approval'),
      "isrpm": this.Status == 'Pending Approval',
      "hoD_ApproverID": Number(this.apprId),
      "hoD_ApproverRemarks": this.Status != 'Pending Approval'?this.approverForm.value.remarks:'',
      "rpM_ApproverID": Number(this.apprId),
      "rpM_ApproverRemarks": this.Status == 'Pending Approval'?this.approverForm.value.remarks:'',
      "status": rejected ? 'Rejected' : (this.Status == 'Pending Approval' ? 'Pending HOD Approval' : 'Approved'),
      "createdBy": this.apprId
    }
    let param = {
      "flag": "I",
      "srApproverID": 0,
      "plantID": 0,
      "supportID": 0,
      "srid": this.srData?.srid,
      "approverLevel": 0,
      "stage": 0,
      "approverID": 0,
      "approvedDt": new Date().toISOString(),
      "remarks": this.approverForm.value.remarks,
      "status": rejected ? 'Rejected' : (this.Status == 'Pending Approval' ? 'Pending HOD Approval' : 'Approved'),
      "attachment": "string",
      "createdBy": this.srData?.srselectedfor=='guest'?(this.srData?.guestReportingManagerEmployeeId):this.apprId,
      "createdDt": new Date().toISOString(),
      "modifiedBy": this.srData?.srselectedfor=='guest'?(this.srData?.guestReportingManagerEmployeeId):this.apprId,
      "modifiedDt": new Date().toISOString()
    }

    if(!this.isAsset){

    this.httpSer.httpPost('/SRApprover/PostApprover', param).subscribe((res: any) => {
      if (res.type == 'S') {
        alert(message + " successfully!")
        this.router.navigate(['/services/servicemaster'])
      }
    })
    }else{


    this.httpSer.httpPost('/AssetRequest/SaveApprover', param1).subscribe((res: any) => {
        alert(message + " successfully!")
        this.router.navigate([this.isSpare?'/assets/sparemaster':'/assets/assetmaster'])
    })
    }
  }

  getApprovedData() {
    if(!this.srData?.srid){
      return
    }
    this.httpSer.httpGet('/serviceMaster/getSRApproved', { srId: this.srData?.srid }).subscribe(
      (response: any) => {
        this.approverData = response?.data

        if ((this.srData?.status.trim() == this.Status || this.sameRpmNhod)) {
          this.approverForm.patchValue({
            remarks: this.approverData[0]?.remarks
          })
        } else {
          this.approverForm.patchValue({
            remarks: this.approverData[1]?.remarks
          })
        }
      }
    )
  }
}
