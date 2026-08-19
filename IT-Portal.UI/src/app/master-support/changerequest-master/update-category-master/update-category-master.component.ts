import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from '../../../change-request/passcrdata.service';

@Component({
  selector: 'app-update-category-master',
  templateUrl: './update-category-master.component.html',
  styleUrl: './update-category-master.component.css'
})
export class UpdateCategoryMasterComponent {
  supportid: any = '';
  supportname: any = '';
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private routeservice: PasscrdataService) {

    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;

    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
  };
  categorytypId: any;

  getidupdate() {
    this.categorytypId = this.route.snapshot.paramMap.get('id');
  }

  private apiurl = environment.apiurls;

  ngOnInit(): void {
    this.getupdatyevalue();
    this.getidupdate();
    this.getCategory()
  }

  categorytype: any = "";
  CategoryTypeID: any = "";
  isactive: boolean = true;
  categoryId: any = "";
 
  today: any;
  postCategoryTyp() {

    const apiUrl = this.apiurl + '/CategoryTyp/PostCategorytyp'
    const requestBody = {
      "flag": "U",
      "categoryTypeID": this.categorytypId,
      "categoryID": this.updatevalue[0].categoryId,
      "categoryType": this.updatevalue[0].categoryType,
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
        this.router.navigate(['/categorytype']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

  updatevalue: any []=[];
  getupdatyevalue() {

    const apiUrls: any = this.apiurl + '/CategoryTyp/viewcattyp';
    const requestBody = {
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.updatevalue = response.filter((item: any) => item.categoryTypeId.toString() === this.categorytypId);
        console.log("update category", this.categorytypId, this.updatevalue[0].categoryName)
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

}
