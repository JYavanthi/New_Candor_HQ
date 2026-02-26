import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ElementRef, ViewChild } from '@angular/core';
// import { environment } from '/IT_Portal/IT-Portal/IT-Portal.UI/src/environments/environment'
import { MatDialog } from '@angular/material/dialog';
import { IssueAssigntoComponent } from './issue-new-issue/issue-assignto/issue-assignto.component';
import { PasscrdataService } from '../../change-request/passcrdata.service';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { HelpdeskserviceService } from '../helpdeskservice.service';
import { FormBuilder } from '@angular/forms';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { HttpServiceService } from 'shared/services/http-service.service';
import { TaskTracker } from 'app/master-support/SLA/slamaster/trackSlaCal';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import * as XLSX from 'xlsx';
import * as jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';
import { DatePipe } from '@angular/common';
import { waitForDebugger } from 'node:inspector';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { Params } from '@angular/router';
import { environment } from '@environments/environment';

interface DropdownItem {
  item_id: number;
  item_text: string;
}

@Component({
  selector: 'app-report-issue',
  templateUrl: './report-issue.component.html',
  styleUrl: './report-issue.component.css',
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
export class ReportIssueComponent {
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  @ViewChild('tableRef')
  tableRef!: ElementRef<HTMLTableElement>;
  fileName = 'IssueListReport.xlsx';

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

  tableData: any[] = [];
  supportid: any;
  Allselected = false
  paginatedTableData: any[] = [];
  paginatedTableDataforIssue: any[] = [];
  pageIndex = 0;
  supportIssuepageIndex = 0;
  pageSize = 10;
  supportIssuepageSize = 10;
  totalItems = 0;
  supportIssuetotalItems = 0;
  editIndex: number = -1;
  DeleditIndex: number = -1;
  filterflag: boolean = false;
  subCat: any;
  isOpenIssues: boolean = true
  DisableAssign: boolean = true;
  DisableForward: boolean = true;
  DisableResolve: boolean = true;
  filterForm: any;


  currentDate=new Date().toISOString().slice(0,10);

  ShowAssignTo: boolean = false;
  ShowResolveDescription: boolean = false;
  SelectPlant: string = '';
  ServiceCategory: string = '';
  SelectSubCategory: string = '';
  assignedTo: string = '';
  AssignRemarks: string = '';
  BulkResolutionRemarks: any = '';
  supportIssueList: any[] = [];
  assignToList: any[] = [];
  OrAssignTo: string = 'Not Assigned';
  assignForward: string = 'Assign';
  user: any;
  fromSupportTeam: any;
  isExecutive: boolean = false
  isAdmin: boolean = false;
  isSuperAdmin: boolean = false;
  adminCatList: any;
  allEmpList: any;
  reAssign: string = '';
  isForwardReason: boolean = false;


  constructor(private http: HttpClient, private datepipe: DatePipe, private fb: FormBuilder, private router: Router, private helpdeskservice: HelpdeskserviceService, private route: Router,
    private dialog: MatDialog, private routeservice: PasscrdataService, public httpSer: HttpServiceService, public employeeInfo: GetEmployeeInfoService,
    private userInfo: UserInfoSerService) {
    this.user = this.userInfo.getUser();
    this.isSuperAdmin = this.user.supportTeamAssignList.filter((m: any) => m.isSuperAdmin && m.isActive).length > 0
    this.adminCatList = this.user.supportTeamAssignList.filter((m: any) => m.supportId == 3 && m.isAdmin && !m.isSuperAdmin && m.isActive)
    this.isAdmin = this.user.supportTeamAssignList.filter((m: any) => m.supportId == 3 && m.isAdmin && !m.isSuperAdmin && m.isActive).length > 0 && !this.isSuperAdmin
    this.isExecutive = (this.user.supportTeamAssignList.filter((m: any) => m.supportId == 3 && m.isSupportEngineer && !m.isAdmin && !m.isSuperAdmin && m.isActive).length > 0) && !this.isAdmin && !this.isSuperAdmin
    this.fromSupportTeam = this.isExecutive || this.isAdmin || this.isSuperAdmin;
    this.supportid = this.user?.supportTeamData?.empId;

    this.employeeInfo.empList().then(() => {
      this.allEmpList = this.employeeInfo.EmpList;
    });

  }
  private apiurl = environment.apiurls
  isVisible: boolean = false;
  empid: string = '';
  deleteconfirmation: boolean = false;

  toggleVisibility() {
    this.isVisible = !this.isVisible;
  }

  ShowIssue: boolean = false;

  ngOnInit(): void {
    if (!this.fromSupportTeam) {
      this.ShowMyIssue = true
      /* this.ShowIssueList2 = false; */

    }
    this.filterForm = this.fb.group({
      plantId: [],
      Category: [],
      subCategory: '',
      Priority: '',
      StartDate: '',
      EndDate: '',
      Status: '',
      rfcChangeNumber: ''
    })

    this.getsupportteams();
    this.getplant();
    this.getcategory();
    this.getpriority();
    this.fetchDropdownData();
    this.fetchCategoryData();
    this.getSelectedData();
  }

  exportexcel(): void {
    const element = this.tableRef.nativeElement;
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(element);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, this.fileName);
  }



  exportToPDF() {
    const doc = new jsPDF.default('landscape');

    const tableElement = document.getElementById('excel-table');

    if (!tableElement) {
        console.error("Table element not found.");
        return;
    }

    const columns = Array.from(tableElement.querySelectorAll('thead th'))
        .slice(0, 8)
        .map(th => ({
            dataKey: th.textContent?.trim() || '',
            title: th.textContent?.trim() || '',
            styles: { cellWidth: 'auto', maxCellWidth: 50 }
        }));

    (doc as any).autoTable({
        head: [columns],
        body: Array.from(tableElement.querySelectorAll('tbody tr')).map(row => {
            return Array.from(row.querySelectorAll('td')).slice(0, 8).map(td => td.textContent || '');
        }),
        styles: { overflow: 'linebreak' },
        columnStyles: {
            0: { maxCellWidth: 50 },
            1: { maxCellWidth: 50 },
            2: { maxCellWidth: 50 },
            3: { maxCellWidth: 50 },
            4: { maxCellWidth: 50 }
        }
    });

    doc.save('issueReport.pdf');
  }

  /*-----------------------Filter--------------------------------start*/

  dropdownList: DropdownItem[] = [];
  selectedPlantIds: any[] = [];
  impactedLocation: any = '';
  selectedlocationNames: any = '';
  dropdowncategroy: DropdownItem[] = [];
  selectedCategoryId: any[] = [];
  selectedcategroy: any = '';
  filtersdata: any[] = [];
  issuelist: any = '';
  categoryId: any = '';
  Category: any = '';
  /*MyIssues: string = 'MY ISSUES';*/
  isMyIssuesActive: boolean = true;
  ShowMyIssue: boolean = false;
  ShowIssueList: boolean = false;
  /* ShowIssueList2: boolean = false; */
  ToggleIssueList: boolean = true;
  exportpdf: boolean = true;

  openIssue() {
    this.isOpenIssues = true
    this.filterdropdown()
  }

  closeIssue() {
    this.isOpenIssues = false
    this.filterdropdown()
  }

  toggleMyIssuesList() {
    this.ClearAssign();
    this.DisableAssign = true;
    this.DisableForward = true;
    this.DisableResolve = true;
    this.ShowAssignTo = false;
    this.ShowResolveDescription = false;
    this.isMyIssuesActive = false;
    this.selectedRow = [];
    if (!this.isMyIssuesActive) {
      this.DisableAssign = true;
      this.DisableForward = true;
      this.DisableResolve = true;
      /*this.MyIssues = 'ISSUE LIST';*/
      this.ShowMyIssue = true;
      this.ToggleIssueList = false;
      this.exportpdf = false;
      this.getissuelist();
    }
  }
  toggleMyIssues() {
    this.ClearAssign();
    this.DisableAssign = true;
    this.DisableForward = true;
    this.DisableResolve = true;
    this.ShowAssignTo = false;
    this.ShowResolveDescription = false;
    this.isMyIssuesActive = true;

    this.selectedRow = [];
    if (this.isMyIssuesActive) {
      /*this.MyIssues = 'MY ISSUES';*/
      this.ShowMyIssue = false;
      this.ToggleIssueList = true;
      this.exportpdf = true;
      this.mergeIssueList();
    }
  }

  dropdownSettings = {
    idField: 'item_id',
    textField: 'item_text',
  };

  fetchDropdownData(): void {
    const apiUrl = this.apiurl + '/Plantid';
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdownList = data.map(item => ({
          item_id: item.id,
          item_text: item.code
        }));
      },
      (error) => {
      }
    );
  }


  /*selectAll(event: any) {
    if (event.checked) {
      this.paginatedTableDataforIssue.forEach(m => { m['selected'] = true })
    } else {
      this.paginatedTableDataforIssue.forEach(m => { m['selected'] = false
      })
    }
  }*/

  selectAll(event: any) {
    const isChecked = event.target.checked;
    this.paginatedTableDataforIssue.forEach(row => row.selected = isChecked);

    if (isChecked) {
      this.selectedRow = [...this.paginatedTableDataforIssue];
      //this.assignToList = this.selectedRow.map(row => row.assignedToid);
      this.assignByName = this.loggedInUser[0].firstName + ' ' + this.loggedInUser[0].middleName + ' ' + this.loggedInUser[0].lastName;
      this.AssignBy = this.supportid + ' ' + '-' + ' ' + this.assignByName;
    } else {
      this.selectedRow = [];
      this.assignToList = [];
      this.assignedTo = '';
    }
    console.log('this.selectedRow', this.selectedRow)
    this.updateButtonStates();
  }

  fetchCategoryData(): void {

    const apiUrl = this.apiurl + '/Category'
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdowncategroy = data.filter((row: any) => row.isActive).map(item => ({
          item_id: item.itcategoryId,
          item_text: item.categoryName
        }));
      },
      (error) => {
      }
    );
  }

  mapedplantdatas() {
    this.impactedLocation = this.selectedPlantIds?.map((item: any) => item.item_id);
    this.selectedlocationNames = Array.from(new Set(this.impactedLocation));
  }

  async mapedcategoryatas(event: any) {
    this.categorytype = [];
    this.subCat = [];
    this.filterForm.controls['subCategory'].setValue('');
    if (this.filterForm.controls['Category'].value == undefined || this.filterForm.controls['Category'].value == null || this.filterForm.controls['Category'].value == '') {
      this.categorytype = [];
    }
    else {
      await this.getcategorytype();
      this.categorytype = this.subCat.filter((m: any) => event?.map((a: any) => a.item_id).indexOf(m.categoryId) != -1)
      this.impactedLocation = this.selectedCategoryId?.map((item: any) => item.item_id);
      this.selectedcategroy = Array.from(new Set(this.impactedLocation));
    }
  }

  onclickfilter() {
    this.filterdropdown();
  }

  filterdropdown() {
    if (this.ShowMyIssue) {
      this.ShowAssignTo = false;
      this.paginatedTableData = this.issuelist.filter((m: any) => {
        return this.applyFilters(m);
      });
      this.paginatedTableData.sort((a, b) => {
        const numA = +a.issueCode.split('/').pop()!;
        const numB = +b.issueCode.split('/').pop()!;
        return numB - numA;
      });
      if (this.isOpenIssues) {
        this.paginatedTableData = this.paginatedTableData.filter((m: any) => {
          return !(m.status?.trim() == 'Closed' || m.status?.trim() == 'Cancelled')
        })
      } else {
        this.paginatedTableData = this.paginatedTableData.filter((m: any) => {
          return m.status?.trim() == 'Closed' || m.status?.trim() == 'Cancelled'
        })
      }
     
      this.slaStatusCal(this.paginatedTableData)
      this.totalItems = this.paginatedTableData.length;
      this.paginatedTableData = this.paginatedTableData.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize);
    }

    else {
      this.paginatedTableDataforIssue = this.IssueListData.filter(m => {
      return this.applyFilters(m);
      });

      this.paginatedTableDataforIssue = this.slaStatusCal(this.paginatedTableDataforIssue)
      this.paginatedTableDataforIssue.sort((a, b) => {
        const numA = +a.issueCode.split('/').pop()!;
        const numB = +b.issueCode.split('/').pop()!;
        return numB - numA;
      });
      this.supportIssuetotalItems = this.paginatedTableDataforIssue.length;
      this.paginatedTableDataforIssue = this.paginatedTableDataforIssue.slice(this.supportIssuepageIndex * this.supportIssuepageSize, (this.supportIssuepageIndex + 1) * this.supportIssuepageSize);
    }
  }

  slaStatusCal(dataArray: any) {
    dataArray.forEach((m: any) => {
      if (!m.slaTime) {
        return
      }
      const taskTracker = new TaskTracker(new Date(m.createdDt), m.slaTime);
      let taskStatus = taskTracker.getTaskStatus();
      m['slastatus'] = taskStatus
    })

    return dataArray
  }

  applyFilters(item: any) {
    console.log('filter',item)
    return (
      (this.filterForm.controls['plantId'].value == null || this.filterForm.controls['plantId'].value.length == 0 || this.filterForm.controls['plantId'].value.map((b: any) => b.item_id).indexOf(item.plantId) != -1) &&
      (this.filterForm.controls['Category'].value == null || this.filterForm.controls['Category'].value.length == 0 || this.filterForm.controls['Category'].value.map((a: any) => a.item_id).indexOf(item.categoryId) != -1) &&
      (this.filterForm.controls['subCategory'].value == '' || this.filterForm.controls['subCategory'].value == null || item.categoryTypId == this.filterForm.controls['subCategory'].value) &&
      (this.filterForm.controls['Priority'].value == '' || this.filterForm.controls['Priority'].value == null || item.priorityid == this.filterForm.controls['Priority'].value) &&
      (this.filterForm.controls['Status'].value == '' || this.filterForm.controls['Status'].value == null || item.status?.trim() == this.filterForm.controls['Status'].value?.trim()) &&
      (this.filterForm.controls['StartDate'].value == '' || this.filterForm.controls['StartDate'].value == null || item.createdDt?.split('T')[0] >= this.filterForm.controls['StartDate'].value) &&
      (this.filterForm.controls['EndDate'].value == '' || this.filterForm.controls['EndDate'].value == null || item.createdDt?.split('T')[0] <= this.filterForm.controls['EndDate'].value)
    );

  }

  resetfn() {
    this.selectedRow = [];
    this.selectedPlantIds = [];
    this.selectedCategoryId = [];
    this.Category = '';
    this.DisableAssign = true;
    this.DisableForward = true;
    this.DisableResolve = true;
    this.ShowAssignTo = false;
    this.ClearAssign();
    this.getissuelist();
    this.mergeIssueList();
    this.filterForm.reset();
    this.filterForm.controls['subCategory'].setValue('');
    this.filterForm.controls['Priority'].setValue('');
    this.filterForm.controls['Status'].setValue('');
  }

  /*-----------------------Filter--------------------------------end*/

  OnEdit(index: number) {
    /*
        let selectdata = [this.paginatedTableData[index]];*/
    let selectdata: any = [];
    selectdata.push(this.paginatedTableData[index])
    selectdata[0]['userRole'] = 'User'
    const selectRowData = {
      rowData: selectdata,
      issue: 'NewIssue'
    }
    if (selectdata[0].status.trim() == "Draft") {
      this.helpdeskservice.getUpdateNewIssueData({ selectRowData });
      this.route.navigate(['/new_issue_draft/' + selectdata[0].issueId + '/edit'])
    }
    else {
      this.helpdeskservice.getUpdateNewIssueData({ selectRowData });
      this.route.navigate(['/update_issue_resolution/' + selectdata[0].issueId + '/edit'], {
        queryParams: {
          onEdit: true
        }

      })
    }
  }

  selectedRow: any[] = [];
  AssignBy: string = '';
  assignByName: string = '';

  toggleRowSelection(row: any) {
     if (row.selected) {
      this.getAssignTo()
      this.selectedRow.push(row);
      //this.assignToList = this.selectedRow.map(row => row.assignedToid);
      this.assignByName = this.loggedInUser[0].firstName + ' ' + this.loggedInUser[0].middleName + ' ' + this.loggedInUser[0].lastName;
      this.AssignBy = this.supportid + ' ' + '-' + ' ' + this.assignByName;
    } else {
      this.selectedRow = this.selectedRow.filter((r) => r !== row);
      this.assignToList = this.selectedRow.map(row => !row.assignedToid);
      this.assignedTo = '';
    }

    this.Allselected = this.paginatedTableDataforIssue.every(item => item.selected);
    console.log('this.selectedRow', this.selectedRow)
    this.updateButtonStates();
  }


  updateButtonStates() {
    const statusCancelled = this.selectedRow.map(m => m.status.trim());
    const allRowsAssignedToEmpty = this.selectedRow.every(m => m.assignedTo.trim() === '');
    const allRowsAssignedTo = this.selectedRow.every(m => m.assignedTo.trim() !== '');
    const notClosed = !(statusCancelled.includes('Closed')||statusCancelled.includes('Cancelled'));

    const notResolved = !statusCancelled.includes('Resolved');

    if (this.selectedRow.length > 0 && allRowsAssignedToEmpty && notClosed ) {
      this.ClearAssign();
      this.DisableAssign = false;
      this.DisableForward = true;
      this.DisableResolve = true;
    }
    else if (this.selectedRow.length > 0 && allRowsAssignedTo && notClosed && notResolved ) {
      this.ClearAssign();
      this.DisableAssign = true;
      this.DisableForward = false;
      if (this.selectedRow.length > 0 && this.user.role.includes('Admin') && (parseInt(this.selectedRow[0].assignedToid) !== parseInt(this.user.empData.employeeNo))) {
        
        this.DisableResolve = true;
      } else if(!statusCancelled.includes('Open')) {
        this.DisableResolve = false;
      }
    }
    else {
      this.ClearAssign();
      this.DisableAssign = true;
      this.DisableForward = true;
      this.DisableResolve = true;
      this.ShowAssignTo = false;
      this.ShowResolveDescription = false;
    }
  }

  /*toggleRowSelection(row: any) {

    this.Allselected = this.paginatedTableDataforIssue.every(item => item.selected);
    if (row.selected) {
      this.selectedRow.push(row);
      this.assignToList = this.selectedRow.map(row => row.assignedToid);
      this.assignByName = this.loggedInUser[0].firstName + ' ' + this.loggedInUser[0].middleName + ' ' + this.loggedInUser[0].lastName;
      this.AssignBy = this.supportid ;
    }
    else {
      this.selectedRow = this.selectedRow.filter((r) => r !== row);
      this.assignToList = this.selectedRow.map(row => row.assignedToid);
      this.assignedTo = '';
    }
    const statusCancelled = this.selectedRow.map(m => m.status.trim());
    const allRowsAssignedToEmpty = this.selectedRow.every(m => m.assignedTo.trim() === '');
    const allRowsAssignedTo = this.selectedRow.every(m => m.assignedTo.trim() !== '');
    const notClosed = !statusCancelled.includes('Closed');
    const notResolved = !statusCancelled.includes('Resolved');

    if (this.selectedRow.length > 0 && allRowsAssignedToEmpty && notClosed) {
      this.ClearAssign();
      this.DisableAssign = false;
      this.DisableForward = true;
      this.DisableResolve = true;
    }
    else if (this.selectedRow.length > 0 && allRowsAssignedTo && notClosed && notResolved) {
      this.ClearAssign();
      this.DisableAssign = true;
      this.DisableForward = false;
      this.DisableResolve = false;
    }
    else {
      this.ClearAssign();
      this.DisableAssign = true;
      this.DisableForward = true;
      this.DisableResolve = true;
      this.ShowAssignTo = false;
      this.ShowResolveDescription = false;
    }
  }*/
  assignForwardTo: any = '';
  AssignTo(Val: any) {
    this.getAssignTo();
    if (Val == 'Assign') {
      this.isForwardReason = false;
      this.ShowAssignTo = !this.ShowAssignTo
      this.ShowResolveDescription = false;
      this.assignForwardTo = 'Assign'
      this.assignForward = "Open"
    } else if (Val == 'Open') {
      this.isForwardReason = true;
      this.ShowAssignTo = !this.ShowAssignTo
      this.ShowResolveDescription = false;
      this.assignForward = "Open";
      this.assignForwardTo = 'Re-Assign'
    }
  }

  getSelfData: any[] = [];
  getOthersData: any[] = [];
  getGuestData: any[] = [];

  async fetchAllItems() {
    try {
      await this.employeeInfo.empList();
      if (this.selectedRow[0].issueSelectedfor == 'self') {
        this.getSelfData = this.allEmpList.filter((row: any) => row.employeeId == parseInt(this.selectedRow[0].raisedbyid));
      }
      if (this.selectedRow[0].issueSelectedfor == 'others') {
        this.getOthersData = this.allEmpList.filter((row: any) => row.employeeId == parseInt(this.selectedRow[0].issuerisedforid))
      }
      if (this.selectedRow[0].issueSelectedfor == 'guest') {
        this.getGuestData = this.allEmpList.filter((row: any) => row.employeeId == parseInt(this.selectedRow[0].guestReportingManagerEmployeeId))
      }
    }
    catch (error) {
      console.error('GET request failed', error);
    }



  }

  sendemailfrom(status: any, IssueDesc: any, issueCode: any) {
    const apiUrl = this.apiurl + '/Email';
    const requestedDateTime: any = this.datepipe.transform(this.selectedRow[0].createdDt, 'dd/MMM/yyyy HH:mm:ss');
    const ProposedResolutionDate: any = this.datepipe.transform(this.selectedRow[0].proposedResolutionOn, 'dd/MMM/yyyy HH:mm:ss');
    var valueofName: any = this.selectedRow[0].issuerisedby;
    const PriorityName = this.selectedRow[0].priorityName;
    const assigntoEmail = this.assignToList.filter(m => parseInt(m.empId) == parseInt(this.assignedTo))[0]?.email
    var valueofTo: any = this.getSelfData[0].email;

    if (this.selectedRow[0].issueSelectedfor === "self") {
      //var valueofTo: any = this.getSelfData[0].email;
      if (status == 'In Progress') {
        var valueofCC: any = assigntoEmail;
      } else {
        var valueofCC: any = '';
      }
      var valueofRequestorName: any = this.getSelfData[0].employeeName;
      var valueofPlantCode: any = this.getSelfData[0].plantcode;
      var valueofDepartmentName: any = this.getSelfData[0].department;
      var valueofPhoneNo: any = this.getSelfData[0].phoneNumber;
    }
    else if (this.selectedRow[0].issueSelectedfor === "others") {
      //var valueofTo: any = this.getOthersData[0].email;
      if (status == 'In Progress') {
        var valueofCC: any = assigntoEmail;
      } else {
        var valueofCC: any = this.getOthersData[0].email;
      }
      var valueofRequestorName: any = this.getOthersData[0].employeeName;
      var valueofPlantCode: any = this.getOthersData[0].plantcode;
      var valueofDepartmentName: any = this.getOthersData[0].department;
      var valueofPhoneNo: any = this.getOthersData[0].phoneNumber;
    }
    else if (this.selectedRow[0].issueSelectedfor === "guest") {
      //var valueofTo: any = this.getGuestData[0].email;
      if (status == 'In Progress') {
        var valueofCC: any = assigntoEmail;
      } else {
        var valueofCC: any = '';
      }
      var valueofRequestorName: any = this.getSelfData[0].employeeName;
      var valueofPlantCode: any = this.getSelfData[0].plantcode;
      var valueofDepartmentName: any = this.getSelfData[0].department;
      var valueofPhoneNo: any = this.getSelfData[0].phoneNumber;
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
      .replace('${IssueID}', issueCode)
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
      "subject": `Unnati: IT ISSUES: ${issueCode}: Logged`,
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

  private sleep(ms: number) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

  // async bulkResolution(status: any): Promise<any> {
    
  //   if (this.selectedRow.length === 0) {
  //     alert('No items selected for resolution.');
  //     return;
  //   } else if (this.BulkResolutionRemarks === '' && this.isForwardReason) {
  //     alert('Please enter resolution remarks!');
  //     return;
  //   }
    
  //   await this.fetchAllItems();
  //   this.ShowAssignTo = false;
  //   this.ShowResolveDescription = false;
  //   const apiUrls = this.apiurl + '/IssueResolution/updateIssueStatusBulk';
  //   const apiPromises: any = [];
  //   const emailPromises: any = [];

  //   this.selectedRow.forEach(row => {
  //       const requestBody = {
  //       issueId: [row.issueId],
  //       status: status,
  //       message: this.BulkResolutionRemarks,
  //       modifiedBy: parseInt(this.user?.empData.employeeNo),
  //       assignTo: this.assignedTo ? parseInt(this.assignedTo) : 0,
  //       reasonId:0
  //     };
 
  //     const apiRequest = this.http.post(apiUrls, requestBody).toPromise();
  //     apiPromises.push(apiRequest);
      
  //       return Promise.all([Promise.all(apiPromises)]).then(([apiResponses]: [any[]]) => {
  //       let successCount = apiResponses.filter(response => response.type !== "E").length;


  //     })
  //     .catch((error: any) => {
  //       throw error;
  //     });
  //   });

  //   // return Promise.all([Promise.all(apiPromises), Promise.all(emailPromises)])
  //   //   .then(([apiResponses, emailResponses]: [any[], any[]]) => {
  //       return Promise.all([Promise.all(apiPromises)])
  //     .then(([apiResponses]: [any[]]) => {
  //       let successCount = apiResponses.filter(response => response.type !== "E").length;

        
  //       if (successCount === 1 || successCount > 1) {
  //         this.BulkResolutionRemarks = '';
  //         this.ShowResolveDescription = false;
  //         this.DisableAssign = true;
  //         this.DisableForward = true;
  //         this.DisableResolve = true;
  //         this.getissuelist();
  //         this.selectedRow = [];
  //         this.mergeIssueList();
  //       }

  //       if (successCount === 1) {
  //         alert((status == 'Resolved' ? 'Resolved' : 'Assigned') + ' Successfully!');
  //       } else if (successCount > 1) {
  //         alert(`Successfully Resolved/Assigned ${successCount} item(s)!`);
  //       } else {
  //         alert('No assignments were successfully completed.');
  //       }


  //     })
  //     .catch((error: any) => {
  //       throw error;
  //     });
  // }
  


async bulkResolution(status: any): Promise<any> {
    if (this.selectedRow.length === 0) {
        alert('No items selected for resolution.');
        return;
    } else if (this.BulkResolutionRemarks === '' && this.isForwardReason) {
        alert('Please enter resolution remarks!');
        return;
    }
    const delay = (ms: number) => new Promise(resolve => setTimeout(resolve, ms));
    await this.fetchAllItems();
    this.ShowAssignTo = false;
    this.ShowResolveDescription = false;

    const apiUrls = this.apiurl + '/IssueResolution/updateIssueStatusBulk';

    // Loop through the selected rows sequentially
    for (let i = 0; i < this.selectedRow.length; i++) {
        const row = this.selectedRow[i];
        const requestBody = {
            issueId: [row.issueId],
            status: status,
            message: this.BulkResolutionRemarks,
            modifiedBy: parseInt(this.user?.empData.employeeNo),
            assignTo: this.assignedTo ? parseInt(this.assignedTo) : 0,
            reasonId: 0
        };

        try {
            
            const response = await this.http.post(apiUrls, requestBody).toPromise();
            console.log(`Request for IssueID: ${row.issueId} completed successfully. Response: `, response);
            await delay(1500);  

        } catch (error) {
            
            console.error(`Error processing IssueID: ${row.issueId}`, error);
            alert(`Error updating Issue ID: ${row.issueId}`);
        }
    }

    alert(`Successfully Resolved/Assigned ${this.selectedRow.length} item(s)!`);
    
    this.BulkResolutionRemarks = '';
    this.ShowResolveDescription = false;
    this.DisableAssign = true;
    this.DisableForward = true;
    this.DisableResolve = true;
    this.getissuelist();
    this.selectedRow = [];
    this.mergeIssueList();

    
}


  Resolve() {
    this.ShowAssignTo = false;
    this.BulkResolutionRemarks = '';
    this.ShowResolveDescription = !this.ShowResolveDescription
  }




  ClearAssign() {
    this.SelectPlant = '';
    this.ServiceCategory = '';
    this.SelectSubCategory = '';
    this.assignedTo = '';
    this.AssignRemarks = '';
  }

  getAssignTo(): Promise<any> {
    this.assignToList = [];
    const apiUrls = this.apiurl + '/SupportTeam'
    return this.http.get(apiUrls).toPromise()
      .then((response: any) => {
        const isHelpdeskSupport = response.filter((item: any) => (item.supportId == 3 || item.isSuperAdmin) && item.isActive);
        if (this.isAdmin) {
          var isSupportExecutive = isHelpdeskSupport.filter((row: any) =>
            row.isSuperAdmin || row.issupportengineer || row.isadmin
          );
        }
        else {
          var isSupportExecutive = isHelpdeskSupport.filter((row: any) => row.isSuperAdmin || row.issupportengineer || row.isadmin);
        }
        const ServiceCategory = isSupportExecutive.filter((col: any) => col.isSuperAdmin || col.categoryId == this.selectedRow?.[0]?.categoryId);
        this.assignToList = ServiceCategory.filter((item: any, i: any) => (item.isadmin || item.isSuperAdmin || item.categoryTypeId == this.selectedRow?.[0]?.categoryTypId) && ServiceCategory.map((a: any) => a.empId).indexOf(item.empId) == i);

        if (this.assignForward == "Open") {
          this.assignToList = this.assignToList.filter((row: any, i: any) => row.empId !== this.selectedRow?.[0]?.assignedToid);
        }
      })
      .catch((error: any) => {
        throw error;
      });
  }



  Next(index: number) {
    let selectdata: any = [];
    selectdata.push(this.paginatedTableDataforIssue[index])
    selectdata[0]['userRole'] = 'Support Engineer'
    const selectedData = {
      rowData: selectdata,
      issue: 'IssueResolution'
    }
    this.helpdeskservice.getUpdateIssueResolutionData({ selectedData });
    this.route.navigate(['/update_issue_resolution/' + selectedData.rowData[0].issueId + '/edit'], {
      queryParams: {
        onEdit: false
      }
    })
  }

  deleteIndex!: number;
  deleteyes() {
    this.deleteconfirmation = false;
    const selectdata = [this.paginatedTableData[this.deleteIndex]];
    const ID = selectdata[0].issueId;
    const apiUrl = this.apiurl + '/IssueList/SaveIssue'
    const requestBody =
    {
      "flag": "D",
      "issueId": Number(ID),
      "issueSelectedfor": "string",
      "issueRaisedBy": 0,
      "issueDate": "2024-07-10T09:02:47.719Z",
      "issueShotDesc": "string",
      "issueDesc": "string",
      "issueRaiseFor": 0,
      "issueForGuest": "string",
      "guestEmployeeId": 0,
      "guestName": "string",
      "guestEmail": "string",
      "guestContactNo": "string",
      "guestReportingManagerEmployeeId": "string",
      "type": "string",
      "guestCompany": "string",
      "plantId": 0,
      "assetId": 0,
      "categoryId": 0,
      "categoryTypId": 0,
      "priority": 0,
      "source": "string",
      "attachment": "string",
      "status": "string",
      "assignedTo": 0,
      "assignedBy": 0,
      "assignedOn": "2024-07-10T09:02:47.719Z",
      "remarks": "string",
      "createdBy": 0,
      "createdDt": "2024-07-10T09:02:47.719Z",
      "modifiedBy": 0,
      "modifiedDt": "2024-07-10T09:02:47.719Z",
      "resolutionDt": new Date("01/01/01"),
      "reasonId": 0
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(apiUrl, requestBody, httpOptions).subscribe(
      (response: any) => {
        if (response.type == "S") {
          alert('Deleted Successfully!');
          this.getissuelist();
        } else {
          alert('Error!')
        }
      },
      (error: any) => {
      });
  }

  deleteno() {
    this.deleteconfirmation = false;
  }

  OnDelete(index: number) {
    this.deleteIndex = index;
    this.deleteconfirmation = true;
  }

  filterSupportIssueList: any[] = [];
  IssueListData: any[] = [];
  async mergeIssueList() {
    await this.getissuelist();

    if (this.isExecutive) {
      this.filterSupportIssueList = this.supportIssueList.filter(supsisueservice => {
        const match = this.loggedInUser.find(loginuser =>
          loginuser.categoryId === supsisueservice.categoryId && loginuser.categoryTypeId === supsisueservice.categoryTypId);
        return !!match;
      });
      this.IssueListData = this.filterSupportIssueList.filter((item: any) => parseInt(item.assignedToid) == parseInt(this.isHelpdesk[0].empId) || parseInt(item.assignedToid) == 0)
      this.filterdropdown();
    }
    else if (this.isAdmin) {
      this.filterSupportIssueList = this.supportIssueList.filter(supsisueservice => {
        const match = this.adminCatList.find((loginuser: any) =>
          loginuser.categoryId === supsisueservice.categoryId);
        return match ? true : false;
      });
      // this.IssueListData = this.filterSupportIssueList.filter((item: any) => parseInt(item.assignedToid) == parseInt(this.isHelpdesk[0].empId) || parseInt(item.assignedToid) == 0)
      this.IssueListData = this.filterSupportIssueList;
      this.filterdropdown();
    }
    else if (this.isSuperAdmin) {
      this.IssueListData = this.supportIssueList;
      this.filterdropdown();
    }

  }

  onPageChange(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.filterdropdown();
  }

  supportIssueonPageChange(event: PageEvent) {
    this.supportIssuepageIndex = event.pageIndex;
    this.supportIssuepageSize = event.pageSize;
    this.filterdropdown();
  }

  /*plantscode: string = '';*/
  categoryids: string = '';

  plantcode: any[] = [];

  getplant() {
    const apiUrls = this.apiurl + '/Plantid'
    const requestBody = {

    }
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        this.plantcode = response;
      },
      (error) => {
      }
    )
  }


  getSelectedData() {
    this.supportteams = [];
    const apiUrls = this.apiurl + '/SupportTeam'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.supportteams = response.filter((row: any) => row.empId == parseInt(this.supportid));
      },
      (error) => {
        throw error
      }
    )
  }

  categorytype: any[] = [];

  async getcategorytype() {
    const apiUrls = this.apiurl + '/CategoryTyp'

    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.subCat = response;
      } else {
      }
    } catch (error) {
    }
  }

  categorydata: any[] = [];

  getcategory() {
    const apiUrls = this.apiurl + '/Category'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.categorydata = response;
      },
      (error) => {
        throw error
      }
    )
  }

  prioritydata: any[] = [];
  getpriority() {
    const apiUrls = this.apiurl + '/Priority'

    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.prioritydata = response;
      },
      (error) => {
        throw error
      }
    )
  }

  openDialog(issueId: string): void {
    const dialogRef = this.dialog.open(IssueAssigntoComponent, {
      width: '33%',
      data: { issueId: issueId }
    });

    dialogRef.afterClosed().subscribe(result => {

    });
  }

  supportteams: any[] = [];
  loggedInUser: any[] = [];
  isHelpdesk: any[] = [];
  getsupportid: any;
  supportpersonname = '';
  firstname: any;
  middlename: any;
  lastname: any;
  HideUpdate: boolean = false;
  RoleSuperAdmin: boolean = false;
  RoleAdmin: boolean = false;

  getsupportteams() {
    const apiUrls = this.apiurl + '/SupportTeam';
    return this.http.get(apiUrls).toPromise()
      .then((response: any) => {
        this.supportteams = response.filter((row: any) => row.empId);
        this.getsupportid = this.supportteams[0].supportTeamId
        this.loggedInUser = response.filter((row: any) => row.empId == parseInt(this.supportid));
        this.isHelpdesk = this.loggedInUser.filter((row: any) => row.supportId == 3);
        this.showIssuesForSupport();
        this.getsupportteamassign()
        this.getissuelist();
        this.mergeIssueList();
      })
      .catch((error: any) => {
        throw error
      });
  }

  getissuelist() {
    const apiUrls = this.apiurl + '/IssueList/Getissuelist';
    return this.http.get(apiUrls).toPromise()
      .then((response: any) => {
        this.issuelist = response.filter((item: any) => item.raisedbyid === parseInt(this.user.empData.employeeNo) || item.issuerisedforid === parseInt(this.user.empData.employeeNo));
        this.filterdropdown();
        this.supportIssueList = response.filter((item: any) => item.status?.trim() != "Draft");
      })
      .catch((error: any) => {
        throw error;
      });
  }

  supportteamassign: any[] = [];
  ischangeanalyst: boolean = false;
  isapprover: boolean = false;
  issupportegineer: boolean = false;
  assignedplant: number = 0;
  getsupportteamassign() {
    const apiUrls = this.apiurl + '/SupportteamAssigned'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this
        this.supportteamassign = response.filter((row: any) => row.supportTeamId == parseInt(this.getsupportid));
        this.assignedplant = this.supportteamassign[0]?.plantId;
        this.isapprover = this.supportteamassign[0]?.isApprover;
        this.issupportegineer = this.supportteamassign[0]?.isSupportEngineer
        this.ischangeanalyst = this.supportteamassign[0]?.isChangeAnalyst
      },
      (error) => {
        throw error
      }
    )
  }

  GotoResolution() {
    this.router.navigate(['/issue_resolution']);
  }

  showIssuesForSupport() {
    if (this.fromSupportTeam) {
      this.ShowIssueList = true;
      /*     this.ShowIssueList2 = false;*/
    } else {
      this.ShowIssueList = false;
      /*  this.ShowIssueList2 = false;*/
    }

  }



}
