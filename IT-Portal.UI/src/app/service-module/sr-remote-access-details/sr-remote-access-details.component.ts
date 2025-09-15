import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { SendEmailServiceService } from 'app/services/send-email-service.service';

interface DropdownAccessTypeItem {
  itemAccessType_id: number;
  itemAccessType_text: string;
}

@Component({
  selector: 'app-sr-remote-access-details',
  templateUrl: './sr-remote-access-details.component.html',
  styleUrls: ['./sr-remote-access-details.component.css', '../servicemodule.css']
})

export class SrRemoteAccessDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  srId: any;
  @Input() srData: any;
  remoteAccessForm!: FormGroup;
  radioDataList: any = [] = [];
  getPlantList: any = [] = [];
  attachMentList=[]
  @Input() currentUrl:any
  impactedPlant: any = '';
  attachmentFileName: string = '';
  softwareList:  any;
  versionList : any;
  selectedAccessType: DropdownAccessTypeItem[] = [];
  dropdownAccessTypeList: DropdownAccessTypeItem[] = [
    { itemAccessType_id: 1, itemAccessType_text: 'Dev' },
    { itemAccessType_id: 2, itemAccessType_text: 'UAT' },
    { itemAccessType_id: 3, itemAccessType_text: 'SAT' },
    { itemAccessType_id: 4, itemAccessType_text: 'Validation' },
    { itemAccessType_id: 5, itemAccessType_text: 'Quality' },
    { itemAccessType_id: 6, itemAccessType_text: 'Production' },
  ];

  dropdownAccessTypeSettings = {
    idField: 'itemAccessType_id',
    textField: 'itemAccessType_text',
  };
  softwareVList: any;

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

  viewFile(fileName: any): void {
    // const apiUrl = `${this.apiurl}/IssueList/View/${fileName.attachId}`;

    // this.http.get(apiUrl, { responseType: 'blob', observe: 'response' }).subscribe(
    //   (response) => {
    //     const contentType = response.headers.get('Content-Type');
    //     const blob = response.body as Blob;
    //     var fileURL = window.URL.createObjectURL(blob);
    //       const imageWindow = window.open(fileURL, '_blank');

    //   },
    //   (error: any) => {
    //     console.error('GET request failed', error);
    //   }
    // );
  }

  formInit() {
    this.remoteAccessForm = this.fb.group({
      requestType: [''],
      softwareName: ['', Validators.required],
      softwareVersion: ['',Validators.required],
      referenceDocument: ['', Validators.required],
      dateOfRemoteAccessRemoval: ['', Validators.required],
      dateOfRemoteAccess: ['', Validators.required],
      softwareApplicationAccessRemoval: ['', Validators.required],
      isServerAccess: ['', Validators.required],
      kindOfAccess: ['', Validators.required],
      isDowntimeRequired: ['', Validators.required],
      serverAccessType: [null, Validators.required],
      serverDetailsIPDetails: ['', Validators.required],
      vendorName: ['', Validators.required],
      vendorFocalName: ['', Validators.required],
      vendorFocalEmail: ['', [Validators.required, Validators.email]],
      accessStartTime: ['', Validators.required],
      accessEndTime: ['', Validators.required],
      justification: ['', Validators.required],
      attachment: ['', Validators.required],
    })
    this.remoteAccessForm.get('isServerAccess')?.valueChanges.subscribe((value: any) => {
      this.formValidationService.updateValidators(this.remoteAccessForm, ['kindOfAccess'], value == "Yes");
    })
    if (!this.srId) {
      this.getRequestType();
      this.getSoftwareList();
    }
  }

  requestTypeList: any[] = [];
  getRequestType() {
    this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: 81 }).subscribe((res: any) => {
      this.requestTypeList = res.reverse();
      if (this.srId) {
        this.remoteAccessForm.patchValue({ requestType: this.srData.supportId });
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

  getSoftwareList(){
    this.httpSer.httpGet('/SoftwareLibrary/GetSoftwarevalue').subscribe((response : any)=> {
      this.softwareList = response;
      if(this.srId){this.versionList = this.softwareList;
      }
    })

    
    this.httpSer.httpGet('/SoftwareLibrary/GetSoftwareVersionBySoftId').subscribe((response : any)=> {
      this.softwareVList = response;
      if(this.srId){
        this.versionList = this.softwareVList.filter(( m : any) =>m.softwareLibraryId == this.remoteAccessForm.controls['softwareName'].value && m.softVersionId)
    if(this.versionList){
      this.remoteAccessForm.patchValue({softwareVersion: Number(this.srData?.softVersion) });
    }
      }
    })
  }

  getVersionList(){
    this.versionList = this.softwareVList.filter(( m : any) =>m.softwareLibraryId == this.remoteAccessForm.controls['softwareName'].value && m.softVersionId)
    if(this.versionList){
      this.remoteAccessForm.patchValue({softwareVersion: ''});
    }
  }

  patchFormValues(data: any) {
    if (this.srId) {
      this.getRequestType();
      this.getSoftwareList();
    }

    this.remoteAccessForm.patchValue({
      softwareName: data.softName || '',
      softwareVersion: data.softVersion || '',
      referenceDocument: data.referDocument || '',
      dateOfRemoteAccess: data.doRemoteAccess?.split('T')[0],
      dateOfRemoteAccessRemoval: data.doRemovalAccess?.split('T')[0],
      softwareApplicationAccessRemoval: data.swRemoved == true ? 'Yes' : 'No' ,
      isServerAccess: data.serverAccess == true ? 'Yes' : 'No' ,
      kindOfAccess: data.kindAccess || '',
      isDowntimeRequired: data.downtimeRequired || '',
      serverAccessType: this.dropdownAccessTypeList.filter((m: any) => this.srData?.typeServerAccess.split(',').map((item: string) => item.trim()).includes(m.itemAccessType_text.toString())) || null,
      serverDetailsIPDetails: data.ipDetails || '',
      vendorName: data.venderName || '',
      vendorFocalName: data.venderFocalName || '',
      vendorFocalEmail: data.venderFocalEmailID || '',
      accessStartTime: data.accessStartTime ? data.accessStartTime.substring(0, 16) : null,
      accessEndTime: data.accessEndTime ? data.accessEndTime.substring(0, 16) : null,
      justification: data.justification || '',
      attachment: data.attachment || ''
    });

    if (data.attachment) {
      this.attachmentFileName = data.attachment.split("\\").pop();
    }

    if (this.srData?.status?.trim() != 'Draft') {
      this.remoteAccessForm.disable();
    }
  }

  allFieldValues = {
    softwareName: '',
    softwareVersion: '',
    referenceDocument: '',
    dateOfRemoteAccessRemoval: '',
    dateOfRemoteAccess: '',
    softwareApplicationAccessRemoval: '',
    isServerAccess: '',
    kindOfAccess: '',
    isDowntimeRequired: '',
    serverAccessType: null,
    serverDetailsIPDetails: '',
    vendorName: '',
    vendorFocalName: '',
    vendorFocalEmail: '',
    accessStartTime: '',
    accessEndTime: '',
    justification: '',
    attachment: ''
  }

  changeRequestTypeValue() {
    this.remoteAccessForm.patchValue(this.allFieldValues);
    this.attachMentList=[]
  }

  clearAll() {
    this.remoteAccessForm.patchValue({ requestType: '' });
    this.remoteAccessForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
  }

  Submit(status: any) {
    if(!this.formValidationService.validateStartAndEndDate(this.remoteAccessForm.value.accessStartTime, this.remoteAccessForm.value.accessEndTime,'accessStartTime','accessEndTime' )){
      return alert('End Date cannot be less than Start date')
    }
    let reqData = this.requestTypeList.filter((m:any) => m.supportId == this.remoteAccessForm.value.requestType)[0]

      if (status == 'Pending Approval') {
        status = (reqData?.isRpmreq &&
          reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending HOD Approval' : 'Approval not required'
      }


      if(this.attachMentList?.length==0&&!this.srId){
        alert('Add Attachment.')
        return
      }
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {

      if (this.formValidationService.validateForm(this.remoteAccessForm)) {
        const apiUrl = '/SRRemoteAccess/PostSRRemoteAccess';
        const requestBody = {
          "flag": this.srId ? "U" : "I",
          "srid": this.srId ? Number(this.srId) : 0,
          "srAccessID": this.srData ? this.srData.srAccessID : 0,
          "requestType": "",
          "supportID": Number(this.remoteAccessForm.get('requestType')?.value),
          "softName": this.remoteAccessForm.get('softwareName')?.value,
          "softVersion": this.remoteAccessForm.get('softwareVersion')?.value,
          "referDocument": this.remoteAccessForm.get('referenceDocument')?.value,
          "doRemovalAccess": this.remoteAccessForm.get('dateOfRemoteAccessRemoval')?.value ? new Date(this.remoteAccessForm.get('dateOfRemoteAccessRemoval')?.value).toISOString() : null,
          "swRemoved": this.remoteAccessForm.get('softwareApplicationAccessRemoval')?.value == 'Yes' ? true : false,
          "serverAccess": this.remoteAccessForm.get('isServerAccess')?.value == 'Yes' ? true : false,
          "kindAccess": this.remoteAccessForm.get('kindOfAccess')?.value,
          "downtimeRequired": this.remoteAccessForm.get('isDowntimeRequired')?.value,
          "typeServerAccess": this.remoteAccessForm.get('serverAccessType')?.value?.map((item: { itemAccessType_text: string }) => item.itemAccessType_text).join(', ') || '',
          "ipDetails": this.remoteAccessForm.get('serverDetailsIPDetails')?.value,
          "venderName": this.remoteAccessForm.get('vendorName')?.value,
          "venderFocalName": this.remoteAccessForm.get('vendorFocalName')?.value,
          "venderFocalEmailID": this.remoteAccessForm.get('vendorFocalEmail')?.value,
          "accessStartTime": this.remoteAccessForm.get('accessStartTime')?.value || null,
          "accessEndTime": this.remoteAccessForm.get('accessEndTime')?.value || null,
          "justification": this.remoteAccessForm.get('justification')?.value,
          "referenceDocument": '',
          "doRemoteAccess": this.remoteAccessForm.get('dateOfRemoteAccess')?.value ? new Date(this.remoteAccessForm.get('dateOfRemoteAccess')?.value).toISOString() : null,
          "isActive": true,
          "AttachmentIds" : this.attachMentList.map((m:any)=>m.attachId),
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
            "attachment": this.remoteAccessForm.get('attachment')?.value,
            "status": status,
            "assignedTo": 0,
            "assignedBy": 0,
            "assignedOn": "2024-10-16T09:28:59.543Z",
            "remarks": "",
            "proposedResolutionOn": "2024-10-16T09:28:59.543Z",
            "createdBy": Number(this.radioDataList.selfEmployeeID)
          }
        }

        this.httpSer.httpPost(apiUrl, requestBody).subscribe(
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

  removeAttchment(event:any){
    this.attachMentList=this.attachMentList.filter((m:any)=>m.attachId!=event)
    }
  getAttchmentList(event:any){
    this.attachMentList = event
  }
}
