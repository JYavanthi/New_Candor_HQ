import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { json } from 'express';import { environment } from '@environments/environment';
import { PasscrdataService } from '../../passcrdata.service';

@Component({
  selector: 'app-execute-approve',
  templateUrl: './execute-approve.component.html',
  styleUrl: './execute-approve.component.css'
})
export class ExecuteApproveComponent {
showInitiator: boolean = false;
  showRiskQ: boolean = false;
  tabs: any[] = [];
  numberOfTabs: number = 1;
  plantData: any[] = [];
  status: any = '';
  approver: any = '';
  appdate: any = '';
  attach: any = '';
  remark: any = '';
  comment: any = '';

  errorMessage: any = '';
  successMessage: any = '';
  Rejected: any = '';
  selectthevalue: any = '';
  updatevalue: any;
  crid: any;
  today: any;
  supportid: any;
  supportname: any;
  currentdate: any;
  stage: any;
  appstatus: any;
  constructor(private http: HttpClient, private routeservice: PasscrdataService, private router: Router, private route: ActivatedRoute) {
    this.routeservice.crdata.subscribe(data => {
      this.crid = data.report.value;
      this.itcrid = this.crid.itcrid;
      this.appstatus = this.crid.status.trim();
      this.status = this.crid.status.trim();
      this.stage = this.crid.stage.trim();
    })
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;
    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
    this.currentdate = currentDate.toISOString().slice(0, 10);
  }
  selectedTab: number = 0;
  count: any;
  // Method to show the selected tab
  showTab(index: number) {
    this.selectedTab = index;
    //alert(this.selectedTab)
  }
  ngOnInit(): void {
    this.getidupdate();
    //this.GetApprover();
  }
  private apiurl = environment.apiurls;

  toggleInitiatorFields() {
    this.showInitiator = !this.showInitiator;
  }

  toggleField() {
    this.showRiskQ = !this.showRiskQ;
  }

  toggleCollapsible(content: HTMLDivElement): void {
    content.style.display = (content.style.display === 'block') ? 'none' : 'block';
  }

  addMore() {
    this.plantData.push({
      selectPlant: '',
      controlNumber: '',
      controlDate: '',
      attachment: null
    });
  }

  toggleInitiatorField(index: number) {
    this.tabs[index].showInitiator = !this.tabs[index].showInitiator;
  }

  removeTab() {
    if (this.tabs.length > 0) {
      this.tabs.pop();
    }
  }

  update(index: number) {
   
  }

  delete(index: number) {
    this.plantData.splice(index, 1);
  }

  handleFileInput(event: any, index: number) {
    const file = event.target.files[0];
    this.plantData[index].attachment = file;
    
  }
  itcrid: any;
  getidupdate() {

    this.itcrid = this.route.snapshot.paramMap.get('id');
  }
  approvervalue: any;
  approverCount: any;
  supportapp1: any; supportapp2: any; supportapp3: any; supportapp: any;
  appvflg: boolean=false;
  supportapp1ID: any; supportapp2ID: any; supportapp3ID: any;

  
  data = 2;
  approvers: any[] = [];

  initializeApprovers() {
  
  }

  counter(i: number) {
    return new Array(i);
  }

  clearErrorMessage() {
    this.errorMessage = '';
  }
  activeTab: number = 1; // Default to the first tab being active

  // Function to activate a tab
  activateTab(tabNumber: number) {
    this.activeTab = tabNumber;
  }
  approverValues: string[] = [];
  remarkValues: string[] = [];
  value: any;
  getdata(statu: any[] = []) {
     
    if (this.approvervalue.approverCount < 1) {
      this.status = "Approved"
    }
    else {
      //Check Status Is Approved true from Change Request for CRID
      //If true display values from CRApprover in both tabs and hide all buttons
      if (this.appstatus == "Implemented") {
        if (statu[0] = "Approval level0") {
          statu[0] = "Approved Level1"
        }
        else if (statu[0] = "Approval level1") {
          statu[0] = "Approved Level2"
        }
        else if (statu[0] = "Approval level2") {
          statu[0] = "Approved Level3"
        }
        const apiUrl = this.apiurl + '/CRapprove/Approve';
        const requestBody = {

          "Flag": "I",
          "CRApproverID": 1,
          "PlantID": this.crid.plantId,
          "SupportID": this.supportid,
          "CRID": this.crid.itcrid,
          "Stage": "I",
          "ApproverID": this.approver,
          "ApprovedDt": this.today,
          "Remarks": this.remark,
          "Status": statu[0],
          "Attachment": this.attach,
          "CreatedBy": this.supportname,
          "CreatedDt": this.currentdate,
          "ModifiedBy": this.supportname,
          "ModifiedDt": this.currentdate,
        }
        const httpOptions = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json'
          })
        };

        this.http.post(apiUrl, requestBody, httpOptions).subscribe(
          (response: any) => {
            if (response.type == "E") {
          alert(response.message);
          return;
        }else{
            alert("Approved Successfully!");
            this.router.navigate(['/change-request']);
        }
          },
          (error: any) => {
            console.error('POST request failed', error);
          });
        
      }
      else {

        const apiUrl = this.apiurl + '/CRapprove/Approve';
        const requestBody = {

          "Flag": "I",
          "CRApproverID": 1,
          "PlantID": this.crid.plantId,
          "SupportID": this.supportid,
          "CRID": this.crid.itcrid,
          "Stage": "I",
         
          "ApproverID": this.approver,
          "ApprovedDt": this.today,
          "Remarks": this.remark,
          "Status": "Approved Level2",
          "Attachment": this.attach,
          "CreatedBy": this.supportname,
          "CreatedDt": this.currentdate,
          "ModifiedBy": this.supportname,
          "ModifiedDt": this.currentdate,
        }
        const httpOptions = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json'
          })
        };

        this.http.post(apiUrl, requestBody, httpOptions).subscribe(
          (response: any) => {
            if (response.type == "E") {
          alert(response.message);
          return;
        }else{
            alert("Approved Successfully!");
            this.router.navigate(['/change-request']);
        }
          },
          (error: any) => {
            console.error('POST request failed', error);
          });
        
      }  
    }
  }

/*  getData(status:any[]=[]) {
     if (this.approver == "") {
      this.errorMessage = 'Enter Approver';
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const selectElement = document.querySelector<HTMLSelectElement>('select[ngModel="approver"]');
      if (selectElement) {
        selectElement.focus();
      }
    }
     else if (this.today == "") {
      this.errorMessage = 'Select Date';
      window.scrollTo({ top: 0, behavior: 'smooth' });
       const inputElement = document.querySelector<HTMLInputElement>('input[ngModel="today"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else if (this.remark == "") {
      this.errorMessage = 'Enter Remark';
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('input[ngModel="remark"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else if (this.comment == "") {
      this.errorMessage = 'Enter Comment';
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('input[ngModel="comment"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    *//*else if (this.attach == "") {
      this.errorMessage = 'Attach file';
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('input[ngModel="attach"]');
      if (inputElement) {
        inputElement.focus();
      }
    }*//*
     else {
  
       this.successMessage = 'Approve Successfully!';
  
       const apiUrl = this.apiurl + '/CRapprove/Approve';
       const requestBody = {
  
        "Flag": "I",
        "CRApproverID": 1,
        "PlantID": 70,
        "SupportID": 4,
        "CRID": this.crid.itcrid,
        "Stage": "Test",
         "ApproverID": this.approver,
        "ApprovedDt": this.today,
        "Remarks": this.remark,
         "Status": status[0],
        "Attachment": this.attach,
        "CreatedBy": "Joe",
        "CreatedDt": "2024-02-06T09:52:33.431Z",
        "ModifiedBy": "Admin",
        "ModifiedDt": "2024-02-06T09:52:33.431Z"
      }
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };
  
      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
          console.log(response);
        },
        (error: any) => {
          console.error('POST request failed', error);
        });
      this.router.navigate(['/change-request']);
    }
    }

*/
     
   rejectbutton(status:any) {
      this.Rejected = 'Rejected';
      
      const apiUrl = this.apiurl + '/CRapprove/Approve';
      const requestBody = {
        "Flag": "I",
        "CRApproverID": 1,
        "PlantID": 70,
        "SupportID": this.supportid,
        "CRID": this.crid.itcrid,
        "Stage": "I",
        "ApproverID": this.approver,
        "ApprovedDt": this.today,
        "Remarks": this.remark,
        "Status": status,
        "Attachment": this.attach,
        "CreatedBy": this.supportid,
        "CreatedDt": this.today,
        "ModifiedBy": this.supportid,
        "ModifiedDt": this.today
      }
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };
  
      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
          if (response.type == "E") {
          alert(response.message);
          return;
        }
        else{
          alert( status +" "+ "Successfully!");
          this.router.navigate(['/change-request']);
        }
        },
        (error: any) => {
          console.error('POST request failed', error);
        });
      
  }

}
