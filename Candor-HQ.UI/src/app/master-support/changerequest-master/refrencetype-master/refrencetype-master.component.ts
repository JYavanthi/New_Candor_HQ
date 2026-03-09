import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';


@Component({
  selector: 'app-refrencetype-master',
  templateUrl: './refrencetype-master.component.html',
  styleUrl: './refrencetype-master.component.css'
})
export class RefrencetypeMasterComponent {
  supportid: any = '';
  constructor(private http: HttpClient, private router: Router, private routeservice: PasscrdataService) {
    this.filteredData = this.Referencetype;
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
}

  ngOnInit() {

    this.getReferencetype();

  }
  private apiurl = environment.apiurls;

  filteredData: any[]; // Array to hold filtered data
  searchText: string = '';
  filterData() {
    this.filteredData = this.Referencetype.filter(item =>
      item.referenceType.toLowerCase().includes(this.searchText.toLowerCase())
    );
  }
  Referencetype: any[] = [];

  getReferencetype() {
    const apiUrls = this.apiurl + '/ReferenceType'
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
        this.Referencetype = response;
        this.filterData();
        console.log(this.Referencetype)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }
  //delete function
  deleteconfirmation: boolean = false;
  deletereferenceType: string = '';
  deletereferenceTypeId: any;
  deleteRow(referenceTypeId: any, referenceType: any) {
    this.deletereferenceTypeId = referenceTypeId;
    this.deletereferenceType = referenceType;
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
    
    
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const apiUrl = this.apiurl + '/ReferenceType/RefrencetypPost'
    const requestBody = {
      "flag": "D",
      "referenceTypeID": this.deletereferenceTypeId,
      "referenceType": this.deletereferenceType,
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
