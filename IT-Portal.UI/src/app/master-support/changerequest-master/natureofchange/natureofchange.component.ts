import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';

@Component({
  selector: 'app-natureofchange',
  templateUrl: './natureofchange.component.html',
  styleUrl: './natureofchange.component.css'
})
export class NatureofchangeComponent {
  constructor(private http: HttpClient, private router: Router) {
    this.filteredData = this.Natureofchange;
}

  ngOnInit() {

    this.getnatureofchange();
  }
  private apiurl = environment.apiurls;

  Natureofchange: any[] = [];
  filteredData: any[]; // Array to hold filtered data
  searchText: string = '';
  filterData() {
    this.filteredData = this.Natureofchange.filter(item =>
      item.natureofChange.toLowerCase().includes(this.searchText.toLowerCase())
    );
  }
  getnatureofchange() {
    const apiUrls = this.apiurl + '/NatureofChange/ViewNatureofchange'
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
        this.Natureofchange = response;
        this.filterData();
        console.log(this.Natureofchange)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  deleteconfirmation: boolean = false;
  deletenatureofchangeid: any;
  deleteRow(delnatureofchangeid: any) {
    this.deletenatureofchangeid = delnatureofchangeid
    this.deleteconfirmation = true
  }

  deleteyes() {
    this.deleteconfirmation = false
    this.deletenatureofchange()
  }

  deleteno() {
    this.deleteconfirmation = false
  }

  responsefromdata: any[] = [];
  /*deletenatureofchange() {
    
    const apiUrl = this.apiurl + '/NatureofChange/postnatureofchange'
    const requestBody = {
      "flag": "D",
      "natureofChangeID": this.deletenatureofchangeid,
      "categoryID": 0,
      "natureofChange": "Null",
      "isActive": false,
      "createdBy": 0,
      "createdDate": "2024-05 - 14T06: 55: 37.900Z",
      "modifiedBy": 0,
      "modifiedDate": "2024-05 - 14T06: 55: 37.900Z"
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(apiUrl, requestBody, httpOptions).subscribe(
      (response: any) => {
        console.log(response);
        this.responsefromdata = response;
        alert("Saved Successfully!");
        this.router.navigate(['/natureofchange']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }*/
  deleteinprogress: boolean = false;
  deletesuccess: boolean = false;
  deletemessage: any = '';
  deleteinmessage: any = '';
  messageerror: boolean = false;
  errormessage: any;
  errorresponse: any;
  deletenatureofchange() {
    
    const apiUrl = this.apiurl + '/NatureofChange/postnatureofchange';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const requestBody = {
      "flag": "D",
      "natureofChangeID": this.deletenatureofchangeid,
      "categoryID": 0,
      "natureofChange": "Null",
      "isActive": false,
      "createdBy": 0,
      "createdDate": "2024-05-14T09:26:44.631Z",
      "modifiedBy": 0,
      "modifiedDate": "2024-05-14T09:26:44.631Z"
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
          this.messageerror = true;
          console.log('Post request failed', error);
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
