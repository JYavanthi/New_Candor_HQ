import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

@Component({
  selector: 'app-sr-file-server-or-access-for-folders-details',
  templateUrl: './sr-file-server-or-access-for-folders-details.component.html',
  styleUrls: ['./sr-file-server-or-access-for-folders-details.component.css', '../servicemodule.css']
})
export class SrFileServerOrAccessForFoldersDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  srId: any;
  @Input() srData: any;
  requestTypeList: any
  @Input() currentUrl:any
  radioDataList: any;
  fileAccessForm!: FormGroup

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
    this.fileAccessForm = this.fb.group({
      requestType: ['', Validators.required],
      ipAddress: ['', Validators.required],
      hostName: ['', Validators.required],
      fileServerName: ['', Validators.required],
      folderPath: ['', Validators.required],
      purpose: ['', Validators.required],
    });
    if (!this.srId) {
      this.getRequestType()
    }
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
    this.fileAccessForm.patchValue({
      ipAddress: data?.ipAddress,
      hostName: data?.hostName,
      fileServerName: data?.fileServerName,
      folderPath: data?.folderPath,
      purpose: data?.justification,
    });
    if (data?.status.trim() != "Draft") {
      this.fileAccessForm.disable()
    }
  }

  getRequestType() {
    this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: 74 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.fileAccessForm.patchValue({ requestType: this.srData?.supportId })
      }
    })
  }

  allFieldValues = {
    ipAddress: '',
    hostName: '',
    fileServerName: '',
    folderPath: '',
    purpose: ''
  }

  changeRequestTypeValue() {
    this.fileAccessForm.patchValue(this.allFieldValues)
  }

  getDatafromRadios(raisedForCommonData: any) {
    this.radioDataList = raisedForCommonData;
  }

  submit(status: string) {
    let reqData = this.requestTypeList.filter((m:any) => m.supportId == this.fileAccessForm.value.requestType)[0]

      if (status == 'Pending Approval') {
        status = (reqData?.isRpmreq &&
          reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
      }
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formValidationService.validateForm(this.fileAccessForm)) {
        const requestBody = {
          "flag": this.srId ? 'U' : 'I',
          "srid": this.srId ? this.srId : 0,
          "srServerID": this.srData ? this.srData.srServerID : 0,
          "supportID": Number(this.fileAccessForm?.value.requestType),
          "requestType": "",
          "hostName": this.fileAccessForm.value.hostName,
          "ipAddress": this.fileAccessForm.value.ipAddress,
          "fileServerName": this.fileAccessForm.value.fileServerName,
          "folderPath": this.fileAccessForm.value.folderPath,
          "justification": this.fileAccessForm.value.purpose,
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

        this.httpSer.httpPost('/SRFileAccess/PostFileAccess', requestBody).subscribe((response: any) => {
          if (response.type == 'S') {
            if (status == "Draft") {
              alert("File/Server Access Saved as a Draft")
            } else {
              alert("File/Server Access Submitted Successfully!");
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
    this.fileAccessForm.patchValue({ requestType: '' });
    this.fileAccessForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }
}
