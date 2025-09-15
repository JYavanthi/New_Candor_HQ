import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

@Component({
  selector: 'app-new-refrence-master',
  templateUrl: './new-refrence-master.component.html',
  styleUrl: './new-refrence-master.component.css'
})
export class NewRefrenceMasterComponent {
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
  referenceId: any = [];
  referenceName: any[] = [];
  isActive: any[] = [];

  today: any;
 
  postRefrencePost() {

    const apiUrl = this.apiurl + '/Reference/RefrencePost'
    const requestBody = {
      "flag": "I",
      "referenceID": 0,
      "referenceName": this.referenceName,
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
        this.router.navigate(['/Refrencemaster']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

}
