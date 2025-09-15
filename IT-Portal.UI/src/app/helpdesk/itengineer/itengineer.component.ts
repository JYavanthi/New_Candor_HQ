import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';import { environment } from '@environments/environment';
import { PasscrdataService } from 'app/change-request/passcrdata.service';


@Component({
  selector: 'app-itengineer',
  templateUrl: './itengineer.component.html',
  styleUrl: './itengineer.component.css'
})
export class ItengineerComponent {
  private apiurl = environment.apiurls

  supportid: any;
  today: any;
  selectedOption: string = '';
  EmployeeID: string = '';
  Name: string = '';
  Email: string = '';
  DateofBirth: string = '';
  Designation: string = '';
  Plant: string = '';

  constructor(private http: HttpClient, private route: Router, private routeservice:PasscrdataService,private router: ActivatedRoute ) 
  {
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;

    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
  }

  ngOnInit(): void {
    this.getidupdate();
    this.getupdatevalue();
    this.getplant();
    this.getcategory();
    this.fetchAllItems();
    this.priorityapi();
    this.getassignto();
  }

  RadioFunc() {
    if (this.selectedOption === "self") {
      this.EmployeeID = '135055';
      this.Name = 'Michael Sameirang Khundrakpam';
      this.Email = 'muthusamy.c@techvaraha.com';
      this.DateofBirth = '01-22-1984'
      this.Designation = 'Assistant General Manager   - IT';
      this.Plant = 'ML00';
    } else if (this.selectedOption === "others") {
      this.EmployeeID = '';
      this.Name = '  ';
      this.Email = '';
      this.DateofBirth = ''
      this.Designation = '';
      this.Plant = '';
    }
  }



  isVisible = false;

  toggleVisibility() {
    this.isVisible = !this.isVisible;
  }

  plantcode: any[] = [];

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
        console.log(response);
        this.plantcode = response;
        console.log(this.plantcode)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
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
        this.categorydata = response.filter((item: any) => item.supportId === 3);
        console.log(this.categorydata)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  categorytype: any[] = [];

  getcategorytype() {
    debugger
    const apiUrls = this.apiurl + '/CategoryTyp'
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
        this.categorytype = response.filter((item: any) => item.categoryId === parseInt(this.categoryId))
        console.log(this.categorytype)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  prioritytype: any[] = [];

  priorityapi() {
    const apiUrls = this.apiurl + '/Priority'
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
        this.prioritytype = response;
        console.log(this.categorydata)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }


  onsubmit() {
    this.checkassigned();
    this.submitissue();
  }

  checkassigned() {
    if (this.assignedtosearch != " ") {
      this.assignedBy = this.supportid
      this.assignedOn = this.today
    }
  }


  issueRaisedBy: any='';
  issueDate: any = '';
  issueShotDesc: any = '';
  issueDesc: any = '';
  issueRaiseFor: any = '';
  issueForGuest: any = '';
  guestCompany: any = '';
  plantId: any = '';
  assetId: any = '';
  categoryId: any = '';
  categoryTypId: any = '';
  priority: any = '';
  source: any = '';
  attachment: any = '';
  status: any = '';
  assignedTo: any = '';
  assignedBy: any = '';
  assignedOn: any = '';
  remarks: any = '';
  issuesraisedfor: any = '';
  assignedtosearch: any = '';
  messagesuccess: boolean = false;
  messageerror: boolean = false;
  Category: string = '';


  submitissue() {
    const apiUrl = this.apiurl + '/IssueList/SaveIssue'
    this.issuesraisedfor = this.issueRaiseFor.split("-")[0];
    this.assignedtosearch = this.assignedTo.split("-")[0];
    const issuesRaisedBy = this.issueRaisedBy.split("-")[0];
    const requestBody = {
      "flag": "I",
      "issueRaisedBy": Number(this.supportid),
      "issueDate": this.today,
      "issueShotDesc": this.issueShotDesc,
      "issueDesc": this.issueDesc,
      "issueRaiseFor": Number(this.issuesraisedfor),
      "issueForGuest": this.issueForGuest,
      "guestCompany": this.guestCompany,
      "plantId": this.plantId,
      "assetId": Number(this.assetId),
      "categoryId": Number(this.categoryId),
      "categoryTypId": Number(this.categoryTypId),
      "priority": this.priority,
      "source": this.source,
      "attachment": this.attachment,
      "status": "Issue Raised",
      "assignedTo": Number(this.assignedtosearch),
      "assignedBy": Number(this.assignedBy),
      "assignedOn": this.assignedOn,
      "remarks": this.remarks,
      "createdBy": Number(this.supportid)
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(apiUrl, requestBody, httpOptions).subscribe(
      (response: any) => {
        console.log(response);
        this.messagesuccess = true
        /*alert("Saved Successfully!");
        this.route.navigate(['/report_issue']);*/
      },
      (error: any) => {
        console.log('Post request failed', error);
        this.messageerror = true;
      });
  }

  navigatesuccess() {
    this.route.navigate(['/report_issue']);
  }

  closeNotification() {
    this.messageerror = false;
  }

  /*search filter*/



  dropdownItems: string[] = [];
  selectedValue: string = '';
  supportteamname: string[] = [];
  supportnames: string[] = [];
  employeeprofile: any[] = [];
  supportpersonname = '';
  firstname: any;
  middlename: any;
  lastname: any;

  fetchAllItems() {
    const apiUrl = this.apiurl + '/EmployeeMasters';
    this.http.get<any[]>(apiUrl).subscribe(
      (response: any[]) => {
        console.log("Function", response);
        this.supportnames = response.map(item => item.employeeId + '-' + item.firstName + ' ' + item.middleName + ' ' + item.lastName);
        this.supportteamname = this.supportnames;
        console.log("Suppoert Team Name", this.supportteamname);
        this.employeeprofile = response.filter((row: any) => row.employeeId === this.supportid.trim());
        this.firstname = this.employeeprofile[0].firstName;
        this.middlename = this.employeeprofile[0].middleName;
        this.lastname = this.employeeprofile[0].lastName;
        /*this.supportpersonname = this.firstname + this.middlename + this.lastname;*/
        if (this.firstname !== null && this.firstname !== undefined) {
          this.supportpersonname += this.firstname;
        }

        if (this.middlename !== null && this.middlename !== undefined) {
          // If the supportpersonname is not empty, add a space before concatenating middle name
          if (this.supportpersonname !== '') {
            this.supportpersonname += ' ';
          }
          this.supportpersonname += this.middlename;
        }

        if (this.lastname !== null && this.lastname !== undefined) {
          // If the supportpersonname is not empty, add a space before concatenating last name
          if (this.supportpersonname !== '') {
            this.supportpersonname += ' ';
          }
          this.supportpersonname += this.lastname;
        }

        // If all parts of the name are null or undefined, set supportpersonname to 'Unknown'
        if (this.supportpersonname === '') {
          this.supportpersonname = 'Unknown';
        }


        // If all parts of the name are null, set supportpersonname to 'Unknown'
        if (this.supportpersonname === '') {
          this.supportpersonname = 'Unknown';
        }
      },
      (error: any) => {
        console.error('GET request failed', error);
      }
    );
  }

  filterItems() {
    const filter = this.issueRaiseFor.toUpperCase();
    this.dropdownItems = this.supportteamname.filter(item =>
      item.toUpperCase().includes(filter)
    );
    if (this.dropdownItems.length === 0 && filter !== '') {
      this.dropdownItems.push('No name found');
    }
    else if (filter === '') {
      this.dropdownItems.length = 0
    }

  }
  selectItem(item: string) {
    this.selectedValue = item;
    this.issueRaiseFor = item;
    this.dropdownItems = [];
  }

  dropdownItemscr: string[] = [];
  selectedValuecr: string = '';
  filterItemscr() {
    const filter = this.issueRaisedBy.toUpperCase();
    this.dropdownItemscr = this.supportteamname.filter(item =>
      item.toUpperCase().includes(filter)
    );
    if (this.dropdownItems.length === 0 && filter !== '') {
      this.dropdownItemscr.push('No name found');
    }
    else if (filter === '') {
      this.dropdownItemscr.length = 0
    }
  }

  selectItemcr(item: string) {
    this.selectedValuecr = item;
    this.issueRaisedBy = item;
    this.dropdownItemscr = [];
  }

  assigntofilter: any[] = [];

 getassignto() {
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
        this.assigntofilter = response.map((item: { supportTeamId: string; firstName: string; middleName: string; lastName: string; }) => item.supportTeamId + '-' + item.firstName + ' ' + item.middleName + ' ' + item.lastName);
        console.log(this.categorydata)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  dropdownItemsassign: string[] = [];
  selectedValueassign: string = '';
  filterItemsassign() {
    const filter = this.assignedTo.toUpperCase();
    this.dropdownItemsassign = this.assigntofilter.filter(item =>
      item.toUpperCase().includes(filter)
    );
    if (this.dropdownItems.length === 0 && filter !== '') {
      this.dropdownItemsassign.push('No name found');
    }
    else if (filter === '') {
      this.dropdownItemsassign.length = 0
    }
  }

  selectItemassign(item: string) {
    this.selectedValueassign = item;
    this.assignedTo = item;
    this.dropdownItemsassign = [];
  }
  //Breadcrumb
  // constructor(private http: HttpClient, private route: Router, private router: ActivatedRoute) {

  // }

  //private apiurl = environment.apiurls

  // ngOnInit(): void {
  //   this.getidupdate();
  //   this.getupdatevalue();
  // }

  urlissueid: any;
  getidupdate() {
    this.urlissueid = this.router.snapshot.paramMap.get('id');
  }


  proposedResolutionOn: any;
  resolutionDt: any;
  resolutionRemarks: any;

  issueresolution() {

    const apiUrl = this.apiurl + '/IssueResolution/IssueResolution'
    const requestBody = {
      "flag": "U",
      "issueId": Number(this.urlissueid),
      "proposedResolutionOn": this.proposedResolutionOn,
      "resolutionDt": this.resolutionDt,
      "resolutionRemarks": this.resolutionRemarks,
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
  }

  updatevalue: any[] = [];
  getupdatevalue() {
    debugger
    const apiUrls = this.apiurl + '/IssueList/Getissuelist'
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
        this.updatevalue = response.filter((row: any) => row.issueId === parseInt(this.urlissueid));
        console.log("update issues",this.updatevalue)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }


}
