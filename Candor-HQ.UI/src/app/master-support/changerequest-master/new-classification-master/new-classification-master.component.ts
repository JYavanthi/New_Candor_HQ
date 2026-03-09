import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

@Component({
  selector: 'app-new-classification-master',
  templateUrl: './new-classification-master.component.html',
  styleUrl: './new-classification-master.component.css'
})
export class NewClassificationMasterComponent {
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

  classificationname: any[] = [];
  today: any;
  classificationid: any[] = [];
  postClassification() {

    const apiUrl = this.apiurl + '/Classification/PostCategorytyp'
    const requestBody = {
      "flag": "I",
      "itClassificationID": this.classificationid,
      "classificationName": this.classificationname,
      "createdBy": this.supportid,
      "createdDt": this.today,
      "modifiedBy": this.supportid,
      "modifiedDt":this.today

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
        this.router.navigate(['/classification']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }


}
