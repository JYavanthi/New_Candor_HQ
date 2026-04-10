import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../passcrdata.service';
import { GetEmployeeInfoService } from '../../../services/get-employee-info.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
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
  selector: 'app-updatechangerequest',
  templateUrl: './updatechangerequest.component.html',
  styleUrl: './updatechangerequest.component.css'
})

export class UpdatechangerequestComponent {
  showInitiator: boolean = false;
  showRiskQ: boolean = false;
  showRiskQ1: any = false;
  supportid: any;
  supportname: any;
  today: any;
  crid: any = '';
  isApproved: any = '';
  isImplemented: any = '';
  isReleased: any = '';
  isSubmitted: any = '';
  getstatus: any = '';
  CheckDowntimeReq: boolean = false;
  dropdownList: DropdownItem[] = [];
  radioconfirmation: boolean = false;
  gxpradioconfirmation: boolean = false;
  allEmpList: any[] = [];
  supportteam: any[] = [];
  plantData: any[] = [];
  selectedlocationNames: DropdownItem[] = [];
  impactedLocation: string = '';
  buttonfunction: boolean = false;
  isPopupVisible = false;
  itcrid: any = '';
  supportId: any = '';
  classificationId: any = '';
  categoryId: any = '';
  categorytypeid: any = '';
  crowner: any = '';
  crdate: any = '';
  changerequestedby: any = '';
  crrequestedDt: any = '';
  referenceid: any = '';
  referencetype: any = '';
  crinitiatedFor: any = '';
  changeType: any = '';
  natureOfChange: any = '';
  priorityType: any[] = [];
  plantId: any = '';
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
  businessImpact: any;
  impactedDept: any;
  imactedFunc: any;
  selectedCategory: any = '';
  SubCategory: any = '';
  SelectNatureOfChange: any = '';
  changecntroldt: any = '';
  minEndDate: string = '';
  categorydata: any[] = [];
  EmailNotification: boolean = false;
  isLoading: boolean = false;
  vflag: boolean = true;
  attach: any = '';

  dropdownSettings = {
    idField: 'item_id',
    textField: 'item_text',
  };

  dropdownListDepartment: DropdownDepartmentItem[] = [];
  dropdownDepartmentSettings = {
    idField: 'itemdepartment_id',
    textField: 'itemdepartment_text',
  };
  user: any;
  attachmentsList: any = [];
  selectedFiles: any;
  MAX_FILE_SIZE = 1024 * 1024 * 5;
  constructor(private http: HttpClient, private routeservice: PasscrdataService, public httpSer: HttpServiceService,
    private userInfo: UserInfoSerService, private employeeInfo: GetEmployeeInfoService, private route: ActivatedRoute, private router: Router) {
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;
    this.user = this.userInfo.getUser();
    // this.user=userInfo.getUser();
    // this.supportId = parseInt(this.user?.empData?.employeeNo)
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);

    this.routeservice.crdata.subscribe(data => {
      this.crid = data?.report?.value;
      if (this.crid) {
        this.getstatus = this.crid?.status?.trim();
        this.isApproved = this.crid.isApproved;
        this.isImplemented = this.crid.isImplemented;
        this.isReleased = this.crid.isReleased;
        this.isSubmitted = this.crid.isSubmitted;
      }
    })
    this.itcrid = this.route.snapshot.paramMap.get('id');
    this.getFileData()
    this.fetchDropdownData();
    this.fetchDropdownDepartment();
    

    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });

    this.employeeInfo.suppTeamList().then(() => {
      this.supportteam = this.employeeInfo.SupportTeamList;
    });
  }
  private apiurl = environment.apiurls;

  ngOnInit(): void {
    this.load();
    setTimeout(() => {
      this.getsupportteams();
      this.getCheckList();
      this.getFileData();
      this.getupdatyevalue(this.itcrid);
    }, 500);
  }

  load() {
    this.getclassification();
    this.getnature();
    this.getcrdata();
    this.getreference();
    this.getreferencetype();
    this.getpriority();
    this.hidebutton();
  }


  async fetchDropdownData() {
    const apiUrl = this.apiurl + '/Plantid';
    try {
      const data: any = await this.http.get(apiUrl).toPromise();

      if (data) {
        this.dropdownList = data.map((item: any) => ({
          item_id: item.id,
          item_text: item.code
        }));
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  async fetchDropdownDepartment() {
    const apiUrl = this.apiurl + '/DepartmentMaster/GetDepartment';
    try {
      const data: any = await this.http.get(apiUrl).toPromise();

      if (data) {
        this.dropdownListDepartment = data.map((item: any) => ({
          itemdepartment_id: item.id,
          itemdepartment_text: item.name
        }));
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }


  onSelectedItemsChange(): void {
    this.impactedLocation = this.selectedlocationNames.map((item: DropdownItem) => item.item_text).join(',');
  }

  hidebutton() {
    if (this.getstatus == 'Draft' || this.getstatus == 'Seek Clarification' && this.ischangeanalyst == true) {
      this.buttonfunction = true
    }
    else {
      this.buttonfunction = false
    }
  }

  toggleInitiatorFields() {
    this.showInitiator = !this.showInitiator;
  }

  toggleField(event: any) {
    // this.showRiskQ = !this.showRiskQ;
    /*const checkbox = event.target as HTMLInputElement
    if(checkbox.checked){
      this.showRiskQ = true
    }
    if (!checkbox.checked) {
      this.radioconfirmation=true
      // if (this.updatevalue[0].downTimeFromDate != '' || this.updatevalue[0].downTimeToDate != '' || this.updatevalue[0].impactedLocation != 0 || this.updatevalue[0].impactedDept != 0 || this.updatevalue[0].imactedFunc != '') {
        this.radioconfirmation = true;
      // }
    }*/

    const checkbox = event.target as HTMLInputElement
    if (checkbox.checked) {
      this.showRiskQ = true;
    }
    else {
      this.showRiskQ = false;
      if (this.updatevalue[0].downTimeFromDate || this.updatevalue[0].downTimeToDate || this.selectedlocationNames.length != 0 || this.selecteddepartmentNames.length != 0 || this.updatevalue[0].imactedFunc != '') {
        this.radioconfirmation = true;
      }
      else {
        this.radioconfirmation = false;
      }
    }
  }

  Yes() {
    this.Value.downTimeFromDate = '';
    this.Value.downTimeToDate = '';
    this.Value.impactedLocation = '';
    this.Value.impactedDept = '';
    this.Value.imactedFunc = '';
    this.selectedlocationNames = []
    this.selecteddepartmentNames = []
    this.radioconfirmation = false;
    this.CheckDowntimeReq = false
  }

  No() {
    this.radioconfirmation = false;
    this.CheckDowntimeReq = false
  }

  togglePopup() {
    this.isPopupVisible = !this.isPopupVisible;
  }

  wrkflow: any = '';
  wrkflowmsg1: any = '';
  wrkflowmsg: any = '';

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

  addMore() {
    this.plantData.push({
      selectPlant: '',
      controlNumber: '',
      controlDate: '',
      attachment: null
    });
  }

  delete(index: number) {
    this.plantData.splice(index, 1);
  }

  datetimefunction() {
    this.showRiskQ = true;
    this.updateEndDateMin();
    this.validateEndDate();
  }

  updateEndDateMin() {
    const fromDate = new Date(this.Value.downTimeFromDate);
    fromDate.setMinutes(fromDate.getMinutes() + 30);
    this.minEndDate = fromDate.toISOString().slice(0, 16);
  }

  validateEndDate() {
    if (!this.Value.downTimeFromDate) {
      this.Value.downTimeToDate = '';
      alert('Please select From Date!');
    } else {
      this.updateEndDateMin()
      const fromDate = new Date(this.Value.downTimeFromDate).getTime();
      const endDate = new Date(this.Value.downTimeToDate).getTime();

      if (endDate < fromDate + 30 * 60 * 1000) {
        alert("End Date and Time cannot be less than 30 minutes after the Start Date and Time.");
        this.Value.downTimeToDate = this.minEndDate;
      }
    }
  }
  handleFileInput(event: any, index: number) {
    const file = event.target.files[0];
    this.plantData[index].attachment = file;
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

  toggleField2(event: any) {
    // this.showRiskQ1 = !this.showRiskQ1;
    const checkbox = event.target as HTMLInputElement
    if (checkbox.checked) {
      this.showRiskQ1 = true
    }
    else {
      this.showRiskQ1 = false;
      if (this.updatevalue[0].gxpplantId != 0 || this.updatevalue[0].changeControlNo != '' || this.updatevalue[0].changeControlDt != 0) {
        this.gxpradioconfirmation = true;
      }
      else {
        this.gxpradioconfirmation = false;
      }
    }
  }

  gxpYes() {
    this.showRiskQ1 = false
    this.updatevalue[0].gxpplantId = '';
    this.updatevalue[0].changeControlNo = '';
    this.updatevalue[0].changeControlDt = '';
    this.gxpradioconfirmation = false;
  }

  gxpNo() {
    //this.showRiskQ1 = true
    this.gxpradioconfirmation = false;
    this.CheckGxPClassification = false;
  }

  supportcateory: any[] = [];
  async getcategory() {
    const apiUrls = this.apiurl + '/Category'
    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.supportcateory = response.filter((item: any) => item.supportId === 1)
        this.categorydata = this.supportcateory.filter((item: any) => this.assignedcat.includes(item.itcategoryId));
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  Natureofchange: any[] = [];
  parseToInt(value: string): number {
    return parseInt(value, 10);
  }

  getnature() {
    const apiUrls = this.apiurl + '/NatureofChange'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        const catid: number = this.selectedCategory;
       // this.Natureofchange = response.filter((item: any) => parseInt(item.categoryId) == natureID);
        this.Natureofchange = response.filter((item: any) => parseInt(item.categoryId) == catid);
      },
      (error) => {
        console.error("Post failed", error)
      }
    
    )
  }

  classifications: any[] = [];

  getclassification() {
    const apiUrls = this.apiurl + '/Classification';
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.classifications = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  plantcode: any[] = [];
  plant: any;

  getplant() {
    const apiUrls = this.apiurl + '/Plantid'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.plantcode = response.filter((item: any) => this.assignedplant.includes(item.plantId));
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
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

  async getcategorytype() {
    const apiUrls = this.apiurl + '/CategoryTyp'
    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {

        var catID: number = this.selectedCategory;
        this.categorytype = response.filter((item: any) => parseInt(item.categoryId) == catID);
        if (this.Value) {
          this.SubCategory = this.Value?.categoryTypeId
        }
        this.getnature();
        this.getCheckList();
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  referenceapi: any[] = [];

  getreference() {
    const apiUrls = this.apiurl + '/Reference'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.referenceapi = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  refer: any;
  getreferencetype() {
    const apiUrls = this.apiurl + '/ReferenceType'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.refer = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  isapproved: any;
  updatevalue: any = '';
  crdesc: any = '';
  crdateval: any = '';
  CheckGxPClassification: boolean = false;
  Value: any = '';
  plantvalue!: number;
  RequestorPlant: string = '';
  NatureOfChange: any = '';
  async getupdatyevalue(itcrid: any) {
    const apiUrls: any = this.apiurl + '/ChangeRequest/Getrequest';
    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.updatevalue = response.filter((item: any) => item.itcrid.toString() === itcrid.toString());
        this.iniatorid()
        this.Value = this.updatevalue[0];
        this.routeservice.setCrData(this.Value);
        setTimeout(() => {
        this.selectedCategory = Number(this.Value.categoryId);
        this.SubCategory = this.Value.categoryTypeId;
        //this.SelectNatureOfChange = this.Value.natureOfChange?.toString();
        this.NatureOfChange = Number(this.Value.natureOfChange);
        this.plantvalue = this.Value.plantId;
        this.EmailNotification = this.Value.crremailNotification;
        this.isapproved = this.updatevalue[0].isApproved;
        this.crdesc = this.updatevalue[0].changeDesc;
        this.crdateval = this.updatevalue[0].crdate;
        this.classificationId = this.updatevalue[0].classificationId;
        this.plantid = this.updatevalue[0].plantId;
        this.plantData.push(this.updatevalue);
        this.attach = this.Value.attachment;
        if (this.updatevalue[0].downTimeRequired == true) {
          this.CheckDowntimeReq = true;
          this.showRiskQ = true;
        }

        if (this.updatevalue[0].gxpclassification == true) {
          this.CheckGxPClassification = true;
          this.showRiskQ1 = true;
        }
        this.getcategorytype();
        this.crrequestors();
        this.getsystemlandscape();
        this.fetchAllItems();

        
        const impactedLocations = this.Value.impactedLocation.split(',');
        this.selectedlocationNames = this.dropdownList.filter(item => impactedLocations.includes(item.item_text));
        this.Value.impactedLocation = this.selectedlocationNames;
        const impactedDepartments = this.Value.impactedDept.split(',');
        this.selecteddepartmentNames = this.dropdownListDepartment.filter(item => impactedDepartments.includes(item.itemdepartment_text));
        this.Value.impactedDept = this.selecteddepartmentNames;
        }, 100);
        await this.fetchDropdownData();
        await this.fetchDropdownDepartment();
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
    
    console.log('natureOfChange',this.NatureOfChange);
  }

  async getsystemlandscape() {
    const apiUrl = this.apiurl + '/SystemLandscape/Getsystems';
    const requestBody = {
      "categroyId": Number(this.selectedCategory),
      "supportId": this.updatevalue[0].supportId,
      "classificationId": Number(this.classificationId)
    };
    try {
      const response: any = await this.http.post(apiUrl, requestBody).toPromise();

      if (response) {
        this.systemlandscape = response;
        if (this.updatevalue[0]['sysLandscapeId'] != null) {
          let checkedVlues = this.updatevalue[0]['sysLandscapeId'].split(',')
          console.log('syslandscape',checkedVlues);
          this.systemlandscape.forEach(m => m['isChcked'] = (checkedVlues.indexOf(m.sysLandscapeId.toString()) != -1) ? true : false)
          //this.selectCheckboxes();
          setTimeout(() => {
            this.selectCheckboxes();
          }, 100);
        }
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  // selectCheckboxes() {
  //   for (const item of this.systemlandscape) {
  //     if (this.checkboxValues.includes(item.sysLandscape1)) {
  //       item.selected = true;
  //     }
  //   }
  // }
  selectCheckboxes() {
  if (!this.systemlandscape?.length || !this.checkboxValues?.length) return;

  this.systemlandscape.forEach(item => {
    item.selected = this.checkboxValues.includes(item.sysLandscape1);
  });
}


  selecteddepartmentNames: DropdownDepartmentItem[] = [];
  onSelecteddepartmentItemsChange(): void {
    this.impactedDept = this.selecteddepartmentNames.map((item: DropdownDepartmentItem) => item.itemdepartment_text).join(',');
  }

  updatedvalue = [
    { crdate: new Date() },
  ];

  formatDate(date: Date): string {
    return date.toISOString().slice(0, 10);
  }
  splitvalue: any = '';

  Updatecr(status: any) {
    if (this.Value.priorityType == "") {
      alert('Select Priority');
    }
    else if (this.setcreniatorname == "") {
      alert('Select Change Requested By');
    }
    else if (this.RequestorPlant == "") {
      alert('Requestor plant should not be empty');
    }
    else if (this.Value.classificationId == "") {
      alert('Select Classification');
    }
    else if (this.Value.categoryId == "" || this.selectedCategory == '') {
      alert('Select Category');
    }
    else if (this.Value.categoryTypeId == "" || this.SubCategory == '') {
      alert('Select Sub-Category');
    }
    else if (this.Value.natureOfChange == "" || this.NatureOfChange == '') {
      alert('Select Nature of Change');
    }
    else if (this.Value.referenceId == "") {
      alert('Select Reference ');
    }
    else if (this.Value.referenceTyp == "") {
      alert('Select Reference Type');
    }
    else if (!this.Value.crrequestedDt) {
      alert('Select Change Requested On Date');
    }
    else if (this.Value.triggeredBy == "") {
      alert('Select Change triggered By');
    }
    else if (this.updatevalue[0].changeDesc == "" || this.updatevalue[0].changeDesc == null) {
      alert('Enter Change Description');
    }
    else if (this.updatevalue[0].reasonForChange == "" || this.updatevalue[0].reasonForChange == null) {
      alert('Enter Reason for Change');
    }
    else if (this.updatevalue[0].alternateConsidetation == "" || this.updatevalue[0].alternateConsidetation == null) {
      alert('Enter Alternate Consideration');
    }
    else if (this.updatevalue[0].impactNotDoing == "" || this.updatevalue[0].impactNotDoing == null) {
      alert('Enter impact of not doing change');
    }
    else if (this.updatevalue[0].benefits == "" || this.updatevalue[0].benefits == null) {
      alert('Enter benefits of doing change');
    }
    else if (this.updatevalue[0].businessImpact == "" || this.updatevalue[0].businessImpact == null) {
      alert('Enter business impact if change is implemented');
    }
    else if (this.updatevalue[0].rollbackPlan == "" || this.updatevalue[0].rollbackPlan == null) {
      alert('Enter Roll Back Plan');
    }
    else if (this.updatevalue[0].backoutPlan == "" || this.updatevalue[0].backoutPlan == null) {
      alert('Enter Back Out Plan');
    }
    else if (this.updatevalue[0].estimatedEffort.length == 0 || this.updatevalue[0].estimatedEffort == '') {
      alert('Please Enter Estimated Effort');
    }
    else if (this.updatevalue[0].estimatedEffortUnit == "") {
      alert('Select Effort Day(s)/Hour(s)');
    }
    else if (!this.updatevalue[0].estimatedDateCompletion || this.updatevalue[0].estimatedDateCompletion == '') {
      alert('Select Expected Date of Completion');
    }
    else if (this.showRiskQ) {
      if (!this.updatevalue[0].downTimeFromDate || this.updatevalue[0].downTimeFromDate == '') {
        alert('Select From Date');
      }
      else if (!this.updatevalue[0].downTimeToDate || this.updatevalue[0].downTimeToDate == '') {
        alert('Select End Date');
      }
      else if (this.selectedlocationNames.length == 0) {
        alert('Select Impacted Location');
      }
      else if (this.selecteddepartmentNames.length == 0) {
        alert('Select Impacted Department');
      }
      else if (this.updatevalue[0].imactedFunc == "") {
        alert('Enter Impacted Function');
      }
      else if (this.showRiskQ1) {
        if (!this.updatevalue[0].gxpplantId) {
          alert('Select GXP Plant');
        }
        else if (!this.updatevalue[0].changeControlNo) {
          alert('Enter Change Control');
        }
        else if (!this.updatevalue[0].changeControlDt || this.updatevalue[0].changeControlDt == '') {
          alert('Select Change Control Date');
        }
        else {
          this.ExecuteFunc(status);
        }
      }
      else {
        this.ExecuteFunc(status);
      }
    }
    else if (this.showRiskQ1) {
      if (!this.updatevalue[0].gxpplantId) {
        alert('Select GXP Plant');
      }
      else if (!this.updatevalue[0].changeControlNo) {
        alert('Enter Change Control');
      }
      else if (!this.updatevalue[0].changeControlDt || this.updatevalue[0].changeControlDt == '') {
        alert('Select Change Control Date');
      }
      else if (this.showRiskQ) {
        if (!this.updatevalue[0].downTimeFromDate || this.updatevalue[0].downTimeFromDate == '') {
          alert('Select From Date');
        }
        else if (!this.updatevalue[0].downTimeToDate || this.updatevalue[0].downTimeToDate == '') {
          alert('Select End Date');
        }
        else if (this.selectedlocationNames.length == 0) {
          alert('Select Impacted Location');
        }
        else if (this.selecteddepartmentNames.length == 0) {
          alert('Select Impacted Department');
        }
        else if (this.updatevalue[0].imactedFunc == "") {
          alert('Enter Impacted Function');
        }
        else {
          this.ExecuteFunc(status);
        }
      }
      else {
        this.ExecuteFunc(status);
      }
    }
    else {
      this.ExecuteFunc(status);
    }
  }
  attachfile: any = '';
  ExecuteFunc(status: any) {
    this.attachfile = this.selectedFile.name;
    if (this.attachfile == undefined) {
      this.attachfile = this.updatevalue[0].attachment;
    }
    const apiUrl = this.apiurl + "/ChangeRequest/InsertChangeRequest";
    const crinitiate = this.setiniatorname.split("-")[0];
    const changerequested = this.setcreniatorname.split("-")[0];
    let checkedLansScapes = this.systemlandscape.filter(m => m.isChcked == true).map(m => m.sysLandscapeId).join(',')
    const impactedlocationString = this.selectedlocationNames.map((item: any) => item.item_text).join(',');
    const impacteddepartmentString = this.selecteddepartmentNames.map((item: any) => item.itemdepartment_text).join(',');

    const requestBody = {
      "type": "U",
      "itcrid": this.itcrid,
      "supportId": 1,
      "classificationId": Number(this.classificationId),
      "categoryId": Number(this.selectedCategory),
      "crowner": this.updatevalue[0].crowner,
      "referenceId": this.updatevalue[0].referenceId,
      "referenceTyp": this.updatevalue[0].referenceTyp,
      "crdate": this.updatevalue[0].crdate,
      "crinitiatedFor": crinitiate,
      "status": status,
      "categoryTypeId": Number(this.SubCategory),
      "crrequestedBy": changerequested,
      "crrEmailNotification": this.EmailNotification,
      "crrequestedDt": this.updatevalue[0].crrequestedDt,
      "natureOfChange": Number(this.NatureOfChange),
      "priorityType": this.updatevalue[0].priorityType,
      "plantId": this.updatevalue[0].plantId,
      "gxpclassification": this.CheckGxPClassification,
      "gxpplantId": this.updatevalue[0].gxpplantId,
      "changeControlNo": this.updatevalue[0].changeControlNo,
      "changeControlDt": this.updatevalue[0].changeControlDt,
      "changeControlAttach": true,
      "changeDesc": this.updatevalue[0].changeDesc,
      "reasonForChange": this.updatevalue[0].reasonForChange,
      "alternateConsidetation": this.updatevalue[0].alternateConsidetation,
      "impactNotDoing": this.updatevalue[0].impactNotDoing,
      "triggeredBy": this.updatevalue[0].triggeredBy,
      "benefits": this.updatevalue[0].benefits,
      "estimatedCost": this.updatevalue[0].estimatedCost,
      "estimatedCostCurr": this.updatevalue[0].estimatedCostCurr,
      "estimatedEffort": this.updatevalue[0].estimatedEffort,
      "estimatedEffortUnit": this.updatevalue[0].estimatedEffortUnit,
      "estimatedDateCompletion": this.updatevalue[0].estimatedDateCompletion,
      "rollbackPlan": this.updatevalue[0].rollbackPlan,
      "backoutPlan": this.updatevalue[0].backoutPlan,
      "businessImpact": this.updatevalue[0].businessImpact,
      "downTimeRequired": this.CheckDowntimeReq,
      "downTimeFromDate": this.updatevalue[0].downTimeFromDate,
      "downTimeToDate": this.updatevalue[0].downTimeToDate,
      "impactedLocation": impactedlocationString,
      "impactedDept": impacteddepartmentString,
      "imactedFunc": this.updatevalue[0].imactedFunc,
      "isSubmitted": true,
      "isApproved": false,
      "isImplemented": false,
      "isReleased": false,
      "createdBy": this.supportid,
      "SysLandscapeID": checkedLansScapes,
      "attachment": this.attachfile
    }

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(apiUrl, requestBody, httpOptions).subscribe(
      (response: any) => {
        if (status == "Submitted") {
          if (response.type == "E") {
            alert(response.message);
            return;
          }
          else {
            alert("RFC Code" + " " + this.updatevalue[0].crcode + " " + ": is Successfully Submitted for approval");
            this.emailapproversinfo();
            this.router.navigate(['/change-request']);
          }
        }
        else if (status == "Draft") {
          if (response.type == "E") {
            alert(response.message);
            return;
          }
          else {
            alert("Saved Successfully as Draft!",);
            this.router.navigate(['/change-request']);
          }
        }
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );

  }
  selectedFile: any = '';
  getattach(event: any): void {
    this.selectedFiles = event.target.files[0];
  }
  // addFile(): void {
  //   if (!this.selectedFile) {
  //     console.error('No file selected.');
  //     return;
  //   }

  //   if (!this.crid.itcrid) {s
  //     console.error('ITCRID is required.');
  //     return;
  //   }

  //   const itcrid = this.crid.itcrid.toString();
  //   const formData = new FormData();

  //   formData.append('itcrid', itcrid);
  //   formData.append('file', this.selectedFile, this.selectedFile.name);

  //   const apiUrl = this.apiurl + '/ChangeRequest';

  //   this.http.post(apiUrl, formData).subscribe(
  //     (response: any) => {
  //     },
  //     (error: any) => {
  //       console.error('POST request failed', error);
  //     }
  //   );
  // }

  deleteDoc(Doc: any) {
    console.log(Doc)
    let url = '/ChangeRequest/Delete/' + Doc.attachId
    this.httpSer.httpDelete(url).subscribe(res => {
      this.attachmentsList = this.attachmentsList.filter((m: any) => Doc.attachId != m.attachId)
    })
  }
  addFile(): void {
    console.log(this.selectedFiles)
    if (!this.selectedFiles) {
      console.error('No files selected.');
      return;
    }

    if (this.selectedFile.size > this.MAX_FILE_SIZE) {
      alert('File size must not exceed 5 MB.')
      return
    }

    const formData = new FormData();
    formData.append('Itcrid', this.itcrid);
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
          fileName: this.selectedFiles?.name,
          file: this.selectedFiles
        })
        this.attach = ''
        this.getFileData();
      },
      (error: any) => {
        console.error('Error uploading files', error);
      }
    );
  }

  getFileData() {
    let url = '/ChangeRequest/GetFileData'

    let param = {
      itcrid: this.itcrid
    }
    this.httpSer.httpGet(url, param).subscribe(res => {
      this.attachmentsList = res
       this.attachmentsList = this.attachmentsList.filter((m: any) => m.stage === 'CR')
    })
  }


  downFile(fileName: any): void {
    
    const apiUrl = `${this.apiurl}/ChangeRequest/Download/${fileName.attachId}`
    this.http.get(apiUrl, { responseType: 'blob' }).subscribe(
      (response: Blob) => {
        
        const url = window.URL.createObjectURL(response);
        const link = document.createElement('a');
        link.href = url;
        link.download = fileName.fileName;
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




  approver11: any = ''
  approver21: any = ''
  approver31: any = ''
  approver12: any = ''
  approver22: any = ''
  approver32: any = ''
  approver13: any = ''
  approver23: any = ''
  approver33: any = ''

  approver11Name: any = ''
  approver21Name: any = ''
  approver31Name: any = ''
  approver12Name: any = ''
  approver22Name: any = ''
  approver32Name: any = ''
  approver13Name: any = ''
  approver23Name: any = ''
  approver33Name: any = ''
  approver1: any = ''
  approver2: any = ''
  approver3: any = ''
  approver1Names: any = ''
  approver2Names: any = ''
  approver3Names: any = ''
  plantid: any = ''
  appv: any[] = []
  apprv11email: any = ''
  apprv21email: any = ''
  apprv31email: any = ''
  apprv12email: any = ''
  apprv22email: any = ''
  apprv32email: any = ''
  apprv13email: any = ''
  apprv23email: any = ''
  apprv33email: any = ''
  approver1Emails: any = ''
  approver2Emails: any = ''
  approver3Emails: any = ''

  emailapproversinfo() {
    const apiUrl = this.apiurl + '/GetApproverforEmail/GetApproverEmail';
    this.categoryId = Number(this.selectedCategory)
    const requestBody = {
      "stage": "N",
      "plantid": Number(this.plantid),
      "categoryId": Number(this.categoryId),
      "classificationId": Number(this.classificationId)
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(apiUrl, requestBody, httpOptions).subscribe(
      (response: any) => {
        this.appv = response
      });
    setTimeout(() => {
      this.sendemailfrom('Requestor', this.appv);
      this.sendemailfrom('Approver', this.appv);
    }, 1000);
  }

  appr: any[] = []
  appemail: any = ''
  to1: any = '';
  to2: any = '';
  to3: any = '';
  cc1: any = '';
  cc2: any = '';
  cc3: any = '';
  subjecttxt: any = '';
  populatedOutput: any = '';

  sendemailfrom(emailreq: string, appv: any[]) {
    const apiUrl = this.apiurl + '/Email'
    this.approver11 = appv[0]?.approver1;
    this.approver11Name = appv[0]?.approver1Name;
    this.apprv11email = appv[0]?.approver1Email;
    if (appv[0]?.empid1 != '' && appv[0]?.empid1 != undefined) {
      this.approver1Names = this.approver11Name + '(' + appv[0]?.empid1 + ')'
      //this.approver1Emails = ', ' +this.apprv11email
      this.approver1Emails = this.apprv11email
    }
    else { this.approver11Name = '' }

    this.approver21 = appv[0]?.approver2
    this.approver21Name = appv[0]?.approver2Name;
    this.apprv21email = appv[0]?.approver2Email;

    if (appv[0]?.empid2 != '' && appv[0]?.empid2 != undefined) {
      this.approver1Names += ", <br> "
      this.approver1Names += this.approver21Name + '(' + appv[0]?.empid2 + ')'
      this.approver1Emails += ", " + this.apprv21email
    }
    else { this.approver21Name = '' }

    this.approver31 = appv[0]?.approver3;
    this.approver31Name = appv[0]?.approver3Name;
    this.apprv31email = appv[0]?.approver3Email;

    if (appv[0]?.empid3 != '' && appv[0]?.empid3 != undefined) {
      this.approver1Names += ', <br>' + this.approver31Name + '(' + appv[0]?.empid3 + ')'
      this.approver1Emails += ', ' + this.apprv31email
    }
    else { this.approver31Name = '' }

    //second Level
    this.approver12 = appv[1]?.approver1;
    this.approver12Name = appv[1]?.approver1Name;
    this.apprv12email = appv[1]?.approver1Email;
    if (appv[1]?.empid1 != '' && appv[1]?.empid1 != undefined) {
      this.approver2Names = this.approver12Name + '(' + appv[1]?.empid1 + ')'
      this.approver2Emails += ', ' + this.apprv12email
    }
    this.approver22 = appv[1]?.approver2;
    this.approver22Name = appv[1]?.approver2Name;
    this.apprv22email = appv[1]?.approver2Email;
    if (appv[1]?.empid2 != '' && appv[1]?.empid2 != undefined) {
      this.approver2Names += ', <br>' + this.approver22Name + '(' + appv[1]?.empid2 + ')'
      this.approver2Emails += ', ' + this.apprv22email
    }
    this.approver32 = appv[1]?.approver3;
    this.approver32Name = appv[1]?.approver3Name;
    this.apprv32email = appv[1]?.approver3Email;
    if (appv[1]?.empid3 != '' && appv[1]?.empid3 != undefined) {
      this.approver2Names += ', <br>' + this.approver32Name + '(' + appv[1]?.empid3 + ')'
      this.approver2Emails += ', ' + this.apprv32email
    }
    else { this.approver32Name = '' }

    //Third Level
    this.approver13 = appv[2]?.approver1;
    this.approver13Name = appv[2]?.approver1Name;
    this.apprv13email = appv[2]?.approver1Email;
    if (appv[2]?.empid1 != '' && appv[2]?.empid1 != undefined) {
      this.approver3Names = this.approver13Name + '(' + appv[2]?.empid1 + ')'
      this.approver3Emails += ', ' + this.apprv13email
    } else { this.approver13Name = '' }

    this.approver23 = appv[2]?.approver2;
    this.approver23Name = appv[2]?.approver2Name;
    this.apprv23email = appv[2]?.approver2Email;
    if (appv[2]?.empid2 != '' && appv[2]?.empid2 != undefined) {
      this.approver3Names += ', <br>' + this.approver23Name + '(' + appv[2]?.empid2 + ')'
      this.approver3Emails += ', ' + this.apprv23email
    } else { this.approver23Name = '' }
    this.approver33 = appv[2]?.approver3;
    this.approver33Name = appv[2]?.approver3Name;
    this.apprv33email = appv[2]?.approver3Email;
    if (appv[2]?.empid3 != '' && appv[2]?.empid3 != undefined) {
      this.approver3Names += ', <br>' + this.approver33Name + '(' + appv[2]?.empid3 + ')'
      this.approver3Emails += ', ' + this.apprv33email
    } else { this.approver33Name = '' }

    setTimeout(() => {
      if (emailreq == 'Requestor') {
        this.to1 = this.crremail
        this.cc1 = this.croemail
        const requestdate = this.crdateval
        const changeDesc = this.crdesc
        this.subjecttxt = `Unnati:IT Change Request:${this.updatevalue[0].crcode} : Submitted for Approval`
        const output = this.readHtmlFile('assets/email.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{this.Cremailvalue[0].crdate}}', requestdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', changeDesc)
          .replace('{{phase}}', 'RFC Submission')
          .replace('{{status}}', 'Pending Approval')
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.approver2Names)
          .replace('{{crapprover3}}', this.approver3Names)
          .replace('@Approval1Status', 'Pending')
          .replace('@Approval2Status', 'Queued')
          .replace('@Approval3Status', 'Queued')
          .replace('{{BodyContent}}', 'Thank you for submitting the Change Request. Below are the details of the Change Request.')
      }
      else {
        this.to1 = this.approver1Emails
        this.cc1 = this.crremail
        this.cc2 = this.croemail
        this.cc3 = this.approver2Emails
        const requestdate = this.crdateval
        const changeDesc = this.crdesc
        this.subjecttxt = `Unnati:IT Change Request:${this.updatevalue[0].crcode} : Pending for Approval`
        const output = this.readHtmlFile('assets/email.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.approver1Names)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{this.Cremailvalue[0].crdate}}', requestdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', changeDesc)
          .replace('{{phase}}', 'RFC Submission')
          .replace('{{status}}', 'Pending Approval')
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.approver2Names)
          .replace('{{crapprover3}}', this.approver3Names)
          .replace('${status}', 'RFC Submitted')
          .replace('@Approval1Status', 'Pending')
          .replace('@Approval2Status', 'Queued')
          .replace('@Approval3Status', 'Queued')
          .replace('{{BodyContent}}', 'Please find the details of the Change Request Submitted by ' + this.supportpersonname + ' and waiting for your Approval.')
          .replace('${loginUrl}', environment.loginurl)
          .replace('${loginUrl}', environment.loginurl)
      }

      if (this.to2 != '' && this.to3 != '') {
        var To = ',' + this.to2 + ',' + this.to3;
      } else if (this.to2 != '' && this.to3 == '') {
        var To = ',' + this.to2;
      }
      else {
        var To = '';
      }
      //cc
      if (this.cc2 != '' && this.cc3 != '') {
        var cc = ',' + this.cc2 + ',' + this.cc3;
      } else if (this.cc2 != '' && this.cc3 == '') {
        var cc = ',' + this.cc2;
      }
      else {
        var cc = '';
      }

      var cc1pluscc = this.cc1 + cc;
      var cc1pluscc1 = cc1pluscc.replace(',,', ',');

      // if (this.approver1Emails == "" || this.approver1Emails == null) {
      //   this.approver1Emails = '';
      // }

      if (this.to1 == "" || this.to1 == null) {
        this.to1 = '';
      }

      if (cc1pluscc1 == "" || cc1pluscc1 == null) {
        To = '';
      }

      const requestBody = {
        "to": (this.to1).replace(/^,+|,+$/g, '').trim().replace(/\s+/g, ' '),
        "cc": (cc1pluscc1).replace(/^,+|,+$/g, '').trim().replace(/\s+/g, ' '),
        "subject": this.subjecttxt,
        "body": this.populatedOutput
      }

      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };
      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
        },
        (error: any) => {
          throw error
        });
    }, 500)
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
  inatiatorid: any;
  setinitator() {
    this.crinitiatedFor = this.supportid + '-' + this.supportpersonname
  }

  systemlandscape: any[] = [];
  checkboxValues: any[] = ['Development', 'Quality', 'Validation', 'Production', 'Live'];
  dropdownItems: string[] = [];
  dropdownItemscr: any[] = [];
  selectedValue: string = '';
  supportteamname: string[] = [];
  supportnames: any;
  crownername: any;
  croemail: any = '';

  async fetchAllItems() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.crownername = this.supportteam.filter(item => item.empId == this.updatevalue[0].crowner)
        this.supportnames = this.crownername[0].firstName + " " + this.crownername[0].middleName + " " + this.crownername[0].lastName;
        this.firstname = this.crownername[0].firstName;
        this.middlename = this.crownername[0].middleName;
        this.lastname = this.crownername[0].lastName;
        this.croemail = this.crownername[0].email;
        this.supportteamname = this.supportnames;
        if (this.firstname !== null && this.firstname !== undefined) {
          this.supportpersonname += this.firstname;
        }

        if (this.middlename !== null && this.middlename !== undefined) {
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
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  dropdownsupportteamid: any;
  filterItems() {
    const filter = this.setiniatorname.toUpperCase().trim();
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

  iniatorsid: any[] = [];
  setiniatorname: any;
  criemail: any = '';
  criequestedBy: any = '';

  async iniatorid() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.iniatorsid = this.supportteam.filter((item: any) => item.empId === this.updatevalue[0].crinitiatedFor);
        this.setiniatorname = this.iniatorsid[0].empId + "-" + this.iniatorsid[0].firstName + " " + this.iniatorsid[0].lastName
        this.criemail = this.iniatorsid[0].email;
        this.criequestedBy = this.iniatorsid[0].firstName + " " + this.iniatorsid[0].middleName + " " + this.iniatorsid[0].lastName
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  selectItem(item: string) {
    this.selectedValue = item;
    this.setiniatorname = item.trim();
    this.dropdownItems = [];
  }

  crrequestedby: any[] = [];
  setcreniatorname: any;
  crremail: any = '';
  crrequestedBy: any = '';

  async crrequestors(): Promise<void> {
    try {
      this.isLoading = true;
      await this.employeeInfo.empList();
      this.crrequestedby = this.allEmpList.filter((item: any) => item.employeeId == this.Value.crrequestedBy);
      this.setcreniatorname = (this.crrequestedby[0].employeeId + "-" + this.crrequestedby[0].employeeName).trim();
      if (this.EmailNotification == true) {
        var sendCrEmail: any = this.crrequestedby[0].email;
      } else {
        var sendCrEmail: any = "";
      }
      this.crremail = sendCrEmail;
      this.crrequestedBy = this.crrequestedby[0].employeeName;
      this.RequestorPlant = this.crrequestedby[0].plantcode;
      this.isLoading = false;
    } catch (error) {
      console.error('Error fetching employee list:', error);
      this.isLoading = false;
    }
  }

  filterItemscr() {
    const filter = this.setcreniatorname.toUpperCase().trim();
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
    this.setcreniatorname = (item.employeeId + '-' + item.employeeName).trim();
    this.RequestorPlant = item.plantcode;
    this.dropdownItemscr = [];
  }

  ClearPlant() {
    this.RequestorPlant = '';
  }

  supportteams: any[] = [];
  getsupportid: any;
  supportpersonname = '';
  firstname: any;
  middlename: any;
  lastname: any;

  async getsupportteams() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.supportteams = this.supportteam.filter((row: any) => row.empId === parseInt(this.supportid.trim()));
        this.getsupportid = this.supportteams[0].supportTeamId
        this.getsupportteamassign();
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  supportteamassign: any[] = [];
  ischangeanalyst: any;
  isapprover: any;
  issupportegineer: any;
  assignedplant: any;
  mapplant: any;
  mapcategory: any;
  assignedcat: any;

  async getsupportteamassign() {
    const apiUrls = this.apiurl + '/SupportteamAssigned'
    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.supportteamassign = response.filter((row: any) => row.supportTeamId === parseInt(this.getsupportid));
        this.mapplant = this.supportteamassign.map((item: any) => item.plantId);
        this.assignedplant = Array.from(new Set(this.mapplant));
        this.mapcategory = this.supportteamassign.map((item: any) => item.categoryId);
        this.assignedcat = Array.from(new Set(this.mapcategory));
        this.isapprover = this.supportteamassign[0].isApprover;
        this.issupportegineer = this.supportteamassign[0].isSupportEngineer;
        this.ischangeanalyst = this.supportteamassign[0].isChangeAnalyst;
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
        this.checklist = response.filter((item: any) => item.plantId === this.updatevalue[0].plantId && item.supportId === 1 && item.classificationId === Number(this.classificationId) && item.categoryId === Number(this.selectedCategory));
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  approverN: any = '';
  approverR: any = '';
  approverC: any = '';
  approver: any[] = [];

  chkapproverexists() {
    const apiUrl = this.apiurl + '/SupportTeam/supportteam';
    this.http.get<any[]>(apiUrl).subscribe(
      (response: any[]) => {
        this.approver = response.filter((item: any) => Number(item.plantId) === Number(this.plantvalue) && item.categoryId === Number(this.selectedCategory) && item.classificationId === Number(this.classificationId));
        this.approverN = this.approver.filter((item: any) => item.approverstage === 'N' && item.level === 1)
        this.approverR = this.approver.filter((item: any) => item.approverstage === 'R' && item.level === 1)
        this.approverC = this.approver.filter((item: any) => item.approverstage === 'C' && item.level === 1)
        if ((this.approverN.length === 0) || (this.approverR.length === 0) || (this.approverC.length === 0)) {
          this.showSavebtn(0);
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

  categoryfunctions() {
    this.SubCategory = '';
    this.SelectNatureOfChange = '';
    this.categorytype = [];
    this.Natureofchange = [];
    this.systemlandscape = [];
    this.approver = [];
    this.vflag = true;
    this.showSavebtn(1);
    this.getcategorytype();
    this.chkapproverexists();
    this.getsystemlandscape();
  }

}
