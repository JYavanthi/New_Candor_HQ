import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from '../../../change-request/passcrdata.service';


@Component({
  selector: 'app-update-priority-master',
  templateUrl: './update-priority-master.component.html',
  styleUrl: './update-priority-master.component.css'
})
export class UpdatePriorityMasterComponent {

  supportid: any = '';
  supportname: any = '';
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private routeservice: PasscrdataService) {

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;

    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
  };

  priorityId: any;

  getidupdate() {
    this.priorityId = this.route.snapshot.paramMap.get('id');
  }

  private apiurl = environment.apiurls;

  ngOnInit(): void {
    this.getupdatyevalue();
    this.getidupdate();
  }
  today: any = '';
  isactive: boolean = true;
  priorityID: any;

  postPriority() {

    const apiUrl = this.apiurl + '/Priority/PostPrority'
    const requestBody = {
      "flag": "U",
      "priorityID": this.priorityId,
      "priorityName": this.updatevalue[0].priorityName,
      "isActive": this.updatevalue[0].isActive,
      "createdBy": this.supportid,
      "createdDate": this.today,
      "updatedBy": this.supportid,
      "updatedDate": this.today
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
        this.router.navigate(['/Priority']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }



  updatevalue: any = '';
  getupdatyevalue() {

    const apiUrls: any = this.apiurl + '/Priority';
    const requestBody = {
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.updatevalue = response.filter((item: any) => item.priorityId.toString() === this.priorityId)
        console.log("update category", this.updatevalue)
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
  }

}
