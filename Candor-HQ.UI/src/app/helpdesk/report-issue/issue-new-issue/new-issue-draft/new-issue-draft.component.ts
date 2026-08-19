import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
// import { environment } from '/IT_Portal/IT-Portal/IT-Portal.UI/src/environments/environment'
import { ActivatedRoute, Router } from '@angular/router';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { PasscrdataService } from '../../../../change-request/passcrdata.service';
import { HelpdeskserviceService } from '../../../helpdeskservice.service';
import { GetEmployeeInfoService } from '../../../../services/get-employee-info.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserInfoSerService } from '../../../../services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { TaskTracker } from 'app/master-support/SLA/slamaster/trackSlaCal';
import { DatePipe } from '@angular/common';
import { environment } from '@environments/environment';

@Component({
  selector: 'app-new-issue-draft',
  templateUrl: './new-issue-draft.component.html',
  styleUrl: './new-issue-draft.component.css'
})
export class NewIssueDraftComponent {
  @ViewChild('EnterIssueID') EnterIssueID: any;

  contactForm: FormGroup;

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

  private apiurl = environment.apiurls;
  supportid: any;
  today: any;
  MAX_FILE_SIZE = 1024 * 1024 * 5
  selectedOption: string = '';
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
  IssueRaisedFor: string = '';
  Plant: string = '';
  supportteams: any[] = [];
  supportteamsforOthers: any[] = [];
  supportteamsforGuest: any[] = [];
  DisableissueRaiseFor: boolean = true;
  service: any = '';
  type: string = '';
  ShowSelf: boolean = true;
  ShowOthers: boolean = false;
  ShowGuest: boolean = false;
  EmployeeIDOthers: string = '';
  OthersName: string = '';
  EmailOthers: string = '';
  ContactNoOthers: string = '';
  ReportingManagerOthers: string = '';
  StaffCategoryOthers: string = '';
  PlantOthers: string = '';
  PaygroupOthers: string = '';
  DepartmentOthers: string = '';
  DesignationOthers: string = '';
  RoleOthers: string = '';
  GuestEmployeeID: string = '';
  GuestName: string = '';
  Guestemail: string = '';
  impactassetlist: any;
  GuestContactNo: string = '';
  ReportingManagerinML: string = '';
  StaffCategoryofML: string = '';
  GuestPlant: string = '';
  PaygroupML: string = '';
  DepartmentML: string = '';
  DesignationofMLManager: string = '';
  RoleofMLManager: string = '';
  supportnames: any[] = [];
  plantcode: any[] = [];
  ReportingManagerEmpID: string = '';
  allEmpList: any[] = [];
  supportteam: any[] = [];
  goBackDiscard: boolean = false;
  assignedplant: any;
  prDate: any;
  ProposedResolution: any;
  slaDeatils: any;
  user;
  attachmentsList: any = [];
  issueId: any;
  issueData: any;

  constructor(private http: HttpClient, private datepipe: DatePipe, private employeeInfo: GetEmployeeInfoService, private userInfo: UserInfoSerService, private route: Router, private routeservice: PasscrdataService,
    private router: ActivatedRoute, private helpdeskservice: HelpdeskserviceService, private fb: FormBuilder, public httpSer: HttpServiceService) {

    this.routeservice.getsupportteam();
    this.user = this.userInfo.getUser();
    this.router.paramMap.subscribe(params => {
      this.issueId = params.get('id');
    });
    this.supportid = this.user?.empData?.employeeNo;

    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });

    this.employeeInfo.suppTeamList().then(() => {
      this.supportteam = this.employeeInfo.SupportTeamList;
    });

    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);

    // this.helpdeskservice.UpdateNewIssuedata$.subscribe(data => {
    //   if (data && data.selectRowData) {
    //     this.selectRowData = data.selectRowData.rowData;
    //   }
    // })
    this.contactForm = this.fb.group({
      contactNo: [
        '',
        [Validators.required, Validators.pattern(/^\d{10}$/)]
      ]
    });
  }

  ngOnInit(): void {
    this.getIssueData()
    this.getsupportteams();
    this.priorityapi();
    this.OnLabelChange();
    this.getassets();
    this.getFileData();
  }

  getIssueData() {
    const apiUrls = this.apiurl + '/IssueList/Getissuelist';
    return this.http.get(apiUrls).toPromise()
      .then((response: any) => {
        this.issueData = response.filter((item: any) => item.issueId == this.issueId)[0];
        this.assignDraftData();
        this.getcategory();
      })
      .catch((error: any) => {
        throw error;
      });
  }

  async assignDraftData() {
    await this.getplant();

    if (this.issueData.issueSelectedfor == 'self') {
      this.selectedOption = 'self';
      this.DisableissueRaiseFor = true;
      this.ShowSelf = true;
      this.ShowOthers = false;
      this.ShowGuest = false;
      this.attachment = '';
      this.fetchAllItems();
    }

    if (this.issueData.issueSelectedfor == "others") {
      this.selectedOption = 'others';
      this.issueRaiseFor = this.issueData.issuerisedforid;
      this.DisableissueRaiseFor = false;
      this.ShowSelf = false;
      this.ShowOthers = true;
      this.ShowGuest = false;
      this.fetchAllItems();
    }

    if (this.issueData.issueSelectedfor == "guest") {
      this.selectedOption = 'guest';
      this.ReportingManagerEmpID = this.issueData.guestReportingManagerEmployeeId;
      this.DisableissueRaiseFor = true;
      this.ShowSelf = false;
      this.ShowOthers = false;
      this.ShowGuest = true;
      this.asset = '';
      this.impactassetlist = [];
      this.GuestEmployeeID = this.issueData.guestEmployeeId;
      this.GuestName = this.issueData.guestName;
      this.Guestemail = this.issueData.guestEmail;
      /*this.GuestContactNo = this.issueData.guestContactNo; */
      this.contactForm.patchValue({
        contactNo: this.issueData.guestContactNo
      })
      this.fetchAllItems();
    }

    this.plantId = this.issueData.plantname;
    if (this.plantId != '') {
      const foundplant = this.plantcode.find(row => row.code == this.plantId);
      if (foundplant) {
        this.plantId = foundplant.id.toString();
      }
    }

    this.categoryId = this.issueData.categoryName;
    if (this.categoryId != '') {
      const foundcategoryId = this.categorydata.find(row => row.categoryName == this.categoryId);
      if (foundcategoryId) {
        this.categoryId = foundcategoryId.itcategoryId.toString();
        // this.getcategorytype();
      }
    }
    try {
      // await this.getcategorytype();
      this.getCatType();
    } catch (error) {
      console.error('Error fetching items:', error);
    }

    this.priority = this.issueData.priorityName;
    if (this.priority != '') {
      const foundpriority = this.prioritytype.find(row => row.priorityName == this.priority);
      if (foundpriority) {
        this.priority = foundpriority.priorityId.toString();
      }
    }

    this.assignedTo = this.issueData.assignedToid;
    this.selectedOption = this.issueData.issueSelectedfor;
    this.ProposedResolution = this.issueData.proposedResolutionOn;
    this.source = this.issueData.source;
    this.type = this.issueData.type;
    this.Subject = this.issueData.issueShotDesc;
    this.issueDesc = this.issueData.issueDesc;
    this.attachment = this.issueData.attachment;
    this.asset = this.issueData.assetId;
  }

  getFileData() {
    let url = `/IssueList/GetFileData`
    let param = {
      srId: this.issueId
    }
    this.httpSer.httpGet(url, param).subscribe(res => {
      this.attachmentsList = res
    })
  }


  downFile(fileName: any): void {
    const apiUrl = `${this.apiurl}/IssueList/Download/${fileName.attachId}`

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

  
  getCatType() {
    this.categoryTypId = this.issueData.categoryType;
    if (this.categoryTypId != '') {
      const foundcategoryTypId = this.categorytype.find(row => row.categoryType == this.categoryTypId);
      if (foundcategoryTypId) {
        this.categoryTypId = foundcategoryTypId.categoryTypeId.toString();
      }
    }
  }

  /*-------------------------------------Impacted Asset DropDown--start -------------------- */
  asset: string = '';

  async getassets() {
    this.fetchAllItems().then(() => {
      const selectedOptionVal = this.selectedOption ? this.selectedOption : this.issueData.issueSelectedfor;
      if (selectedOptionVal == 'self' && this.EmployeeID != '') {
        this.OnlyAsset(this.EmployeeID);
      }
      if (selectedOptionVal == 'others' && this.EmployeeIDOthers != '') {
        this.OnlyAsset(this.EmployeeIDOthers);
      }
      if (selectedOptionVal == 'guest' && this.GuestEmployeeID != '') {
        this.OnlyAsset(this.GuestEmployeeID);
      }
    })
  }

  OnlyAsset(emp: any) {
    this.impactassetlist = [];
    const apiUrls = this.apiurl + '/GetAssets'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        const PlantFilter = this.plantcode.filter((row: any) => row.id == this.plantId)[0]?.code;
        const assetlist = response.filter((item: any) => parseInt(item.empNo) == parseInt(emp))
        this.impactassetlist = assetlist.filter((item: any) => item.location == PlantFilter);
        if (this.impactassetlist.length > 0) {
          this.asset = this.impactassetlist.find((row: any) => parseInt(row.assetId) == parseInt(this.issueData.assetId))[0].code;
        }
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }
  /*-------------------------------------Impacted Asset DropDown--end -------------------- */

  /*-------------------------------------Assign To  DropDown--start -------------------- */
  assignToList: any[] = [];

  async getAssignTo() {
    if (this.selectedOption == 'others' && this.issueRaiseFor == '') {
      alert('Select Self, Others or Guest');
      return
    }
    this.prDate = '';
    this.ProposedResolution = null;
    if (this.plantId == '') {
      alert('Select Plant')
    }
    // else if (this.categoryId == '') {
    //   // alert('Select Service Category')
    // }
    // else if (this.categoryTypId == '') {
    //   // alert('Select Sub-Category')
    // }
    else {
      this.assignToList = [];
      try {
        if (this.categoryId != null && this.categoryTypId != null) {
          this.getPrdate()
        }
        await this.employeeInfo.suppTeamList();
        if (this.supportteam) {
          const isHelpdeskSupport = this.supportteam.filter((item: any) => (item.isSuperAdmin || item.supportId == 3) && item.isActive);
          const isExecutive = isHelpdeskSupport.filter((row: any) => row.isSuperAdmin || row.isadmin || row.issupportengineer)
          const ServiceCategory = this.categorydata.filter((col: any) => col.itcategoryId == this.categoryId)[0]?.categoryName;
          const assignServiceCat = isExecutive.filter((item: any) => item.isSuperAdmin || item.categoryId == this.categoryId)
          const assignList = assignServiceCat.filter((item: any, i: any) => (item.isadmin || item.isSuperAdmin || item.categoryTypeId == this.categoryTypId) && assignServiceCat.map((a: any) => a.empId).indexOf(item.empId) == i)
          this.assignToList = assignList.filter((m:any)=> m.empId != Number(this.issueRaiseFor));
        }
      }
      catch (error) {
        console.error('GET request failed', error);
      }
    }
  }
  /*-------------------------------------Assign To DropDown--end -------------------- */

  ClearIssueDetailsInputs() {
    this.plantId = '';
    this.categoryId = '';
    this.categoryTypId = '';
    this.priority = '';
    this.type = '';
    this.source = '';
    this.assignedTo = '';
    this.Subject = '';
    this.issueDesc = '';
    this.attachment = '';
    this.asset = '';
    this.impactassetlist = [];
    this.ProposedResolution = null;
  }

  ClearGuestInputs() {
    this.GuestEmployeeID = '';
    this.GuestName = '';
    this.Guestemail = '';
    this.GuestContactNo = '';
    this.ReportingManagerEmpID = '';
    this.ReportingManagerinML = '';
    this.StaffCategoryofML = '';
    this.GuestPlant = '';
    this.PaygroupML = '';
    this.DepartmentML = '';
    this.DesignationofMLManager = '';
    this.RoleofMLManager = '';
  }

  ClearOtherInputs() {
    this.EmployeeIDOthers = '';
    this.OthersName = '';
    this.EmailOthers = '';
    this.ContactNoOthers = '';
    this.ReportingManagerOthers = '';
    this.StaffCategoryOthers = '';
    this.PlantOthers = '';
    this.PaygroupOthers = '';
    this.DepartmentOthers = '';
    this.DesignationOthers = '';
    this.RoleOthers = '';
  }

  ClearGuestOtherInputs() {
    this.ReportingManagerinML = '';
    this.StaffCategoryofML = '';
    this.GuestPlant = '';
    this.PaygroupML = '';
    this.DepartmentML = '';
    this.DesignationofMLManager = '';
    this.RoleofMLManager = '';
  }

  ClearSelfInputs() {
    this.EmployeeID = '';
    this.Name = '  ';
    this.Email = '';
    this.ContactNo = '';
    this.ReportingManager = '';
    this.StaffCategory = '';
    this.Plant = '';
    this.Paygroup = '';
    this.Department = '';
    this.Designation = '';
    this.Role = '';
  }

  getInputDatas() {
    this.EmployeeID = this.supportteams[0]?.employeeId;
    this.Name = this.supportteams[0]?.employeeName;
    this.Email = this.supportteams[0]?.email;
    this.ContactNo = this.supportteams[0]?.phoneNumber;
    this.ReportingManager = this.supportteams[0]?.reportManagerName;
    this.StaffCategory = this.supportteams[0]?.staffCategory;
    this.Plant = this.supportteams[0]?.plantcode;
    this.Paygroup = this.supportteams[0]?.payGroup;
    this.Department = this.supportteams[0]?.department;
    this.Designation = this.supportteams[0]?.designation;
    this.Role = this.supportteams[0]?.role;
  }

  getOtherInputDatas() {
    this.EmployeeIDOthers = this.supportteamsforOthers[0]?.employeeId;
    this.OthersName = this.supportteamsforOthers[0]?.employeeName;
    this.EmailOthers = this.supportteamsforOthers[0]?.email;
    this.ContactNoOthers = this.supportteamsforOthers[0]?.phoneNumber;
    this.ReportingManagerOthers = this.supportteamsforOthers[0]?.reportManagerName;
    this.StaffCategoryOthers = this.supportteamsforOthers[0]?.staffCategory;
    this.PlantOthers = this.supportteamsforOthers[0]?.plantcode;
    this.PaygroupOthers = this.supportteamsforOthers[0]?.payGroup;
    this.DepartmentOthers = this.supportteamsforOthers[0]?.department;
    this.DesignationOthers = this.supportteamsforOthers[0]?.designation;
    this.RoleOthers = this.supportteamsforOthers[0]?.role;
  }

  getGuestInputDatas() {
    this.ReportingManagerinML = this.supportteamsforGuest[0]?.reportManagerName;
    this.StaffCategoryofML = this.supportteamsforGuest[0]?.staffCategory;
    this.GuestPlant = this.supportteamsforGuest[0]?.plantcode;
    this.PaygroupML = this.supportteamsforGuest[0]?.payGroup;
    this.DepartmentML = this.supportteamsforGuest[0]?.department;
    this.DesignationofMLManager = this.supportteamsforGuest[0]?.designation;
    this.RoleofMLManager = this.supportteamsforGuest[0]?.role;
  }

  async OnLabelChange() {
    if (this.selectedOption) {
      this.ClearSelfInputs();
      this.ClearOtherInputs();
      this.ClearGuestInputs();
      this.ClearIssueDetailsInputs();
      this.supportteams = [];
      this.supportteamsforOthers = [];
      this.supportteamsforGuest = [];
      this.issueRaiseFor = '';
      this.dropdownItems = [];
      this.dropdownItems2 = [];

      if (this.selectedOption === "self") {
        this.DisableissueRaiseFor = true;
        this.ShowSelf = true;
        this.ShowOthers = false;
        this.ShowGuest = false;
      }
      else if (this.selectedOption === "others") {
        setTimeout(() => {
          this.EnterIssueID.nativeElement.focus();
        }, 0);
        this.DisableissueRaiseFor = false;
        this.ShowSelf = false;
        this.ShowOthers = true;

        this.ShowGuest = false;
      }
      else if (this.selectedOption === "guest") {
        this.DisableissueRaiseFor = true;
        this.ShowSelf = false;
        this.ShowOthers = false;
        this.ShowGuest = true;
        this.asset = '';
        this.impactassetlist = [];
      }

      this.supportid = this.routeservice.supporterID;
      try {
        await this.fetchAllItems();
      } catch (error) {
        console.error('Error fetching items:', error);
      }

    }
  }

  deleteDoc(Doc: any) {
    let url = '/IssueList/Delete/' + Doc.attachId
    this.httpSer.httpDelete(url).subscribe(res => {
      this.attachmentsList = this.attachmentsList.filter((m: any) => Doc.attachId != m.attachId)
    })
  }
  getplant() {
    const apiUrls = this.apiurl + '/Plantid'
    return this.http.get(apiUrls).toPromise()
      .then((response: any) => {
        const empPlant = this.user.empData.plantId;
        this.plantcode = response.filter((item: any) => parseInt(item.id) == parseInt(empPlant));
      })
      .catch((error: any) => {
        console.error('GET request failed', error);
        throw error;
      });
  }


  supportteamassign: any[] = [];
  mapcategory: any;
  assignedcat: any;
  getsupportid: any;

  async getsupportteams() {
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        const supportTeam = this.supportteam.filter((row: any) => row.empId === parseInt(this.supportid.trim()));
        this.getsupportid = supportTeam[0]?.supportTeamId;
        this.getsupportteamassign();
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  async getsupportteamassign() {
    const apiUrls = this.apiurl + '/SupportteamAssigned'
    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.supportteamassign = response.filter((row: any) => row.supportTeamId === parseInt(this.getsupportid));
        const mapplant = this.supportteamassign.map((item: any) => item.plantId);
        this.assignedplant = Array.from(new Set(mapplant));
        this.mapcategory = this.supportteamassign.map((item: any) => item.categoryId);
        this.assignedcat = Array.from(new Set(this.mapcategory));
        this.getplant();
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  categorydata: any[] = [];

  getcategory() {
    const apiUrls = this.apiurl + '/Category'
    return this.http.get(apiUrls).toPromise()
      .then((response: any) => {
        this.categorydata = response.filter((m: any) => m.isActive);
        if (this.issueData) {
          this.categoryId = this.issueData?.categoryId
          this.getcategorytype();
        }
      })
      .catch((error: any) => {
        console.error('GET request failed', error);
        throw error;
      });
  }

  categorytype: any[] = [];

  getcategorytype() {
    this.assignToList = [];
    this.assignedTo = '';
    this.categorytype = [];
    this.categoryTypId = '';
    this.prDate = '';
    this.ProposedResolution = null;
    const apiUrls = this.apiurl + '/CategoryTyp'
    return this.http.get(apiUrls).toPromise()
      .then((response: any) => {
        if (this.categoryId == 1) {
          this.categorytype = [{
            categoryType: "Others"
          }];
          if (this.issueId) {
            this.categoryTypId = this.issueData?.categoryTypId

            this.getAssignTo();
          }
        }
        else {
          this.categorytype = response.filter((item: any) => item.isActive && item.categoryId === parseInt(this.categoryId))

          if (this.issueId) {
            this.categoryTypId = this.issueData?.categoryTypId

            this.getAssignTo();
          }
        }
      })
      .catch((error: any) => {
        throw error;
      });
  }

  prioritytype: any[] = [];

  priorityapi() {
    const apiUrls = this.apiurl + '/Priority'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.prioritytype = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  issueRaisedBy: any = '';
  issueDate: any = '';
  Subject: any = '';
  issueDesc: any = '';
  images: Array<{ name: string, type: string, url: string }> = [];
  issueRaiseFor: any = '';
  plantId: any = '';
  assetId: any = '';
  categoryId: any = '';
  categoryTypId: any = '';
  priority: any = '';
  source: any = '';
  attachment: any = '';
  status: any = '';
  assignedTo: any = '';
  assignedBy: any = '';
  assignedOn: any = '';
  remarks: any = '';
  issuesraisedfor: any = '';
  assignedtosearch: any = '';
  messagesuccess: boolean = false;
  messageerror: boolean = false;

  errorMessage: any = '';
  successMessage: any = '';

  clearErrorMessage() {
    this.errorMessage = '';
  }
  clearSuccessMessage() {
    this.successMessage = '';
  }

  private decodeHtmlEntities(encodedString: string): string {
    const textarea = document.createElement('textarea');
    textarea.innerHTML = encodedString;
    return textarea.textContent || textarea.innerText;
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

  /* handleFileInput(event: any) {
    const files: File[] = Array.from(event.target.files);
    this.images = [];

    files.forEach(file => {
      this.convertFileToBase64(file).then(base64 => {
        this.images.push({ name: file.name, type: file.type, url: base64 });
        this.issueDesc += `<img src="${base64}" alt="${file.name} width='100' height='100' ">`;
      });
    });
  } */

  onsubmit(status: any) {
    if (this.selectedOption == 'self') {
      if (status == "Draft") {
        this.ExecuteFunc(status);
      } else {
        this.ValidateExecuteFunc(status);
      }
    }

    if (this.selectedOption == 'others') {
      if (status == "Draft") {
        this.ExecuteFunc(status);
      } else {
        if (this.EmployeeIDOthers == '') {
          alert('Requested for Employeed ID is Required!');
        }
        else {
          this.ValidateExecuteFunc(status);
        }
      }
    }

    if (this.selectedOption == 'guest') {
      if (status == "Draft") {
        this.ExecuteFunc(status);
      }
      else {
        if (this.GuestName == '') {
          alert('Enter Guest Name');
        }
        else {
          this.ValidateExecuteFunc(status);
        }
      }
    }
  }

  ValidateExecuteFunc(status: any) {
    if (this.plantId == '') {
      alert('Select Plant');
    }
    else if (this.categoryId == '' || this.categoryId == null) {
      alert('Select Service-Category');
    }
    else if (this.categoryTypId == '' || this.categoryTypId == null) {
      alert('Select Sub-Category');
    }
    else if (this.priority == '') {
      alert('Select Priority');
    }
    else if (this.Subject == '') {
      alert('Enter Subject');
    }
    else if (this.issueDesc == '') {
      alert('Enter Description');
    }
    else {
      this.ExecuteFunc(status);
    }
  }

  private extractPlainText(html: string): string {
    const doc = new DOMParser().parseFromString(html, 'text/html');
    return doc.body.innerText.trim();
  }

  private extractImageUrls(html: string): string[] {
    const doc = new DOMParser().parseFromString(html, 'text/html');
    const images = doc.body.querySelectorAll('img');
    const urls = Array.from(images).map(img => img.getAttribute('src') || '');
    return urls;
  }

  private formatOutput(text: string, urls: string[]): string {
    let formattedOutput = text + '\n\n';
    urls.forEach(url => {
      formattedOutput += 'Image URL: ' + url + '\n';
    });
    return formattedOutput.trim();
  }
  attachfile: any = '';

  ExecuteFunc(status: any) {
    this.attachfile = this.selectedFile.name;
    if (this.attachfile == undefined) {
      this.attachfile = '';
    }
    const apiUrl = this.apiurl + '/IssueList/SaveIssue';

    const plainText = this.extractPlainText(this.issueDesc);
    const imageUrls = this.extractImageUrls(this.issueDesc);
    const formattedOutput = this.formatOutput(plainText, imageUrls);
    //const decodedDescData = this.decodeHtmlEntities(this.issueDesc);

    if (this.assignedTo == '' && status == "Submit") {
      var getStatus = "Open";
    }
    else if (status == "Submit" && this.assignedTo != '') {
      var getStatus = "In Progress";
    }
    else {
      var getStatus = "Draft";
    }

    if (this.assignedTo) {
      var AssignedBy = Number(this.EmployeeID);
      var getAssignTo = Number(this.assignedTo);
    } else {
      var getAssignTo = 0;
      var AssignedBy = 0;
    }

    const requestBody =
    {
      "flag": "U",
      "issueId": this.issueData?.issueId,
      "issueSelectedfor": this.selectedOption,
      "issueRaisedBy": Number(this.EmployeeID),
      "issueDate": this.today,
      "issueShotDesc": this.Subject,
      "issueDesc": formattedOutput,
      "issueRaiseFor": Number(this.EmployeeIDOthers) || Number(this.EmployeeID),
      "issueForGuest": "",
      "guestEmployeeId": Number(this.GuestEmployeeID) || 0,
      "guestName": this.GuestName,
      "guestEmail": this.Guestemail,
      "guestContactNo": this.contactForm.controls['contactNo']?.value?.toString().slice(0,10),
      "guestReportingManagerEmployeeId": this.ReportingManagerEmpID,
      "type": this.type,
      "guestCompany": "",
      "plantId": Number(this.plantId) || 0,
      "assetId": Number(this.asset) || 0,
      "categoryId": Number(this.categoryId) || 0,
      "categoryTypId": Number(this.categoryTypId) || 0,
      "priority": Number(this.priority),
      "source": this.source,
      "attachment": this.attachfile,
      "status": getStatus,
      "assignedTo": getAssignTo,
      "assignedBy": AssignedBy,
      "assignedOn": this.today,
      "remarks": "",
      "createdBy": Number(this.EmployeeID),
      "createdDt": this.today,
      "modifiedBy": Number(this.EmployeeID),
      "modifiedDt": this.today,
      "resolutionDt": new Date("01/01/01"),
      "proposedResolutionOn": this.prDate || null,
      "reasonID": 0
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    this.http.post(apiUrl, requestBody, httpOptions).subscribe(
      (response: any) => {
        this.messagesuccess = true
        // this.addFile(response.data?.issueID);
        if (response.type == "S" && status == "Draft") {
          alert("Issue Saved in Draft!");
          this.route.navigate(['/report_issue']);
        }
        else if (response.type == "S" && status == "Submit") {
          alert("Saved Successfully!");
          this.route.navigate(['/report_issue']);
          this.sendemailfrom(getStatus, formattedOutput);
        }
        else {
          alert("Error while saving!");
        }
      },
      (error: any) => {
        this.messageerror = true;
      });

  }

  selectedFile: any = '';
  getattach(event: any): void {
    this.selectedFile = event.target.files[0];
    console.log('attachments',this.selectedFile);
  }


  addFile(): void {
    if (!this.selectedFile) {
      console.error('No files selected.');
      return;
    }
    if (this.selectedFile.size > this.MAX_FILE_SIZE) {
      alert('File size must not exceed 5 MB.')
      return
    }

    const formData = new FormData();

    formData.append('file', this.selectedFile, this.selectedFile.name);
    formData.append('FileName', this.selectedFile.name);
    formData.append('Stage', this.selectedFile, 'N');
    formData.append('CreatedBy', this.selectedFile, this.user?.empData?.employeeNo);
    formData.append('ModifiedBy', this.selectedFile, this.user?.empData?.employeeNo);
    formData.append('IssueId', this.issueData?.issueId);

    const apiUrl = this.apiurl + '/IssueList/addFile';

    this.http.post(apiUrl, formData).subscribe(
      (response: any) => {
        this.attachmentsList.push({
          attachId: response?.attachId,
          fileName: this.selectedFile?.name,
          file: this.selectedFile
        })
        this.attachment = ''
        this.selectedFile = ''
      },
      (error: any) => {
        console.error('Error uploading files', error);
      }
    );
  }
  

  navigatesuccess() {
    this.route.navigate(['/report_issue']);
  }

  closeNotification() {
    this.messageerror = false;
  }

  dropdownItems: any[] = [];
  selectedValue: string = '';
  supportteamname: any[] = [];
  employeeprofile: any[] = [];
  supportpersonname = '';
  firstname: any;
  middlename: any;
  lastname: any;

  onInput(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.value.length > 10) {
      input.value = input.value.slice(0, 10);
    }
  }
  filterItems() {
    const filter = this.issueRaiseFor.toUpperCase().trim();
    const filteredItems = this.supportnames.filter(item =>
      item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
    );

    this.dropdownItems = filteredItems.filter((row: any) => row.employeeId !== this.user.empData.employeeNo);

    if (this.dropdownItems.length === 0 && filter !== '') {
      this.dropdownItems = [{ employeeId: '', employeeName: 'No name found' }];
    } else if (filter === '') {
      this.dropdownItems = [];
    }
  }

  dropdownItems2: any[] = [];

  filterItemsforGuest() {
    const filter = this.ReportingManagerEmpID.toUpperCase().trim();
    this.dropdownItems2 = this.supportnames.filter(item =>
      item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
    );
    if (this.dropdownItems2.length === 0 && filter !== '') {
      this.dropdownItems2 = [{ employeeId: '', employeeName: 'No name found' }];
    } else if (filter === '') {
      this.dropdownItems2.length = 0;
    }
  }
  
   async fetchAllItems() {
    try {
      await this.employeeInfo.empList();
      this.supportnames = this.allEmpList;
      this.supportteams = this.allEmpList.filter((row: any) => row.employeeId == parseInt(this.supportid.trim()));
      this.getInputDatas();
      if (this.selectedOption == "others") {
        this.supportteamsforOthers = this.allEmpList.filter((row: any) => row.employeeId == parseInt(this.issueRaiseFor));
        this.getOtherInputDatas();
      }
      if (this.selectedOption == "guest") {
        this.supportteamsforGuest = this.allEmpList.filter((row: any) => row.employeeId == parseInt(this.ReportingManagerEmpID.trim()));
        this.getGuestInputDatas();
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  async selectItem(item: any) {
    if (this.selectedOption == "others") {
      this.issueRaiseFor = item.employeeId;
      this.dropdownItems = [];
      try {
        await this.fetchAllItems();
      } catch (error) {
        console.error('Error fetching items:', error);
      }
    }

    if (this.selectedOption == "guest") {
      this.ReportingManagerEmpID = item.employeeId;
      this.dropdownItems2 = [];
      try {
        await this.fetchAllItems();
      } catch (error) {
        console.error('Error fetching items:', error);
      }
    }
  }

  
  async getSelectedData() {
    this.supportteams = [];
    try {
      await this.employeeInfo.suppTeamList();
      if (this.supportteam) {
        this.supportteams = this.supportteam.filter((row: any) => row.empId == parseInt(this.supportid.trim()));
        this.getInputDatas();
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }
  }

  dropdownItemscr: string[] = [];
  selectedValuecr: string = '';
  filterItemscr() {
    const filter = this.issueRaisedBy.toUpperCase();
    this.dropdownItemscr = this.supportteamname.filter(item =>
      item.toUpperCase().includes(filter)
    );
    if (this.dropdownItems.length === 0 && filter !== '') {
      this.dropdownItemscr.push('No name found');
    }
    else if (filter === '') {
      this.dropdownItemscr.length = 0
    }
  }

  selectItemcr(item: string) {
    this.selectedValuecr = item;
    this.issueRaisedBy = item;
    this.dropdownItemscr = [];
  }

  assigntofilter: any[] = [];

  dropdownItemsassign: string[] = [];
  selectedValueassign: string = '';
  filterItemsassign() {
    const filter = this.assignedTo.toUpperCase();
    this.dropdownItemsassign = this.assigntofilter.filter(item =>
      item.toUpperCase().includes(filter)
    );
    if (this.dropdownItems.length === 0 && filter !== '') {
      this.dropdownItemsassign.push('No name found');
    }
    else if (filter === '') {
      this.dropdownItemsassign.length = 0
    }
  }

  selectItemassign(item: string) {
    this.selectedValueassign = item;
    this.assignedTo = item;
    this.dropdownItemsassign = [];
  }

  getPrdate() {
    const apiUrls = '/SlaMaster/getSlaByCatId';

    let Param = {
      categoryId: this.categoryId,
      categoryTypeId: this.categoryTypId
    }
    this.httpSer.httpGet(apiUrls, Param).subscribe(m => {
      this.slaDeatils = m[0]
      const taskTracker = new TaskTracker(new Date(), this.slaDeatils?.waitTime);
      this.prDate = taskTracker.getEndDateFromCurrent(this.slaDeatils?.waitTime);
      this.ProposedResolution = this.formatDateTimeToInput(this.prDate);
    })
  }

  formatDateTimeToInput(date: Date): string {
    const year = date.getFullYear();
    const month = ('0' + (date.getMonth() + 1)).slice(-2);
    const day = ('0' + date.getDate()).slice(-2);
    const hours = ('0' + date.getHours()).slice(-2);
    const minutes = ('0' + date.getMinutes()).slice(-2);
    return `${year}-${month}-${day}T${hours}:${minutes}`;
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

  sendemailfrom(status: any, IssueDesc: any) {
    const apiUrl = this.apiurl + '/Email';
    const requestedDateTime: any = this.datepipe.transform(new Date(), 'dd/MMM/yyyy HH:mm:ss');
    const ProposedResolutionDate: any = this.datepipe.transform(this.prDate, 'dd/MMM/yyyy HH:mm:ss');
    var valueofName: any = this.Name;
    const PriorityName = this.prioritytype.filter(m => m.priorityId == parseInt(this.priority))[0].priorityName;
    const assigntoEmail = this.assignToList.filter(m => parseInt(m.empId) == parseInt(this.assignedTo))[0]?.email
    var valueofTo: any = this.Email;

    if (this.selectedOption === "self") {
    
      if (status == 'In Progress') {
        var valueofCC: any = assigntoEmail;
      } else {
        var valueofCC: any = '';
      }
      var valueofRequestorName: any = this.Name;
      var valueofPlantCode: any = this.Plant;
      var valueofDepartmentName: any = this.Department;
      var valueofPhoneNo: any = this.ContactNo;
    }
    else if (this.selectedOption === "others") {
     
      if (status == 'In Progress') {
        var valueofCC: any = assigntoEmail;
      } else {
        var valueofCC: any = this.Email;
      }
      var valueofRequestorName: any = this.OthersName;
      var valueofPlantCode: any = this.PlantOthers;
      var valueofDepartmentName: any = this.DepartmentOthers;
      var valueofPhoneNo: any = this.ContactNoOthers;
    }
    else if (this.selectedOption === "guest") {
      //var valueofTo: any = this.Email;
      if (status == 'In Progress') {
        var valueofCC: any = assigntoEmail;
      } else {
        var valueofCC: any = '';
      }
      var valueofRequestorName: any = this.Name;
      var valueofPlantCode: any = this.Plant;
      var valueofDepartmentName: any = this.Department;
      var valueofPhoneNo: any = this.ContactNo;
    }

    if (valueofPhoneNo == undefined || valueofPhoneNo == null) {
      var validPhoneNo: any = '';
    } else {
      var validPhoneNo: any = valueofPhoneNo.toString();
    }

    let to = valueofTo;
    let cc = valueofCC;
    const output = this.readHtmlFile('assets/issue-email.html');

    const populatedOutput = output
      .replace('${SubmitterName}', valueofName)
      .replace('${IssueID}', this.issueData.issueCode)
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

    const requestBody = {
      "to": (to).replace(/^,+|,+$/g, '').trim().replace(/\s+/g, ' '),
      "cc": (cc).replace(/^,+|,+$/g, '').trim().replace(/\s+/g, ' '),
      "subject": `Unnati: IT ISSUES: ${this.issueData.issueCode}: Logged`,
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

