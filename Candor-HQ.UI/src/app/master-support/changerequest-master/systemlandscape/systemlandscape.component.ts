import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

@Component({
  selector: 'app-systemlandscape',
  templateUrl: './systemlandscape.component.html',
  styleUrl: './systemlandscape.component.css'
})
export class SystemlandscapeComponent {
  supportid: any = '';
  constructor(private http: HttpClient, private router: Router, private routeservice:PasscrdataService) {
    this.filteredData = this.systemlandscape;
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
}

  ngOnInit() {
  
    this.getsystemlandscape();

  }
  private apiurl = environment.apiurls;

  filteredData: any[]; // Array to hold filtered data
  searchText: string = '';
  filterData() {
    this.filteredData = this.systemlandscape.filter(item =>
      item.sysLandscape.toLowerCase().includes(this.searchText.toLowerCase())
    );
  }
  systemlandscape: any[] = [];

  getsystemlandscape() {
    const apiUrls = this.apiurl + '/SystemLandscape/ViewSystemLans'
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
        this.systemlandscape = response;
        this.filterData();
        console.log(this.systemlandscape)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }
  //delete function
  deleteconfirmation: boolean = false;
  deletecategoryId: string = '';
  deletesysLandscapeId: any;
  deleteclassificationnmae: any;
  deletesupportId: any;
  deletepriorityName: any;
  deletesysLandscape: any;
  deleteRow(sysLandscapeId: any, classificationId: any, supportId: any, priorityNum: any, sysLandscape: any, categoryId: any) {
    this.deletesysLandscapeId = sysLandscapeId;
    this.deleteclassificationnmae = classificationId;
    this.deletesupportId = supportId;
    this.deletepriorityName = priorityNum;
    this.deletesysLandscape = sysLandscape;
    this.deletecategoryId = categoryId;
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
  today: any = '';

  deleteSupportTeam() {
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
    
    const apiUrl = this.apiurl + '/SystemLandscapeSp/PostSystemLandscape'
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const requestBody = {
      "flag": "D",
      "sysLandscapeId": this.deletesysLandscapeId,
      "supportId": this.deletesupportId,
      "categoryId": this.deleteclassificationnmae,
      "classificationId": this.deletecategoryId ,
      "sysLandscape1": this.deletesysLandscape,
      "priorityNum": this.deletepriorityName,
      "isActive": false,
      "createdBy": this.supportid,
      "createdDt": this.today,
      "modifiedBy": this.supportid,
      "modifiedDt": this.today

    }
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
