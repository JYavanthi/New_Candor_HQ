import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

@Component({
  selector: 'app-new-master',
  templateUrl: './new-master.component.html',
  styleUrl: './new-master.component.css'
})
export class NewMasterComponent {
  supportid: any;
  constructor(private http: HttpClient, private routeservice: PasscrdataService, private router: Router) {
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
}

  ngOnInit() {
    this.getitsupport();
  }
  private apiurl = environment.apiurls;

  categoryName: any = "";
  crsupportID: any="";
  isActive: boolean = true;
  categoryType: any;
  today: any = '';
  postcategorytyp() {

    const apiUrl = this.apiurl + '/Category/PostCategorytyp'
    const requestBody = {
      "flag": "I",
      "itCategoryID": 0,
      "supportID": this.crsupportID,  
      "categoryName": this.categoryName,
      "isActive": this.isActive,
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
        this.router.navigate(['/ChageRequest-Masters']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }


  itsupportid: any[] = [];
  getitsupport() {
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
        this.itsupportid = response;
        console.log("Muthu", this.itsupportid)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

}
