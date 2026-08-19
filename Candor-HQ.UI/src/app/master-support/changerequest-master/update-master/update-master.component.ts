import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from '../../../change-request/passcrdata.service';


@Component({
  selector: 'app-update-master',
  templateUrl: './update-master.component.html',
  styleUrl: './update-master.component.css'
})
export class UpdateMasterComponent {
  supportid: any = '';
  supportname: any = '';
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private routeservice:PasscrdataService ) {

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;

    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
  };

  categoryid: any;
  filtercategoryid: any;
  getidupdate() {
    this.categoryid = this.route.snapshot.paramMap.get('id');
    this.filtercategoryid = this.categoryid;
    console.log("this is categoryid",this.filtercategoryid)
  }

  private apiurl = environment.apiurls;

  ngOnInit(): void {
    this.getupdatyevalue();
    this.getidupdate();
  }

  categoryName: any = "";
  crsupportID: any = "";
  isActive: boolean = true;
  categoryType: any;
  today: any = '';
  postcategorytyp() {

    const apiUrl = this.apiurl + '/Category/PostCategorytyp'
    const requestBody = {
      "flag": "U",
      "itCategoryID": this.categoryid,
      "supportID": this.updatevalue[0].supportId,
      "categoryName": this.updatevalue[0].categoryName,
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
        alert("Updated Successfully!");
        this.router.navigate(['/ChageRequest-Masters']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

  
  

  updatevalue: any[] = [];
  getupdatyevalue() {
    const apiUrls: any = this.apiurl + '/Category';
    const requestBody = {
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.updatevalue = response.filter((item: any) => item.itcategoryId.toString() === this.filtercategoryid);
        console.log("update category", this.updatevalue, this.categoryid)
      },
      (error: any) => {
        console.log('Post request failed', error);
      }
    );
  }
 
}
