import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

@Component({
  selector: 'app-sr-backup-and-restoration-details',
  templateUrl: './sr-backup-and-restoration-details.component.html',
  styleUrls: ['./sr-backup-and-restoration-details.component.css', '../servicemodule.css']
})
export class SrBackupAndRestorationDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  @Input() srData: any;
  requestTypeList: any;
  srId: any
  radioDataList: any;
  backUpForm!: FormGroup
  @Input() currentUrl:any
  submit:any

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
    this.backUpForm = this.fb.group({
      requestType: [''],
      selectType: ['', Validators.required],
      provideDescriptions: ['', Validators.required],
      dateInput: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      specifyDevice: ['', Validators.required],
      restorationDatePreference: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
    if (!this.srId) {
      this.getRequestType();
    }
  }

  getRequestType() {
    this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: 77 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.backUpForm.patchValue({ requestType: this.srData.supportId })
      }
    })
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
    this.backUpForm.patchValue({
      selectType: data.ots != '' ? data.ots == 'One-time' ? 'Yes' : 'No' : '',
      provideDescriptions: data.provideDescription || '',
      dateInput: data.date?.split('T')[0] || null,
      startDate: data.startDate?.split('T')[0] || null,
      endDate: data.endDate?.split('T')[0] || null,
      specifyDevice: data.transferingData || '',
      restorationDatePreference: data.restoration?.split('T')[0] || null,
      email: data?.requestType,
      
    })

    if (this.srData?.status?.trim() != 'Draft') {
      this.backUpForm.disable();
    }
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }

  allFieldValues = {
    selectType: '',
    provideDescriptions: '',
    dateInput: '',
    startDate: '',
    endDate: '',
    specifyDevice: '',
    restorationDatePreference: ''
  }

  changeRequestTypeValue() {
    this.backUpForm.patchValue(this.allFieldValues);
  }

  clearAll() {
    this.backUpForm.patchValue({ requestType: '' });
    this.backUpForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  Submit(status: any) {

    if(!this.formValidationService.validateDate(this.backUpForm.value.startDate,'startDate')){
      return alert('Start Date cannot be less than current date')
    }
    if(!this.formValidationService.validateStartAndEndDate(this.backUpForm.value.startDate, this.backUpForm.value.endDate,'startDate','endDate' )){
      return alert('End Date cannot be less than Start date')
    }
    this.submit = true
    let reqData = this.requestTypeList.filter((m:any) => m.supportId == this.backUpForm.value.requestType)[0]

    if (status == 'Pending Approval') {
      status = (reqData?.isRpmreq &&
        reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
    }
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formValidationService.validateForm(this.backUpForm)) {
        const apiUrl = '/SRRestoration/PostRestoration';
        const requestBody = {
          "flag": this.srId ? "U" : "I",
          "srid": this.srId ? Number(this.srId) : 0,
          "srrid": this.srId ? Number(this.srData?.srrid) : 0,
          "supportID": Number(this.backUpForm.get('requestType')?.value),
          "requestType": this.backUpForm.get('email')?.value,
          "ots": this.backUpForm.get('selectType')?.value == 'Yes' ? 'One-time' : 'Schedule',
          "descriptions": '',
          "date": this.backUpForm.get('dateInput')?.value ? new Date(this.backUpForm.get('dateInput')?.value).toISOString() : null,
          "startDate": this.backUpForm.get('startDate')?.value ? new Date(this.backUpForm.get('startDate')?.value).toISOString() : null,
          "endDate": this.backUpForm.get('endDate')?.value ? new Date(this.backUpForm.get('endDate')?.value).toISOString() : null,
          "provideDescription": this.backUpForm.get('provideDescriptions')?.value,
          "restoration": this.backUpForm.get('restorationDatePreference')?.value ? new Date(this.backUpForm.get('restorationDatePreference')?.value).toISOString() : null,
          "transferingData": this.backUpForm.get('specifyDevice')?.value,
          "isActive": true,
          "srVariable": {
            "srCode": "",
            "srRaisedBy": Number(this.radioDataList?.selfEmployeeID),
            "srDate": new Date().toISOString(),
            "srShotDesc": "",
            "srDesc": "",
            "srRaiseFor": this.radioDataList.serviceRaisedFor,
            "srSelectedfor": this.radioDataList.formValues?.userType,
            "guestEmployeeId": Number(this.radioDataList.formValues?.guestEmployeeID) || 0,
            "guestName": this.radioDataList.formValues?.guestName,
            "guestEmail": this.radioDataList.formValues?.guestEmail,
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
            "assignedOn": "2024-11-09T11:17:56.677Z",
            "remarks": "",
            "proposedResolutionOn": "2024-11-09T11:17:56.677Z",
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
