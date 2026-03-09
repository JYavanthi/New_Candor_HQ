import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

@Component({
  selector: 'app-sr-url-or-internet-access-details',
  templateUrl: './sr-url-or-internet-access-details.component.html',
  styleUrls: ['./sr-url-or-internet-access-details.component.css', '../servicemodule.css']
})
export class SrUrlOrInternetAccessDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  urlAccessForm!: FormGroup;
  @Input() currentUrl:any
  @Input() srData: any;
  radioDataList: any;
  requestTypeList: any[] = [];
  srId: any;
  assetDetails: any;


  API_URLS = {
    GET_REQUEST_TYPE: '/SupportMaster/GetParentValue',
    SAVE_URL_ACCESS: '/SRURLAccess/PostURLAccess'
  }

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

  ngOnChanges(changes: SimpleChanges) {
    if (changes['srData']) {
      if (this.srData) {
        this.patchFormValues(this.srData)
      }
    }
  }

  patchFormValues(data: any) {
    if (this.srId) {
      this.getRequestType();
    }
    this.urlAccessForm.patchValue({
      hostName: data?.hostName,
      ipAddress: data?.ipAddress,
      urlRequired: data?.urlRequired,
      empType: data?.empType,
      purpose: data?.justification
    })
    if (data?.status.trim() != "Draft") {
      this.urlAccessForm.disable()
    }
  }

  formInit() {
    this.urlAccessForm = this.fb.group({
      requestType: ['', Validators.required],
      hostName: ['', Validators.required],
      ipAddress: ['', Validators.required],
      urlRequired: ['', Validators.required],
      empType: ['', Validators.required],
      purpose: ['', Validators.required]
    });
    if (!this.srId) {
      this.getRequestType();
    }
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
    this.getAssetDetails();
  }

  allFieldValues = {
    hostName: '',
    ipAddress: '',
    urlRequired: '',
    empType: '',
    purpose: ''
  }

  changeRequestTypeValue() {
    this.urlAccessForm.patchValue(this.allFieldValues);
    this.getAssetDetails();
  }

  submit(status: string) {
    let reqData = this.requestTypeList.filter((m:any) => m.supportId == this.urlAccessForm.value.requestType)[0]

      if (status == 'Pending Approval') {
        status = (reqData?.isRpmreq &&
          reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
      }
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formValidationService.validateForm(this.urlAccessForm)) {
        const requestBody = {
          "flag": this.srId ? 'U' : 'I',
          "srid": this.srId ? this.srId : 0,
          "srurlid": this.srData ? this.srData.srurlid : 0,
          "supportID": Number(this.urlAccessForm?.value.requestType),
          "requestType": "",
          "hostName": this.urlAccessForm.value.hostName,
          "ipAddress": this.urlAccessForm.controls['ipAddress'].value,
          "urlRequired": this.urlAccessForm.value.urlRequired,
          "empType": this.urlAccessForm.value.empType,
          "justification": this.urlAccessForm.value.purpose,
          "description": "",
          "isActive": true,
          "srVariable": {
            "srCode": "",
            "srRaisedBy": Number(this.radioDataList.selfEmployeeID),
            "srDate": new Date().toISOString().slice(0, 10),
            "srShotDesc": "",
            "srDesc": "",
            "srRaiseFor": this.radioDataList.serviceRaisedFor,
            "srSelectedfor": this.radioDataList.formValues?.userType,
            "guestEmployeeId": this.radioDataList?.formValues?.guestEmployeeID || 0,
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
            "assignedOn": "2024-11-07T07:14:35.103Z",
            "remarks": "",
            "proposedResolutionOn": "2024-11-07T07:14:35.103Z",
            "createdBy": Number(this.radioDataList.selfEmployeeID)
          }
        }

        this.httpSer.httpPost(this.API_URLS.SAVE_URL_ACCESS, requestBody).subscribe((response: any) => {
          if (response.type == 'S') {
            if (status == "Draft") {
              alert("URL/Internet Access Saved as a Draft")
            } else {
              this.sendEmail.getData(response?.data?.srId,this.currentUrl)
              alert("URL/Internet Access Submitted Successfully!");
            }
            this.router.navigate(['/services/servicemaster']);
          } else {
            alert("Submit Failed!");
          }
        })
      }
    }
  }

  clearAll() {
    this.urlAccessForm.patchValue({ requestType: '' });
    this.urlAccessForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  getRequestType() {
    this.httpSer.httpGet(this.API_URLS.GET_REQUEST_TYPE, { ParentID: 68 }).subscribe((data: any) => {
      this.requestTypeList = data;
      if (this.srId) {
        this.urlAccessForm.patchValue({ requestType: this.srData?.supportId })
      }
    })
  }

  getAssetDetails() {
    if(this.radioDataList.serviceRaisedFor==0){
      return
    }
    this.httpSer.httpGet('/SRUSBAccess/GetAssetDetails', { Empno: String(this.radioDataList.serviceRaisedFor) }).subscribe((response: any) => {
      this.assetDetails = response.data;
    })
  }

  selectDetails(event:any){
    // let data=this.assetDetails[event.target.selectedIndex]
    let data = this.assetDetails.filter( (m : any)=> m.assetNo ==  this.urlAccessForm.value.hostName)
    this.urlAccessForm.patchValue({
      ipAddress: data[0]?.ipAddress
    })
    this.urlAccessForm.controls['ipAddress'].disable()
  }

}
