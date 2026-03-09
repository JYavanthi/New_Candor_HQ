import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

@Component({
  selector: 'app-sr-external-drive-access-details',
  templateUrl: './sr-external-drive-access-details.component.html',
  styleUrls: ['./sr-external-drive-access-details.component.css', '../servicemodule.css']
})
export class SrExternalDriveAccessDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  srId: any;
  @Input() srData: any;
  @Input() currentUrl:any
  externalDriveAccessForm!: FormGroup;
  radioDataList: any;
  dropdownItems: any[] = [];
  impactedPlant: any = '';

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
    this.externalDriveAccessForm = this.fb.group({
      requestType: [''],

      durationAccessRequire: [null, [Validators.required, Validators.min(1)]],
      ownerEmailOfDrive: [null, [Validators.required, Validators.min(1)]],
      ownerPlant: ['', Validators.required],
      employeeType: ['', Validators.required],
      justification: ['', Validators.required],
      removeAccessRequiredFolderAccessOrPath: ['', Validators.required],
      removeAccessAccessType: ['', Validators.required],
    })
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

    this.externalDriveAccessForm.patchValue({
      durationAccessRequire: data.accessRequired || null,
      ownerEmailOfDrive: data.onwerEmail || '',
      ownerPlant: data.onwerPlant || '',
      employeeType: data.empType || '',
      justification: data.justification || '',
      removeAccessRequiredFolderAccessOrPath: data.accessPath || '',
      removeAccessAccessType: data.accessType || '',
    })

    if (this.srData?.status?.trim() != 'Draft') {
      this.externalDriveAccessForm.disable();
    }
  }

  allFieldValues = {
    durationAccessRequire: null,
    ownerEmailOfDrive: null,
    ownerPlant: '',
    employeeType: '',
    justification: '',
    removeAccessRequiredFolderAccessOrPath: '',
    removeAccessAccessType: '',
  }

  changeRequestTypeValue() {
    this.externalDriveAccessForm.patchValue(this.allFieldValues);
  }

  clearAll() {
    this.externalDriveAccessForm.patchValue({ requestType: '' });
    this.externalDriveAccessForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }

  requestTypeList: any[] = [];
  getRequestType() {
    const apiUrl = '/SupportMaster/GetParentValue';
    this.httpSer.httpGet(apiUrl, { ParentId: 47 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.externalDriveAccessForm.patchValue({ requestType: this.srData.supportId })
      }
    })
  }

  Submit(status: any) {
    let reqData = this.requestTypeList.filter(m => m.supportId == this.externalDriveAccessForm.value.requestType)[0]

      if (status == 'Pending Approval') {
        status = (reqData?.isRpmreq &&
          reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
      }
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formValidationService.validateForm(this.externalDriveAccessForm)) {
        const requestBody = {
          "flag": this.srId ? "U" : "I",
          "sredid": this.srId ? Number(this.srData?.sredid) : 0,
          "srid": this.srId ? Number(this.srId) : 0,
          "supportID": Number(this.externalDriveAccessForm.get('requestType')?.value),
          "reqType": "",
          "forSelf": "",
          "name": "",
          "designation": "",
          "empCategory": "",
          "role": "",
          "department": "",
          "subDepartment": "",
          "reportingManager": "",
          "hod": "",
          "accessPath": this.externalDriveAccessForm.get('removeAccessRequiredFolderAccessOrPath')?.value,
          "accessType": this.externalDriveAccessForm.get('removeAccessAccessType')?.value,
          "accessRequired": String(this.externalDriveAccessForm.get('durationAccessRequire')?.value),
          "onwerEmail": this.externalDriveAccessForm.get('ownerEmailOfDrive')?.value,
          "onwerPlant": this.externalDriveAccessForm.get('ownerPlant')?.value,
          "empType": this.externalDriveAccessForm.get('employeeType')?.value,
          "justification": this.externalDriveAccessForm.get('justification')?.value,
          "description": "",
          "isActive": true,
          "srVariable": {
            "srCode": "",
            "srRaisedBy": Number(this.radioDataList.selfEmployeeID),
            "srDate": new Date().toISOString(),
            "srShotDesc": "",
            "srDesc": "",
            "srRaiseFor": this.radioDataList.serviceRaisedFor,
            "srSelectedfor": this.radioDataList.formValues.userType,
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
            "assignedOn": "2024-11-09T11:17:56.677Z",
            "remarks": "",
            "proposedResolutionOn": "2024-11-09T11:17:56.677Z",
            "createdBy": Number(this.radioDataList.selfEmployeeID)
          }
        }

        this.httpSer.httpPost('/SRExternalDrive/PostSRExternal', requestBody).subscribe(
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

  filterItem() {
    var filter = this.externalDriveAccessForm.value.ownerEmailOfDrive.toUpperCase().trim();

    this.dropdownItems = this.employeeInfo?.EmpList?.filter((item: any) =>
      item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
    );
    if (this.dropdownItems.length === 0 && filter === '') {
      this.dropdownItems.push('');
    } else if (filter === '') {
      this.dropdownItems.length = 0;
    }
  }

  selectItem(item: any) {
    this.externalDriveAccessForm.patchValue({ ownerEmailOfDrive: item.officialEmailId ? item.officialEmailId : 'No email available' })
    this.externalDriveAccessForm.patchValue({ ownerPlant: item.plantcode })
    this.dropdownItems = [];
  }

}
