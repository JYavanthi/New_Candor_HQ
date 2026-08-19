import { transferArrayItem } from '@angular/cdk/drag-drop';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { HttpServiceService } from 'shared/services/http-service.service';
import { Router } from '@angular/router';
import * as XLSX from 'xlsx';
import * as jsPDF from 'jspdf';
import 'jspdf-autotable';
// import { FilterPipe } from '../filter.pipe';
import { FormBuilder, FormGroup } from '@angular/forms';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { FilterPipe } from 'app/project-managament-module/filter.pipe';
import { FormValidationService } from 'app/services/form-validation.service';

interface DropdownItem {
  item_id: number;
  item_text: string;
}


@Component({
  selector: 'app-projectreport',
  templateUrl: './projectreport.component.html',
  styleUrl: './projectreport.component.css',
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
export class ProjectreportComponent {
  @ViewChild('tableRef')
  tableRef!: ElementRef<HTMLTableElement>;
  fileName = 'Project Report.xlsx';
  filterVal: any
  projectManagementList: any;
  paginatedData: any;
  pageIndex: number = 0;
  pageSize: number = 20;
  totalItems = 0;
  searchText: any;
  filterForm!: FormGroup
  isVisible: any
  employeeList: any
  employeeList1: any
  groupList: any
  todayDate: any = new Date().toISOString().split('T')[0];


  constructor(private fb: FormBuilder, public employeeInfo: GetEmployeeInfoService,
    private httpSer: HttpServiceService) { }

  toggleVisibility() {
    this.isVisible = !this.isVisible;
  }
  ngOnInit(): void {
    this.getEmployee()
    this.formInIt()
    this.getGroupList()
    this.getProjectManagementList();
  }

  filterItemSponser() {
    var filter = this.filterForm.value.projectSponsor.toUpperCase().trim();
    this.employeeList1 = this.employeeInfo?.EmpList?.filter((item: any) =>
      item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
    );
    //alert('pro spon'+this.employeeList1.length);
    if (this.employeeList1.length === 0) {
      
      this.filterForm.get('projectSponsor')?.setValue('');
         alert('Enter Valid Project Sponsorer');
         this.employeeList.push('');
          this.employeeList = [];
         return;
    } else if (filter === '') {
      this.employeeList1.length = 0;
    }
  }

  async getEmployee() {
    await this.employeeInfo.empList()
    // this.filterItem()
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
    if (this.employeeList.length === 0) {
      this.filterForm.get('projectOwner')?.setValue('');
         alert('Enter Valid Project Owner');
         this.employeeList.push('');
          this.employeeList = [];
         return;
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
    this.paginatedData=0;
    this.pageIndex=0;
    this.filterVal = this.projectManagementList?.filter((m: any) => {
      return (
        (this.filterForm.controls['projectOwner'].value?.split('-')[0] == '' || this.filterForm.controls['projectOwner'].value?.split('-')[0] == null || m.projectOwner.toString() == this.filterForm.controls['projectOwner'].value.split('-')[0]) &&
        (this.filterForm.controls['projectSponsor'].value == '' || this.filterForm.controls['projectSponsor'].value.split('-')[0] == null || m.sponser == this.filterForm.controls['projectSponsor'].value.split('-')[0]) &&
        (this.filterForm.controls['projectGroup'].value == '' || this.filterForm.controls['projectGroup'].value == null || m.projectGroupId == this.filterForm.controls['projectGroup'].value) &&
        (this.filterForm.controls['status'].value == ''  || this.filterForm.controls['status'].value == null || m.projectStatus == this.filterForm.controls['status'].value) &&
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
    // this.filterForm.reset();
    this.employeeList = [];
    this.employeeList1 = [];
    this.filterForm.patchValue({
      projectOwner: '',
      projectSponsor: '',
      projectGroup: '',
      status: '',
      StartDate: '',
      EndDate: ''
    })
    this.getProjectManagementList();
  }

  searchTextFun() {
    this.paginatedData=0;
    let filetPipe = new FilterPipe().transform(this.projectManagementList, this.searchText)
    this.paginatedData = filetPipe?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
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
      .slice(0, 12)
      .map(th => ({
        dataKey: th.textContent?.trim() || '',
        title: th.textContent?.trim() || '',
        styles: { cellWidth: 'auto', maxCellWidth: 50 }
      }));

    (doc as any).autoTable({
      head: [columns],
      body: Array.from(tableElement.querySelectorAll('tbody tr')).map(row => {
        return Array.from(row.querySelectorAll('td')).slice(0, 12).map(td => td.textContent || '');
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

  getProjectManagementList() {
      this.paginatedData=0;
      this.pageIndex=0;
      this.httpSer.httpGet('/projectManagement/getProject').subscribe((response: any) => {
      this.projectManagementList = response.data;
      setTimeout(() => {
      this.filetSerList();
      this.paginatedData = this.projectManagementList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
      }, 100);
      
    })
  }

  onPageChange(event: any=null) {
    if(event){
      this.pageIndex = event?.pageIndex;
      this.pageSize = event?.pageSize;
    }
      this.paginatedData = this.filterVal?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
  }
}
