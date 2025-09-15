import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

@Component({
  selector: 'app-refrence-master',
  templateUrl: './refrence-master.component.html',
  styleUrl: './refrence-master.component.css'
})
export class RefrenceMasterComponent {
  supportid: any = '';
  constructor(private http: HttpClient, private router: Router, private routeservice:PasscrdataService) {
    this.filteredData = this.Reference;
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
}

  ngOnInit() {

    this.getReference();

  }
  private apiurl = environment.apiurls;


  filteredData: any[]; // Array to hold filtered data
  searchText: string = '';
  filterData() {
    this.filteredData = this.Reference.filter(item =>
      item.referenceName.toLowerCase().includes(this.searchText.toLowerCase())
    );
  }
  Reference: any[] = [];

  getReference() {
    const apiUrls = this.apiurl + '/Reference'
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
        this.Reference = response;
        this.filterData();
        console.log(this.Reference)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  //delete function
  deleteconfirmation: boolean = false;
  deletereferenceName: string = '';
  deletereferenceId: any;
  deleteRow(referenceId: any, referenceName: any) {
    this.deletereferenceId = referenceId;
    this.deletereferenceName = referenceName;
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
    
    const apiUrl = this.apiurl + '/Reference/RefrencePost'
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const requestBody = {
      "flag": "D",
      "referenceID": this.deletereferenceId,
      "referenceName": this.deletereferenceName,
      "isActive": false,
      "createdBy": this.supportid,
      "createdDate": this.today,
      "modifiedBy": this.supportid,
      "modifiedDate": this.today

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
