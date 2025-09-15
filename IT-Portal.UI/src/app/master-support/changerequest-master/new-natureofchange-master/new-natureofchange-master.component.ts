import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

@Component({
  selector: 'app-new-natureofchange-master',
  templateUrl: './new-natureofchange-master.component.html',
  styleUrl: './new-natureofchange-master.component.css'
})
export class NewNatureofchangeMasterComponent {
  supportid: any;
  constructor(private http: HttpClient, private routeservice: PasscrdataService, private router: Router) {
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
  }

  ngOnInit() {

    this.getCategory();

  }
  private apiurl = environment.apiurls;

  natureofchangeid: any[] = [];
  natureofchange: any[] = [];
  categoryId: any[] = [];
  today: any;
  isactive: boolean = true;
  postnatureofchange() {
    const apiUrl = this.apiurl + '/NatureofChange/postnatureofchange'
    const requestBody = {
      "flag": "I",
      "natureofChangeID": 0,
      "categoryID": this.categoryId,
      "natureofChange": this.natureofchange,
      "isActive": this.isactive,
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
        this.router.navigate(['/natureofchange']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

  categoryName: any[] = [];
  getCategory() {

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
        this.categoryName = response;
        console.log(this.categoryName)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

}
