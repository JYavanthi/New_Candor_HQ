import { Component, ViewChild, ViewEncapsulation  } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';
import { HelpdeskserviceService } from '../../helpdeskservice.service';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { PasscrdataService } from '../../../change-request/passcrdata.service';
import { FormBuilder } from '@angular/forms';

interface DropdownItem {
  item_id: number;
  item_text: string;
}

@Component({
  selector: 'app-issue-resolution',
  templateUrl: './issue-resolution.component.html',
  styleUrl: './issue-resolution.component.css',
})
export class IssueResolutionComponent {
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  paginatedTableData: any[] = [];
  pageIndex = 0;
  pageSize = 5;
  totalItems = 0;
  editIndex: number = -1;
  DeleditIndex: number = -1;
  ShowAssignTo: boolean = false;
  checkbox: any = '';
  DisableAssign: boolean = true;
  ClickUpdate: boolean = false;
  viewIssueFiltered: any;
  tablevalueshow: boolean = false;
  fromDt: any = '';
  endDt: any = '';
  today: any;
  supportid: any;
  
 
  

  

  tableData: any[] = [];
  statuses: any[] = ['Open', 'Progress', 'Seek Clarification', 'On Hold', 'Cancelled', 'Waiting for Spare', 'Waiting for Vendor', 'Resolved', 'Closed'];
  assets: any[] = [{ id: 1, Asset: 'Wifi' }, { id: 2, Asset: 'Internet' }, { id: 3, Asset: 'Hard Disk' }, { id: 4, Asset: 'Pen Drive' }];
  categoryData: any[] = [{ id: 1, Asset: 'Infra' }, { id: 2, Asset: 'Network' }, { id: 3, Asset: 'Security' }, { id: 4, Asset: 'End User Drive' }, { id: 5, Asset: 'SAP' }];
  constructor(private http: HttpClient, private fb: FormBuilder, private routeservice: PasscrdataService, private helpdeskservice: HelpdeskserviceService, private route: Router, private router: ActivatedRoute, private helpservice: HelpdeskserviceService) {
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
  }

  private apiurl = environment.apiurls

  ngOnInit(): void {
    this.filterForm = this.fb.group({
      plantId: [],
      Category: [],
      subCategory: '',
      Priority: '',
      StartDate: '',
      EndDate: '',
      Status: '',
      rfcChangeNumber: ''
    })
    this.fetchDropdownData();
    this.fetchCategoryData();
    this.getidupdate();
    this.getissuelist();
    this.getupdatevalue();
    this.getpriority();
    
  }


  /*-----------------------Filter--------------------------------start*/

  dropdownList: DropdownItem[] = [];
  filterflag: boolean = false;
  selectedPlantIds: any[] = [];
  impactedLocation: any = '';
  selectedlocationNames: any = '';
  dropdowncategroy: DropdownItem[] = [];
  selectedCategoryId: any[] = [];
  selectedcategroy: any = '';
  filtersdata: any[] = [];
  issuelist: any = '';
  categoryId: any = '';
  Category: any = '';
  StartDate:  string = '';
  EndDate:  string = '';
  prioritytypeid: string = '';
  filterForm: any;


  dropdownSettings = {
    idField: 'item_id',
    textField: 'item_text',
  };

  fetchDropdownData(): void {
    const apiUrl = this.apiurl + '/Plantid'; //Replace with your API endpoint
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdownList = data.map(item => ({
          item_id: item.id,
          item_text: item.code //Assuming your API response has 'id' and 'name' fields
        }));
      },
      (error) => {
        console.error('Error fetching dropdown data:', error);
      }
    );
  }
  fetchCategoryData(): void {
    const apiUrl = this.apiurl + '/Category' // Replace with your API endpoint
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdowncategroy = data.map(item => ({
          item_id: item.itcategoryId,
          item_text: item.categoryName // Assuming your API response has 'id' and 'name' fields
        }));
        console.log(this.dropdowncategroy);
      },
      (error) => {
        console.error('Error fetching dropdown data:', error);
      }
    );
  }
  mapedplantdatas() {
    this.impactedLocation = this.selectedPlantIds.map((item: any) => item.item_id);
    console.log('Plant:', this.impactedLocation)
    this.selectedlocationNames = Array.from(new Set(this.impactedLocation));
  }

  mapedcategoryatas() {
    this.impactedLocation = this.selectedCategoryId.map((item: any) => item.item_id);
    console.log(this.impactedLocation)
    this.selectedcategroy = Array.from(new Set(this.impactedLocation));
  }

  onclickfilter() {
    //this.resetfn();
    this.filterdropdown();
  }

  filterdropdown() {
    this.paginatedTableData = this.issuelist
    this.paginatedTableData = this.paginatedTableData.filter(m => {
      return (
        ((this.filterForm.controls['plantId'].value == null ||
          this.filterForm.controls['plantId'].value.length == 0) ? true : (this.filterForm.controls['plantId'].value.map((b: any) => { return b.item_id }).indexOf(m.plantId) != -1))
        && ((this.filterForm.controls['Category'].value == null ||
          this.filterForm.controls['Category'].value.length == 0) ? true : (this.filterForm.controls['Category'].value.map((a: any) => { return a.item_id }).indexOf(m.categoryId) != -1))
        && ((this.filterForm.controls['subCategory'].value == '' || this.filterForm.controls['subCategory'].value == null) ?
          true : (m.categoryTypId == this.filterForm.controls['subCategory'].value))
        && ((this.filterForm.controls['Priority'].value == '' || this.filterForm.controls['Priority'].value == null) ?
          true : (m.priorityid == this.filterForm.controls['Priority'].value))
        && ((this.filterForm.controls['Status'].value == '' || this.filterForm.controls['Status'].value == null) ?
          true : (m.status.trim() == this.filterForm.controls['Status'].value))
        && ((this.filterForm.controls['StartDate'].value == '' || this.filterForm.controls['StartDate'].value == null) ?
          true : (m.createdDt > this.filterForm.controls['StartDate'].value))
        && ((this.filterForm.controls['EndDate'].value == '' || this.filterForm.controls['EndDate'].value == null) ?
          true : (m.createdDt < this.filterForm.controls['EndDate'].value))
      )
    })
    this.paginatedTableData = this.parseAndSortResponse(this.paginatedTableData)
    this.totalItems = this.paginatedTableData.length;
    this.paginatedTableData = this.paginatedTableData.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize);
  }

  resetfn() {
    this.selectedPlantIds = [];
    this.selectedCategoryId = [];
    this.Category = '';
    this.prioritytypeid = '';
    this.statusfilter = '';
    this.fromDt = '';
    this.endDt = '';
    this.filterForm.reset()
    this.getissuelist();
    this.DisableAssign = true;
    this.ShowAssignTo = false;

  }

  parseAndSortResponse(response: any): any[] {
    let parsedResponse = response.map((item: any) => {
      return item;
    });
    parsedResponse.sort((a: any, b: any) => {
      if (a.itcrid < b.itcrid) {
        return 1;
      }
      if (a.itcrid > b.itcrid) {
        return -1;
      }
      return 0;
    });
    return parsedResponse;
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
        this.categorytype = response.filter((item: any) => item.categoryId === parseInt(this.categoryId))
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  /*-----------------------Filter--------------------------------end*/
  getissuelist() {

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
        this.issuelist = response.filter((item: any) => item.raisedbyid === parseInt(this.supportid));
        this.totalItems = this.issuelist.length;
        /*this.paginatedTableData = this.issuelist.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize);
        console.log('holamigo'+this.issuelist)*/
        this.filterdropdown()
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  onPageChange(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.getissuelist();
  }


  selectedStatus: { [key: string]: boolean } = {
    'All': false,
    'New': false,
    'Submit': false,
    'Approved': false,
    'Rejected': false,
    'Implement': false,
    'Pending': false,
    'Release': false,
    'Completed': false,

    // Add other status values here
  };

  /* ----------------------------------*/
  isVisible = true;
  empid: string = '';
  IssueCode: any = '';

  toggleVisibility() {
    this.isVisible = !this.isVisible;
  }

  selectedRow: any[] = [];
  toggleRowSelection(row: any) {
    if (row.selected) {
      this.selectedRow.push(row);
    }
    else {
      this.selectedRow = this.selectedRow.filter((r) => r !== row);
    }

    if (this.selectedRow.length > 0) {
      this.ClearAssign();
      this.DisableAssign = false;
    } else {
      this.ClearAssign();
      this.DisableAssign = true;
      this.ShowAssignTo = false;
    }
  }

  Next() {
    const selectedData = {
      selectedVal: this.selectedRow
    }
    this.helpdeskservice.getUpdateIssueResolutionData({ selectedData });
    if (this.selectedRow.length == 1) {
      this.route.navigate(['/update_issue_resolution/' + this.selectedRow[0].issueId + '/edit'])
    }
    else {
      alert("Select a issue to view")
    }
  }
  
  tablevalue: any;
  function() {
    if (this.tablevalueshow == false) {
      this.tablevalue = this.paginatedTableData
    }
    else {
      this.tablevalue = this.viewIssueFiltered
    }
  }

  
  selectradio: any = '';
/*  onIssue(row: any) {
    this.selectradio = row;
    this.helpservice.setSelectedRadio(JSON.stringify(row));
    console.log("value from radio button", this.selectradio)
    this.updatepage();
  }*/

  /*updatepage() {
    const report = {
      value: this.selectradio
    }
    this.helpservice.changerequestdata({ report })
  }*/

  statusfilter: any;
  plantscode: any;
  prioritydata: any[] = [];
  getpriority() {

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
        this.prioritydata = response;
        console.log("Priority data test", this.prioritydata)
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }
  /* ----------------------------------*/

  urlissueid: any;
  getidupdate() {
    this.urlissueid = this.router.snapshot.paramMap.get('id');
  }


  proposedResolutionOn: any;
  resolutionDt: any;
  resolutionRemarks: any;
  Type: string = '';
  Asset: string = '';
  FromDate: string = '';
  ToDate: string = '';
  Plant: string = '';
  Priority: string = '';
  Source: string = '';
  ImpactedAsset: string = '';
  SelectStatus: string = '';
  selectedRows: any[] = [];
  SelectPlant: string = '';
  SelectServiceCategory: string = '';
  SelectSubCategory: string = '';
  SelectAssignTo: string = '';

  
  

 

  toggleselectionRow(row: any) {
    if (row.selected) {
      this.selectedRows = [];
      this.selectedRows = [row];
      this.SelectStatus = row.status.trim();
      this.Asset = row.assetId;
      this.Category = row.categoryName;
      this.Type = row.categoryType;
      this.Plant = row.plantname;
      this.Source = row.source;
      this.Priority = row.priorityName;
    }
    else {
      this.selectedRows = this.selectedRows.filter((r) => r !== row);
    }
  }

  errorMessage: any = '';
  successMessage: any = '';

  clearErrorMessage() {
    this.errorMessage = '';
  }
  clearSuccessMessage() {
    this.successMessage = '';
  }

  issueresolution() {
    if (this.SelectStatus == "") {
      this.errorMessage = 'Select Status';
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('select[ngModel="SelectStatus"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else if (this.Category == "") {
      this.errorMessage = "Category shouldn't be empty";
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('select[ngModel="Category"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else if (this.Type == "") {
      this.errorMessage = "Type shouldn't be empty";
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('select[ngModel="Type"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else if (this.Asset == "") {
      this.errorMessage = "Asset shouldn't be empty";
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('select[ngModel="Asset"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else if (!this.FromDate) {
      this.errorMessage = "Select From Date";
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('select[ngModel="FromDate"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else if (!this.ToDate) {
      this.errorMessage = "Select To Date";
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('select[ngModel="ToDate"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else if (this.Plant == "") {
      this.errorMessage = "Plant shouldn't be empty";
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('select[ngModel="Plant"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else if (this.Priority) {
      this.errorMessage = "Priority shouldn't be empty";
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('select[ngModel="Priority"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else if (this.Source) {
      this.errorMessage = "Source shouldn't be empty";
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('select[ngModel="Source"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else if (!this.proposedResolutionOn) {
      this.errorMessage = "Select the Date from Proposed Resolution On";
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('select[ngModel="proposedResolutionOn"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else if (!this.resolutionDt) {
      this.errorMessage = "Select Resolution Date";
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('select[ngModel="resolutionDt"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else if (this.resolutionRemarks) {
      this.errorMessage = "Resolution Remarks shouldn't be empty";
      window.scrollTo({ top: 0, behavior: 'smooth' });
      const inputElement = document.querySelector<HTMLInputElement>('select[ngModel="resolutionRemarks"]');
      if (inputElement) {
        inputElement.focus();
      }
    }
    else {
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
  }

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
        this.tableData = response;
        this.totalItems = response.length;
        this.paginatedTableData = this.tableData.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize);
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  

  SeekClarification() {
    alert('Submitted to Seek Clarification.')
  }

  AssignTo() {
    this.ClearAssign();
    this.ShowAssignTo = !this.ShowAssignTo
  }

  ClearAssign() {
    this.SelectPlant = '';
    this.SelectServiceCategory = '';
    this.SelectSubCategory = '';
    this.SelectAssignTo = '';
  }

}
