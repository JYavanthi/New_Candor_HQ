import { Component, HostListener, Input, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SrDetailsSelfOthersGuestComponent } from 'app/service-module/sr-details-self-others-guest/sr-details-self-others-guest.component';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-it-spare',
  templateUrl: './it-spare.component.html',
  styleUrls: ['./it-spare.component.css', '../assetmodule.css']
})
export class ItSpareComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent

  showBackIcon: boolean = false;
  spareData: any;
  requestTypeList: any;
  spareId: any
  ITSpareForm!: FormGroup;
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
      this.spareId = m.spareid;
      if (this.spareId) {
        this.httpSer.httpGet('/ITSpareRequest/GetSpareById', { ID: this.spareId }).subscribe((res: any) => {
          this.spareData = res.data;
          this.changingTabs();
          this.patchFormValues(this.spareData)
        })
      }
    });
    this.formInit();

    this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: 5 }).subscribe((res: any) => {
      this.requestTypeList = res;
    })
  }

  formInit() {
    this.ITSpareForm = this.fb.group({
      requestType: [''],
      employeeType: ['', Validators.required],
      isGxpImpactValidation: ['', Validators.required],
      assetType: ['', Validators.required],
      spareType: ['', Validators.required],
      replacementSpareModel: ['', Validators.required],
      replacementSpareSerialNo: ['', Validators.required],
      specsRequirements: ['', Validators.required],
      purposeOrJustification: ['', Validators.required],
      specification: ['', Validators.required]
    });
  }

  @HostListener('window:scroll', [])
  onWindowScroll() {
    this.showBackIcon = window.scrollY > 200;
  }

  patchFormValues(data: any) {
    this.ITSpareForm.patchValue({
      requestType: data.requesttype || '',
      employeeType: data.empType || '',
      isGxpImpactValidation: data.gxpReq || '',
      assetType: data.assetType || '',
      spareType: data.spareType || '',
      replacementSpareModel: data.spareModel || '',
      replacementSpareSerialNo: data.spareSerialNo || '',
      specsRequirements: data.specsRequirements || '',
      purposeOrJustification: data.justification || '',
      specification: data.specification || ''
    })

    if (this.spareData?.status?.trim() != 'Draft') {
      this.ITSpareForm.disable();
    }
  }

  changingTabs() {
    if (this.spareId) {
      const notShowingApprovalTab = this.spareData?.status?.trim() == "Approval not required";
      if (notShowingApprovalTab) {
        this.selectedTabIndex = 1;
      }
      if (this.spareData?.status?.trim() == 'Resolved') {
        this.selectedTabIndex = 0;
        this.disableResolution = false;
      }
      else if (this.spareData?.status?.trim() == 'Approved' ||
        this.spareData?.status?.trim() == 'Seek Clarification' ||
        this.spareData?.status?.trim() == 'Open' ||
        this.spareData?.status?.trim() == 'In Progress' ||
        this.spareData?.status?.trim() == 'On Hold' ||
        this.spareData?.status?.trim() == 'Submit Clarification'
      ) {
        if (this.spareData?.isRpmreq == null && this.spareData?.isHodreq == null) {
          this.selectedTabIndex = 1;
          this.disableResolution = false;
        } else{
          this.selectedTabIndex = 2;
          this.disableResolution = false;
        }
      }
      else if (this.spareData?.status?.trim() == 'Pending Approval' || this.spareData?.status?.trim() == 'Rejected' || this.spareData?.status?.trim() == 'Pending HOD Approval') {
        this.selectedTabIndex = 1;
        this.disableResolution = true;
      }
    }
  }

  allFieldValues = {
    employeeType: '',
    isGxpImpactValidation: '',
    assetType: '',
    spareType: '',
    replacementSpareModel: '',
    replacementSpareSerialNo: '',
    specsRequirements: '',
    purposeOrJustification: '',
    specification: ''
  }

  changeRequestTypeValue() {
    this.ITSpareForm.patchValue(this.allFieldValues);
  }

  clearAll() {
    this.ITSpareForm.patchValue({ requestType: '' });
    this.ITSpareForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }

  Submit(status: any) {
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      let reqData = this.requestTypeList.filter((m: any) => m.supportId == 93)[0]
      if (status == 'Pending Approval') {
        status = (reqData?.isRpmreq &&
          reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
      }
      if (this.formValidationService.validateForm(this.ITSpareForm)) {
        const requestBody = {
          "flag": this.spareId ? "U" : "I",
          "itSpareID": this.spareId ? Number(this.spareId) : 0,
          "supportID": 93,
          // "plantID": this.radioDataList.plantID,
          "plantID" : 2 ,
          "requesttype": this.ITSpareForm.value.requestType,
          "requestedBY": Number(this.radioDataList.selfEmployeeID),
          "requestedFor": Number(this.radioDataList.serviceRaisedFor),
          "selectedFor": this.radioDataList.formValues?.userType,
          "guest_Id": Number(this.radioDataList?.formValues?.guestEmployeeID) || 0,
          "guest_Name": this.radioDataList?.formValues?.guestName,
          "guest_Email": this.radioDataList?.formValues?.guestEmail,
          "guest_RManagerId": Number(this.radioDataList.formValues?.reportingManagerID?.split('-')[0]) || 0,
          "guest_ContactNo": this.radioDataList.formValues?.guestContactNo?Number(this.radioDataList.formValues?.guestContactNo) :0,
          "empType": this.ITSpareForm.value.employeeType || '',
          "emp_Id": Number(this.radioDataList.selfEmployeeID),
          "gxpReq": this.ITSpareForm.value.isGxpImpactValidation || '',
          "asset_Type": this.ITSpareForm.value.assetType || '',
          "spare_Type": this.ITSpareForm.value.spareType || '',
          "spare_Model": this.ITSpareForm.value.replacementSpareModel || '',
          "spare_SerialNo": this.ITSpareForm.value.replacementSpareSerialNo || '',
          "specs_Requirements": this.ITSpareForm.value.specsRequirements || '',
          "specification": this.ITSpareForm.value.specification || '',
          "justification": this.ITSpareForm.value.purposeOrJustification || '',
          "hoD_Approval": "",
          "isActive": true,
          "status": status,
          "createdBy": Number(this.radioDataList.selfEmployeeID)
        }

        this.httpSer.httpPost('/ITSpareRequest/PostITSpare', requestBody).subscribe(
          (response: any) => {
            if (response.type == 'S') {
              if (status == "Draft") {
                alert("Saved as a Draft Successfully!");
                this.router.navigate(['/assets/sparemaster']);
              }
              else {
                alert("Submitted Successfully!");
                // this.sendEmail.getData(response?.data?.srId,this.currentUrl)
                this.router.navigate(['/assets/sparemaster']);
              }
            } else {
              alert("Submit failed!");
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
