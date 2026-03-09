import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

@Component({
  selector: 'app-new-systemlandscope-master',
  templateUrl: './new-systemlandscope-master.component.html',
  styleUrl: './new-systemlandscope-master.component.css'
})
export class NewSystemlandscopeMasterComponent {
  supportid: any;
  constructor(private http: HttpClient, private routeservice: PasscrdataService, private router: Router) {
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
  }

  ngOnInit() {

    this.getsystemlandscape();
    this.getClassification();
    this.getpriorty();
    this.getsupport();
     

  }
  private apiurl = environment.apiurls;
  today: any;
  SystemLandscapeId: any[] = [];
  sysLandscape: any[] = [];
  classificationId: any[] = [];
  priorityNumber: any[] = [];
  isactive: Boolean = true;
  supportsId: any[] = [];
  categoryId: any[] = [];

  PostSystemLandscapeSp() {

    const apiUrl = this.apiurl + '/SystemLandscapeSp/PostSystemLandscape'
    const requestBody = {
      "flag": "I",
      "sysLandscapeId": 0,
      "supportId": this.supportsId,
      "categoryId": this.categoryId,
      "classificationId": this.classificationId,
      "sysLandscape1": this.sysLandscape,
      "priorityNum": this.priorityNumber,
      "isActive": this.isactive,
      "createdBy": this.supportid,
      "createdDt": this.today,
      "modifiedBy": this.supportid,
      "modifiedDt": this.today

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
        this.router.navigate(['/systemlandscape']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

 category: any[] = [];

  getsystemlandscape() {
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
        this.category = response;
        console.log(this.category)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  classification: any[] = [];

  getClassification() {
    const apiUrls = this.apiurl + '/Classification'
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
        this.classification = response;
        console.log(this.classification)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  priority: any[] = [];
  getpriorty() {
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
        this.priority = response;
        console.log(this.priority)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  support: any[] = [];
  getsupport() {
    const apiUrls = this.apiurl + '/ITSupport/GetSupport'
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
        this.support = response;
        console.log(this.support)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

}

