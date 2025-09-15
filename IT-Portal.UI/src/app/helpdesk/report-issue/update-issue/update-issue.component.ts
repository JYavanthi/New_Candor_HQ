import { Component } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { environment } from '/IT_Portal/IT-Portal/IT-Portal.UI/src/environments/environment'
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-issue',
  templateUrl: './update-issue.component.html',
  styleUrl: './update-issue.component.css'
})
export class UpdateIssueComponent {
  private apiurl = environment.apiurls

  constructor(private http: HttpClient, private route:ActivatedRoute,private router: Router) {

  }

  ngOnInit(): void {
    this.getplant();
    this.getcategorytype();
    this.getcategory();
    this.fetchAllItems();
    this.getupdatevalue();
    this.getidupdate();
  }

  issuelistid:any;

  getidupdate() {
    this.issuelistid = this.route.snapshot.paramMap.get('id');
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
        this.plantcode = response;
      },
      (error) => {
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
        this.categorydata = response;
        console.log(this.categorydata)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  categorytype: any[] = [];

  getcategorytype() {

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
        this.categorytype = response;
        console.log(this.categorytype)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  issueRaisedBy: any;
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
  remarks: any = '';
  submitissue() {
     
    const apiUrl = this.apiurl + '/IssueList/SaveIssue'
    const issuesraisedfor = this.issueRaiseFor.split("-")[0];
    const issuesRaisedBy = this.issueRaisedBy.split("-")[0];
    const requestBody = {
      "flag": "U",
      "issueId":this.updatevalue[0].issueId,
      "issueRaisedBy": issuesRaisedBy,
      "issueDate": this.issueDate,
      "issueShotDesc": this.issueShotDesc,
      "issueDesc": this.issueDesc,
      "issueRaiseFor": issuesraisedfor,
      "issueForGuest": this.issueForGuest,
      "guestCompany": this.guestCompany,
      "plantId": this.plantId,
      "assetId": this.assetId,
      "categoryId": this.categoryId,
      "categoryTypId": this.categoryTypId,
      "priority": this.priority,
      "source": this.source,
      "attachment": this.attachment,
      "status": "Issue Raised",
      "remarks": "ssssssss",
      "createdBy": 1
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
        this.router.navigate(['/report_issue']);
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }

  /*search filter*/
  dropdownItems: string[] = [];
  selectedValue: string = '';
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

 //get update values
 updatevalue: any[] = [];
  getupdatevalue() {
    
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
        this.updatevalue = response.filter((row: any) => row.issueId === parseInt(this.issuelistid));
        console.log("update issues",this.updatevalue)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }
}
