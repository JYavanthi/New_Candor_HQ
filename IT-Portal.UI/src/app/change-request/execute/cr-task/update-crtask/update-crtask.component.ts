import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from '../../../passcrdata.service'; import { environment } from '@environments/environment';
import { GetEmployeeInfoService } from '../../../../services/get-employee-info.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-update-crtask',
  templateUrl: './update-crtask.component.html',
  styleUrl: './update-crtask.component.css'
})
export class UpdateCrtaskComponent {
  crid: any;
  sysid: any;
  filtersys: any;
  supportid: any;
  supportname: any;
  allEmpList: any[] = [];
  supportteam: any[] = [];
  employeeid: any[] = [];
  EmailNotification: boolean = false;
  constructor(private http: HttpClient, private datepipe: DatePipe, private employeeInfo: GetEmployeeInfoService, private router: Router, private route: ActivatedRoute, private routeservice: PasscrdataService) {
    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });

    this.employeeInfo.suppTeamList().then(() => {
      this.supportteam = this.employeeInfo.SupportTeamList;
      this.employeeid = this.supportteam;
    });

    this.routeservice.crdata.subscribe(data => {
      this.crid = data.report.value;
    })
    this.routeservice.sysdata.subscribe(data => {
      this.sysid = data?.report;
      this.filtersys = parseInt(this.sysid?.value);
    });

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;
    this.getupdatyevalue(this.itcrexecId);
  }

  itcrexecId: any = '';
  getidupdate() {
    this.itcrexecId = this.route.snapshot.paramMap.get('id'); //TaskID
  }

  private apiurl = environment.apiurls

  errorMessage: any = '';
  successMessage: any = '';

  clearErrorMessage() {
    this.errorMessage = '';
  }
  clearSuccessMessage() {
    this.successMessage = '';
  }

  ngOnInit(): void {
    this.getidupdate()
    this.getexecuteid();
    this.fetchAllItems();
    this.filterItems();
    setTimeout(() => {
      if (this.updatestatus == 'Completed') {
        this.DisableSubmit = true;
      }
    }, 500)
  }

  forwardedToChange() {
    this.forwardstatus = this.setforwardedto.length == 0 ? "Not Forwarded" : this.forwardstatus;
  }

  pickedStatusChange() {
    this.updatevalue[0].pickedDt = this.updatevalue[0].pickedStatus == "Not Picked" ? this.updatevalue[0].pickedDt = '' : this.updatevalue[0].pickedDt;
  }

  getexecuteid() {
    this.itcrexecId = this.route.snapshot.paramMap.get('id');
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
  forwardedTo: any = '';
  forwardedDt: any = '';
  reasonForwarded: any = '';
  remarks: any = '';
  pickedStatus: any = '';
  pickedDt: any = '';
  actualStartDt: any = '';
  actualEndDt: any = '';
  dependSysLandscape: any = '';
  dependTaskId: any = '';
  status: string = 'Implemented';
  DisableSubmit: boolean = false;
  /*forwardonValue = this.forwardedDt ? this.forwardedDt : null;
  startDtValue = this.startDt ? this.startDt : null;
  endDTValue = this.endDT ? this.endDT : null;
  actualStartDtValue = this.actualStartDt ? this.actualStartDt : null;
  actualEndDtValue = this.actualEndDt ? this.actualEndDt : null;*/
  assignedtoid: any = '';
  updatevalue: any[] = [];
  updatestatus: any = '';
  forwardstatus: any = '';
  pickedstatus: any = '';
  Startdate: any = '';
  enddate: any = '';
  forwardtoid: any = '';
  DependSysLandscape: any = 0;
  Selectthetask: string = '';

  async getupdatyevalue(itcrexecId: any) {
    const apiUrls: any = this.apiurl + '/Crexecute/GetExecute';
    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.updatevalue = response.filter((item: any) => Number(item.itcrexecId) === Number(this.itcrexecId));
        if (this.updatevalue.length > 0) {
          this.crid = this.updatevalue[0];
          this.getdepdenttask();
          this.getexecutionhistory();
          this.DependSysLandscape = this.updatevalue[0].dependSysLandscapeid;

          this.Selectthetask = this.updatevalue[0].dependTaskId;
          this.assignedtoid = this.updatevalue[0].assignedtoid;
          this.updatestatus = this.updatevalue[0].status?.trim();
          this.forwardtoid = this.updatevalue[0].forwardedtoid;

          if (!this.forwardtoid) {
            this.forwardstatus = 'Not Forwarded'
          }
          else {
            this.forwardstatus = 'Forwarded'
          }
          this.Startdate = this.updatevalue[0].startDt;
          this.enddate = this.updatevalue[0].endDt;
          this.pickedDt = this.updatevalue[0].pickedDt;
          const assignedtosupport = parseInt(this.setassignedname.split("-")[0]);
          this.getcrdata(this.crid?.itcrid);
          this.getsupportdata(this.assignedtoid);
          this.Systemtask();
          this.iniatorid();
          this.crrequestors();
        }
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }
  crdesc: any = '';
  crdateval: any = '';
  crrempid: any = '';
  crrdtls: any[] = [];
  croempid: any = '';

  async getcrdata(itcrid: any) {
    const apiUrls: any = this.apiurl + '/ChangeRequest/Getrequest';
    try {
      const response: any = await this.http.get(apiUrls).toPromise();
      if (response) {
        this.crrdtls = response.filter((item: any) => item.itcrid.toString() === itcrid.toString());
        this.crdesc = this.crrdtls[0].changeDesc;
        this.crdateval = this.crrdtls[0].crdate;
        this.crrempid = this.crrdtls[0].crrequestedBy;
        this.croempid = this.crrdtls[0].crowner;
        this.EmailNotification = this.crrdtls[0].crremailNotification;
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
  assignedto: any = '';
  assignedname: any = '';
  assignedemail: any = '';
  assgn: any[] = [];

  async getsupportdata(id: Number) {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.assgn = this.supportteam.filter((item: any) => item.empId === id);
        if (this.assgn.length > 0) {
          this.assignedname = this.assgn[0].empId + "-" + this.assgn[0].firstName + " " + this.assgn[0].lastName
          this.assignedemail = this.assgn[0].email;
        }
      }
    }
    catch (error) {
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
      this.crrequestedby = this.allEmpList.filter((item: any) => parseInt(item.employeeId) === parseInt(this.crrdtls[0].crrequestedBy));
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

  FirstsubmitExexute() {
    if (this.updatestatus == 'Completed' && this.crid?.dependSysLandscapeid != '' && this.Selectthetask != '') {
      const getSelectthetaskrow = this.depdenttask.filter((item: any) => item.itcrexecId == parseInt(this.Selectthetask));

      if (getSelectthetaskrow?.[0]?.status?.trim() != "Completed") {
        alert(`Please complete task ${getSelectthetaskrow[0].executionStepName} to complete this task!`);
        // this.crid['dependSysLandscapeid'] = '';
        //this.Selectthetask = '';
      } else {
        this.submitExexute()
      }
    }
    else {
      this.submitExexute()
    }
  }

  submitExexute() {
    if (this.updatestatus == 'Assigned' && this.updatevalue[0].pickedStatus == '' || this.updatestatus == 'Assigned' && this.updatevalue[0].pickedStatus == null) {
      if (!this.updatevalue[0].startDt || this.updatevalue[0].startDt == '' || this.updatevalue[0].startDt == null) {
        alert('Select Planned Start Date');
      }
      else if (!this.updatevalue[0].endDt || this.updatevalue[0].endDt == '' || this.updatevalue[0].endDt == null) {
        alert('Select Planned End Date');
      }
      else if (this.setassignedname === '' || this.setassignedname == null) {
        alert('Enter Assigned To');
      }
      else if (this.updatevalue[0].pickedStatus?.trim() == 'Picked') {
        if (!this.updatevalue[0].startDt || this.updatevalue[0].startDt == '' || this.updatevalue[0].startDt == null) {
          alert('Select Planned Start Date');
        }
        else if (!this.updatevalue[0].endDt || this.updatevalue[0].endDt == '' || this.updatevalue[0].endDt == null) {
          alert('Select Planned End Date');
        }
        else if (this.setassignedname == '' || this.setassignedname == null) {
          alert('Enter Employee Name');
        }
        else if (!this.updatevalue[0].pickedDt || this.updatevalue[0].pickedDt == '' || this.updatevalue[0].pickedDt == null) {
          alert('Select Picked Date');
        }
        else if (!this.updatevalue[0].actualStartDt) {
          alert('Select Actual Start Date');
        }
        else if (this.updatevalue[0].executionStepName == '' || this.updatevalue[0].executionStepName == null) {
          alert('Enter Execution Step Name');
        }
        else if (this.updatevalue[0].executionStepDesc == '' || this.updatevalue[0].executionStepDesc == null) {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
      }
      else if (this.updatevalue[0].pickedStatus?.trim() == 'Not Picked') {
        if (!this.updatevalue[0].startDt || this.updatevalue[0].startDt == '' || this.updatevalue[0].startDt == null) {
          alert('Select Planned Start Date');
        }
        else if (!this.updatevalue[0].endDt || this.updatevalue[0].endDt == '' || this.updatevalue[0].endDt == null) {
          alert('Select Planned End Date');
        }
        else if (this.setassignedname == '' || this.setassignedname == null) {
          alert('Enter Employee Name');
        }
        else if (!this.updatevalue[0].actualStartDt) {
          alert('Select Actual Start Date');
        }
        else if (this.updatevalue[0].executionStepName == '' || this.updatevalue[0].executionStepName == null) {
          alert('Enter Execution Step Name');
        }
        else if (this.updatevalue[0].executionStepDesc == '' || this.updatevalue[0].executionStepDesc == null) {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
      }
      else if (this.updatevalue[0].executionStepName == '' || this.updatevalue[0].executionStepName == null) {
        alert('Enter Execution Step Name');
      }
      else if (this.updatevalue[0].executionStepDesc == '' || this.updatevalue[0].executionStepDesc == null) {
        alert('Enter Execution Step Desc');
      }
      else {
        this.ExecuteFunc()
      }
    }

    else if (this.updatestatus == 'Onhold') {
      if (this.updatevalue[0].pickedStatus?.trim() == 'Picked') {

        if (!this.updatevalue[0].startDt || this.updatevalue[0].startDt == '' || this.updatevalue[0].startDt == null) {
          alert('Select Planned Start Date');
        }
        else if (!this.updatevalue[0].endDt || this.updatevalue[0].endDt == '' || this.updatevalue[0].endDt == null) {
          alert('Select Planned End Date');
        }
        else if (this.setassignedname == '' || this.setassignedname == null) {
          alert('Enter Employee Name');
        }
        else if (!this.updatevalue[0].pickedDt || this.updatevalue[0].pickedDt == '' || this.updatevalue[0].pickedDt == null) {
          alert('Select Picked Date');
        }
        else if (!this.updatevalue[0].actualStartDt) {
          alert('Select Actual Start Date');
        }
        else if (this.updatevalue[0].executionStepName == '' || this.updatevalue[0].executionStepName == null) {
          alert('Enter Execution Step Name');
        }
        else if (this.updatevalue[0].executionStepDesc == '' || this.updatevalue[0].executionStepDesc == null) {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
      }
      else if (this.updatevalue[0].pickedStatus?.trim() == 'Not Picked') {
        if (!this.updatevalue[0].startDt || this.updatevalue[0].startDt == '' || this.updatevalue[0].startDt == null) {
          alert('Select Planned Start Date');
        }
        else if (!this.updatevalue[0].endDt || this.updatevalue[0].endDt == '' || this.updatevalue[0].endDt == null) {
          alert('Select Planned End Date');
        }
        else if (this.setassignedname == '' || this.setassignedname == null) {
          alert('Enter Employee Name');
        }
        else if (!this.updatevalue[0].actualStartDt) {
          alert('Select Actual Start Date');
        }
        else if (this.updatevalue[0].executionStepName == '' || this.updatevalue[0].executionStepName == null) {
          alert('Enter Execution Step Name');
        }
        else if (this.updatevalue[0].executionStepDesc == '' || this.updatevalue[0].executionStepDesc == null) {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
      }
      else if (this.updatevalue[0].executionStepName == '' || this.updatevalue[0].executionStepName == null) {
        alert('Enter Execution Step Name');
      }
      else if (this.updatevalue[0].executionStepDesc == '' || this.updatevalue[0].executionStepDesc == null) {
        alert('Enter Execution Step Desc');
      }
      else {
        this.ExecuteFunc()
      }
    }

    else if (this.updatestatus == 'Completed') {
      if (this.updatevalue[0].pickedStatus == "Not Picked") {
        alert('Please pick task to change to complete!');
      } else {
        if (!this.updatevalue[0].startDt || this.updatevalue[0].startDt == '' || this.updatevalue[0].startDt == null) {
          alert('Select Planned Start Date');
        }
        else if (!this.updatevalue[0].endDt || this.updatevalue[0].endDt == '' || this.updatevalue[0].endDt == null) {
          alert('Select Planned End Date');
        }
        else if (this.setassignedname == '' || this.setassignedname == null) {
          alert('Enter Employee Name');
        }
        else if (this.updatevalue[0].pickedStatus == '' || this.updatevalue[0].pickedStatus == null) {
          alert('Select Picked Status');
        }
        else if (this.updatevalue[0].pickedStatus?.trim() == 'Picked' && !this.updatevalue[0].pickedDt || this.updatevalue[0].pickedStatus?.trim() == 'Picked' && this.updatevalue[0].pickedDt == '' || this.updatevalue[0].pickedStatus?.trim() == 'Picked' && this.updatevalue[0].pickedDt == null) {
          alert('Select Picked Date');
        }
        else if (!this.updatevalue[0].actualStartDt || this.updatevalue[0].actualStartDt == '' || this.updatevalue[0].actualStartDt == null) {
          alert('Select Actual Start Date');
        }
        else if (!this.updatevalue[0].actualEndDt || this.updatevalue[0].actualEndDt == '' || this.updatevalue[0].actualEndDt == null) {
          alert('Select Actual End Date');
        }
        else if (this.updatevalue[0].executionStepName == '' || this.updatevalue[0].executionStepName == null) {
          alert('Enter Execution Step Name');
        }
        else if (this.updatevalue[0].executionStepDesc == '' || this.updatevalue[0].executionStepDesc == null) {
          alert('Enter Execution Step Desc');
        }
        else {
          this.ExecuteFunc()
        }
      }
    }


    else if (this.updatestatus == 'Unassigned') {

      if (this.updatevalue[0].executionStepName == '' || this.updatevalue[0].executionStepName == null) {
        alert('Enter Execution Step Name');
      }
      else if (this.updatevalue[0].executionStepDesc == '' || this.updatevalue[0].executionStepDesc == null) {
        alert('Enter Execution Step Desc');
      }
      else {
        this.ExecuteFunc()
      }
    }

    else if (this.updatevalue[0].pickedStatus?.trim() == 'Picked' && this.updatestatus != 'Completed') {
      if (!this.updatevalue[0].startDt || this.updatevalue[0].startDt == '' || this.updatevalue[0].startDt == null) {
        alert('Select Planned Start Date');
      }
      else if (!this.updatevalue[0].endDt || this.updatevalue[0].endDt == '' || this.updatevalue[0].endDt == null) {
        alert('Select Planned End Date');
      }
      else if (this.setassignedname == '' || this.setassignedname == null) {
        alert('Enter Employee Name');
      }
      else if (!this.updatevalue[0].pickedDt || this.updatevalue[0].pickedDt == '' || this.updatevalue[0].pickedDt == null) {
        alert('Select Picked Date');
      }
      else if (!this.updatevalue[0].actualStartDt) {
        alert('Select Actual Start Date');
      }
      else if (this.updatevalue[0].executionStepName == '' || this.updatevalue[0].executionStepName == null) {
        alert('Enter Execution Step Name');
      }
      else if (this.updatevalue[0].executionStepDesc == '' || this.updatevalue[0].executionStepDesc == null) {
        alert('Enter Execution Step Desc');
      }
      else {
        this.ExecuteFunc()
      }
    }

    else if (this.updatevalue[0].pickedStatus?.trim() == 'Not Picked' && this.updatestatus != 'Completed') {
      if (!this.updatevalue[0].startDt || this.updatevalue[0].startDt == '' || this.updatevalue[0].startDt == null) {
        alert('Select Planned Start Date');
      }
      else if (!this.updatevalue[0].endDt || this.updatevalue[0].endDt == '' || this.updatevalue[0].endDt == null) {
        alert('Select Planned End Date');
      }
      else if (this.setassignedname == '' || this.setassignedname == null) {
        alert('Enter Employee Name');
      }
      else if (!this.updatevalue[0].actualStartDt) {
        alert('Select Actual Start Date');
      }
      else if (this.updatevalue[0].executionStepName == '' || this.updatevalue[0].executionStepName == null) {
        alert('Enter Execution Step Name');
      }
      else if (this.updatevalue[0].executionStepDesc == '' || this.updatevalue[0].executionStepDesc == null) {
        alert('Enter Execution Step Desc');
      }
      else {
        this.ExecuteFunc()
      }
    }

    else if (this.updatestatus == '' && this.updatevalue[0].pickedStatus == '' || this.updatestatus == null && this.updatevalue[0].pickedStatus == null) {
      if (this.updatevalue[0].executionStepName == '' || this.updatevalue[0].executionStepName == null) {
        alert('Enter Execution Step Name');
      }
      else if (this.updatevalue[0].executionStepDesc == '' || this.updatevalue[0].executionStepDesc == null) {
        alert('Enter Execution Step Desc');
      }
      else {
        this.ExecuteFunc()
      }
    }

  }

  ExecuteFunc() {
    const apiUrl = this.apiurl + '/Crexecute/executeplan'
    const assignedtosupport = parseInt(this.setassignedname.split("-")[0]);
    const forwardedtosupport = parseInt(this.setforwardedto.split("-")[0]);
    this.dependSysLandscape = this.crid?.dependSysLandscapeid;
    if (this.Selectthetask === null) this.dependSysLandscape = null;

    const requestBody = {
      "flag": "U",
      "itcrExecID": this.itcrexecId,
      "itcrid": this.crid?.itcrid,
      "sysLandscape": this.updatevalue[0].sysLandscapeid,
      "executionStepName": this.updatevalue[0].executionStepName,
      "executionStepDesc": this.updatevalue[0].executionStepDesc,
      "assignedTo": assignedtosupport ? assignedtosupport : null,
      "startDt": this.updatevalue[0].startDt ? this.updatevalue[0].startDt : null,
      "endDT": this.updatevalue[0].endDt ? this.updatevalue[0].endDt : null,
      "attachments": this.attachments,
      "status": this.updatestatus,
      "forwardStatus": this.forwardstatus,
      "forwardedTo": forwardedtosupport ? forwardedtosupport : null,
      "forwardedDt": this.updatevalue[0].forwardedDt ? this.updatevalue[0].forwardedDt : null,
      "reasonForwarded": this.updatevalue[0].reasonForwarded,
      "remarks": this.updatevalue[0].remarks,
      "pickedStatus": this.updatevalue[0].pickedStatus,
      "pickedDt": this.updatevalue[0].pickedDt ? this.updatevalue[0].pickedDt : null,
      "actualStartDt": this.updatevalue[0].actualStartDt ? this.updatevalue[0].actualStartDt : null,
      "actualEndDt": this.updatevalue[0].actualEndDt ? this.updatevalue[0].actualEndDt : null,
      "dependSysLandscape": this.dependSysLandscape ? this.dependSysLandscape : null,
      "dependTaskId": this.Selectthetask ? this.Selectthetask : null,
      "createdBy": parseInt(this.supportid),
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
        } else {
          if (this.updatestatus == "Assigned" && this.updatevalue[0].pickedStatus?.trim() != 'Picked') {
            alert("RFC Code" + " " + this.crrdtls[0].crcode + " " + ": Implementation Task ID is successfully Assigned")
            setTimeout(() => {
              this.sendemailfrom(this.updatestatus);
            }, 1000)
          }
          else if (this.updatevalue[0].pickedStatus?.trim() == 'Picked' && this.updatestatus == "Assigned") {
            alert("RFC Code" + " " + this.crrdtls[0].crcode + " " + ": Implementation Task ID is successfully Picked")
            setTimeout(() => {
              this.sendemailfrom(this.updatevalue[0].pickedStatus);
            }, 1000)
          }
          else if (this.updatestatus == "Completed") {
            alert("RFC Code" + " " + this.crrdtls[0].crcode + " " + ": Implementation Task ID is successfully Completed")
            setTimeout(() => {
              this.sendemailfrom(this.updatestatus);
            }, 1000)
          }
          else {
            alert("RFC Code" + " " + this.crrdtls[0].crcode + " " + " Updated Successfully")
          }
          this.goToTab('contact');
        }
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
  }

  Cremailvalue: any[] = [];
  viewemail(status: any) {
    //api/Crtaskemail/GetCrTaskEmail
    //const apiUrl = this.apiurl + '/Crtaskemail/GetCrTaskEmail'
    //const requestBody = {

    //}
    //this.http.get(apiUrl, requestBody).subscribe(
    //  (response: any) => {
    //    this.Cremailvalue = response.filter((item: any) => item.itcrid === this.crid.value.itcrid && item.taskId === Number(this.itcrexecId) );
    setTimeout(() => {
      this.sendemailfrom(status)
    }, 500);
    (error: any) => {
      console.log('Post request failed', error);
    }
  }

  crdate: any = '';
  assignDate: any = '';
  selectedStatus: string = '';
  responseStatus: string = '';

  sendemailfrom(status: any) {
    this.responseStatus = '';
    this.selectedStatus = '';
    const apiUrl = this.apiurl + '/Email'
    const emailcrdate: any = this.datepipe.transform(this.updatevalue?.[0]?.createdDt, 'dd-MMM-yyyy')
    let to = this.assignedemail
    if (this.EmailNotification == true) {
      var sendCrEmail: any = this.crremail;
    } else {
      var sendCrEmail: any = "";
    }
    let cc = this.croemail;
    let cc2 = sendCrEmail;
    const requestdate: any = this.datepipe.transform(this.crdateval, 'dd-MMM-yyyy')
    const changeDesc = this.crdesc
    const assigneddate = this.assignDate
    const output = this.readHtmlFile('assets/emailexecute.html');

    if (this.updatestatus == "Assigned" && this.updatevalue[0].pickedStatus != "Picked") {
      this.selectedStatus = 'Assigned';
      this.responseStatus = "assigned to your Queue under Implementation";
    }
    else if (this.updatestatus == "" && this.updatevalue[0].pickedStatus == "" || this.updatestatus == "" && this.updatevalue[0].pickedStatus != "Picked") {
      this.selectedStatus = 'Unassigned';
      this.responseStatus = "Unassigned";
    }
    else if (this.updatestatus == "Completed") {
      this.selectedStatus = 'Completed';
      this.responseStatus = "Completed";
    }
    else if (this.updatestatus != "Completed" && this.updatevalue[0].pickedStatus == "Picked") {
      this.selectedStatus = 'Picked';
      this.responseStatus = "Picked";
    }

    const populatedOutput = output
      .replace('${crid}', this.crrdtls[0].crcode)
      .replace('${crid}', this.crrdtls[0].crcode)
      .replace('${response.status}', this.responseStatus)
      .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
      .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
      .replace('{{this.Cremailvalue[0].crdate}}', requestdate)
      .replace('{{this.Cremailvalue[0].changeDesc}}', changeDesc)
      .replace('${status}', status)
      .replace('${status}', status)
      .replace('${response[0].taskId}', this.itcrexecId)
      .replace('${response[0].taskId}', this.itcrexecId)
      .replace('${response[0].estatus}', 'Implement')
      .replace('${response[0].estatus}', this.updatestatus)
      .replace('${response[0].assignedToName}', this.assignedname)
      .replace('${response[0].assignedToName}', this.assignedname)
      .replace('${response[0].assignedDt}', emailcrdate)
      .replace('${response[0].taskDesc}', this.updatevalue[0].executionStepDesc)
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
      "subject": `For following RFC Code: ${this.crrdtls[0].crcode}, the Task ID: ${this.itcrexecId} is ${this.responseStatus}`,
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
      });
  }

  readHtmlFile(file: string): string {
    const xhr = new XMLHttpRequest();
    xhr.open('GET', file, false);
    xhr.send();
    if (xhr.status === 200) {
      return xhr.responseText;
    } else {
      return '';
    }
  }
  goToTab(tabId: string) {
    const itcrid = this.crid?.itcrid;
    this.router.navigate([`/executive/${this.crid?.itcrid}/edit`], { fragment: tabId });
    setTimeout(() => {
      const tabButton = document.getElementById(tabId + '-tab');
      if (tabButton) {
        tabButton.click();
      }
    }, 500);
  }

  /*search filter*/
  dropdownItems: string[] = [];
  dropdownItemscr: string[] = [];
  selectedValue: string = '';
  selectedValuecr: string = '';
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
    }
  }

  dropdownsupportteamid: any;
  filterItems() {
    const filter = this.setassignedname.toUpperCase();
    this.dropdownItems = this.supportteamname.filter(item =>
      item.toUpperCase().includes(filter)

    );
    /* this.dropdownsupportteamid = this.supportteamid.filter();*/
    if (this.dropdownItems.length === 0 && filter !== '') {
      this.dropdownItems.push('No name found');
    }
    else if (filter === '') {
      this.dropdownItems.length = 0
    }

  }
  selectItem(item: string) {
    this.selectedValue = item;
    this.setassignedname = item;
    this.dropdownItems = [];
  }

  supportassignedto: any[] = [];
  setassignedname: any = '';

  async iniatorid() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.supportassignedto = this.supportteam.filter((item: any) => item.empId === parseInt(this.updatevalue[0].assignedtoid));
        if (this.supportassignedto.length > 0) {
          this.setassignedname = this.supportassignedto[0].empId + "-" + this.supportassignedto[0].firstName + " " + this.supportassignedto[0].lastName
        }
      }
    }
    catch (error) {
    }
  }

  supforwardedto: any[] = [];
  setforwardedto: any = '';

  async crrequestors() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.supforwardedto = this.supportteam.filter((item: any) => item.empId === parseInt(this.updatevalue[0].forwardedtoid));
        if (this.supforwardedto.length > 0) {
          this.setforwardedto = this.supforwardedto[0].empId + "-" + this.supforwardedto[0].firstName + " " + this.supforwardedto[0].lastName
        }
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  filterItemscr() {
    const filter = this.setforwardedto.toUpperCase();
    this.dropdownItemscr = this.supportteamname.filter(item =>
      item.toUpperCase().includes(filter)
    );
    if (this.dropdownItemscr.length === 0 && filter !== '') {
      this.dropdownItemscr.push('No name found');
    }
    else if (filter === '') {
      this.dropdownItemscr.length = 0
    }
  }

  selectItemcr(item: string) {
    this.selectedValuecr = item;
    this.setforwardedto = item;
    this.dropdownItemscr = [];
    this.forwardstatus = this.selectedValuecr != 'No name found' ? "Forwarded" : this.forwardstatus;
  }

  /*task name*/
  taskname: any;
  Systemtask() {
    const apiUrl = this.apiurl + '/SystemLandscape/Allsystems';
    const requestBody = {
    }
    this.http.get(apiUrl, requestBody).subscribe(
      (response: any) => {
        this.taskname = response.filter((item: any) => item.sysLandscapeId === this.updatevalue[0].sysLandscape);
      },
      (error: any) => {
        console.error('POST request failed', error);
      });
  }

  systemlandscape: any[] = [];

  async getsystemlandscape() {

    const apiUrl = this.apiurl + '/SystemLandscape/Getsystems';
    const requestBody = {
      "categroyId": this.crrdtls[0].categoryId,
      "supportId": this.crrdtls[0].supportId,
      "classificationId": this.crrdtls[0].classifcationId
    };
    try {
      const response: any = await this.http.post(apiUrl, requestBody).toPromise();

      if (response) {
        this.systemlandscape = response;
        if (this.crrdtls[0]['sysLandscapeId'] != null) {
          let checkedVlues = this.crrdtls[0]['sysLandscapeId'].split(',')
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
        if (this.updatevalue[0].dependSysLandscapeid != null) {
          var FiltData: number = this.updatevalue[0].dependSysLandscapeid;
        } else {
          var FiltData: number = this.filtersys;
        }
        this.systemlandscape = response.filter((item: any) => item.sysLandscapeId <= FiltData);
      },
      (error: any) => {
        console.error('POST request failed', error);
      });
  }*/

  depdenttask: any[] = [];
  getdepdenttask() {
    const apiUrl = this.apiurl + '/Crexecute/GetExecute';
    this.http.get(apiUrl).subscribe(
      (response: any) => {
        if (this.crid?.dependSysLandscapeid == null) {
          var filteredData: number = this.filtersys;
        } else {
          var filteredData: number = this.crid?.dependSysLandscapeid;
        }
        this.depdenttask = response.filter((item: any) => item.sysLandscapeid == filteredData && item.itcrid == this.updatevalue[0].itcrid);
        //this.depdenttask = response.filter((item: any) => item.itcrid === this.crid.value.itcrid);
        this.depdenttask = this.depdenttask.filter((item: any) => item.itcrexecId != this.itcrexecId);
      },
      (error: any) => {
      });
  }

  executionhistory: any[] = [];
  getexecutionhistory() {
    const apiUrls = this.apiurl + '/ViewChangeHistory/GetCrExecutionPlanHistory?id=' + this.crid?.itcrid
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.executionhistory = response.filter((item: any) => parseInt(item.itcrexecId) === parseInt(this.itcrexecId));
        this.executionhistory = this.executionhistory.sort((a, b) => {
          return new Date(a.crhistoryDt).getTime() - new Date(b.crhistoryDt).getTime();
        });
      },
      (error) => {
      }
    )
  }

  changestatusece() {
    if (this.updatestatus?.trim() == "Unassigned") {
      this.setassignedname = '';
    }
    else if (this.updatevalue[0].pickedStatus) {
      if (this.updatevalue[0].pickedStatus == "Not Picked" && this.updatestatus?.trim() == "Completed") {
        this.updatestatus = '';
        alert('Please pick task to change to complete!');
      }
    }
  }

}


