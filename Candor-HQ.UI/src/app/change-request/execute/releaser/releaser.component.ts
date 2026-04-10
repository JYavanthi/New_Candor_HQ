import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { PasscrdataService } from '../../passcrdata.service';
import { ActivatedRoute, Router } from '@angular/router';import { environment } from '@environments/environment';
import { GetEmployeeInfoService } from '../../../services/get-employee-info.service';
import { UserInfoSerService } from '../../../services/user-info-ser.service';
import { MatDialog } from '@angular/material/dialog';
import { HttpServiceService } from 'shared/services/http-service.service';
import { AddFilePopUpComponent } from '../../add-file-pop-up/add-file-pop-up.component';

@Component({
  selector: 'app-releaser',
  templateUrl: './releaser.component.html',
  styleUrl: './releaser.component.css'
})
export class ReleaserComponent implements OnChanges {

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
  @Input() crData1: any
  today: any;
  currentdate: any;
  itcrid: any;
  appstatus: any;
  supportid: any;
  stage: any;
  isRelease: any = '';
  appflag: boolean = false;
  APILevel: Number = 1;
  rfcapproverlevel: string = '';
  isApproved: any;
  isReleased: any;
  categoryId: any = '';
  selectedOption: string = '';
  classificationId: any = '';
  approveflag: boolean = true;
  isSupport: boolean = true;
  supportname: any;
  crownername: any;
  getcrid: any[] = [];
  allEmpList: any[] = [];
  getcrcode: string = '';
  plantidforapp: any = ' ';
  date: any = ' ';
  currentday: any = ' ';
  EmailNotification: boolean = false;
  user: any;
  attachmentsList: any = [];
  MAX_FILE_SIZE = 1024 * 1024 * 5

  constructor(private http: HttpClient, private employeeInfo: GetEmployeeInfoService,
    private userinfoSer: UserInfoSerService, private router: Router, private httpSer: HttpServiceService,
    private routeservice: PasscrdataService, private route: ActivatedRoute, private dialog: MatDialog) {

    // this.routeservice.crdata.subscribe(data => {

    // this.crid = data.report.value;
    this.user = userinfoSer.getUser();
    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });

    this.employeeInfo.suppTeamList().then(() => {
      this.supportteam = this.employeeInfo.SupportTeamList;
    });

    this.itcrid = this.route.snapshot.paramMap.get('id');
    if (this.crid) {

      this.appstatus = this.crid?.status.trim();
      this.status = this.crid?.status.trim();
      this.stage = this.crid?.stage.trim();
      this.crownername = this.crid?.crowner;
      this.isApproved = this.crid?.isApproved;
      this.isReleased = this.crid?.isReleased;
      this.categoryId = this.crid?.categoryId;
      this.classificationId = this.crid?.classificationId;
      this.plantidforapp = this.crid?.plantId;
      this.getcrcode = this.crid?.crcode;
    }

    // })

    this.Approver(1);
    this.Approver1();
    this.getsupportteams();
    this.routeservice.getsupportteam();
    // this.supportid = this.routeservice.supporterID;
    this.supportid = this.user?.empData?.employeeNo
    this.supportname = this.user?.empData?.firstName;

    const currentDate = new Date()
    const datePart = currentDate.toISOString().slice(0, 10);
    const timePart = currentDate.getHours().toString().padStart(2, '0') + ':' +
      currentDate.getMinutes().toString().padStart(2, '0') + ':' +
      currentDate.getSeconds().toString().padStart(2, '0');
    this.date = `${datePart} ${timePart}`;
    this.currentday = `${datePart} ${timePart}`;
    this.today = currentDate.toISOString().slice(0, 10);
    this.currentdate = currentDate.toISOString().slice(0, 10);
    // this.routeservice.crdata.subscribe(data => {

    this.getData();
  }

  tab1: boolean = true;
  showfunction() {
    this.supportid == 2;
    if (this.supportid == 2) {
      this.tab1 = true;
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['crData1']) {
      if (!this.crData1) {
        return
      }
      if (!this.crid) {
        return
      }
      this.Approver1();
      this.appstatus = this.crid.status.trim();
      this.status = this.crid.status.trim();
      this.stage = this.crid.stage.trim();
      this.crownername = this.crid.crowner;
      this.isApproved = this.crid.isApproved;
      this.isReleased = this.crid.isReleased;
      this.getcrcode = this.crid.crcode;
      this.categoryId = this.crid.categoryId;
      this.classificationId = this.crid.classificationId;
      this.plantidforapp = this.crid.plantId;

      this.getrequetervalue(this.crid?.itcrid);
      this.getidupdate();
      this.getapprovestatus();
      this.getapprdtls(1);
      this.getapproverslevel();
      this.usersupportteams();
      this.getreleasedata();
      this.GetApprover(1);
      this.getData();
      if (this.supportid == this.crid?.crowner) {
        this.ischangeowner = true
      }
    }
  }

  seekClarification(status: any) {
    this.attachfile = this.selectedFiles.name;
    if (this.attachfile == undefined) {
      this.attachfile = '';
    }
    if (this.remark.trim() == '') {
      alert('Enter Remarks for RFC ')
    }
    else {
      const apiUrl = this.apiurl + '/CRapprove/Approve';
      const requestBody = {
        "Flag": "I",
        "CRApproverID": 1,
        "PlantID": this.crid?.plantId,
        "SupportID": 1,
        "CRID": this.crid?.itcrid,
        "approverLevel": Number(this.APILevel),
        "Stage": "R",
        "ApproverID": Number(this.supportid),
        "ApprovedDt": this.today,
        "Remarks": this.remark,
        "Comments": this.comment,
        "Status": status,
        "Attachment": this.attachfile,
        "CreatedBy": Number(this.supportid),
        "CreatedDt": this.currentdate,
        "ModifiedBy": Number(this.supportid),
        "ModifiedDt": this.currentdate,
        "sendemailfrom": this.sendemailfrom
      }
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };

      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
          if (status == 'Seek Clarification') {
            alert("RFC Code" + " " + this.crid?.crcode + " " + ": Needs Clarification");
          }
          else {
            alert("RFC Code" + " " + this.crid?.crcode + " " + ": is Rejected");
          }
          setTimeout(() => {
            this.emailapproversinfo(status);
          }, 1000)
          this.router.navigate(['/change-request']);
        },
        (error: any) => {
          alert("POST request failed");
        });
    }
  }
  ImplementedStatus() {
    if (this.stage == "Implementation") {
      if (this.appstatus == "Implemented") {
        this.Approver1();
        if (this.approverCount == 2) {
          this.Approver2();
        }
        if (this.approverCount == 3) {
          this.Approver2();
          this.Approver3();
        }
      }
    }
  }

  StageStatus() {
    if (this.isReleased) {
      this.Approver1();

      if (this.approverCount == 2) {
        this.Approver2();
      }

      if (this.approverCount == 3) {
        this.Approver2();
        this.Approver3();
      }
    }
    if (this.appstatus == "Implemented") {

      this.Approver1();

      if (this.approverCount == 2) {
        this.Approver2();
      }

      if (this.approverCount == 3) {
        this.Approver2();
        this.Approver3();
      }
    }

    if (this.stage == "Release") {
      if (this.appstatus == "Approved") {
        this.Approver1();

        if (this.approverCount == 2) {
          this.Approver2();
        }

        if (this.approverCount == 3) {
          this.Approver2();
          this.Approver3();
        }
      }
      if (this.appstatus == "Approved level1") {
        this.Approver1();
        this.Approver2();

        if (this.approverCount == 3) {
          this.Approver3();
        }
      }

      if (this.appstatus == "Approved level2") {
        this.Approver1();
        this.Approver2();
        this.Approver3();
      }
    }
  }


  selectedTab: number = 0;
  count: any;
  // Method to show the selected tab
  showTab(index: number) {
    this.selectedTab = index;
  }

  approver1Name: String = '';
  approver2Name: String = '';
  approver3Name: String = '';

  ngOnInit(): void {
    this.getidupdate();
    this.getapprovestatus();
    this.getapprdtls(1);
    this.getapproverslevel();
    this.usersupportteams();
    this.getFileData();
    this.getreleasedata();
    setTimeout(() => {
      this.GetApprover(1);
    }, 1000);


  }
  private apiurl = environment.apiurls;

  handleFileInput(event: any, index: number) {
    const file = event.target.files[0];
    this.plantData[index].attachment = file;
  }
  activetab(tabval: any) {
    if (tabval == 'R' && this.isApproved) {
      alert("Please complete approval to release.");
      //this.release1tab.active=false;
    }
  }
  getidupdate() {
    this.itcrid = this.route.snapshot.paramMap.get('id');
  }

  approverdata: any[] = [];
  data = 2;
  approvers: any[] = [];


  initializeApprovers() {

  }

  counter(i: number) {
    return new Array(i);
  }


  activeTab: number = 1; // Default to the first tab being active

  supportpersonname: any = ''
  firstname: any = ''
  middlename: any = ''
  lastname: any = ''
  employeeid: any = ''

  supportteams: any[] = []
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
  croname: any = '';
  crrempid: any = '';
  croempid: any = '';
  crempid: any = '';
  cremail: any = '';
  ischangeowner: boolean = false

  async getcrinfo(empid: Number) {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.crval = this.supportteam.filter(item => item.empId === empid)
        this.croname = this.crval[0].firstName + " " + this.crval[0].middleName + " " + this.crval[0].lastName;
        this.croemail = this.crval[0].email
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  releaseval: any[] = [];
  releasecmts: any = '';
  releasedt: any = '';
  attachmentfile: any = '';

  async getreleasedata() {
    const apiUrls = this.apiurl + '/CRrelease/GetRelease';
    try {
      const response: any = await this.http.get(apiUrls).toPromise();
      if (response) {
        this.releaseval = response.filter((item: any) => item.itcrid === Number(this.crid?.itcrid))
        if (this.releaseval.length > 0) {
          this.releasecmts = this.releaseval[0].releaseComments
          this.releasedt = this.releaseval[0].releasedt
          this.attachmentfile = this.releaseval[0].attachments?.trim();
          this.releaseComments = this.releaseval[0].releaseComments
        }
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  croemailid: any = ''
  crdate: any = ''
  crrdate: any = ''
  crdesc: any = ''
  emailCR: any[] = []

  async getcrdata() {
    this.emailCR = [this.crid]
    this.crrempid = this.emailCR[0].crrequestedBy
    this.croempid = this.emailCR[0].crowner
    this.crdate = this.emailCR[0].crdate
    this.crrdate = this.emailCR[0].crrequestedDt
    this.crdesc = this.emailCR[0].changeDesc
    this.plantid = this.emailCR[0].plantId
    this.EmailNotification = this.emailCR[0].crremailNotification;
    this.crrequestors();
    this.getcrinfo(this.croempid);

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

  emailapproversinfo(status: string): Promise<any> {
    const apiUrl = this.apiurl + '/GetApproverforEmail/GetApproverEmail';
    const requestBody = {
      "stage": "R",
      "plantid": Number(this.crid?.plantId),
      "categoryId": Number(this.crid?.categoryId),
      "classificationId": Number(this.crid?.classificationId)
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
        if (status == 'Released') {
          this.closureemailapproversinfo();
        }
      })
      .catch((error: any) => {
        throw error;
      });
  }

  closureappv: any[] = [];
  closureemailapproversinfo(): Promise<any> {
    const apiUrl = this.apiurl + '/GetApproverforEmail/GetApproverEmail';
    const requestBody = {
      "stage": "C",
      "plantid": Number(this.crid?.plantId),
      "categoryId": Number(this.crid?.categoryId),
      "classificationId": Number(this.crid?.classificationId)
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.http.post(apiUrl, requestBody, httpOptions).toPromise()
      .then((response: any) => {
        this.closureappv = response;
        this.sendemailfrom('Closure', this.closureappv);
      })
      .catch((error: any) => {
        throw error;
      });
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
  approverlevelstatus1: any = ''
  approverlevelstatus2: any = ''
  approverlevelstatus3: any = ''
  subjecttxt: any = '';
  populatedOutput: any = '';
  crowner: any = '';
  submitby: any = '';
  crrequestedby: any[] = [];
  setcreniatorname: any;
  approver1NamesR: any = '';
  approver2NamesR: any = '';
  approver3NamesR: any = '';
  appname: any = '';

  async crrequestors() {
    try {
      await this.employeeInfo.empList();
      this.crrequestedby = this.allEmpList.filter((item: any) => parseInt(item.employeeId) == this.updatevalue[0]?.crrequestedBy);
      this.setcreniatorname = (this.crrequestedby[0].employeeId + "-" + this.crrequestedby[0].employeeName).trim();
      this.crrname = this.crrequestedby[0].employeeName;
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

  sendemailfrom(emailreq: string, appv: any[]) {
    const apiUrl = this.apiurl + '/Email'
    this.approver11 = appv[0]?.approver1;
    this.approver11Name = appv[0]?.approver1Name;
    this.apprv11email = appv[0]?.approver1Email;
    if (appv[0]?.empid1 != '' && appv[0]?.empid1 != undefined) {
      this.approver1Names = this.approver11Name + '(' + appv[0]?.empid1 + ')'
      this.approver1Emails = ', ' + this.apprv11email
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

    //Thrid Level
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
      this.approver1N = appv[0]?.approver1Name;
      this.approver2N = appv[0]?.approver2Name;
      this.approver3N = appv[0]?.approver3Name;

      //alert('crremail' + this.crremail + 'cro email' + this.croemail)
      if (emailreq == "Approved Level1") {
        this.to1 = this.approver1Emails
        //this.to2 = this.apprv21email
        //this.to3 = this.apprv31email
        this.cc1 = this.crremail
        this.cc2 = this.croemail
        this.cc3 = this.approver2Emails
        if (this.approver1Names == '') {
          this.approver1Names = 'No Approvers'
          this.approverlevelstatus1 = 'Not Applicable'
        }
        else {
          this.approverlevelstatus1 = 'Approved'
        }

        if (this.approver2Names == '') {
          this.approver2Names = 'No Approvers'
          this.approverlevelstatus2 = 'Not Applicable'
        }
        else {
          this.approverlevelstatus2 = 'Pending'
        }
        if (this.approver3Names == '') {
          this.approver3Names = 'No Approvers'
          this.approverlevelstatus3 = 'Not Applicable'
        }
        else {
          this.approverlevelstatus3 = 'Queued'
        }
        const requestdate = this.crdate
        this.subjecttxt = `Unnati:IT Change Request:${this.crid.crcode} : Release Approved Level 1`
        const output = this.readHtmlFile('assets/approvalemail.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.approver1Names)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'Release Submitted for Approval Level 1')
          .replace('{{crid}}', this.crData1?.crcode)
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.appv?.length >= 2 ? this.approver2Names : 'NA')
          .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3Names : 'NA')
          .replace('{{phase}}', 'Release Approval')
          .replace('{{status}}', 'Release Approval Level1')
          .replace('@Approval1Status', this.approverlevelstatus1)
          .replace('@Approval2Status', this.appv?.length >= 2 ? this.approverlevelstatus2 : 'NA')
          .replace('@Approval3Status', this.appv?.length == 3 ? this.approverlevelstatus3 : 'NA')
          .replace('{{approvedby}}',
            [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
              .filter(Boolean)
              .join(' ')
          )
      }

      else if (emailreq == "Approved Level2") {
        this.to1 = this.approver2Emails
        this.cc1 = this.crremail
        this.cc2 = this.croemail
        this.cc3 = this.approver3Emails
        if (this.approver1Names == '') {
          this.approver1Names = 'No Approvers'
          this.approverlevelstatus1 = 'Not Applicable'
        }
        else {
          this.approverlevelstatus1 = 'Approved'
        }

        if (this.approver2Names == '') {
          this.approver2Names = 'No Approvers'
          this.approverlevelstatus2 = 'Not Applicable'
        }
        else {
          this.approverlevelstatus2 = 'Approved'
        }
        if (this.approver3Names == '') {
          this.approver3Names = 'No Approvers'
          this.approverlevelstatus3 = 'Not Applicable'
        }
        else {
          this.approverlevelstatus3 = 'Pending'
        }
        const requestdate = this.crdate
        const changeDesc = this.crdesc
        this.subjecttxt = `Unnati:IT Change Request:${this.crid.crcode} : Release Approved Level 2`
        const output = this.readHtmlFile('assets/approvalemail.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.approver2Names)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'Release Submitted for Approval Level 2')
          .replace('{{crid}}', this.crData1?.crcode)
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.appv?.length >= 2 ? this.approver2Names : 'NA')
          .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3Names : 'NA')
          .replace('{{phase}}', 'Release Approval')
          .replace('{{status}}', 'Release Approval Level2')
          .replace('@Approval1Status', this.approverlevelstatus1)
          .replace('@Approval2Status', this.appv?.length >= 2 ? this.approverlevelstatus2 : 'NA')
          .replace('@Approval3Status', this.appv?.length == 3 ? this.approverlevelstatus3 : 'NA')
          .replace('{{approvedby}}', [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
            .filter(Boolean)
            .join(' ')
          );
      }

      else if ((emailreq == "Approved")) {

        if (this.approver1Names == '') {
          this.approver1Names = 'No Approvers'
          this.approverlevelstatus1 = 'Not Applicable'
        }
        else {
          this.approver1NamesR = this.approver1Names
          this.approverlevelstatus1 = 'Approved'
        }

        if (this.approver2Names == '') {
          this.approver2Names = 'No Approvers'
          this.approverlevelstatus2 = 'Not Applicable'
        }
        else {
          this.approver2NamesR = this.approver2Names
          this.approverlevelstatus2 = 'Approved'
        }
        if (this.approver3Names == '') {
          this.approver3Names = 'No Approvers'
          this.approverlevelstatus3 = 'Not Applicable'
        }
        else {
          this.approver3NamesR = this.approver3Names
          this.approverlevelstatus3 = 'Approved'
        }

        //this.to1 = this.approver3Emails
        this.to1 = this.appv?.length == 3 ? this.approver3Emails : this.appv?.length == 2 ? this.approver2Emails : this.approver1Emails
        //this.to2 = this.apprv23email
        //this.to3 = this.apprv33email
        this.cc1 = this.croemail
        this.cc2 = this.crremail
        // this.cc3 = this.approver1Emails

        const requestdate = this.crdate
        const changeDesc = this.crdesc
        this.subjecttxt = `Unnati:IT Change Request:${this.crid.crcode} : Release Approved`
        const output = this.readHtmlFile('assets/approvalemail.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.appv?.length == 3 ? this.approver3Names : this.appv?.length >= 2 ? this.approver2Names : this.approver1Names)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'Release Approved')
          .replace('{{crid}}', this.crData1?.crcode)
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.appv?.length >= 2 ? this.approver2Names : 'NA')
          .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3Names : 'NA')
          .replace('{{phase}}', 'Release Approval')
          .replace('{{status}}', 'Release Approved')
          .replace('@Approval1Status', this.approverlevelstatus1)
          .replace('@Approval2Status', this.appv?.length >= 2 ? this.approverlevelstatus2 : 'NA')
          .replace('@Approval3Status', this.appv?.length == 3 ? this.approverlevelstatus3 : 'NA')
          .replace('{{approvedby}}', [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
            .filter(Boolean)
            .join(' '));
      }
      else if ((emailreq == "Released")) {

        this.crdesc += "<br><br><b> Release Remarks : </b>" + this.releaseComments

        this.to1 = this.crremail
        this.to2 = this.croemail
        this.cc1 = this.croemail

        this.subjecttxt = `Unnati:IT Change Request:${this.crid.crcode} : Released`
        const output = this.readHtmlFile('assets/email.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrname)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crownername)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'Release Approved')
          .replace('{{crid}}', this.crData1?.crcode)
          .replace('{{crapprover1}}', this.approver1NamesR)
          .replace('{{crapprover2}}', this.appv?.length >= 2 ? this.approver2NamesR : 'NA')
          .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3NamesR : 'NA')
          .replace('{{phase}}', 'Release ')
          .replace('{{status}}', 'Released')
          .replace('@Approval1Status', 'Approved')
          .replace('@Approval2Status', this.appv?.length >= 2 ? 'Approved' : 'NA')
          .replace('@Approval3Status', this.appv?.length == 3 ? 'Approved' : 'NA')
          .replace('{{BodyContent}}', 'Please find the details of the Change Request Submitted by ' + [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
            .filter(Boolean)
            .join(' ') + ' and waiting for your Approval.')
          .replace('{{approvedby}}', [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
            .filter(Boolean)
            .join(' '));
      }
      else if (emailreq == "Reject") {
        this.cc1 = this.croemail
        this.cc2 = this.crremail
        if (this.status == 'Approved') {
          this.appname = this.approver3Names
          this.to1 = this.appv?.length == 3 ? this.approver3Emails : this.appv?.length == 2 ? this.approver2Emails : this.approver1Emails.trim()
          this.approverlevelstatus1 = 'Approved'
          this.approverlevelstatus2 = 'Approved'
          this.approverlevelstatus3 = 'Rejected'

        } else if (this.status == 'Approved Level2') {
          this.appname = this.approver2Names
          this.to1 = this.approver2Emails
          this.cc3 = this.approver3Emails
          this.approverlevelstatus1 = 'Approved'
          this.approverlevelstatus2 = 'Rejected'
          this.approverlevelstatus3 = 'Not Required'
        } else if (this.status == 'Approved Level1') {
          this.appname = this.approver1Names
          this.to1 = this.approver1Emails
          this.cc3 = this.approver2Emails

          this.approverlevelstatus1 = 'Rejected'
          this.approverlevelstatus2 = 'Not Required'
          this.approverlevelstatus3 = 'Not Required'

        } else {
          this.appname = this.approver1Names
          this.to1 = this.approver1Emails
          this.cc3 = this.approver2Emails

          this.approverlevelstatus1 = 'Rejected'
          this.approverlevelstatus2 = 'Not Required'
          this.approverlevelstatus3 = 'Not Required'
        }

        if (this.approver1Names == '') {
          this.approver1Names = 'No Approvers'
          this.approverlevelstatus1 = 'Not Applicable'
        }

        if (this.approver2Names == '') {
          this.approver2Names = 'No Approvers'
          this.approverlevelstatus2 = 'Not Applicable'
        }

        if (this.approver3Names == '') {
          this.approver3Names = 'No Approvers'
          this.approverlevelstatus3 = 'Not Applicable'
        }


        this.subjecttxt = `Unnati:IT Change Request:${this.crid.crcode} : Release Approve Rejected`
        const output = this.readHtmlFile('assets/rejection.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.appname)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'Release Approve Rejected')
          .replace('{{phase}}', 'Release Approve Approval')
          .replace('{{status}}', 'Release Approve Rejected')
          .replace('{{crid}}', this.crData1?.crcode)
          .replace('{{setstatus}}', 'Rejected')
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.appv?.length >= 2 ? this.approver2Names : 'NA')
          .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3Names : 'NA')
          .replace('@Approval1Status', this.approverlevelstatus1)
          .replace('@Approval2Status', this.appv?.length >= 2 ? this.approverlevelstatus2 : 'NA')
          .replace('@Approval3Status', this.appv?.length == 3 ? this.approverlevelstatus3 : 'NA')
          .replace('{{approvedby}}', [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
            .filter(Boolean)
            .join(' '));

      }
      else if ((emailreq == "Closure")) {

        this.to1 = this.approver1Emails
        this.cc1 = this.crremail
        this.cc2 = this.croemail


        const requestdate = this.crdate
        const changeDesc = this.crdesc
        this.subjecttxt = `Unnati:IT Change Request:${this.crid.crcode} : Pending Closure Approval`
        const output = this.readHtmlFile('assets/approvalemail.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrname)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crownername)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'Pending Closure Approval')
          .replace('{{crid}}', this.crData1?.crcode)
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.appv?.length >= 2 ? this.approver2Names : 'NA')
          .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3Names : 'NA')
          .replace('{{phase}}', 'Release ')
          .replace('{{status}}', 'Pending Closure Approval')
          .replace('@Approval1Status', 'Pending')
          .replace('@Approval2Status', this.appv?.length >= 2 ? 'Queued' : 'NA')
          .replace('@Approval3Status', this.appv?.length == 3 ? 'Queued' : 'NA')
          .replace('{{BodyContent}}', 'Please find the details of the Change Request Submitted by ' + [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
            .filter(Boolean)
            .join(' ') + ' and waiting for your Approval.')
          .replace('{{approvedby}}', [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
            .filter(Boolean)
            .join(' '))
          .replace('${loginUrl}', environment.loginurl)
          .replace('${loginUrl}', environment.loginurl)
      }
      if (this.to2 != '' && this.to3 != '') {
        var To = ',' + this.to2 + ',' + this.to3;
      } else if (this.to2 != '' && this.to3 == '') {
        var To = ',' + this.to2;
      } else if (this.to2 == '' && this.to3 != '') {
        var To = ',' + this.to3;
      }
      else {
        var To = '';
      }
      //cc
      if (this.cc2 != '' && this.cc3 != '') {
        var cc = ',' + this.cc2 + ',' + this.cc3;
      }
      else if (this.cc2 != '' && this.cc3 == '') {
        var cc = ',' + this.cc2;
      }
      else if (this.cc2 == '' && this.cc3 != '') {
        var cc = ',' + this.cc3;
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
        "cc": cc1pluscc1.replace(/^,+|,+$/g, '').trim().replace(/\s+/g, ' '),
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
      return ''; // or handle error accordingly
    }
  }

  // Function to activate a tab
  activateTab(tabNumber: number) {
    this.activeTab = tabNumber;
  }

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
        this.router.navigate(['/change-request']);
      }
    })
  }

  onFileSelected(event: any): void {
    this.selectedFiles = event.target.files[0];
  }

  filestg : string;
  addFile(): void {

    if (!this.selectedFiles) {
      console.error('No files selected.');
      return;
    }
    if (this.selectedFiles.size > this.MAX_FILE_SIZE) {
      alert('File size must not exceed 5 MB.')
      return
    }
    
    switch (this.APILevel) {
      case 1:
        this.filestg = 'R1';
        break;
      case 2:
        this.filestg = 'R2';
        break;
      case 3:
        this.filestg = 'R3';
        break;
      default:
        this.filestg = 'R1';
    }
    if(this.status==="Approved" && this.stage==="Release") this.filestg = 'R';
    const formData = new FormData();
    formData.append('itcrid', this.crid.itcrid);
    formData.append('file', this.selectedFiles, this.selectedFiles.name);
    formData.append('FileName', this.selectedFiles.name);
    formData.append('Stage', this.filestg);
    formData.append('CreatedBy', this.user?.empData?.employeeNo);
    formData.append('ModifiedBy', this.user?.empData?.employeeNo);

    const apiUrl = this.apiurl + '/ChangeRequest/addFile';

    this.http.post(apiUrl, formData).subscribe(
      (response: any) => {
        this.attachmentsList.push({
          attachId: response?.attachId,
          attachedFile: this.selectedFiles?.name,
          file: this.selectedFiles,
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
    
    switch (this.APILevel) {
      case 1:
        this.filestg = 'R1';
        break;
      case 2:
        this.filestg = 'R2';
        break;
      case 3:
        this.filestg = 'R3';
        break;
      default:
        this.filestg = 'R1';
    }

    if((this.status==="Approved" && this.stage==="Release") || (this.isReleased)) this.filestg = 'R';
    
    let param = {
      itcrid: this.itcrid
    }
    this.httpSer.httpGet(url, param).subscribe(res => {
      this.attachmentsList = res 
      this.attachmentsList = this.attachmentsList.filter((m: any) => m.stage === this.filestg)
    })
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
 
  deleteDoc(fileName: any) {
    let url = `/ChangeRequest/Delete/${fileName.attachId}`
    this.httpSer.httpDelete(url).subscribe(res => {
      this.attachmentsList = this.attachmentsList.filter((m: any) => fileName.attachId != m.attachId)
    })
  }

  approverValues: string[] = [];
  remarkValues: string[] = [];
  value: any;
  attachfile: any='';

  getdata(statu: any) {
    if(this.remark==''){
      alert('Enter Remarks');
      return;
    }

    // this.attachfile = this.selectedFiles.name;
    // if (this.attachfile == undefined) {
    //   this.attachfile = '';
    // }

    if (Number(this.APILevel) == 1) {
      if (Number(this.approverCount) <= 1) {
        this.status = "Approved"
      }
      else {
        this.status = "Approved Level1"
      }
    }
    else if (Number(this.APILevel) == 2) {
      if (Number(this.approverCount) <= 2) {
        this.status = "Approved"
      }
      else {
        this.status = "Approved Level2"
      }
    }
    else {
      this.status = "Approved"
    }

    const apiUrl = this.apiurl + '/CRapprove/Approve';
    const requestBody = {

      "Flag": "I",
      "CRApproverID": 1,
      "PlantID": this.crid.plantId,
      "SupportID": 1,
      "CRID": this.crid.itcrid,
      "ApproverLevel": this.APILevel,
      "Stage": "R",
      "ApproverID": this.supportid,
      "ApprovedDt": this.today,
      "Remarks": this.remark,
      "Comments": this.comment,
      "Status": this.status,
      "Attachment": this.attachfile,
      "CreatedBy": this.supportid,
      "CreatedDt": this.currentdate,
      "ModifiedBy": this.supportid,
      "ModifiedDt": this.currentdate,
      "sendemailfrom": this.sendemailfrom
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
          alert("RFC Code" + this.crid.crcode + " " + "" + " " + "Released " + " " + this.status);
          this.addFile();
          this.emailapproversinfo(this.status);
          this.router.navigate(['/change-request']);
        }
      });
  }
  

  rejectbutton(status: any) {
    this.attachfile = this.selectedFiles.name;
    
    if (this.attachfile == undefined) {
      this.attachfile = '';
    }
    if (this.remark == '') {
      alert('Enter release remarks')
    }
    else {
      const apiUrl = this.apiurl + '/CRapprove/Approve';
      const requestBody = {
        "Flag": "I",
        "CRApproverID": 1,
        "PlantID": this.crid.plantId,
        "approverLevel": this.APILevel,
        "SupportID": 1,
        "CRID": this.crid.itcrid,
        "Stage": status == 'Seek Clarification' ? 'R' : '',
        "ApproverID": Number(this.supportid),
        "ApprovedDt": this.today,
        "Remarks": this.remark,
        "Comments": this.comment,
        "Status": status,
        "Attachment": this.attachfile,
        "CreatedBy": Number(this.supportid),
        "CreatedDt": this.currentdate,
        "ModifiedBy": Number(this.supportid),
        "ModifiedDt": this.currentdate,
        "sendemailfrom": this.sendemailfrom
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
            alert("RFC Code" + " " + this.crid.crcode + " " + (('Seek Clarification' == status) ? ":Release Approver is Seeking Clarification." : ": RFC is Rejected at" + " " + this.status));
            this.addFile();
            this.emailapproversinfo(status);
            this.router.navigate(['/change-request']);
          }
        },
        (error: any) => {
          alert("POST request failed");
        });


    }
  }

  isapprover: any[] = [];
  getapprovestatus() {
    const apiUrl = this.apiurl + '/SupportteamAssigned';
    this.http.get(apiUrl).subscribe(
      (response: any) => {
        //this.isapprover = response.filter((item: any) => item.itcrid === this.crid.itcrid);
        this.isapprover = response.filter((item: any) => parseInt(item.supportTeamId) == parseInt(this.getsupportid));
      },
      (error: any) => {
        console.error('POST request failed', error);
      });
  }

  supportteam: any[] = [];
  getsupportid: any;

  async getsupportteams() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        const suppteams = this.supportteam.filter((row: any) => row.empId === parseInt(this.supportid.trim()));
        this.getsupportid = suppteams[0].supportTeamId;
        this.getsupportteamassign(this.getsupportid);
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  supportteamassign: any[] = [];
  isapprovers: any = 0;
  issupportegineer: any = 0;
  ischangeanalyst: any = 0;

  getsupportteamassign(getsupportid: Number) {
    const apiUrls = this.apiurl + '/SupportteamAssigned'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.supportteamassign = response.filter((row: any) => row.supportTeamId == getsupportid);
        this.isapprovers = this.supportteamassign[0].isApprover
        this.ischangeanalyst = this.supportteamassign[0].isChangeAnalyst
        this.issupportegineer = this.supportteamassign[0].isSupportEngineer
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  updatevalue: any;
  valuereq: any = '';
  isapproved: any;
  changerequest: any = '';

  getrequetervalue(itcrid: any) {
    // const apiUrls: any = this.apiurl + '/ChangeRequest/Getrequest';
    // return this.http.get(apiUrls).toPromise()
    //   .then((response: any) => {
    // this.valuereq = response;
    this.updatevalue = [this.crid];
    this.isapproved = this.updatevalue[0]?.isApproved
    this.crdesc = this.updatevalue[0]?.changeDesc;
    const changerequstorname = this.updatevalue[0]?.crrequestedBy;
    this.getupdatyevalue();
    this.getcrdata();
    this.getCrOwnerfromsupteam();
    // })
    // .catch((error: any) => {
    //   throw error;
    // });
  }



  getupdatyevalue() {
    // const apiUrls: any = this.apiurl + '/ChangeRequest/Getrequest';
    // this.http.get(apiUrls).subscribe(
    //   (response: any) => {
    // this.changerequest = response.filter((item: any) => item.itcrid.toString() === this.crid.itcrid);
    this.changerequest = [this.crid]
    this.isapproved = this.updatevalue[0]?.isApproved
    //   },
    //   (error: any) => {
    //     console.log('Post request failed', error);
    //   }
    // );
  }


  approvervalue: any = '';
  approverCount: any = '';
  supportapp1: any; supportapp2: any; supportapp3: any; supportapp: any;
  supportapp1ID: any; supportapp2ID: any; supportapp3ID: any;
  appvflg: boolean = false;

  async GetApprover(index: Number) {
    if (!this.crid) {
      return
    }
    const apiUrl = this.apiurl + '/GetApproval/GetApprover';
    const requestBody = {
      "level": Number(index),
      "stage": "R",
      "plantid": Number(this.crid?.plantId),
      "categoryId": Number(this.crid?.categoryId),
      "classificationId": Number(this.crid?.classificationId)
    }

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    try {
      const response: any = await this.http.post(apiUrl, requestBody, httpOptions).toPromise();

      if (response) {
        this.appvflg = false;
        this.approverCount = (response[0].approverCount);
        this.approvervalue = response;
        this.supportapp = "Select Approver"

        if (this.approvervalue[0].approver1 != '') {
          this.supportapp1ID = this.approvervalue[0].approver1;
          this.supportapp1 = this.approvervalue[0].approver1Name;
          if (Number(this.getsupportid) === Number(this.supportapp1ID)) {
            this.appvflg = true;
          }
        }

        if (this.approvervalue[0].approver2 != '') {
          this.supportapp2ID = this.approvervalue[0].approver2;
          this.supportapp2 = this.approvervalue[0].approver2Name;
          if (Number(this.supportapp2ID) == Number(this.getsupportid))
            this.appvflg = true;
        }

        if (this.approvervalue[0].approver3 != '') {
          this.supportapp3ID = this.approvervalue[0].approver3;
          this.supportapp3 = this.approvervalue[0].approver3Name;
          if (Number(this.supportapp3ID) == Number(this.getsupportid))
            this.appvflg = true;
        }
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('POST request failed', error);
    }
  }

  Approver(applevel: Number) {
    if (Number(applevel) == 3) { this.Approver3(); }
    else if (Number(applevel) == 2) { this.Approver2(); }
    else { this.Approver1(); }
  }


  //get approved details for all levels
  getapprvdtls: any[] = [];
  approvedDt: any = '';
  comments: any = '';
  getlevel: any;
  emailofreciver: any;

  async getapprdtls(level: Number) {
    const apiUrls = this.apiurl + '/ViewChangeHistory/GetCrApproverHistory?id=' + this.itcrid

    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.getapprvdtls = response.filter((item: any) => item.stage.trim() === "R");
        this.getlevel = Number(level) - 1
        if (this.getapprvdtls.length > 0) {
          this.approvedDt = this.getapprvdtls[this.getlevel].approvedDt;
          this.remark = this.getapprvdtls[this.getlevel].remarks
          this.date = this.getapprvdtls[this.getlevel].approvedDt
          this.comment = this.getapprvdtls[this.getlevel].comments
          this.attach = this.getapprvdtls[this.getlevel].attachment
        }
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  async Approver1() {
    this.APILevel = 1;
    await this.GetApprover(1);
    await this.getapproverslevel();
    await this.getapprdtls(1);
    await this.getFileData();
    if (this.appstatus == "Implemented") {
      if (this.appvflg) this.appflag = true;
      this.remark = '';
      this.attach = '';
      this.date = this.currentday;
    } else {
      this.appflag = false;
      this.appvflg = false;
    }
  }

  async Approver2() {
    this.APILevel = 2;
    await this.GetApprover(2);
    await this.getapproverslevel();
    await this.getapprdtls(2);
    await this.getFileData();
    if (this.appstatus == "Approved level1") {
      if (this.appvflg) this.appflag = true;
      this.remark = '';
      this.attach = '';
      this.date = this.currentday;
    } else {
      this.appflag = false;
      this.appvflg = false;
    }
  }

  async Approver3() {
    this.APILevel = 3;
    await this.GetApprover(3);
    await this.getapproverslevel();
    await this.getapprdtls(3);
    await this.getFileData();
    if (this.appstatus == "Approved level2") {
      if (this.appvflg) this.appflag = true;
      this.remark = '';
      this.attach = '';
      this.date = this.currentday;
    }
    else {
      this.appflag = false;
      this.appvflg = false;
    }
  }

  approverget: any;
  approverlevels: any = '';
  responseData: any[] = [];
  apvnames: any[] = [];

  ApproverNames(): { id: string, name: string }[] {

    const approverNames: { id: string, name: string }[] = [];
    for (const key in this.responseData[0]) {
      if (key.endsWith('Name')) {
        const idKey = key.replace('Name', '');
        const id = this.responseData[0][idKey];
        const name = this.responseData[0][key];
        if (id && name && name.trim() !== '') {
          approverNames.push({ id, name });
        }

      }
    }

    return approverNames;
  }

  async getapproverslevel() {
    if (!this.crid) {
      return
    }
    const apiUrls: any = this.apiurl + '/GetApproval/GetApprover';

    const requestBody = {
      "level": Number(this.APILevel),
      "stage": "R",
      "plantid": Number(this.crid?.plantId),
      "categoryId": Number(this.crid?.categoryId),
      "classificationId": Number(this.crid?.classificationId)
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };

    try {
      const response: any = await this.http.post(apiUrls, requestBody, httpOptions).toPromise();

      if (response) {
        if (this.APILevel == 1) {
          this.responseData = response;
          this.rfcapproverlevel = "Approval Level 1";
          this.ApproverNames();
        }
        if (this.APILevel == 2) {
          this.responseData = response;
          this.rfcapproverlevel = "Approval Level 2";
          this.ApproverNames();
        }
        if (this.APILevel == 3) {
          this.responseData = response;
          this.rfcapproverlevel = "Approval Level 3";
          this.ApproverNames();
        }
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('POST request failed', error);
    }
  }

  releaseComments: any = '';
  attachments: any = '';
  submitRelease() {
    // this.attachfile = this.selectedFiles.name;
    // if (this.attachfile == undefined) {
    //   this.attachfile = '';
    // }

    if (this.releaseComments.trim() == '') {
      alert(' Enter Release Comments');
      return;

    } else {
      const apiUrl = this.apiurl + "/CRrelease/Releaser";
      const requestBody = {
        "flag": "I",
        "itcrid": this.crid?.itcrid,
        "crReleaseID": 0,
        "sysLandscape": 1,
        "releaseComments": this.releaseComments,
        "assignedTo": this.supportid,
        "releaseDt": this.today,
        "attachments": this.attachfile,
        "status": "Released",
        "approvedBy": this.supportid,
        "approvedDt": this.today,
        "createdBy": this.supportid,
        // "sendemailfrom": this.sendemailfrom,
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
            alert("RFC Code" + this.crid.crcode + " " + "Released for Approval");
            this.addFile();
            this.emailapproversinfo('Released');
            this.router.navigate(['/change-request']);
          }

        },
        (error: any) => {
          console.log('Post request failed', error);
        }
      );
    }
  }

  tableData: any[] = [];
  getData() {
    if (!this.crid) {

      return
    }
    const apiUrls = this.apiurl + '/ViewChangeHistory/GetCrApproverHistory?id=' + this.crid.itcrid
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.tableData = response;
        this.tableData = this.tableData.sort((a, b) => {
          return new Date(a.crhistoryDt).getTime() - new Date(b.crhistoryDt).getTime();
        });
      },
      (error) => {
        console.error("Data fetching error", error)
      }
    )
  }
}


