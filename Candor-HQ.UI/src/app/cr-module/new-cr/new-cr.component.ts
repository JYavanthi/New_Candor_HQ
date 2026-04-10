import { Component, Input, SimpleChanges } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { FormValidationService } from 'app/services/form-validation.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { map, Observable } from 'rxjs';
import { DatePipe } from '@angular/common';
import { HttpServiceService } from 'shared/services/http-service.service';
import { ActivatedRoute } from '@angular/router';
import { environment } from '@environments/environment.development';
import { HttpClient } from '@angular/common/http';

interface DropdownItem {
  item_id: number;
  item_text: string;
}

interface DropdownDepartmentItem {
  itemdepartment_id: number;
  itemdepartment_text: string;
}

@Component({
  selector: 'app-new-cr',
  templateUrl: './new-cr.component.html',
  styleUrl: './new-cr.component.css'
})
export class NewCrComponent {
  public newCrForm!: FormGroup;
  plantsList: any = [];
  priorityList: any = [];
  classificationList: any = [];
  categoryList: any = [];
  categoryTypeList: any = [];
  user: any;
  selectedFiles: File|undefined;
  userData: any;
  crByList: any;
  natureOfChangeList: any = [];
  referenceList: any = [];
  referenceTypeList: any = [];
  supportteam: any[] = [];
  supportnames: string[] = [];
  supportteamname: string[] = [];
  plantList: DropdownItem[] = [];
  selectedlocationNames: DropdownItem[] = [];
  impactLocation: string = '';
  impactedDept: string = '';
  impactedDepartment: DropdownDepartmentItem[] = [];
  systemLandScapes: any[] = [];
  checkboxValues: any[] = ['Development', 'Quality', 'Validation', 'Production', 'Live'];
  allEmpList: any[] = [];
  private apiurl = environment.apiurl

  @Input() crData:any
  @Input() isImplement:any
  attach: any = '';
API_URLS = {
    PLANT: '/Plantid',
    PRIORITY: '/Priority',
    CLASSIFICATION: '/Classification',
    CATEGORY: '/Category',
    CATEGORY_TYPE: '/CategoryTyp',
    NATURE_OF_CHANGE: '/NatureofChange',
    REFERENCE: '/Reference',
    REFERENCE_TYPE: '/ReferenceType',
    DEPARTMENT: '/DepartmentMaster/GetDepartment',
    SYSTEM_LANDSCAPE: '/SystemLandscape/Getsystems',
    SUBMIT_CHANGE_REQUEST: '/ChangeRequest/InsertChangeRequest',
  };
  initaitorList: any;
  crId: any;
  changeRequestData: any;
  attachmentsList: any=[];
  MAX_FILE_SIZE=1024*1024*5
  populatedOutput: any;
  emailData: any;
  private fetchList(apiurls: string): Observable<any> {
    return this.httpSer.httpGet(apiurls);
  }

  impactedDepartmentList: DropdownDepartmentItem[] = [];
  departmentDropdown = {
    idField: 'itemdepartment_id',
    textField: 'itemdepartment_text',
  };

  constructor( private httpSer: HttpServiceService, private userInfo: UserInfoSerService,public http:HttpClient,
    public formValidSer: FormValidationService, private employeeInfo: GetEmployeeInfoService) {

    this.user = this.userInfo.getUser();
    this.userData = this.user.empData;
    this.employeeInfo.suppTeamList().then(() => {
      this.supportteam = this.employeeInfo.SupportTeamList;
      if (this.supportteam) {
        this.supportnames = this.supportteam.map(item => item.empId + '-' + item.firstName + " " + item.lastName);
        this.supportteamname = this.supportnames.filter((value, index, self) => self.indexOf(value) === index)
      }
    });

    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });
  }

  onCategoryChange() {
    this.getCategoryTypeList();
    this.getNatureOfChange();
    this.getsystemlandscape();
  }

  ngOnInit() {
    this.newCrFormFunc();
    this.onLoad();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['crData']) {
      if (this.crData) {
        if(!this.newCrForm){
          return
        }
        this.setData();
      }
    }
  }

  setData() {
    console.log("Cr Data", this.crData);
    this.newCrForm.patchValue({
      rfcDate: this.crData?.crdate,
      changeOwner: this.crData?.crowner,
      initiator: this.crData?.initiatedFor,
      plantId: this.crData?.plantcode,
      priority: this.crData?.priorityType,
      changeRequestedBy: this.crData?.crrequestorName,
      requestorPlant: this.crData?.requestorPlant,
      classifications: this.crData?.itclassificationId,
      category: this.crData?.itcategoryId,
      reference: this.crData?.referenceId,
      referenceType: this.crData?.referenceTyp,
      changeRequestedOn: this.crData?.crdate,
      changeDescription: this.crData?.changeDesc,
      notificationCheckBox: this.crData?.crremailNotification,
      rfcNo: this.crData?.crcode,
      approxCost: this.crData?.estimatedCost,
      currency: this.crData?.estimatedCostCurr,
      expectedCompletionDate: this.crData?.estimatedDateCompletion,
      reasonForChange : this.crData?.estimatedDateCompletion,
    })
    this.getCategoryTypeList()
    this.getNatureOfChange();
    this.getsystemlandscape();
    // changeTriggeredBy: this.crData?.initiatedFor,
    // notificationCheckBox: [''],
    // reasonForChange: this.crData?.initiatedFor,
    // alternateConsideration: this.crData?.initiatedFor,
    // impactOfNotDoingChnage: this.crData?.initiatedFor,
    // benefitsOfChange: this.crData?.initiatedFor,
    // businessImpact: this.crData?.initiatedFor,
    // rollBackPlan: this.crData?.initiatedFor,
    // backOutPlan: this.crData?.initiatedFor,
    // attachment: this.crData?.initiatedFor,
    // approxCost: this.crData?.initiatedFor,
    // currency: this.crData?.initiatedFor,
    // estimatedEffort: this.crData?.initiatedFor,
    // effortDays: this.crData?.initiatedFor,
    // expectedCompletionDate: this.crData?.initiatedFor,
    // downtimeRequired: this.crData?.initiatedFor,
    // fromDate:this.crData?.initiatedFor,
    // endDate : this.crData?.initiatedFor,
    // impactedFunction:this.crData?.initiatedFor,
    // gxpClassificationCheckBox :this.crData?.initiatedFor],
    // changeControlInput : this.crData?.initiatedFor,
    // changeControlDateInput :this.crData?.initiatedFor
    this.newCrForm.disable();
  }

  getattach(event: any): void {
    this.selectedFiles = event.target.files[0];
  }
  private newCrFormFunc() {
    this.newCrForm = new FormGroup({
      rfcNo: new FormControl(''),
      rfcDate: new FormControl(new Date().toISOString().slice(0, 10), Validators.required),
      changeOwner: new FormControl(`${this.userData.firstName ?? ''} ${this.userData.middleName ?? ''} ${this.userData.lastName ?? ''}`, Validators.required),
      initiator:new FormControl('', Validators.required),
      sameChangeOwnerCheckBox:new FormControl(false),
      plantId:new FormControl('', Validators.required),
      priority:new FormControl('', Validators.required),
      changeRequestedBy: new FormControl('', Validators.required),
      requestorPlant: new FormControl('', Validators.required),
      classifications: new FormControl('', Validators.required),
      category: new FormControl('', Validators.required),
      subCategory: new FormControl('', Validators.required),
      natureOfChange: new FormControl('', Validators.required),
      reference: new FormControl('', Validators.required),
      referenceType: new FormControl('', Validators.required),
      changeRequestedOn: new FormControl('', Validators.required),
      changeTriggeredBy: new FormControl('', Validators.required),
      notificationCheckBox: new FormControl(false),
      changeDescription: new FormControl('', Validators.required),
      reasonForChange: new FormControl('', Validators.required),
      alternateConsideration: new FormControl('', Validators.required),
      impactOfNotDoingChnage: new FormControl('', Validators.required),
      benefitsOfChange: new FormControl('', Validators.required),
      businessImpact: new FormControl('', Validators.required),
      rollBackPlan: new FormControl('', Validators.required),
      backOutPlan: new FormControl('', Validators.required),
      attachment: new FormControl('', Validators.required),
      approxCost: new FormControl('', Validators.required),
      currency: new FormControl('', Validators.required),
      estimatedEffort: new FormControl('', Validators.required),
      effortDays: new FormControl('', Validators.required),
      expectedCompletionDate: new FormControl('', Validators.required),
      downtimeRequired: new FormControl(false),
      fromDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required),
      impactedFunction: new FormControl('', Validators.required),
      gxpClassificationCheckBox: new FormControl(false),
      changeControlNo: new FormControl(''),
      changeControlDate: new FormControl(''),
      impactedLocation: new FormControl(''),
      impactedDepartment: new FormControl(''),
      gxpPlantId: new FormControl('', Validators.required),

    })

    if(this.crData){
      this.setData()
    }
  }

  setinitator(){
    if (this.newCrForm.value['sameChangeOwnerCheckBox'] == true) {
      const employeeNo = this.userData?.employeeNo ?? '';
      const ChangeOwner = this.newCrForm.value['changeOwner'] ?? '';
      this.newCrForm.patchValue({ initiator: `${this.userData?.employeeNo ?? ''} - ${this.newCrForm.value['changeOwner'] ?? ''}`});
      this.newCrForm.get('initiator')?.disable();
    } else {
      this.newCrForm.get('initiator')?.enable();
      this.newCrForm.patchValue({ initiator: '' });
    }
  }

  readHtmlFile(file: string): string {
    const xhr = new XMLHttpRequest();
    xhr.open('GET', file, false);
    xhr.send();
    if (xhr.status === 200) {
      return xhr.responseText;
    } else {
      console.error('Failed to read HTML file:', file);
      return '';
    }
  }
  sendEmila(){
    // this.subjecttxt = 
    // `Unnati:IT Change Request:${this.updatevalue[0].crcode} : Pending for Approval`
        const output = this.readHtmlFile('assets/email.html');

        this.populatedOutput = output
          // .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.approver1Names)
          // .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          // .replace('{{this.Cremailvalue[0].crdate}}', requestdate)
          // .replace('{{this.Cremailvalue[0].changeDesc}}', changeDesc)
          .replace('{{phase}}', 'RFC Submission')
          .replace('{{status}}', 'Pending Approval')
          // .replace('{{crapprover1}}', this.approver1Names)
          // .replace('{{crapprover2}}', this.approver2Names)
          // .replace('{{crapprover3}}', this.approver3Names)
          .replace('${status}', 'RFC Submitted')
          .replace('@Approval1Status', 'Pending')
          .replace('@Approval2Status', 'Queued')
          .replace('@Approval3Status', 'Queued')
          // .replace('{{BodyContent}}', 'Please find the details of the Change Request Submitted by ' + this.supportpersonname + ' and waiting for your Approval.');
      }
  

  deleteDoc(Doc:any){
    let url = '/ChangeRequest/Delete/'+Doc.attachId
    this.httpSer.httpDelete(url).subscribe(res=>{
      this.attachmentsList = this.attachmentsList.filter((m:any)=>Doc.attachId!=m.attachId)
    })
  }
  plantDropdown = {
    idField: 'item_id',
    textField: 'item_text',
  };
  getCrda() {
    let param = {
      crId: this.crId
    }
    const apiUrls = '/ViewChangeRequest/ViewChangerequest';
    this.httpSer.httpGet(apiUrls, param).subscribe(res => {
      this.changeRequestData = res[0]
    })
  }

  emailapproversinfo() {
    const apiUrl = this.apiurl + '/GetApproverforEmail/GetApproverEmail';
    const requestBody = {
      "stage": "N",
      "plantid": this.newCrForm.value?.plantId,
      "categoryId": this.newCrForm.value?.category,
      "classificationId": this.newCrForm.value?.subCategory
    }
    this.httpSer.httpPost(apiUrl, requestBody).subscribe(
      (response: any) => {
        this.emailData = response
      });
  }
  onLoad(){
    this.getPlantList();
    this.getPriorityList();
    this.getClassificationList();
    this.getCategoryList();
    this.getReferenceList();
    this.getreferenceTypeList();
    this.getDepartmentList();
  }

  getPlantList() {
    this.fetchList(this.API_URLS.PLANT).subscribe(res => {
      this.plantsList = res.filter((item: any) => item.id === this.user.empData.plantId);
      this.plantList = res.map((data: any) => ({
        item_id: data.id,
        item_text: data.code
      }));
    })

  }

  addFile(): void {
    if (!this.selectedFiles) {
      console.error('No files selected.');
      return;
    }
    if (this.selectedFiles.size > this.MAX_FILE_SIZE) {
      alert('File size must not exceed 5 MB.')
      return
    }
    

    const formData = new FormData();

      formData.append('file', this.selectedFiles, this.selectedFiles.name);
      formData.append('FileName', this.selectedFiles.name);
      formData.append('Stage', this.selectedFiles, 'N');
      formData.append('CreatedBy', this.selectedFiles, this.user?.empData?.employeeNo);
      formData.append('ModifiedBy', this.selectedFiles, this.user?.empData?.employeeNo);

    const apiUrl = this.apiurl + '/ChangeRequest';

    this.http.post(apiUrl, formData).subscribe(
      (response: any) => {
        this.attachmentsList.push({
          attachId:response?.attachId,
          attachedFile : this.selectedFiles?.name,
          file : this.selectedFiles
        })
        this.attach =''
      },
      (error: any) => {
        console.error('Error uploading files', error);
      }
    );
  }

  downFile(fileName:any): void {
    const apiUrl = this.apiurl+'/ChangeRequest/Download/'+fileName.attachId

    this.http.get(apiUrl, { responseType: 'blob' }).subscribe(
      (response: Blob) => {
        const url = window.URL.createObjectURL(response);
        const link = document.createElement('a');
        link.href = url;
        link.download = fileName.attachedFile;
        link.target = '_blank';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
        window.URL.revokeObjectURL(url);
      },
      (error: any) => {
        console.error('GET request failed', error);
      }
    );
  }
  
  viewFile(fileName: any): void {
    const apiUrl = `${this.apiurl}/ChangeRequest/View/${fileName.attachId}`;
  
    this.http.get(apiUrl, { responseType: 'blob', observe: 'response' }).subscribe(
      (response) => {
        const contentType = response.headers.get('Content-Type');
        const blob = response.body as Blob;
        var fileURL = window.URL.createObjectURL(blob);
          const imageWindow = window.open(fileURL, '_blank');
        
      },
      (error: any) => {
        console.error('GET request failed', error);
      }
    );
  }

  getPriorityList() {
    this.fetchList(this.API_URLS.PRIORITY).subscribe(res => {
      this.priorityList = res;
    })
  }

  getClassificationList() {
    this.fetchList(this.API_URLS.CLASSIFICATION).subscribe(res => {
      this.classificationList = res;
    })
  }

  getCategoryList() {
    this.fetchList(this.API_URLS.CATEGORY).subscribe(res => {
      this.categoryList = res;
    })
  }

  getCategoryTypeList() {
    this.fetchList(this.API_URLS.CATEGORY_TYPE).subscribe(res => {
      this.categoryTypeList = res.filter((item: any) => item.categoryId == this.newCrForm.controls['category'].value)
      if (this.crData) {
        this.newCrForm.controls['subCategory'].setValue(this.crData?.categoryTypeId)
      }
    })
  }

  submitForm( status: any) {
    if (this.formValidSer.validateForm(this.newCrForm)) {
       this.onSubmit(status)
    }
  }

  getNatureOfChange() {
    this.fetchList(this.API_URLS.NATURE_OF_CHANGE).subscribe(res => {
      this.natureOfChangeList = res.filter((item: any) => item.categoryId == this.newCrForm.controls['category'].value);
      if (this.crData) {
        this.newCrForm.patchValue({
          natureOfChange: this.natureOfChangeList.filter((m: any) => m.natureofChange1 == this.crData?.natureofChange)[0]?.natureofChangeId
        })
      }
    })
  }

  getReferenceList() {
    this.fetchList(this.API_URLS.REFERENCE).subscribe(res => {
      this.referenceList = res;
    })
  }

  getreferenceTypeList() {
    this.fetchList(this.API_URLS.REFERENCE_TYPE).subscribe(res => {
      this.referenceTypeList = res;
    })
  }

  getInitiatorList() {
    this.initaitorList = this.supportnames.filter(item =>
      item.toUpperCase().includes(this.newCrForm.controls['initiator'].value.toUpperCase())
    );
    if (this.initaitorList.length === 0 && this.newCrForm.controls['initiator'].value.toUpperCase() !== '') {
      this.initaitorList.push('No name found.');
    } else if (this.newCrForm.controls['initiator'].value.toUpperCase() == '') {
      this.initaitorList.length = 0
    }
  }

  selectItem(item: string) {
    this.newCrForm.patchValue({initiator:item.trim()})
    this.initaitorList = [];
  }

  getcrByList() {
    const filter = this.newCrForm.value.changeRequestedBy.toUpperCase().trim();
    this.crByList = this.allEmpList.filter(item =>
      item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
    );
   if (filter == '') {
      this.crByList.length = 0;
    }
  }

  selectItemcr(item: any) {
    this.newCrForm.patchValue({changeRequestedBy:(item.employeeId + '-' + item.employeeName).trim()})
    this.newCrForm.patchValue({requestorPlant:item.plantcode});
    this.crByList = [];
  }

  ClearReqPlant(){
    this.newCrForm.patchValue({requestorPlant:''});
  }

  getDepartmentList() {
    this.fetchList(this.API_URLS.DEPARTMENT).subscribe((data) => {
      this.impactedDepartmentList = data.map((item: any) => ({
        itemdepartment_id: item.id,
        itemdepartment_text: item.name
      }));
    },)
  }

  onSelectedItemsChange(): void {
    this.impactLocation = this.selectedlocationNames.map((item: DropdownItem) => item.item_text).join(',');
  }

  onSelecteddepartmentItemsChange(): void {
    this.impactedDept = this.impactedDepartment.map((item: DropdownDepartmentItem) => item.itemdepartment_text).join(',');
  }

  onSubmit(status : any) {
    let checkedLansScapes = this.systemLandScapes.filter(m => m.isChcked == true).map(m => m.sysLandscapeId)
      .join(',')
    const requestBody = {
      "type": "I",
      "itcrid": 0,
      "supportId": 1,
      "classificationId": this.newCrForm.value['classifications'],
      "categoryId": this.newCrForm.value['category'],
      "categoryTypeId": this.newCrForm.value['subCategory'],
      "crowner": this.user?.empData?.employeeNo,
      "crdate": this.newCrForm.value['rfcDate'],
      "crrequestedBy": this.newCrForm.value['changeRequestedBy'].split('-')[0],
      "crrEmailNotification": this.newCrForm.value['notificationCheckBox'],
      "crrequestedDt": this.newCrForm.value['changeRequestedOn'],
      "crinitiatedFor": this.newCrForm.value['initiator'],
      "status": status,
      "referenceId": this.newCrForm.value['reference'],
      "referenceTyp": this.newCrForm.value['referenceType'],
      "natureOfChange": this.newCrForm.value['natureOfChange'],
      "priorityType": this.newCrForm.value['priority'],
      "plantId": this.newCrForm.value['plantId'],
      "gxpclassification": this.newCrForm.value['gxpClassificationCheckBox'],
      "gxpplantId": this.newCrForm.value['gxpPlantId'] ? this.newCrForm.value['gxpPlantId'] : null,
      "changeControlNo": this.newCrForm.value['changeControlNo'] ? this.newCrForm.value['changeControlNo'] : null,
      "changeControlDt": this.newCrForm.value['changeControlDate'] ? this.newCrForm.value['changeControlDate'] : null,
      "changeControlAttach": false,
      "changeDesc": this.newCrForm.value['changeDescription'],
      "reasonForChange": this.newCrForm.value['reasonForChange'],
      "alternateConsidetation": this.newCrForm.value['alternateConsideration'] ? this.newCrForm.value['alternateConsideration'] : null,
      "impactNotDoing": this.newCrForm.value['impactOfNotDoingChnage'],
      "businessImpact": this.newCrForm.value['businessImpact'],
      "triggeredBy": this.newCrForm.value['changeTriggeredBy'],
      "benefits": this.newCrForm.value['benefitsOfChange'] ? this.newCrForm.value['benefitsOfChange'] : null,
      "estimatedCost": this.newCrForm.value['approxCost'] ? this.newCrForm.value['approxCost'] : null,
      "estimatedCostCurr": this.newCrForm.value['currency'] ? this.newCrForm.value['currency'] : null,
      "estimatedEffort": this.newCrForm.value['estimatedEffort'] ? this.newCrForm.value['estimatedEffort'] : null,
      "estimatedEffortUnit": this.newCrForm.value['effortDays'] ? this.newCrForm.value['effortDays'] : null,
      "estimatedDateCompletion": this.newCrForm.value['expectedCompletionDate'] ? this.newCrForm.value['expectedCompletionDate'] : null,
      "rollbackPlan": this.newCrForm.value['rollBackPlan'] ? this.newCrForm.value['rollBackPlan'] : null,
      "backoutPlan": this.newCrForm.value['backOutPlan'] ? this.newCrForm.value['backOutPlan'] : null,
      "downTimeRequired": this.newCrForm.value['downtimeRequired'],
      "downTimeFromDate": this.newCrForm.value['fromDate'] ? this.newCrForm.value['fromDate'] : null,
      "downTimeToDate": this.newCrForm.value['endDate'] ? this.newCrForm.value['endDate'] : null,
      "impactedLocation": this.impactLocation,
      "impactedDept": this.impactedDept,
      'imactedFunc': this.newCrForm.value['impactedFunction'],
      "isSubmitted": status == 'Draft' ? false : true,
      "isApproved": false,
      "isImplemented": false,
      "isReleased": false,
      "createdBy": this.user?.empData?.employeeNo,
      "SysLandscapeID": checkedLansScapes,
      "attachmentIds" : this.attachmentsList.map((m:any)=>m.attachId)
    }


    this.httpSer.httpPost('//ChangeRequest/InsertChangeRequest', requestBody).subscribe(
      (response: any) => {
        this.emailapproversinfo()
      })

  }

  getsystemlandscape() {
    if (this.newCrForm.value['category'] && this.newCrForm.value['classifications']) {
      const requestBody = {
        "categroyId": this.newCrForm.value['category'],
        "supportId": 1,
        "classificationId": this.newCrForm.value['classifications']
      };

      this.httpSer.httpPost(this.API_URLS.SYSTEM_LANDSCAPE, requestBody).subscribe(
        (response: any) => {
          this.systemLandScapes = response;
          this.systemLandScapes.forEach(m => m['isChcked'] = true)
          if (this.crData?.sysLandscapeId != null) {
            let checkedBox = this.crData?.sysLandscapeId.split(',')
            this.systemLandScapes.forEach(m => m['isChcked'] = (checkedBox.indexOf(m.sysLandscapeId.toString()) != -1) ? true : false)
            this.selectCheckboxes();
          }
        }
      )
    }
    (error: any) => {
      console.error('POST request failed', error);
    }
  }

  selectCheckboxes() {
    for (const item of this.systemLandScapes) {
      if (this.checkboxValues.includes(item.sysLandscape1)) {
        item.selected = true;
      }
    }
  }
}

