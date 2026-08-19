import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
// import { environment } from '/IT_Portal/IT-Portal/IT-Portal.UI/src/environments/environment'
import { ActivatedRoute, Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ReportIssueComponent } from '../../report-issue.component';
import { PasscrdataService } from '../../../../change-request/passcrdata.service';
import { environment } from '@environments/environment';

@Component({
  selector: 'app-issue-assignto',
  templateUrl: './issue-assignto.component.html',
  styleUrl: './issue-assignto.component.css'
})
export class IssueAssigntoComponent {

  supportid: any;
  today: any;
  constructor(private http: HttpClient, private routeservice: PasscrdataService, private route: Router, private router: ActivatedRoute, public dialogRef: MatDialogRef<ReportIssueComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;

    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
  }

  private apiurl = environment.apiurls

  issueId: any;

  ngOnInit(): void {
    this.fetchAllItems();
    this.issueId = this.data.issueId;
  }




  assignedTo: any = '';
  assignedBy: any;
  assignedOn: any;

  issueassignedto() {
    if (this.assignedTo ==' ') {
      alert("Select Assign to")
    }
    else { 
    const apiUrl = this.apiurl + '/IssueAssignedTo/Issueassignedto'
    const employeassignedto = this.assignedTo.split("-")[0];
    const requestBody = {
      "flag": "U",
      "issueId": this.issueId,
      "assignedTo": Number(employeassignedto),
      "assignedBy": Number(this.supportid),
      "assignedOn": this.today,
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
        this.route.navigate(['/report_issue']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
    this.dialogRef.close();
    }
  }

  onClose(): void {
    this.dialogRef.close();
  }

  supportteamname: string[] = [];
  supportnames: string[] = [];

  fetchAllItems() {
    
    const apiUrl = this.apiurl + '/EmployeeMasters';
    this.http.get<any[]>(apiUrl).subscribe(
      (response: any[]) => {
        console.log("Function", response);
        this.supportnames = response.map(item => item.employeeId + '-' + item.firstName + ' ' + item.middleName + ' ' + item.lastName);
        this.supportteamname = this.supportnames;
        console.log("Suppoert Team Name", this.supportteamname);
      },
      (error: any) => {
        console.error('GET request failed', error);
      }
    );
  }

  Itemsassignedto: string[] = [];
  selectassignto: string = '';
  filterAssignedto() {
    const filter = this.assignedTo.toUpperCase();
    this.Itemsassignedto = this.supportteamname.filter(item =>
      item.toUpperCase().includes(filter)
    );
    if (this.Itemsassignedto.length === 0 && filter !== '') {
      this.Itemsassignedto.push('No name found');
    }
    else if (filter === '') {
      this.Itemsassignedto.length = 0
    }
  }

  selectAssignedto(item: string) {
    this.selectassignto = item;
    this.assignedTo = item;
    this.Itemsassignedto = [];
  }

  Itemsassignedby: string[] = [];
  selectassignby: string = '';
  filterAssignedby() {
    const filter = this.assignedTo.toUpperCase();
    this.Itemsassignedby = this.supportteamname.filter(item =>
      item.toUpperCase().includes(filter)
    );
    if (this.Itemsassignedby.length === 0 && filter !== '') {
      this.Itemsassignedby.push('No name found');
    }
    else if (filter === '') {
      this.Itemsassignedby.length = 0
    }
  }

  selectAssignedby(item: string) {
    this.selectassignby = item;
    this.assignedBy = item;
    this.Itemsassignedby = [];
  }
  /*end search filter*/


}
