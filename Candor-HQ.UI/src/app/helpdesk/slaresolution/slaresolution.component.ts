import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
// import { environment } from '/IT_Portal/IT-Portal/IT-Portal.UI/src/environments/environment'
import { PageEvent, MatPaginator } from '@angular/material/paginator';
import { HttpServiceService } from 'shared/services/http-service.service';
import * as jsPDF from 'jspdf';
import 'jspdf-autotable';
import * as XLSX from 'xlsx';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { environment } from '@environments/environment';

interface DropdownItem {
  item_id: number;
  item_text: string;  
}

@Component({
  selector: 'app-slaresolution',
  templateUrl: './slaresolution.component.html',
  styleUrl: './slaresolution.component.css'
})
export class SlaresolutionComponent {

  supportteams: any[] = [];
  plantcode: any[] = [];
  currentDate=new Date().toISOString().slice(0,10)
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
  issuelistvalue :any;
  issuelistFilterValue: any;
  Count:any;
  dropdownItems: any;
  allEmpList: any;
  supportnames: any;

  constructor(private fb:FormBuilder, private http:HttpClient,private httpSer:HttpServiceService,
    public employeeInfo : GetEmployeeInfoService) { }
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
    this.getIssuereportlist();
  }
  filterdropdown() {
    this.issuelistvalue = this.issuelist
    this.issuelistFilterValue = this.issuelistvalue.filter((m:any)=>{
      return (
        ((this.filterForm.controls['plantId'].value==null||
      this.filterForm.controls['plantId'].value.length==0)?true:(this.filterForm.controls['plantId'].value.map((b:any)=>{return b.item_id}).indexOf(m.plantId)!=-1))
      &&((this.filterForm.controls['Category'].value==null||
      this.filterForm.controls['Category'].value.length==0)?true:(this.filterForm.controls['Category'].value.map((a:any)=>{return a.item_id}).indexOf(m.itcategoryId)!=-1))
      
      &&((this.filterForm.controls['Priority'].value==''||this.filterForm.controls['Priority'].value==null)?
      true:(m.priorityid==this.filterForm.controls['Priority'].value))
      &&((this.filterForm.controls['Status'].value==''||this.filterForm.controls['Status'].value==null)?
      true:(m.status.trim()==this.filterForm.controls['Status'].value))
      &&((this.filterForm.controls['StartDate'].value==''||this.filterForm.controls['StartDate'].value==null)?
      true:(m.issueDate.split('T')[0]>this.filterForm.controls['StartDate'].value))
      &&((this.filterForm.controls['EndDate'].value==''||this.filterForm.controls['EndDate'].value==null)?
      true:(m.issueDate.split('T')[0]<=this.filterForm.controls['EndDate'].value))
      &&((this.filterForm.controls['assignTo'].value==0||this.filterForm.controls['assignTo'].value==null)?
      true:(m.assignedToId==this.filterForm.controls['assignTo'].value))
      )
    })
    this.issuelistFilterValue = this.parseAndSortResponse(this.issuelistFilterValue)
    console.log('issue filtr val',this.issuelistFilterValue)
    this.issuelistFilterValue = this.issuelistFilterValue.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize);

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

  
  setFormControl(item:any){
    this.filterForm.controls['assignTo'].setValue(item.employeeId)
    this.dropdownItems = []
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
  fetchDropdownData(): void {
    const apiUrl = this.apiurl + '/Plantid';
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdownList = data.map(item => ({
          item_id: item.plantId,
          item_text: item.plantCode
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
        this.dropdowncategroy = data.map(item => ({
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
  getIssuereportlist(){
    let param = {
      pageNumber: this.pageIndex + 1,
      pageSize: this.pageSize,
      
    }
    const apiUrls = '/GetIssuseReport/IssueResolution';
    this.httpSer.httpGet(apiUrls, param).subscribe(

      (response: any) => {
        this.issuelist = response.data;
        this.totalItems =response.count;
        this.filterdropdown()
      },
      (error) => {
        throw error
      }
    )
  }
  onPageChange(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.getIssuereportlist();
  }

  exportexcel(): void {
    let element = document.getElementById('excel-table');
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(element);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, "IssueReport.xlsx");

  }

  exportToPDF() {
    
    const doc = new jsPDF.default('landscape');

    const tableElement = document.getElementById('excel-table');

    if (!tableElement) {
        console.error("Table element not found.");
        return;
    }

    const columns = Array.from(tableElement.querySelectorAll('thead th'))
        .slice(0, 14)
        .map(th => ({
            dataKey: th.textContent?.trim() || '',
            title: th.textContent?.trim() || '' 
        }));

    (doc as any).autoTable({
        head: [columns],
        body: Array.from(tableElement.querySelectorAll('tbody tr')).map(row => {
            return Array.from(row.querySelectorAll('td')).slice(0, 14).map(td => td.textContent || ''); // Ensure not null
        })
    });

    doc.save('Issue Resolution.pdf');
  }

}
