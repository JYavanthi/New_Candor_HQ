import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
// import { environment } from '/IT_Portal/IT-Portal/IT-Portal.UI/src/environments/environment'
import { PasscrdataService } from '../passcrdata.service';
import { ActivatedRoute } from '@angular/router';
import { environment } from '@environments/environment';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrl: './history.component.css'
})
export class HistoryComponent {

  crid: any[] = [];
  getcrcode: string = '';
  itcrid: any;
  crData: any;
  constructor(private http: HttpClient,private routeservice: PasscrdataService,private route: ActivatedRoute) {
    this.itcrid = this.route.snapshot.paramMap.get('id');

  }

  private apiurl = environment.apiurls

  ngOnInit(): void {
    this.getCrData();
    this.getcrhistory();
    this.executionhistory();
    this.getData();
  }

  crhistory: any[] = [];

  getCrData(){
    
    const apiUrls = this.apiurl + '/ViewChangeRequest/ViewChangerequest';
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        // this.crid = response.filter
        this.crData = response.filter((m:any)=>{return m['itcrid']==this.itcrid})[0]
        this.getcrcode = this.crData.crcode;
        this.getData()
      },
      (error) => {
        throw error
      })
  }
  getcrhistory() {

    const apiUrls = this.apiurl + '/ChangeRequestHistory/GetCrhistory'
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        this.crhistory = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  exehistory: any[] = [];

  executionhistory() {

    const apiUrls = this.apiurl + '/ExecutionHistory/ExecutionHistory'
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        this.exehistory = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  approverhistory: any[] = [];
  tableData: any[] = [];
  getData() {
    if(!this.getcrcode){
      return
    }
    const apiUrls = this.apiurl + '/ViewChangeHistory/GetChangeRequestHistory?id=' + this.getcrcode

    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.tableData = response;
        this.tableData = this.tableData.sort((a, b) => {
          return new Date(a.crhistoryDt).getTime() - new Date(b.crhistoryDt).getTime();
        });
      },
      (error) => {
        console.error("Data fetching error", error)
      }
    )
  }


}
