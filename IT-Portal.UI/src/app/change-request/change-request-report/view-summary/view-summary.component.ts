import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Component, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from '../../passcrdata.service';
import { environment } from '/IT_Portal/IT-Portal/IT-Portal.UI/src/environments/environment'
import 'jspdf-autotable';
import * as XLSX from 'xlsx';
import { jsPDF } from 'jspdf';
import { FormBuilder, FormGroup } from '@angular/forms';

interface DropdownItem {
  item_id: number;
  item_text: string;
}

@Component({
  selector: 'app-view-summary',
  templateUrl: './view-summary.component.html',
  styleUrl: './view-summary.component.css'
})
export class ViewSummaryComponent {
  showInitiator: boolean = false;
  showRiskQ: boolean = false;
  supportid: any;
  supportname: any;
  today: any;
  crid: any = '';
  categorydata: any;
  plantcode: any;
  dropdowncategroy: any;
  filterForm!:FormGroup
  viewchangerequest=[];
  currentDate=new Date().toISOString().slice(0,10);


  stustuList = [
    "Draft",
    "Pending Approval",
    "Approved level1",
    "Approved level2",
    "Approved level3",
    "Approved",
    "Implement",
    "Implemented",
    "Release",
    "Released",
    "Completed"
];
  count: any=[];

  constructor(private http: HttpClient, public fb: FormBuilder,private routeservice: PasscrdataService, private route: ActivatedRoute, private router: Router) {
    this.getChangeRequests();
  }
  private apiurl = environment.apiurls;

  ngOnInit(): void {
    /*  this.getsummaryreport();*/
    // this.filterdonutbyplant();
    this.getChangeRequests();
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
    this.getplant();

    this.getcategory();
    this.getclassification();
    this.getpriority();
    this.fetchDropdownData();
    this.fetchCategoryData();

  }

  reset(){
    this.filterForm.reset()
  }

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

  filterdropdown() {
    this.viewchangerequest = this.changerequest


    this.viewchangerequest = this.viewchangerequest.filter((m:any)=>{
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
    this.count= []
    this.stustuList.forEach((m:any)=>{
      this.count.push(this.getopenCount(m))
    })
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


  dropdownList: DropdownItem[] = [];
  dropdownSettings = {
    idField: 'item_id',
    textField: 'item_text',
  };



  selectedlocationNames: any='';
  impactedLocation: any = '';
  selectedlocation: any = '';
  selectedPlantIds: any[] = [];
  filterdata: any[] = [];


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
  exportToPDF() {
    const doc = new jsPDF('landscape');
    (doc as any).autoTable({ html: '#excel-table' });
    doc.save('CRSummaryReport.pdf');
  }

  fileName = 'CRSummaryReport.xlsx';
  exportexcel(): void {
    let element = document.getElementById('excel-table');
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(element);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, this.fileName);

  }


  code: any[] = [];
  changerequest = [];

  // statusList: string[] = ['Open', 'Completed', 'Draft', 'Pending', 'Approved', 'Implemented', 'Released', 'Closure', 'Rejected'];
  getChangeRequests(): void {
    const apiUrl = this.apiurl + '/ViewChangeRequest/ViewChangerequest';
    this.http.get(apiUrl).subscribe(
      (response: any) => {
        this.changerequest = response;
        this.viewchangerequest = response
        this.stustuList.forEach((m:any)=>{
          this.count.push(this.getopenCount(m))
        })
        this.code = [...new Set(response.map((item: any) => item.plantId))];
      },

      (error) => {
        console.error("Request failed", error);
      }
    );
  }
  mapedplantdatas() {
    this.impactedLocation = this.selectedPlantIds.map((item: any) => item.item_id);
    this.selectedlocationNames = Array.from(new Set(this.impactedLocation));
  }

  getopenCount(_status: string) {
    if(!this.viewchangerequest){
      return 0
    }
   return this.viewchangerequest.filter((m:any)=>{return m.status==_status}).length
  }

  navigateToOtherComponent(status:any) {
    this.filterForm.controls['Status'].setValue(status)
    this.router.navigate(['/filteredCRs'], { queryParams: this.filterForm.value });
  }
}
