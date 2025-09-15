import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

@Component({
  selector: 'app-new-priority-master',
  templateUrl: './new-priority-master.component.html',
  styleUrl: './new-priority-master.component.css'
})
export class NewPriorityMasterComponent {

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

  priorityName: any = '';
  isActive: any ='';

  today: any;
  postPriority() {

    const apiUrl = this.apiurl + '/Priority/PostPrority'
    const requestBody = {
      "flag": "I",
      "priorityID": 0,
      "priorityName": this.priorityName,
      "isActive": this.isActive,
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
        alert("Saved Successfully!");
        this.router.navigate(['/Priority']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

}
