import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';
import { Router } from '@angular/router';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-support-view',
  templateUrl: './support-view.component.html',
  styleUrl: './support-view.component.css'
})
export class SupportViewComponent {

  constructor(private http: HttpClient, private route: Router) {
    this.joinsupportTeam();
    this.filteredData = this.supportAssignName;
  }


  private apiurl = environment.apiurls;
  supportTeamAssgnId: any = '';
  supportName: { supportTeamAssgnId: number; supportTeamId: number; firstName: string; middleName: string; lastName: string, name: string }[] = []

  supportTeamname: any = ''
  joinsupportTeam() {
    this.supportName = this.supportTeamAssign.map(item => ({
      ...item,
      ...this.supportTeamname.find((innerItem: any) => innerItem.firstname === item.id)
    }))
  }

  supportTeam: any = '';
  supportTeamAssign: any[] = []
  plantid: any[] = [];
  ngOnInit(): void {
    this.getsupportteamid();
    this.getplant();
  }

  getsupportteamid() {
    this.http.get(this.apiurl + '/SupportTeam').subscribe((response1: any) => {
      this.supportTeam = response1;

      this.http.get(this.apiurl + '/SupportteamAssigned').subscribe((response2: any) => {

        this.supportTeamAssign = response2;
        this.http.get(this.apiurl + '/Plantid').subscribe((response3: any) => {
          this.plantid = response3
          this.combineData();
        });
      });
    });
  }

  filteredData: any[];
  searchText: string = '';
  paginatedTableData: any[] = [];
  pageIndex = 0;
  pageSize = 10;
  totalItems = 0;

  filterData() {
    this.filteredData = this.supportTeam.filter((item: any) =>
      item.firstName.toUpperCase().includes(this.searchText.toUpperCase())
    );
  }

  supportAssignName: any[] = [];
  combineData() {
    this.supportAssignName = this.supportTeam.map((item: any) => ({
      ...item,
      ...this.supportTeamAssign.find((innerItem: any) => innerItem.supportTeamId === item.supportTeamId)
    }));
    this.filterData();
  }

  plant: any[] = [];
  getplant() {

    const apiUrls = this.apiurl + '/Plantid'
    const requestBody = {

    }
    const httpOptions = {
      headers: new HttpHeaders({
        'content-Type': 'application/json'
      })
    };
    this.http.get(apiUrls, requestBody).subscribe(
      (response: any) => {
        this.plant = response
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  deleteconfirmation: boolean = false;
  deletesupportid: any;
  deletesupportassignid: any;
  deleteempid: any;
  deletespassign: any;
  deleteplantid: any;
  deletecategoryid: any;
  deleteclassificationid: any;
  isapprover: boolean = false;

  deleteRow(delsupportTeamId: any, employeeid: any, supporteamassignid: any, plantid: any, categoryid: any, classificationid: any, isapprover: any) {
    this.deletesupportid = delsupportTeamId

    this.deleteempid = employeeid

    this.deleteplantid = plantid
    this.deletecategoryid = categoryid
    this.deleteclassificationid = classificationid
    this.deletesupportassignid = supporteamassignid

    this.isapprover = isapprover

    this.deleteconfirmation = true
    /*setTimeout(() => {
      this.deleteSupportTeam()
    }, 500);*/

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
    const apiUrl = this.apiurl + '/SupportTeam/PostSupportTeam';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    const requestBody = {
      "flag": "D",
      "supportTeamId": Number(this.deletesupportid),
      "supportTeamAssgnID": Number(this.deletesupportassignid),
      "email": "email",
      "firstName": "firstName",
      "middleName": "middleName",
      "lastName": "lastName",
      "imgUrl": "imgUrl",
      "designation": "designation",
      "role": "role",
      "empId": Number(this.deleteempid),
      "isActive": false,
      "dol": "2024-04-10T19:05:12.91",
      "dob": "1976-03-06",
      "isAdmin": false,
      "isApprover": this.isapprover,
      "isChangeAnalyst": false,
      "isSupportEngineer": false,
      "plantId": Number(this.deleteplantid),
      "supportId": 1,
      "categoryTypID": 0,
      "categoryId": Number(this.deletecategoryid),
      "classificationId": Number(this.deleteclassificationid),
      "approverstageCR": "N",
      "approverstageR": "R",
      "approverstageC": "C",
      "level": 1,
      "approverstage2CR": "N",
      "approverstage2R": "R",
      "approverstage2C": "C",
      "level2": 2,
      "approverstage3CR": "N",
      "approverstage3R": "R",
      "approverstage3C": "C",
      "level3": 3,
      "createdBy": 1,
      "createdDate": "2024-04-10T19:05:12.91"
    };
    setTimeout(() => {
      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
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

  // Pagination variables
  currentPage = 1;
  //pageSize = 15; // Adjust as per your requirement

  //get totalItems(): number {
  //return this.filteredData.length;
  //}
  onPageChange(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.filterData();
  }
  /*get pagedData(): any[] {
   *//* const startIndex = (this.currentPage - 1) * this.pageSize;*//*
 this.totalItems = this.filteredData.length;
 const startIndex = this.pageIndex * this.pageSize;
 const endIndex = startIndex + this.pageSize;
 this.paginatedTableData = this.filteredData.slice(startIndex, endIndex);
 return this.paginatedTableData;
}*/

  get pagedData(): any[] {
    const startIndex = this.pageIndex * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.totalItems = this.filteredData.length;
    return this.filteredData.slice(startIndex, endIndex).map((item, index) => ({
      ...item,
      srNo: startIndex + index + 1
    }));
  }

  // Handle page change event
  /*onPageChange(page: number): void {
    this.currentPage = page;
  }*/

  navigate(suppID: any) {
    this.route.navigate(['/mastermodule/userconfiguration'], { queryParams: { suppID: suppID } });
  }

}



