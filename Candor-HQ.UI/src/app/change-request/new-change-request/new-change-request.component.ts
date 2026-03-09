import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PasscrdataService } from '../passcrdata.service';
import { GetEmployeeInfoService } from '../../services/get-employee-info.service'; import { environment } from '@environments/environment';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { MatDialog } from '@angular/material/dialog';
import { AddFilePopUpComponent } from '../add-file-pop-up/add-file-pop-up.component';
import { HttpServiceService } from 'shared/services/http-service.service';

interface DropdownItem {
  item_id: number;
  item_text: string;
}

interface DropdownDepartmentItem {
  itemdepartment_id: number;
  itemdepartment_text: string;
}

@Component({
  selector: 'app-new-change-request',
  templateUrl: './new-change-request.component.html',
  styleUrl: './new-change-request.component.css'
})
export class NewChangeRequestComponent {
  todaysDate = new Date().toISOString().slice(0, 10);
  showInitiator: boolean = false;
  showRiskQ: boolean = false;
  showRiskQ2: boolean = false;
  supportid: any;
  supportname: any;
  today: any;
  CheckGxPClassification: boolean = false;
  radioconfirmation: boolean = false;
  gxpradioconfirmation: boolean = false;
  emailconfirmation: boolean = false;
  plantcode: any[] = [];
  assignedPlantsArray: any[] = [];
  allEmpList: any[] = [];
  vflag: boolean = true;
  dropdownList: DropdownItem[] = [];
  RequestorPlant: string = '';
  isPopupVisible = false;
  plantData: any[] = [];
  supportId: any = '';
  classificationId: any = '';
  categoryId: any = '';
  crowner: any = '';
  crdate: any = '';
  changerequestedby: any = '';
  crrequestedDt: any = '';
  referenceid: any = '';
  referencetype: any = '';
  crinitiatedFor: any = '';
  crinitiate: any = '';
  setinitatorids: any = '';
  changeType: any = '';
  natureOfChange: any = '';
  priorityType: any[] = [];
  crpriority: any = '';
  plantId: any = '';
  sysLandscapeID: '';
  gxpclassification: any = '';
  gxpplantId: any = '';
  changeControlNo: any = '';
  changeControlDt: any = '';
  changeControlAttach: any = '';
  changeDesc: any = '';
  reasonForChange: any = '';
  alternateConsidetation: any = '';
  impactNotDoing: any = '';
  triggeredBy: any = '';
  benefits: any = '';
  estimatedCost: any = '';
  estimatedCostCurr: any = '';
  estimatedEffort: any = '';
  estimatedEffortUnit: any = '';
  estimatedDateCompletion: any = '';
  rollbackPlan: any = '';
  backoutPlan: any = '';
  downTimeRequired: any = '';
  downTimeFromDate: string = '';
  downTimeToDate: string = '';
  approvedBy: any = '';
  approvedDt: any = '';
  createdBy: any = '';
  createdDt: any = '';
  modifiedBy: any = '';
  modifiedDt: any = '';
  selectedCategory: any = '';
  categoryTypeId: any = '';
  reftype: any[] = [];
  priority: any;
  attach: any = '';
  supportteam: any[] = [];
  rfcDate: any;
  businessImpact: any = '';
  imactedFunc: any = '';
  plant: any = '';
  minEndDate: string = '';
  CheckDowntimeReq: boolean = false;
  successMessage: any = '';
  isSubmittedVal: boolean = false;
  EmailNotification: boolean = false;
  user: any = '';
  attachFlag = false

  dropdownSettings = {
    idField: 'item_id',
    textField: 'item_text',
  };

  dropdownListDepartment: DropdownDepartmentItem[] = [];
  dropdownDepartmentSettings = {
    idField: 'itemdepartment_id',
    textField: 'itemdepartment_text',
  };
  attachmentsList: any = [];
  MAX_FILE_SIZE = 1024 * 1024 * 5

  constructor(private http: HttpClient, private employeeInfo: GetEmployeeInfoService, private routeservice: PasscrdataService, private route: Router,
    private userInfo: UserInfoSerService, private dialog: MatDialog, private httpSer: HttpServiceService) {
    this.user = this.userInfo.getUser();
    this.supportId = parseInt(this.user?.empData?.employeeNo)

    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);

    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });
    this.employeeInfo.suppTeamList().then(() => {
      this.supportteam = this.employeeInfo.SupportTeamList;
    });
  }

  private apiurl = environment.apiurls

  ngOnInit() {
    this.fetchDropdownData();
    this.fetchDropdownDepartment();
    this.getclassification();
    this.getcrdata();
    this.getreference();
    this.getreferencetype();
    this.getinitator();
    this.fetchAllItems();
    this.getpriority();
    this.getsupportteams();
  }

  fetchDropdownData(): void {
    const apiUrl = this.apiurl + '/Plantid';
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdownList = data.map(item => ({
          item_id: item.id,
          item_text: item.code
        }));
      },
      (error) => {
      }
    );
  }

  selectedlocationNames: DropdownItem[] = [];
  impactedLocation: string = '';

  onSelectedItemsChange(): void {
    this.impactedLocation = this.selectedlocationNames.map((item: DropdownItem) => item.item_text).join(',');
  }

  fetchDropdownDepartment(): void {
    const apiUrl = this.apiurl + '/DepartmentMaster/GetDepartment';
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdownListDepartment = data.map(item => ({
          itemdepartment_id: item.id,
          itemdepartment_text: item.name
        }));
      },
      (error) => {
      }
    );
  }

  impactedDept: string = '';
  selecteddepartmentNames: DropdownDepartmentItem[] = [];
  onSelecteddepartmentItemsChange(): void {
    this.impactedDept = this.selecteddepartmentNames.map((item: DropdownDepartmentItem) => item.itemdepartment_text).join(',');
  }

  toggleInitiatorFields() {
    this.showInitiator = !this.showInitiator;
  }

  toggleField(event: any) {
    // this.showRiskQ = !this.showRiskQ;
    // if (!this.showRiskQ) {
    //   if (this.downTimeFromDate != '' || this.downTimeToDate != '' || this.selectedlocationNames.length != 0 || this.selecteddepartmentNames.length != 0 || this.imactedFunc != '') {
    //     this.radioconfirmation = true;
    //   }
    //   else {
    //     this.radioconfirmation = false;
    //   }
    // }

    const checkbox = event.target as HTMLInputElement
    if (checkbox.checked) {
      this.showRiskQ = true;
    }
    else {
      this.showRiskQ = false;
      if (this.downTimeFromDate || this.downTimeToDate || this.selectedlocationNames.length != 0 || this.selecteddepartmentNames.length != 0 || this.imactedFunc != '') {
        this.radioconfirmation = true;
      }
      else {
        this.radioconfirmation = false;
      }
    }
    /*if (!checkbox.checked) {

      }*/
  }

  Yes() {
    this.CheckDowntimeReq = false
    this.downTimeFromDate = '';
    this.downTimeToDate = '';
    this.selectedlocationNames = [];
    this.selecteddepartmentNames = [];
    this.imactedFunc = '';
    this.radioconfirmation = false;
    this.showRiskQ2 = false
  }

  No() {
    this.radioconfirmation = false;
    this.CheckDowntimeReq = false;
  }

  toggleField2(event: any) {

    const checkbox = event.target as HTMLInputElement
    if (checkbox.checked) {
      this.showRiskQ2 = true
    }
    else {
      this.showRiskQ2 = false;
      if (this.gxpplantId != '' || this.changeControlNo != '' || this.changeControlDt) {
        this.gxpradioconfirmation = true;
      }
      else {
        this.gxpradioconfirmation = false;
      }
    }
    /*if(!checkbox.checked){

      this.gxpradioconfirmation = true;
    }*/

  }

  gxpYes() {
    this.gxpplantId = '';
    this.CheckGxPClassification = false
    this.changeControlNo = '';
    this.changeControlDt = '';
    this.gxpradioconfirmation = false;
    this.showRiskQ2 = false;
  }

  gxpNo() {
    this.gxpradioconfirmation = false;
    this.CheckGxPClassification = false;
  }

  togglePopup() {
    this.isPopupVisible = !this.isPopupVisible;
  }

  addMore() {
    this.plantData.push({
      selectPlant: '',
      controlNumber: '',
      controlDate: '',
      attachment: null
    });
  }

  deleteDoc(Doc: any) {
    let url = '/ChangeRequest/Delete/' + Doc.attachId
    this.httpSer.httpDelete(url).subscribe(res => {
      this.attachmentsList = this.attachmentsList.filter((m: any) => Doc.attachId != m.attachId)
    })
  }
  delete(index: number) {
    this.plantData.splice(index, 1);
  }

  datetimefunction() {
    this.showRiskQ = true;
    this.updateEndDateMin();
    this.validateEndDate();
  }

  handleFileInput(event: any, index: number) {
    const file = event.target.files[0];
    this.plantData[index].attachment = file;
  }

  submitApprove(status: any) {
    let checkedLansScapes = this.systemlandscape.filter(m => m.isChcked == true).map(m => m.sysLandscapeId)
      .join(',')
    if (this.crinitiatedFor == "") {
      alert('Enter Initiator');
    }
    else if (this.plantId == "") {
      alert('Select Plant');
    }
    else if (this.crpriority == "") {
      alert('Select Priority');
    }
    else if (this.changerequestedby == "") {
      alert('Select Change Requested By');
    }
    else if (this.RequestorPlant == "") {
      alert('Requestor plant should not be empty');
    }
    else if (this.classificationId == "") {
      alert('Select Classification');
    }
    else if (this.selectedCategory == "") {
      alert('Select Category');
    }
    else if (this.categoryTypeId == "") {
      alert('Select Sub-Category');
    }
    else if (this.natureOfChange == "") {
      alert('Select Nature of Change');
    }
    else if (this.referenceid == "") {
      alert('Select Reference ');
    }
    else if (this.referencetype == "") {
      alert('Select Reference Type');
    }
    else if (!this.crrequestedDt) {
      alert('Select Change Requested On Date');
    }
    else if (this.triggeredBy == "") {
      alert('Select Change triggered By');
    }
    else if (this.changeDesc == "") {
      alert('Enter Change Description');
    }
    else if (this.reasonForChange == "") {
      alert('Enter Reason for Change');
    }
    else if (this.alternateConsidetation == "") {
      alert('Enter Alternate Consideration');
    }
    else if (this.impactNotDoing == "") {
      alert('Enter impact of not doing change');
    }
    else if (this.benefits == "") {
      alert('Enter benefits of doing change');
    }
    else if (this.businessImpact == "") {
      alert('Enter business impact if change is implemented');
    }
    else if (this.rollbackPlan == "") {
      alert('Enter Roll Back Plan');
    }
    else if (this.backoutPlan == "") {
      alert('Enter Back Out Plan');
    }
    else if (this.estimatedEffort.length == 0 || this.estimatedEffort == '') {
      alert('Please Enter Estimated Effort');
    }
    else if (this.estimatedEffortUnit == "") {
      alert('Select Effort Day(s)/Hour(s)');
    }
    else if (!this.estimatedDateCompletion) {
      alert('Select Expected Date of Completion');
    }
    else if (this.showRiskQ) {
      if (!this.downTimeFromDate) {
        alert('Select From Date');
      }
      else if (!this.downTimeToDate) {
        alert('Select End Date');
      }
      else if (this.selectedlocationNames.length == 0) {
        alert('Select Impacted Location');
      }
      else if (this.selecteddepartmentNames.length == 0) {
        alert('Select Impacted Department');
      }
      else if (this.imactedFunc == "") {
        alert('Enter Impacted Function');
      }
      else if (this.showRiskQ2) {
        if (!this.gxpplantId) {
          alert('Selectc GXP Plant');
        }
        else if (this.changeControlNo == "") {
          alert('Enter Change Control');
        }
        else if (!this.changeControlDt) {
          alert('Select Change Control Date');
        }
        else {
          this.ExecuteFunc(status)
        }
      }
      else {
        this.ExecuteFunc(status)
      }
    }
    else if (this.showRiskQ2) {
      if (!this.gxpplantId) {
        alert('Select GXP Plant');
      }
      else if (this.changeControlNo == "") {
        alert('Enter Change Control');
      }
      else if (!this.changeControlDt) {
        alert('Select Change Control Date');
      }
      else if (this.showRiskQ) {
        if (!this.downTimeFromDate) {
          alert('Select From Date');
        }
        else if (!this.downTimeToDate) {
          alert('Select End Date');
        }
        else if (this.selectedlocationNames.length == 0) {
          alert('Select Impacted Location');
        }
        else if (this.selecteddepartmentNames.length == 0) {
          alert('Select Impacted Department');
        }
        else if (this.imactedFunc == "") {
          alert('Enter Impacted Function');
        }
        else {
          this.ExecuteFunc(status)
        }
      }
      else {
        this.ExecuteFunc(status)
      }
    }
    else {
      this.ExecuteFunc(status)
    }
  }
  attachfile: any = '';


  ExecuteFunc(status: any) {
    if (status == "Draft") {
      this.isSubmittedVal = false;
    } else {
      this.isSubmittedVal = true;
    }
    this.attachfile = this.selectedFile.name;
    if (this.attachfile == undefined) {
      this.attachfile = '';
    }
    const apiUrl = this.apiurl + "/ChangeRequest/InsertChangeRequest";
    this.crinitiate = this.crinitiatedFor.split("-")[0];
    const changerequested = this.changerequestedby.split("-")[0];
    let checkedLansScapes = this.systemlandscape.filter(m => m.isChcked == true).map(m => m.sysLandscapeId)
      .join(',')

    const requestBody = {
      "type": "I",
      "itcrid": 0,
      "supportId": 1,
      "classifcationId": this.classificationId,
      "categoryId": this.selectedCategory,
      "categoryTypeId": this.categoryTypeId,
      "crowner": this.user?.empData?.employeeNo,
      "crdate": this.today,
      "crrequestedBy": changerequested,
      "crrEmailNotification": this.EmailNotification,
      "crrequestedDt": this.crrequestedDt,
      "crinitiatedFor": this.crinitiate,
      "status": status,
      "referenceId": this.referenceid,
      "referenceTyp": this.referencetype,
      "natureOfChange": this.natureOfChange,
      "priorityType": this.crpriority,
      // "plantId": this.plantId,
      "plantId" : 1,
      "sysLandscapeID": this.sysLandscapeID,
      "gxpclassification": this.CheckGxPClassification,
      "gxpplantId": this.gxpplantId ? this.gxpplantId : null,
      "changeControlNo": this.changeControlNo ? this.changeControlNo : null,
      "changeControlDt": this.changeControlDt ? this.changeControlDt : null,
      "changeControlAttach": false,
      "changeDesc": this.changeDesc,
      "reasonForChange": this.reasonForChange,
      "alternateConsidetation": this.alternateConsidetation ? this.alternateConsidetation : null,
      "impactNotDoing": this.impactNotDoing,
      "businessImpact": this.businessImpact,
      "triggeredBy": this.triggeredBy,
      "benefits": this.benefits ? this.benefits : null,
      "estimatedCost": this.estimatedCost,
      "estimatedCostCurr": this.estimatedCostCurr ? this.estimatedCostCurr : null,
      "estimatedEffort": this.estimatedEffort ? this.estimatedEffort : null,
      "estimatedEffortUnit": this.estimatedEffortUnit ? this.estimatedEffortUnit : null,
      "estimatedDateCompletion": this.estimatedDateCompletion ? this.estimatedDateCompletion : null,
      "rollbackPlan": this.rollbackPlan ? this.rollbackPlan : null,
      "backoutPlan": this.backoutPlan ? this.backoutPlan : null,
      "downTimeRequired": this.CheckDowntimeReq,
      "downTimeFromDate": this.downTimeFromDate ? this.downTimeFromDate : null,
      "downTimeToDate": this.downTimeToDate ? this.downTimeToDate : null,
      "impactedLocation": this.impactedLocation,
      "impactedDept": this.impactedDept,
      'imactedFunc': this.imactedFunc,
      "isSubmitted": this.isSubmittedVal,
      "isApproved": false,
      "isImplemented": false,
      "isReleased": false,
      "createdBy": this.user?.empData?.employeeNo,
      "SysLandscapeID": checkedLansScapes,
      "attachment": this.attachfile,
      "attachmentIds": this.attachmentsList.map((m: any) => m.attachId)
    }

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(apiUrl, requestBody, httpOptions).subscribe(
      (response: any) => {
        if (response.type == "E") {
          this.successMessage = response.message;
          alert(this.successMessage);
        }
        else {
          if (status == "Draft") {
            this.successMessage = 'Saved Successfully as Draft!';
            alert(this.successMessage);
            this.route.navigate(['/change-request']);
          }
          else if (requestBody.type == 'I') {
            this.successMessage = 'Submitted Successfully for RFC Pending Approval!';
            alert(this.successMessage);
            this.route.navigate(['/change-request']);
          }
          else {
            this.successMessage = 'Submitted Successfully for RFC Pending Approval!';
            alert(this.successMessage);
            this.route.navigate(['/change-request']);
          }
        }
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

  selectedFile: any = '';
  selectedFiles: File | undefined;

  getattach(event: any): void {
    this.selectedFiles = event.target.files[0];
  }


  openAddFile(crid: any) {
    const dialogRef = this.dialog.open(AddFilePopUpComponent, {
      data: {
        crId: crid
      }
    });
    dialogRef.afterClosed().subscribe(m => {
      if (m) {
        this.route.navigate(['/change-request']);
      }
    })
  }

  onFileSelected(event: any): void {
    this.selectedFiles = event.target.files[0];
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
    formData.append('Itcrid', '99999');
    formData.append('file', this.selectedFiles, this.selectedFiles.name);
    formData.append('FileName', this.selectedFiles.name);
    formData.append('Stage', 'CR');
    formData.append('CreatedBy', this.user?.empData?.employeeNo);
    formData.append('ModifiedBy', this.user?.empData?.employeeNo);

    const apiUrl = this.apiurl + '/ChangeRequest/addFile';

    this.http.post(apiUrl, formData).subscribe(
      (response: any) => {
        this.attachmentsList.push({
          attachId: response?.attachId,
          attachedFile: this.selectedFiles?.name,
          file: this.selectedFiles
        })
        this.attach = ''
      },
      (error: any) => {
        console.error('Error uploading files', error);
      }
    );
  }




  downFile(fileName: any): void {
    const apiUrl = `${this.apiurl}/ChangeRequest/Download/${fileName.attachId}`
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

  categorydata: any[] = [];
  supportcateory: any[] = [];

  getcategory() {
    const apiUrls = this.apiurl + '/Category'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.supportcateory = response.filter((item: any) => item.supportId === 1)
        this.categorydata = this.supportcateory.filter((item: any) => this.assignedcat.includes(item.itcategoryId));
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  getpriority() {
    const apiUrls = this.apiurl + '/Priority'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.priorityType = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  categoryfunctions() {
    this.categoryTypeId = '';
    this.natureOfChange = '';
    this.categorytype = [];
    this.Natureofchange = [];
    this.systemlandscape = [];
    this.vflag = true;
    this.showSavebtn(1);
    this.getcategorytype();
    this.getnature();
    this.getCheckList();
    this.chkapproverexists();
    this.getsystemlandscape();
  }

  wrkflow: any = '';
  showSavebtn(val: Number) {
    if (val == 0) {
      this.vflag = false;
    }
    else {
      if (this.vflag == false) { this.vflag = false; }
      else { this.vflag = true; }
    }
    this.wrkflow = '';
    if (!this.vflag) {
      if (this.wrkflowmsg1 != '' && this.wrkflowmsg != '')
        this.wrkflow = "Workflow for the Change and Category for this plant needs to be updated. Please reach Admin to complete RFC!"
      else if (this.wrkflowmsg1 == '' && this.wrkflowmsg !== '')
        this.wrkflow = this.wrkflowmsg
      else
        this.wrkflow = this.wrkflowmsg1
    }
  }

  Natureofchange: any[] = [];
  natureofcatid: any = '';
  naturecatid: any = '';

  getnature() {
    const apiUrls = this.apiurl + '/NatureofChange'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        const naturecatid = this.selectedCategory
        this.natureofcatid = naturecatid
        this.Natureofchange = response.filter((item: any) => item.categoryId.toString() === this.natureofcatid);
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  classifications: any[] = [];

  getclassification() {
    const apiUrls = this.apiurl + '/Classification'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.classifications = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  inatiatorid: any;
  setinitator() {
    if (this.sameinitator == false) {
      this.crinitiatedFor = this.user?.empData?.employeeNo + '-' + this.supportpersonname
    } else {
      this.crinitiatedFor = '';
    }
  }

  changerequest: any[] = [];

  getcrdata() {
    const apiUrls = this.apiurl + '/ChangeRequest/Getrequest'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.changerequest = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  categorytype: any[] = [];
  checkcatid: any = '';
  catidfilter: any = '';

  getcategorytype() {
    const apiUrls = this.apiurl + '/CategoryTyp'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        const checkcatid = this.selectedCategory;
        this.catidfilter = checkcatid
        this.categorytype = response.filter((item: any) => item.categoryId.toString() === this.catidfilter);
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  // referenceapi: any[] = [];
  refer: any[] = [];

  getreference() {
    const apiUrls = this.apiurl + '/Reference'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.refer = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  referencedrop: any[] = [];

  getreferencetype() {
    const apiUrls = this.apiurl + '/ReferenceType'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.reftype = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  sameinitator: boolean = false;
  getinitator() {
    if (this.sameinitator == true) {
      this.crinitiatedFor = this.user?.empData?.employeeNo
    } else {
      this.crinitiatedFor = '';
    }
  }

  updateEndDateMin() {
    const fromDate = new Date(this.downTimeFromDate);
    fromDate.setMinutes(fromDate.getMinutes() + 30);
    this.minEndDate = fromDate.toISOString().slice(0, 16);
  }

  validateEndDate() {
    if (!this.downTimeFromDate) {
      this.downTimeToDate = '';
      alert('Please select From Date!');
    } else {
      this.updateEndDateMin()
      const fromDate = new Date(this.downTimeFromDate).getTime();
      const endDate = new Date(this.downTimeToDate).getTime();

      if (endDate < fromDate + 30 * 60 * 1000) {
        alert("End Date and Time cannot be less than 30 minutes after the Start Date and Time.");
        this.downTimeToDate = this.minEndDate;
      }
    }
  }

  dropdownItems: string[] = [];
  dropdownItemscr: any[] = [];
  selectedValue: string = '';
  supportteamname: string[] = [];
  supportnames: string[] = [];

  async fetchAllItems() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.supportnames = this.supportteam.map(item => item.empId + '-' + item.firstName + " " + item.lastName);
        this.supportnames = this.supportnames.filter((value, index, self) => self.indexOf(value) === index)
        this.supportteamname = this.supportnames;
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  dropdownsupportteamid: any;
  filterItems() {
    const filter = this.crinitiatedFor.toUpperCase().trim();
    this.dropdownItems = this.supportteamname.filter(item =>
      item.toUpperCase().includes(filter)
    );
    if (this.dropdownItems.length === 0 && filter !== '') {
      this.dropdownItems.push('No name found');
    }
    else if (filter === '') {
      this.dropdownItems.length = 0
    }
  }

  selectItem(item: string) {
    this.selectedValue = item;
    this.crinitiatedFor = item.trim();
    this.dropdownItems = [];
  }

  filterItemscr() {
    const filter = this.changerequestedby.toUpperCase().trim();
    this.dropdownItemscr = this.allEmpList.filter(item =>
      item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
    );
    if (this.dropdownItemscr.length === 0 && filter === '') {
      this.dropdownItemscr.push('No name found');
    } else if (filter === '') {
      this.dropdownItemscr.length = 0;
    }
  }

  selectItemcr(item: any) {
    this.changerequestedby = (item.employeeId + '-' + item.employeeName).trim();
    this.RequestorPlant = item.plantcode;
    this.dropdownItemscr = [];
  }

  ClearPlant() {
    this.RequestorPlant = '';
  }

  systemlandscape: any[] = [];
  checkboxValues: any[] = ['Development', 'Quality', 'Validation', 'Production', 'Live'];
  wrkflowmsg1: any = '';

  getsystemlandscape() {
    const apiUrl = this.apiurl + '/SystemLandscape/Getsystems';

    if (this.selectedCategory && this.classificationId) {
      const requestBody = {
        "categroyId": this.selectedCategory,
        "supportId": 1,
        "classificationId": this.classificationId
      };
      this.http.post(apiUrl, requestBody).subscribe(
        (response: any) => {
          this.systemlandscape = response;
          this.systemlandscape.forEach(m => m['isChcked'] = true)
          if (this.systemlandscape.length == 0) {
            this.showSavebtn(0);
            this.wrkflowmsg1 = "Workflow is not defined for System Landscape. Please reach Admin to complete RFC!";
          }
          else {
            this.showSavebtn(1);
            this.wrkflowmsg1 = "";
          }
        },
        (error: any) => {
          console.error('POST request failed', error);
        }
      );
    }
    else {
      console.log('');
    }
  }

  approverN: any = '';
  approverR: any = '';
  approverC: any = '';
  approver: any[] = [];
  wrkflowmsg: any = '';

  chkapproverexists() {
    const apiUrl = this.apiurl + '/SupportTeam/supportteam';
    this.http.get<any[]>(apiUrl).subscribe(
      (response: any[]) => {
        this.approver = response.filter((item: any) => Number(item.plantId) === Number(this.plantId) && item.categoryId === Number(this.selectedCategory) && item.classificationId === Number(this.classificationId))
        this.approverN = this.approver.filter((item: any) => item.approverstage === 'N' && item.level === 1)
        this.approverR = this.approver.filter((item: any) => item.approverstage === 'R' && item.level === 1)
        this.approverC = this.approver.filter((item: any) => item.approverstage === 'C' && item.level === 1)

        if ((this.approverN.length === 0) || (this.approverR.length === 0) || (this.approverC.length === 0)) {
          this.showSavebtn(1);
          this.wrkflowmsg = "Workflow is not defined for Approvers. Please reach Admin to complete RFC!";
        }
        else {
          this.showSavebtn(1);
          this.wrkflowmsg = "";
        }
      },
      (error: any) => {
        console.error('No Approver ', error);
      });
  }

  supportteams: any[] = [];
  getsupportid: any;
  supportpersonname = '';
  firstname: any;
  middlename: any;
  lastname: any;
  emailofreciver: any;

  async getsupportteams() {
    try {
      await this.employeeInfo.suppTeamList();

      if (this.supportteam) {
        this.supportteams = this.supportteam.filter((row: any) => row.empId === parseInt(this.user?.empData?.employeeNo));
        this.getsupportid = this.supportteams[0].supportTeamId;
        this.firstname = this.supportteams[0].firstName;
        this.middlename = this.supportteams[0].middleName;
        this.lastname = this.supportteams[0].lastName;
        this.emailofreciver = this.supportteams[0].email.trim();
        if (this.firstname != null && this.firstname != undefined) {
          this.supportpersonname += this.firstname;
        }

        if (this.middlename != null && this.middlename != undefined) {
          if (this.supportpersonname !== '') {
            this.supportpersonname += ' ';
          }
          this.supportpersonname += this.middlename;
        }

        if (this.lastname !== null && this.lastname !== undefined) {
          if (this.supportpersonname !== '') {
            this.supportpersonname += ' ';
          }
          this.supportpersonname += this.lastname;
        }

        if (this.supportpersonname === '') {
          this.supportpersonname = 'Unknown';
        }

        if (this.supportpersonname === '') {
          this.supportpersonname = 'Unknown';
        }
        this.getsupportteamassign();
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  supportteamassign: any[] = [];
  ischangeanalyst: any;
  isapprover: any;
  issupportegineer: any;
  assignedplant: any;
  assignedcat: any;
  mapplant: any;
  mapcategory: any;

  async getsupportteamassign() {
    const apiUrls = this.apiurl + '/SupportteamAssigned'
    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.supportteamassign = response.filter((row: any) => row.supportTeamId === this.getsupportid);
        this.mapplant = this.supportteamassign.map((item: any) => item.plantId);
        this.assignedplant = Array.from(new Set(this.mapplant));
        this.mapcategory = this.supportteamassign.map((item: any) => item.categoryId);
        this.assignedcat = Array.from(new Set(this.mapcategory));
        this.isapprover = this.supportteamassign[0].isApprover
        this.issupportegineer = this.supportteamassign[0].isSupportEngineer
        this.ischangeanalyst = this.supportteamassign[0].isChangeAnalyst
        this.getcategory();
        this.getplant();
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  checklist: any[] = [];
  getCheckList() {
    const apiUrls = this.apiurl + '/CheckList'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.checklist = response.filter((item: any) => item.plantId === parseInt(this.plantId) && item.supportId === 1 && item.classificationId === parseInt(this.classificationId) && item.categoryId === parseInt(this.selectedCategory));
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  // getplant() {
  //   const apiUrls = this.apiurl + '/Plantid'
  //   this.http.get(apiUrls).subscribe(
  //     (response: any) => {
  //       this.plantcode = response.filter((item: any) => this.assignedplant.includes(item.id));
  //     },
  //     (error) => {
  //       console.error("Post failed", error)
  //     }
  //   )
  // }

  getplant() {
    const apiUrls = this.apiurl + '/Plantid';

    this.http.get(apiUrls).subscribe(
      (response: any[]) => {

        const empPlant = this.user.empData.plantId;
        this.plantcode = response.filter(
          (item: any) => item.plantId == empPlant
        );

      },
      (error) => {
        console.error("Plant API failed", error);
      }
    );
  }

}
