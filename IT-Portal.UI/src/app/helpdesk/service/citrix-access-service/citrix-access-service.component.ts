import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { PasscrdataService } from '../../../change-request/passcrdata.service';
import { Router } from '@angular/router';import { environment } from '@environments/environment';

@Component({
  selector: 'app-citrix-access-service',
  templateUrl: './citrix-access-service.component.html',
  styleUrl: './citrix-access-service.component.css'
})
export class CitrixAccessServiceComponent {

  supportid: any;
  today: any;
  constructor(private http: HttpClient, private routeservice: PasscrdataService, private route: Router) {
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;

    const currentDate = new Date()
    this.today = currentDate.toISOString().slice(0, 10);
  }

  private apiurl = environment.apiurls;
  ngOnInit() {
    this.getPlantid();
    this.getCategory();
    this.getsubCategory();
    this.getprioritytyp();
    this.getsupportteams();
    this.fetchAllItems();
  }
  requestfor: any = '';
  providenewaccess:boolean= false
  removeaccess:boolean= false
  changevalue() {
    
    if (this.requestfor == 'providenewaccess') {
      this.providenewaccess = true;
      this.removeaccess = false;
    }
    else if (this.requestfor == 'removeaccess') {
      this.providenewaccess = false;
      this.removeaccess = true;
    }
    else {
      this.providenewaccess = false;
      this.removeaccess = false;
    }
  }

  israisedfor: boolean = false
  plantcode: any[] = [];
  getPlantid() {

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

  categoryName: any[] = [];
  getCategory() {

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
        this.categoryName = response
        console.log(this.categoryName)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  subcategoryName: any[] = [];
  getsubCategory() {
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
        this.subcategoryName = response
        console.log(this.subcategoryName)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  prioritytyp: any[] = [];
  getprioritytyp() {
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
        this.prioritytyp = response
        console.log(this.subcategoryName)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }


  supportteams: any[] = [];
  getsupportid: any;
  supportpersonname = '';
  firstname: any;
  middlename: any;
  lastname: any;
  emailofreciver: any;
  getsupportteams() {

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
        this.supportteams = response.filter((row: any) => row.empId === parseInt(this.supportid.trim()));
        this.getsupportid = this.supportteams[0].supportTeamId;
        this.firstname = this.supportteams[0].firstName;
        this.middlename = this.supportteams[0].middleName;
        this.lastname = this.supportteams[0].lastName;
        this.emailofreciver = this.supportteams[0].email;
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
      (error) => {
        console.error("Post failed", error)
      }
    )
    this.getsupportteamassign();
  }

  supportteamassign: any[] = [];
  ischangeanalyst: any;
  isapprover: any;
  issupportegineer: any;
  assignedplant: any;
  assignedcat: any;
  mapplant: any;
  mapcategory: any;

  getsupportteamassign() {

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
        this.supportteamassign = response.filter((row: any) => row.supportTeamId === this.getsupportid);
        this.mapplant = this.supportteamassign.map((item: any) => item.plantId);
        this.assignedplant = Array.from(new Set(this.mapplant));
        this.mapcategory = this.supportteamassign.map((item: any) => item.categoryId);
        this.assignedcat = Array.from(new Set(this.mapcategory));
        this.isapprover = this.supportteamassign[0].isApprover
        this.issupportegineer = this.supportteamassign[0].isSupportEngineer
        this.ischangeanalyst = this.supportteamassign[0].isChangeAnalyst
        console.log("PlantLogin", this.assignedplant)
        console.log("CateLogin", this.assignedcat)
      },

      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  dropdownItems: string[] = [];
  selectedValue: string = '';
  supportteamname: string[] = [];
  supportnames: string[] = [];
  employeeprofile: any[] = [];
  issueRaiseFor: any = '';
  employeename: any='';
  empfirstname: any;
  empmiddlename: any;
  emplastname: any;

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

  srdate: any = '';
  shotDesc: any = '';
  srDesc: any = '';
  plantID: any = '';
  assetID: any = '';
  categoryID: any = '';
  categoryTypID: any = '';
  priority: any = '';
  source: any = '';
  attachment: any = '';
  serviceraisedfor: any = '';
  messagesuccess: boolean = false;
  deletesuccess: boolean = false;
  deletemessage: any = '';
  messageerror: boolean = false;
  errormessage: any;
  errorresponse: any;
  submitservicecitrix() {
    
    const apiUrl = this.apiurl + '/ServiceCitrixlist/ServiceCitrix'
    this.serviceraisedfor = this.issueRaiseFor.split("-")[0];
    const requestBody = {
      "flag": "I",
      "serviceCitrixID": 1,
      "raisedBy": Number(this.supportid),
      "srDate": this.today,
      "shotDesc": this.shotDesc,
      "srDesc": this.srDesc,
      "srRaiseFor": Number(this.serviceraisedfor),
      "plantID": Number(this.plantID),
      "assetID": Number(this.assetID),
      "categoryID": Number(this.categoryID),
      "categoryTypID": Number(this.categoryTypID),
      "priority": Number(this.priority),
      "source": this.source,
      "service": "Citrix",
      "attachment": this.attachment,
      "status": "Raised",
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
        this.errorresponse = response.type
        if (this.errorresponse == "E") {
          this.deletesuccess = true;
          this.deletemessage = "Not Submitted"
        } else if (this.errorresponse == "S") {
          this.deletesuccess = true;
          this.deletemessage = "Submitted Successfully"
        }              
      },
      (error: any) => {
        console.log('Post request failed', error);
        this.messageerror = true;
      });
  }

  navigatesuccess() {
    this.deletesuccess = false
    if (this.errorresponse == "S") {
      this.route.navigate(['/service']);
    }
  }

  closeNotification() {
    this.messageerror = false
  }
}
