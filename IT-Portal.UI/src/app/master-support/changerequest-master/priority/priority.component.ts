import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';


@Component({
  selector: 'app-priority',
  templateUrl: './priority.component.html',
  styleUrl: './priority.component.css'
})
export class PriorityComponent {

  priorityName: any = '';
  isActive: any = '';
  supportid: any;
  today: any;
  constructor(private http: HttpClient, private routeservice: PasscrdataService, private router: Router) {
     this.filteredData = this.Prioritty;
     const currentDate = new Date()
     this.today = currentDate.toISOString().slice(0, 10);

     this.routeservice.getsupportteam();
     this.supportid = this.routeservice.supporterID;
}

  ngOnInit() {
    this.getpriority();
    
   /* this.getpriority();
    this.getReference();
    this.getReferencetype();*/
  

  }
  private apiurl = environment.apiurls;

  Prioritty: any[] = [];
  filteredData: any[]; // Array to hold filtered data
  searchText: string = '';
  filterData() {
    this.filteredData = this.Prioritty.filter(item =>
      item.priorityName.toLowerCase().includes(this.searchText.toLowerCase())
    );
  }

  deleteconfirmation: boolean = false;
  deletepriorityId: any;
  deletepriorityName: any;
  deletecategoryName: any;
  deleteRow(priorityId: any, priorityName: any) {
    this.deletepriorityId = priorityId;
    this.deletepriorityName = priorityName;
    this.deleteconfirmation = true
  }

  deleteyes() {
    this.deleteconfirmation = false
    this.deletepriority()
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

  deletepriority() {

    const apiUrl = this.apiurl + '/Priority/PostPrority'
    const requestBody = {
      "flag": "D",
      "priorityID": this.deletepriorityId,
      "priorityName": this.deletepriorityName,
      "isActive": false,
      "createdBy": this.supportid,
      "createdDate": this.today,
      "updatedBy": this.supportid,
      "updatedDate": this.today

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
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
        this.Prioritty = response;
        this.filterData();
        console.log(this.Prioritty)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }
}
