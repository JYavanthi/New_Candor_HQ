import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';


@Component({
  selector: 'app-new-refrencetype-master',
  templateUrl: './new-refrencetype-master.component.html',
  styleUrl: './new-refrencetype-master.component.css'
})
export class NewRefrencetypeMasterComponent {
  supportid: any;
  constructor(private http: HttpClient, private routeservice: PasscrdataService, private router: Router) {
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
  }

  ngOnInit() {

  }
  private apiurl = environment.apiurls;



  today: any;
  isActive: any[] = [];
  referenceTypeId: any[] = [];
  referenceType: any[] = [];

  postReferenceType() {

    const apiUrl = this.apiurl + '/ReferenceType/RefrencetypPost'
    const requestBody = {
      "flag": "I",
      "referenceTypeID": this.referenceTypeId,
      "referenceType": this.referenceType,
      "isActive": this.isActive,
      "createdBy": this.supportid,
      "createdDate": this.today,
      "modifiedBy": this.supportid,
      "modifiedDate": this.today
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(apiUrl, requestBody, httpOptions).subscribe(
      (response: any) => {
        console.log(response);
        alert("Saved Successfully!");
        this.router.navigate(['/Refrencetype']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

}
