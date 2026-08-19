import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-cr-addtask',
  templateUrl: './cr-addtask.component.html',
  styleUrl: './cr-addtask.component.css'
})
export class CrAddtaskComponent {
  allEmpList: any;
  supportteam: any;
  supportTeamNames: any;
  suppDropdown: any;
  suppDropdownAssign: any
  crrData: any;
  taskname: any;
  sysLansScapeId: any;
  depdentTasks: any;
  crId: any;
  sysid: any;
  user: any;
  taskID: any;
  depdendTaskList: any[] = [];
  NewUpdateTask: string = '';

  APIURLS = {
    ExecuteCRTask: '/Crexecute/executeplan',
    getExecutionHistoryAPI: '/ViewChangeHistory/GetCr',
    EmailAPI: '/Email',
    getCRExecute: '/Crexecute/GetExecute',
    UpdateCRHistoryAPI: '/ViewChangeHistory/GetCrExecutionPlanHistory?id=',
    GetCrExecutionPlanHistoryAPI: '/ViewChangeHistory/GetCrExecutionPlanHistory?id=',
  };

  constructor(public fb: FormBuilder, private datepipe: DatePipe, private userInfo: UserInfoSerService, private router: Router, public employeeInfo: GetEmployeeInfoService, private route: ActivatedRoute,
    public httpSer: HttpServiceService) {
    this.user = this.userInfo.getUser();
    this.getCRExecuteData();

    if (this.router.url.includes('cr-updateTask')) {
      this.route.queryParamMap.subscribe(params => {
        this.crId = params.get('impid');
        this.sysid = params.get('sysid');
        this.taskID = params.get('id');
        if (this.crId) {
          this.getCRData()
        }
      })

      this.getCRExecuteData().then(() => {
        this.getUpdateData();
      });
      this.NewUpdateTask = 'Update Task / Task ' + this.taskID
    }
    else {
      this.route.queryParamMap.subscribe(params => {
        this.crId = params.get('id');
        this.sysid = params.get('sysid');
        if (this.crId) {
          this.getCRData()
        }
      })
      this.NewUpdateTask = 'New Task';
    }

    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });

    this.employeeInfo.suppTeamList().then(() => {
      this.supportteam = this.employeeInfo.SupportTeamList;
    });

  }

  taskForm!: FormGroup
  ngOnInit() {
    this.fetchAllItems();
    this.SystemTask();
    this.formInIt();
    if (this.taskID == undefined) {
      const forwardStatusValue = !this.taskForm.value.forwardedTo ? "Not Forwarded" : "Forwarded";
      this.taskForm.patchValue({ forwardStatus: forwardStatusValue });
    }
  }

  formInIt() {
    this.taskForm = this.fb.group({
      plannedStartDate: [null, Validators.required],
      plannedEndDate: [null, Validators.required],
      status: ['', Validators.required],
      assignedTo: [''],
      forwardStatus: [''],
      forwardedTo: [''],
      forwardedDate: [null],
      reasonForForwarding: [''],
      pickedStatus: [''],
      pickedDate: [null],
      actualStartDate: [null],
      actualEndDate: [null],
      dependSysLandscape: [''],
      dependTask: [''],
      executionStepName: ['', Validators.required],
      executionStepDesc: ['', Validators.required],
      remarks: ['']
    });
  }

  filterSupportTeamAssign() {
    const filter = this.taskForm.value.assignedTo.toUpperCase();
    this.suppDropdownAssign = this.supportTeamNames.filter((item: any) =>
      item.toUpperCase().includes(filter)
    );
    if (this.suppDropdownAssign.length === 0 && filter !== '') {
      this.suppDropdownAssign.push('No name found');
    }
    else if (filter === '') {
      this.suppDropdownAssign.length = 0
    }
  }

  filterSupportTeam() {
    const filter = this.taskForm.value.forwardedTo.toUpperCase();
    this.suppDropdown = this.supportTeamNames.filter((item: any) =>
      item.toUpperCase().includes(filter)
    );
    if (this.suppDropdown.length === 0 && filter !== '') {
      this.suppDropdown.push('No name found');
    }
    else if (filter === '') {
      this.suppDropdown.length = 0
    }
  }

  async fetchAllItems() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.supportTeamNames = this.supportteam.map((item: any) => item.empId + '-' + item.firstName + " " + item.lastName);
        this.supportTeamNames = this.supportTeamNames.filter((value: any, index: any, self: any) => self.indexOf(value) === index);
      }
    }
    catch (error) {
    }
  }

  selectForwardTo(item: string) {
    this.taskForm.controls['forwardedTo'].setValue(item)
    this.suppDropdown = [];
    const forwardStatusValue = this.taskForm.value.forwardedTo != 'No name found' ? "Forwarded" : this.taskForm.value.forwardStatus;
    this.taskForm.patchValue({forwardStatus:forwardStatusValue});
  }

  selectAssignTo(item: string) {
    this.taskForm.controls['assignedTo'].setValue(item)
    this.suppDropdownAssign = [];
  }

  SystemTask() {
    const apiUrl = '/SystemLandscape/Allsystems';
    this.httpSer.httpGet(apiUrl).subscribe(
      (response: any) => {
        this.taskname = response.filter((item: any) => item.sysLandscapeId === this.sysid);
      },
      (error: any) => {
        console.error('POST request failed', error);
      });
  }

  systemlandscape: any[] = [];

  async getsystemlandscape() {
    const apiUrl = '/SystemLandscape/Getsystems';
    const requestBody = {
      "categroyId": this.crrData?.itcategoryId,
      "supportId": this.crrData?.supportId,
      "classificationId": this.crrData?.itclassificationId
    };

    try {
      const response: any = await this.httpSer.httpPost(apiUrl, requestBody).toPromise();

      if (response) {
        this.systemlandscape = response;
        if (this.crrData['sysLandscapeId'] != null) {
          let checkedVlues = this.crrData['sysLandscapeId'].split(',')
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

  assignedtoid!: number;
  getdependtask() {
    if (this.taskID == undefined) {
      this.depdendTaskList = this.getCRExecuteList.filter((item: any) => item.sysLandscapeid === parseInt(this.taskForm.value.dependSysLandscape) && item.itcrid === this.crrData.itcrid);
      const updatevalue: any[] = this.getCRExecuteList.filter((item: any) => Number(item.itcrexecId) === Number(this.emailitcrexecId));
      this.assignedtoid = updatevalue?.[0]?.assignedtoid;
      this.getsupportdata(this.assignedtoid);
    }
    else {
      if (this.taskForm.value.dependSysLandscape == '') {
        var filteredData: number = this.sysid;
      } else {
        var filteredData: number = this.taskForm.value.dependSysLandscape;
      }
      this.depdendTaskList = this.getCRExecuteList.filter((item: any) => item.sysLandscapeid == filteredData && item.itcrid == this.UpdateValueList[0].itcrid);
      this.depdendTaskList = this.depdendTaskList.filter((item: any) => item.itcrexecId != this.taskID);
    }
  }

  assignedemail: any = '';
  async getsupportdata(id: Number) {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        let assgn: any = [];
        assgn = this.supportteam.filter((item: any) => item.empId === id);
        this.assignedemail = assgn[0]?.email;
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  crremail: any = '';
  crrequestedBy: any = '';

  async EmpDtls() {
    try {
      await this.employeeInfo.empList();
      const crrequestedbyList: any[] = this.allEmpList.filter((item: any) => parseInt(item.employeeId) === parseInt(this.crrData.crrequestedBy));
      this.crremail = crrequestedbyList[0].email;
      this.crrequestedBy = crrequestedbyList[0].employeeName;
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  croemail: any = '';
  async crdtls(id: Number) {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        const crval: any[] = this.supportteam.filter((item: any) => item.empId === id);
        this.croemail = crval[0].email;
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  selectedStatus: string = '';
  responseStatus: string = '';

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

  sendemailfrom() {
    this.responseStatus = '';
    this.selectedStatus = '';

    const emailcrdate: any = this.datepipe.transform(this.lastItemfilteredexehist?.[0]?.createdDt, 'dd-MMM-yyyy')
    let to = this.assignedemail
    let cc = this.crremail;
    let cc2 = this.croemail;
    const requestdate: any = this.datepipe.transform(this.crrData.crdate, 'dd-MMM-yyyy')
    const changeDesc = this.crrData.changeDesc;

    if (this.taskForm.value.status == "Assigned" && this.taskForm.value.pickedStatus != "Picked") {
      this.selectedStatus = 'Assigned';
      this.responseStatus = "assigned to your Queue under Implementation";
    }
    else if (this.taskForm.value.status == "" && this.taskForm.value.pickedStatus == "" || this.taskForm.value.status == "" && this.taskForm.value.pickedStatus != "Picked") {
      this.selectedStatus = 'Unassigned';
      this.responseStatus = "Unassigned";
    }
    else if (this.taskForm.value.status == "Completed") {
      this.selectedStatus = 'Completed';
      this.responseStatus = "Completed";
    }
    else if (this.taskForm.value.status != "Completed" && this.taskForm.value.pickedStatus == "Picked") {
      this.selectedStatus = 'Picked';
      this.responseStatus = "Picked";
    }

    const output = this.readHtmlFile('assets/emailexecute.html');

    const populatedOutput = output
      .replace('${crid}', this.crrData.crcode)
      .replace('${crid}', this.crrData.crcode)
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
      .replace('${response[0].taskDesc}', this.taskForm.value.executionStepDesc)

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
      "subject": `For following RFC Code: ${this.crrData.crcode}, the Task ID: ${this.emailitcrexecId} is ${this.responseStatus}`,
      "body": populatedOutput
    }

    this.httpSer.httpPost(this.APIURLS.EmailAPI, requestBody).subscribe(
      (response: any) => {
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

  async getCRData() {
    const apiUrls = '/ViewChangeRequest/ViewChangerequest';
    try {
      const res: any = await this.httpSer.httpGet(apiUrls, { crId: this.crId }).toPromise();
      if (res) {
        const response = res as any;
        this.crrData = response.data[0];
        this.getsystemlandscape();
        this.EmpDtls();
        this.crdtls(this.crrData.crownerid);
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  getCRExecuteList: any[] = [];
  async getCRExecuteData() {
    try {
      const res: any = await this.httpSer.httpGet(this.APIURLS.getCRExecute).toPromise();
      if (res) {
        this.getCRExecuteList = res;
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  changeStatus() {
    if (this.taskForm.value.status == "Unassigned") {
      this.taskForm.patchValue({ assignedTo: '' })
    }
    else if (this.taskForm.value.pickedStatus) {
      if (this.taskForm.value.pickedStatus == "Not Picked" && this.taskForm.value.status?.trim() == "Completed") {
        this.taskForm.patchValue({ status: '' });
        alert('Please pick task to change to complete!');
      }
    }
  }

  forwardedToChange() {
    const forwardStatusValue = this.taskForm.value.forwardedTo.length == 0 ? "Not Forwarded" : this.taskForm.value.forwardStatus;
    this.taskForm.patchValue({ forwardStatus: forwardStatusValue });
  }

  pickedStatusChange() {
    const changePickedDateValue = this.taskForm.patchValue({ pickedDate: '' });
    const newPickedDatevalue = this.taskForm.value.pickedStatus == "Not Picked" ? changePickedDateValue : this.taskForm.value.pickedDate;
    this.taskForm.patchValue({ pickedDate: newPickedDatevalue });
  }

  SubmitTaskFunc() {
    if (this.router.url.includes('cr-updateTask')) {
      if (
        this.taskForm.value.status === 'Completed' &&
        this.taskForm.value.dependSysLandscape != null &&
        this.taskForm.value.dependSysLandscape !== '' &&
        this.taskForm.value.dependTask != null &&
        this.taskForm.value.dependTask !== ''
      ) {
        const getDepdendTaskList = this.depdendTaskList.filter((item: any) => item.itcrexecId == parseInt(this.taskForm.value.dependTask));
        if (getDepdendTaskList?.[0]?.status?.trim() != "Completed") {
          alert(`Please complete task ${getDepdendTaskList[0].executionStepName} to complete this task!`);
          this.taskForm.patchValue({ dependSysLandscape: "" })
          //this.UpdateValueList[0]['dependSysLandscapeid'] = '';
          this.taskForm.patchValue({ dependTask: '' });
        } else {
          this.submitTask();
        }
      }
      else {
        this.submitTask();
      }
    }

    else {
      this.submitTask();
    }
  }

  submitTask() {
    switch (this.taskForm.value.status) {
      case 'Assigned':
        if (!this.taskForm.value.plannedStartDate) {
          alert('Select Planned Start Date');
        }
        else if (!this.taskForm.value.plannedEndDate) {
          alert('Select Planned End Date');
        }
        else if (this.taskForm.value.assignedTo === '') {
          alert('Enter Employee Name');
        }
        else if (this.taskForm.value.pickedStatus?.trim() === 'Picked') {
          if (!this.taskForm.value.plannedStartDate) {
            alert('Select Planned Start Date');
          }
          else if (!this.taskForm.value.plannedEndDate) {
            alert('Select Planned End Date');
          }
          else if (this.taskForm.value.status === '') {
            alert('Select Status');
          }
          else if (this.taskForm.value.assignedTo === '') {
            alert('Enter Employee Name');
          }
          else if (!this.taskForm.value.pickedDate) {
            alert('Select Picked Date');
          }
          else if (!this.taskForm.value.actualStartDate) {
            alert('Select Actual Start Date');
          }
          else if (!this.taskForm.value.actualEndDate) {
            alert('Select Actual End Date');
          }
          else if (this.taskForm.value.executionStepName === '') {
            alert('Enter Execution Step Name');
          }
          else if (this.taskForm.value.executionStepDesc === '') {
            alert('Enter Execution Step Desc');
          }
          else {
            this.ExecuteFunc()
          }
        }
        else if (this.taskForm.value.pickedStatus?.trim() == 'Not Picked') {
          if (!this.taskForm.value.plannedStartDate) {
            alert('Select Planned Start Date');
          }
          else if (!this.taskForm.value.plannedEndDate) {
            alert('Select Planned End Date');
          }
          else if (this.taskForm.value.status === '') {
            alert('Select Status');
          }
          else if (this.taskForm.value.assignedTo === '') {
            alert('Enter Employee Name');
          }
          else if (!this.taskForm.value.actualStartDate) {
            alert('Select Actual Start Date');
          }
          else if (!this.taskForm.value.actualEndDate) {
            alert('Select Actual End Date');
          }
          else if (this.taskForm.value.executionStepName === '') {
            alert('Enter Execution Step Name');
          }
          else if (this.taskForm.value.executionStepDesc === '') {
            alert('Enter Execution Step Desc');
          }
          else {
            this.ExecuteFunc()
          }
        }
        else if (this.taskForm.value.executionStepName === '') {
          alert('Enter Execution Step Name');
        }
        else if (this.taskForm.value.executionStepDesc === '') {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
        break;

      case 'Onhold':
        if (this.taskForm.value.pickedStatus?.trim() === 'Picked') {
          if (!this.taskForm.value.plannedStartDate) {
            alert('Select Planned Start Date');
          }
          else if (!this.taskForm.value.plannedEndDate) {
            alert('Select Planned End Date');
          }
          else if (this.taskForm.value.status === '') {
            alert('Select Status');
          }
          else if (this.taskForm.value.assignedTo === '') {
            alert('Enter Employee Name');
          }
          else if (!this.taskForm.value.pickedDate) {
            alert('Select Picked Date');
          }
          else if (!this.taskForm.value.actualStartDate) {
            alert('Select Actual Start Date');
          }
          else if (!this.taskForm.value.actualEndDate) {
            alert('Select Actual End Date');
          }
          else if (this.taskForm.value.executionStepName === '') {
            alert('Enter Execution Step Name');
          }
          else if (this.taskForm.value.executionStepDesc === '') {
            alert('Enter Execution Step Desc');
          }
          else {
            this.ExecuteFunc()
          }
        }
        else if (this.taskForm.value.pickedStatus?.trim() == 'Not Picked') {
          if (!this.taskForm.value.plannedStartDate) {
            alert('Select Planned Start Date');
          }
          else if (!this.taskForm.value.plannedEndDate) {
            alert('Select Planned End Date');
          }
          else if (this.taskForm.value.status === '') {
            alert('Select Status');
          }
          else if (this.taskForm.value.assignedTo === '') {
            alert('Enter Employee Name');
          }
          else if (!this.taskForm.value.actualStartDate) {
            alert('Select Actual Start Date');
          }
          else if (!this.taskForm.value.actualEndDate) {
            alert('Select Actual End Date');
          }
          else if (this.taskForm.value.executionStepName === '') {
            alert('Enter Execution Step Name');
          }
          else if (this.taskForm.value.executionStepDesc === '') {
            alert('Enter Execution Step Desc');
          }
          else {
            this.ExecuteFunc()
          }
        }
        else if (this.taskForm.value.executionStepName === '') {
          alert('Enter Execution Step Name');
        }
        else if (this.taskForm.value.executionStepDesc === '') {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
        break;

      case 'Completed':
        if (this.taskForm.value.pickedStatus.trim() == 'Not Picked') {
          alert('Please pick task to change to complete!');
        } else {
          if (!this.taskForm.value.plannedStartDate) {
            alert('Select Planned Start Date');
          }
          else if (!this.taskForm.value.plannedEndDate) {
            alert('Select Planned End Date');
          }
          else if (this.taskForm.value.assignedTo === '') {
            alert('Enter Employee Name');
          }
          else if (this.taskForm.value.pickedStatus == '') {
            alert('Select Picked Status');
          }
          else if (this.taskForm.value.pickedStatus?.trim() == 'Picked' && !this.taskForm.value.pickedDate || this.taskForm.value.pickedStatus?.trim() == 'Picked' && this.taskForm.value.pickedDate == '') {
            alert('Select Picked Date');
          }
          else if (this.taskForm.value.actualStartDate == '' || this.taskForm.value.actualStartDate == undefined) {
            alert('Select Actual Start Date');
          }
          else if (this.taskForm.value.actualEndDate == '' || this.taskForm.value.actualEndDate == undefined) {
            alert('Select Actual End Date');
          }
          else if (this.taskForm.value.executionStepName === '') {
            alert('Enter Execution Step Name');
          }
          else if (this.taskForm.value.executionStepDesc === '') {
            alert('Enter Execution Step Desc');
          }
          else {
            this.ExecuteFunc()
          }
        }
        break;

      case 'Unassigned':
        if (this.taskForm.value.pickedStatus?.trim() === 'Picked') {
          if (!this.taskForm.value.plannedStartDate) {
            alert('Select Planned Start Date');
          }
          else if (!this.taskForm.value.plannedEndDate) {
            alert('Select Planned End Date');
          }
          else if (this.taskForm.value.status === '') {
            alert('Select Status');
          }
          else if (this.taskForm.value.assignedTo === '') {
            alert('Enter Employee Name');
          }
          else if (!this.taskForm.value.pickedDate) {
            alert('Select Picked Date');
          }
          else if (!this.taskForm.value.actualStartDate) {
            alert('Select Actual Start Date');
          }
          else if (!this.taskForm.value.actualEndDate) {
            alert('Select Actual End Date');
          }
          else if (this.taskForm.value.executionStepName === '') {
            alert('Enter Execution Step Name');
          }
          else if (this.taskForm.value.executionStepDesc === '') {
            alert('Enter Execution Step Desc');
          }
          else {
            this.ExecuteFunc()
          }
        }
        else if (this.taskForm.value.pickedStatus?.trim() == 'Not Picked') {
          if (!this.taskForm.value.plannedStartDate) {
            alert('Select Planned Start Date');
          }
          else if (!this.taskForm.value.plannedEndDate) {
            alert('Select Planned End Date');
          }
          else if (this.taskForm.value.status === '') {
            alert('Select Status');
          }
          else if (this.taskForm.value.assignedTo === '') {
            alert('Enter Employee Name');
          }
          else if (!this.taskForm.value.actualStartDate) {
            alert('Select Actual Start Date');
          }
          else if (!this.taskForm.value.actualEndDate) {
            alert('Select Actual End Date');
          }
          else if (this.taskForm.value.executionStepName === '') {
            alert('Enter Execution Step Name');
          }
          else if (this.taskForm.value.executionStepDesc === '') {
            alert('Enter Execution Step Desc');
          }
          else {
            this.ExecuteFunc()
          }
        }
        else if (this.taskForm.value.pickedStatus?.trim() == 'Picked') {
          if (!this.taskForm.value.pickedDate) {
            alert('Enter Picked Date');
          }
          else if (!this.taskForm.value.actualStartDate) {
            alert('Select Actual Start Date');
          }
        }
        else if (this.taskForm.value.pickedStatus == 'Not Picked') {
          if (!this.taskForm.value.actualStartDate) {
            alert('Select Actual Start Date');
          }
        }
        else if (this.taskForm.value.executionStepName === '') {
          alert('Enter Execution Step Name');
        }
        else if (this.taskForm.value.executionStepDesc === '') {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
        break;

      default:
        if (this.taskForm.value.pickedStatus?.trim() === 'Picked' && this.taskForm.value.status !== 'Completed') {
          if (!this.taskForm.value.plannedStartDate) {
            alert('Select Planned Start Date');
          }
          else if (!this.taskForm.value.plannedEndDate) {
            alert('Select Planned End Date');
          }
          else if (this.taskForm.value.status === '') {
            alert('Select Status');
          }
          else if (this.taskForm.value.assignedTo === '') {
            alert('Enter Employee Name');
          }
          else if (!this.taskForm.value.pickedDate) {
            alert('Select Picked Date');
          }
          else if (!this.taskForm.value.actualStartDate) {
            alert('Select Actual Start Date');
          }
          else if (!this.taskForm.value.actualEndDate) {
            alert('Select Actual End Date');
          }
          else if (this.taskForm.value.executionStepName === '') {
            alert('Enter Execution Step Name');
          }
          else if (this.taskForm.value.executionStepDesc === '') {
            alert('Enter Execution Step Desc');
          }
          else {
            this.ExecuteFunc()
          }
        }
        if (this.taskForm.value.pickedStatus?.trim() === 'Not Picked' && this.taskForm.value.status !== 'Completed') {
          if (!this.taskForm.value.plannedStartDate) {
            alert('Select Planned Start Date');
          }
          else if (!this.taskForm.value.plannedEndDate) {
            alert('Select Planned End Date');
          }
          else if (this.taskForm.value.status === '') {
            alert('Select Status');
          }
          else if (this.taskForm.value.assignedTo === '') {
            alert('Enter Employee Name');
          }
          else if (!this.taskForm.value.actualStartDate) {
            alert('Select Actual Start Date');
          }
          else if (!this.taskForm.value.actualEndDate) {
            alert('Select Actual End Date');
          }
          else if (this.taskForm.value.executionStepName === '') {
            alert('Enter Execution Step Name');
          }
          else if (this.taskForm.value.executionStepDesc === '') {
            alert('Enter Execution Step Desc');
          }
          else {
            this.ExecuteFunc()
          }
        }
        else if (this.taskForm.value.status === '' && this.taskForm.value.pickedStatus === '') {
          if (this.taskForm.value.executionStepName === '') {
            alert('Enter Execution Step Name');
            return;
          }
          if (this.taskForm.value.executionStepDesc === '') {
            alert('Enter Execution Step Desc');
            return;
          }
          this.ExecuteFunc()
        }
        break;
    }
  }

  assignedtousername: string = '';
  attachments: any = '';

  ExecuteFunc() {
    const assignedtouser = this.taskForm.value.assignedTo.split("-")[0];
    this.assignedtousername = this.taskForm.value.assignedTo?.split("-")[1]?.trim();
    const forwardedtouser = this.taskForm.value.forwardedTo.split("-")[0];

    const requestBody = {
      "flag": this.taskID != undefined ? 'U' : 'I',
      "itcrExecID": this.taskID != undefined ? this.taskID : 0,
      "itcrid": this.crrData?.itcrid,
      "sysLandscape": this.sysid,
      "executionStepName": this.taskForm.value.executionStepName?.trim(),
      "executionStepDesc": this.taskForm.value.executionStepDesc?.trim(),
      "assignedTo": assignedtouser ? assignedtouser : null,
      "startDt": this.taskForm.value.plannedStartDate ? this.taskForm.value.plannedStartDate : null,
      "endDT": this.taskForm.value.plannedEndDate ? this.taskForm.value.plannedEndDate : null,
      "attachments": this.attachments?.trim(),
      "status": this.taskForm.value.status?.trim(),
      "forwardStatus": this.taskForm.value.forwardStatus?.trim(),
      "forwardedTo": forwardedtouser ? forwardedtouser : null,
      "forwardedDt": this.taskForm.value.forwardedDate ? this.taskForm.value.forwardedDate : null,
      "reasonForwarded": this.taskForm.value.reasonForForwarding?.trim(),
      "remarks": this.taskForm.value.remarks?.trim(),
      "pickedStatus": this.taskForm.value.pickedStatus?.trim(),
      "pickedDt": this.taskForm.value.pickedDate ? this.taskForm.value.pickedDate : null,
      "actualStartDt": this.taskForm.value.actualStartDate ? this.taskForm.value.actualStartDate : null,
      "actualEndDt": this.taskForm.value.actualEndDate ? this.taskForm.value.actualEndDate : null,
      "dependSysLandscape": this.taskForm.value.dependSysLandscape ? this.taskForm.value.dependSysLandscape : null,
      "dependTaskId": this.taskForm.value.dependTask ? this.taskForm.value.dependTask : null,
      "createdBy": this.user.empData.employeeNo,
    }

    this.httpSer.httpPost(this.APIURLS.ExecuteCRTask, requestBody).subscribe(
      (response: any) => {
        if (response.type == "E") {
          alert(response.message);
          return;
        }
        else {
          if (this.taskID == undefined) {
            alert("RFC Code" + " " + this.crrData.crcode + " " + ": Impelmentation Task ID is successsfully Saved")
            this.Back();
            this.getexecutionhistory();
          }
          else {
            if (this.taskForm.value.status == "Assigned" && this.taskForm.value.pickedStatus?.trim() != 'Picked') {
              alert("RFC Code" + " " + this.crrData.crcode + " " + ": Implementation Task ID is successfully Assigned")
            }
            else if (this.taskForm.value.pickedStatus?.trim() == 'Picked' && this.taskForm.value.status == "Assigned") {
              alert("RFC Code" + " " + this.crrData.crcode + " " + ": Implementation Task ID is successfully Picked")
            }
            else if (this.taskForm.value.status == "Completed") {
              alert("RFC Code" + " " + this.crrData.crcode + " " + ": Implementation Task ID is successfully Completed")
            }
            else {
              alert("RFC Code" + " " + this.crrData.crcode + " " + " Updated Successfully")
            }
            this.Back();
          }
        }
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
  }

  lastItemfilteredexehist: any[] = [];
  emailitcrexecId: string = '';

  async getexecutionhistory() {
    const getAPI = this.APIURLS.UpdateCRHistoryAPI;
    try {
      const response: any = await this.httpSer.httpGet(getAPI + this.crrData?.itcrid).toPromise();
      if (response) {
        const maxValue = response.reduce((max: any, item: any) => item.itcrexecId > max ? item.itcrexecId : max, response[0].itcrexecId);
        const filteredData: any[] = response.filter((item: any) => item.itcrexecId == Number(maxValue));
        const filteredexehist: any[] = filteredData.filter((item: any) => parseInt(item.createdBy) == parseInt(this.user.empData.employeeNo));
        this.lastItemfilteredexehist = [filteredexehist[filteredexehist.length - 1]];
        this.emailitcrexecId = this.lastItemfilteredexehist[0].itcrexecId;
        this.getdependtask();
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  UpdateValueList: any[] = [];
  getUpdateData() {
    this.UpdateValueList = this.getCRExecuteList.filter((item: any) => Number(item.itcrexecId) === Number(this.taskID));

    if (this.UpdateValueList.length != 0) {
      const forwardedToId = this.UpdateValueList[0].forwardedtoid;
      const assignedtoid = this.UpdateValueList[0].assignedtoid;
      const forwardStatus = (forwardedToId !== '' && forwardedToId !== null) ? "Forwarded" : "Not Forwarded";
      const forwardedToVal = (forwardedToId == '' || forwardedToId == null) ? '' : this.UpdateValueList[0].forwardedtoid + "-" + this.UpdateValueList[0].forwardedTo;
      const assignedToVal = (assignedtoid == '' || assignedtoid == null) ? '' : this.UpdateValueList[0].assignedtoid + "-" + this.UpdateValueList[0].assignedTo;

      this.taskForm.patchValue({
        plannedStartDate: this.UpdateValueList[0].startDt,
        plannedEndDate: this.UpdateValueList[0].endDt,
        status: this.UpdateValueList[0].status,
        assignedTo: assignedToVal,
        forwardStatus: forwardStatus,
        forwardedTo: forwardedToVal,
        forwardedDate: this.UpdateValueList[0].forwardedDt,
        reasonForForwarding: this.UpdateValueList[0].reasonForwarded,
        pickedStatus: this.UpdateValueList[0].pickedStatus,
        pickedDate: this.UpdateValueList[0].pickedDt,
        actualStartDate: this.UpdateValueList[0].actualStartDt,
        actualEndDate: this.UpdateValueList[0].actualEndDt,
        dependSysLandscape: this.UpdateValueList[0].dependSysLandscapeid,
        dependTask: this.UpdateValueList[0].dependTaskId,
        executionStepName: this.UpdateValueList[0].executionStepName,
        executionStepDesc: this.UpdateValueList[0].executionStepDesc,
        remarks: this.UpdateValueList[0].remarks
      })
      this.GetHistory();
      this.getdependtask();
    }
  }

  getUpdateCRHistoryList: any[] = [];
  async GetHistory() {
    const getAPI = this.APIURLS.UpdateCRHistoryAPI;
    try {
      const res: any = await this.httpSer.httpGet(getAPI + this.crrData?.itcrid).toPromise();
      if (res) {
        this.getUpdateCRHistoryList = res.filter((item: any) => parseInt(item.itcrexecId) === parseInt(this.taskID));
        this.getUpdateCRHistoryList = this.getUpdateCRHistoryList.sort((a, b) => {
          return new Date(a.crhistoryDt).getTime() - new Date(b.crhistoryDt).getTime();
        });
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  Back() {
    const itcrid = this.crrData.itcrid;
    this.router.navigate(['/changerequest/cr-implement'], { queryParams: { id: itcrid } });
  }

  clearForm() {
    this.taskForm.reset({
      plannedStartDate: null,
      plannedEndDate: null,
      status: '',
      assignedTo: '',
      forwardStatus: '',
      forwardedTo: '',
      forwardedDate: null,
      reasonForForwarding: '',
      pickedStatus: '',
      pickedDate: null,
      actualStartDate: null,
      actualEndDate: null,
      dependSysLandscape: '',
      dependTask: '',
      executionStepName: '',
      executionStepDesc: '',
      remarks: ''
    });
  }

}
