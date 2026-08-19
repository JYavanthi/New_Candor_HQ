import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from '../passcrdata.service';
import { GetEmployeeInfoService } from '../../services/get-employee-info.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { environment } from '@environments/environment';
import { MatDialog } from '@angular/material/dialog';
import { HttpServiceService } from 'shared/services/http-service.service';
import { AddFilePopUpComponent } from '../add-file-pop-up/add-file-pop-up.component';

@Component({
  selector: 'app-approve',
  templateUrl: './approve.component.html',
  styleUrl: './approve.component.css'
})


export class ApproveComponent implements OnChanges {
  todaysDate = new Date().toISOString().slice(0, 10);
  showInitiator: boolean = false;
  showRiskQ: boolean = false;
  tabs: any[] = [];
  numberOfTabs: number = 1;
  plantData: any[] = [];
  approver: any = '';
  appdate: any = '';
  attach: any = '';
  remark: any = '';
  comment: any = '';
  errorMessage: any = '';
  successMessage: any = '';
  Rejected: any = '';
  selectthevalue: any = '';
  updatevalue: any[] = [];
  today: any;
  supportid: any;
  supportname: any;
  currentdate: any;
  approveflag: boolean = true;
  appflag: boolean = true;
  isSupport: boolean = true;
  selectedOption: string = '';
  isApprover1: boolean = true;
  isApprover2: boolean = true;
  isApprover3: boolean = true;
  APILevel: Number = 1;
  rfcapproverlevel: string = '';
  getcrid: any[] = [];
  getcrcode: string = '';
  crrempid: any = '';
  currentday: any = '';
  empname: any = '';
  EmailNotification: boolean = false;
  allEmpList: any[] = [];
  supportteam: any[] = [];
  approvervalue: any = '';
  approverCount: any = '';
  supportapp1: any; supportapp2: any; supportapp3: any; supportapp: any;
  supportapp1ID: any; supportapp2ID: any; supportapp3ID: any;
  appvflg: boolean = false;
  selectedTab: number = 0;
  count: any;
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
  tableData: any[] = [];
  @Input() crData: any
  @Input() crData1: any
  user: any;
  attachmentsList: any = [];
  MAX_FILE_SIZE = 1024 * 1024 * 5
  selectedFile: any = '';
  selectedFiles: File | undefined;

  constructor(private http: HttpClient, private employeeInfo: GetEmployeeInfoService,
    public userInfo: UserInfoSerService, private dialog: MatDialog, private httpSer: HttpServiceService, private routeservice: PasscrdataService, private router: Router, private route: ActivatedRoute) {
    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });
    this.user = userInfo.getUser()
    this.employeeInfo.suppTeamList().then(() => {
      this.supportteam = this.employeeInfo.SupportTeamList;
    });

    this.itcrid = this.route.snapshot.paramMap.get('id');
    if (this.crData?.isApproved == true) {
      this.approveflag = false;
    }
    else {
      this.approveflag = true;
    }

    this.getsupportteams();
    this.GetApprover(1);
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;
    const currentDate = new Date();
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
    this.getcrdata();
  }

  tab1: boolean = true;
  showfunction() {
    this.supportid == 2;
    if (this.supportid == 2) {
      this.tab1 = true;
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

  showTab(index: number) {
    this.selectedTab = index;
  }

  approver1Name: String = '';
  approver2Name: String = '';
  approver3Name: String = '';

  ngOnInit(): void {
    this.getapproverslevel();
    this.getapprdtls(1);
    this.usersupportteams();
    this.getFileData();
  }
  private apiurl = environment.apiurls;

  handleFileInput(event: any, index: number) {
    const file = event.target.files[0];
    this.plantData[index].attachment = file;
  }
  itcrid: any;

  approverdata: any[] = [];

  clearErrorMessage() {

  }

  activeTab: number = 1;

  activateTab(tabNumber: number) {
    this.activeTab = tabNumber;
  }

  approverValues: string[] = [];
  remarkValues: string[] = [];
  value: any;
  attachfile: any = '';


  getdata(status: any) {
    if (this.remark == '') {
      alert('Enter Remarks');
      return;
    }
    this.attachfile = this.selectedFile.name;
    if (this.attachfile == undefined) {
      this.attachfile = '';
    }
    if (this.APILevel == 1) {
      if (this.approverCount <= 1) {
        this.crData.status = "Approved"
      }
      else {
        this.crData.status = "Approved Level1"
      }
    }
    else if (this.APILevel == 2) {
      if (this.approverCount <= 2) {
        this.crData.status = "Approved"
      }
      else {
        this.crData.status = "Approved Level2"
      }
    }
    else {
      this.crData.status = "Approved"
    }

    const apiUrl = this.apiurl + '/CRapprove/Approve';
    const requestBody = {
      "Flag": "I",
      "CRApproverID": 1,
      "PlantID": this.crData?.plantId,
      "SupportID": 1,
      "CRID": this.crData?.itcrid,
      "approverLevel": this.APILevel,
      "Stage": "N",
      "ApproverID": Number(this.supportid),
      "ApprovedDt": this.today,
      "Remarks": this.remark,
      "Comments": this.comment,
      "Status": this.crData?.status?.trim(),
      "Attachment": this.attachfile,
      "CreatedBy": this.supportid,
      "CreatedDt": this.currentdate,
      "ModifiedBy": this.supportid,
      "ModifiedDt": this.currentdate,

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
          alert("RFC Code" + " " + this.crData?.crcode + " " + ": is Successfully" + " " + this.crData?.status.trim());
          this.addFile();
          this.emailapproversinfo(this.crData.status.trim());
          this.router.navigate(['/change-request']);
        }
      },
      (error: any) => {
        console.error('POST request failed', error);
      });
  }



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

  filestg: string;
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
        this.filestg = 'N1';
        break;
      case 2:
        this.filestg = 'N2';
        break;
      case 3:
        this.filestg = 'N3';
        break;
      default:
        this.filestg = 'N1';
    }
    const formData = new FormData();
    formData.append('itcrid', this.crData.itcrid);
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
        this.filestg = 'N1';
        break;
      case 2:
        this.filestg = 'N2';
        break;
      case 3:
        this.filestg = 'N3';
        break;
      default:
        this.filestg = 'N1';
    }

    let param = {
      itcrid: this.itcrid
    }
    this.httpSer.httpGet(url, param).subscribe(res => {
      this.attachmentsList = res
      this.attachmentsList = this.attachmentsList.filter((m: any) => m.stage === this.filestg)
    })
  }



  deleteDoc(Doc: any) {
    let url = '/ChangeRequest/Delete/' + Doc.attachId
    this.httpSer.httpDelete(url).subscribe(res => {
      this.attachmentsList = this.attachmentsList.filter((m: any) => Doc.attachId != m.attachId)
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
    //const apiUrl = `${this.apiurl}/CRlession/GetFile?itcrid=${itcrid}&fileName=${fileName.attachId}`;
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


  rejectbutton(status: any) {
    this.attachfile = this.selectedFile.name;
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
        "PlantID": this.crData.plantId,
        "SupportID": 1,
        "CRID": this.crData.itcrid,
        "approverLevel": Number(this.APILevel),
        "Stage": "N",
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
      }
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };

      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
          if (status == 'Seek Clarification') {
            alert("RFC Code" + " " + this.crData.crcode + " " + ": Needs Clarification");
          }
          else {
            alert("RFC Code" + " " + this.crData.crcode + " " + ": is Rejected");
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


  croempid: any = ''
  croemailid: any = ''
  crdate: any = ''
  crrdate: any = ''
  crdesc: any = ''
  emailCR: any[] = []
  crval: any[] = [];
  crrname: any = '';
  croname: any = '';
  crempid: any = '';
  cremail: any = '';

  async getcrdata() {
    const apiUrls = this.apiurl + '/ChangeRequest/Getrequest'

    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.emailCR = response.filter((item: any) => item.itcrid === Number(this.crData.itcrid))
        this.crrempid = this.emailCR[0].crrequestedBy;
        this.croempid = this.emailCR[0].crowner;
        this.crdate = this.emailCR[0].crdate;
        this.crrdate = this.emailCR[0].crrequestedDt;
        this.crdesc = this.emailCR[0].changeDesc;
        this.plantid = this.emailCR[0].plantId;
        this.EmailNotification = this.emailCR[0].crremailNotification;
        this.getcrinfo(this.croempid);
      } else {
      }
    } catch (error) {
    }
  }

  async getcrinfo(empid: any) {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.crval = this.supportteam.filter(item => item.empId === Number(empid));
        this.croemail = this.crval[0].email;
      }
    }
    catch (error) {
    }
  }

  emailapproversinfo(status: any): Promise<any> {
    const apiUrl = this.apiurl + '/GetApproverforEmail/GetApproverEmail';
    const requestBody = {
      "stage": "N",
      "plantid": Number(this.crData?.plantId),
      "categoryId": Number(this.crData?.categoryId),
      "classificationId": Number(this.crData?.classificationId)
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
  apprv11empid: any = '';
  apprv21empid: any = '';
  apprv31empid: any = '';
  apprv12empid: any = '';
  apprv22empid: any = '';
  apprv32empid: any = '';
  apprv13empid: any = '';
  apprv23empid: any = '';
  apprv33empid: any = '';
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
      this.crrequestedby = this.allEmpList.filter((item: any) => parseInt(item.employeeId) === this.updatevalue[0].crrequestedBy);
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
        this.crowner = this.supportteam.filter((item: any) => item.empId === this.updatevalue?.[0]?.crowner);
        this.submitby = this.crData1?.crowner
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
    this.apprv11empid = appv[0]?.empid1;
    if (appv[0]?.empid1 != '') {
      this.approver1Names = this.approver11Name + '(' + appv[0]?.empid1 + ')'
      this.approver1Emails = this.apprv11email
    }
    else { this.approver11Name = '' }

    this.approver21 = appv[0]?.approver2
    this.approver21Name = appv[0]?.approver2Name;
    this.apprv21email = appv[0]?.approver2Email;
    this.apprv21empid = appv[0]?.empid2;
    if (appv[0]?.empid2 != '') {
      this.approver1Names += ", <br> "
      this.approver1Names += this.approver21Name + '(' + appv[0]?.empid2 + ')'
      this.approver1Emails += ", " + this.apprv21email
    }
    else { this.approver21Name = '' }

    this.approver31 = appv[0]?.approver3;
    this.approver31Name = appv[0]?.approver3Name;
    this.apprv31email = appv[0]?.approver3Email;
    this.apprv31empid = appv[0]?.empid3;
    if (appv[0]?.empid3 != '') {
      this.approver1Names += ', <br>' + this.approver31Name + '(' + appv[0]?.empid3 + ')'
      this.approver1Emails += ', ' + this.apprv31email
    }
    else { this.approver31Name = '' }
    //second Level
    this.approver12 = appv[1]?.approver1;
    this.approver12Name = appv[1]?.approver1Name;
    this.apprv12email = appv[1]?.approver1Email;
    this.apprv12empid = appv[0]?.empid1;
    if (appv[1]?.empid1 != '') {
      this.approver2Names = this.approver12Name + '(' + appv[1]?.empid1 + ')'
      this.approver2Emails = this.apprv12email
    }
    this.approver22 = appv[1]?.approver2;
    this.approver22Name = appv[1]?.approver2Name;
    this.apprv22email = appv[1]?.approver2Email;
    this.apprv22empid = appv[0]?.empid2;
    if (appv[1]?.empid2 != '') {
      this.approver2Names += ', <br>' + this.approver22Name + '(' + appv[1]?.empid2 + ')'
      this.approver2Emails += ', ' + this.apprv22email
    }
    this.approver32 = appv[1]?.approver3;
    this.approver32Name = appv[1]?.approver3Name;
    this.apprv32email = appv[1]?.approver3Email;
    this.apprv32empid = appv[0]?.empid3;
    if (appv[1]?.empid3 != '') {
      this.approver2Names += ', <br>' + this.approver32Name + '(' + appv[1]?.empid3 + ')'
      this.approver2Emails += ', ' + this.apprv32email
    }
    else { this.approver32Name = '' }

    //Thrid Level
    this.approver13 = appv[2]?.approver1;
    this.approver13Name = appv[2]?.approver1Name;
    this.apprv13email = appv[2]?.approver1Email;
    this.apprv13empid = appv[0]?.empid1;
    if (appv[2]?.empid1 != '') {
      this.approver3Names = this.approver13Name + '(' + appv[2]?.empid1 + ')'
      this.approver3Emails = this.apprv13email
    } else { this.approver13Name = '' }

    this.approver23 = appv[2]?.approver2;
    this.approver23Name = appv[2]?.approver2Name;
    this.apprv23email = appv[2]?.approver2Email;
    this.apprv23empid = appv[0]?.empid2;
    if (appv[2]?.empid2 != '') {
      this.approver3Names += ', <br>' + this.approver23Name + '(' + appv[2]?.empid2 + ')'
      this.approver3Emails += ', ' + this.apprv23email
    } else { this.approver23Name = '' }
    this.approver33 = appv[2]?.approver3;
    this.approver33Name = appv[2]?.approver3Name;
    this.apprv33email = appv[2]?.approver3Email;
    this.apprv33empid = appv[0]?.empid3;
    if (appv[2]?.empid3 != '') {
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
        this.subjecttxt = `Unnati:IT Change Request:${this.crData?.crcode} : RFC Initiation Approved Level 1`
        const output = this.readHtmlFile('assets/approvalemail.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.approver1Names)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'RFC Initiation Approved Level 1')
          .replace('{{crid}}', this.crData?.crcode)
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.appv?.length >= 2 ? this.approver2Names : 'NA')
          .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3Names : 'NA')
          .replace('{{phase}}', 'RFC Initiation Approval')
          .replace('{{status}}', 'RFC Initiation Approved Level 1')
          .replace('@Approval1Status', this.approverlevelstatus1)
          .replace('@Approval2Status', this.appv?.length >= 2 ? this.approverlevelstatus2 : 'NA')
          .replace('@Approval3Status', this.appv?.length == 3 ? this.approverlevelstatus3 : 'NA')
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

        const requestdate = this.crdate
        const changeDesc = this.crdesc
        this.subjecttxt = `Unnati:IT Change Request:${this.crData?.crcode} : RFC Initiation Approved Level 2`
        const output = this.readHtmlFile('assets/approvalemail.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.approver2Names)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'RFC Initiation Approved Level 2')
          .replace('{{crid}}', this.crData?.crcode)
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.appv?.length >= 2 ? this.approver2Names : 'NA')
          .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3Names : 'NA')
          .replace('{{phase}}', 'RFC Initiation Approval')
          .replace('{{status}}', 'RFC Initiation Approved Level 2')
          .replace('@Approval1Status', this.approverlevelstatus1)
          .replace('@Approval2Status', this.appv?.length >= 2 ? this.approverlevelstatus2 : 'NA')
          .replace('@Approval3Status', this.appv?.length == 3 ? this.approverlevelstatus3 : 'NA')
          .replace('{{approvedby}}', [this.user?.empData?.firstName, this.user?.empData?.middleName, this.user?.empData?.lastName]
            .filter(Boolean)
            .join(' '));

      }
      else if (emailreq == "Approved") {

        //this.to1 = this.approver3Emails
        this.to1 = this.appv?.length == 3 ? this.approver3Emails : this.appv?.length == 2 ? this.approver2Emails : this.approver1Emails
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
        this.subjecttxt = `Unnati:IT Change Request:${this.crData?.crcode} : RFC Initiation Approved`
        const output = this.readHtmlFile('assets/approvalemail.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.appv?.length == 3 ? this.approver3Names : this.appv?.length == 2 ? this.approver2Names : this.approver1Names)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'RFC Initiation Approved')
          .replace('{{phase}}', 'RFC Initiation Approval')
          .replace('{{status}}', 'RFC Initiation Approved')
          .replace('{{crid}}', this.crData?.crcode)
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
      else if (emailreq == "Reject") {
        this.cc1 = this.croemail
        this.cc2 = this.crremail

        if (this.crData.status.trim() == 'Approved') {
          this.appname = this.approver3Names
          //this.to1 = this.approver3Emails
          this.to1 = this.appv?.length == 3 ? this.approver3Emails : this.appv?.length == 2 ? this.approver2Emails : this.approver1Emails;
          this.approverlevelstatus1 = 'Approved'
          this.approverlevelstatus2 = 'Approved'
          this.approverlevelstatus3 = 'Rejected'

        } else if (this.crData.status.trim() == 'Approved Level2') {
          this.appname = this.approver2Names
          this.to1 = this.approver2Emails
          this.cc3 = this.approver3Emails
          this.approverlevelstatus1 = 'Approved'
          this.approverlevelstatus2 = 'Rejected'
          this.approverlevelstatus3 = 'Not Required'
        } else if (this.crData.status.trim() == 'Approved Level1') {
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

        this.subjecttxt = `Unnati:IT Change Request:${this.crData?.crcode} : RFC Initiation Rejected`
        const output = this.readHtmlFile('assets/rejection.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.appname)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'RFC Initiation Rejected')
          .replace('{{phase}}', 'RFC Initiation Approval')
          .replace('{{status}}', 'RFC Initiation Rejected')
          .replace('{{crid}}', this.crData?.crcode)
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
      else if (emailreq == "Seek Clarification") {

        this.cc1 = this.croemail
        this.cc2 = this.crremail
        if (this.crData.status.trim() == 'Approved') {
          this.appname = this.approver3Names
          this.to1 = this.appv?.length == 3 ? this.approver3Emails : this.appv?.length == 2 ? this.approver2Emails : this.approver1Emails
          this.approverlevelstatus1 = 'Approved'
          this.approverlevelstatus2 = 'Approved'
          this.approverlevelstatus3 = 'Seek Clarification'

        } else if (this.crData == 'Approved Level2') {
          this.appname = this.approver2Names
          this.to1 = this.approver2Emails
          this.cc3 = this.approver3Emails
          this.approverlevelstatus1 = 'Approved'
          this.approverlevelstatus2 = 'Seek Clarification'
          this.approverlevelstatus3 = 'Not Required'
        } else if (this.crData.status.trim() == 'Approved Level1') {
          this.appname = this.approver1Names
          this.to1 = this.approver1Emails
          this.cc3 = this.approver2Emails

          this.approverlevelstatus1 = 'Seek Clarification'
          this.approverlevelstatus2 = 'Not Required'
          this.approverlevelstatus3 = 'Not Required'

        } else {
          this.appname = this.approver1Names
          this.to1 = this.approver1Emails
          this.cc3 = this.approver2Emails

          this.approverlevelstatus1 = 'Seek Clarification'
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


        this.subjecttxt = `Unnati:IT Change Request:${this.crData?.crcode} : RFC Initiation Seek Clarification`
        const output = this.readHtmlFile('assets/rejection.html');

        this.populatedOutput = output
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.appname)
          .replace('{{this.Cremailvalue[0].crrequestedBy}}', this.crrequestedBy)
          .replace('{{Requestorname}}', this.crData1?.crrequestorName)
          .replace('{{Submittedname}}', this.crData1?.crowner)
          .replace('{{this.Cremailvalue[0].crdate}}', this.crdate)
          .replace('{{this.Cremailvalue[0].changeDesc}}', this.crdesc)
          .replace('{{Approvestatus}}', 'RFC Initiation Seek Clarification')
          .replace('{{phase}}', 'RFC Initiation Approval')
          .replace('{{status}}', 'RFC Initiation Seek Clarification')
          .replace('{{crid}}', this.crData?.crcode)
          .replace('{{setstatus}}', 'Seek Clarification')
          .replace('{{crapprover1}}', this.approver1Names)
          .replace('{{crapprover2}}', this.appv?.length >= 2 ? this.approver2Names : 'NA')
          .replace('{{crapprover3}}', this.appv?.length == 3 ? this.approver3Names : 'NA')
          .replace('@Approval1Status', this.approverlevelstatus1)
          .replace('@Approval2Status', this.appv?.length >= 2 ? this.approverlevelstatus2 : 'NA')
          .replace('@Approval3Status', this.appv?.length == 3 ? this.approverlevelstatus3 : 'NA')
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
      return '';
    }
  }

  isapprover: any[] = [];
  getapprovestatus() {
    const apiUrl = this.apiurl + '/SupportteamAssigned';
    this.http.get(apiUrl).subscribe(
      (response: any) => {
        this.isapprover = response.filter((item: any) =>
          parseInt(item.categoryId) == parseInt(this.crData?.categoryId) &&
          parseInt(item.classificationId) == parseInt(this.crData?.classificationId) &&
          parseInt(item.plantId) == parseInt(this.crData?.plantId) &&
          parseInt(item.supportTeamId) == parseInt(this.getsupportid)
        );
      },
      (error: any) => {
        console.error('POST request failed', error);
      });

  }

  getsupportid: any;
  async getsupportteams() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        const suppteam = this.supportteam.filter((row: any) => row.empId === parseInt(this.supportid.trim()));
        this.getsupportid = suppteam[0].supportTeamId;
        this.getapprovestatus();
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  isapproved: any;
  changerequest: any = '';
  apprvlevel: number = 0;
  valuereq: any = '';


  async GetApprover(apprvlevel: Number) {

    if (!this.crData) {
      return
    }


    const apiUrl = this.apiurl + '/GetApproval/GetApprover';
    const requestBody = {
      "level": Number(apprvlevel),
      "stage": "N",
      "plantid": Number(this.crData?.plantId),
      "categoryId": Number(this.crData?.categoryId),
      "classificationId": Number(this.crData?.classificationId)
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
        this.appvflg = false;
        if (this.approvervalue[0].approver1 != '') {
          this.supportapp1ID = this.approvervalue[0].approver1;
          this.supportapp1 = this.approvervalue[0].approver1Name;
          if (Number(this.getsupportid) === Number(this.supportapp1ID)) {
            this.selectedOption = "support1";
          }
          if (this.supportapp1ID == this.getsupportid)
            this.appvflg = true;
        }
        if (this.approvervalue[0].approver2 != '') {
          this.supportapp2ID = this.approvervalue[0].approver2;
          this.supportapp2 = this.approvervalue[0].approver2Name;
          if (this.supportapp2ID == this.getsupportid)
            this.appvflg = true;
        }
        if (this.approvervalue[0].approver3 != '') {
          this.supportapp3ID = this.approvervalue[0].approver3;
          this.supportapp3 = this.approvervalue[0].approver3Name;
          if (this.supportapp3ID == this.getsupportid)
            this.appvflg = true;
        }
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  ngOnChanges(changes: SimpleChanges): void {

    if (changes['crData']) {
      this.GetApprover(1);
      this.getapproverslevel();
      this.getapprdtls(1);
      this.usersupportteams();
      this.getsupportteams();
      this.GetApprover(1);
    }
  }


  PendingStatus() {
    if (this.crData.stage.trim() == "Initiated") {
      if (this.crData?.status == "Pending Approval") {
        this.Approver1();
        this.isApprover1 = false;

        if (this.approverCount == 2) {
          this.Approver2();
          this.isApprover2 = false;
        }

        if (this.approverCount == 3) {
          this.Approver2();
          this.Approver3();
        }
      }
    }
  }

  StageStatus() {
    if (this.crData?.isApproved) {
      this.Approver1();
      if (this.approverCount == 2) {
        this.Approver2();
      }

      if (this.approverCount == 3) {
        this.Approver2();
        this.Approver3();
      }
    }
    if (this.crData.stage.trim() == "Approval") {
      if (this.crData.status.trim() == "Approved") {
        this.Approver1();
        this.Approver2();
        this.Approver3();
      }
      if (this.crData.status.trim() == "Approved level1") {
        this.Approver1();
        this.isApprover1 = false;

        if (this.approverCount == 2) {
          this.Approver2();
        }

        if (this.approverCount == 3) {
          this.Approver2();
          this.Approver3();
        }
      }
      if (this.crData.status.trim() == "Approved level2") {
        this.Approver1();
        this.isApprover1 = false;

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
  date: any = '';
  Approver(applevel: Number) {
    if (applevel == 3) { this.Approver3(); }
    else if (applevel == 2) { this.Approver2(); }
    else { this.Approver1(); }
  }

  parseAndSortResponse(response: any): any[] {
    let parsedResponse = response.map((item: any) => {
      return item;
    });
    parsedResponse.sort((a: any, b: any) => {
      if (a.itcrid < b.itcrid) {
        return 1;
      }
      if (a.itcrid > b.itcrid) {
        return -1;
      }
      return 0;
    });
    return parsedResponse;
  }

  //get approved details for all levels
  getapprvdtls: any[] = [];
  approvedDt: any = '';
  comments: any = '';
  getlevel: any;
  reclenght: number = 0;

  async getapprdtls(level: number) {
    const apiUrls = this.apiurl + '/ViewChangeHistory/GetCrApproverHistory?id=' + this.itcrid;

    try {
      let response: any = await this.http.get(apiUrls).toPromise();
      const response2: any = this.parseAndSortResponse(response);
      this.getapprvdtls = response2.filter((item: any) => item.stage.trim() === "N" && parseInt(item.approverLevel) === level);
      this.reclenght = this.getapprvdtls.length;
      if (this.reclenght > 0) {
        this.getlevel = this.reclenght - 1;
        this.remark = this.getapprvdtls[this.getlevel].remarks;
        this.date = this.getapprvdtls[this.getlevel].approvedDt;
        this.attach = this.getapprvdtls[this.getlevel].attachment;

      } else {
        this.remark = '';
        this.date = this.currentday;
        this.attach = '';
      }

    } catch (error) {
      console.error("Data fetching error", error);
    }
  }


  async Approver1() {
    this.APILevel = 1;
    await this.GetApprover(1);
    await this.getapproverslevel();
    await this.getapprdtls(1);
    await this.getFileData();

    if (this.crData.status.trim() == "Pending Approval" && this.date != '') {
      if (this.appvflg) {
        this.appflag = true;
        this.remark = '';
        this.attach = '';
        this.date = this.currentday;
      }
      else {
        this.appvflg = false;
        this.appflag = false;
      }
    }
    else if (this.crData.status.trim() == "Pending Approval" && this.date == '') {
      if (this.appvflg) {
        this.appflag = true;
        this.remark = '';
        this.attach = '';
        this.date = this.currentday;
      }
      else {
        this.appvflg = false;
        this.appflag = false;
      }
    }

    else {
      this.appvflg = false;
      this.appflag = false;
    }
  }

  async Approver2() {
    this.APILevel = 2;
    await this.GetApprover(2);
    await this.getapproverslevel();
    await this.getapprdtls(2);
    await this.getFileData();

    if (this.crData.status.trim() == "Approved level1" && this.crData.stage.trim() == "Approval" && this.date != '') {
      if (this.appvflg) {
        this.appflag = true;
        this.remark = '';
        this.attach = '';
        this.date = this.currentday;
      }
      else {
        this.appvflg = false;
        this.appflag = false;
      }
    }
    else if (this.crData.status.trim() == "Approved level1" && this.crData.stage.trim() == "Approval" && this.date == '') {
      if (this.appvflg) {
        this.appflag = true;
        this.remark = '';
        this.attach = '';
        this.date = this.currentday;
      }
      else {
        this.appvflg = false;
        this.appflag = false;
      }

    }
    else {
      this.appvflg = false;
      this.appflag = false;
    }
  }

  async Approver3() {
    this.APILevel = 3;
    await this.GetApprover(3);
    await this.getapproverslevel();
    await this.getapprdtls(3);
    await this.getFileData();

    if (this.crData.status.trim() == "Approved level2" && this.crData.stage.trim() == "Approval" && this.date != '') {
      if (this.appvflg) {
        this.appflag = true;
        this.remark = '';
        this.attach = '';
        this.date = this.currentday;
      }
      else {
        this.appvflg = false;
        this.appflag = false;
      }
    }
    else if (this.crData.status.trim() == "Approved level2" && this.crData.stage.trim() == "Approval" && this.date == '') {
      if (this.appvflg) {
        this.appflag = true;
        this.remark = '';
        this.attach = '';
        this.date = this.currentday;
      }
      else {
        this.appvflg = false;
        this.appflag = false;
      }

    }
    else {
      this.appvflg = false;
      this.appflag = false;
    }
  }

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

    const apiUrls: any = this.apiurl + '/GetApproval/GetApprover';
    if (!this.crData) {
      return
    }
    const requestBody = {
      "level": Number(this.APILevel),
      "stage": "N",
      "plantid": Number(this.crData?.plantId),
      "categoryId": Number(this.crData?.categoryId),
      "classificationId": Number(this.crData?.classificationId)
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
      console.error('GET request failed', error);
    }
  }

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
