import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

@Component({
  selector: 'app-update-classification-master',
  templateUrl: './update-classification-master.component.html',
  styleUrl: './update-classification-master.component.css'
})
export class UpdateClassificationMasterComponent {
  supportid: any = '';
  supportname: any = '';
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private routeservice: PasscrdataService) {

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;

    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
  };
  itclassificationId: any;

  getidupdate() {
    this.itclassificationId = this.route.snapshot.paramMap.get('id');
  }

  private apiurl = environment.apiurls;

  ngOnInit(): void {
    this.getupdatyevalue();
    this.getidupdate();
  }

  today: any = '';
  classificationId: any[] = [];
  Classificationname: any[] = [];
  postClassification() {

    const apiUrl = this.apiurl + '/Classification/PostCategorytyp'
    const requestBody = {
      "flag": "U",
      "itClassificationID": this.itclassificationId,
      "classificationName": this.updatevalue[0].classificationName,
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
        this.router.navigate(['/classification']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

  updatevalue: any = '';
  getupdatyevalue() {

    const apiUrls: any = this.apiurl + '/Classification';
    const requestBody = {
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.updatevalue = response.filter((item: any) => item.itclassificationId.toString() === this.itclassificationId);
        console.log("update category", this.updatevalue)
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
  }

}
