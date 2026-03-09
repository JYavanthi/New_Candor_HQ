import { transferArrayItem } from '@angular/cdk/drag-drop';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { HttpServiceService } from 'shared/services/http-service.service';
import { Router } from '@angular/router';
import * as XLSX from 'xlsx';
import { FilterPipe } from '../filter.pipe';
import { FormBuilder, FormGroup } from '@angular/forms';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
// import { FilterPipe } from '../filter.pipe';

@Component({
  selector: 'app-project-master',
  
  templateUrl: './project-master.component.html',
  
  styleUrl: './project-master.component.css',
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

export class ProjectMasterComponent {
  @ViewChild('tableRef')
  tableRef!: ElementRef<HTMLTableElement>;
  fileName = 'ProjectManagement Report.xlsx';
  filterVal:any
  projectManagementList: any;
  pageSize = 10
  pageIndex = 0
  paginatedData: any;
  searchText: any;
  filterForm!: FormGroup
  isVisible:any
  employeeList:any
  employeeList1:any
  groupList:any
  todayDate:any=new Date().toISOString().split('T')[0];
  constructor( private httpSer: HttpServiceService, private route : Router,
    public fb: FormBuilder, public employeeInfo: GetEmployeeInfoService
  ){}

  ngOnInit(){
    this.getEmployee()
    this.formInIt();
    this.getProjectManagementList();
    this.getGroupList()
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

  async getEmployee(){
    await this.employeeInfo.empList()
    // this.filterItem()
  }

  formInIt(){
    this.filterForm = this.fb.group({
      projectOwner: [''],
      projectSponsor: [''],
      projectGroup: [''],
      status: [''],
      StartDate: [''],
      EndDate: [''],
      paginatedData : [''],
      pageIndex: ['0'],
      pageSize: ['0'],
    })
  }
  exportexcel(): void {
    const element = this.tableRef.nativeElement;
    const rows = Array.from(element.querySelectorAll('tr'));
    const data = rows.map(row => {
    const cells = Array.from(row.querySelectorAll('th, td'));
    return cells.slice(0, 11).map(cell => cell.textContent?.trim() || '');
  });
    const ws: XLSX.WorkSheet = XLSX.utils.aoa_to_sheet(data);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, this.fileName);
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
    this.httpSer.httpGet('/projectGroup/getProjectGrops').subscribe((res:any)=>{
      this.groupList=res['data']
    })
  }
  selectSponser(item: any) {
    this.filterForm.patchValue({
      projectSponsor : item.employeeId?.trim() + '-' + item.employeeName?.trim(),
    })
    this.employeeList1 = [];
  }

  getProjectManagementList() {
    this.paginatedData=0;
    this.pageIndex=0;
    
    this.httpSer.httpGet('/projectManagement/getProject').subscribe((response : any)=>{
      this.projectManagementList = response.data
      this.filetSerList()
      this.paginatedData = this.projectManagementList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
    })
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
  reset(){

    this.filterForm.patchValue({
      projectOwner: '',
      projectSponsor: '',
      projectGroup: '',
      status: '',
      StartDate: '',
      EndDate: ''
    })
    this.filetSerList()
  }

  searchTextFun(){
    let filetPipe = new FilterPipe().transform(this.projectManagementList,this.searchText)
    this.paginatedData = filetPipe?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
  }

  navigateToEdit(projectID : any){
    this.route.navigate(['/projectmanagement'], { queryParams: { projectId: projectID} });
  }

  onPageChange(event: any=null) {
    if(event){
      this.pageIndex = event?.pageIndex;
      this.pageSize = event?.pageSize;
    }
      this.paginatedData = this.filterVal?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
  }

}
