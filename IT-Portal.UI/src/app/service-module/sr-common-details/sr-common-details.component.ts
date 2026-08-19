import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormValidationService } from '../../services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';

interface DepartmentDropdown {
  itemDepartment_id: number;
  itemDepartment_text: string;
}

interface PlantDropdown {
  itemPlant_id: number;
  itemPlant_text: string;
}

@Component({
  selector: 'app-sr-common-details',
  templateUrl: './sr-common-details.component.html',
  styleUrls: ['./sr-common-details.component.css', '../servicemodule.css']
})

export class SrCommonDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  srId: any;
  @Input() srData: any;
  radioDataList: any;
  softwareForm!: FormGroup;
  @Input() currentUrl: any
  impactedPlant: any = '';
  plantList: PlantDropdown[] = [];
  departmentList: DepartmentDropdown[] = [];
  attachMentList = [];
  // softwareList: any;
  // versionList: any;
  targetVersionList: any;

  softwareList: any[] = [];
  softwareVList: any[] = [];
  versionList: any[] = [];
  plantDropdownSettings = {
    idField: 'itemPlant_id',
    textField: 'itemPlant_text',
  };
  departmentDropdownSettings = {
    idField: 'itemDepartment_id',
    textField: 'itemDepartment_text',
  };
  // softwareVList: any;

  constructor(public fb: FormBuilder, private httpSer: HttpServiceService, private employeeInfo: GetEmployeeInfoService, private activeRoute: ActivatedRoute, public formValidationService: FormValidationService,
    public router: Router) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.srId = m.srId
    });
    this.formInIt();
  }

  API_URLS = {
    SAVE_SUPPORT: '/SRSoftware/SaveSupport',
    GET_PARENT_VALUE: '/SupportMaster/GetParentValue',
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }

  getPlantDropdown() {
    const apiUrl = '/Plantid';
    this.httpSer.httpGet(apiUrl).subscribe((list: any) => {
      this.plantList = list?.map((item: any) => ({
        itemPlant_id: item.id,
        itemPlant_text: item.code
      }));

      if (this.srId) {
        this.softwareForm.patchValue({
          location: this.plantList.filter((m: any) =>
            this.srData?.location.split(',').includes(m.itemPlant_id.toString())
          )
        });
      }
    })
  }

  getDepartmentDropdown() {
    const apiUrl = '/DepartmentMaster/GetDepartment'
    this.httpSer.httpGet(apiUrl).subscribe((list: any) => {
      this.departmentList = list?.map((item: any) => ({
        itemDepartment_id: item.id,
        itemDepartment_text: item.name
      }))

      if (this.srId) {
        this.softwareForm.patchValue({
          department: this.departmentList.filter((m: any) =>
            this.srData?.department.split(',').includes(m.itemDepartment_id.toString())
          )
        });
      }
    })
  }

  getAttchmentList(event: any) {
    this.attachMentList = event
  }
  formInIt() {
    this.softwareForm = this.fb.group({
      requestType: [''],
      procureBuyVendorName: [''],
      softwareName: ['', Validators.required],
      softwareVersion: ['', Validators.required],
      procureBuyInstallationType: ['', Validators.required],
      procureBuyLicenseType: ['', Validators.required],
      location: ['', Validators.required],
      department: ['', Validators.required],
      userCount: [null, [Validators.required, Validators.min(1)]],
      noOfUsersUsingThis: [null, [Validators.required, Validators.min(1)]],
      procureBuyLicenses: [null, [Validators.required, Validators.min(1)]],
      procureBuyCostPerLicense: [null],
      procureBuyTotalCost: [''],
      procureBuyisAMCApplicable: ['', Validators.required],
      procureBuyAMCCost: [null],
      procureBuyScopeOfAMC: [''],
      procureBuyisImpOrinstallationRequired: ['', Validators.required],
      procureBuyInstallationCharges: [null],
      procureBuyInstallationDetails: [''],
      procureBuyExpectedDate: ['', Validators.required],
      justification: ['', Validators.required],
      developmentType: ['', Validators.required],
      developmentDetails: ['', Validators.required],
      developmentInterfaceIsRequired: ['', Validators.required],
      developmentInterfaceRequirements: [''],
      developmentInterfaceDetails: [''],
      isGxpApplication: ['', Validators.required],
      nonFunctionalRequirements: [''],
      developmentBRDorSRSAttachment: [''],

      websiteDevRequirementDetails: ['', Validators.required],
      websiteDevType: ['', Validators.required],
      websiteDevhosting: ['', Validators.required],
      websiteDevUsageBy: ['', Validators.required],
      websiteDevAccessLocation: ['', Validators.required],
      websiteDevIsInterfaceRequired: ['', Validators.required],
      websiteDevInterfaceRequirements: [''],
      websiteDevSystemOrSoftwareInterfaced: [''],
      websiteDevBRDorSRSAttachment: ['', Validators.required],


      upgradeSoftwareCurrentVersion: ['', Validators.required],
      upgradeSoftwareTargetVersion: ['', Validators.required],

      uninstallSoftwareCurrentVersion: [''],
    });

    this.softwareForm.get('procureBuyisAMCApplicable')?.valueChanges.subscribe((value: any) => {
      this.formValidationService.updateValidators(this.softwareForm, ['procureBuyAMCCost', 'procureBuyScopeOfAMC'], value == "Yes");
    })

    this.softwareForm.get('procureBuyisImpOrinstallationRequired')?.valueChanges.subscribe(value => {
      this.formValidationService.updateValidators(this.softwareForm, ['procureBuyInstallationCharges', 'procureBuyInstallationDetails'], value == "Yes");
    })

    this.softwareForm.get('developmentInterfaceIsRequired')?.valueChanges.subscribe(value => {
      this.formValidationService.updateValidators(this.softwareForm, ['developmentInterfaceRequirements', 'developmentInterfaceDetails'], value == "Yes");
    })

    this.softwareForm.get('websiteDevIsInterfaceRequired')?.valueChanges.subscribe(value => {
      this.formValidationService.updateValidators(this.softwareForm, ['websiteDevInterfaceRequirements', 'websiteDevSystemOrSoftwareInterfaced'], value == "Yes");
    })
    if (!this.srId) {
      this.getRequestType();
      this.getPlantDropdown();
      this.getDepartmentDropdown();
      this.getSoftwareList();
    }
  }

  allFieldValues = {
    procureBuyVendorName: '',
    softwareName: '',
    softwareVersion: '',
    procureBuyInstallationType: '',
    procureBuyLicenseType: '',
    location: '',
    department: '',
    userCount: null,
    noOfUsersUsingThis: null,
    procureBuyLicenses: null,
    procureBuyCostPerLicense: null,
    procureBuyTotalCost: '',
    procureBuyisAMCApplicable: '',
    procureBuyAMCCost: null,
    procureBuyScopeOfAMC: '',
    procureBuyisImpOrinstallationRequired: '',
    procureBuyInstallationCharges: null,
    procureBuyInstallationDetails: '',
    procureBuyExpectedDate: '',
    justification: '',
    developmentType: '',
    developmentDetails: '',
    developmentInterfaceIsRequired: '',
    developmentInterfaceRequirements: '',
    developmentInterfaceDetails: '',
    isGxpApplication: '',
    nonFunctionalRequirements: '',
    developmentBRDorSRSAttachment: '',
    websiteDevRequirementDetails: '',
    websiteDevType: '',
    websiteDevhosting: '',
    websiteDevUsageBy: '',
    websiteDevAccessLocation: '',
    websiteDevIsInterfaceRequired: '',
    websiteDevInterfaceRequirements: '',
    websiteDevSystemOrSoftwareInterfaced: '',
    websiteDevBRDorSRSAttachment: '',
    upgradeSoftwareCurrentVersion: '',
    upgradeSoftwareTargetVersion: '',
    uninstallSoftwareCurrentVersion: '',
  };

  clearAll() {
    this.softwareForm.patchValue({ requestType: '' });
    this.softwareForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  changeRequestTypeValue() {
    this.softwareForm.patchValue(this.allFieldValues);
  }

  // getSoftwareList() {
  //   this.httpSer.httpGet('/SoftwareLibrary/GetSoftwarevalue').subscribe((response: any) => {
  //     this.softwareList = response;
  //     if (this.srId) {
  //       this.versionList = this.softwareList;
  //       this.targetVersionList = this.softwareList
  //     }
  //   })

  //   this.httpSer.httpGet('/SoftwareLibrary/GetSoftwareVersionBySoftId').subscribe((response: any) => {
  //     this.softwareVList = response;
  //   })
  // }

  getSoftwareList() {
    this.httpSer.httpGet('/SoftwareLibrary/GetSoftwarevalue').subscribe((response: any) => {
      this.softwareList = response;

      if (this.srId) {
        this.versionList = this.softwareList;
        this.targetVersionList = this.softwareList;
      }
    });

    this.httpSer.httpGet('/SoftwareLibrary/GetSoftwareVersionBySoftId').subscribe((response: any) => {
      this.softwareVList = response;
    });
  }

  // getVersionList() {
  //   this.versionList = this.softwareList.filter((m: any) => m.softwareLibraryId == this.softwareForm.controls['softwareName'].value && m.softVersionId)
  //   if (this.versionList) {
  //     this.softwareForm.patchValue({ softwareVersion: '' });
  //   }
  // }

  getVersionList() {
    const selectedSoftwareId = this.softwareForm.controls['softwareName'].value;
    this.versionList = this.softwareVList.filter(
      (version: any) => version.softwareLibraryId == selectedSoftwareId
    );

    this.softwareForm.patchValue({ softwareVersion: '' });
    console.log('Filtered version list:', this.versionList);
  }

  requestTypeList: any[] = [];
  getRequestType() {
    let param = { ParentId: 8 }
    this.httpSer.httpGet(this.API_URLS.GET_PARENT_VALUE, param).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.softwareForm.patchValue({ requestType: this.srData.supportId })
      }
    })
  }

  totalCost() {
    const totalCost = this.softwareForm?.value.procureBuyLicenses * this.softwareForm?.value.procureBuyCostPerLicense;
    this.softwareForm.patchValue({ procureBuyTotalCost: totalCost });
  }

  Submit(status: any) {
    if (!this.formValidationService.validateDate(this.softwareForm.value.procureBuyExpectedDate, 'procureBuyExpectedDate')) {
      return alert('Date cannot be less than current date')
    }
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      let reqData = this.requestTypeList.filter(m => m.supportId == this.softwareForm.value.requestType)[0]

      if (status == 'Pending Approval') {
        status = (reqData?.isRpmreq &&
          reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
      }
      if ((this.softwareForm.value.requestType == 19 || this.softwareForm.value.requestType == 20) && this.attachMentList?.length == 0 && !this.srId) {
        alert('Add Attachment.')
        return
      }
      if (this.formValidationService.validateForm(this.softwareForm)) {

        const requestBody = {
          "flag": this.srId ? "U" : 'I',
          "srid": this.srId ? this.srId : 0,
          "swid": this.srId ? this.srData?.swid : 0,
          "supportID": Number(this.softwareForm.value.requestType),
          "softwareType": "",
          "softwareName": Number(this.softwareForm?.controls['softwareName'].value),
          "softwareVersionName": Number(this.softwareForm?.value.softwareVersion),
          "vendorName": this.softwareForm?.value.procureBuyVendorName,
          "instType": this.softwareForm?.value.procureBuyInstallationType,
          "licenceType": this.softwareForm?.value.procureBuyLicenseType,
          "location": this.softwareForm?.value.location ? this.softwareForm?.value.location?.map((m: any) => m.itemPlant_id)?.join() : '',
          "department": this.softwareForm?.value.department ? this.softwareForm?.value.department?.map((m: any) => m.itemDepartment_id)?.join() : '',
          "noOfUers": this.softwareForm.value.userCount || 0,
          "noOfLicence": this.softwareForm.value.procureBuyLicenses || 0,
          "costPerLicence": this.softwareForm.value.procureBuyCostPerLicense || 0,
          "totalCost": this.softwareForm?.value.procureBuyTotalCost || 0,
          "amcAppilcable": this.softwareForm?.value.procureBuyisAMCApplicable == 'Yes' ? true : false,
          "costForAMC": Number(this.softwareForm?.value.procureBuyAMCCost),
          "scopeOfAMC": this.softwareForm?.value.procureBuyScopeOfAMC,
          "isInstReq": this.softwareForm.value.procureBuyisImpOrinstallationRequired == 'Yes' ? true : false,
          "instCharge": Number(this.softwareForm.value.procureBuyInstallationCharges),
          "dtlsOfInst": this.softwareForm?.value.procureBuyInstallationDetails,
          "dtlsOfinstDt": this.softwareForm?.value.procureBuyExpectedDate ? new Date(this.softwareForm.get('procureBuyExpectedDate')?.value).toISOString() : "2024-10-16T09:28:59.543Z",
          "typeOfDev": this.softwareForm?.value.developmentType,
          "dtlsOfDev": this.softwareForm?.value.developmentDetails,
          "isInterfaceReq": this.softwareForm?.value.developmentInterfaceIsRequired == 'Yes' ? true : false,
          "interfaceReq": this.softwareForm?.value.developmentInterfaceRequirements,
          "interfaceWith": this.softwareForm?.value.developmentInterfaceDetails,
          "isGxpApp": this.softwareForm?.value.isGxpApplication == 'Yes' ? true : false,
          "nonFunReq": this.softwareForm?.value.nonFunctionalRequirements,
          "dtlsOfReq": this.softwareForm?.value.websiteDevRequirementDetails,
          "whereHosted": this.softwareForm?.value.websiteDevhosting,
          "typeOfWeb": this.softwareForm?.value.websiteDevType,
          "usageBY": this.softwareForm?.value.websiteDevUsageBy,
          "userAccessFrom": this.softwareForm?.value.websiteDevAccessLocation,
          "currVersion": this.softwareForm?.value.upgradeSoftwareCurrentVersion,
          "tareVersion": this.softwareForm?.value.upgradeSoftwareTargetVersion,
          "brds": this.softwareForm?.value.developmentBRDorSRSAttachment,
          "busJustification": this.softwareForm?.value.installSoftwareBusinessJustification ? this.softwareForm?.value.installSoftwareBusinessJustification : "",
          "justification": this.softwareForm?.value.justification,
          "noofUseruse": Number(this.softwareForm.value.noOfUsersUsingThis),
          "isActive": true,
          "AttachmentIds": this.attachMentList.map((m: any) => m.attachId),
          "srVariable": {
            "srCode": "",
            "srRaisedBy": Number(this.radioDataList.selfEmployeeID),
            "srDate": new Date().toISOString().slice(0, 10),
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
            "assignedOn": "2024-10-16T09:28:59.543Z",
            "remarks": "",
            "proposedResolutionOn": "2024-10-16T09:28:59.543Z",
            "createdBy": Number(this.radioDataList.selfEmployeeID)
          }
        }

        this.httpSer.httpPost(this.API_URLS.SAVE_SUPPORT, requestBody).subscribe(
          (response: any) => {
            if (response.type == 'S') {
              if (status == "Draft") {
                alert("Saved as a Draft Successfully!");
                this.router.navigate(['/services/servicemaster']);
              }
              else {
                alert("Saved Successfully!");
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

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['srData']) {
      if (this.srData != undefined) {
        this.getPlantDropdown();
        this.getDepartmentDropdown();

        this.patchFormValues(this.srData)
      }
    }
  }

  removeAttchment(event: any) {
    this.attachMentList = this.attachMentList.filter((m: any) => m.attachId != event)
  }

  patchFormValues(data: any) {
    if (this.srId) {
      this.getRequestType();
      this.getSoftwareList();
    }
    this.softwareForm.patchValue({
      softwareName: Number(data?.softwareName) || '',
      procureBuyInstallationType: data?.instType || '',
      procureBuyVendorName: data?.vendorName || '',
      procureBuyLicenseType: data?.licenceType || '',
      userCount: data?.noOfUers ? +data?.noOfUers : null,
      noOfUsersUsingThis: data?.noofUseruse ? +data?.noofUseruse : null,
      procureBuyLicenses: data?.noOfLicence ? +data?.noOfLicence : null,
      procureBuyCostPerLicense: data?.costPerLicence ? +data?.costPerLicence : null,
      procureBuyTotalCost: data?.totalCost || 0,
      procureBuyisAMCApplicable: data?.amcappilcable ? 'Yes' : 'No',
      procureBuyAMCCost: data?.costForAmc || null,
      procureBuyScopeOfAMC: data?.scopeOfAmc || '',
      procureBuyisImpOrinstallationRequired: data?.isInstReq ? 'Yes' : 'No',
      procureBuyInstallationCharges: data?.instCharge || null,
      procureBuyInstallationDetails: data?.dtlsOfInst || '',
      procureBuyExpectedDate: data?.dtlsOfinstDt ? data?.dtlsOfinstDt?.split('T')[0] : '',
      justification: data?.justification || '',
      developmentType: data?.typeOfDev || '',
      developmentDetails: data?.dtlsOfDev || '',
      developmentInterfaceIsRequired: data?.isInterfaceReq ? 'Yes' : 'No',
      developmentInterfaceRequirements: data?.interfaceReq || '',
      developmentInterfaceDetails: data?.interfaceWith || '',
      isGxpApplication: data?.isGxpApp ? 'Yes' : 'No',
      nonFunctionalRequirements: data?.nonFunReq || '',
      websiteDevRequirementDetails: data?.dtlsOfReq || '',
      websiteDevType: data?.typeOfWeb || '',
      websiteDevhosting: data?.whereHosted || '',
      websiteDevUsageBy: data?.usageBy || '',
      websiteDevAccessLocation: data?.userAccessFrom || '',
      websiteDevIsInterfaceRequired: data?.isInterfaceReq ? 'Yes' : 'No',
      websiteDevInterfaceRequirements: data?.interfaceReq || '',
      websiteDevSystemOrSoftwareInterfaced: data?.interfaceWith || '',
      upgradeSoftwareCurrentVersion: data?.currVersion || '',
      upgradeSoftwareTargetVersion: data?.tareVersion || '',
      uninstallSoftwareCurrentVersion: data?.brds || '',
      softwareVersion: Number(data?.softwareVersionName) || '',
    });

    if (this.srData?.status?.trim() != 'Draft') {
      this.softwareForm.disable()
    }
  }
}
