import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

@Component({
  selector: 'app-sr-usb-access-details',
  templateUrl: './sr-usb-access-details.component.html',
  styleUrls: ['./sr-usb-access-details.component.css', '../servicemodule.css']
})
export class SrUsbAccessDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  requestTypeList: any
  @Input() currentUrl: any
  srId: any
  radioDataList: any
  usbAccessForm!: FormGroup
  @Input() srData: any;
  assetDetails: any;

  constructor(private fb: FormBuilder, public sendEmail: SendEmailServiceService,
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
    this.usbAccessForm = this.fb.group({
      adId: ['', Validators.required],
      requestType: ['', Validators.required],
      assetDetails: ['', Validators.required],
      hostname1: ['', Validators.required],
      deviceType: ['', Validators.required],
      durationFrom: ['', Validators.required],
      durationTo: ['', Validators.required],
      accessType: ['', Validators.required],
      ipAddress: ['', Validators.required],
      employeeType: ['', Validators.required],
      justification: ['', Validators.required]
    });
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
    let data = this.assetDetails.filter( (m : any)=> m.assetNo ==  this.usbAccessForm.value.assetDetails)
    this.usbAccessForm.patchValue({
      hostname1: data[0]?.hostName,
    ipAddress: data[0]?.ipAddress,
    deviceType: data[0]?.assetType
    })

    this.usbAccessForm.controls['hostname1'].disable()
    this.usbAccessForm.controls['ipAddress'].disable()
    this.usbAccessForm.controls['deviceType'].disable()
  }

  patchFormValues(data: any) {
    if (this.srId) {
      this.getRequestType();
    }

    this.usbAccessForm.patchValue({
      adId: data?.adid,
      assetDetails: data?.assetDetails,
      hostname1: data?.hostName,
      deviceType: data?.deviceType,
      durationFrom: data?.durationFrom?.split('T')[0],
      durationTo: data?.durationTo?.split('T')[0],
      accessType: data?.accessType,
      ipAddress: data?.ipAddress,
      employeeType: data?.empType,
      justification: data?.justification
    });



    if (this.srData?.status?.trim() != 'Draft') {
      this.usbAccessForm.disable();
    }
  }

  validateYear(input: any) {
    const dateValue = input;
    const year = dateValue?.split('-')[0];
    if (year?.length > 4) {
      input = year.slice(0, 4);
    }
  }


  getRequestType() {
    this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: 53 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.usbAccessForm.patchValue({ requestType: this.srData.supportId })
      }
    })
  }

  changeRequestTypeValue() {
    this.usbAccessForm.patchValue(this.allFieldValues);
    this.getAssetDetails();
  }

  getDatafromRadios(raisedForCommonData: any) {
    this.radioDataList = raisedForCommonData;
    this.getAssetDetails()
  }

  allFieldValues = {
    adId: '',
    assetDetails: '',
    hostname1: '',
    deviceType: '',
    durationFrom: '',
    durationTo: '',
    accessType: '',
    ipAddress: '',
    employeeType: '',
    justification: ''
  }

  clearAll() {
    this.usbAccessForm.patchValue({ requestType: '' });
    this.usbAccessForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  Submit(status: any) {
    if (!this.formValidationService.validateDate(this.usbAccessForm.value.durationFrom, 'durationFrom')) {
      return alert('Duration From cannot be less than current date')
    }
    if (!this.formValidationService.validateStartAndEndDate(this.usbAccessForm.value.durationFrom, this.usbAccessForm.value.durationTo, 'durationFrom', 'durationTo')) {
      return alert('Duration To cannot be less than Duration From date')
    }
    let reqData = this.requestTypeList.filter((m: any) => m.supportId == this.usbAccessForm.value.requestType)[0]

    if (status == 'Pending Approval') {
      status = (reqData?.isRpmreq &&
        reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
    }
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formValidationService.validateForm(this.usbAccessForm)) {
        const apiUrl = '/SRUSBAccess/PostSRUSB';
        const requestBody = {
          "flag": this.srId ? "U" : "I",
          "srid": this.srId ? Number(this.srId) : 0,
          "srusbaid": this.srData ? this.srData.srusbaid : 0,
          "supportID": Number(this.usbAccessForm.value.requestType),
          "requestType": "",
          "adid": this.usbAccessForm.value.adId,
          "assestDetails": this.usbAccessForm.value.assetDetails,
          "hostname": this.usbAccessForm.controls['hostname1'].value,
          "deviceType": this.usbAccessForm.controls['deviceType'].value,
          "durationFrom": new Date(this.usbAccessForm.get('durationFrom')?.value).toISOString(),
          "durationTo": new Date(this.usbAccessForm.get('durationTo')?.value).toISOString(),
          "accessType": this.usbAccessForm.controls['accessType'].value,
          "ipAddress": this.usbAccessForm.controls['ipAddress'].value,
          "empType": this.usbAccessForm.controls['employeeType'].value,
          "justification": this.usbAccessForm.controls['justification'].value,
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
            "grManagerEmpId": this.radioDataList.formValues?.reportingManagerID?.split('-')[0] || '',
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
                this.sendEmail.getData(response?.data?.srId, this.currentUrl)
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
