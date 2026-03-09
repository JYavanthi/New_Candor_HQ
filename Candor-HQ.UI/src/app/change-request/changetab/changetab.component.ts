import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';

@Component({
  selector: 'app-changetab',
  templateUrl: './changetab.component.html',
  styleUrl: './changetab.component.css'
})
export class ChangetabComponent {
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

  constructor(private http: HttpClient) { }

  private apiurl = environment.apiurls

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
    // Implement the update logic here
  }

  delete(index: number) {
    this.plantData.splice(index, 1);
  }

  handleFileInput(event: any, index: number) {
    const file = event.target.files[0];
    this.plantData[index].attachment = file;
  }

  getData() {
    
    const apiUrl = this.apiurl + '/CRapprove/Approve';
    const requestBody = {
      "Flag": "I",
      "CRApproverID": 1,
      "PlantID": 70,
      "SupportID": 4,
      "CRID": 6,
      "Stage": "Test",
      "ApproverID": this.approver,
      "ApprovedDt": this.appdate,
      "Remarks": this.remark,
      "Status": this.status,
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
  }
}
