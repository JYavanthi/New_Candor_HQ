import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

interface locationDropdown {
  itemPlant_id: number;
  itemPlant_text: string;
}

@Component({
  selector: 'app-sr-wifi-access-details',
  templateUrl: './sr-wifi-access-details.component.html',
  styleUrls: ['./sr-wifi-access-details.component.css', '../servicemodule.css']
})
export class SrWifiAccessDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  requestTypeList: any
  srId: any
  radioDataList: any;
  wifiForm!: FormGroup
  @Input() currentUrl:any
  attachmentFileName: string = '';
  @Input() srData: any;
  locationList: locationDropdown[] = [];
  locationDropdownSettings = {
    idField: 'itemPlant_id',
    textField: 'itemPlant_text',
  };
  attachMentList=[]

  constructor(private fb: FormBuilder,public sendEmail:SendEmailServiceService,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute,
    public formValidationService: FormValidationService,
    private employeeInfo: GetEmployeeInfoService
  ) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.srId = m.srId
    });
    this.formInit();
  }

  formInit() {
    this.wifiForm = this.fb.group({
      requestType: [''],
      specifyPlant: ['', Validators.required],
      location: ['', Validators.required],
      specifyOfficeGuest: ['', Validators.required],
      fromDate: ['', Validators.required],
      toDate: ['', Validators.required],
      purposeOrJustification: ['', Validators.required],
      attachment: ['']
    });
    if (!this.srId) {
      this.getRequestType();
      this.getPlantDropdown();
    }
  }

  getRequestType() {
    this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: 71 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.wifiForm.patchValue({ requestType: this.srData.supportId })
      }
    })
  }

  async getPlantDropdown() {
    await this.employeeInfo.getPlant();
    this.locationList = this.employeeInfo.plantList.map((item: any) => ({
      itemPlant_id: item.id,
      itemPlant_text: item.code
    }));
    this.wifiForm.patchValue({
      location: this.locationList.filter((m: any) => this.srData?.location.split(',').includes(m.itemPlant_id.toString()))
    })
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['srData']) {
      if (this.srData != undefined) {
        this.getPlantDropdown();
        this.patchFormValues(this.srData)
      }
    }
  }

  patchFormValues(data: any) {
    if (this.srId) {
      this.getRequestType();
    }

    this.wifiForm.patchValue({
      specifyPlant: data.specifyPlant || '',
      specifyOfficeGuest: data.specifyOffice || '',
      fromDate: data.fromDate?.split('T')[0] || '',
      toDate: data.toDate?.split('T')[0] || '',
      purposeOrJustification: data.justification || '',
      attachment: data.attachment || ''
    })
    if (this.wifiForm.get('attachment')?.value) {
      this.attachmentFileName = this.wifiForm.get('attachment')?.value?.split("\\").pop();
    }
    if (this.srData?.status?.trim() != 'Draft') {
      this.wifiForm.disable();
    }
  }


  getAttchmentList(event:any){
    this.attachMentList = event
  }
  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }

  allFieldValues = {
    specifyPlant: '',
    location: '',
    specifyOfficeGuest: '',
    fromDate: '',
    toDate: '',
    purposeOrJustification: '',
    attachment: ''
  }

  changeRequestTypeValue() {
    this.wifiForm.patchValue(this.allFieldValues);
    this.attachmentFileName = ''
  }

  clearAll() {
    this.wifiForm.patchValue({ requestType: '' });
    this.wifiForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  removeAttchment(event:any){
    this.attachMentList=this.attachMentList.filter((m:any)=>m.attachId!=event)
    }
  Submit(status: any) {
    if(!this.formValidationService.validateDate(this.wifiForm.value.fromDate,'fromDate')){
      return alert('Start Date cannot be less than current date')
    }
    if(!this.formValidationService.validateStartAndEndDate(this.wifiForm.value.fromDate, this.wifiForm.value.toDate ,'fromDate','toDate')){
      return alert('End Date cannot be less than Start date')
    }
    let reqData = this.requestTypeList.filter((m:any) => m.supportId == this.wifiForm.value.requestType)[0]

      if (status == 'Pending Approval') {
        status = (reqData?.isRpmreq &&
          reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
      }
      if((this.wifiForm.get('requestType')?.value == 72 || this.wifiForm.get('requestType')?.value == 73)&&this.attachMentList?.length==0&&!this.srId){
          alert('Add Attachment.')
          return
        }
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formValidationService.validateForm(this.wifiForm)) {
        const apiUrl = '/SRWIFIAccess/PostWIFIAccess';
        const requestBody = {
          "flag": this.srId ? "U" : "I",
          "srid": this.srId ? Number(this.srId) : 0,
          "srwifiid": this.srId ? Number(this.srData?.srwifiid) : 0,
          "supportID": Number(this.wifiForm.get('requestType')?.value),
          "requestType": "",
          "specifyPlant": this.wifiForm.get('specifyPlant')?.value,
          "location": this.wifiForm.get('location')?.value ? this.wifiForm.get('location')?.value.map((m: any) => m.itemPlant_id).join() : '',
          "specifyOffice": this.wifiForm.get('specifyOfficeGuest')?.value,
          "fromDate": this.wifiForm.get('fromDate')?.value ? new Date(this.wifiForm.get('fromDate')?.value).toISOString() : null,
          "toDate": this.wifiForm.get('toDate')?.value ? new Date(this.wifiForm.get('toDate')?.value).toISOString() : null,
          "justification": this.wifiForm.get('purposeOrJustification')?.value,
          "description": "",
          "isActive": true,
          "AttachmentIds" : this.attachMentList.map((m:any)=>m.attachId),
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
            "grManagerEmpId": this.radioDataList.formValues?.reportingManagerID?.split('-')[0] || '',
            "type": "",
            "guestCompany": "",
            "plantID": this.radioDataList.plantID,
            "assetID": 0,
            "categoryID": 0,
            "categoryTypID": 0,
            "priority": 0,
            "source": "",
            "attachment": this.wifiForm.get('attachment')?.value || '',
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
