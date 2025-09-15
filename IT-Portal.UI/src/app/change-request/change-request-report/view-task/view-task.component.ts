import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import * as XLSX from 'xlsx'; import { environment } from '@environments/environment';
import * as jsPDF from 'jspdf';
import 'jspdf-autotable';
import { DatePipe } from '@angular/common';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { debug } from 'console';
import { FormBuilder } from '@angular/forms';


interface DropdownItem {
  item_id: number;
  item_text: string;
}
@Component({
  selector: 'app-view-task',
  templateUrl: './view-task.component.html',
  styleUrl: './view-task.component.css'
})
export class ViewTaskComponent {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  isVisible = true;
  fileName = 'CRTaskReport.xlsx';
  filterForm: any;
  currentDate = new Date().toISOString().slice(0, 10);


  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.getviewcrdata()
  }
  private apiurl = environment.apiurls

  ngOnInit(): void {
    this.filterForm = this.fb.group({
      plantId: [],
      Category: [],
      ClassificationId: '',
      Priority: '',
      StartDate: '',
      EndDate: '',
      Status: '',
      stage:'',
      rfcChangeNumber: ''
    })
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
    const apiUrl = this.apiurl + '/Category' 
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdowncategroy = data.map(item => ({
          item_id: item.itcategoryId,
          item_text: item.categoryName 
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
    console.log('Plant', this.impactedLocation)
    this.selectedlocationNames = Array.from(new Set(this.impactedLocation));
  }
  mapedcategoryatas() {

    this.impactedLocation = this.selectedCategoryId.map((item: any) => item.item_id);
    console.log(this.impactedLocation)
    this.selectedcategroy = Array.from(new Set(this.impactedLocation));
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

    const apiUrls = this.apiurl + '/ViewExecuteReport/GetAllcrexecute';
    const requestBody = {}; 
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };

    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.rptfilter = response;
        this.viewchangerequest = this.parseAndSortResponse(this.rptfilter);
        console.log('getviewcrdata',this.viewchangerequest);
        this.filterdropdown();

        return this.viewchangerequest;
              
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
    this.viewchangerequest = this.viewchangerequest.filter(m => {
      return (
        ((this.filterForm.controls['plantId'].value == null ||
          this.filterForm.controls['plantId'].value.length == 0) ? true : (this.filterForm.controls['plantId'].value.map((b: any) => { return b.item_id }).indexOf(m.plantcode) != -1))
        && ((this.filterForm.controls['Category'].value == null ||
          this.filterForm.controls['Category'].value.length == 0) ? true : (this.filterForm.controls['Category'].value.map((a: any) => { return a.item_id }).indexOf(m.itcategoryId) != -1))
        && ((this.filterForm.controls['ClassificationId'].value == '' || this.filterForm.controls['ClassificationId'].value == null) ?
          true : (m.itclassificationId == this.filterForm.controls['ClassificationId'].value))
        && ((this.filterForm.controls['Priority'].value == '' || this.filterForm.controls['Priority'].value == null) ?
          true : (m.priorityType == this.filterForm.controls['Priority'].value))
        && ((this.filterForm.controls['stage'].value == '' || this.filterForm.controls['stage'].value == null) ?
          true : (m.stage == this.filterForm.controls['stage'].value))
        && ((this.filterForm.controls['Status'].value == '' || this.filterForm.controls['Status'].value == null) ?
          true : (m.status.trim() == this.filterForm.controls['Status'].value))
        && ((this.filterForm.controls['StartDate'].value == '' || this.filterForm.controls['StartDate'].value == null) ?
          true : (m.crdate.split('T')[0] > this.filterForm.controls['StartDate'].value))
        && ((this.filterForm.controls['EndDate'].value == '' || this.filterForm.controls['EndDate'].value == null) ?
          true : (m.crdate.split('T')[0] <= this.filterForm.controls['EndDate'].value))
        && ((this.filterForm.controls['rfcChangeNumber'].value == '' || this.filterForm.controls['rfcChangeNumber'].value == null) ?
          true : (m.crcode == this.filterForm.controls['rfcChangeNumber'].value))
       
      )
    })

    this.viewchangerequest = this.parseAndSortResponse(this.viewchangerequest)
    this.totalItems = this.viewchangerequest.length;
    //console.log('totalItems',this.totalItems)
    this.viewchangerequest = this.viewchangerequest.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize);

  }

  reset() {
    this.filterForm.reset()
    this.filterdropdown();
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
        this.classificationdata = response;
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

  exportexcel(): void {
    let element = document.getElementById('excel-table');
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(element);

    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');

    XLSX.writeFile(wb, this.fileName);

  }
  toggleVisibility() {
    this.isVisible = !this.isVisible;
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
        return Array.from(row.querySelectorAll('td')).slice(0, 14).map(td => td.textContent || '');
      })
    });

    doc.save('CRTaskReport.pdf');
  }
}
