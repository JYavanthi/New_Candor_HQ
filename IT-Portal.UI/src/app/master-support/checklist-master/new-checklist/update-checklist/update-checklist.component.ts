import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from '../../../../change-request/passcrdata.service';

@Component({
  selector: 'app-update-checklist',
  templateUrl: './update-checklist.component.html',
  styleUrl: './update-checklist.component.css'
})
export class UpdateChecklistComponent {


  supportid: any = '';
  supportname: any = '';
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private routeservice: PasscrdataService) {

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;

    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
  };

  itchecklistId: any;

  getidupdate() {
    this.itchecklistId = this.route.snapshot.paramMap.get('id');
  }

  private apiurl = environment.apiurls;

  ngOnInit(): void {
    this.getupdatyevalue();
    this.getidupdate();
    this.getCategory();
    this.getClasification();
    this.getsupport();
    this.getPlantid();
  }

  today: any = '';
  checklistTitle: any[] = [];
  checklistDesc: any[] = [];
  
  postCheckList() {

    const apiUrl = this.apiurl + '/CheckList/ChecklistPost'
    const requestBody = {
      "flag": "U",
      "itChecklistID": this.itchecklistId,
      "plantID": this.updatevalue[0].plantId,
      "supportID": this.updatevalue[0].supportId,
      "categoryID": this.updatevalue[0].categoryId,
      "classificationID": this.updatevalue[0].classificationId,
      "checklistTitle": this.updatevalue[0].checklistTitle,
      "checklistDesc": this.updatevalue[0].checklistDesc,
      "mandatoryFlag":this.updatevalue[0].mandatoryFlag,
      "createdBy": this.supportid,
      "createdDt":this.today,
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
        this.router.navigate(['/viewcheklist']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

  updatevalue: any = '';
  getupdatyevalue() {

    const apiUrls: any = this.apiurl + '/CheckList';
    const requestBody = {
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.updatevalue = response.filter((item: any) => item.itchecklistId.toString() === this.itchecklistId)
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
        console.log(response);
        this.categoryName = response
        console.log(this.categoryName)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  caclasification: any[] = [];
  getClasification() {

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
        this.caclasification = response
        console.log(this.caclasification)
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

  plantcode: any[] = [];
  getPlantid() {

    const apiUrls = this.apiurl + '/Plantid'
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
        this.plantcode = response;
        console.log(this.plantcode)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }
}
