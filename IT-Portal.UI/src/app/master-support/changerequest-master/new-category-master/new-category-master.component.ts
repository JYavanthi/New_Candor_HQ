import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';
@Component({
  selector: 'app-new-category-master',
  templateUrl: './new-category-master.component.html',
  styleUrl: './new-category-master.component.css'
})
export class NewCategoryMasterComponent {
  supportid: any[] = [];
  constructor(private http: HttpClient, private routeservice: PasscrdataService, private router: Router) {
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
  }
  ngOnInit() {
    this.getCategory();


  }
  private apiurl = environment.apiurls;

  
  isActive: boolean = true;
  categoryType: any;
  today: any = '';
  categoryID: any;
  postcategorytype() {

    const apiUrl = this.apiurl + '/CategoryTyp/PostCategorytyp'
    const requestBody = {
      "flag": "I",
      "categoryTypeID":0,
      "categoryID": this.categoryID,
      "categoryType": this.categoryType,
      "isActive": this.isActive,
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
        alert("Saved Successfully!");
        this.router.navigate(['/categorytype']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

  checkcat() {
    if (this.categoryID == "") {
      alert("select category")
    }
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
        this.categoryName = response;
        console.log(this.categoryName)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

}
