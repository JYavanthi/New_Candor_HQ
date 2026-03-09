import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

@Component({
  selector: 'app-update-natureofchange-master',
  templateUrl: './update-natureofchange-master.component.html',
  styleUrl: './update-natureofchange-master.component.css'
})
export class UpdateNatureofchangeMasterComponent {
  supportid: any = '';
  supportname: any = '';
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private routeservice: PasscrdataService) {

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;

    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
  };

  natureofChangeId: any;

  getidupdate() {
    this.natureofChangeId = this.route.snapshot.paramMap.get('id');
  }

  private apiurl = environment.apiurls;

  ngOnInit(): void {
    this.getupdatyevalue();
    this.getidupdate();
  }
  today: any = '';
  isactive: boolean = true;
  natureofchange1: any[] = [];
  natureofChangeID: any[] = [];

  postNatureofChange() {

    const apiUrl = this.apiurl + '/NatureofChange/postnatureofchange'
    const requestBody = {
      "flag": "U",
      "natureofChangeID": this.natureofChangeId,
      "categoryID": this.updatevalue[0].categoryId,
      "natureofChange": this.updatevalue[0].natureofChange1,
      "isActive": this.updatevalue[0].isActive,
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
        alert("Update Successfully!");
        this.router.navigate(['/natureofchange']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

  updatevalue: any = '';
  getupdatyevalue() {

    const apiUrls: any = this.apiurl + '/NatureofChange';
    const requestBody = {
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.updatevalue = response.filter((item: any) => item.natureofChangeId.toString() === this.natureofChangeId)
        console.log("update category", this.updatevalue)
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
  }
}
