import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

@Component({
  selector: 'app-update-systemlandscope-master',
  templateUrl: './update-systemlandscope-master.component.html',
  styleUrl: './update-systemlandscope-master.component.css'
})
export class UpdateSystemlandscopeMasterComponent {
  supportid: any = '';
  supportname: any = '';
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private routeservice: PasscrdataService) {

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;

    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
  };
  sysLandscapeId: any;

  getidupdate() {
    this.sysLandscapeId = this.route.snapshot.paramMap.get('id');
  }

  private apiurl = environment.apiurls;

  ngOnInit(): void {
    this.getupdatyevalue();
    this.getidupdate();
    this.getCategory();
    this.getsystem();
    this.getpri();
    this.getsupport();
  }

  categorytype: any = "";
  CategoryTypeID: any = "";
  isactive: boolean = true;

  today: any = '';
  postSystemLandscapeSp() {

    const apiUrl = this.apiurl + '/SystemLandscapeSp/PostSystemLandscape'
    const requestBody = {
      "flag": "U",
      "sysLandscapeId": this.sysLandscapeId,
      "supportId": this.updatevalue[0].supportId,
      "categoryId": this.updatevalue[0].categoryId,
      "classificationId": this.updatevalue[0].classificationId,
      "sysLandscape1": this.updatevalue[0].sysLandscape,
      "priorityNum": this.updatevalue[0].priorityNum,
      "isActive": this.updatevalue[0].isActive,
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
        alert("Update Successfully!");
        this.router.navigate(['/systemlandscape']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

  updatevalue: any[] = [];
  getupdatyevalue() {

    const apiUrls: any = this.apiurl + '/SystemLandscape/ViewSystemLans';
    const requestBody = {
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.updatevalue = response.filter((item: any) => item.sysLandscapeId.toString() === this.sysLandscapeId);
        console.log("update category", this.updatevalue)
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
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
        this.categoryName = response
        console.log(this.categoryName)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  Name: any[] = [];
  getsystem() {

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
        this.Name = response
        console.log(this.Name)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  priName: any[] = [];
  getpri() {

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
        this.priName = response
        console.log(this.priName)
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
