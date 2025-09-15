import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../change-request/passcrdata.service';
@Component({
  selector: 'app-checklist-master',
  templateUrl: './checklist-master.component.html',
  styleUrl: './checklist-master.component.css'
})
export class ChecklistMasterComponent {
  supportid: any = '';
  constructor(private http: HttpClient, private router: Router, private routeservice: PasscrdataService) {
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    
  }

  ngOnInit() {


    this.getCheckList();

  }
  private apiurl = environment.apiurls;


  checklist: any[] = [];
  getCheckList() {
    const apiUrls = this.apiurl + '/CheckList'
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
        this.checklist = response;
       
        console.log(this.checklist)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }
  //delete function
  deleteconfirmation: boolean = false;
  deleteclassificationName: string = '';
  itchecklistId: any;
  deletesupportId: any;
  deleteplantname: any;
  deletecategoryName: any;
  deletechecklistTitle: any;
  deletechecklistDesc: any;
  deleteRow(itchecklistId: any, supportId: any, plantId: any, categoryId: any, classificationId: any, checklistTitle: any, checklistDesc: any) {
    this.itchecklistId = itchecklistId;
    this.deletesupportId = supportId;
    this.deleteplantname = plantId;
    this.deletecategoryName = categoryId;
    this.deleteclassificationName = classificationId;
    this.deletechecklistTitle = checklistTitle;
    this.deletechecklistDesc = checklistDesc;
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
    
    const apiUrl = this.apiurl + '/CheckList/ChecklistPost'
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    
      const requestBody = {
        "flag": "D",
        "itChecklistID": this.itchecklistId,
        "plantID": this.deleteplantname,
        "supportID": this.deletesupportId,
        "categoryID": this.deletecategoryName,
        "classificationID": this.deleteclassificationName,
        "checklistTitle": this.deletechecklistTitle,
        "checklistDesc": this.deletechecklistDesc,
        "mandatoryFlag": false,
        "createdBy": this.supportid,
        "createdDt": this.today,
        "modifiedBy": this.supportid,
        "modifiedDt": this.today
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
