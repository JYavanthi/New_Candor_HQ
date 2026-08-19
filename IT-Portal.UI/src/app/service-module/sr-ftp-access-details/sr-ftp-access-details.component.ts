import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

@Component({
  selector: 'app-sr-ftp-access-details',
  templateUrl: './sr-ftp-access-details.component.html',
  styleUrls: ['./sr-ftp-access-details.component.css', '../servicemodule.css']
})
export class SrFtpAccessDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  @Input() srData: any;
  @Input() currentUrl:any
  requestTypeList: any
  srId: any
  raisedForCommonData: any
  ftpAccessForm!: FormGroup
  dropdownItems: any[] = [];
  radioDataList: any;

  API_URLS = {
    GET_PARENT_VALUE: '/SupportMaster/GetParentValue',
    SAVE_FTP: '/SRFTPAccess/PostSRFTPAccess'
  }

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

  filterItem() {
    var filter = this.ftpAccessForm.value.ownerEmail.toUpperCase().trim();

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
    this.ftpAccessForm.patchValue({ ownerEmail: item.officialEmailId ? item.officialEmailId : 'No email available' })
    this.ftpAccessForm.patchValue({ ownerPlant: item.plantcode })
    this.dropdownItems = [];
  }

  formInit() {
    this.ftpAccessForm = this.fb.group({
      requestType: ['', Validators.required],
      requiredFolderAccess: ['', Validators.required],
      accessType: ['', Validators.required],
      duration: ['', [Validators.required, Validators.min(1)]],
      ownerEmail: ['', [Validators.required]],
      ownerPlant: ['', [Validators.required]],
      empType: ['', Validators.required],
      purpose: ['', Validators.required]
    });
    if (!this.srId) {
      this.getRequestType();
    }
  }

  getRequestType() {
    this.httpSer.httpGet(this.API_URLS.GET_PARENT_VALUE, { ParentId: 50 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.ftpAccessForm.patchValue({ requestType: this.srData?.supportId })
      }
    })
  }

  allFieldValues = {
    requiredFolderAccess: '',
    accessType: '',
    duration: '',
    ownerEmail: '',
    ownerPlant: '',
    empType: '',
    purpose: '',
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

    this.ftpAccessForm.patchValue({
      requiredFolderAccess: data?.accessPath,
      accessType: data?.accessType,
      duration: data?.accessRequire,
      ownerEmail: data?.ownerEmail,
      ownerPlant: data?.ownerPlant,
      empType: data?.empType,
      purpose: data.justification,
    });
    if (this.srData?.status.trim() != 'Draft') {
      this.ftpAccessForm.disable()
    }
  }

  changeRequestTypeValue() {
    this.ftpAccessForm.patchValue(this.allFieldValues);
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }

  submit(status: string) {
    let reqData = this.requestTypeList.filter((m:any) => m.supportId == this.ftpAccessForm.value.requestType)[0]

      if (status == 'Pending Approval') {
        status = (reqData?.isRpmreq &&
          reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
      }
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formValidationService.validateForm(this.ftpAccessForm)) {
        const requestBody = {
          "flag": this.srId ? 'U' : 'I',
          "srid": this.srId ? this.srId : 0,
          "srftpaid": 0,
          "supportID": Number(this.ftpAccessForm?.value.requestType),
          "reqType": "",
          "accessRequire": String(this.ftpAccessForm.value.duration) || "0",
          "accessType": this.ftpAccessForm.value.accessType,
          "accessPath": this.ftpAccessForm.value.requiredFolderAccess,
          "description": "",
          "ownerEmail": this.ftpAccessForm.value.ownerEmail,
          "ownerPlant": this.ftpAccessForm.value.ownerPlant,
          "empType": this.ftpAccessForm.value.empType,
          "justification": this.ftpAccessForm.value.purpose,
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
            "assignedOn": "2024-11-08T10:46:25.410Z",
            "remarks": "",
            "proposedResolutionOn": "2024-11-08T10:46:25.410Z",
            "createdBy": Number(this.radioDataList.selfEmployeeID)
          }
        }

        this.httpSer.httpPost(this.API_URLS.SAVE_FTP, requestBody).subscribe((response: any) => {
          if (response.type == 'S') {
            if (status == "Draft") {
              alert("FTP Access Saved as a Draft")
            } else {
              alert("FTP Access Submitted Successfully!");
              this.sendEmail.getData(response?.data?.srId,this.currentUrl)
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
    this.ftpAccessForm.patchValue({ requestType: '' });
    this.ftpAccessForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }
}
