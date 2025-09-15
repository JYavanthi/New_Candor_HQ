import { Component, Input, SimpleChanges, ViewChild, ChangeDetectionStrategy, DebugElement } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { SrDetailsSelfOthersGuestComponent } from '../sr-details-self-others-guest/sr-details-self-others-guest.component';
import { SendEmailServiceService } from 'app/services/send-email-service.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { Console } from 'console';

@Component({
  selector: 'app-sr-email-details',
  templateUrl: './sr-email-details.component.html',
  styleUrls: ['./sr-email-details.component.css', '../servicemodule.css'],
  changeDetection:ChangeDetectionStrategy.OnPush,
})
export class SrEmailDetailsComponent {
  @ViewChild(SrDetailsSelfOthersGuestComponent) selfOthersGuest!: SrDetailsSelfOthersGuestComponent;

  mailGroups = ['Group A', 'Group B', 'Group C'];
  groups = ['Group A', 'Group B', 'Group C'];
  @Input() currentUrl: any
  srId: any;
  requestTypeList: any;
  @Input() srData: any
  emailForm: any
  userInfoSer: any
  user: any
  dropdownItems: any[] = [];
  addedMembers: any[] = [];
  searchText: any;
  emailGrpList: any;
  isFieldDisabled : boolean = false;
  subimited:any
  emailList:any
  API_URLS = {
    SAVE_SUPPORT: '/SRSoftware/SaveSupport',
    GET_PARENT_VALUE: '/SupportMaster/GetParentValue',
  }
  radioDataList: any;
  constructor(public fb: FormBuilder, private httpSer: HttpServiceService, public sendEmail: SendEmailServiceService, public userInfo: UserInfoSerService,
    public router: Router, private activeRoute: ActivatedRoute, public formValidationService: FormValidationService,
    public employeeInfo: GetEmployeeInfoService) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.srId = m.srId
    });
    this.user = this.userInfo.getUser()
    this.getGroup()
    this.getEmailList()
    this.formInIt();
  }

 async getEmailList(){
    await this.employeeInfo.empList()
    let list = this.employeeInfo.EmpList
    this.emailList=list.map(m=>m.officialEmailId?.toLocaleLowerCase()).filter(a=>a!='')
  }
  formInIt() {
    this.emailForm = this.fb.group({
      requestType: ['', Validators.required],
      intercomVoipNo: [null, Validators.required],
      mobileNumber: ['', Validators.required],
      isCommonId: ['', Validators.required],
      preferredEmailId: ['', [Validators.required, Validators.email]],
      allowOutsideCommunication: ['', Validators.required],
      mailAccessOnMobile: ['', Validators.required],
      addInMailGroups: ['', Validators.required],
      justification: ['', Validators.required],
      emailId: ['', [Validators.required, Validators.email]],
      commonIndividualId: ['', Validators.required],
      groupName: ['', Validators.required],
      members: [''],
      domain: ['', Validators.required],
      gbIncrease: ['', Validators.required],
      employeeType : ['',Validators.required],
      dateOfJoining :['', Validators.required],
      membersAdded : ['', Validators.required],
      membersTobeAdded : ['']
    });
    if (!this.srId) {
      this.getRequestType();
    }
  }

  drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );
    }
  }

  getRequestType() {
    this.httpSer.httpGet(this.API_URLS.GET_PARENT_VALUE, { ParentId: 36 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.srId) {
        this.emailForm.patchValue({ requestType: this.srData?.supportId })
      }
    })
  }

  getGroup() {
    this.httpSer.httpGet('/SREmail/GetSREmailGroups').subscribe((res: any) => {
      this.emailGrpList = res.data;
    })
  }

 ngOnChanges(changes: SimpleChanges) {
    if (changes['srData']) {
      if (this.srData != undefined) {

        this.patchFormValues(this.srData)
        this.patchMembersAdded();
      }
    }
  }

 async patchMembersAdded(){
  await this.employeeInfo.empList()
  let a=this.srData.memberAdded.split(',');
  this.addedMembers=this.employeeInfo.EmpList.filter(m=> a.includes(m.employeeId));
  this.isFieldDisabled = true;
  }

  patchFormValues(data: any) {
    if (this.srId) {
      this.getRequestType();
    }
    this.emailForm.patchValue({
      requestType: data.supportID || '',
      intercomVoipNo: data.intercom || null,
      mobileNumber: data.moblieNo || '',
      isCommonId: data.commonEmailID || '',
      preferredEmailId: data.preEmailID || '',
      allowOutsideCommunication: data.outsideComm || '',
      mailAccessOnMobile: data.mailAccess || '',
      addInMailGroups: data.mailGroup || '',
      justification: data.justification || '',
      emailId: data.emailID || '',
      commonIndividualId: data.commonEmailID || '',
      groupName: data.groupName || '',
      members: data.memberAdded || '',
      domain: data.description || '',
      gbIncrease: data.gb || '',
      employeeType: data.empType || '',
    });

    if (this.srData?.status.trim() != 'Draft') {
      this.emailForm.disable()
    }
  }

  filterItem(field : string) {
      var filter = this.emailForm.value.members.toUpperCase().trim();

      this.dropdownItems = this.employeeInfo?.EmpList?.filter((item: any) =>
      (item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter))&&
      !this.addedMembers.map(m=>m.employeeId).includes(item.employeeId)
      );
      if (this.dropdownItems.length === 0 && filter === '') {
        this.dropdownItems.push('');
      } else if (filter === '') {
        this.dropdownItems.length = 0;
      }
  }

  getDatafromRadios(updatedData: any) {
    this.radioDataList = updatedData;
    // this.bindePreferedEmail(updatedData)
    this.emailForm.patchValue({ dateOfJoining: this.radioDataList.formValues.userType == 'self' ? this.radioDataList?.selfDateOfJoining?.slice(0, 10) : this.radioDataList?.othersDateOfJoining?.slice(0, 10)
     })
     this.bindePreferedEmail()
    this.emailForm.controls['dateOfJoining'].disable();
  }

  allFieldValues = {
    intercomVoipNo: null,
    mobileNumber: '',
    isCommonId: '',
    mailAccessOnMobile: '',
    addInMailGroups: '',
    justification: '',
    emailId: '',
    commonIndividualId: '',
    groupName: '',
    members: '',
    domain: '',
    gbIncrease: '',
    employeeType: '',
    preferredEmailId : ''
  }

  changeRequestTypeValue() {
    this.emailForm.patchValue(this.allFieldValues);
    this.addedMembers=[];
    this.bindePreferedEmail();

    // if (this.radioDataList?.formValues?.userType == 'self') {
    //   this.emailForm.patchValue({
    //     emailId: (this.user.empData.officialEmailId)
    //   })
    // }
    // if (this.radioDataList?.formValues?.userType == 'others') {
    //   this.emailForm.patchValue({
    //     emailId: (this.user.empData.officialEmailId)
    //   })
    // }
    // this.dropdownItems = [];
  }

  clearAll() {
    this.emailForm.patchValue({ requestType: '' });
    this.emailForm.patchValue(this.allFieldValues);
    this.selfOthersGuest.resetFields();
    this.selfOthersGuest.getInputDatas();
  }

  submitEmail(status: any) {
    debugger
    if (this.emailForm.value.mobileNumber.toString().length<10 && (this.emailForm.value.requestType == '37' || this.emailForm.value.requestType == '38')) {
      alert("Please Enter 10-digit Mobile Number!");
      return 
    }
    if( this.emailList.includes(this.emailForm.value.preferredEmailId.toLocaleLowerCase())&&
  (this.emailForm.value.requestType == 37||this.emailForm.value.requestType == 38)){
      alert('Email id already exists.')
      return
    }
    let reqData = this.requestTypeList.filter((m: any) => m.supportId == this.emailForm.value.requestType)[0]
    if (status == 'Pending Approval') {
      status = (reqData?.isRpmreq &&
        reqData?.isHodreq) ? status : (!reqData?.isRpmreq && reqData?.isHodreq) ? 'Pending Hod Approval' : 'Approval not required'
    }
    this.subimited = true
    this.selfOthersGuest.executeFunc();
    if (this.radioDataList?.validationStatus == "Success") {
      if (this.formValidationService.validateForm(this.emailForm)) {
        const requestBody = {
          "flag": this.srId ? "U" : "I",
          "srid": this.srId ? Number(this.srId) : 0,
          'srEmailID': this.srData ? this.srData.srEmailID : 0,
          "supportID": Number(this.emailForm.value.requestType),
          "requesttype": "",
          "empID": 0,
          "empCategory": "",
          "empName": "",
          "designation": "",
          "department": "",
          "location": 0,
          "intercom": this.emailForm.value.intercomVoipNo?.toString().slice(0,16) || '',
          "moblieNo": this.emailForm.value.mobileNumber?.toString(),
          "reportManager": "",
          "hod": "",
          "commonEmailID": this.emailForm.value.isCommonId,
          "preEmailID": this.emailForm.value.preferredEmailId,
          "outsideComm": this.emailForm.value.allowOutsideCommunication,
          "emailID": this.emailForm.value.emailId,
          "mailGroup": this.emailForm.value.addInMailGroups,
          "mailAccess": this.emailForm.value.mailAccessOnMobile,
          "justification": this.emailForm.value.justification,
          "description": this.emailForm.value.domain,
          "empType": this.emailForm.value.employeeType,
          "gb": this.emailForm.value.gbIncrease?.toString(),
          "memberAdded": "",
          "empNo": this.addedMembers.map(m=>m.employeeId).join(','),
          "groupName": this.emailForm.value.groupName,
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
            "assignedOn": "2024-10-16T09:28:59.543Z",
            "remarks": "",
            "proposedResolutionOn": "2024-10-16T09:28:59.543Z",
            "createdBy": Number(this.radioDataList.selfEmployeeID)
          }
        };
        this.httpSer.httpPost('/SREmail/PostSREmail', requestBody).subscribe(
          (response: any) => {
            if (response.type == 'S') {
              if (status == "Draft") {
                alert("Saved as a Draft Successfully!");
                this.router.navigate(['/services/servicemaster']);
              }
              else {
                alert("Submitted Successfully!");
                this.sendEmail.getData(response?.data?.srId, this.currentUrl)
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

  onMobileNumberChange(event: any): void {
    const inputValue = event.target.value;
    if (inputValue.length > 10) {
      event.preventDefault();
      event.target.value = inputValue.slice(0, 10);
    }
    event.target.value = event.target.value.replace(/\D/g, '');
  }


  onVouIpChange(event: any): void {
    const inputValue = event.target.value;
    if (inputValue.length > 16) {
      event.preventDefault();
      event.target.value = inputValue.slice(0, 16);
    }
    event.target.value = event.target.value.replace(/\D/g, '');
  }

  gbToBeIncreasedInput(event: any): void {
    const inputValue = event.target.value;
    if (inputValue.length > 4) {
      event.preventDefault();
      event.target.value = inputValue.slice(0, 4);
    }
    event.target.value = event.target.value.replace(/\D/g, '');
  }


  async bindePreferedEmail() {
    if(this.srId){
      return
    }
  await this.radioDataList;
    if(this.subimited){
      return
    }
    if((this.emailForm.controls['requestType'].value == '37' || this.emailForm.controls['requestType'].value == '38' ||
      this.emailForm.controls['requestType'].value == '40' || this.emailForm.controls['requestType'].value == '94'
    )
      && (this.emailForm.controls['isCommonId'].value =='Common' || this.emailForm.controls['isCommonId'].value =='')){
      this.emailForm.patchValue({
        preferredEmailId: '', emailId : ''
      })
      return
    }

    if (this.radioDataList?.formValues?.userType == 'self') {
      this.emailForm.patchValue({
        emailId: (this.radioDataList.selfEmail)
      })
    } else if(this.radioDataList?.formValues?.userType == 'others'){
      this.emailForm.patchValue({
        emailId: (this.radioDataList.othersEmail)
      })
    }


    // if(event?.target.value=='Common'){
    //   this.emailForm.patchValue({
    //     preferredEmailId: ''
    //   })
    //   return
    // }

    if (this.radioDataList?.formValues?.userType == 'others' ) {
      let nameParts = [...this.radioDataList?.othersName?.split(' ').filter(Boolean)].join('.')
      this.emailForm.patchValue({
        preferredEmailId: ( `${nameParts.toLowerCase()}@microlabs.in`)
      })
    }
    if (this.radioDataList?.formValues?.userType == 'self') {
      let nameParts = [...this.radioDataList.selfName?.split(' ').filter(Boolean)].join('.')
      this.emailForm.patchValue({
        preferredEmailId: `${nameParts.toLowerCase()}@microlabs.in`
          
      })
    }
    if (this.radioDataList?.formValues?.userType == 'guest') {
      this.emailForm.patchValue({
        preferredEmailId: ''
      })
    }
  }

}
