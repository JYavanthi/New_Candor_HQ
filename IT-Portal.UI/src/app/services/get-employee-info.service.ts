import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';import { environment } from '@environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GetEmployeeInfoService {

  EmpList:any[]=[];
  SupportTeamList:any[]=[];
  empDetails: any;
  SupportUserName = ''
  SupportUserEmail = ''
  EmpIDwithName = ''
  EmpName = ''
  EmpEmail = ''
    SupportId: any;
  constructor(private http: HttpClient) {
   }

  empList() {
    const apiUrl = environment.apiurls + '/HREmployee';
    return this.http.get(apiUrl).toPromise()
      .then((response: any) => {
        this.EmpList = response;
      })
      .catch((error: any) => {
        throw error;
      });
  }

  suppTeamList(){
    const apiUrl = environment.apiurls + '/SupportTeam';
    return this.http.get(apiUrl).toPromise()
      .then((response: any) => {
        this.SupportTeamList = response;
      })
      .catch((error: any) => {
        throw error;
      });
  }

  getSupportUserInfo(empid: Number){
    const apiUrl = environment.apiurls + '/SupportTeam';
    this.http.get<any[]>(apiUrl).subscribe(
      (response: any[]) => {
        let SupportUserInfo = response.filter(item => item.empId === Number(empid))[0]
        
        this.SupportUserName = SupportUserInfo.firstName + ' ' + SupportUserInfo.middleName + ' ' + SupportUserInfo.lastName
        this.SupportUserEmail = this.empDetails.email
        this.SupportId = SupportUserInfo.supportTeamId

        return { SupportUserName: this.SupportUserName, SupportUserEmail: this.SupportUserEmail,
        userInfo : SupportUserInfo}
      },
      (error: any) => {
        throw error;
      })
  }

  getEmployeeInfo(empid: Number){
        this.empDetails = this.EmpList.filter((m:any)=>m.employeeId == empid)[0]
        this.EmpIDwithName = this.empDetails.employeeId + ' ' + '-' + ' ' + this.empDetails.employeeName;
        this.EmpName = this.empDetails.employeeName
        this.EmpEmail = this.empDetails.email
        return { EmpIDName: this.EmpIDwithName, EmpName: this.EmpName, EmpEmail: this.EmpEmail}
  }

  plantList: any[] = [];
  async getPlant() {
    const apiUrl = environment.apiurls + '/Plantid';
    const response: any = await this.http.get(apiUrl).toPromise();
    if (response) {
      this.plantList = response;
    }
  }
  
}
