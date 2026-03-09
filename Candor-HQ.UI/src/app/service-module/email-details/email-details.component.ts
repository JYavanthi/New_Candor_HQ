import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-email-details',
  templateUrl: './email-details.component.html',
  styleUrl: './email-details.component.css'
})
export class EmailDetailsComponent {
  srId: any;
  requestTypeList: any;
  srData:any
  emailForm:any
  API_URLS = {
    SAVE_SUPPORT: '/SRSoftware/SaveSupport',
    GET_PARENT_VALUE: '/SupportMaster/GetParentValue',
  }
  radioDataList: any;
  constructor(public fb: FormBuilder, private httpSer: HttpServiceService, private activeRoute: ActivatedRoute, public formValidationService: FormValidationService) {
    this.activeRoute.queryParamMap.subscribe(param => {
      if (param.get('srId')) {
        this.srId = param.get('srId');
      }
    })
  }

  ngOnInit() {
    this.activeRoute.queryParams.subscribe((m:any)=>{
      this.srId = m.srId  
    });
    this.formInIt();
  }

  formInIt() {
    this.emailForm = this.fb.group({
      requestType: [''],
    })
    }
  getRequestType() {
    let param = { ParentId: 36 }
    this.httpSer.httpGet(this.API_URLS.GET_PARENT_VALUE, param).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.emailForm.patchValue({ requestType: this.srData.supportId })
      }
    })
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }
  changeRequestTypeValue() {
    this.emailForm.patchValue({
      procureBuyVendorName: '',
      softwareName: '',
      softwareVersion: '',
      procureBuyInstallationType: '',
      procureBuyLicenseType: '',
      location: '',
      department: '',
      userCount: null,
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
    });
  }


}
