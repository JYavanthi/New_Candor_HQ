import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

@Component({
  selector: 'app-sr-antivirus-details',
  templateUrl: './sr-antivirus-details.component.html',
  styleUrls: ['./sr-antivirus-details.component.css', '../servicemodule.css']
})

export class SrAntivirusDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  requestTypeList: any
  srId: any;
  @Input() srData: any;
  radioDataList: any;
  antivirusForm!: FormGroup
  @Input() currentUrl:any

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
    this.antivirusForm = this.fb.group({
      requestType: [''],

      installationDetails: ['', Validators.required],
      uninstallDetails: ['', Validators.required],
      excludeFolderDetails: ['', Validators.required],
      uninstallIncludeFolders: ['', Validators.required]
    });
    if (!this.srId) {
      this.getRequestType();
    }
  }

  getRequestType() {
    this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: 83 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.antivirusForm.patchValue({ requestType: this.srData.supportId });
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

    this.antivirusForm.patchValue({
      installationDetails: data?.installDts || '',
      uninstallDetails: data?.uninstallDts || '',
      excludeFolderDetails: data?.excDts || '',
      uninstallIncludeFolders: data?.incDts || '',

    });

    if (this.srData?.status?.trim() != 'Draft') {
      this.antivirusForm.disable();
    }
  }

  allFieldValues = {
    installationDetails: '',
    uninstallDetails: '',
    excludeFolderDetails: '',
    uninstallIncludeFolders: ''
  }

  changeRequestTypeValue() {
    this.antivirusForm.patchValue(this.allFieldValues);
  }

  clearAll() {
    this.antivirusForm.patchValue({ requestType: '' });
    this.antivirusForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }

  Submit(status: any) {
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formValidationService.validateForm(this.antivirusForm)) {
        const requestBody = {
          "flag": this.srId ? "U" : "I",
          "srid": this.srId ? Number(this.srId) : 0,
          "supportID": Number(this.antivirusForm.get('requestType')?.value),
          "sravid": this.srData ? this.srData.sravid : 0,
          "requestType": "",
          "installDts": this.antivirusForm.get('installationDetails')?.value,
          "uninstallDts": this.antivirusForm.get('uninstallDetails')?.value,
          "excDts": this.antivirusForm.get('excludeFolderDetails')?.value,
          "incDts": this.antivirusForm.get('uninstallIncludeFolders')?.value,
          "attachment": "",
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

        this.httpSer.httpPost('/SRAntivirus/PostAntivirus', requestBody).subscribe(
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
