import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-changerequest-master',
  templateUrl: './changerequest-master.component.html',
  styleUrl: './changerequest-master.component.css'
})
export class ChangerequestMasterComponent {
  today: any = '';
  constructor(private http: HttpClient, private router: Router) {
    
    this.filteredData = this.categorydata;
}

  ngOnInit() {
    this.getcategory();
    
   /* this.getpriority();
    this.getReference();
    this.getReferencetype();*/
  

  }
  private apiurl = environment.apiurls;
  
  categoryTypeId: any = "";
  categoryId: any = "";
  categoryType: any = "";
  isActive: any = "";
  createdBy: any = "";
  createdDate: any = "";
  modifiedBy: any = "";
  modifiedDate: any = "";

  postcategorytyp() {
     
    const apiUrl = this.apiurl + '/CategoryTyp/PostCategorytyp'
    const requestBody = {
      "flag": "I",
      "categoryId": 1,
      "categoryType": this.categoryType,
      "isActive": true,
      "createdBy": "null",
      "createdDate": "2024-03-13T13:59:05.155Z",
      "modifiedBy": "null",
      "modifiedDate": "2024-03-13T13:59:05.155Z",
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
        this.router.navigate(['/mastersupport']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

  
  classificationName: any = "";

  postclassification() {
     
    const apiUrl = this.apiurl + '/Classification/PostCategorytyp'
    const requestBody = {
      "flag": "I",
      "classificationName": this.classificationName,
      "createdBy": "null",
      "createdDt": "2024-03-13T13:59:05.155Z",
      "modifiedBy": "null",
      "modifiedDt": "2024-03-13T13:59:05.155Z",
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

  natureofChange: any = "";

  postnatureofchange() {
     
    const apiUrl = this.apiurl + '/NatureofChange/postnatureofchange'
    const requestBody = {
      "flag": "I",
      "categoryID": 0,
      "natureofChange": this.natureofChange,
      "isActive": true,
      "createdBy": "null",
      "createdDate": "2024-03-13T13:59:05.155Z",
      "modifiedBy": "null",
      "modifiedDate": "2024-03-13T13:59:05.155Z",
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


  filteredData: any[]; // Array to hold filtered data
  searchText: string = '';
  filterData() {
    this.filteredData = this.categorydata.filter(item =>
      item.categoryName.toUpperCase().includes(this.searchText.toUpperCase())
    );
  }



  categorydata: any[] = [];

  getcategory() {
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
        this.categorydata = response;

        this.filterData(); // Filter data after fetching
        console.log(this.categorydata);

      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  deleteconfirmation: boolean = false;
  deletecategoryid: any;
  deletesupportid: any;
  deletecategoryName: any;
  deleteRow(categoryid: any, supportId: any, categoryName:any) {
    this.deletecategoryid = categoryid;
    this.deletesupportid = supportId;
    this.deletecategoryName = categoryName;
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
  
  deleteSupportTeam() {
    
    const apiUrl = this.apiurl + '/Category/PostCategorytyp'
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const requestBody = {
      "flag": "D",
      "itCategoryID": Number(this.deletecategoryid),
      "supportID": Number(this.deletesupportid),
      "categoryName": this.deletecategoryName,
      "isActive": false,
      "createdBy": 1,
      "createdDt": "2024-04-10T19:05:12.91",
      "modifiedBy":1,
      "modifiedDt": "2024-04-10T19:05:12.91"
    };
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
