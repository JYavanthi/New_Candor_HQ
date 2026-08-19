import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

@Component({
  selector: 'app-update-refrence-master',
  templateUrl: './update-refrence-master.component.html',
  styleUrl: './update-refrence-master.component.css'
})
export class UpdateRefrenceMasterComponent {
  supportid: any = '';
  supportname: any = '';
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private routeservice: PasscrdataService) {

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;

    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
  };
  referenceId: any;

  getidupdate() {
    this.referenceId = this.route.snapshot.paramMap.get('id');
  }

  private apiurl = environment.apiurls;

  ngOnInit(): void {
    this.getupdatyevalue();
    this.getidupdate();
  }

  referenceName: any = "";
  isactive: boolean = true;

  today: any = '';
  postRefrencePost() {

    const apiUrl = this.apiurl + '/Reference/RefrencePost'
    const requestBody = {
      "flag": "U",
      "referenceID": this.referenceId,
      "referenceName": this.updatevalue[0].referenceName,
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
        this.router.navigate(['/Refrencemaster']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

  updatevalue: any[] = [];
  getupdatyevalue() {

    const apiUrls: any = this.apiurl + '/Reference';
    const requestBody = {
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.updatevalue = response.filter((item: any) => item.referenceId.toString() === this.referenceId);
        console.log("update category", this.updatevalue)
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
  }
}
