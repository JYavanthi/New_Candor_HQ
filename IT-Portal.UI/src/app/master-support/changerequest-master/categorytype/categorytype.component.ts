import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';

@Component({
  selector: 'app-categorytype',
  templateUrl: './categorytype.component.html',
  styleUrl: './categorytype.component.css'
})
export class CategorytypeComponent {
  today: any = '';
  constructor(private http: HttpClient, private router: Router) {
    this.filteredData = this.categorytypedata;
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);

}

  ngOnInit() {
    this.getCategoryType();
  }
  private apiurl = environment.apiurls;

  categorytypedata: any[] = [];

  filteredData: any[]; // Array to hold filtered data
  searchText: string = '';
  filterData() {
    this.filteredData = this.categorytypedata.filter(item =>
      item.categoryType.toLowerCase().includes(this.searchText.toLowerCase())
    );
  }
  getCategoryType() {
    const apiUrls = this.apiurl + '/CategoryTyp/viewcattyp'
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
        this.categorytypedata = response;
        this.filterData();
        console.log(this.categorytypedata)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  deleteconfirmation: boolean = false;
  deletecategorytypeid: string='';
  deletecategoryid: any;
  deleteRow(categorytypeid: any,categoryid:any) {
    this.deletecategorytypeid = categorytypeid;
    this.deletecategoryid = categoryid;
    this.deleteconfirmation = true
  }

  deleteyes() {
    this.deleteconfirmation = false
    this.deleteSupportTeam()
  }

  deleteno() {
    this.deleteconfirmation = false
  }

  deleteinprogress: boolean = false;
  deletesuccess: boolean = false;
  deletemessage: any = '';
  deleteinmessage: any = '';
  messageerror: boolean = false;
  errormessage: any;
  errorresponse: any;

  deleteSupportTeam() {
    
    const apiUrl = this.apiurl + '/CategoryTyp/PostCategorytyp'
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const requestBody = {
      "flag": "D",
      "categoryTypeID": Number(this.deletecategorytypeid),
      "categoryID": Number(this.deletecategorytypeid),
      "categoryType": String(this.deletecategorytypeid),
      "isActive": false,
      "createdBy": 1,
      "createdDate": this.today,
      "modifiedBy":1,
      "modifiedDate": this.today
    };
    setTimeout(() => {
      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
          console.log("this is error response", response);
          this.errorresponse = response.type
          if (this.errorresponse == "E") {
            this.deleteinprogress = true;
            this.deleteinmessage = "There are open items it Can't be deleted"
          } else if (this.errorresponse == "S") {
            this.deletesuccess = true;
            this.deletemessage = "Deleted Successfully"
          }
        },
        (error: any) => {
          console.log('Post request failed', error);
          this.messageerror = true;
          this.errormessage = error;
        }
      );
    }, 500);
  }

  navigateinprogress() {
    this.deleteinprogress = false;
  }

  navigatesuccess() {
    this.deletesuccess = false;
    window.location.reload();
  }
}
