import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { UserInfoSerService } from 'app/services/user-info-ser.service';import { environment } from '@environments/environment';
import 'jspdf-autotable';
import * as XLSX from 'xlsx';
import { jsPDF } from 'jspdf';
interface DropdownItem {
  item_id: number;
  item_text: string;
}
@Component({
  selector: 'app-cr-approved-report',
  templateUrl: './cr-approved-report.component.html',
  styleUrl: './cr-approved-report.component.css'
})

export class CrApprovedReportComponent {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  private apiurl = environment.apiurls
  fileName = 'CRApproverReport.xlsx';
  today: any;
  filterForm: any;
  loggedUer: any;
  constructor(private http: HttpClient,private fb:FormBuilder,
    public userInfo : UserInfoSerService
    ) {
    const currentDate = new Date()
    this.loggedUer = userInfo.getUser()
    this.getviewcrdata();
    this.today = currentDate.toISOString().slice(0, 10);
    //this.today = this.datepipe.transform(currentDate,'yyyyMMdd')
  }

  ngOnInit(): void {
    this.filterForm=this.fb.group({
      plantId:[],
      Category:[],
      ClassificationId:'',
      Priority:'',
      StartDate:'',
      EndDate:'',
      Status:'',
      rfcChangeNumber:'',
      stage:''
    })
    this.filterData();
    this.onload();
    this.getplant();
    this.getcategory();
    this.getclassification();
    this.getpriority();
    this.getviewcrdata();
    this.fetchDropdownData();
    this.fetchCategoryData();
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
  paginatedTableData: any[] = [];
  pageIndex = 0;
  pageSize = 10;
  totalItems = 0;
  onPageChange(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.getviewcrdata();
  }
  getviewcrdata() {
    
    const apiUrls = this.apiurl + '/ViewChangeRequest/getApprovedCR?apprId='+this.loggedUer?.supportTeamData?.empId;
    const requestBody = {}; // You can include request body if needed
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };

    this.http.get(apiUrls).subscribe(
      (response: any) => {
        console.log("rptfilter", response);
        // Parse and sort the response before assigning it to viewchangerequest
        this.rptfilter = response
        this.viewchangerequest = this.parseAndSortResponse(response);
        this.filterdropdown()
        // this.totalItems = this.viewchangerequest.length;
        // const startIndex = this.pageIndex * this.pageSize;
        // const endIndex = startIndex + this.pageSize;
        // this.viewchangerequest = this.viewchangerequest.slice(startIndex, endIndex);
        return this.viewchangerequest
      },
      (error) => {
        console.error("Get failed", error);
      }
    );
  }
  statusfilter: any;
  viewchangerequest: any[] = [];
  rptfilter: any = '';
  plantscode: any = '';
  categoryids: any = '';
  classificationid: any = '';
  prioritytypeid: any = '';
  fromDt: any = '';
  endDt: any = '';
  searchrfcnumber: any = '';
  filtersdata: any[] = [];
  filterdropdown() {
    this.viewchangerequest = this.rptfilter
    this.viewchangerequest = this.viewchangerequest.filter(m=>{
      return (
        ((this.filterForm.controls['plantId'].value==null||
      this.filterForm.controls['plantId'].value.length==0)?true:(this.filterForm.controls['plantId'].value.map((b:any)=>{return b.item_id}).indexOf(m.plantcode)!=-1))
      &&((this.filterForm.controls['Category'].value==null||
      this.filterForm.controls['Category'].value.length==0)?true:(this.filterForm.controls['Category'].value.map((a:any)=>{return a.item_id}).indexOf(m.itcategoryId)!=-1))
      &&((this.filterForm.controls['ClassificationId'].value==''||this.filterForm.controls['ClassificationId'].value==null)?
      true:(m.itclassificationId==this.filterForm.controls['ClassificationId'].value))
      &&((this.filterForm.controls['Priority'].value==''||this.filterForm.controls['Priority'].value==null)?
      true:(m.priorityType==this.filterForm.controls['Priority'].value))
      &&((this.filterForm.controls['Status'].value==''||this.filterForm.controls['Status'].value==null)?
      true:(m.status.trim()==this.filterForm.controls['Status'].value))
      &&((this.filterForm.controls['StartDate'].value==''||this.filterForm.controls['StartDate'].value==null)?
      true:(m.crdate.split('T')[0]>this.filterForm.controls['StartDate'].value))
      &&((this.filterForm.controls['EndDate'].value==''||this.filterForm.controls['EndDate'].value==null)?
      true:(m.crdate.split('T')[0]<=this.filterForm.controls['EndDate'].value))
      &&((this.filterForm.controls['rfcChangeNumber'].value==''||this.filterForm.controls['rfcChangeNumber'].value==null)?
      true:(m.crcode==this.filterForm.controls['rfcChangeNumber'].value))
      &&((this.filterForm.controls['stage'].value==''||this.filterForm.controls['stage'].value==null)?
      true:(m.stage==this.filterForm.controls['stage'].value))
      )
    })

    this.viewchangerequest = this.parseAndSortResponse(this.viewchangerequest)
    this.totalItems = this.viewchangerequest.length;
    this.viewchangerequest = this.viewchangerequest.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize);

  }

  // Filter
  isVisible = true;
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

    // Add other status values here
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
  tablevalueshow: boolean = false;

  dropdownList: DropdownItem[] = [];
  dropdowncategroy: DropdownItem[] = [];
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
        console.error('Error fetching dropdown data:', error);
      }
    );
  }

  fetchCategoryData(): void {
    const apiUrl = this.apiurl + '/Category' // Replace with your API endpoint
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdowncategroy = data.map(item => ({
          item_id: item.itcategoryId,
          item_text: item.categoryName // Assuming your API response has 'id' and 'name' fields
        }));
        console.log(this.dropdowncategroy);
      },
      (error) => {
        console.error('Error fetching dropdown data:', error);
      }
    );
  }

  selectedlocationNames: any = '';
  selectedcategroy: any = '';
  impactedLocation: any = '';
  selectedlocation: any = '';
  selectedPlantIds: any[] = [];
  selectedCategoryId: any[] = [];
  mapedplantdatas() {
    
    this.impactedLocation = this.selectedPlantIds.map((item: any) => item.item_id);
    console.log('Plant:',this.impactedLocation)
    this.selectedlocationNames = Array.from(new Set(this.impactedLocation));
  }
  filterdonutbyplant() {
    
    if (this.selectedlocationNames != '') {
      this.viewchangerequest = this.viewchangerequest.filter((item: any) => this.selectedlocationNames.includes(item.plantcode));
    }
    console.log("here is multi donut selected plantid", this.viewchangerequest)
  }
  mapedcategoryatas() {
    
    this.impactedLocation = this.selectedCategoryId.map((item: any) => item.item_id);
    console.log(this.impactedLocation)
    this.selectedcategroy = Array.from(new Set(this.impactedLocation));
  }
  filterData() {
    const selectedStatusKeys = Object.keys(this.selectedStatus);
    if (this.selectedStatus['']) {
      this.viewchangerequestFiltered = this.viewchangerequest;
      this.tablevalueshow = true;
      this.function();
    }
    else if (this.selectedStatus['All']) {
      this.viewchangerequestFiltered = this.viewchangerequest;
      this.tablevalueshow = true;
      this.function();
    } else {
      const filteredKeys = selectedStatusKeys.filter(key => this.selectedStatus[key]);
      this.viewchangerequestFiltered = this.viewchangerequest.filter(item => {
        const Statusfilter = item.status.trim();
        return filteredKeys.includes(Statusfilter);

      });
      this.tablevalueshow = true;
      this.function();
    }
    console.log('helloooooo', this.viewchangerequestFiltered)
  }
  tablevalue: any;
  function() {
    if (this.tablevalueshow == false) {
      this.tablevalue = this.viewchangerequest
    }
    else {
      this.tablevalue = this.viewchangerequestFiltered
    }
  }
  onload() {
    this.selectedStatus['All'] = true
    this.viewchangerequestFiltered = this.viewchangerequest;
  }


  exportexcel(): void {
    let element = document.getElementById('excel-table');
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(element);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, this.fileName);

  }

  exportToPDF() {
    const doc = new jsPDF('landscape');
    (doc as any).autoTable({ html: '#excel-table' });
    doc.save('ChangeRequestReport.pdf'); 
  }

  
  

  plantcode: any[] = [];

  getplant() {

    const apiUrls = this.apiurl + '/Plantid'
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        console.log(response);
        this.plantcode = response;
        console.log(this.plantcode)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  categorydata: any[] = [];
  
  getcategory() {

    const apiUrls = this.apiurl + '/Category'
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        console.log(response);
        this.categorydata = response.filter((item: any) => item.supportId === 1);
        console.log("category data test", this.categorydata)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  classificationdata: any[] = [];
  getclassification() {

    const apiUrls = this.apiurl + '/Classification'
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        console.log(response);
        this.classificationdata = response;
        console.log("classification data test", this.classificationdata)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  prioritydata: any[] = [];
  getpriority() {

    const apiUrls = this.apiurl + '/Priority'
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        console.log(response);
        this.prioritydata = response;
        console.log("Priority data test", this.prioritydata)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  reset(){
    this.filterForm.reset()
    this.filterdropdown();
  }
}