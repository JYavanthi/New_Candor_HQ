import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { ActivatedRoute } from '@angular/router';import { environment } from '@environments/environment';
@Injectable({
  providedIn: 'root'
})
export class PasscrdataService {
  private crrequestDataSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public crdata:Observable<any> = this.crrequestDataSubject.asObservable();

  //Made Changes
  private RejectDataSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public RejectDta: Observable<any> = this.RejectDataSubject.asObservable();
  Data: any;
  //Made Changes End
  constructor(private http: HttpClient, private route: ActivatedRoute) { }

  private apiurl = environment.apiurls

  private readonly EMPLOYEE_ID_KEY = 'employee_id';

  getEmployeeId(): string | null {
    return localStorage.getItem(this.EMPLOYEE_ID_KEY);
  }

  setEmployeeId(empNumber: string): void {
    localStorage.setItem(this.EMPLOYEE_ID_KEY, empNumber);
  }

  clearEmployeeId(): void {
    localStorage.removeItem(this.EMPLOYEE_ID_KEY);
  }


  employyesid: any;
  employeeidfromlogin(empNumber: string) {
    this.employyesid = empNumber
  }

  changerequestdata(data:any): void{
    this.crrequestDataSubject.next(data);
  }

  //Made Changes
  getCRRejectData(data: any): void {
    this.RejectDataSubject.next(data);
  }
  //Made Changes End

  private empNumber: any;

  seteid(empNumber: any) {
    this.empNumber = empNumber;
  }

  private SupportName: any;
  setSupportName(supportname: any) {
    this.SupportName = supportname;
  }

  supporterID: any;
  supportempid: any;
  supporterName: any;
  getsupportteam() {
    this.supportempid = this.getEmployeeId();
    this.supporterID = (this.getEmployeeId());
    this.supporterName = this.SupportName;
  }

  /* test id
     120678 = isChangeanalyst
     1757 = issupportengineer
     7603 = isapprover */

  getsupportid: any;
  getcategory() {
    const apiUrls = this.apiurl + '/SupportTeam'
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
        this.getsupportid = response.filtet((item: any) => item.empId == this.supporterID);
        alert(this.getsupportid)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  getsupportassinid: any;
  supportTeamdts: any[] = [];
  getsupportassign() {
    const apiUrls = this.apiurl + '/SupportteamAssigned'
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
        this.getsupportid = response;
        //this.supportTeamdts = 
        console.log(this.getsupportid)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  private systemlandscape: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public sysdata: Observable<any> = this.systemlandscape.asObservable();
  
  syslandscapedata(data: any): void {
    this.systemlandscape.next(data);
  }

  private refreshDataSubject = new Subject<void>();

  refreshData$ = this.refreshDataSubject.asObservable();

  triggerDataRefresh(){
    this.refreshDataSubject.next();
  }

  /*radiobutton data*/
  private localStorageKey = 'selectedRadio';
  
  // Store selected radio value in local storage
  setSelectedRadio(value: string): void {
    localStorage.setItem(this.localStorageKey, value);
  }

  // Retrieve selected radio value from local storage
  getSelectedRadio(): string | null {
    return localStorage.getItem(this.localStorageKey);
  }
  
  setCrData(data:any){
    this.Data = data
  }

  getCrData(){
    return this.Data
  }

}
