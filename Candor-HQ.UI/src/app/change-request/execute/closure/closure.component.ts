import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { PasscrdataService } from '../../passcrdata.service';
import { ActivatedRoute, Router } from '@angular/router';import { environment } from '@environments/environment';
import { DatePipe } from '@angular/common';
import { GetEmployeeInfoService } from '../../../services/get-employee-info.service';
import { UserInfoSerService } from '../../../services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-closure',
  templateUrl: './closure.component.html',
  styleUrl: './closure.component.css'
})
export class ClosureComponent implements OnChanges {
todaysDate = new Date().toISOString().slice(0,10);
  @Input() crid: any;
  @Input() crData1: any
  today: any;
  supportid: any;
  supportname: any;
  currentdate: any;
  stage: any;
  appstatus: any;
  status: any = '';
  appflag: any = '';
  remark: any = '';
  comment: any = '';
  APILevel: Number = 1;
  rfcapproverlevel: string = '';
  isApproved: any;
  categoryId: any = '';
  selectedOption: string = '';
  classificationId: any = '';
  approveflag: boolean = true;
  isSupport: boolean = true;
  plantData: any[] = [];
  getcrid: any[] = [];
  getcrcode: string = '';
  crownername: string = '';
  isCompleted: boolean = false;
  plantidforapp: any = ' ';
  date: any = ' ';
  currentday: any = ' ';
  allEmpList: any[] = [];
  supportteam: any[] = [];
  itcrid: any = '';
  approver: any = '';
  attach: any = '';
  closureRemarks: any = "";
  feedbackout: any = "";
  closedby: any = "";
  createdby: any = "";
  closeddate: any = "";
  closedstatus: string = "";
  EmailNotification: boolean = false;
  user: any;
  attachmentsList: any = [];
  MAX_FILE_SIZE = 1024 * 1024 * 5
  selectedFiles: File | undefined;

  constructor(private http: HttpClient, private userinfoSer: UserInfoSerService, private httpSer: HttpServiceService,
    private employeeInfo: GetEmployeeInfoService, private datepipe: DatePipe, private routeservice: PasscrdataService, private route: ActivatedRoute, private router: Router) {
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
    if (this.crid) {
      this.appstatus = this.crid.status.trim();
      this.status = this.crid.status.trim();
      this.stage = this.crid.stage.trim();
      this.crownername = this.crid.crowner;
      this.plantidforapp = this.crid.plantId
    }

    // })

    // this.routeservice.crdata.subscribe(data => {

    // })
    this.StageStatus();
    this.getsupportteams();
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;
    const currentDate = new Date()
    const datePart = currentDate.toISOString().slice(0, 10);
    const timePart = currentDate.getHours().toString().padStart(2, '0') + ':' +
      currentDate.getMinutes().toString().padStart(2, '0') + ':' +
      currentDate.getSeconds().toString().padStart(2, '0');
    this.date = `${datePart} ${timePart}`;
    this.currentday = `${datePart} ${timePart}`;
    this.today = currentDate.toISOString().slice(0, 10);
    this.currentdate = currentDate.toISOString().slice(0, 10);

    this.routeservice.crdata.subscribe(data => {
      this.getcrid = [data.report];
    })
    this.getcrcode = this.getcrid[0]?.value?.crcode;
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
      if (this.crid) {
        this.appstatus = this.crid.status.trim();
        this.status = this.crid.status.trim();
        this.stage = this.crid.stage.trim();
        this.crownername = this.crid.crowner;
        this.plantidforapp = this.crid.plantId
        this.isApproved = this.crid.isApproved;
        this.categoryId = this.crid.categoryId;
        this.classificationId = this.crid.classificationId
        if (this.isApproved == true) {
          this.approveflag = false;
        }
        else {
          this.approveflag = true;
        }
        this.getcrdata();
        this.getidupdate();
        this.getapprovestatus();
        this.getsupportteams();
        this.getupdatyevalue();
        this.getapproverslevel();
        this.getCloserdtls();
        this.getfollowupdtls();
        this.getlessonsdtls();
        this.usersupportteams()
        this.GetApprover(1);
        this.ReleasedStatus();
        this.StageStatus();
      }
    }
  }
  selectedTab: number = 0;
  count: any;
  showTab(index: number) {
    this.selectedTab = index;
  }

  approver1Name: String = '';
  approver2Name: String = '';
  approver3Name: String = '';

  ngOnInit(): void {
    this.getidupdate();
    this.getapprovestatus();
    this.getsupportteams();
    this.getupdatyevalue();
    this.getapproverslevel();
    this.getCloserdtls();
    this.getfollowupdtls();
    this.getlessonsdtls();
    this.getFileData();
    this.usersupportteams()
    setTimeout(() => {
      this.GetApprover(1);
      this.ReleasedStatus();
      this.StageStatus();
    }, 1000);
    setTimeout(() => {
      this.GetApprover(1);
    }, 500);
  }
  private apiurl = environment.apiurls;

  handleFileInput(event: any, index: number) {
    const file = event.target.files[0];
    this.plantData[index].attachment = file;
  }

  getidupdate() {

    this.itcrid = this.route.snapshot.paramMap.get('id');
  }//ff
  approvervalue: any = '';
  approverCount: any = '';
  supportapp1: any; supportapp2: any; supportapp3: any; supportapp: any;
  supportapp1ID: any; supportapp2ID: any; supportapp3ID: any;
  appvflg: boolean = false;

  approverdata: any[] = [];

  data = 2; // Or any value you want
  approvers: any[] = [];


  initializeApprovers() {

  }

  counter(i: number) {
    return new Array(i);
  }

  isapprover: any[] = [];
  getapprovestatus() {
    const apiUrl = this.apiurl + '/SupportteamAssigned';
    this.http.get(apiUrl).subscribe(
      (response: any) => {
        //this.isapprover = response.filter((item: any) => item.itcrid === parseInt(this.crid.itcrid));
        this.isapprover = response.filter((item: any) => parseInt(item.supportTeamId) == parseInt(this.getsupportid));
      },
      (error: any) => {
        console.error('POST request failed', error);
      });
  }

  selectedFile: any = '';
  getattach(event: any): void {
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
        this.filestg = 'C1';
        break;
      case 2:
        this.filestg = 'C2';
        break;
      case 3:
        this.filestg = 'C3';
        break;
      default:
        this.filestg = 'C1';
    }
    if(this.status==="Approved" && this.stage==="Closure") this.filestg = 'C';

    
    const formData = new FormData();
    formData.append('itcrid', this.crid.itcrid);
    formData.append('file',this.selectedFiles);
    formData.append('FileName', this.selectedFiles.name);
    formData.append('Stage', this.filestg);
    formData.append('CreatedBy', this.user?.empData?.employeeNo);
    formData.append('ModifiedBy', this.user?.empData?.employeeNo);

    const apiUrl = `${this.apiurl}/ChangeRequest/addFile`;

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
        this.filestg = 'C1';
        break;
      case 2:
        this.filestg = 'C2';
        break;
      case 3:
        this.filestg = 'C3';
        break;
      default:
        this.filestg = 'C1';
    }

    if((this.status==="Approved" && this.stage==="Closure") || (this.isCompleted)) this.filestg = 'C';
    
    let param = {
      itcrid: this.itcrid
    }
    this.httpSer.httpGet(url, param).subscribe(res => {
      this.attachmentsList = res 
      this.attachmentsList = this.attachmentsList.filter((m: any) => m.stage === this.filestg)
    })
  }

  viewFile(itcrid: string, fileName: string): void {
    const apiUrl = `${this.apiurl}/CRlession/GetFile?itcrid=${itcrid}&fileName=${fileName}`;

    this.http.get(apiUrl, { responseType: 'blob' }).subscribe(
      (response: Blob) => {
        const url = window.URL.createObjectURL(response);
        const link = document.createElement('a');
        link.href = url;
        link.download = fileName;
        link.target = '_blank';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
        window.URL.revokeObjectURL(url);
      },
      (error: any) => {
      }
    );
  }

   viewFile1(fileName: any): void {
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

  crval: any[] = [];
  crrname: any = '';
  croname: any = '';
  crempid: any = '';
  cremail: any = '';

  async getcrinfo(empid: any) {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.crval = this.supportteam.filter(item => item.empId === Number(empid));
        this.croname = this.crval[0].firstName + " " + this.crval[0].middleName + " " + this.crval[0].lastName;
        this.croemail = this.crval[0].email;
        console.log('this.croname', this.croname)
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
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

  crrempid: any = ''
  croempid: any = ''
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
    this.plantid = this.emailCR[0].plantId;
    this.EmailNotification = this.emailCR[0].crremailNotification;
    this.crrequestors();
    this.getcrinfo(this.croempid);
  }
  activeTab: number = 1;

  activateTab(tabNumber: number) {
    this.activeTab = tabNumber;
  }

  approverValues: string[] = [];
  remarkValues: string[] = [];
  value: any;
  attachfile: any = '';

  getdata(statu: any) {
    if(this.remark==='') {
      alert('Enter Remarks');
      return;
    }
    this.attachfile = this.selectedFile.name;
    if (this.attachfile == undefined) {
      this.attachfile = '';
    }

    if (this.APILevel == 1) {
      if (this.approverCount <= 1) {
        this.status = "Approved"
      }
      else {
        this.status = "Approved Level1"
      }
    }
    else if (this.APILevel == 2) {
      if (this.approverCount <= 2) {
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
      "approverLevel": this.APILevel,
      "PlantID": this.crid.plantId,
      "SupportID": 1,
      "CRID": this.crid.itcrid,
      "Stage": "C",
      "ApproverID": Number(this.supportid),
      "ApprovedDt": this.today,
      "Remarks": this.remark,
      "Comments": this.remark,
      "Status": this.status,
      "Attachment": this.attachfile,
      "CreatedBy": Number(this.supportid),
      "createdDt": this.today,
      "ModifiedBy": Number(this.supportid),
      "modifiedDt": this.today
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
          this.addFile();
          alert("RFC Code" + " " + this.crid.crcode + " " + ": is Successfully" + " " + this.status);
          this.emailapproversinfo(this.status);
          this.router.navigate(['/change-request']);
        }
      },
      (error: any) => {
        console.error('POST request failed', error);
      });
  }

  rejectbutton(status: any) {
    if (this.remark == '') {
      alert('Enter closure remarks')
    }
    else {
      const apiUrl = this.apiurl + '/CRapprove/Approve';
      const requestBody = {
        "Flag": "I",
        "CRApproverID": 1,
        "PlantID": this.crid.plantId,
        "SupportID": 1,

        "CRID": this.crid.itcrid,
        "ApproverLevel": this.APILevel,
        "Stage": "C",
        "ApproverID": this.supportid,
        "ApprovedDt": this.today,
        "Remarks": this.remark,
        "Comments": "this.comment",
        "Status": status,
        "Attachment": this.attach,
        "CreatedBy": Number(this.supportid),
        "CreatedDt": this.today,
        "ModifiedBy": Number(this.supportid),
        "ModifiedDt": this.today,
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
            alert("RFC Code" + " " + this.crid.crcode + " " + ": was Rejected!");
            this.emailapproversinfo(status);
            this.router.navigate(['/change-request']);
          }
        },
        (error: any) => {
          alert("POST request failed");
          console.error('POST request failed', error);
        });
    }
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

  emailapproversinfo(status: any): Promise<any> {
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
        this.appv = response
        this.sendemailfrom(status, this.appv);
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
  approverlevelstatus1: any = ''
  approverlevelstatus2: any = ''
  approverlevelstatus3: any = ''
  to: any = '';
  to1: any = '';
  to2: any = '';
  to3: any = '';
  cc1: any = '';
  cc2: any = '';
  cc3: any = '';
  cc4: any = '';
  cc5: any = '';
  addrto: any = '';
  subjecttxt: any = '';
  populatedOutput: any = '';
  crrequestedby: any[] = [];
  setcreniatorname: any;
  crowner: any = '';
  submitby: any = '';
  appname: any = '';

  async crrequestors() {
    try {
      await this.employeeInfo.empList();
      this.crrequestedby = this.allEmpList.filter((item: any) => parseInt(item.employeeId) == parseInt(this.updatevalue[0].crrequestedBy));
      this.setcreniatorname = (this.crrequestedby[0].employeeId + "-" + this.crrequestedby[0].employeeName).trim();
      this.crrname = this.crrequestedby[0].employeeName;
      if (this.EmailNotification == true) {
        var sendCrEmail: any = this.crrequestedby[0].email;
      } else {
        var sendCrEmail: any = "";
      }
      this.crremail = sendCrEmail;;
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
        this.crowner = this.supportteam.filter((item: any) => item.empId === this.updatevalue[0].crowner);
        this.submitby = this.crowner[0].firstName + " " + this.crowner[0].middleName + " " + this.crowner[0].lastName
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
      if (emailreq == "Approved Level1") {
        this.to1 = this.approver1Emails
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
        const changeDesc = this.crdesc
        this.subjecttxt = `Unnati:IT Change Request: ${this.crid.crcode} : Closure Approved Level 1`
        const output = this.readHtmlFile('assets/approvalemail.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.approver1Names)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrname)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'Completed Closure Approval Level 1')
          .replace('{{crid}}', this.crData1?.crcode)
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.appv?.length >= 2 ? this.approver2Names : 'NA')
          .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3Names : 'NA')
          .replace('{{phase}}', 'Closure Approval')
          .replace('{{status}}', 'Closure Approved Level 1')
          .replace('@Approval1Status', this.approverlevelstatus1)
          .replace('@Approval2Status', this.appv?.length>=2?this.approverlevelstatus2:'NA')
          .replace('@Approval3Status', this.appv?.length==3?this.approverlevelstatus3:'NA')
          .replace('{{approvedby}}', [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
            .filter(Boolean)
            .join(' '));
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

        this.subjecttxt = `Unnati:IT Change Request:${this.crid.crcode} : Closure Approved Level 2`
        const output = this.readHtmlFile('assets/approvalemail.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.approver2Names)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrname)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'Completed Closure Approval Level 2')
          .replace('{{crid}}', this.crData1?.crcode)
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.appv?.length >= 2 ? this.approver2Names : 'NA')
          .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3Names : 'NA')
          .replace('{{phase}}', 'Closure Approval')
          .replace('{{status}}', 'Closure Approved Level 2')
          .replace('@Approval1Status', this.approverlevelstatus1)
          .replace('@Approval2Status', this.appv?.length>=2?this.approverlevelstatus2:'NA')
          .replace('@Approval3Status', this.appv?.length==3?this.approverlevelstatus3:'NA')
          .replace('{{approvedby}}', [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
            .filter(Boolean)
            .join(' '));

      }
      else if (emailreq == "Approved") {
        //this.to1 = this.apprv13email
        this.to1 = this.appv?.length == 3 ? this.approver3Emails : this.appv?.length == 2 ? this.approver2Emails : this.approver1Emails
        //this.to2 = this.apprv23email
        //this.to3 = this.apprv33email
        this.cc1 = this.croemail
        this.cc2 = this.crremail
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
          this.approverlevelstatus3 = 'Approved'
        }
        const requestdate = this.crdate
        const changeDesc = this.crdesc
        this.subjecttxt = `Unnati:IT Change Request:${this.crid.crcode} : Closure Approved`
        const output = this.readHtmlFile('assets/approvalemail.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.appv?.length == 3 ? this.approver3Names : this.appv?.length == 2 ? this.approver2Names : this.approver1Names)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrname)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'Completed Closure Approved')
          .replace('{{phase}}', 'Closure Approval')
          .replace('{{status}}', 'Closure Approved')
          .replace('{{crid}}', this.crData1?.crcode)
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.appv?.length >= 2 ? this.approver2Names : 'NA')
          .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3Names : 'NA')
          .replace('@Approval1Status', this.approverlevelstatus1)
          .replace('@Approval2Status', this.appv?.length>=2?this.approverlevelstatus2:'NA')
          .replace('@Approval3Status', this.appv?.length==3?this.approverlevelstatus3:'NA')
          .replace('{{approvedby}}', [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
            .filter(Boolean)
            .join(' '));
      }
      else if (emailreq == "Reject") {
        this.cc1 = this.croemail
        this.cc2 = this.crremail
        //alert("satus")
        if (this.status == 'Approved') {
          this.appname = this.approver3Names
          this.to1 = this.appv?.length == 3 ? this.approver3Emails : this.appv?.length == 2 ? this.approver2Emails : this.approver1Emails
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
        // alert(this.appname)

        this.subjecttxt = `Unnati:IT Change Request:${this.crid.crcode} : Closure Approve Rejected`
        const output = this.readHtmlFile('assets/rejection.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.appname)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'Closure Approve Rejected')
          .replace('{{phase}}', 'Closure Approve Approval')
          .replace('{{status}}', 'Closure Approve Rejected')
          .replace('{{crid}}', this.crData1?.crcode)
          .replace('{{setstatus}}', 'Rejected')
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.appv?.length == 2 ? this.approver2Names : 'NA')
          .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3Names : 'NA')
          .replace('@Approval1Status', this.approverlevelstatus1)
          .replace('@Approval2Status', this.appv?.length == 2 ? this.approverlevelstatus2 : 'NA')
          .replace('@Approval3Status', this.appv?.length == 3 ? this.approverlevelstatus3 : 'NA')
          .replace('{{approvedby}}', [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
            .filter(Boolean)
            .join(' '));

      }
      else if ((emailreq == "Completed")) {
        this.to1 = this.crremail
        this.to2 = this.croemail
        this.cc1 = this.croemail
        this.crdesc += '<br><br> <b>Closure Remarks</b>: ' + this.closureRemarks
        const requestdate = this.crdate
        const changeDesc = this.crdesc
        this.subjecttxt = `Unnati:IT Change Request:${this.crid.crcode} : RFC Completed`
        const output = this.readHtmlFile('assets/rfccompletedemail.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrname)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrname)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{phase}}', 'Closure ')
          .replace('{{status}}', 'Completed')
          .replace('{{BodyContent}}', 'The change request submitted by ' + [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
            .filter(Boolean)
            .join(' ') + ' is completed now.')
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
      return ''; // or handle error accordingly
    }
  }

  getsupportid: any;
  async getsupportteams() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.supportteams = this.supportteam.filter((row: any) => row.empId === parseInt(this.supportid));
        this.getsupportid = this.supportteams[0].supportTeamId
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  updatevalue: any;
  isapproved: any;
  changerequest: any = '';

  getupdatyevalue() {
    const apiUrls: any = this.apiurl + '/ChangeRequest/Getrequest';

    return this.http.get(apiUrls).toPromise()
      .then((response: any) => {
        this.updatevalue = response.filter((item: any) => item.itcrid === parseInt(this.crid.itcrid));
        this.changerequest = response.filter((item: any) => item.itcrid.toString() === this.crid.itcrid);
        this.getCrOwnerfromsupteam();
      })
      .catch((error: any) => {
        throw error;
      });
  }

  async GetApprover(index: number) {
    const apiUrl = this.apiurl + '/GetApproval/GetApprover';
    if (!this.crid) {
      return
    }
    const requestBody = {
      "level": Number(index),
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
    try {
      const response: any = await this.http.post(apiUrl, requestBody, httpOptions).toPromise();

      if (response) {
        this.approverCount = response[0].approverCount;
        this.approvervalue = response;
        this.supportapp = "Select Approver"

        if (this.approvervalue[0].approver1 != '') {
          this.supportapp1ID = this.approvervalue[0].approver1;
          this.supportapp1 = this.approvervalue[0].approver1Name;
          if (Number(this.getsupportid) === Number(this.supportapp1ID)) {
            this.selectedOption = "support1";
          }
          if (Number(this.supportapp1ID) == Number(this.getsupportid))
            this.appvflg = true;
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

  ReleasedStatus() {
    if (this.stage == "Release") {
      if (this.appstatus == "Released") {
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
    if (this.appstatus == "Completed") {
      this.Approver1();
      if (this.approverCount == 2) {
        this.Approver2();
      }

      if (this.approverCount == 3) {
        this.Approver2();
        this.Approver3();
      }
      this.isCompleted = true;
    }
    if (this.stage == "Closure") {
      if (this.appstatus == "Approved") {
        this.Approver1();

        if (this.approverCount == 2) {
          this.Approver2();
        }

        if (this.approverCount == 3) {
          this.Approver2();
          this.Approver3();
        }
        this.isCompleted = true;
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
      if (this.status == "Approved level3") {
        this.Approver1();
        this.Approver2();
        this.Approver3();

      }

    }
    //alert('isCompleted : ' + this.isCompleted + 'app status' + this.appstatus)
  }
  Approver(applevel: Number) {
    if (applevel == 3) { this.Approver3(); }
    else if (applevel == 2) { this.Approver2(); }
    else { this.Approver1(); }
  }
  //get approved details for all levels
  getapprvdtls: any[] = [];
  approvedDt: any = '';
  getlevel: any = '';

  async getapprdtls(level: Number) {
    const apiUrls = this.apiurl + '/ViewChangeHistory/GetCrApproverHistory?id=' + this.itcrid

    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.getapprvdtls = response.filter((item: any) => item.stage.trim() === "C");
        if (this.getapprvdtls.length > 0) {
          this.getlevel = Number(level) - 1
          this.approvedDt = this.getapprvdtls[this.getlevel].approvedDt;
          this.remark = this.getapprvdtls[this.getlevel].remarks
          this.comment = this.getapprvdtls[this.getlevel].comments
          this.date = this.getapprvdtls[this.getlevel].approvedDt
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
    if (this.appstatus == "Released") {
      if (this.appvflg) this.appflag = true;
      this.remark = ''
      this.attach = ''
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
      this.remark = ''
      this.attach = ''
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
      this.remark = ''
      this.attach = ''
      this.date = this.currentday;
    } else {
      this.appflag = false;
      this.appvflg = false;
    }
  }

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
      "stage": "C",
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

  submitCloser() {

    const apiUrl = this.apiurl + '/Crcloser/Closer';
    const requestBody = {
      "itcrid": this.crid.itcrid,
      "closureRemarks": this.closureRemarks,
      "closedBy": Number(this.supportid),
      "closedDt": "2024-06-12T13:22:17.307Z",
      "feedback": this.feedbackout,
      "createdBy": Number(this.supportid),
      "closedStatus": this.closedstatus,
      "sendemailfrom": this.sendemailfrom,
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
          alert("RFC Code" + " " + this.crid.crcode + " " + ": is Completed");
          this.emailapproversinfo('Completed');
          this.router.navigate(['/change-request']);
        }
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }
  //get data from cr for closure
  closerdtls: any[] = []

  getCloserdtls() {
    const apiUrls = this.apiurl + '/ChangeRequest/Getrequest'
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.closerdtls = response;
        this.closerdtls = response.filter((item: any) => item.itcrid == this.crid.itcrid);
        this.closureRemarks = this.closerdtls[0].closureRemarks
        this.currentdate = this.closerdtls[0].closedDt
        this.feedbackout = this.closerdtls[0].feedback
        this.closedstatus = this.closerdtls[0].closedStatus
      },
      (error) => {
        console.error("Data fetching error", error)
      });
  }

  followupdtls: any[] = []
  followupviewdt: string = '';
  /*  getfollowupdtls() {
      const apiUrls = this.apiurl + '/CRfollowUp/GetFollow'
      const httpOptions = {
        headers: new HttpHeaders({
          'content-Type': 'application/json'
        })
      };
      this.http.get(apiUrls).subscribe(
        (response: any) => {
          this.followupdtls = response.filter((item: any) => item.itcrid === parseInt(this.crid.itcrid));

          //FollowUpDtStart
          this.followupviewdt = this.followupdtls?.[0]?.followupDt;
          const apimnfdate = this.datepipe.transform(this.followupviewdt, 'dd-MMM-yyyy') || '';
          const [day, month, year] = apimnfdate.split('-');
          const dateObject = new Date(`${year}-${month}-${day}`);
          //const formatDate = dateObject.toISOString().split('T')[0];
          const formatDate = dateObject?.toISOString()?.split('T')[0];
          this.followupDt = formatDate;

          //FollowUpDtEnd
          this.followupComments= this.followupdtls?.[0]?.followupComments
        },
        (error) => {
          console.error("Data fetching error", error)
        });
    }
  */

  getfollowupdtls() {
    const apiUrls = this.apiurl + '/CRfollowUp/GetFollow';

    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.followupdtls = response.filter((item: any) => item.itcrid === parseInt(this.crid.itcrid));

        // FollowUpDtStart
        this.followupviewdt = this.followupdtls?.[0]?.followupDt;
        if (this.followupviewdt) {
          const apimnfdate = this.datepipe.transform(this.followupviewdt, 'dd-MMM-yyyy');
          if (apimnfdate) {
            const [day, month, year] = apimnfdate.split('-');
            const dateObject = new Date(`${year}-${month}-${day}`);
            if (!isNaN(dateObject.getTime())) {
              const formatDate = dateObject.toISOString().split('T')[0];
              this.followupDt = formatDate;
            } else {
              console.error('Invalid date format:', apimnfdate);
            }
          } else {
            console.error('Failed to transform date:', this.followupviewdt);
          }
        } else {
          console.error('Empty or undefined date:', this.followupviewdt);
        }

        // FollowUpDtEnd
        this.followupComments = this.followupdtls?.[0]?.followupComments;
      },
      (error) => {
        console.error("Data fetching error", error);
      }
    );
  }

  lessondata: any[] = [];
  lessonsdtOnly: string = '';
  getlessonsdtls() {
    const apiUrls = this.apiurl + '/CRlession/GetCrLession'

    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.lessondata = response.filter((item: any) => item.itcrid === parseInt(this.crid.itcrid));
        if (this.lessondata) {
          this.lessondata.forEach((row) => {
            this.lessonsArray.push({ text: `${row.lessons}` });
          });
          this.lessonsdtOnly = this.lessondata?.[0]?.lessonDt;
          if (this.lessonsdtOnly) {
            const apilsnmnfdate = this.datepipe.transform(this.lessonsdtOnly, 'dd-MMM-yyyy');
            if (apilsnmnfdate) {
              const [day, month, year] = apilsnmnfdate.split('-');
              const datelsnObject = new Date(`${year}-${month}-${day}`);
              if (!isNaN(datelsnObject.getTime())) {
                const formattedLsnDate = datelsnObject.toISOString().split('T')[0];
                this.lessonDt = formattedLsnDate;
              }
              else {
                console.error('Invalid date format:', apilsnmnfdate);
              }
            }
            else {
              console.error('Failed to transform date:', this.lessonsdtOnly);
            }

          }
          else {
          }
        }
        else {
          console.log('Empty or undefined date:', this.lessondata);
        }
      },
      (error) => {
        console.error("Data fetching error", error)
      });
  }

  lessons: any = "";
  lessonsArray: any[] = [];
  attachment: any = "";
  lessonDt: any = "";
  errorMessage: any = '';


  crlesson() {
    const allEmpty = this.lessonsArray.every(lesson => lesson.text == '');

    if (this.lessonDt == '' || this.lessonDt == undefined || this.lessonDt == null) {
      alert('Please Select Lessons Learned Date.')
      return
    }
    else if (allEmpty) {
      alert('Please Add Lesson.');
      return;
    }
    this.lessonsArray.forEach((lesson, index) => {
      const apiUrl = this.apiurl + '/CRlession/Approve';
      if (lesson.crLessonID) {
        return
      }
      const requestBody = {
        "flag": "I",
        "crLessonID": 0,
        "itcrid": this.crid.itcrid,
        "lessons": lesson.text,
        "lessonDt": this.lessonDt,
        "attachment": this.attachment,
        "createdBy": Number(this.supportid),
        "createdDt": this.today,
        "modifiedBy": Number(this.supportid),
        "modifiedDt": this.today
      };

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
            alert("Lessons Saved successfully!")
            this.router.navigate(['/change-request']);
          }
        },
        (error: any) => {
          console.log('Post request failed', error);
        }
      );
    });
  }

  addLesson() {
    this.lessonsArray.push({ text: '' });
  }

  removeLastLesson() {
    if (this.lessonsArray.length > 1) {
      this.lessonsArray.pop();
    }
  }


  // Function to activate a tab
  followupDt: any;
  followupToPerson: any;
  followupComments: any;
  emailofreciver: any;

  Closerfollowup() {
    if (!this.followupDt || this.followupDt == '') {
      alert('Please enter Follow-up date!');
    }
    else if (!this.followupComments || this.followupComments == '') {
      alert('Please enter Follow-up comments!');
    }
    else {
      const apiUrl = this.apiurl + '/CRfollowUp/Followup';
      const requestBody = {
        "Flag": "I",
        "crFollowupID": 1,
        "itcrid": this.crid.itcrid,
        "followupDt": this.followupDt,
        "followupToPerson": this.supportid,
        "followupComments": this.followupComments,
        "CreatedBy": this.supportid

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
            alert("FollowUp Saved Successful!")
            this.router.navigate(['/change-request']);
          }
        },
        (error: any) => {
          console.error('POST request failed', error);
        });
    }
  }


  tableData: any[] = [];
  getData() {
    const apiUrls = this.apiurl + '/ViewChangeHistory/GetCrApproverHistory?id=' + this.itcrid
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
