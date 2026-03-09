import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../../change-request/passcrdata.service';


@Component({
  selector: 'app-classification',
  templateUrl: './classification.component.html',
  styleUrl: './classification.component.css'
})
export class ClassificationComponent {
  supportid: any = '';
  constructor(private http: HttpClient, private router: Router, private routeservice:PasscrdataService) {
    this.filteredData = this.classification;
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
}

  ngOnInit() {
   

    this.getClassification();
   
  }
  private apiurl = environment.apiurls;

  classification: any[] = [];
  filteredData: any[]; 
  searchText: string = '';
  filterData() {
    this.filteredData = this.classification.filter(item =>
      item.classificationName.toLowerCase().includes(this.searchText.toLowerCase())
    );
  }
  getClassification() {
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
        this.classification = response;
        this.filterData();
        console.log(this.classification)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  //delete function
  deleteconfirmation: boolean = false;
  deleteclassificationnmae: string = '';
  deleteclassificationId: any;
  deleteRow(itclassificationId: any, classificationName: any) {
    this.deleteclassificationId = itclassificationId;
    this.deleteclassificationnmae = classificationName;
    this.deleteconfirmation = true
  }

  deleteyes() {
    this.deleteconfirmation = false
    this.deleteSupportTeam()
  }

  deleteno() {
    this.deleteconfirmation = false
  }

  deleteinprogress: boolean = false;
  deletesuccess: boolean = false;
  deletemessage: any = '';
  deleteinmessage: any = '';
  messageerror: boolean = false;
  errormessage: any;
  errorresponse: any;
  today: any = '';

  deleteSupportTeam() {
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
    
    const apiUrl = this.apiurl + '/Classification/PostCategorytyp'
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const requestBody = {
      "flag": "D",
      "itClassificationID": this.deleteclassificationId,
      "classificationName": this.deleteclassificationnmae,
      "createdBy": this.supportid,
      "createdDt": this.today,
      "modifiedBy": this.supportid,
      "modifiedDt": this.today

    }
    setTimeout(() => {
      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
          console.log("this is error response", response);
          this.errorresponse = response.type
          if (this.errorresponse == "E") {
            this.deleteinprogress = true;
            this.deleteinmessage = "There are open items it Can't be deleted"
          } else if (this.errorresponse == "S") {
            this.deletesuccess = true;
            this.deletemessage = "Deleted Successfully"
          }
        },
        (error: any) => {
          console.log('Post request failed', error);
          this.messageerror = true;
          this.errormessage = error;
        }
      );
    }, 500);
  }

  navigateinprogress() {
    this.deleteinprogress = false;
  }

  navigatesuccess() {
    this.deletesuccess = false;
    window.location.reload();
  }

}
