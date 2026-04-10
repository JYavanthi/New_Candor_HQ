import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../passcrdata.service';
import { GetEmployeeInfoService } from '../../../services/get-employee-info.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-cr-task',
  templateUrl: './cr-task.component.html',
  styleUrl: './cr-task.component.css'
})
export class CrTaskComponent {
  todaysDate = new Date().toISOString().slice(0, 10);
  crid: any;
  sysid: any;
  filtersys: any;
  supportid: any;
  supportname: any;
  allEmpList: any[] = [];
  supportteam: any[] = [];
  employeeid: any[] = [];
  filteredexehist: any[] = [];
  assignedtousername: string = '';
  emailitcrexecId: string = '';
  updatevalue: any[] = [];
  depdenttask: any[] = [];
  assignedtoid!: number;

  constructor(private http: HttpClient, private datepipe: DatePipe, private employeeInfo: GetEmployeeInfoService, private router: Router, private route: ActivatedRoute, private routeservice: PasscrdataService) {
    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });


    this.getcrdata();

    this.employeeInfo.suppTeamList().then(() => {
      this.supportteam = this.employeeInfo.SupportTeamList;
      this.employeeid = this.supportteam;
    });

    // this.routeservice.crdata.subscribe(data => {
    //   this.crid = data.report;
    // })
    this.route.queryParams.subscribe(params => {
      this.itcrid = params['id'];
      this.sysid = params['sysid'];
    });

    /*this.routeservice.sysdata.subscribe(data => {
      this.sysid = data.report;
      this.filtersys = parseInt(this.sysid.value);
    })*/

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;
    this.getsupportteams();
  }

  itcrid: any = '';

  getidupdate() {
    // this.itcrid = this.route.snapshot.paramMap.get('id');
  }

  private apiurl = environment.apiurls

  ngOnInit(): void {
    this.fetchAllItems();
    this.Systemtask();
    this.filterassignedItems();
    this.forwardStatus = this.forwardedto == "" ? "Not Forwarded" : "Forwarded";
  }

  forwardedToChange() {
    this.forwardStatus = this.forwardedto.length == 0 ? "Not Forwarded" : this.forwardStatus;
  }

  pickedStatusChange() {
    this.pickedDt = this.pickedStatus == "Not Picked" ? this.pickedDt = '' : this.pickedDt;
  }

  itcrExecID: any = '';
  sysLandscape: any = '';
  executionStepName: any = '';
  executionStepDesc: any = '';
  assignedTo: any = '';
  startDt: any = '';
  endDT: any = '';
  attachments: any = '';
  statusece: any = '';
  forwardStatus: any = '';
  forwardedDt: any = '';
  reasonForwarded: any = '';
  remarks: any = '';
  pickedStatus: any = '';
  pickedDt: any = '';
  actualStartDt: any = '';
  actualEndDt: any = '';
  dependSysLandscape: any = '';
  dependTaskId: any = '';
  status: any = '';
  forwardonValue = this.forwardedDt ? this.forwardedDt : null;
  startDtValue = this.startDt ? this.startDt : null;
  endDTValue = this.endDT ? this.endDT : null;
  actualStartDtValue = this.actualStartDt ? this.actualStartDt : null;
  actualEndDtValue = this.actualEndDt ? this.actualEndDt : null;


  errorMessage: any = '';
  successMessage: any = '';

  clearErrorMessage() {
    this.errorMessage = '';
  }
  clearSuccessMessage() {
    this.successMessage = '';
  }

  emailCR: any[] = [];
  crdesc: any = '';
  crdateval: any = '';
  crrempid: any = '';
  croempid: any = '';

  async getcrdata() {
    const apiUrls = this.apiurl + '/ChangeRequest/Getrequest'
    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.emailCR = response.filter((item: any) => item.itcrid === Number(this.itcrid));
        this.crid = this.emailCR[0]
        this.crdesc = this.emailCR[0].changeDesc;
        this.crdateval = this.emailCR[0].crdate;
        this.crrempid = this.emailCR[0].crrequestedBy;
        this.croempid = this.emailCR[0].crowner;
        
        this.getsystemlandscape();
        this.EmpDtls();
        this.crdtls(this.croempid);
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }


  submitExexute() {
    if (this.statusece === 'Assigned') {
      if (!this.startDtValue) {
        alert('Select Planned Start Date');
      }
      else if (!this.endDTValue) {
        alert('Select Planned End Date');
      }
      else if (this.assignedTo === '') {
        alert('Enter Employee Name');
      }
      else if (this.pickedStatus.trim() == 'Picked') {
        if (!this.startDtValue) {
          alert('Select Planned Start Date');
        }
        else if (!this.endDTValue) {
          alert('Select Planned End Date');
        }
        else if (this.statusece === '') {
          alert('Select Status');
        }
        else if (this.assignedTo == '') {
          alert('Enter Employee Name');
        }
        else if (!this.pickedDt) {
          alert('Select Picked Date');
        }
        else if (!this.actualStartDtValue) {
          alert('Select Actual Start Date');
        }
        else if (!this.actualEndDtValue) {
          alert('Select Actual End Date');
        }
        else if (this.executionStepName == '') {
          alert('Enter Execution Step Name');
        }
        else if (this.executionStepDesc == '') {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
      }
      else if (this.pickedStatus.trim() == 'Not Picked') {
        if (!this.startDtValue) {
          alert('Select Planned Start Date');
        }
        else if (!this.endDTValue) {
          alert('Select Planned End Date');
        }
        else if (this.statusece === '') {
          alert('Select Status');
        }
        else if (this.assignedTo == '') {
          alert('Enter Employee Name');
        }
        else if (!this.actualStartDtValue) {
          alert('Select Actual Start Date');
        }
        else if (!this.actualEndDtValue) {
          alert('Select Actual End Date');
        }
        else if (this.executionStepName == '') {
          alert('Enter Execution Step Name');
        }
        else if (this.executionStepDesc == '') {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
      }
      else if (this.executionStepName == '') {
        alert('Enter Execution Step Name');
      }
      else if (this.executionStepDesc == '') {
        alert('Enter Execution Step Desc');
      }
      else {
        this.ExecuteFunc()
      }
    }


    else if (this.statusece == 'Onhold') {
      if (this.pickedStatus.trim() == 'Picked') {
        if (!this.startDtValue) {
          alert('Select Planned Start Date');
        }
        else if (!this.endDTValue) {
          alert('Select Planned End Date');
        }
        else if (this.statusece === '') {
          alert('Select Status');
        }
        else if (this.assignedTo == '') {
          alert('Enter Employee Name');
        }
        else if (!this.pickedDt) {
          alert('Select Picked Date');
        }
        else if (!this.actualStartDtValue) {
          alert('Select Actual Start Date');
        }
        else if (!this.actualEndDtValue) {
          alert('Select Actual End Date');
        }
        else if (this.executionStepName == '') {
          alert('Enter Execution Step Name');
        }
        else if (this.executionStepDesc == '') {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
      }
      else if (this.pickedStatus.trim() == 'Not Picked') {
        if (!this.startDtValue) {
          alert('Select Planned Start Date');
        }
        else if (!this.endDTValue) {
          alert('Select Planned End Date');
        }
        else if (this.statusece === '') {
          alert('Select Status');
        }
        else if (this.assignedTo == '') {
          alert('Enter Employee Name');
        }
        else if (!this.actualStartDtValue) {
          alert('Select Actual Start Date');
        }
        else if (!this.actualEndDtValue) {
          alert('Select Actual End Date');
        }
        else if (this.executionStepName == '') {
          alert('Enter Execution Step Name');
        }
        else if (this.executionStepDesc == '') {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
      }
      else if (this.executionStepName == '') {
        alert('Enter Execution Step Name');
      }
      else if (this.executionStepDesc == '') {
        alert('Enter Execution Step Desc');
      }
      else {
        this.ExecuteFunc()
      }
    }


    else if (this.statusece == 'Completed') {
      if (this.pickedStatus.trim() == 'Not Picked') {
        alert('Please pick task to change to complete!');
      } else {
        if (!this.startDtValue) {
          alert('Select Planned Start Date');
        }
        else if (!this.endDTValue) {
          alert('Select Planned End Date');
        }
        else if (this.assignedTo == '') {
          alert('Enter Employee Name');
        }
        else if (this.pickedStatus == '') {
          alert('Select Picked Status');
        }
        else if (this.pickedStatus.trim() == 'Picked' && !this.pickedDt || this.pickedStatus.trim() == 'Picked' && this.pickedDt == '') {
          alert('Select Picked Date');
        }
        else if (this.actualStartDtValue == '' || this.actualStartDtValue == undefined) {
          alert('Select Actual Start Date');
        }
        else if (this.actualEndDtValue == '' || this.actualEndDtValue == undefined) {
          alert('Select Actual End Date');
        }
        else if (this.executionStepName == '') {
          alert('Enter Execution Step Name');
        }
        else if (this.executionStepDesc == '') {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
      }
    }


    else if (this.statusece == 'Unassigned') {
      if (this.pickedStatus.trim() == 'Picked') {
        if (!this.startDtValue) {
          alert('Select Planned Start Date');
        }
        else if (!this.endDTValue) {
          alert('Select Planned End Date');
        }
        else if (this.statusece === '') {
          alert('Select Status');
        }
        else if (this.assignedTo == '') {
          alert('Enter Employee Name');
        }
        else if (!this.pickedDt) {
          alert('Select Picked Date');
        }
        else if (!this.actualStartDtValue) {
          alert('Select Actual Start Date');
        }
        else if (!this.actualEndDtValue) {
          alert('Select Actual End Date');
        }
        else if (this.executionStepName == '') {
          alert('Enter Execution Step Name');
        }
        else if (this.executionStepDesc == '') {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
      }
      else if (this.pickedStatus.trim() == 'Not Picked') {
        if (!this.startDtValue) {
          alert('Select Planned Start Date');
        }
        else if (!this.endDTValue) {
          alert('Select Planned End Date');
        }
        else if (this.statusece === '') {
          alert('Select Status');
        }
        else if (this.assignedTo == '' && this.statusece!== 'Unassigned') {
          alert('Enter Employee Name');
        }
        else if (!this.actualStartDtValue) {
          alert('Select Actual Start Date');
        }
        else if (!this.actualEndDtValue) {
          alert('Select Actual End Date');
        }
        else if (this.executionStepName == '') {
          alert('Enter Execution Step Name');
        }
        else if (this.executionStepDesc == '') {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
      }
      else if (this.executionStepName == '') {
        alert('Enter Execution Step Name');
      }
      else if (this.pickedStatus.trim() == 'Picked') {
        if (!this.pickedDt) {
          alert('Enter Picked Date');
        }
        else if (!this.actualStartDtValue) {
          alert('Select Actual Start Date');
        }
      }
      else if (this.pickedStatus.trim() == 'Not Picked') {
        if (!this.actualStartDtValue) {
          alert('Select Actual Start Date');
        }
      }
      else if (this.executionStepDesc == '') {
        alert('Enter Execution Step Desc');
      }
      else {
        this.ExecuteFunc()
      }
    }

    else if (this.pickedStatus.trim() == 'Picked' && this.statusece != 'Completed') {
      if (!this.startDtValue) {
        alert('Select Planned Start Date');
      }
      else if (!this.endDTValue) {
        alert('Select Planned End Date');
      }
      else if (this.statusece === '') {
        alert('Select Status');
      }
      else if (this.assignedTo == '') {
        alert('Enter Assigned To');
      }
      else if (!this.pickedDt) {
        alert('Select Picked Date');
      }
      else if (!this.actualStartDtValue) {
        alert('Select Actual Start Date');
      }
      else if (this.executionStepName == '') {
        alert('Enter Execution Step Name');
      }
      else if (this.executionStepDesc == '') {
        alert('Enter Execution Step Desc');
      }
      else {
        this.ExecuteFunc()
      }
    }

    else if (this.pickedStatus.trim() == 'Not Picked' && this.statusece != 'Completed') {
      if (!this.startDtValue) {
        alert('Select Planned Start Date');
      }
      else if (!this.endDTValue) {
        alert('Select Planned End Date');
      }
      else if (this.statusece === '') {
        alert('Select Status');
      }
      else if (this.assignedTo == '') {
        alert('Enter Assigned To');
      }
      else if (!this.actualStartDtValue) {
        alert('Select Actual Start Date');
      }
      else if (this.executionStepName == '') {
        alert('Enter Execution Step Name');
      }
      else if (this.executionStepDesc == '') {
        alert('Enter Execution Step Desc');
      }
      else {
        this.ExecuteFunc()
      }
    }

    else if (this.statusece == '' && this.pickedStatus == '') {
      if (this.executionStepName == '') {
        alert('Enter Execution Step Name');
      }
      else if (this.executionStepDesc == '') {
        alert('Enter Execution Step Desc');
      }
      else {
        this.ExecuteFunc()
      }
    }
  }

  ExecuteFunc() {
    const apiUrl = this.apiurl + '/Crexecute/executeplan';
    const assignedtouser = this.assignedTo.split("-")[0];
    this.assignedtousername = this.assignedTo?.split("-")[1]?.trim();
    const forwardedtouser = this.forwardedto.split("-")[0];
    if (this.dependTaskId==='') this.dependSysLandscape='';
    
    const requestBody = {
      "flag": "I",
      "itcrid": this.crid?.itcrid,
      "sysLandscape": this.sysid,
      "executionStepName": this.executionStepName.trim(),
      "executionStepDesc": this.executionStepDesc.trim(),
      "assignedTo": assignedtouser ? assignedtouser : null,
      "startDt": this.startDtValue ? this.startDtValue : null,
      "endDT": this.endDTValue ? this.endDTValue : null,
      "attachments": this.attachments.trim(),
      "status": this.statusece.trim(),
      "forwardStatus": this.forwardStatus.trim(),
      "forwardedTo": forwardedtouser ? forwardedtouser : null,
      "forwardedDt": this.forwardonValue,
      "reasonForwarded": this.reasonForwarded.trim(),
      "remarks": this.remarks.trim(),
      "pickedStatus": this.pickedStatus.trim(),
      "pickedDt": this.pickedDt ? this.pickedDt : null,
      "actualStartDt": this.actualStartDtValue,
      "actualEndDt": this.actualEndDtValue,
      "dependSysLandscape": this.dependSysLandscape ? this.dependSysLandscape : null,
      "dependTaskId": this.dependTaskId ? this.dependTaskId : null,
      "createdBy": this.supportid,
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(apiUrl, requestBody, httpOptions).subscribe(
      (response: any) => {
        if (response.type == "E") {
          alert(response.message);
          return;
        }
        else {
          alert("RFC Code" + " " + this.crid.crcode + " " + ": Impelmentation Task ID is successsfully Saved")
          this.goToTab('contact');
          this.getexecutionhistory();
        }
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
  }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }

  lastItemfilteredexehist: any[] = [];
  async getexecutionhistory() {
    // const apiUrls = this.apiurl + '/ViewChangeHistory/GetCr'+
    // ?id+'='+this.crid.value.itcrid
    //const apiUrls = this.apiurl + '/ViewChangeHistory/GetCr'
    const apiUrls = this.apiurl + '/ViewChangeHistory/GetCrExecutionPlanHistory?id=' + this.crid.itcrid;
    try {
      const response: any = await this.http.get(apiUrls).toPromise();
      if (response) {
        const maxValue = response.reduce((max: any, item: any) => item.itcrexecId > max ? item.itcrexecId : max, response[0].itcrexecId);
        let filteredData = [];
        filteredData = response.filter((item: any) => item.itcrexecId == Number(maxValue));
        this.filteredexehist = filteredData.filter((item: any) => parseInt(item.createdBy) == parseInt(this.supportid));
        this.lastItemfilteredexehist = [this.filteredexehist[this.filteredexehist.length - 1]];
        this.emailitcrexecId = this.lastItemfilteredexehist[0].itcrexecId;
        this.getdepdenttask();
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  crrequestedby: any[] = [];
  crremail: any = '';
  croemail: any = '';
  crrequestedBy: any = '';
  crval: any[] = [];

  async EmpDtls() {
    try {
      await this.employeeInfo.empList();
      this.crrequestedby = this.allEmpList.filter((item: any) => parseInt(item.employeeId) === parseInt(this.emailCR[0].crrequestedBy));
      this.crremail = this.crrequestedby[0].email;
      this.crrequestedBy = this.crrequestedby[0].employeeName;
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  async crdtls(id: Number) {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.crval = this.supportteam.filter((item: any) => item.empId === id);
        this.croemail = this.crval[0].email;
      }
    }
    catch (error) {
      console.error('GET request failed', error);
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

  selectedStatus: string = '';
  responseStatus: string = '';

  sendemailfrom() {
    this.responseStatus = '';
    this.selectedStatus = '';

    const apiUrl = this.apiurl + '/Email';
    const emailcrdate: any = this.datepipe.transform(this.lastItemfilteredexehist?.[0]?.createdDt, 'dd-MMM-yyyy')
    let to = this.assignedemail
    let cc = this.crremail;
    let cc2 = this.croemail;
    const requestdate: any = this.datepipe.transform(this.crdateval, 'dd-MMM-yyyy')
    const changeDesc = this.crdesc;

    if (this.statusece == "Assigned" && this.pickedStatus != "Picked") {
      this.selectedStatus = 'Assigned';
      this.responseStatus = "assigned to your Queue under Implementation";
    }
    else if (this.statusece == "" && this.pickedStatus == "" || this.statusece == "" && this.pickedStatus != "Picked") {
      this.selectedStatus = 'Unassigned';
      this.responseStatus = "Unassigned";
    }
    else if (this.statusece == "Completed") {
      this.selectedStatus = 'Completed';
      this.responseStatus = "Completed";
    }
    else if (this.statusece != "Completed" && this.pickedStatus == "Picked") {
      this.selectedStatus = 'Picked';
      this.responseStatus = "Picked";
    }

    const output = this.readHtmlFile('assets/emailexecute.html');

    const populatedOutput = output
      .replace('${crid}', this.crid.crcode)
      .replace('${crid}', this.crid.crcode)
      .replace('${response.status}', this.responseStatus)
      .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
      .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
      .replace('{{this.Cremailvalue[0].crdate}}', requestdate)
      .replace('{{this.Cremailvalue[0].changeDesc}}', changeDesc)
      .replace('${response[0].taskId}', this.emailitcrexecId)
      .replace('${response[0].taskId}', this.emailitcrexecId)
      .replace('${response[0].estatus}', 'Implement')
      .replace('${response[0].estatus}', this.selectedStatus)
      .replace('${response[0].assignedToName}', this.assignedtousername)
      .replace('${response[0].assignedToName}', this.assignedtousername)
      .replace('${response[0].assignedDt}', emailcrdate)
      .replace('${response[0].taskDesc}', this.executionStepDesc)
      .replace('${loginUrl}', environment.loginurl)
      .replace('${loginUrl}', environment.loginurl)

    if (to == "" || to == null) {
      to = '';
    }
    if (cc == "" || cc == null) {
      cc = '';
    }
    if (cc2 == "" || cc2 == null) {
      cc2 = '';
    }

    const requestBody = {
      "to": to,
      "cc": cc, cc2,
      "subject": `For following RFC Code: ${this.crid.crcode}, the Task ID: ${this.emailitcrexecId} is ${this.responseStatus}`,
      "body": populatedOutput
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
        console.log('Post request failed', error);
      });
  }

  goToTab(tabId: string) {
    const itcrid = this.crid.itcrid;
    this.router.navigate([`/executive/${itcrid}/edit`], { fragment: tabId });
    setTimeout(() => {
      const tabButton = document.getElementById(tabId + '-tab');
      if (tabButton) {
        tabButton.click();
      }
    });
  }

  /*search filter*/
  forwardedto: any = '';
  dropdownItems: string[] = [];
  selectedValue: string = '';
  supportteamname: string[] = [];
  supportnames: string[] = [];

  async fetchAllItems() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.supportteamname = this.supportteam.map(item => item.empId + '-' + item.firstName + " " + item.lastName);
        this.supportteamname = this.supportteamname.filter((value, index, self) => self.indexOf(value) === index);
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  filterItems() {
    const filter = this.forwardedto.toUpperCase();
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
    this.forwardedto = item;
    this.dropdownItems = [];
    this.forwardStatus = this.selectedValue != 'No name found' ? "Forwarded" : this.forwardStatus;
  }

  /*Assigned to filter*/
  dropdownassignedItems: string[] = [];
  selectedassignedValue: string = '';

  filterassignedItems() {
    const filter = this.assignedTo.toUpperCase();

    this.dropdownassignedItems = this.supportteamname.filter(item =>
      item.toUpperCase().includes(filter)
    );

    if (this.dropdownassignedItems.length === 0 && filter !== '') {
      this.dropdownassignedItems.push('No name found');
    }
    else if (filter === '') {
      this.dropdownassignedItems.length = 0
    }
  }

  selectItemasignto(item: string) {
    this.selectedassignedValue = item;
    this.assignedTo = item;
    this.dropdownassignedItems = [];
  }
  /*task name*/
  taskname: any;
  Systemtask() {
    const apiUrl = this.apiurl + '/SystemLandscape/Allsystems';
    const requestBody = {
    }
    this.http.get(apiUrl, requestBody).subscribe(
      (response: any) => {
        this.taskname = response.filter((item: any) => item.sysLandscapeId === this.sysid);
      },
      (error: any) => {
        console.error('POST request failed', error);
      });
  }

  /*systemlandscape*/
  systemlandscape: any[] = [];
  async getsystemlandscape() {
    const apiUrl = this.apiurl + '/SystemLandscape/Getsystems';
    const requestBody = {
      "categroyId": this.emailCR[0].categoryId,
      "supportId": this.emailCR[0].supportId,
      "classificationId": this.emailCR[0].classificationId
    };
    try {
      const response: any = await this.http.post(apiUrl, requestBody).toPromise();

      if (response) {
        this.systemlandscape = response;
        if (this.emailCR[0]['sysLandscapeId'] != null) {
          let checkedVlues = this.emailCR[0]['sysLandscapeId'].split(',')
          this.systemlandscape.forEach(m => m['isChcked'] = (checkedVlues.indexOf(m.sysLandscapeId.toString()) != -1) ? true : false)
          this.systemlandscape = this.systemlandscape.filter((item) => item.isChcked == true);
        }
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }
  /*getsystemlandscape() {
    const apiUrl = this.apiurl + '/SystemLandscape/Getsystems';
    const requestBody = {
      "categroyId": this.crid.value.itcategoryId,
      "supportId": this.crid.value.supportId,
      "classificationId": this.crid.value.itclassificationId
    };
    this.http.post(apiUrl, requestBody).subscribe(
      (response: any) => {
        this.systemlandscape = response.filter((item: any) => item.sysLandscapeId <= this.filtersys);
        for (var i of this.systemlandscape) {
        }
      },
      (error: any) => {
        console.error('POST request failed', error);
      });
  }*/

  async getdepdenttask() {
    const apiUrl = this.apiurl + '/Crexecute/GetExecute';
    try {
      const response: any = await this.http.get(apiUrl).toPromise();
      if (response) {
        console.log('this.dependSysLandscape-',this.dependSysLandscape,this.itcrid)
        this.depdenttask = response.filter((item: any) => item.sysLandscapeid === Number(this.dependSysLandscape) && item.itcrid === Number(this.itcrid));
        console.log('dependent task : ', this.depdenttask);
        this.updatevalue = response.filter((item: any) => Number(item.itcrexecId) === Number(this.emailitcrexecId));
        this.assignedtoid = this.updatevalue?.[0]?.assignedtoid;
        this.getsupportdata(this.assignedtoid);
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  assgn: any[] = [];
  assignedname: any = '';
  assignedemail: any = '';

  async getsupportdata(id: Number) {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.assgn = this.supportteam.filter((item: any) => item.empId === id);
        this.assignedname = this.assgn[0].empId + "-" + this.assgn[0].firstName + " " + this.assgn[0].lastName;
        this.assignedemail = this.assgn[0].email;
        this.sendemailfrom();
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  /*login users*/
  supportteams: any[] = [];
  getsupportid: any;
  supportpersonname: any;
  firstname: any;
  middlename: any;
  lastname: any;

  async getsupportteams() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.supportteams = this.supportteam.filter((row: any) => row.empId === parseInt(this.supportid.trim()));
        this.getsupportid = this.supportteams[0].supportTeamId
        this.firstname = this.supportteams[0].firstName
        this.middlename = this.supportteams[0].middleName
        this.lastname = this.supportteams[0].lastName
        this.supportpersonname = this.firstname + this.middlename + this.lastname
        this.getsupportteamassign()
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  supportteamassign: any[] = [];
  issupportegineer: any;
  supportengineername: any;
  getsupportengineerid: any;

  getsupportteamassign() {
    const apiUrls = this.apiurl + '/SupportteamAssigned'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.supportteamassign = response.filter((row: any) => row.supportTeamId === this.getsupportid);
        this.issupportegineer = this.supportteamassign[0].isSupportEngineer
        this.supportengineername = response.filter((row: any) => row.isSupportEngineer === this.issupportegineer);
        this.getsupportengineerid = this.supportengineername.supportTeamId
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  changestatusece() {
    if (this.statusece?.trim() == "Unassigned") {
      this.assignedTo = '';
    }
    else if (this.pickedStatus) {
      if (this.pickedStatus == "Not Picked" && this.statusece?.trim() == "Completed") {
        this.statusece = '';
        alert('Please pick task to change to complete!');
      }
    }
  }

}
