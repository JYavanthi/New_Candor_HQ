import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';



@Component({
  selector: 'app-sr-resolution',
  templateUrl: './sr-resolution.component.html',
  styleUrls: ['./sr-resolution.component.css', '/src/app/asset-module/assetmodule.css'],
  animations: [
    trigger('expandCollapseAnimation', [
      state('void', style({
        height: '0',
        opacity: '0'
      })),
      state('*', style({
        height: '*',
        opacity: '1'
      })),
      transition('void <=> *', animate('300ms ease-out')),
    ])
  ]
})
export class SrResolutionComponent {
  @Input() srData: any;
  @Input() assetData: any;
  @Input() isAsset!: boolean;
  @Input() isSpare = false;
  user: any;
  onHoldReason: any;
  onHoldDropDown = false;
  assignToList: any;
  assignToDropDown = false;
  isSuperAdmin: any
  isEngineer: any
  presentTime = new Date().toISOString().slice(0, 16);
  history: any
  srId: any

  resolutionForm!: FormGroup;
  isUpdateSidebarVisible = false;
  API_URLS = {
    SUBMIT_RESOLUTION: '/serviceMaster/submitResolution',
    ON_HOLD: '/Classification/getHoldOnReason',
    ASSIGN_TO: '/SupportTeam',
    GET_SR_RESOLUTION: '/serviceMaster/getSRResolution',
    submitAsset_RESOLUTION: '/AssetRequest/SaveResolution',

  }

  constructor(private fb: FormBuilder, private userInfo: UserInfoSerService, public activeRoute: ActivatedRoute,
    public router: Router, public httpSer: HttpServiceService,
    public validationSer: FormValidationService) {
    this.user = this.userInfo.getUser()
    this.isSuperAdmin = this.user.supportTeamAssignList.filter((m: any) => m.isSuperAdmin && m.isActive).length > 0


    this.activeRoute.queryParams.subscribe((m: any) => {
      this.isEngineer = m.isEngineer == 'true'
    });

    this.activeRoute.queryParamMap.subscribe(param => {
      if (param.get('srId')) {
        this.srId = param.get('srId');
      }
    })
  }

  ngOnInit() {
    this.resolutionFormFunc();
    this.getOnHoldReason();
    this.getComments()
  }

  ngOnChanges() {
    if (this.srData && (this.srData?.status == 'In Progress' || this.srData?.status == 'Seek Clarification' || this.srData?.status == 'On Hold' || this.srData?.status == 'Resolved' ||
      this.srData?.status == 'Submit Clarification')) {
      this.getSrResolution();
      this.getReasonList()
    }
  }

  resolutionFormFunc() {
    this.resolutionForm = this.fb.group({
      remarks: [''],
      proposedResDate: [''],
      resolutionDate: [''],
      onHold: [0],
      assign: [''],
      extimateResolutionDate: [this.presentTime]
    })
    this.resolutionForm.controls['extimateResolutionDate'].disable();
  }

  toggleUpdateSidebar() {
    this.isUpdateSidebarVisible = !this.isUpdateSidebarVisible;
  }

  getSrResolution() {
    let param = {
      srId: this.srData.srid
    }
    this.httpSer.httpGet(this.API_URLS.GET_SR_RESOLUTION, param).subscribe((response: any) => {
      this.resolutionForm.controls['proposedResDate'].setValue(response.data[0].proposedResolDt)
      this.resolutionForm.controls['proposedResDate'].disable()
    })
  }

  getAssignto() {
    this.assignToDropDown = !this.assignToDropDown
    if (this.assignToDropDown == true) {
      this.resolutionForm.controls['assign'].setValue('')
      this.httpSer.httpGet(this.API_URLS.ASSIGN_TO).subscribe((response: any) => {
        let a = response.filter((m: any) => m.supportId == this.srData?.supportId || m.isSuperAdmin)
        this.assignToList = a.filter((m: any, i: any) => a.map((x: any) => x.empId).indexOf(m.empId) == i);
      })
    }
  }
  getOnHoldReason() {
    this.httpSer.httpGet(this.API_URLS.ON_HOLD).subscribe((response: any) => {
      this.onHoldReason = response;
    })
  }

  resolveService(status: string, succMessage: string) {

    if (status == 'In Progress' && !this.validationSer.validateDate(this.resolutionForm?.value?.proposedResDate, 'proposedResDate')) {
      alert('Proposed Resolution Date cant be less than currnet date.')
      return
    }
    if (status == 'In Progress' && this.resolutionForm?.value?.proposedResDate == "") {
      alert('Select Resolution Date.')
      return
    }
    if (status != 'Open' && status != 'In Progress' && (!this.resolutionForm?.value?.remarks || this.resolutionForm?.value?.remarks == '')) {
      alert('Enter Resolution Remark.')
      return
    }

    if (status == "On Hold" && !this.resolutionForm.controls['onHold'].value) {
      alert('Select On Hold Reason');
      return;
    }
    const requestBody = {
      "flag": "I",
      "srResolID": 0,
      "srid": this.srData?.srid,
      "resolRemarks": this.user.supportTeamAssignList.filter((m: any) => m.supportTeamId > 0).length > 1 ? this.resolutionForm.value.remarks : "",
      "userRemarks": this.user.supportTeamAssignList.filter((m: any) => m.supportTeamId > 0).length < 1 ? this.resolutionForm.value.remarks : "",
      "proposedResolDt": this.resolutionForm?.value.extimateResolutionDate ? this.resolutionForm?.value.extimateResolutionDate : "2024-10-16T09:28:59.543Z",
      "resolDt": this.resolutionForm?.value.resolutionDate ? this.resolutionForm?.value.resolutionDate : "2024-10-16T09:28:59.543Z",
      "description": "",
      "onHoldReason": this.resolutionForm?.value.onHold,
      "status": status,
      "createdBy": Number(this.user?.empData?.employeeNo),
      "createdDt": new Date().toISOString(),
      "modifiedBy": Number(this.user?.empData?.employeeNo),
      "modifiedDt": new Date().toISOString(),
      "empNo": this.srData?.memberAdded,
      "supportId": this.srData?.supportId
    }

    let param = {
      "flag": this.isSpare ? "S" : "A",
      "itAssetID": !this.isSpare ? this.srData?.itassetId : 0,
      "itSpareID": this.isSpare ? this.srData?.itspareId : 0,
      "userRemarks": '',
      "proposedResolDt": this.resolutionForm?.value.extimateResolutionDate ? this.resolutionForm?.value.extimateResolutionDate : "2024-10-16T09:28:59.543Z",
      "resolDt": this.resolutionForm?.value.resolutionDate ? this.resolutionForm?.value.resolutionDate : "2024-10-16T09:28:59.543Z",
      "description": "string",
      "onHoldReason": this.resolutionForm?.value.onHold,
      "remarks": (status != 'Open' ? (this.resolutionForm.value.remarks == null ? '' : this.resolutionForm.value.remarks) : this.srData?.resolRemarks) || '',
      "assignedTo": status == 'Open' ? Number(this.resolutionForm.value.assign) : (this.srData?.assignedTo || ''),
      "assignedBy": status == 'Open' ? Number(this.resolutionForm.value.assign) : (this.srData?.assignedTo || ''),
      "status": status,
      "createdBy": Number(this.user?.empData?.employeeNo)
    }
    this.httpSer.httpPost(this.isAsset ? this.API_URLS.submitAsset_RESOLUTION : this.API_URLS.SUBMIT_RESOLUTION,
      this.isAsset ? param : requestBody).subscribe((response: any) => {
        if (response?.type == 'S') {
          alert(succMessage + " Successfully!");
          if (this.isAsset) {

            this.router.navigate([this.isSpare ? 'assets/sparemaster' : '/assets/assetmaster'])
          } else {

            this.router.navigate(['/services/servicemaster'])
          }
        }
        else {
          alert("Resolve Falied!")
        }
      }
      )


  }
  assignTo(status: string, message: string) {
    if (this.isAsset) {
      this.resolveService(status, message)
      return
    }
    const requestBody = {
      "srid": this.srData?.srid,
      "assignedBy": this.user?.empData?.employeeNo,
      "assignedTo": this.resolutionForm.value.assign,
      "modifiedBy": this.user?.empData?.employeeNo,
      "status": status
    }
    this.httpSer.httpPost('/serviceMaster/srAssignTo', requestBody).subscribe((response: any) => {
      if (response?.type == 'S') {
        alert(message + ' ' + 'Successfully!');
        this.router.navigate(['/services/servicemaster'])
      }
      else {
        alert("Assign Falied!")
      }
    })

  }

  getReasonList() {
    this.httpSer.httpGet('/Classification/getHoldOnReason', { supportId: this.srData?.supportId }).subscribe(
      (response: any) => {
        this.onHoldReason = response
      },
      (error) => {
      }
    )
  }

  
  onHold() {
    this.onHoldDropDown = !this.onHoldDropDown;
  }


  getComments() {
    if (!this.srId) {
      return
    }
    this.httpSer.httpGet('/serviceMaster/getSRResolution', { srId: this.srId }).subscribe((res: any) => {
      this.history = res?.data;
    })
  }
}
