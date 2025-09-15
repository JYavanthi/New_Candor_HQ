import { Component, ElementRef, ViewChild } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { HttpServiceService } from 'shared/services/http-service.service';
import { Router } from '@angular/router';
import * as XLSX from 'xlsx';
import { FormBuilder } from '@angular/forms';
import { PageEvent, MatPaginator } from '@angular/material/paginator';
import * as jsPDF from 'jspdf';
import 'jspdf-autotable';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';

interface DropdownItem {
  item_id: number;
  item_text: string;
}


@Component({
  selector: 'app-issuereport',
  templateUrl: './issuereport.component.html',
  styleUrl: './issuereport.component.css',
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
export class IssuereportComponent {
  @ViewChild('tableRef')
  tableRef!: ElementRef<HTMLTableElement>;
  fileName = 'ProjectIssue Report.xlsx';

  projectManagementList: any;
  paginatedData: any=[];

  supportteams: any[] = [];
  DisableissueRaiseFor: boolean = true;
  plantcode: any[] = [];
  prioritydata: any[] = [];
  categorydata: any[] = [];
  categorytype: any[] = [];
  subCat: any;
  dropdownList: DropdownItem[] = [];
  selectedPlantIds: any[] = [];
  impactedLocation: any = '';
  selectedlocationNames: any = '';
  dropdowncategroy: DropdownItem[] = [];
  selectedCategoryId: any[] = [];
  selectedcategroy: any = '';
  filtersdata: any[] = [];
  pageIndex: number = 0;
  pageSize: number = 20;
  totalItems = 0;
  issuelistvalue: any;
  issuelistFilterValue: any;
  currentDate = new Date().toISOString().slice(0, 10)
  supportnames: any;
  allEmpList: any;
  selectedOption: any;
  dropdownItems: any;
  taskList: any;
  projectId : any

      constructor(private fb:FormBuilder,public employeeInfo:GetEmployeeInfoService ,
        private http:HttpClient,private httpSer:HttpServiceService) { 
          this.getProjectManagementList()
        }
      filterForm: any;
      isVisible:boolean = false;
      issuelist : any;
      private apiurl = environment.apiurls
  
      
        toggleVisibility() {
          this.isVisible = !this.isVisible;
        }
        ngOnInit(): void {
          this.fetchAllItems()
          this.filterForm=this.fb.group({
            plantId:[],
            Category:[],
            subCategory:'',
            Priority:'',
            StartDate:'',
            EndDate:'',
            Status:'',
            rfcChangeNumber:'',
            assignTo:''
          })
          this.getplant();
          this.getcategory();
          this.getpriority();
          this.fetchDropdownData();
          this.fetchCategoryData();
          this.getTaskList();
        }
      
        filterItems() {
          const filter = this.filterForm.value.assignTo.toUpperCase().trim();
          const isUserItems = this.supportnames.filter((item:any) =>
            item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
          );
          this.dropdownItems = isUserItems.filter((row: any) => row.employeeId)
      
          if (this.dropdownItems.length === 0 && filter !== '') {
            this.dropdownItems = [{ employeeId: '', employeeName: 'No name found' }];
          } else if (filter === '') {
            this.dropdownItems = [];
          }
        }
      
      
        async fetchAllItems() {
          try {
            await this.employeeInfo.empList().then(() => {
              this.allEmpList = this.employeeInfo.EmpList;
            });
            this.supportnames = this.allEmpList;
      
          }
          catch (error) {
            console.error('GET request failed', error);
          }
        }
      
        setFormControl(item:any){
          this.filterForm.controls['assignTo'].setValue(item.employeeId)
          this.dropdownItems = []
        }
        filterdropdown() {
      
          this.issuelistvalue = this.issuelist
          this.issuelistFilterValue = this.issuelistvalue.filter((m:any)=>{
            return (
      
              ((this.filterForm.controls['plantId'].value==null||
            this.filterForm.controls['plantId'].value.length==0)?true:(this.filterForm.controls['plantId'].value.map((b:any)=>{return b.item_id}).indexOf(m.plantId)!=-1))
            &&((this.filterForm.controls['Category'].value==null||
            this.filterForm.controls['Category'].value.length==0)?true:(this.filterForm.controls['Category'].value.map((a:any)=>{return a.item_id}).indexOf(m.categoryId)!=-1))
      
            &&((this.filterForm.controls['Priority'].value==''||this.filterForm.controls['Priority'].value==null)?
            true:(m.priorityid==this.filterForm.controls['Priority'].value))
            &&((this.filterForm.controls['Status'].value==''||this.filterForm.controls['Status'].value==null)?
            true:(m.status.trim()==this.filterForm.controls['Status'].value))
            &&((this.filterForm.controls['StartDate'].value==''||this.filterForm.controls['StartDate'].value==null)?
            true:(m.issueDate.split('T')[0]>this.filterForm.controls['StartDate'].value))
            &&((this.filterForm.controls['EndDate'].value==''||this.filterForm.controls['EndDate'].value==null)?
            true:(m.issueDate.split('T')[0]<=this.filterForm.controls['EndDate'].value))
            &&((this.filterForm.controls['rfcChangeNumber'].value==''||this.filterForm.controls['rfcChangeNumber'].value==null)?
            true:(m.crcode==this.filterForm.controls['rfcChangeNumber'].value))
            &&((this.filterForm.controls['assignTo'].value==0||this.filterForm.controls['assignTo'].value==null)?
            true:(m.assignedToId==this.filterForm.controls['assignTo'].value))
            )
          })
          this.issuelistvalue = this.parseAndSortResponse(this.issuelistFilterValue)
          this.totalItems = this.issuelistvalue.length
          this.issuelistvalue = this.issuelistvalue.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize);
      
        }
        filteredData: any[] = []; // Array to hold filtered data
        viewchangerequestFiltered: any; // Array to hold selected statuses
      
        selectedStatus: { [key: string]: boolean } = {
          'All': false,
          'New': false,
          'Submit': false,
          'Approved': false,
          'Rejected': false,
          'Implement': false,
          'Pending': false,
          'Release': false,
          'Completed': false,
        };
        selectAll(event: any) {
          const isChecked = event.target.checked;
          const checkboxes = document.querySelectorAll('.cr_filter_checkbox');
      
          checkboxes.forEach((checkbox: any) => {
            checkbox.checked = isChecked;
            const label = checkbox.nextElementSibling;
            const labelText = label.textContent.trim();
            this.selectedStatus[labelText] = isChecked;
          });
      
          console.log("selectedStatus:", this.selectedStatus);
        };
      
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
        // Filter Function
      
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
      
        fetchCategoryData(): void {
          const apiUrl = this.apiurl + '/Category'
          this.http.get<any[]>(apiUrl).subscribe(
            (data) => {
              this.dropdowncategroy = data.filter((row:any)=>row.isActive).map(item => ({
                item_id: item.itcategoryId,
                item_text: item.categoryName
              }));
            },
            (error) => {
            }
          );
        }
      
        onOptionSelected(event:any){
          this.getTaskList(event.target.value);
        }


        getTaskList(value?: any) {
          this.httpSer.httpGet('/projectIssue/getProIssueByProId?id=' +value).subscribe((response: any) => {
            this.taskList = response.data;
            this.onPageChange()
          })
        }

        getProjectManagementList() {
          debugger
          this.httpSer.httpGet('/projectManagement/getProject').subscribe((response : any)=>{
            this.projectManagementList = response.data
          })
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
      
      
        applyFilters(item: any) {
          return (
            (this.filterForm.controls['plantId'].value == null || this.filterForm.controls['plantId'].value.length == 0 || this.filterForm.controls['plantId'].value.map((b: any) => b.item_id).indexOf(item.plantId) != -1) &&
            (this.filterForm.controls['Category'].value == null || this.filterForm.controls['Category'].value.length == 0 || this.filterForm.controls['Category'].value.map((a: any) => a.item_id).indexOf(item.categoryId) != -1) &&
            (this.filterForm.controls['subCategory'].value == '' || this.filterForm.controls['subCategory'].value == null || item.categoryTypId == this.filterForm.controls['subCategory'].value) &&
            (this.filterForm.controls['Priority'].value == '' || this.filterForm.controls['Priority'].value == null || item.priorityid == this.filterForm.controls['Priority'].value) &&
            (this.filterForm.controls['Status'].value == '' || this.filterForm.controls['Status'].value == null || item.status?.trim() == this.filterForm.controls['Status'].value) &&
            (this.filterForm.controls['StartDate'].value == '' || this.filterForm.controls['StartDate'].value == null || item.createdDt?.split('T')[0] >= this.filterForm.controls['StartDate'].value) &&
            (this.filterForm.controls['EndDate'].value == '' || this.filterForm.controls['EndDate'].value == null || item.createdDt?.split('T')[0] <= this.filterForm.controls['EndDate'].value)
          );
        }
        resetfn() {
          this.selectedPlantIds = [];
          this.selectedCategoryId = [];
          this.filterForm.reset();
          this.filterForm.controls['subCategory'].setValue('');
          this.filterForm.controls['Priority'].setValue('');
          this.filterForm.controls['Status'].setValue('');
          this.filterdropdown()
        }
      // End Filter
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
              .slice(0, 10)
              .map(th => ({
                  dataKey: th.textContent?.trim() || '',
                  title: th.textContent?.trim() || '',
                  styles: { cellWidth: 'auto', maxCellWidth: 50 }
              }));
      
          (doc as any).autoTable({
              head: [columns],
              body: Array.from(tableElement.querySelectorAll('tbody tr')).map(row => {
                  return Array.from(row.querySelectorAll('td')).slice(0, 10).map(td => td.textContent || '');
              }),
              styles: { overflow: 'linebreak' }, // Allow text to wrap
              columnStyles: {
                0: { maxCellWidth: 50 },
                1: { maxCellWidth: 50 },
                2: { maxCellWidth: 50 },
                3: { maxCellWidth: 50 },
                4: { maxCellWidth: 50 }
              }
          });
      
          doc.save('IssueReport.pdf');
        }
        onPageChange(event: any = null) {
          if (event) {
            this.pageIndex = event?.pageIndex;
            this.pageSize = event?.pageSize;
          }
          this.paginatedData = this.taskList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
        }
     
}
