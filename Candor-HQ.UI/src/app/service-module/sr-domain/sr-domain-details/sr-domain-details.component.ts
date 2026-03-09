import { HttpServiceService } from './../../../../shared/services/http-service.service';
import { AfterViewInit, Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SrDetailsSelfOthersGuestComponent } from 'app/service-module/sr-details-self-others-guest/sr-details-self-others-guest.component';
import { FormValidationService } from 'app/services/form-validation.service';
import { ActivatedRoute, Router } from '@angular/router';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

interface DropdownLocationItem {
  itemLocation_id: number;
  itemLocation_text: string;
}

interface DropdownDepartmentItem {
  itemDepartment_id?: number;
  itemDepartment_text?: string;
}

@Component({
  selector: 'app-sr-domain-details',
  templateUrl: './sr-domain-details.component.html',
  styleUrls: ['./sr-domain-details.component.css', '../../servicemodule.css']
})

export class SrDomainDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;
  @Input() srData: any;
  domainForm!: FormGroup;
  dropdownListLocation: DropdownLocationItem[] = [];
  dropdownListDepartment: DropdownDepartmentItem[] = [];
  radioDataList: any;
  requestTypeList: any[] = [];
  @Input() currentUrl:any
  srId: any;
  todaysDate = new Date().toISOString().slice(0, 10);

  API_URLS = {
    GET_PARENT_VALUE: '/SupportMaster/GetParentValue',
    PLANT_LIST: '/Plantid',
    SAVE_DOMAIN: '/serviceMaster/saveDomain',
    GET_DEPARTMENT_LIST: '/DepartmentMaster/GetDepartment',
  }

  dropdownLocationSettings = {
    idField: 'itemLocation_id',
    textField: 'itemLocation_text',
  };

  dropdownDepartmentSettings = {
    idField: 'itemDepartment_id',
    textField: 'itemDepartment_text'
  };

  constructor(public fb: FormBuilder, private httpSer: HttpServiceService,public sendEmail:SendEmailServiceService,
    public formVal: FormValidationService, public router: Router, private activeRoute: ActivatedRoute) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.srId = m.srId
    });
    this.formInIt();
  }

  formInIt() {
    this.domainForm = this.fb.group({
      domainRequestType: ['', Validators.required],
      requiredDomainName: ['', Validators.required],
      selectLocationName: ['', Validators.required],
      department: ['', Validators.required],
      noOfUsers: [null, [Validators.required, Validators.min(1)]],
      purposeOfDomain: ['', Validators.required],
      domainName: ['', Validators.required],
      dueDate: ['', Validators.required],
      renewalYearsRequired: [null, [Validators.required, Validators.min(1)]],
      justification: ['', Validators.required],
      sslType: ['', Validators.required],
      discontinuationDate: ['', Validators.required]
    })
    if (!this.srId) {
      this.getRequestType();
      this.fetchDropdownLocation();
      this.fetchDropdownDepartment();
    }
  }

  getRequestType() {
    this.httpSer.httpGet(this.API_URLS.GET_PARENT_VALUE, { ParentId: 30 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.domainForm.patchValue({ domainRequestType: this.srData?.supportId })
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
      this.fetchDropdownLocation();
      this.fetchDropdownDepartment();
    }
    this.domainForm.patchValue({
      requiredDomainName: data?.reqDomainName || '',
      noOfUsers: data?.noofUser || null,
      purposeOfDomain: data?.purPoseDomain || '',
      domainName: data?.domainName || '',
      dueDate: data?.dueDate ? data?.dueDate?.split('T')[0] : "2024-11-07T07:14:35.103Z",
      renewalYearsRequired: data?.renewalPeriod || null,
      justification: data?.justification || '',
      sslType: data?.typeofSsl,
      discontinuationDate: data?.discontinuationDate ? data?.discontinuationDate?.split('T')[0] : "2024-11-07T07:14:35.103Z"
    });
    if (this.srData?.status.trim() != 'Draft') {
      this.domainForm.disable()
    }
  }

  fetchDropdownLocation() {
    this.httpSer.httpGet(this.API_URLS.PLANT_LIST).subscribe((list: any) => {
      this.dropdownListLocation = list.map((item: any) => ({
        itemLocation_id: item.id,
        itemLocation_text: item.code
      }));

      this.domainForm.patchValue({
        selectLocationName: this.dropdownListLocation.filter((m: any) => this.srData?.plant.split(',').includes(m.itemLocation_id.toString()))
      })
    })
  }

  fetchDropdownDepartment() {
    this.httpSer.httpGet(this.API_URLS.GET_DEPARTMENT_LIST).subscribe((list: any) => {
      this.dropdownListDepartment = list.map((item: any) => ({
        itemDepartment_id: item.id,
        itemDepartment_text: item.name
      }))

      this.domainForm.patchValue({
        department: this.dropdownListDepartment.filter((m: any) => this.srData?.department.split(',').includes(m.itemDepartment_id.toString()))
      })
    })
  }

  allFieldValues = {
    requiredDomainName: '',
    selectLocationName: '',
    department: '',
    noOfUsers: null,
    purposeOfDomain: '',
    domainName: '',
    dueDate: '',
    renewalYearsRequired: null,
    justification: '',
    sslType: '',
    discontinuationDate: '',
  };

  changeRequestTypeValue() {
    this.domainForm.patchValue(this.allFieldValues);
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }


  submit(status: string) {
    if(!this.formVal.validateDate(this.domainForm.value.dueDate,'dueDate') ){
      return alert('Date cannot be less than current date')
    }
    let reqData = this.requestTypeList.filter(m => m.supportId == this.domainForm.value.domainRequestType)[0]

      if (status == 'Pending Approval') {
        status = (reqData?.isRpmreq &&
          reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
      }
    this.selfOthersGuest.executeFunc();

    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formVal.validateForm(this.domainForm)) {
        const requestBody = {
          "flag": this.srId ? 'U' : 'I',
          "srDomainID": this.srId ? this.srData?.srdomainId : 0,
          "supportID": Number(this.domainForm?.value.domainRequestType),
          "domainName": this.domainForm?.value.domainName,
          "usePlant": this.domainForm.get('selectLocationName')?.value ? this.domainForm?.value.selectLocationName.map((m: any) => m.itemLocation_id).join() : '',
          "useDepart": this.domainForm.get('department')?.value ? this.domainForm.value.department.map((m: any) => m.itemDepartment_id).join() : '',
          "noofUser": this.domainForm?.value.noOfUsers,
          "purpDomain": this.domainForm?.value.purposeOfDomain,
          "dueDt": this.domainForm?.value.dueDate ? new Date(this.domainForm.get('dueDate')?.value).toISOString() : "2024-11-07T07:14:35.103Z",
          "typeofSSL": this.domainForm.value.sslType,
          "renewalPeriod": this.domainForm?.value.renewalYearsRequired || 0,
          "justification": this.domainForm?.value.justification,
          "discontinationDt": this.domainForm?.value.discontinuationDate ? new Date(this.domainForm.get('discontinuationDate')?.value).toISOString() : "2024-11-07T07:14:35.103Z",
          "reqDomainName": this.domainForm?.value.requiredDomainName,
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
            "assignedOn": "2024-11-07T07:14:35.103Z",
            "remarks": "",
            "proposedResolutionOn": "2024-11-07T07:14:35.103Z",
            "createdBy": Number(this.radioDataList.selfEmployeeID)
          },
          "srId": this.srId ? this.srId : 0,
          "modifiedDt": "2024-11-07T07:14:35.103Z"
        }

        this.httpSer.httpPost(this.API_URLS.SAVE_DOMAIN, requestBody).subscribe((response: any) => {
          if (response.type == 'S') {
            if (status == "Draft") {
              alert("Domain Request Saved as a Draft")
            } else {
              alert("Domain Request Submitted Successfully!");
              this.sendEmail.getData(response?.data?.srId,this.currentUrl)
            }
            this.router.navigate(['/services/servicemaster']);
          } else {
            alert("Submit failed!");
          }
        })
      }
    }
  }

  clearAll() {
    this.domainForm.patchValue({ domainRequestType: '' });
    this.domainForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }


}
