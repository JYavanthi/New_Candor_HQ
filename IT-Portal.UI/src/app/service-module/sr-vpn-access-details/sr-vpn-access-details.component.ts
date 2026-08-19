import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

interface PlantDropdown {
  itemPlant_id: number;
  itemPlant_text: string;
}
@Component({
  selector: 'app-sr-vpn-access-details',
  templateUrl: './sr-vpn-access-details.component.html',
  styleUrls: ['./sr-vpn-access-details.component.css', '../servicemodule.css']
})
export class SrVpnAccessDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  requestTypeList: any
  srId: any;
  @Input() srData: any;
  @Input() currentUrl:any
  vpnAccessForm!: FormGroup
  radioDataList: any = [] = [];
  plantList: PlantDropdown[] = [];plantDropdownSettings = {
    idField: 'itemPlant_id',
    textField: 'itemPlant_text',
  };

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
    this.getPlantDropdown()
    this.vpnAccessForm = this.fb.group({
      requestType: [''],
      employeeLocation: ['', Validators.required],
      accessPermission: ['', Validators.required],
      requiredAccessList: ['', Validators.required],
      accessType: ['', Validators.required],
      accessFromDate: ['', Validators.required],
      accessToDate: ['', Validators.required],
      employeeType: ['', Validators.required],
      justification: ['', Validators.required],
      location: ['', Validators.required]
    });
    if (!this.srId) {
      this.getRequestType();
    }
  }

  getRequestType() {
    this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: 65 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.vpnAccessForm.patchValue({ requestType: this.srData.supportId });
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
    this.vpnAccessForm.patchValue({
      location: this.plantList.filter((m: any) =>
        this.srData?.location.trim().split(',').includes(m.itemPlant_id.toString())
      )
    });
    this.vpnAccessForm.patchValue({
      employeeLocation: data.empPlant || '',
      accessPermission: data.accessPermission || '',
      requiredAccessList: data.accessList || '',
      accessType: data.accessType || '',
      accessFromDate: data.accessFromDt?.split('T')[0] || '',
      accessToDate: data.accessToDt?.split('T')[0] || '',
      employeeType: data.empType || '',
      justification: data.justification || ''
    });

    if (this.srData?.status?.trim() != 'Draft') {
      this.vpnAccessForm.disable();
    }
  }

  allFieldValues = {
    employeeLocation: '',
    accessPermission: '',
    requiredAccessList: '',
    accessType: '',
    accessFromDate: '',
    accessToDate: '',
    employeeType: '',
    justification: ''
  }

  changeRequestTypeValue() {
    this.vpnAccessForm.patchValue(this.allFieldValues);
  }

  clearAll() {
    this.vpnAccessForm.patchValue({ requestType: '' });
    this.vpnAccessForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  validateYear(input :  any) {
    const dateValue = input;
    const year = dateValue?.split('-')[0];
    if (year?.length > 4) {
        input= year.slice(0, 4);
     }
}

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }

  Submit(status: any) {
    if(!this.formValidationService.validateDate(this.vpnAccessForm.value.accessFromDate,'accessFromDate')){
      return alert('Start Date cannot be less than current date')
    }
    if(!this.formValidationService.validateStartAndEndDate(this.vpnAccessForm.value.accessFromDate, this.vpnAccessForm.value.accessToDate,'accessFromDate', 'accessToDate')){
      return alert('End Date cannot be less than Start date')
    }
    let reqData = this.requestTypeList.filter((m:any) => m.supportId == this.vpnAccessForm.value.requestType)[0]

      if (status == 'Pending Approval') {
        status = (reqData?.isRpmreq &&
          reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
      }
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formValidationService.validateForm(this.vpnAccessForm)) {
        let requestBody = {
          "flag": this.srId ? "U" : "I",
          "srid": this.srId ? Number(this.srId) : 0,
          "srvpnid": this.srData ? this.srData.srvpnid : 0,
          "supportID": Number(this.vpnAccessForm.get('requestType')?.value),
          "requestType": "",
          "empPlant": this.vpnAccessForm.get('employeeLocation')?.value,
          "accessPermission": this.vpnAccessForm.get('accessPermission')?.value,
          "accessList": this.vpnAccessForm.get('requiredAccessList')?.value,
          "accessType": this.vpnAccessForm.get('accessType')?.value,
          "accessFromDt": this.vpnAccessForm.get('accessFromDate')?.value ? new Date(this.vpnAccessForm.get('accessFromDate')?.value).toISOString() : null,
          "accessToDt": this.vpnAccessForm.get('accessToDate')?.value ? new Date(this.vpnAccessForm.get('accessToDate')?.value).toISOString() : null,
          "empType": this.vpnAccessForm.get('employeeType')?.value,
          "justification": this.vpnAccessForm.get('justification')?.value,
          "description": "",
          "isActive": true,
          "Location":this.vpnAccessForm?.value.location ? this.vpnAccessForm?.value.location?.map((m: any) => m.itemPlant_id)?.join() : '',
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

        this.httpSer.httpPost('/SRVPNAccess/PostVPNAccess', requestBody).subscribe(
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

  
  getPlantDropdown() {
    const apiUrl = '/Plantid';
    this.httpSer.httpGet(apiUrl).subscribe((list: any) => {
      this.plantList = list?.map((item: any) => ({
        itemPlant_id: item.id,
        itemPlant_text: item.code
      }));

      if (this.srId) {
        this.vpnAccessForm.patchValue({
          location: this.plantList.filter((m: any) =>
            this.srData?.location.trim().split(',').includes(m.itemPlant_id.toString())
          )
        });
      }
    })
  }

}
