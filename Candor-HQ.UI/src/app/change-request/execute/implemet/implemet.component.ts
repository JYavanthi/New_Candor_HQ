import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { PasscrdataService } from '../../passcrdata.service';
import { ActivatedRoute, Router } from '@angular/router'; import { environment } from '@environments/environment';
import { GetEmployeeInfoService } from '../../../services/get-employee-info.service';
import { UserInfoSerService } from '../../../services/user-info-ser.service';

@Component({
  selector: 'app-implemet',
  templateUrl: './implemet.component.html',
  styleUrl: './implemet.component.css'
})
export class ImplemetComponent implements OnChanges {

  selectoption: any;
  showInitiator: boolean = false;
  showRiskQ: boolean = false;
  tabs: any[] = [];
  numberOfTabs: number = 1;
  plantData: any[] = [];
  status: any = '';
  approver: any = '';
  appdate: any = '';
  attach: any = '';
  remark: any = '';
  comment: any = '';
  @Input() crid: any;
  sysid: any;
  selecttask: any[] = [];
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
  forwardedTo: string = '';
  forwardedDt: any = '';
  reasonForwarded: any = '';
  remarks: any = '';
  pickedStatus: any = '';
  pickedDt: any = '';
  actualStartDt: any = '';
  actualEndDt: any = '';
  forwardonValue = this.forwardedDt ? this.forwardedDt : null;
  startDtValue = this.startDt ? this.startDt : null;
  endDTValue = this.endDT ? this.endDT : null;
  actualStartDtValue = this.actualStartDt ? this.actualStartDt : null;
  actualEndDtValue = this.actualEndDt ? this.actualEndDt : null;
  execowner: boolean = true;
  supportid: any;
  supportname: any;
  appstatus: any;
  itcrid: any;
  isImplemented: any = '';
  // getimplement: any = '';
  classificationId: any = '';
  categoryId: any = '';
  plantidforapp: any = '';
  today; any = '';
  crownername: string = '';
  allEmpList: any[] = [];
  supportteam: any[] = [];
  EmailNotification: boolean = false;
  templateid: string = '';
  categorytypeId: any;
  user: any;

  constructor(private http: HttpClient, private route: ActivatedRoute, private userinfoSer: UserInfoSerService,
    private employeeInfo: GetEmployeeInfoService, private routeservice: PasscrdataService, private router: Router) {
    this.user = userinfoSer.getUser();

    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });

    this.employeeInfo.suppTeamList().then(() => {
      this.supportteam = this.employeeInfo.SupportTeamList;
    });

    // this.routeservice.crdata.subscribe(data => {
    // this.crid = data.report.value;
    this.itcrid = this.route.snapshot.paramMap.get('id');
    /*if (this.crid){
    this.appstatus = this.crid.status.trim();
    this.crownername = this.crid.crowner;
    this.isImplemented = this.crid.isImplemented;
    this.plantidforapp = this.crid.plantcode;
    this.categoryId = this.crid.itcategoryId;
    this.categorytypeId = this.crid.categoryTypeId;
    this.classificationId = this.crid.itclassificationId;
    }*/
    // })
    this.routeservice.sysdata.subscribe(data => {
      this.sysid = data?.report;
    });
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;
  }

  private apiurl = environment.apiurls

  nagivate() {
    const report = {
      value: this.selectoption
    }
    this.routeservice.syslandscapedata({ report })
    this.router.navigate(['/cr-task'], { queryParams: { id: this.itcrid, sysid: this.selectoption } })
  }

  UpdateCR() {
    const report = {
      value: this.selectoption
    }
    this.routeservice.syslandscapedata({ report })
  }

  Update(val: any) {
    this.selectoption = val;
    const report = {
      value: this.selectoption
    }
    this.routeservice.syslandscapedata({ report })
  }

  navigateToUpdate(row: any) {
    this.router.navigate(['/updatetask/' + row.itcrexecId + '/edit'], {
      queryParams: { crId: this.itcrid }
    })


    // PPPPPPPPPPPPPPPPPPPPP
  }

  handleFileInput(event: any, index: number) {
    const file = event.target.files[0];
    this.plantData[index].attachment = file;
  }
  uniqueLandscapes: string[] = [];

  type: any = '';
  data: any = [];
  items: any[] = [];
  selectedCategory: string = '';
  filteredData: any[] = [];
  landscapeOptions: number[] = [];
  exectivevalue: any[] = [];
  crownerid: any = '';

  ngOnInit(): void {
    this.getvalue();
    this.usersupportteams();
    this.asignandviewtasks();
    this.landscapeOptions = this.value.map((item: { sysLandscape: any; }) => item.sysLandscape)
      .filter((value: any, index: any, self: string | any[]) => self.indexOf(value) === index);
    setTimeout(() => {
      this.getreleaseforapprove();
      this.getexecutionhistory();
    }, 1000);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['crid']) {
      if (!this.crid) {
        return
      }
      this.appstatus = this.crid.status.trim();
      this.crownername = this.crid?.crowner;
      this.isImplemented = this.crid?.isImplemented;
      this.plantidforapp = this.crid?.plantId;
      this.categoryId = this.crid?.categoryId;
      this.categorytypeId = this.crid?.categoryTypeId;
      this.classificationId = this.crid?.classificationId;
      this.getvalue();
      this.usersupportteams();
      this.asignandviewtasks();
      this.getrequetervalue(this.itcrid);
      this.landscapeOptions = this.value.map((item: { sysLandscape: any; }) => item.sysLandscape)
        .filter((value: any, index: any, self: string | any[]) => self.indexOf(value) === index);
      setTimeout(() => {
        this.getreleaseforapprove();
        this.getexecutionhistory();
      }, 1000);
    }
  }
  asignandviewtask: boolean = false;

  asignandviewtasks() {
    if (Object.keys(this.landscapeTasks).length === 0) {
      this.asignandviewtask = true
    }
    else {
      this.asignandviewtask = false
    }
  }


  fnTask(task: any) {
  }

  predefindtaskradio: boolean = false;
  manualtaskradio: boolean = false;

  updateCheckbox(checkboxNumber: number) {
  }

  head: string = '';
  filterData(event: any) {
    const selectedLandscape: number = event.target.value;
    if (selectedLandscape) {
      this.filteredData = this.value.filter((row: any) => row.sysLandscapeid.toString() === selectedLandscape.toString());
      this.releaseforapprove = this.value.filter((item: any) => item.itcrid === this.crid.itcrid).every((row: any) => row.status?.trim() === 'Completed');
    } else {
      this.filteredData = this.value;
      this.releaseforapprove = false;
    }
    this.UpdateCR();
  }

  systemlandscape: any[] = [];
  getcheckedVlues: any[] = [];
  filteredsystemlandscape: any[] = [];

  async getsystemlandscape() {
    if (!this.crid) {
      return
    }
    const apiUrl = this.apiurl + '/SystemLandscape/Getsystems';
    const requestBody = {
      "categroyId": this.crid?.categoryId,
      "supportId": this.crid?.supportId,
      "classificationId": this.crid?.classificationId
    };

    try {
      const response: any = await this.http.post(apiUrl, requestBody).toPromise();

      if (response) {
        this.systemlandscape = response;
        if (this.updatevalue[0]?.['sysLandscapeId'] != null) {
          let checkedVlues = this.updatevalue[0]?.['sysLandscapeId'].split(',')
          this.getcheckedVlues = checkedVlues;
          this.systemlandscape.forEach(m => m['isChcked'] = (checkedVlues.indexOf(m.sysLandscapeId.toString()) != -1) ? true : false)
          this.systemlandscape = this.systemlandscape.filter((item) => item.isChcked == true);
          this.getpredefinedtemplates();
        }
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  submitExexute() {
    const apiUrl = this.apiurl + '/Crexecute/executeplan';
    const requestBody = {
      "flag": "V",
      "itcrid": this.crid.itcrid,
      "sysLandscape": 1,
      "executionStepName": "",
      "executionStepDesc": "",
      "assignedTo": null,
      "startDt": null,
      "endDT": null,
      "attachments": null,
      "status": "Implemented",
      "forwardStatus": null,
      "forwardedTo": null,
      "forwardedDt": null,
      "reasonForwarded": null,
      "remarks": null,
      "pickedStatus": null,
      "pickedDt": null,
      "actualStartDt": null,
      "actualEndDt": this.actualEndDtValue,
      "createdBy": null,

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
          alert("RFC Code" + " " + this.crid.crcode + " " + ": Release successfully submitted for Approval");
          this.emailapproversinfo('Submitted for Approval');
          this.router.navigate(['/change-request']);
        }
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
  }

  emailapproversinfo(status: string): Promise<any> {
    const apiUrl = this.apiurl + '/GetApproverforEmail/GetApproverEmail';
    const requestBody = {
      "stage": "C",
      "plantid": Number(this.plantidforapp),
      "categoryId": Number(this.categoryId),
      "classificationId": Number(this.classificationId)
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post(apiUrl, requestBody, httpOptions).toPromise()
      .then((response: any) => {
        this.appv = response
        this.sendemailfrom(status, this.appv);
      })
      .catch((error: any) => {
        throw error;
      });
  }

  crremail: any = '';
  croemail: any = '';
  crrequestedBy: any = '';

  approver1N: any = ''
  approver2N: any = ''
  approver3N: any = ''
  approver1: any = ''
  approver2: any = ''
  approver3: any = ''
  plantid: any = ''
  appv: any[] = []
  apprv1email: any = ''
  apprv2email: any = ''
  apprv3email: any = ''
  valuereq: any = '';

  async getrequetervalue(itcrid: any) {
    // const apiUrls: any = this.apiurl + '/ChangeRequest/Getrequest';

    // try {
    //   const response: any = await this.http.get(apiUrls).toPromise();

    //   if (response) {
    // this.valuereq = response
    this.valuereq = [this.crid]
    this.updatevalue = [this.crid]
    this.crownerid = this.updatevalue[0]?.crowner;
    this.getsupportteams();
    this.getCrOwnerfromsupteam();
    this.getsystemlandscape();
    //   } else {
    //     console.error('Response is undefined or null');
    //   }
    // } catch (error) {
    //   console.error('GET request failed', error);
    // }
  }

  supportpersonname: any = ''
  firstname: any = ''
  middlename: any = ''
  lastname: any = ''
  employeeid: any = ''
  supportteams: any[] = [];

  async usersupportteams() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.supportteams = this.supportteam.filter((row: any) => row.empId == parseInt(this.supportid.trim()));
        this.employeeid = this.supportteams[0].empId;
        this.firstname = this.supportteams[0].firstName;
        this.middlename = this.supportteams[0].middleName;
        this.lastname = this.supportteams[0].lastName;
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
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  crval: any[] = [];
  crrname: any = '';
  crrempid: any = '';
  croempid: any = '';
  crempid: any = '';
  cremail: any = '';

  async getcrinfo(empid: Number) {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.crval = this.supportteam.filter(item => item.empId === Number(empid))
        this.croemail = this.crval[0].email
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  croemailid: any = ''
  crdate: any = ''
  crrdate: any = ''
  crdesc: any = ''
  emailCR: any[] = []

  async getcrdata() {

    // const apiUrls = this.apiurl + '/ChangeRequest/Getrequest'
    // try {
    //   const response: any = await this.http.get(apiUrls).toPromise();

    //   if (response) {
    this.emailCR = [this.crid]
    this.crrempid = this.emailCR[0].crrequestedBy
    this.croempid = this.emailCR[0].crowner
    this.crdate = this.emailCR[0].crdate
    this.crrdate = this.emailCR[0].crrequestedDt
    this.crdesc = this.emailCR[0].changeDesc
    this.plantid = this.emailCR[0].plantId
    this.EmailNotification = this.emailCR[0].crremailNotification;
    this.taskOwner = [this.crid]
    if (this.taskOwner.length > 0) {
      this.addtaskflag = true;
    }
    else {
      if (this.croempid == this.supportid) {
        this.addtaskflag = true;
      }
      else {
        this.addtaskflag = false;
      }
    }
    this.crrequestors();
    this.getcrinfo(this.croempid);

  }

  submitfor: boolean = true;
  completedstatus: any = '';
  implcompleted: any[] = [];
  totrecords: any = '';
  comprecords: any = '';
  value: any[] = [];
  getforwardedtoname: any;
  taskOwner: any[] = [];
  addtaskflag: boolean = false;

  getvalue() {
    const apiUrl = this.apiurl + '/Crexecute/GetExecute';
    this.http.get(apiUrl).subscribe(
      (response: any) => {
        this.value = response.filter((item: any) => item.itcrid === parseInt(this.crid.itcrid));
        this.totrecords = this.value.length
        this.implcompleted = response.filter((item: any) => item.itcrid === this.crid.itcrid && item.status == 'Completed');
        this.comprecords = this.implcompleted.length

        if ((Number(this.totrecords) == Number(this.comprecords)) && (Number(this.totrecords) != 0) && (!this.isImplemented))
          this.submitfor = true;
        else
          this.submitfor = false;
      },
      (error: any) => {
        alert('Request failed -' + error);
      });
  }

  crowner: any = '';
  submitby: any = '';

  async crrequestors() {
    try {
      await this.employeeInfo.empList();
      this.crrequestedby = this.allEmpList.filter((item: any) => parseInt(item.employeeId) === this.updatevalue[0]?.crrequestedBy);
      this.setcreniatorname = (this.crrequestedby[0].employeeId + "-" + this.crrequestedby[0].employeeName).trim();
      if (this.EmailNotification == true) {
        var sendCrEmail: any = this.crrequestedby[0].email;
      } else {
        var sendCrEmail: any = "";
      }
      this.crremail = sendCrEmail;
      this.crrequestedBy = this.crrequestedby[0].employeeName;
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  async getCrOwnerfromsupteam() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.crowner = this.supportteam.filter((item: any) => item.empId === this.updatevalue[0]?.crowner);
        this.submitby = this.crowner[0].firstName + " " + this.crowner[0].middleName + " " + this.crowner[0].lastName;
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  appr: any[] = []
  appemail: any = ''
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
  approver1Names: any = ''
  approver2Names: any = ''
  approver3Names: any = ''
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
  to: any = '';
  to1: any = '';
  to2: any = '';
  to3: any = '';
  cc1: any = '';
  cc2: any = '';
  cc3: any = '';
  cc4: any = '';
  cc5: any = '';
  crdateval: any = '';
  subjecttxt: any = '';
  populatedOutput: any = '';
  approverlevelstatus1: any = ''
  approverlevelstatus2: any = ''
  approverlevelstatus3: any = ''
  crrequestedby: any[] = [];
  setcreniatorname: any;

  sendemailfrom(emailreq: string, appv: any[]) {
    const apiUrl = this.apiurl + '/Email'
    this.approver11 = appv[0]?.approver1;
    this.approver11Name = appv[0]?.approver1Name;
    this.apprv11email = appv[0]?.approver1Email;
    if (appv[0]?.empid1 != '') {
      this.approver1Names = this.approver11Name + '(' + appv[0]?.empid1 + ')'
      this.approver1Emails = ', ' + this.apprv11email
    }
    else { this.approver11Name = '' }

    this.approver21 = appv[0]?.approver2
    this.approver21Name = appv[0]?.approver2Name;
    this.apprv21email = appv[0]?.approver2Email;

    if (appv[0]?.empid2 != '') {
      this.approver1Names += ", <br> "
      this.approver1Names += this.approver21Name + '(' + appv[0]?.empid2 + ')'
      this.approver1Emails += ", " + this.apprv21email
    }
    else { this.approver21Name = '' }

    this.approver31 = appv[0]?.approver3;
    this.approver31Name = appv[0]?.approver3Name;
    this.apprv31email = appv[0]?.approver3Email;
    if (appv[0]?.empid3 != '') {
      this.approver1Names += ', <br>' + this.approver31Name + '(' + appv[0]?.empid3 + ')'
      this.approver1Emails += ', ' + this.apprv31email
    }
    else { this.approver31Name = '' }
    //second Level
    this.approver12 = appv[1]?.approver1;
    this.approver12Name = appv[1]?.approver1Name;
    this.apprv12email = appv[1]?.approver1Email;
    if (appv[1]?.empid1 != '') {
      this.approver2Names = this.approver12Name + '(' + appv[1]?.empid1 + ')'
      this.approver2Emails += ', ' + this.apprv12email
    }
    this.approver22 = appv[1]?.approver2;
    this.approver22Name = appv[1]?.approver2Name;
    this.apprv22email = appv[1]?.approver2Email;
    if (appv[1]?.empid2 != '') {
      this.approver2Names += ', <br>' + this.approver22Name + '(' + appv[1]?.empid2 + ')'
      this.approver2Emails += ', ' + this.apprv22email
    }
    this.approver32 = appv[1]?.approver3;
    this.approver32Name = appv[1]?.approver3Name;
    this.apprv32email = appv[1]?.approver3Email;
    if (appv[1]?.empid3 != '') {
      this.approver2Names += ', <br>' + this.approver32Name + '(' + appv[1]?.empid3 + ')'
      this.approver2Emails += ', ' + this.apprv32email
    }
    else { this.approver32Name = '' }

    //Thrid Level
    this.approver13 = appv[2]?.approver1;
    this.approver13Name = appv[2]?.approver1Name;
    this.apprv13email = appv[2]?.approver1Email;
    if (appv[2]?.empid1 != '') {
      this.approver3Names = this.approver13Name + '(' + appv[2]?.empid1 + ')'
      this.approver3Emails += ', ' + this.apprv13email
    } else { this.approver13Name = '' }

    this.approver23 = appv[2]?.approver2;
    this.approver23Name = appv[2]?.approver2Name;
    this.apprv23email = appv[2]?.approver2Email;
    if (appv[2]?.empid2 != '') {
      this.approver3Names += ', <br>' + this.approver23Name + '(' + appv[2]?.empid2 + ')'
      this.approver3Emails += ', ' + this.apprv23email
    } else { this.approver23Name = '' }
    this.approver33 = appv[2]?.approver3;
    this.approver33Name = appv[2]?.approver3Name;
    this.apprv33email = appv[2]?.approver3Email;
    if (appv[2]?.empid3 != '') {
      this.approver3Names += ', <br>' + this.approver33Name + '(' + appv[2]?.empid3 + ')'
      this.approver3Emails += ', ' + this.apprv33email
    } else { this.approver33Name = '' }
    setTimeout(() => {

      this.to1 = this.approver1Emails
      //this.to2 = this.apprv21email
      //this.to3 = this.apprv31email
      this.cc1 = this.crremail
      this.cc2 = this.croemail
      this.cc3 = this.approver2Emails

      this.subjecttxt = `Unnati:IT Change Request:${this.crid.crcode} : Pending for Release Approval`
      const output = this.readHtmlFile('assets/email.html');

      this.populatedOutput = output
        .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.approver1Names)
        .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
        .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
        .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
        .replace('{{phase}}', 'Release')
        .replace('{{status}}', 'Pending for Release Approval')
        .replace('{{crapprover1}}', this.approver1Names)
        .replace('{{crapprover2}}', this.appv?.length == 2 ? this.approver2Names : 'NA')
        .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3Names : 'NA')
        .replace('${status}', 'Release')
        .replace('@Approval1Status', 'Pending')
        .replace('@Approval2Status', this.appv?.length == 2 ? 'Queued' : 'NA')
        .replace('@Approval3Status', this.appv?.length == 3 ? 'Queued' : 'NA')
        .replace('{{BodyContent}}', 'Please find the details of the Change Request Submitted by ' + [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
          .filter(Boolean)
          .join(' ') + ' and waiting for your Approval.')
        .replace('${loginUrl}', environment.loginurl)
        .replace('${loginUrl}', environment.loginurl)

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

      if (this.to1 == "" || this.to1 == null) {
        this.to1 = '';
      }
      if (To == "" || To == null) {
        if (this.to1 != '' || this.to1 != null) {
          To = ',' + '';
        } else {
          To = '';
        }
      }
      if (cc1pluscc1 == "" || cc1pluscc1 == null) {
        cc1pluscc1 = '';
      }

      const requestBody = {
        "to": (this.to1 + To).replace(/^,+|,+$/g, '').trim().replace(/\s+/g, ' '),
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
          console.log('Post request failed', error);
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


  templateName: any;

  predefindtask() {
    if (this.templateName == "") {
      alert("Enter Template Name")
    } else {
      const apiUrl = this.apiurl + '/CRTemplate/PostCRTemplate';
      const requestBody = {
        "flag": "I",
        "crTemplateID": 0,
        "templateName": this.templateName,
        "crid": this.crid.itcrid,
        "crTemplateDtlsID": 0,
        "supportID": this.crid.supportId,
        "sysLandscapeID": 1,
        "classificationID": this.crid.classificationId,
        "categoryID": this.crid.categoryId,
        "categoryTypID": this.crid.categoryTypeId,
        "taskName": "string",
        "taskDesc": "string",
        "priority": this.crid.priorityType,
        "isActive": true,
        "createdBy": this.crid.supportId,
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
            alert("Saved as predefined task");
            this.router.navigate(['/change-request']);
          }
        },
        (error: any) => {
          console.log('Post request failed', error);
        }
      );
    }
  }

  savepredefindtask() {
    const apiUrl = this.apiurl + '/CRTemplateExe/PostCRTemplateExe';
    const requestBody = {
      "flag": "I",
      "crTemplateID": Number(this.templateid),
      "crid": Number(this.crid.itcrid),
      "createdBy": Number(this.supportid),
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
          alert("Saved Template Successfully");
          this.router.navigate(['/change-request']);
        }
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
  }

  predefindtemplate: any[] = [];
  templatenames: any[] = [];
  emailofreciver: any;
  DisableSelectTemplate: boolean = false;
  getfilteredTemplates: any[] = [];
  predefinedList: any[] = [];
  filteredRows: any[] = [];

  /* getpredefinedtemplates() {
    const apiUrl = this.apiurl + '/CRTemplate/GetCRTemplate';

    this.http.get(apiUrl).subscribe(
      (response: any) => {
        this.templatenames = response.filter((item: any) =>
          item.categoryId == this.categoryId &&
          item.categoryTypId == this.categorytypeId
        );

        const templateWithLandScape = this.templatenames.filter((item: any) => this.getcheckedVlues.includes(item.sysLandscapeId.toString()));
        const templateWithoutLandScape = this.templatenames.filter((item: any) => !this.getcheckedVlues.includes(item.sysLandscapeId.toString()));
        console.log('templateWithLandScape', templateWithLandScape)
        console.log('templateWithoutLandScape', templateWithoutLandScape)
        if (templateWithLandScape.length != 0 && templateWithoutLandScape.length != 0) {
          let FilteredTemplates: any = templateWithLandScape.filter(x => {
            return !(templateWithoutLandScape.map((m: any) => { return m.crtemplateId }).indexOf(x.crtemplateId) != -1)
          })
          this.predefindtemplate = this.removeDuplicates(FilteredTemplates, 'crtemplateId');
        }
        else {
          this.predefindtemplate = [];
        }

        if (this.predefindtemplate.length == 0) {
          this.DisableSelectTemplate = true;
        } else {
          this.DisableSelectTemplate = false;
        }
      },
      (error: any) => {
        console.error('GET request failed', error);
      });
  } */

  getpredefinedtemplates() {
    const apiUrl = this.apiurl + '/CRTemplate/GetCRTemplate';

    this.http.get(apiUrl).subscribe(
      (response: any) => {
        console.log('response', response);
        console.log('this.crid.categoryId', this.crid.categoryId);
        console.log('this.crid.categoryTypeId', this.crid.categoryTypeId);

        this.templatenames = response.filter((item: any) =>
          item.categoryId == this.crid?.categoryId &&
          item.categoryTypId == this.crid?.categoryTypeId
        );

        console.log('this.templatenames', this.templatenames);

        const groupedTemplates = this.templatenames.reduce((acc: any, item: any) => {
          if (!acc[item.crtemplateId]) {
            acc[item.crtemplateId] = new Set();
          }
          acc[item.crtemplateId].add(item.sysLandscapeId);
          return acc;
        }, {});

        console.log('groupedTemplates', groupedTemplates);

        const checkedValuesSet = new Set(this.getcheckedVlues.map((id: any) => parseInt(id, 10)));

        console.log('checkedValuesSet', checkedValuesSet);

        const qualifyingTemplateIds = Object.keys(groupedTemplates).filter(crtemplateId => {
          const landscapeIdsSet = groupedTemplates[crtemplateId];

          return (
            checkedValuesSet.size === landscapeIdsSet.size &&
            [...checkedValuesSet].every(val => landscapeIdsSet.has(val))
          );
        });

        console.log('qualifyingTemplateIds', qualifyingTemplateIds);

        const filteringpredefindtemplate = this.templatenames.filter(item =>
          qualifyingTemplateIds.includes(item.crtemplateId.toString())
        );

        console.log('filteringpredefindtemplate', filteringpredefindtemplate);

        this.predefindtemplate = this.removeDuplicates(filteringpredefindtemplate, 'crtemplateId');

        console.log('this.predefindtemplate', this.predefindtemplate);

        if (this.predefindtemplate.length === 0) {
          this.DisableSelectTemplate = true;
        } else {
          this.DisableSelectTemplate = false;
        }
      },
      (error: any) => {
        console.error('GET request failed', error);
      }
    );
  }

  /*  getpredefinedtemplates() {
    const apiUrl = this.apiurl + '/CRTemplate/GetCRTemplate';
  
    this.http.get(apiUrl).subscribe(
      (response: any) => {
        console.log('response',response)
        console.log('this.crid.categoryId',this.crid.categoryId)
        console.log('this.crid.categoryTypeId', this.crid.categoryTypeId)
        this.templatenames = response.filter((item: any) =>
          item.categoryId == this.crid?.categoryId &&
          item.categoryTypId == this.crid?.categoryTypeId
        );
        console.log('this.templatenames',this.templatenames)
        const groupedTemplates = this.templatenames.reduce((acc: any, item: any) => {
          if (!acc[item.crtemplateId]) {
            acc[item.crtemplateId] = [];
          }
          acc[item.crtemplateId].push(item.sysLandscapeId);
          return acc;
        }, {});
        console.log('groupedTemplates',groupedTemplates)
        const checkedValuesSet = new Set(this.getcheckedVlues.map((id: any) => parseInt(id, 10)));
        console.log('checkedValuesSet',checkedValuesSet)
        const qualifyingTemplateIds = Object.keys(groupedTemplates).filter(crtemplateId => {
          const landscapeIds = groupedTemplates[crtemplateId].map((id: any) => parseInt(id, 10));
          const landscapeIdsSet = new Set(landscapeIds);
          return [...checkedValuesSet].every(val => landscapeIdsSet.has(val));
        });
        console.log('qualifyingTemplateIds',qualifyingTemplateIds)
        const filteringpredefindtemplate = this.templatenames.filter(item => qualifyingTemplateIds.includes(item.crtemplateId.toString()));
        console.log('filteringpredefindtemplate',filteringpredefindtemplate)
        this.predefindtemplate = this.removeDuplicates(filteringpredefindtemplate, 'crtemplateId');
        console.log('this.predefindtemplate',this.predefindtemplate)
        if (this.predefindtemplate.length == 0) {
            this.DisableSelectTemplate = true;
          } else {
            this.DisableSelectTemplate = false;
          }
      },
      (error: any) => {
        console.error('GET request failed', error);
      }
    );
  }
  */
  showtasktable: boolean = false;
  showpredefindtasks: any[] = [];
  showpredefindtask() {
    if (this.showpredefindtasks.length > 0) {
      alert('Cannot add template, as task exists for the change!')
    }
    else {
      this.showtasktable = true;
      this.showpredefindtasks = this.templatenames.filter((item: any) => item.crtemplateId === parseInt(this.templateid))
    }
  }

  removeDuplicates(array: any[], property: string): any[] {
    return array.filter((obj, index, self) =>
      index === self.findIndex((o) => (
        o[property] === obj[property]
      ))
    );
  }

  executethepart: any[] = []
  releaseforapprove: boolean = false;
  getreleaseforapprove() {

    const apiUrl = this.apiurl + '/Crexecute/GetExecute';
    const requestBody = {}
    this.http.get(apiUrl, requestBody).subscribe(
      (response: any) => {
        this.executethepart = response
        this.releaseforapprove = response.filter((item: any) => item.itcrid === this.crid.itcrid).every((row: any) => row.status?.trim() === 'Completed');
      },
      (error: any) => {
        console.error('POST request failed', error);
      });
  }


  nameinimplement: any[] = [];
  gettheusername: any;

  /*async getimplementname() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        for (var data in this.filteredData) {
          this.nameinimplement = this.supportteam.filter((item: any) => item.supportTeamId === 1);
        }
        this.nameinimplement = this.supportteam.filter((item: any) => item.supportTeamId === this.filteredData[0].forwardedTo);
        this.gettheusername = this.nameinimplement[0].supportTeamId + "-" + this.nameinimplement[0].firstName + " " + this.nameinimplement[0].lastName;
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }*/

  getsupportid: any;
  async getsupportteams() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.supportteams = this.supportteam.filter((row: any) => row.empId === parseInt(this.supportid.trim()));
        this.getsupportid = this.supportteams[0].supportTeamId;
        this.getsupportteamassign();
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  supportteamassign: any[] = [];
  isapprover: any;
  ischangeanalyst: any;
  issupportengineer: any;
  supportteamid: any;

  async getsupportteamassign() {
    const apiUrls = this.apiurl + '/SupportteamAssigned'

    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.supportteamassign = response.filter((row: any) => row.supportTeamId === parseInt(this.getsupportid));
        this.isapprover = this.supportteamassign[0].isApprover;
        this.issupportengineer = this.supportteamassign[0].isSupportEngineer;
        this.getcrdata()
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  isReleased: any;
  updatevalue: any;

  onclickassign() {
    this.getassigntome();
    this.assigintobutton();
  }

  assigntobutton: boolean = false;
  assigintobutton() {
    this.assigntobutton = true;
    this.implementbtn = false;
  }

  assingntome: any[] = [];
  getassigntome() {
    const apiUrl = this.apiurl + '/Crexecute/GetExecute';
    this.http.get(apiUrl).subscribe(
      (response: any) => {
        this.assingntome = response.filter((item: any) => item.itcrid === this.crid.itcrid && item.assignedtoid === parseInt(this.supportid));
      },
      (error: any) => {
        console.error('POST request failed', error);
      });

  }

  emplementtsk() {
    this.viewimplement();
    this.getexecutetask();
    this.getvalue();
  }

  implementbtn: boolean = false;
  viewimplement() {
    this.implementbtn = true
    this.assigntobutton = false
  }

  landscapeTasks: { [key: string]: any[] } = {};
  landscapeNames: { [key: string]: string } = {};
  executetaskbyid: any[] = [];
  getexecutetask() {
    const apiUrl = this.apiurl + '/Crexecute/GetExecute';
    const requestBody = {};

    this.http.get(apiUrl, requestBody).subscribe(
      (response: any) => {
        this.executetaskbyid = response.filter((item: any) => item.itcrid === this.crid.itcrid);
        this.landscapeTasks = {};
        this.landscapeNames = {};
        this.executetaskbyid.forEach((item: any) => {
          const landscape = item.sysLandscapeid;
          if (!this.landscapeTasks[landscape]) {
            this.landscapeTasks[landscape] = [];
            this.landscapeNames[landscape] = item.sylandscape;
          }
          this.landscapeTasks[landscape].push(item);
        });
      },
      (error: any) => {
        console.error('GET request failed', error);
      }
    );
  }

  executionhistory: any[] = [];
  getexecutionhistory() {
    const apiUrls = this.apiurl + '/ViewChangeHistory/GetCrExecutionPlanHistory?id=' + this.itcrid
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.executionhistory = response;
        this.executionhistory = this.executionhistory.sort((a, b) => {
          return new Date(a.crhistoryDt).getTime() - new Date(b.crhistoryDt).getTime();
        });
      },
      (error) => {
        console.error("Data fetching error", error)
      }
    )
  }

  deleteconfirmation: boolean = false;
  deleteitcrexecId: string = '';
  deletecategoryid: any;
  deleteRow(itcrexecId: any) {
    this.deleteitcrexecId = itcrexecId;
    this.deleteconfirmation = true
  }

  deleteyes() {
    this.deleteconfirmation = false
    this.deleteexeplan()
  }

  deleteno() {
    this.deleteconfirmation = false
  }

  deleteinprogress: boolean = false;
  deletesuccess: boolean = false;
  deletemessage: any = '';
  deleteinmessage: any = '';
  messageerror: boolean = false;
  errormessage: any;
  errorresponse: any;

  deleteexeplan() {

    const apiUrl = this.apiurl + '/Crexecute/executeplan'
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const requestBody = {
      "flag": "D",
      "itcrExecID": this.deleteitcrexecId,
      "itcrid": 0,
      "sysLandscape": 0,
      "executionStepName": "string",
      "executionStepDesc": "string",
      "assignedTo": 0,
      "startDt": "2024-05-27T13:04:04.576Z",
      "endDT": "2024-05-27T13:04:04.576Z",
      "attachments": "string",
      "status": "string",
      "forwardStatus": "string",
      "forwardedTo": 0,
      "forwardedDt": "2024-05-27T13:04:04.576Z",
      "reasonForwarded": "string",
      "remarks": "string",
      "pickedStatus": "string",
      "pickedDt": "2024-05-27T13:04:04.576Z",
      "actualStartDt": "2024-05-27T13:04:04.576Z",
      "actualEndDt": "2024-05-27T13:04:04.576Z",
      "dependSysLandscape": 0,
      "dependTaskId": 0,
      "createdBy": 0

    }
    setTimeout(() => {
      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
          this.errorresponse = response.type
          if (this.errorresponse == "E") {
            this.deleteinprogress = true;
            this.deleteinmessage = "There are open items it Can't be deleted"
          } else if (this.errorresponse == "S") {
            this.deletesuccess = true;
            this.deletemessage = "Deleted Task ID :" + this.deleteitcrexecId + " Successfully"
          }
        },
        (error: any) => {
          console.log('Post request failed', error);
          this.messageerror = true;
          this.errormessage = error;
        }
      );
    }, 500);
  }

  navigateinprogress() {
    this.deleteinprogress = false;
  }

  navigatesuccess() {
    this.deletesuccess = false;
    this.router.navigate(["/change-request"])
  }

}
