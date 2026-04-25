import { Component, ViewChild } from '@angular/core';
import { HelpdeskserviceService } from '../../../helpdeskservice.service';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { PasscrdataService } from '../../../../change-request/passcrdata.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
// import { environment } from '/IT_Portal/IT-Portal/IT-Portal.UI/src/environments/environment'
import { trigger, state, style, transition, animate } from '@angular/animations';
import { HttpServiceService } from 'shared/services/http-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { DatePipe } from '@angular/common';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { environment } from '@environments/environment';

interface Message {
  text: string;
  timestamp: Date;
}

@Component({
  selector: 'app-update-issue-resolution',
  templateUrl: './update-issue-resolution.component.html',
  styleUrl: './update-issue-resolution.component.css',
  animations: [
    trigger('expandCollapseAnimation', [
      state('void', style({
        height: '0',
        opacity: '0'
      })),
      state('*', style({
        height: '*',
        opacity: '1'
      })),
      transition('void <=> *', animate('300ms ease-out')),
    ])
  ]
})
export class UpdateIssueResolutionComponent {
  @ViewChild('EnterCommentsID') EnterCommentsID: any;

  editorConfig: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: 'auto',
    minHeight: '0',
    maxHeight: 'auto',
    width: 'auto',
    minWidth: '0',
    translate: 'yes',
    enableToolbar: true,
    showToolbar: true,
    defaultParagraphSeparator: '',
    defaultFontName: '',
    defaultFontSize: '',
    fonts: [
      { class: 'arial', name: 'Arial' },
      { class: 'times-new-roman', name: 'Times New Roman' },
      { class: 'calibri', name: 'Calibri' },
      { class: 'comic-sans-ms', name: 'Comic Sans MS' }
    ],
    customClasses: [
      {
        name: 'quote',
        class: 'quote',
      },
      {
        name: 'redText',
        class: 'redText'
      },
      {
        name: 'titleText',
        class: 'titleText',
        tag: 'h1',
      },
    ],
    /*uploadUrl: 'v1/image',*/
    /*upload: (file: File) => { ... }
  uploadWithCredentials: false,
  sanitize: true,
  toolbarPosition: 'top'*/
    toolbarHiddenButtons: [
      ['fontSize',
        'subscript',
        'superscript',
        'indent',
        'outdent',
        'heading',
        'fontName',
        'fontSize',
        'link',
        'unlink',
        'insertVideo',
        'insertHorizontalRule',
        'removeFormat',
        'toggleEditorMode',
        'customClasses',
        'insertUnorderedList',
        'insertOrderedList',
      ]
    ]
  };

  // selectedRowData: any[] = [];
  IssueCode: string = '';
  attachment: any = '';
  Status: string = '';
  Category: string = '';
  ImpactedAsset: string = '';
  ShowForwardTo: boolean = false;
  showPanel: boolean = false;
  showChatPanel: boolean = false;
  Description: string = '';
  ResolutionRemarks: string = '';
  UserRemarks: string = '';
  images: Array<{ name: string, type: string, url: string }> = [];
  ShowSelfInputs: boolean = false;
  closeIssue: boolean = false;
  seekClarification: boolean = false;
  inProgress: boolean = false;
  resolve: boolean = false;
  submitClarification: boolean = false;
  unResolved: boolean = false;
  cancel: boolean = false;
  onHold: boolean = false;
  onHoldReason: boolean = false;
  ShowUserRemarks: boolean = false;
  forward: boolean = false;
  ShowResolutionRemarks: boolean = false;
  showForwardToDropdown = false;
  ShowOthers: boolean = false;
  ShowGuest: boolean = false;
  ShowOnHold: boolean = true;
  ShowAdminButtons: boolean = false;
  selectRowData: any[] = [];
  EmployeeID: string = '';
  Name: string = '';
  Email: string = '';
  ContactNo: string = '';
  ReportingManager: string = '';
  StaffCategory: string = '';
  Paygroup: string = '';
  Department: string = '';
  Designation: string = '';
  Role: string = '';
  Plant: string = '';
  EmployeeIDOthers: string = '';
  OthersName: string = '';
  EmailOthers: string = '';
  ContactNoOthers: string = '';
  ReportingManagerOthers: string = '';
  StaffCategoryOthers: string = '';
  onEdit: any;
  PlantOthers: string = '';
  PaygroupOthers: string = '';
  DepartmentOthers: string = '';
  DesignationOthers: string = '';
  RoleOthers: string = '';
  GuestEmployeeID: string = '';
  GuestName: string = '';
  Guestemail: string = '';
  GuestContactNo: string = '';
  ReportingManagerinML: string = '';
  StaffCategoryofML: string = '';
  GuestPlant: string = '';
  PaygroupML: string = '';
  DepartmentML: string = '';
  DesignationofMLManager: string = '';
  RoleofMLManager: string = '';
  ReportingManagerEmpID: string = '';
  assetId: any;
  loggedInUser: any[] = [];
  presentTime: string;
  isHelpdesk: any[] = [];
  RoleExecutive: boolean = false;
  RoleSuperAdmin: boolean = false;
  RoleAdmin: boolean = false;
  RoleApprover: boolean = false;
  isCommentVisible: boolean = false;
  messages: Message[] = [];
  SupportEngineerMessage: string = '';
  UserMessage: string = '';
  updateResolutionForOthers: any[] = [];
  updateResolutionForGuest: any[] = [];
  historytableData: any[] = [];
  description: string = '';
  messageList: any = [];
  commentBoxText = ''
  onHoldComment = '';
  messagesuccess: boolean = false;
  messageerror: boolean = false;
  onHoldReasonValue: string = '';
  ForwardTextOpen: boolean = false;
  forwardTo: string = '';
  assignToList: any[] = [];
  AssignTextOpen: boolean = false;
  assign: boolean = false;
  assignTo: string = '';
  ShowCommentBox: boolean = true;
  // isUpdateSidebarVisible = false;
  user: any;
  reasonList: any
  ProposedResolution: any;
  assignedTo: any = '';
  attachmentsList: any;
  issueData: any;
  issueId: any;
  resolutionDate: any;
  resolutionDtDisabled: boolean = false;
  resolutionDateField: boolean = true;

  scrollToTop(duration: number = 500) {
    window.scrollTo({
      top: 0,
      behavior: 'smooth'
    });
    setTimeout(() => {
      this.EnterCommentsID.nativeElement.focus();
    }, 0);
  }

  toggleUpdateSidebar() {
    this.isUpdateSidebarVisible = !this.isUpdateSidebarVisible;
  }

  sendMessage() {
    const messageText = this.commentBoxText;
    if (!messageText.trim()) {
      const alertMessage = 'Enter comments.';
      alert(alertMessage);
      return;
    }
    if (messageText.trim()) {
      this.messageList.push({
        userRole: this.issueData['userRole'],
        text: messageText,
        timestamp: new Date()
      });
    }
    const jsonString = JSON.stringify(this.messageList);

    let param = {
      "issueId": this.issueData.issueId,
      "textChat": jsonString
    }
    const url = '/issueChat/sendCommentById'
    this.httpser.httpPost(url, param).subscribe(m => {

    })
  }

  isUpdateSidebarVisible: boolean = false;

  closeSidebar() {
    this.isUpdateSidebarVisible = false;
  }

  openSidebar() {
    this.isUpdateSidebarVisible = true;
  }


  getcommentMessage() {
    const url = '/issueChat/getComments'
    this.httpser.httpGet(url, { id: this.issueId }).subscribe((m: any) => {
      let a = JSON.parse(m['textChat']);
      a.forEach((a: any) => {
        m['timestamp'] = new Date(m['timestamp'])
      })
      this.messageList = a;
      this.messageList.sort((a: { timestamp: string }, b: { timestamp: string }) => {
        return Date.parse(b.timestamp) - Date.parse(a.timestamp);
      });
    })
  }

  getFormattedTime(date: Date): string {
    if (typeof (date) == 'string') {
      date = new Date(date)
    }
    const hours = date.getHours().toString().padStart(2, '0');
    const minutes = date.getMinutes().toString().padStart(2, '0');
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const year = date.getFullYear();
    return `${hours}:${minutes} ${day}/${month}/${year}`;
  }

  togglePanel() {
    this.showPanel = !this.showPanel;
  }

  toggleChatPanel() {
    this.showChatPanel = !this.showChatPanel;
  }

  toggleCommentVisibility() {
    this.isCommentVisible = !this.isCommentVisible;
  }
  supportid: any;
  private apiurl = environment.apiurls;
  isSuperAdmin: boolean = false;
  isAdmin: boolean = false;
  allEmpList: any;


  constructor(private helpdeskservice: HelpdeskserviceService, private employeeInfo: GetEmployeeInfoService, private http: HttpClient, private routeservice: PasscrdataService,
    public httpser: HttpServiceService, private router: Router,
    private route: ActivatedRoute, private userInfo: UserInfoSerService, private datepipe: DatePipe,) {
    this.route.queryParams.subscribe(params => {
      this.onEdit = params['onEdit'];
    });
    this.presentTime = new Date().toISOString().slice(0, 16);

    this.user = this.userInfo.getUser();
    this.isSuperAdmin = this.user.supportTeamAssignList.filter((m: any) => m.isSuperAdmin && m.isActive).length > 0
    this.isAdmin = this.user.supportTeamAssignList.filter((m: any) => m.supportId == 3 && m.isAdmin && !m.isSuperAdmin && m.isActive).length > 0 && !this.isSuperAdmin
    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });

    this.route.paramMap.subscribe(params => {
      this.issueId = params.get('id');
    });


    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;

    //this.getUpdatedinputs();
    this.getsupportteams();
    this.fetchAllItems();


    if (this.ShowOnHold == true) {
      this.ShowAdminButtons = false;
    } else {
      this.ShowAdminButtons = true;
    }
  }

 
  async ngOnInit(): Promise<void> {
    try {
      await this.getIssueData();

      this.attachment = this.issueData?.attachment;

      // Call other dependent methods AFTER issueData is ready
      this.getcommentMessage();
      this.OnlyAsset();
      this.fetchAllItems();
      this.issueHistory();
      this.getFileData();
      this.getOnHOldReason();
    } catch (error) {
      console.error('Error loading issue data:', error);
      // You can show an alert or handle error UI here
    }
  }

  getIssueData(): Promise<void> {
    const apiUrls = '/IssueList/GetissuelistById';
    let param = {
      id: this.issueId
    };
    return this.httpser.httpGet(apiUrls, param).toPromise()
      .then((response: any) => {
        this.issueData = response;

        const status = this.issueData.status.trim();

        if (status != "Open") {
          this.resolutionDate = this.issueData?.resolutionDt;
        }

        this.updateResolutionData();
        this.getUpdatedinputs();
        // if(status == "Seek Clarification" && this.issueData.raisedbyid==this.user.empData.employeeNo){
        //   this.submitClarification = true;
        //   this.ForwardTextOpen = false;
        // }
        if (status == "Seek Clarification" && this.issueData.raisedbyid == this.user.empData.employeeNo) {
          this.submitClarification = true;
          this.ForwardTextOpen = false;
          this.forward = false;

        }
        if (this.issueData && this.onEdit == "false") {
          // your existing logic to set flags
          if ((status === "Open") && this.issueData.assignedToid != this.user.empData.employeeNo && this.issueData.assignedToid == 0) {
            this.resolutionDateField = false;
            this.assign = true;
          }
          else if ((status === "Open") && this.issueData.assignedToid != this.user.empData.employeeNo && this.issueData.assignedToid != 0) {
            this.resolutionDateField = false;
            this.forward = true;
          }
          else if ((status === "Open") && this.issueData.assignedToid == this.user.empData.employeeNo) {
            this.inProgress = true;
            this.resolutionDtDisabled = false;
          }
          else if ((status === "In Progress" || status == "Seek Clarification" || status === "Not Resolved" || status === "Submit Clarification") && this.issueData.assignedToid == this.user.empData.employeeNo) {
            this.seekClarification = true;
            this.resolve = true;
            this.onHold = true;
            this.forward = true;
            this.submitClarification = false;
          }
          else if (status.includes("On Hold") && this.issueData.assignedToid == this.user.empData.employeeNo) {
            this.seekClarification = true;
            this.resolve = true;
            this.forward = true;
            this.onHold = true;
          }
          else if (status == "Resolved") {
            this.seekClarification = false;
            this.resolve = false;
            this.forward = false;
            this.onHold = false;
            this.closeIssue = true;
            this.unResolved = true;

          }
          else if (this.issueData.assignedToid == 0) {
            this.assign = true;
            this.onHold = false;
            this.resolutionDateField = false;
          }
          else if ((this.isSuperAdmin || this.isAdmin) && this.issueData?.assignedToid != this.user.empData.employeeNo && this.issueData.assignedToid != 0 && (status != "Resolved" && status != "Closed" && status != "Cancelled")) {
            this.forward = true;
            this.assign = false;
          }

          this.assignedTo = this.issueData?.assignedToid;

          if (this.issueData?.status?.toUpperCase().trim() == "CANCELLED" ||
            this.issueData?.status?.toUpperCase().trim() == "CLOSED" ||
            (!this.seekClarification && !this.issueData?.status.trim().includes('On Hold') && !this.resolve && !this.forward && !this.assign && !this.submitClarification && !this.closeIssue && !this.unResolved && !this.cancel)) {
            this.ShowCommentBox = false;
          }
          else {
            this.ShowCommentBox = true;
          }
        }

        if (this.issueData && this.onEdit == "true") {
          this.ShowUserRemarks = true;
          this.cancel = true;
          this.ShowResolutionRemarks = false;
          if (status == "Open") {
            this.resolutionDateField = false;
          }
          else if (status == "Seek Clarification") {
            this.submitClarification = true;
            this.forward = false;
          }
          else if (status == "Resolved") {
            this.closeIssue = true;
            this.unResolved = true;
          }
        }
      })
      .catch((error: any) => {
        console.error('Error in getIssueData:', error);
        throw error;
      });
  }



  viewFile(fileName: string): void {
    const apiUrl = `${this.apiurl}/issueResolutionAttach/GetFile`;
    let param = {
      issueId: this.issueData?.issueId,
      fileName: fileName
    }

    this.http.get(apiUrl, {
      params: param,
      responseType: 'blob'
    }).subscribe(
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

  getOnHOldReason() {
    this.httpser.httpGet('/Classification/getHoldOnReason', { supportId: 3 }).subscribe(res => {
      this.reasonList = res
    })
  }
  issueHistory() {
    const apiUrls = this.apiurl + '/IssueList/GetIssuelistHistory'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.historytableData = response.filter((row: any) => row.issueId == this.issueData?.issueId);
        console.log('issue history datat', this.historytableData)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }
  getSelfData: any[] = [];

  sendCommnet() {
    this.messageList.push({ user: this.commentBoxText })
  }
  updateResolutionData() {
    if (this.issueData?.issueSelectedfor == 'self') {
      this.ShowSelfInputs = true;
    }

    if (this.issueData?.issueSelectedfor == 'others') {
      this.ShowOthers = true;
    }

    if (this.issueData?.issueSelectedfor == 'guest') {
      this.ShowGuest = true;
    }
  }

  async fetchAllItems() {
    try {
      await this.employeeInfo.empList();
      this.getSelfData = this.allEmpList?.filter((row: any) => row.employeeId == parseInt(this.issueData?.raisedbyid));
      this.getInputDatas();
      if (this.issueData?.issueSelectedfor == 'others') {
        this.updateResolutionForOthers = this.allEmpList?.filter((row: any) => row.employeeId == parseInt(this.issueData?.issuerisedforid))
        this.getOtherInputDatas();
      }
      if (this.issueData?.issueSelectedfor == 'guest') {
        this.updateResolutionForGuest = this.allEmpList?.filter((row: any) => row.employeeId == parseInt(this.issueData?.guestReportingManagerEmployeeId))
        this.getGuestInputDatas();
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }
  getOtherInputDatas() {
    this.EmployeeIDOthers = this.updateResolutionForOthers[0]?.employeeId;
    this.OthersName = this.updateResolutionForOthers[0]?.firstName + ' ' + this.updateResolutionForOthers[0]?.middleName + ' ' + this.updateResolutionForOthers[0]?.lastName;
    this.EmailOthers = this.updateResolutionForOthers[0]?.officialEmailId;
    this.ContactNoOthers = this.updateResolutionForOthers[0]?.mobileNo;
    this.ReportingManagerOthers = this.updateResolutionForOthers[0]?.reportManagerName;
    this.StaffCategoryOthers = this.updateResolutionForOthers[0]?.staffCategory;
    this.PlantOthers = this.updateResolutionForOthers[0]?.plantcode;
    this.PaygroupOthers = this.updateResolutionForOthers[0]?.payGroup;
    this.DepartmentOthers = this.updateResolutionForOthers[0]?.department;
    this.DesignationOthers = this.updateResolutionForOthers[0]?.designation;
    this.RoleOthers = this.updateResolutionForOthers[0]?.role;
  }

  getGuestInputDatas() {
    this.GuestEmployeeID = this.issueData?.guestEmployeeId;
    this.GuestName = this.issueData?.guestName;
    this.Guestemail = this.issueData?.guestEmail;
    this.GuestContactNo = this.issueData?.guestContactNo;
    this.ReportingManagerEmpID = this.updateResolutionForGuest[0]?.employeeId;
    this.ReportingManagerinML = this.updateResolutionForGuest[0]?.employeeName;
    this.StaffCategoryofML = this.updateResolutionForGuest[0]?.staffCategory;
    this.GuestPlant = this.updateResolutionForGuest[0]?.plantcode;
    this.PaygroupML = this.updateResolutionForGuest[0]?.payGroup;
    this.DepartmentML = this.updateResolutionForGuest[0]?.department;
    this.DesignationofMLManager = this.updateResolutionForGuest[0]?.designation;
    this.RoleofMLManager = this.updateResolutionForGuest[0]?.role;
  }

  updateStatus(status: any) {
    if (status == "Resolved") {
      const resolutionDate = new Date();
      this.ShowCommentBox = true;
    }

    if (status == 'Hold') {
      this.onHoldReason = !this.onHoldReason;
      this.ForwardTextOpen = false;
      this.ShowCommentBox = true;
      return
    }
    else {
      this.onHoldReason = false;
    }

    if (status == 'assignTextOpen') {
      this.ForwardTextOpen = false;
      this.AssignTextOpen = !this.AssignTextOpen;
      this.ShowCommentBox = false
      return
    }
    else {
      this.AssignTextOpen = false;
    }

    if (status == 'Seek Clarification') {
      this.ShowCommentBox = true;
    }

    if (status == 'ForwardTextOpen') {
      this.ForwardTextOpen = !this.ForwardTextOpen;
      this.onHoldReason = false;
      this.ShowCommentBox = true
      this.forwardToList = this.assignToList.filter((row: any) => row.empId !== this.issueData?.assignedToid);
      return;
    }
    else {
      this.ForwardTextOpen = false;
    }

    if (status.includes("On Hold") && this.onHoldComment == '') {
      const alertMessageHold = "Select On Hold reason";
      alert(alertMessageHold);
      return;
    }

    if (status == "In Progress") {
      if (this.resolutionDate == "" || this.resolutionDate == null) {
        alert("Please select Resolution Date");
        return;

      }
      const apiUrl = '/IssueList/SaveIssue'
      const requestBody = {
        "flag": "U",
        "issueId": this.issueData?.issueId,
        "issueSelectedfor": this.issueData?.issueSelectedfor,
        "issueRaisedBy": this.issueData?.raisedbyid,
        "issueDate": this.issueData?.issueDate,
        "issueShotDesc": this.issueData?.issueShotDesc,
        "issueDesc": this.issueData?.issueDesc,
        "issueRaiseFor": this.issueData?.issuerisedforid,
        "issueForGuest": this.issueData?.issueForGuest,
        "guestEmployeeId": this.issueData?.guestEmployeeId,
        "guestName": this.issueData?.guestName,
        "guestEmail": this.issueData?.guestEmail,
        "guestContactNo": this.issueData?.guestContactNo,
        "guestReportingManagerEmployeeId": this.issueData?.guestReportingManagerEmployeeId,
        "type": this.issueData?.type,
        "guestCompany": this.issueData?.guestCompany,
        "plantId": this.issueData?.plantId,
        "assetId": this.issueData?.assetId,
        "categoryId": this.issueData?.categoryId,
        "categoryTypId": this.issueData?.categoryTypId,
        "priority": this.issueData?.priorityid,
        "source": this.issueData?.source,
        "attachment": this.issueData?.attachment,
        "status": status,
        "assignedTo": this.issueData?.assignedToid,
        "assignedBy": this.issueData?.assignedbyid,
        "assignedOn": this.issueData?.assignedOn,
        "remarks": this.issueData?.remarks,
        "createdBy": this.issueData?.createdBy,
        "createdDt": this.issueData?.createdDt,
        "modifiedBy": this.issueData?.modifiedBy,
        "modifiedDt": this.issueData?.modifiedDt,
        "proposedResolutionOn": this.issueData?.proposedResolutionOn,
        "resolutionDt": this.resolutionDate,
        "attachmentIds": [],
        "reasonID": 0
      }

      this.httpser.httpPost(apiUrl, requestBody).subscribe(
        (response: any) => {
          this.messagesuccess = true;

          if (response.type == "S") {
            alert("Issue Picked Successfully.");
            this.router.navigate(['/report_issue']);
          }
          else {
            alert("Error while saving!");
          }
        },
        (error: any) => {
          this.messageerror = true;
        });
    }

    const messageText = this.commentBoxText;
    if (!messageText.trim() && status != 'In Progress' && !this.assign) {
      this.scrollToTop();
      setTimeout(() => {
        const alertMessage = 'Enter comments.';
        alert(alertMessage);
      }, 500);
      return;
    }
    if (messageText.trim()) {
      this.messageList.push({
        userRole: this.user?.empData?.firstName,
        text: messageText,
        timestamp: new Date()
      });
    }
    const jsonString = JSON.stringify(this.messageList);

    let param = {
      "id": 0,
      "issueId": this.issueData.issueId,
      "textChat": jsonString
    }

    if (status != "In Progress") {
      const requestBody = {
        "issueId": this.issueData?.issueId,
        "status": status,
        "chatsBox": param,
        "modifiedBy": parseInt(this.user?.empData?.employeeNo),
        "resolutionRemarks": messageText,
        "assignTo": Number(this.forwardTo),
        "reasonID": Number(this.onHoldComment)
      }
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };

      const apiUrl = this.apiurl + '/IssueResolution/updateIssueStatus'
      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
          if (response.type == "S") {
            this.messagesuccess = true
            this.commentBoxText = ''
            alert(response.message);
            this.sendemailfrom(status, this.issueData?.issueDesc);
            this.router.navigate(['/report_issue']);
          }
          else {
            alert(response.message);
          }

        },
        (error: any) => {
          this.messageerror = true;
        });

    }


  }

  impactassetasset: any[] = [];
  asset: string[] = [];
  impactassetassetcat: any = '';

  OnlyAsset() {
    this.impactassetasset = [];
    const apiUrls = this.apiurl + '/GetAssets'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.impactassetasset = response.filter((row: any) => row.assetId == this.issueData?.assetId);
        this.impactassetassetcat = this.impactassetasset[0]
      },
      (error) => {
      }
    )
  }


  downFile(fileName: any): void {
    const apiUrl = this.apiurl + '/IssueList/Download/' + fileName.attachId

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

  getFileData() {
    let url = '/IssueList/GetFileData'
    let param = {
      srId: this.issueId
    }
    this.httpser.httpGet(url, param).subscribe(res => {
      this.attachmentsList = res
    })
  }

  
  viewFileM(fileName: any): void {
    const apiUrl = `${this.apiurl}/IssueList/View/${fileName.attachId}`;

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

  deleteDoc(Doc: any) {
    let url = '/IssueList/Delete/' + Doc.attachId
    this.httpser.httpDelete(url).subscribe(res => {
      this.attachmentsList = this.attachmentsList.filter((m: any) => Doc.attachId != m.attachId)
    })
  }

  getInputDatas() {
    if (this.getSelfData) {
      this.EmployeeID = this.getSelfData[0]?.employeeId;
      this.Name = this.getSelfData[0]?.employeeName;
      this.Email = this.getSelfData[0]?.officialEmailId;
      this.ContactNo = this.getSelfData[0]?.mobileNo;
      this.ReportingManager = this.getSelfData[0]?.reportManagerName;
      this.StaffCategory = this.getSelfData[0]?.staffCategory;
      this.Plant = this.getSelfData[0]?.plantcode;
      this.Paygroup = this.getSelfData[0]?.payGroup;
      this.Department = this.getSelfData[0]?.department;
      this.Designation = this.getSelfData[0]?.designation;
    }
  }

  supportteams: any[] = [];
  forwardToList: any[] = [];

  getsupportteams() {
    const apiUrls = this.apiurl + '/SupportTeam'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.supportteams = response.filter((row: any) => row.empId === parseInt(this.supportid));
        const helpdeskFilter = response.filter((row: any) => (row.isSuperAdmin || row.supportId == 3) && row.isActive);
        if (this.isAdmin) {
          var isExecutiveFilter = helpdeskFilter.filter((row: any) =>
            row.isSuperAdmin || row.issupportengineer || row.isadmin
          );
        }
        else {
          var isExecutiveFilter = helpdeskFilter.filter((row: any) => row.isSuperAdmin || row.isadmin || row.issupportengineer);
        }
        const servicefilter = isExecutiveFilter.filter((row: any) => row.isSuperAdmin || row.categoryId == this.issueData?.categoryId)
        this.assignToList = servicefilter.filter((row: any, i: any) => (row.isSuperAdmin || row.isadmin || row.categoryTypeId == this.issueData?.categoryTypId) && servicefilter.map((a: any) => a.empId).indexOf(row.empId) == i);
        this.forwardToList = this.assignToList.filter((row: any) => row.empId !== this.issueData?.assignedToid);
      },
      (error) => {
      }
    )
  }

  async AssignTo(status: any) {
    const apiUrls = this.apiurl + 'IssueResolution/updateIssueStatus';
    const requestBody = {
      "flag": "U",
      "issueId": this.issueData?.issueId,
      "assignedTo": this.forwardTo,
      "assignedBy": parseInt(this.user?.empData?.employeeNo),
      "assignedOn": new Date().toISOString().slice(0, 10),
      "Status": status,
      "reasonID": this.onHoldComment
    };

    try {
      const response: any = await this.http.post(apiUrls, requestBody).toPromise()
      if (response) {
        if (response.type == "S") {
          this.issueData.assignedToid = this.forwardTo
          let assgn = this.assignToList.filter(m => m?.empId == this.forwardTo)[0]
          this.issueData.assignedTo = assgn.firstName + ' ' + assgn.middleName + ' ' + assgn.lastName
          alert(response.message);
          this.sendemailfrom(status, this.issueData.issueDesc);
          this.router.navigate(['/report_issue']);
        }
        else {
          alert(response.message);
        }
      }
    } catch (error) {
      console.error('Error', error)
    }
  }

  getUpdatedinputs() {
    this.description = this.issueData?.issueDesc;
    this.ProposedResolution = new Date(this.issueData?.proposedResolutionOn).toISOString().split('.')[0].replace('T', ' ')
    if (this.issueData?.status != "Open") {
      this.resolutionDate = new Date(this.issueData?.resolutionDt).toISOString().split('.')[0].replace('T', ' ')
      this.resolutionDtDisabled = true;
    }
  }

  Forward() {
    this.ShowForwardTo = !this.ShowForwardTo;
  }

  Assign() {
    this.ShowForwardTo = !this.ShowForwardTo;
  }

  private decodeHtmlEntities(encodedString: string): string {
    const textarea = document.createElement('textarea');
    textarea.innerHTML = encodedString;
    return textarea.value;
  }

  private convertFileToBase64(file: File): Promise<string> {
    return new Promise<string>((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        resolve(reader.result as string);
      };
      reader.onerror = (error) => {
        reject('Error converting file to base64');
      };
    });
  }

  handleFileInput(event: any) {
    const files: File[] = Array.from(event.target.files);
    this.images = [];

    files.forEach(file => {
      this.convertFileToBase64(file).then(base64 => {
        this.images.push({ name: file.name, type: file.type, url: base64 });
        this.Description += `<img src="${base64}" alt="${file.name} width='100' height='100' ">`;
      });
    });
  }

  currentTime: Date = new Date();

  ngInOnIt() {
    this.currentTime = new Date();
  }

  Goback() {
    this.helpdeskservice.getUpdateIssueResolutionData(null);
    this.helpdeskservice.getUpdateNewIssueData(null);
    this.router.navigate(['/report_issue']);
  }

  /* --------------------------------Chat-end----------------------------------*/
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

  sendemailfrom(status: any, IssueDesc: any) {
    const apiUrl = this.apiurl + '/Email';
    const requestedDateTime: any = this.datepipe.transform(this.issueData?.createdDt, 'dd/MMM/yyyy HH:mm:ss');
    const ProposedResolutionDate: any = this.datepipe.transform(this.issueData?.proposedResolutionOn, 'dd/MMM/yyyy HH:mm:ss');
    var valueofName: any = this.issueData?.issuerisedby;
    const PriorityName = this.issueData?.priorityName
    const assigntoEmail = this.assignToList.filter(m => parseInt(m.empId) == parseInt(this.assignedTo))[0]?.email

    if (this.issueData?.issueSelectedfor === "self") {
      var valueofTo: any = this.getSelfData[0].email;
      if (status == 'In Progress') {
        var valueofCC: any = assigntoEmail;
      } else {
        var valueofCC: any = '';
      }
      var valueofCC2: any = '';
      var valueofRequestorName: any = this.getSelfData[0]?.employeeName;
      var valueofPlantCode: any = this.getSelfData[0]?.plantcode;
      var valueofDepartmentName: any = this.getSelfData[0]?.department
      var valueofPhoneNo: any = this.getSelfData[0]?.phoneNumber
    }
    else if (this.issueData.issueSelectedfor === "others") {
      var valueofTo: any = this.EmailOthers;
      if (status == 'In Progress') {
        var valueofCC: any = assigntoEmail;
      } else {
        var valueofCC: any = this.Email;
      }
      var valueofCC2: any = '';
      var valueofRequestorName: any = this.OthersName;
      var valueofPlantCode: any = this.PlantOthers;
      var valueofDepartmentName: any = this.DepartmentOthers;
      var valueofPhoneNo: any = this.ContactNoOthers;
    }
    else if (this.issueData.issueSelectedfor === "guest") {
      var valueofTo: any = this.Email;
      if (status == 'In Progress') {
        var valueofCC: any = assigntoEmail;
      } else {
        var valueofCC: any = '';
      }
      var valueofCC2: any = '';
      var valueofRequestorName: any = this.getSelfData[0]?.employeeName;
      var valueofPlantCode: any = this.Plant;
      var valueofDepartmentName: any = this.Department;
      var valueofPhoneNo: any = this.ContactNo;
    }

    if (valueofPhoneNo == undefined || valueofPhoneNo == null) {
      var validPhoneNo: any = '';
    } else {
      var validPhoneNo: any = valueofPhoneNo.toString();
    }

    var to = valueofTo;
    var cc = valueofCC;
    var cc2 = valueofCC2;

    const output = this.readHtmlFile('assets/issue-email.html');

    const populatedOutput = output
      .replace('${SubmitterName}', valueofName)
      .replace('${IssueID}', this.issueData?.issueCode)
      .replace('{{RequestorName}}', valueofRequestorName)
      .replace('{{PlantCode}}', valueofPlantCode)
      .replace('{{DepartmentName}}', valueofDepartmentName)
      .replace('${PhoneNo}', validPhoneNo)
      .replace('${RequestedDateandTime}', requestedDateTime)
      .replace('{{Status}}', status)
      .replace('${Priority}', PriorityName)
      .replace('${IssueDescription}', IssueDesc)
      .replace('{{ProposedResolutionDate}}', ProposedResolutionDate)
      .replace('${WithinSLAorBreachedMet}', 'Within SLA')
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

    var cc1pluscc = cc + ',' + cc2;

    const requestBody = {
      "to": (to).replace(/^,+|,+$/g, '').trim().replace(/\s+/g, ' '),
      "cc": (cc1pluscc).replace(/^,+|,+$/g, '').trim().replace(/\s+/g, ' '),
      "subject": `Unnati: IT ISSUES: Issue ID: ${this.issueData?.issueCode}, Logged`,
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

}