import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

@Component({
  selector: 'app-sr-windows-login-details',
  templateUrl: './sr-windows-login-details.component.html',
  styleUrls: ['./sr-windows-login-details.component.css', '../servicemodule.css']
})
export class SrWindowsLoginDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;
  @Input() srData: any;
  radioDataList: any = [] = [];
  requestTypeList: any = [] = [];
  srId: any
  @Input() currentUrl:any
  raisedForCommonData: any
  windowLoginForm!: FormGroup

  constructor(private fb: FormBuilder,public sendEmail:SendEmailServiceService,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute,
    public formValidationService: FormValidationService
  ) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.srId = m.srId
    });
    this.formInIt();
  }

  updateUserTypeValidators() {
    const requestTypeValue = this.windowLoginForm.get('requestType')?.value;
    if (requestTypeValue == 57) {
      this.windowLoginForm.get('userType1')?.setValidators([Validators.required]);
    } else {
      this.windowLoginForm.get('userType1')?.clearValidators();
    }
    this.windowLoginForm.get('userType1')?.updateValueAndValidity();
  }

  formInIt() {
    this.windowLoginForm = this.fb.group({
      requestType: [''],

      userType1: ['', Validators.required],
      changeOUPath: ['', Validators.required],
      employeeType: ['', Validators.required],
      purposeOrJustification: ['', Validators.required]
    });
    // this.updateUserTypeValidators();
    if (!this.srId) {
      this.getRequestType();
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['srData']) {
      if (this.srData != undefined) {
        this.patchFormValues(this.srData)
      }
    }
  }

  patchFormValues(data: any) {
    if (this.srId) {
      this.getRequestType();
    }

    this.windowLoginForm.patchValue({
      userType1: data.userType || '',
      purposeOrJustification: data.justification || '',
      changeOUPath: data.changeOUPath || '',
      employeeType: data.empType || ''
    })

    if (this.srData?.status?.trim() != 'Draft') {
      this.windowLoginForm.disable();
    }
  }

  getRequestType() {
    this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: 56 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.windowLoginForm.patchValue({ requestType: this.srData.supportId })
      }
    })
  }

  allFieldValues = {
    userType1: '',
    purposeOrJustification: '',
    changeOUPath: '',
    employeeType: ''
  }

  changeRequestTypeValue() {
    this.windowLoginForm.patchValue(this.allFieldValues);
    // this.updateUserTypeValidators();
  }

  clearAll() {
    this.windowLoginForm.patchValue({ requestType: '' });
    this.windowLoginForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }

  Submit(status: any) {
    let reqData = this.requestTypeList.filter((m:any) => m.supportId == this.windowLoginForm.value.requestType)[0]

      if (status == 'Pending Approval') {
        status = (reqData?.isRpmreq &&
          reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
      }
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formValidationService.validateForm(this.windowLoginForm)) {
        const apiUrl = '/SRWindowLogin/PostWindowLogin';
        const requestBody = {
          "flag": this.srId ? "U" : "I",
          "srid": this.srId ? Number(this.srId) : 0,
          "srwlid": this.srId ? Number(this.srData?.srwlid) : 0,
          "supportID": Number(this.windowLoginForm.get('requestType')?.value),
          "requestType": "",
          "empID": 0,
          "date": "2024-11-09T06:25:22.233Z",
          "initials": "",
          "firstName": "",
          "lastName": "",
          "designation": "",
          "plant": 0,
          "payGroup": "",
          "staffCategory": "",
          "department": "",
          "reportingTO": "",
          "hod": "",
          "role": "",
          "userType": this.windowLoginForm.get('userType1')?.value,
          "changeOUPath": this.windowLoginForm.get('changeOUPath')?.value,
          "justification": this.windowLoginForm.get('purposeOrJustification')?.value,
          "eidIndividual": "2024-11-09T06:25:22.233Z",
          "userID": "",
          "empType": this.windowLoginForm.get('employeeType')?.value,
          "description": "",
          "isActive": true,
          "srVariable": {
            "srCode": "",
            "srRaisedBy": Number(this.radioDataList.selfEmployeeID),
            "srDate": new Date().toISOString(),
            "srShotDesc": "",
            "srDesc": "",
            "srRaiseFor": this.radioDataList.serviceRaisedFor,
            "srSelectedfor": this.radioDataList.formValues?.userType,
            "guestEmployeeId": Number(this.radioDataList?.formValues?.guestEmployeeID) || 0,
            "guestName": this.radioDataList?.formValues?.guestName,
            "guestEmail": this.radioDataList?.formValues?.guestEmail,
            "guestContactNo": String(this.radioDataList.formValues?.guestContactNo),
            "grManagerEmpId": this.radioDataList.formValues.reportingManagerID?.split('-')[0] || '',
            "type": "",
            "guestCompany": "",
            "plantID": this.radioDataList.plantID,
            "assetID": 0,
            "categoryID": 0,
            "categoryTypID": 0,
            "priority": 0,
            "source": "",
            "attachment": "",
            "status": status,
            "assignedTo": 0,
            "assignedBy": 0,
            "assignedOn": "2024-11-09T06:25:22.233Z",
            "remarks": "",
            "proposedResolutionOn": "2024-11-09T06:25:22.233Z",
            "createdBy": Number(this.radioDataList.selfEmployeeID)
          }
        }
        this.httpSer.httpPost(apiUrl, requestBody).subscribe(
          (response: any) => {
            if (response.type == 'S') {
              if (status == "Draft") {
                alert("Saved as a Draft Successfully!");
                this.router.navigate(['/services/servicemaster']);
              }
              else {
                alert("Submitted Successfully!");
                this.sendEmail.getData(response?.data?.srId,this.currentUrl)
                this.router.navigate(['/services/servicemaster']);
              }
            } else {
              alert("Submit Failed!");
            }
          }
        )
      }
    }
  }

}
