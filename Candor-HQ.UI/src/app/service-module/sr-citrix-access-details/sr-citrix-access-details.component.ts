import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

@Component({
  selector: 'app-sr-citrix-access-details',
  templateUrl: './sr-citrix-access-details.component.html',
  styleUrls: ['./sr-citrix-access-details.component.css', '../servicemodule.css']
})
export class SrCitrixAccessDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  @Input() srData: any;
  citrixForm!: FormGroup;
  @Input() currentUrl: any
  radioDataList: any;
  assetDetails: any
  softwareList: any;

  API_URLS = {
    GET_REQUEST_TYPE: '/SupportMaster/GetParentValue',
    POST_CITRIX: '/SRCitrixAccess/PostCitrixAccess'
  }

  constructor(private fb: FormBuilder, public sendEmail: SendEmailServiceService,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute,
    public formValidationService: FormValidationService
  ) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.srId = m.srId
    });
    this.initForm();
  }

  initForm() {
    this.citrixForm = this.fb.group({
      requestType: ['', Validators.required],
      adId: ['', Validators.required],
      replacement: ['', Validators.required],
      assetDetails: ['', Validators.required],
      // ipAddress: ['', [Validators.required, Validators.pattern(/^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[0-9])\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/)]],
      ipAddress: ['', Validators.required],
      hostName: ['', Validators.required],
      softwareRequired: ['', Validators.required],
      justification: ['', Validators.required],
      changeOUPath: ['', Validators.required],
      employeeType: ['', Validators.required]
    });
    if (!this.srId) {
      this.getRequestType();
      this.getSoftwareList();
    }
  }


  requestTypeList: any
  srId: any
  raisedForCommonData: any

  getRequestType() {
    this.httpSer.httpGet(this.API_URLS.GET_REQUEST_TYPE, { ParentId: 62 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.citrixForm.patchValue({ requestType: this.srData?.supportId })
      }
    })
  }

  async ngOnChanges(changes: SimpleChanges) {

    await this.getAssetDetails()
    if (changes['srData']) {
      if (this.srData != undefined) {
        this.patchFormValues(this.srData)
      }
    }
  }

  getSoftwareList() {
    this.httpSer.httpGet('/SoftwareLibrary/GetSoftwarevalue').subscribe((response: any) => {
      this.softwareList = response;
    })
  }

  patchFormValues(data: any) {
    if (this.srId) {
      this.getRequestType();
      this.getSoftwareList();
    }
    this.citrixForm.patchValue({
      adId: data?.adid ? data?.adid : '',
      replacement: data?.replaceADID ? data?.replaceADID : '',
      assetDetails: data?.assetDetails ? data?.assetDetails : '',
      ipAddress: data?.ipAddress ? data?.ipAddress : '',
      hostName: data?.hostName ? data?.hostName : '',
      softwareRequired: data?.softwareRequired ? data?.softwareRequired : '',
      justification: data?.justification ? data?.justification : '',
      changeOUPath: data?.ouPath ? data?.ouPath : '',
      employeeType: data?.empType ? data?.empType : ''
    })

    if (this.srData?.status?.trim() != 'Draft') {
      this.citrixForm.disable();
    }
  }

  allFieldValues = {
    adId: '',
    replacement: '',
    assetDetails: '',
    ipAddress: '',
    hostName: '',
    softwareRequired: '',
    justification: '',
    changeOUPath: '',
    employeeType: ''
  }

  selectDetails() {
    // let data=this.assetDetails[event.target.selectedIndex]
    let data = this.assetDetails.filter((m: any) => m.assetNo == this.citrixForm.value.assetDetails)
    this.citrixForm.patchValue({
      hostName: data[0]?.hostName,
      ipAddress: data[0]?.ipAddress,
    })
    this.citrixForm.controls['hostName'].disable()
    this.citrixForm.controls['ipAddress'].disable()
  }

  changeRequestTypeValue() {
    this.citrixForm?.patchValue(this.allFieldValues);
    this.getAssetDetails();
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
    this.getAssetDetails()
  }

  submit(status: string) {
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formValidationService.validateForm(this.citrixForm)) {
        const requestBody = {
          "flag": this.srId ? 'U' : 'I',
          "srcid": this.srId ? this.srData?.srcid : 0,
          "srid": this.srId ? this.srId : 0,
          "supportID": Number(this.citrixForm?.value?.requestType),
          "requestType": "",
          "adid": (this.citrixForm?.value?.adId),
          "replaceADID": (this.citrixForm?.value?.replacement),
          "assetDetails": this.citrixForm?.value?.assetDetails,
          "softwareRequired": this.citrixForm?.value.softwareRequired,
          "ipAddress": this.citrixForm?.controls['ipAddress'].value,
          "hostName": this.citrixForm?.controls['hostName'].value,
          "empType": this.citrixForm?.value.employeeType,
          "justification": this.citrixForm?.value?.justification,
          "ouPath": this.citrixForm?.value?.changeOUPath,
          "isActive": true,
          "srVariable": {
            "srCode": "",
            "srRaisedBy": Number(this.radioDataList.selfEmployeeID),
            "srDate": new Date().toISOString().slice(0, 10),
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
            "assignedOn": "2024-11-08T10:46:25.410Z",
            "remarks": "",
            "proposedResolutionOn": "2024-11-08T10:46:25.410Z",
            "createdBy": Number(this.radioDataList.selfEmployeeID)
          }
        }

        this.httpSer.httpPost(this.API_URLS.POST_CITRIX, requestBody).subscribe((response: any) => {
          if (response.type == 'S') {
            if (status == "Draft") {
              alert("Citrix Access Saved as a Draft")
            } else {
              this.sendEmail.getData(response?.data?.srId, this.currentUrl)
              alert("Citrix Access submitted successfully!");
            }
            this.router.navigate(['/services/servicemaster']);
          } else {
            alert("Submit failed!");
          }
        })
      }
    }
  }


  getAssetDetails() {
    if (this.radioDataList?.serviceRaisedFor == 0) {
      return
    }
    this.httpSer.httpGet('/SRUSBAccess/GetAssetDetails', { Empno: String(this.radioDataList?.serviceRaisedFor) }).subscribe((response: any) => {
      this.assetDetails = response.data;
    })
  } 

  /* selectDetails(event:any){
    let data=this.assetDetails[event.target.selectedIndex]
    this.citrixForm.patchValue({
      hostName: data?.hostName,
    ipAddress: data?.ipAddress
    })

    this.citrixForm.controls['hostname'].disable()
    this.citrixForm.controls['ipAddress'].disable()
    this.citrixForm.controls['deviceType'].disable()
  } */

  clearAll() {
    this.citrixForm.patchValue({ requestType: '' });
    this.citrixForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

}
