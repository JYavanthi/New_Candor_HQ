import { Component, ElementRef, ViewChild } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { HttpServiceService } from 'shared/services/http-service.service';
import * as XLSX from 'xlsx';
import { FormBuilder } from '@angular/forms';
import * as jsPDF from 'jspdf';
import 'jspdf-autotable';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { FilterPipe } from 'app/project-managament-module/filter.pipe';
import { Router } from '@angular/router';


interface DropdownItem {
  item_id: number;
  item_text: string;
}


@Component({
  selector: 'app-taskreport',
  templateUrl: './taskreport.component.html',
  styleUrl: './taskreport.component.css',
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
export class taskreportComponent {
  @ViewChild('tableRef')
  tableRef!: ElementRef<HTMLTableElement>;
  fileName = 'projectTask Report.xlsx';
  filterWala: any
  projectManagementList: any;
  pageSize = 10
  pageIndex = 0
  taskListData: any[] = [];
  paginatedData: any[] = [];
  searchText: any;
  filterForm!: any;
  isVisible: any
  employeeList: any
  employeeList1: any
  groupList: any
  projectManagementList1: any;


  constructor(private fb: FormBuilder, public employeeInfo: GetEmployeeInfoService,
    private httpSer: HttpServiceService, private route: Router) { }
  // ngOnInit(): void {
  //   this.getProjectManagementList();
  //   this.getGroupList()
  //   this.formInIt()
  //   this.getPaginatedData();
  //   this.getProjectManagementList1();
  // }

  ngOnInit(): void {
    this.getProjectManagementList();
    this.getGroupList();
    this.formInIt();
    this.getProjectManagementList1();
  }


  filterItemSponser() {
    var filter = this.filterForm.value.projectSponsor.toUpperCase().trim();
    this.employeeList1 = this.employeeInfo?.EmpList?.filter((item: any) =>
      item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
    );
    if (this.employeeList1.length === 0 && filter === '') {
      this.employeeList.push('');
    } else if (filter === '') {
      this.employeeList1.length = 0;
    }
  }

  onOptionSelected(event: any) {
    const projectId = event.target.value;
    if (projectId) {
      this.getProjectTasksByProjectId(projectId);
    }
  }
  


  async getEmployee() {
    await this.employeeInfo.empList()
    this.filterItem()
  }

  formInIt() {
    this.filterForm = this.fb.group({
      projectOwner: [''],
      projectSponsor: [''],
      projectGroup: [''],
      status: [''],
      StartDate: [''],
      EndDate: ['']
    })
  }

  filterItem() {
    var filter = this.filterForm.value.projectOwner.toUpperCase().trim();
    this.employeeList = this.employeeInfo?.EmpList?.filter((item: any) =>
      item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
    );
    if (this.employeeList.length === 0 && filter === '') {
      this.employeeList.push('');
    } else if (filter === '') {
      this.employeeList.length = 0;
    }
  }
  getGroupList() {
    this.httpSer.httpGet('/projectGroup/getProjectGrops').subscribe((res: any) => {
      this.groupList = res['data']
    })
  }
  selectSponser(item: any) {
    this.filterForm.patchValue({
      projectSponsor: item.employeeId?.trim() + '-' + item.employeeName?.trim(),
    })
    this.employeeList1 = [];
  }

  filetSerList() {
    this.filterWala = this.projectManagementList?.filter((m: any) => {
      return (
        (this.filterForm.controls['projectOwner'].value?.split('-')[0] == '' || this.filterForm.controls['projectOwner'].value?.split('-')[0] == null || m.projectOwner.toString() == this.filterForm.controls['projectOwner'].value.split('-')[0]) &&
        (this.filterForm.controls['projectSponsor'].value == '' || this.filterForm.controls['projectSponsor'].value.split('-')[0] == null || m.projectOwner == this.filterForm.controls['projectSponsor'].value.split('-')[0]) &&
        (this.filterForm.controls['projectGroup'].value == '' || this.filterForm.controls['projectGroup'].value == null || m.projectGroupId == this.filterForm.controls['projectGroup'].value) &&
        (this.filterForm.controls['status'].value == '' || this.filterForm.controls['status'].value == null || m.projectStatus == this.filterForm.controls['status'].value) &&
        (this.filterForm.controls['StartDate'].value == '' || this.filterForm.controls['StartDate'].value == null || m.createdDt?.split('T')[0] >= this.filterForm.controls['StartDate'].value) &&
        (this.filterForm.controls['EndDate'].value == '' || this.filterForm.controls['EndDate'].value == null || m.createdDt?.split('T')[0] <= this.filterForm.controls['EndDate'].value)
      );
    })
    this.onPageChange()
  }

  selectItem(item: any) {
    this.filterForm.patchValue({
      projectOwner: item.employeeId?.trim() + '-' + item.employeeName?.trim(),
    })
    this.employeeList = [];
  }

  reset() {
    this.filterForm.reset()
  }

  searchTextFun() {
    this.paginatedData = this.projectManagementList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
  }

  getParentTaskList(projectId: any) {

    this.httpSer.httpGet('/projectTask/getTask?proId=' + projectId).subscribe((response: any) => {
      this.taskListData = response.data;
      this.onPageChange()
    })
  }


  // onPageChange(event: any = null) {
  //   if (event) {
  //     this.pageIndex = event?.pageIndex;
  //     this.pageSize = event?.pageSize;
  //   }
  //   this.paginatedData = this.projectManagementList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
  // }

  onPageChange(event: any = null) {
    if (event) {
      this.pageIndex = event.pageIndex;
      this.pageSize = event.pageSize;
    }
    this.paginateTasks();
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
      .slice(0, 6)
      .map(th => ({
        dataKey: th.textContent?.trim() || '',
        title: th.textContent?.trim() || '',
        styles: { cellWidth: 'auto', maxCellWidth: 50 }
      }));

    (doc as any).autoTable({
      head: [columns],
      body: Array.from(tableElement.querySelectorAll('tbody tr')).map(row => {
        return Array.from(row.querySelectorAll('td')).slice(0, 6).map(td => td.textContent || '');
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

    doc.save('ProjectReport.pdf');
  }

  // onOptionSelected(event: any) {
  //   this.getPaginatedData(event.target.value);
  // }


  getProjectTasksByProjectId(projectId: any) {
    this.httpSer.httpGet('/projectTask/getTask?proId=' + projectId).subscribe((response: any) => {
      this.taskListData = response.data || [];
      this.pageIndex = 0;
      this.paginateTasks();
    });
  }

  paginateTasks() {
    this.paginatedData = this.taskListData.slice(
      this.pageIndex * this.pageSize,
      (this.pageIndex + 1) * this.pageSize
    );
  }


  getPaginatedData(value?: any) {
    this.httpSer.httpGet('/projectManagement/getProIssue').subscribe((response: any) => {
      this.paginatedData = response.data;
    })
  }
  getProjectManagementList1() {
    this.httpSer.httpGet('/projectManagement/getProject').subscribe((response: any) => {
      this.projectManagementList1 = response.data
    })
  }

  getProjectManagementList() {
    this.httpSer.httpGet('/projectManagement/getProject').subscribe((response: any) => {
      this.projectManagementList = response.data;
      // this.paginatedData = this.projectManagementList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
    })
  }


}

