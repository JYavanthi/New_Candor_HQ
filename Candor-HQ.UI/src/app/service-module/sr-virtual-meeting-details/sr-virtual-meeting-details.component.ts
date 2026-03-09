import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

@Component({
  selector: 'app-sr-virtual-meeting-details',
  templateUrl: './sr-virtual-meeting-details.component.html',
  styleUrls: ['./sr-virtual-meeting-details.component.css', '../servicemodule.css']
})

export class SrVirtualMeetingDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  srId: any;
  @Input() srData: any;
  virtualMeetingForm!: FormGroup;
  radioDataList: any = [] = [];
  @Input() currentUrl:any
  requestTypeList: any[] = [];

  constructor(private fb: FormBuilder,public sendEmail:SendEmailServiceService,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute,
    public formValidationService: FormValidationService
  ) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.srId = m.srId
    });
    this.formInit();
  }

  formInit() {
    this.virtualMeetingForm = this.fb.group({
      requestType: [''],

      specifyEmailID: ['', [Validators.required, Validators.email]],
      purposeOrJustification: ['', Validators.required],
      specifyParticipants: ['', [Validators.required, Validators.min(1)]],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required]
    })
    if (!this.srId) {
      this.getRequestType();
    }
  }

  getRequestType() {
    this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: 88 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.virtualMeetingForm.patchValue({ requestType: this.srData.supportId });
      }
    })
  }

  allFieldValues = {
    specifyEmailID: '',
    purposeOrJustification: '',
    specifyParticipants: '',
    startDate: '',
    endDate: ''
  }

  changeRequestTypeValue() {
    this.virtualMeetingForm.patchValue(this.allFieldValues);
  }

  clearAll() {
    this.virtualMeetingForm.patchValue({ requestType: '' });
    this.virtualMeetingForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['srData'] && this.srData != undefined) {
      this.patchFormValues(this.srData)
    }
  }

  patchFormValues(data: any) {
    if (this.srId) {
      this.getRequestType();
    }

    this.virtualMeetingForm.patchValue({
      specifyEmailID: data.emailId || '',
      purposeOrJustification: data.justification || '',
      specifyParticipants: parseInt(data.noParticipants) || '',
      startDate: data.startDt?.split('T')[0] || '',
      endDate: data.endDt?.split('T')[0] || ''
    });

    if (this.srData?.status?.trim() != 'Draft') {
      this.virtualMeetingForm.disable();
    }
  }

  Submit(status: any) {

    if(!this.formValidationService.validateDate(this.virtualMeetingForm.value.startDate,'startDate')){
      return alert('Start Date cannot be less than current date')
    }
    if(!this.formValidationService.validateStartAndEndDate(this.virtualMeetingForm.value.startDate, this.virtualMeetingForm.value.endDate,'startDate','endDate')){
      return alert('End Date cannot be less than Start date')
    }
    let reqData = this.requestTypeList.filter((m:any) => m.supportId == this.virtualMeetingForm.value.requestType)[0]

      if (status == 'Pending Approval') {
        status = (reqData?.isRpmreq &&
          reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
      }
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formValidationService.validateForm(this.virtualMeetingForm)) {
        const apiUrl = '/SRVirtual/PostVirtual';
        const requestBody = {
          "flag": this.srId ? "U" : "I",
          "srid": this.srId ? Number(this.srId) : 0,
          "srvmid": this.srData ? this.srData.srvmid : 0,
          "supportID": Number(this.virtualMeetingForm.get('requestType')?.value),
          "requestType": "",
          "emailID": this.virtualMeetingForm.get('specifyEmailID')?.value,
          "noParticipants": this.virtualMeetingForm.get('specifyParticipants')?.value.toString(),
          "startDt": this.virtualMeetingForm.get('startDate')?.value ? new Date(this.virtualMeetingForm.get('startDate')?.value).toISOString() : null,
          "endDt": this.virtualMeetingForm.get('endDate')?.value ? new Date(this.virtualMeetingForm.get('endDate')?.value).toISOString() : null,
          "location": 0,
          "department": "",
          "justification": this.virtualMeetingForm.get('purposeOrJustification')?.value,
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
            "guestEmployeeId": Number(this.radioDataList?.formValues.guestEmployeeID) || 0,
            "guestName": this.radioDataList?.formValues?.guestName,
            "guestEmail": this.radioDataList?.formValues?.guestEmail,
            "guestContactNo": String(this.radioDataList.formValues?.guestContactNo),
            "grManagerEmpId": this.radioDataList.formValues?.reportingManagerID?.split('-')[0] || '',
            "type": "",
            "guestCompany": "",
            "plantID": this.radioDataList.plantID,
            "assetID": 0,
            "categoryID": 0,
            "categoryTypID": 0,
            "priority": 0,
            "source": "",
            "attachment": '',
            "status": status,
            "assignedTo": 0,
            "assignedBy": 0,
            "assignedOn": "2024-10-16T09:28:59.543Z",
            "remarks": "",
            "proposedResolutionOn": "2024-10-16T09:28:59.543Z",
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
              alert("Submit failed!");
            }
          }
        )
      }
    }
  }

}
