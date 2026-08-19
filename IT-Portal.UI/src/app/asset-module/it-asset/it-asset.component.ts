import { Component, HostListener, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from 'app/service-module/sr-details-self-others-guest/sr-details-self-others-guest.component';
import { Location } from '@angular/common';

@Component({
  selector: 'app-it-asset',
  templateUrl: './it-asset.component.html',
  styleUrls: ['./it-asset.component.css', '../assetmodule.css']
})
export class ItAssetComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent

  showBackIcon: boolean = false;
  assetData: any;
  requestTypeList: any;
  assetId: any
  ITAssetForm!: FormGroup;
  radioDataList: any;
  selectedTabIndex: number = 0;
  disableResolution: boolean = false;

  constructor(private fb: FormBuilder,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute,
    public formValidationService: FormValidationService,
    private location: Location
  ) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.assetId = m.assetid
      if (this.assetId) {
        this.httpSer.httpGet('/AssetRequest/AssetbyID', { ID: this.assetId }).subscribe((res: any) => {
          this.assetData = res.data;
          this.changingTabs();
          this.patchFormValues(this.assetData)
        })
      }
    });
    this.formInit();

    this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: 5 }).subscribe((res: any) => {
      this.requestTypeList = res;
    })
  }

  @HostListener('window:scroll', [])
  onWindowScroll() {
    this.showBackIcon = window.scrollY > 200;
  }

  formInit() {
    this.ITAssetForm = this.fb.group({
      requestType: [''],
      employeeType: ['', Validators.required],
      assetType: ['', Validators.required],
      isGxpImpactValidation: ['', Validators.required],
      existingAsset: ['', Validators.required],
      suggestedModel: ['', Validators.required],
      specsRequirements: ['', Validators.required],
      approximateValue: [null, Validators.required],
      purposeOrJustification: ['', Validators.required],
      assetModel: ['', Validators.required],
      assetWarrantyEndDate: ['', Validators.required],
      assetSerialNo: ['', Validators.required]
    });
  }

  patchFormValues(data: any) {
    this.ITAssetForm.patchValue({
      requestType: data.requesttype || '',
      employeeType: data.empType || '',
      assetType: data.assettype || '',
      isGxpImpactValidation: data.gxpReq || '',
      existingAsset: data.existingAsset || '',
      suggestedModel: data.suggModel || '',
      specsRequirements: data.specsRequirements || '',
      approximateValue: data.approximateInr || null,
      purposeOrJustification: data.justification || '',
      assetModel: data.assetModel || '',
      assetWarrantyEndDate: data.assetsWarrantyEndDt?.split('T')[0] || '',
      assetSerialNo: data.assetSerialNo || ''
    })

    if (this.assetData?.status?.trim() != 'Draft') {
      this.ITAssetForm.disable();
    }
  }

  changingTabs() {
    if (this.assetId) {
      const notShowingApprovalTab = this.assetData?.status?.trim() == "Approval not required";
      if (notShowingApprovalTab) {
        this.selectedTabIndex = 1;
      }
      if (this.assetData?.status?.trim() == 'Resolved') {
        this.selectedTabIndex = 0;
        this.disableResolution = false;
      }
      else if (this.assetData?.status?.trim() == 'Approved' ||
        this.assetData?.status?.trim() == 'Seek Clarification' ||
        this.assetData?.status?.trim() == 'Open' ||
        this.assetData?.status?.trim() == 'In Progress' ||
        this.assetData?.status?.trim() == 'On Hold' ||
        this.assetData?.status?.trim() == 'Submit Clarification'
      ) {
        if (this.assetData?.isRpmreq == null && this.assetData?.isHodreq == null) {
          this.selectedTabIndex = 1;
          this.disableResolution = false;
        }else{
          this.selectedTabIndex = 2;
          this.disableResolution = false;
        }
      }
      else if (this.assetData?.status?.trim() == 'Pending Approval' || this.assetData?.status?.trim() == 'Rejected' || this.assetData?.status?.trim() == 'Pending HOD Approval') {
        this.selectedTabIndex = 1;
        this.disableResolution = true;
      }
    }
  }

  allFieldValues = {
    employeeType: '',
    assetType: '',
    isGxpImpactValidation: '',
    existingAsset: '',
    suggestedModel: '',
    specsRequirements: '',
    approximateValue: null,
    purposeOrJustification: '',
    assetModel: '',
    assetWarrantyEndDate: '',
    assetSerialNo: ''
  }

  changeRequestTypeValue() {
    this.ITAssetForm.patchValue(this.allFieldValues);
  }

  clearAll() {
    this.ITAssetForm.patchValue({ requestType: '' });
    this.ITAssetForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }

  Submit(status: any) {
    if(!this.formValidationService.validateDate(this.ITAssetForm.value.assetWarrantyEndDate,'assetWarrantyEndDate')){
      return alert('Date cannot be less than current date')
    }
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      let reqData = this.requestTypeList.filter((m: any) => m.supportId == 92)[0]
      if (status == 'Pending Approval') {
        status = (reqData?.isRpmreq &&
          reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
      }
      if (this.formValidationService.validateForm(this.ITAssetForm)) {
        const param = {
          "flag": this.assetId ? "U" : "I",
          "itAssetID": this.assetId ? Number(this.assetId) : 0,
          "requesttype": this.ITAssetForm.get('requestType')?.value,
          "requestedBY": Number(this.radioDataList.selfEmployeeID),
          "requestedFor": Number(this.radioDataList.serviceRaisedFor),
          "selectedFor": this.radioDataList.formValues.userType,
          // "plantID": this.radioDataList.plantID,
          "plantID" : 2,
          "supportID": 92,
          "empType": this.ITAssetForm.get('employeeType')?.value,
          "guest_Id": Number(this.radioDataList?.formValues?.guestEmployeeID) || 0,
          "guest_Name": this.radioDataList?.formValues?.guestName,
          "guest_Email": this.radioDataList?.formValues?.guestEmail,
          "guest_RManagerId": this.radioDataList.formValues?.reportingManagerID?.split('-')[0]?.trim() || 0,
          "guest_ContactNo":this.radioDataList.formValues?.guestContactNo? Number(this.radioDataList.formValues?.guestContactNo) : 0,
          "assettype": this.ITAssetForm.get('assetType')?.value,
          "emp_Id": Number(this.radioDataList.selfEmployeeID),
          "gxpReq": this.ITAssetForm.get('isGxpImpactValidation')?.value,
          "existingAsset": this.ITAssetForm.get('existingAsset')?.value,
          "assetModel": this.ITAssetForm.get('assetModel')?.value,
          "assetSerialNo": this.ITAssetForm.get('assetSerialNo')?.value,
          "assetsWarranty_EndDt": this.ITAssetForm.get('assetWarrantyEndDate')?.value ? new Date(this.ITAssetForm.get('assetWarrantyEndDate')?.value).toISOString() : null,
          "suggModel": this.ITAssetForm.get('suggestedModel')?.value,
          "specs_Requirements": this.ITAssetForm.get('specsRequirements')?.value,
          "approximateINR": Number(this.ITAssetForm.get('approximateValue')?.value),
          "justification": this.ITAssetForm.get('purposeOrJustification')?.value,
          "hoD_Approval": "",
          "isActive": true,
          "status": status,
          "createdBy": Number(this.radioDataList.selfEmployeeID)
        }
        this.httpSer.httpPost('/AssetRequest/SaveITAssets', param).subscribe(
          (response: any) => {
            if (response.type == 'S') {
              if (status == "Draft") {
                alert("Saved as a Draft Successfully!");
                this.router.navigate(['/assets/assetmaster']);
              }
              else {
                alert("Submitted Successfully!");
                this.router.navigate(['/assets/assetmaster']);
              }
            } else {
              alert("Submit Failed!");
            }
          }
        )
      }
    }
  }

  navigateToBack() {
    this.location.back();
  }

}
