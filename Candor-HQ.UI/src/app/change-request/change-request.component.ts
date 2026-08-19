import { Component, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { FormBuilder } from '@angular/forms';
import { PasscrdataService } from './passcrdata.service';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { MatDialog } from '@angular/material/dialog';
import { AddFilePopUpComponent } from './add-file-pop-up/add-file-pop-up.component';
import { environment } from '@environments/environment';
import { firstValueFrom } from 'rxjs';
interface DropdownItem {
  item_id: number;
  item_text: string;
}
@Component({
  selector: 'app-change-request',
  templateUrl: './change-request.component.html',
  styleUrl: './change-request.component.css',
})

export class ChangeRequestComponent {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  selecttable: any;
  supportid: any;
  supportname: any;
  today: any;
  getstatus: any = '';
  crid: any = '';
  filterForm: any;
  getcrcode: string = '';
  user: any;
  currentDate = new Date().toISOString().slice(0, 10);


  constructor(private http: HttpClient, private routeservice: PasscrdataService, private router: Router, private route: ActivatedRoute,
    private fb: FormBuilder, private userInfo: UserInfoSerService) {

    this.routeservice.crdata.subscribe(data => {
      if (data && data.report) {
        this.crid = data.report.value;
        this.getstatus = this.crid.status.trim();
      }
    });
    this.routeservice.getsupportteam();
    this.supportid = this.routeservice.supporterID;
    this.supportname = this.routeservice.supporterName;
    this.user = this.userInfo.getUser()
    const currentDate = new Date();
    this.today = currentDate.toISOString().slice(0, 10);
    this.getsupportteams();
    this.getsupportteamassign();
    this.getviewcrdata();
    this.getsupportemgineers();
  }

  ngOnInit(): void {
    this.loadData();
    this.filterForm = this.fb.group({
      plantId: [],
      Category: [],
      ClassificationId: '',
      Priority: '',
      StartDate: '',
      EndDate: '',
      Status: '',
      rfcChangeNumber: '',
      stage: ''
    })
  }

  loadData() {
    this.getplant();
    this.getclassification();
    this.getcategory();
    //this.filterdropdown();
    //this.useraccess();
    //this.function();
    this.getpriority();
    this.fetchDropdownData();
    this.fetchCategoryData();
  }

  private apiurl = environment.apiurls

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
  supportteam: any[] = [];
  crfilter: any[] = [];

  paginatedTableData: any[] = [];
  pageIndex = 0;
  pageSize = 10;
  totalItems = 0;
  rptfilter: any = '';
  getviewcrdataList: any[] = [];

  async getviewcrdata() {
    const apiUrls = this.apiurl + '/ViewChangeRequest/ViewChangerequest';

    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.getviewcrdataList = response;
        //this.crfilter = response.filter((item: any) => item.changeRequestor === parseInt(this.supportid));
        this.rptfilter = response.filter((item: any) => item.changeRequestor === parseInt(this.supportid));
        this.viewchangerequest = response.filter((item: any) => item.changeRequestor === parseInt(this.supportid));
        console.log('response', this.viewchangerequest);
        this.filtersdata = this.parseAndSortResponse(this.rptfilter);
        this.totalItems = this.rptfilter.length;
        const startIndex = this.pageIndex * this.pageSize;
        const endIndex = startIndex + this.pageSize;
        this.filterChangeCr()
        return this.rptfilter
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }


  downFile(fileName: any): void {
    const apiUrl = this.apiurl + '/ChangeRequest/Download/' + fileName.attachId

    this.http.get(apiUrl, { responseType: 'blob' }).subscribe(
      (response: Blob) => {
        const url = window.URL.createObjectURL(response);
        const link = document.createElement('a');
        link.href = url;
        link.download = fileName.attachedFile;
        link.target = '_blank';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
        window.URL.revokeObjectURL(url);
      },
      (error: any) => {
        console.error('GET request failed', error);
      }
    );
  }

  onPageChange(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.filterChangeCr();
  }

  statusfilter: any;

  plantscode: any = '';
  categoryids: any = '';
  classificationid: any = '';
  prioritytypeid: any = '';
  fromDt: any = '';
  endDt: any = '';
  filterflag: boolean = false;
  searchrfcnumber: any = '';
  viewchangerequest: any[] = [];

  filtersdata: any[] = [];

  dropdownList: DropdownItem[] = [];
  dropdowncategroy: DropdownItem[] = [];
  dropdownSettings = {
    idField: 'item_id',
    textField: 'item_text',
  };

  fetchDropdownData(): void {
    const apiUrl = this.apiurl + '/Plantid';
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdownList = data.map(item => ({
          item_id: item.plantId,
          item_text: item.plantCode
        }));
      },
      (error) => {
        throw error
      }
    );
  }

  fetchCategoryData(): void {
    const apiUrl = this.apiurl + '/Category'
    this.http.get<any[]>(apiUrl).subscribe(
      (data) => {
        this.dropdowncategroy = data.map(item => ({
          item_id: item.itcategoryId,
          item_text: item.categoryName
        }));
      },
      (error) => {
      }
    );
  }

  selectedlocationNames: any = '';
  selectedcategroy: any = '';
  impactedLocation: any = '';
  selectedlocation: any = '';
  selectedPlantIds: any[] = [];
  selectedCategoryId: any[] = [];

  mapedplantdatas() {
    this.impactedLocation = this.selectedPlantIds.map((item: any) => item.item_id);
    this.selectedlocationNames = Array.from(new Set(this.impactedLocation));
  }

  filterdonutbyplant() {
    if (this.selectedlocationNames != '') {
      this.viewchangerequest = this.viewchangerequest.filter((item: any) => this.selectedlocationNames.includes(item.plantcode));
    }
  }

  mapedcategoryatas() {
    this.impactedLocation = this.selectedCategoryId.map((item: any) => item.item_id);
    this.selectedcategroy = Array.from(new Set(this.impactedLocation));
  }

  filterChangeCr() {
    this.viewchangerequest = this.rptfilter
    this.viewchangerequest = this.viewchangerequest.filter(m => {
      return (
        ((this.filterForm.controls['plantId'].value == null ||
          this.filterForm.controls['plantId'].value.length == 0) ? true : (this.filterForm.controls['plantId'].value.map((b: any) => { return b.item_id }).indexOf(m.plantcode) != -1))
        && ((this.filterForm.controls['Category'].value == null ||
          this.filterForm.controls['Category'].value.length == 0) ? true : (this.filterForm.controls['Category'].value.map((a: any) => { return a.item_id }).indexOf(m.itcategoryId) != -1))
        && ((this.filterForm.controls['ClassificationId'].value == '' || this.filterForm.controls['ClassificationId'].value == null) ?
          true : (m.itclassificationId == this.filterForm.controls['ClassificationId'].value))
        && ((this.filterForm.controls['Priority'].value == '' || this.filterForm.controls['Priority'].value == null) ?
          true : (m.priorityType == this.filterForm.controls['Priority'].value))
        && ((this.filterForm.controls['Status'].value == '' || this.filterForm.controls['Status'].value == null) ?
          true : (m.status == this.filterForm.controls['Status'].value))
        && ((this.filterForm.controls['StartDate'].value == '' || this.filterForm.controls['StartDate'].value == null) ?
          true : (m.crdate.split('T')[0] >= this.filterForm.controls['StartDate'].value))
        && ((this.filterForm.controls['EndDate'].value == '' || this.filterForm.controls['EndDate'].value == null) ?
          true : (m.crdate.split('T')[0] <= this.filterForm.controls['EndDate'].value))
        && ((this.filterForm.controls['rfcChangeNumber'].value == '' || this.filterForm.controls['rfcChangeNumber'].value == null) ?
          true : (m.crcode == this.filterForm.controls['rfcChangeNumber'].value))
        && ((this.filterForm.controls['stage'].value == '' || this.filterForm.controls['stage'].value == null) ?
          true : (m.stage == this.filterForm.controls['stage'].value))
      )
    })

    this.viewchangerequest = this.parseAndSortResponse(this.viewchangerequest)
    this.totalItems = this.viewchangerequest.length;
    this.viewchangerequest = this.viewchangerequest.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize);

  }

  updatecr(itcrid: number): void {
    this.router.navigate(['/updatecr', itcrid]);
  }

  plantcode: any[] = [];

  getplant() {
    const apiUrls = this.apiurl + '/Plantid'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.plantcode = response;
      },
      (error) => {
        throw error
      }
    )
  }

  classifications: any[] = [];

  getclassification() {
    const apiUrls = this.apiurl + '/Classification'

    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.classifications = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  categorydata: any[] = [];

  getcategory() {
    const apiUrls = this.apiurl + '/Category'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.categorydata = response;
      },
      (error) => {
        throw error
      }
    )
  }

  prioritydata: any[] = [];
  getpriority() {
    const apiUrls = this.apiurl + '/Priority'
    this.http.get(apiUrls).subscribe(
      (response: any) => {
        this.prioritydata = response;
      },
      (error) => {
        throw error
      }
    )
  }

  selectradio: any = '';
  gotoapprove(tabId: string) {
    if (this.selectradio != '') {
      const itcrid = this.selectradio.itcrid;
      this.router.navigate([`/executive/${itcrid}/edit`], { fragment: tabId });
      setTimeout(() => {
        const tabButton = document.getElementById(tabId + '-tab');
        if (tabButton) {
          tabButton.click();
        }
      });
      this.approvepage();
    } else {
      alert('Select the RFC');
    }
  }

  approvepage() {
    const report = {
      value: this.selectradio
    }
    this.routeservice.changerequestdata({ report })
  }

  updatepage() {
    const report = {
      value: this.selectradio
    }
    this.routeservice.changerequestdata({ report })
  }

  goToTab(tabId: string) {
    if (this.selectradio == '') {
      alert("Select the RFC")
    }
    else {
      const itcrid = this.selectradio.itcrid;
      this.router.navigate([`/executive/${itcrid}/edit`], { fragment: tabId });
      setTimeout(() => {
        this.excutepage();
      }, 1000);
    }
  }

  excutepage() {
    const report = {
      value: this.selectradio
    }
    this.routeservice.changerequestdata({ report })
  }

  onRadioSelect(row: any): void {
    this.selectradio = row;
    this.routeservice.setSelectedRadio(JSON.stringify(row));

  }

  onRadio(row: any): void {
    this.selectradio = row;
    // this.routeservice.setSelectedRadio(JSON.stringify(row));
    // this.updatepage();
    if (row.Status == 'Rejected') {
      alert('Change Request was rejected. Please check History for details');
      const actvFlg = { activeFlg: 'false' }
      // this.routeservice.getCRRejectData({ actvFlg })

    }
    else if (this.getstatus != 'Rejected') {
      const actvFlg = { activeFlg: 'true' }
      let urlNavigate = '/executive/' + (row['ITCRID'] ? row['ITCRID'] : row['itcrid']) + '/edit'
      this.router.navigate([urlNavigate]);
    }
  }

  supportengineers: any[] = [];
  filterexecutdata: any[] = [];
  supportteamcode: any = '';

  paginatedTableDataforsupport: any[] = [];
  pageIndexforsupport = 0;
  pageSizeforsupport = 10;
  totalItemsforsupport = 0;

  onPageChangeforsupport(event: PageEvent) {
    this.pageIndexforsupport = event.pageIndex;
    this.pageSizeforsupport = event.pageSize;
    this.filtersupportengineer();
  }

  async getsupportemgineers() {
    const apiUrls = this.apiurl + '/VwSupportEngineer'

    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.supportengineers = response;
        this.supportengineers = response.filter((item: any) => item.assgigntome === parseInt(this.supportid));
        this.filterexecutdata = this.parseAndSortResponse(this.supportengineers);
        this.filterexecutdata = this.filterexecutdata.filter((value: any, index: any, self: any) => self.indexOf(value) === index)
        this.totalItemsforsupport = this.filterexecutdata.length;
        this.filterexecutdata = this.filterexecutdata.slice(this.pageIndexforsupport * this.pageSizeforsupport, (this.pageIndexforsupport + 1) * this.pageSizeforsupport);
        this.filtersupportengineer();
      } else {
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  filtersupportengineer() {
    this.filterexecutdata = this.supportengineers
    this.filterexecutdata = this.filterexecutdata.filter(m => {
      return (
        ((this.filterForm.controls['plantId'].value == null ||
          this.filterForm.controls['plantId'].value.length == 0) ? true : (this.filterForm.controls['plantId'].value.map((b: any) => { return b.item_id }).indexOf(m.plantcode) != -1))
        && ((this.filterForm.controls['Category'].value == null ||
          this.filterForm.controls['Category'].value.length == 0) ? true : (this.filterForm.controls['Category'].value.map((a: any) => { return a.item_id }).indexOf(m.itcategoryId) != -1))
        && ((this.filterForm.controls['ClassificationId'].value == '' || this.filterForm.controls['ClassificationId'].value == null) ?
          true : (m.itclassificationId == this.filterForm.controls['ClassificationId'].value))
        && ((this.filterForm.controls['Priority'].value == '' || this.filterForm.controls['Priority'].value == null) ?
          true : (m.priorityType == this.filterForm.controls['Priority'].value))
        && ((this.filterForm.controls['Status'].value == '' || this.filterForm.controls['Status'].value == null) ?
          true : (m.status == this.filterForm.controls['Status'].value))
        && ((this.filterForm.controls['StartDate'].value == '' || this.filterForm.controls['StartDate'].value == null) ?
          true : (m.crdate.split('T')[0] >= this.filterForm.controls['StartDate'].value))
        && ((this.filterForm.controls['EndDate'].value == '' || this.filterForm.controls['EndDate'].value == null) ?
          true : (m.crdate.split('T')[0] <= this.filterForm.controls['EndDate'].value))
        && ((this.filterForm.controls['rfcChangeNumber'].value == '' || this.filterForm.controls['rfcChangeNumber'].value == null) ?
          true : (m.crcode == this.filterForm.controls['rfcChangeNumber'].value))
        && ((this.filterForm.controls['stage'].value == '' || this.filterForm.controls['stage'].value == null) ?
          true : (m.stage == this.filterForm.controls['stage'].value))
      )
    })
    this.totalItemsforsupport = this.filterexecutdata.length;
    this.filterexecutdata = this.filterexecutdata.slice(this.pageIndexforsupport * this.pageSizeforsupport, (this.pageIndexforsupport + 1) * this.pageSizeforsupport);

  }

  supporassignto: any;
  supportenginer() {
    this.supporassignto = this.supportengineers.filter((item: any) => item.assgigntome === parseInt(this.supportid) && item.status !== 'Completed');
  }

  isengineerasign: boolean = false;
  allengineer: boolean = true;
  assigenttobutton() {
    this.isengineerasign = true
    this.allengineer = false
    this.supportenginer()
  }

  //Login User
  supportteams: any[] = [];
  getsupportid: any;

  async getsupportteams() {
    const apiUrls = this.apiurl + '/SupportTeam'

    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        for (var i of response) {
          if (i.empId == parseInt(this.supportid)) {
            this.getsupportid = i.supportTeamId;
          }
        }
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }


  supportteamassign: any[] = [];
  isapprover: any;
  isassignappbutton: any;
  ischangeanalyst: any;
  issupportegineer: any;
  issupegineerasignbtn: any;
  supportcatid: any;
  supportcalid: any;
  supportplantid: any;
  getsupportteamassignList: any[] = [];

  async getsupportteamassign() {

    await this.getsupportteams();

    const apiUrls = this.apiurl + '/SupportteamAssigned'

    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        this.getsupportteamassignList = response;
        this.supportteamassign = response.filter((row: any) => row.supportTeamId === parseInt(this.getsupportid));
        if (this.supportteamassign.length > 0) {
          this.isapprover = this.supportteamassign[0].isApprover
          this.isassignappbutton = this.supportteamassign[0].isApprover
          this.ischangeanalyst = this.supportteamassign[0].isChangeAnalyst
          this.issupportegineer = this.supportteamassign[0].isSupportEngineer
          this.issupegineerasignbtn = this.supportteamassign[0].isSupportEngineer
          this.supportcatid = this.supportteamassign[0].categoryId
          this.supportcalid = this.supportteamassign[0].classificationId
          this.supportplantid = this.supportteamassign[0].plantId
          this.changeapprovers();
          this.supportadmin();
        }
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  navigateinprogress() {
    this.deleteinprogress = false;
  }

  issuperadmin: boolean = false;
  supportadmin() {
  
    if (this.isapprover == true && this.ischangeanalyst == true && this.issupportegineer == true) {
      this.issuperadmin = true;
      this.issupegineerasignbtn = false;
      this.isassignappbutton = false;
    }
  }

  supportbtnadmin() {
    this.filterChangeCr();
    this.filtersupportengineer();
    this.isassignbutton();
    this.assigenttobutton();
  }

  changeapprover: any[] = [];
  filtersapprvdata: any[] = [];

  paginatedTableDataforapprover: any[] = [];
  pageIndexforapprover = 0;
  pageSizeforapprover = 10;
  totalItemsforapprover = 0;


  onPageChangeforapprover(event: PageEvent) {
    this.pageIndexforapprover = event.pageIndex;
    this.pageSizeforapprover = event.pageSize;
    this.filterapprover();
  }

  filteredList: any[] = [];


  // async changeapprovers() {
  //   const apiUrls = this.apiurl + '/VwApproverCR/getPendingForApprovalCR?id='+this.user?.supportTeamData?.supportTeamId

  //   try {
  //     const response: any = await this.http.get(apiUrls,).toPromise();

  //     if (response) {
  //       this.changeapprover = response;

  //       this.filteredList = this.changeapprover
  //       this.filtersapprvdata = this.parseAndSortResponse(this.filteredList);
  //       this.totalItemsforapprover = this.filteredList.length;
  //       this.filtersapprvdata = this.filtersapprvdata.slice(this.pageIndexforapprover * this.pageSizeforapprover, (this.pageIndexforapprover + 1) * this.pageSizeforapprover);
  //       this.filterapprover();
  //     } else {
  //       console.error('Response is undefined or null');
  //     }
  //   } catch (error) {
  //     console.error('GET request failed', error);
  //   }
  // }

  async changeapprovers() {

    const supportId = this.user?.supportTeamData?.supportTeamId;

    if (!supportId) {
      console.error('SupportTeamId is missing');
      return;
    }

    const apiUrls = `${this.apiurl}/VwApproverCR/getPendingForApprovalCR?id=${supportId}`;

    try {
      const response: any = await firstValueFrom(this.http.get(apiUrls));

      const data = Array.isArray(response)
        ? response
        : response?.data || [];

      this.changeapprover = data;
      this.filteredList = data;

      this.filtersapprvdata = this.parseAndSortResponse(data);

      this.totalItemsforapprover = data.length;

      this.filtersapprvdata = this.filtersapprvdata.slice(
        this.pageIndexforapprover * this.pageSizeforapprover,
        (this.pageIndexforapprover + 1) * this.pageSizeforapprover
      );

      this.filterapprover();

    } catch (error: any) {
      console.error('GET request failed');
      console.error('Status:', error?.status);
      console.error('Message:', error?.message);
      console.error('Error Body:', error?.error);
    }
  }

  onclickfilter() {
    //this.resetfn();
    if (this.ischangeanalyst && this.isapprover && this.issupportegineer) {
      this.filterChangeCr();
      this.filtersupportengineer();
      this.filterapprover();

    }
    else if (this.isapprover) {
      //this.filtersapprvdata = [];
      this.filterapprover();
    }
    else if (this.issupportegineer) {
      this.filtersupportengineer();
    }
    else { this.filterChangeCr(); }

  }

  filterapprover() {
    this.filtersapprvdata = this.filteredList;
    this.filtersapprvdata = this.filtersapprvdata.filter(m => {
      return ((this.filterForm.controls['plantId'].value == null ||
        this.filterForm.controls['plantId'].value.length == 0) ? true : (this.filterForm.controls['plantId'].value.map((b: any) => { return b.item_id }).indexOf(m.plantcode) != -1))
        && ((this.filterForm.controls['Category'].value == null ||
          this.filterForm.controls['Category'].value.length == 0) ? true : (this.filterForm.controls['Category'].value.map((a: any) => { return a.item_id }).indexOf(m.itcategoryId) != -1))
        && ((this.filterForm.controls['ClassificationId'].value == '' || this.filterForm.controls['ClassificationId'].value == null) ?
          true : (m.itclassificationId == this.filterForm.controls['ClassificationId'].value))
        && ((this.filterForm.controls['Priority'].value == '' || this.filterForm.controls['Priority'].value == null) ?
          true : (m.priorityType == this.filterForm.controls['Priority'].value))
        && ((this.filterForm.controls['Status'].value == '' || this.filterForm.controls['Status'].value == null) ?
          true : (m.status == this.filterForm.controls['Status'].value))
        && ((this.filterForm.controls['StartDate'].value == '' || this.filterForm.controls['StartDate'].value == null) ?
          true : (m.crdate.split('T')[0] >= this.filterForm.controls['StartDate'].value))
        && ((this.filterForm.controls['EndDate'].value == '' || this.filterForm.controls['EndDate'].value == null) ?
          true : (m.crdate.split('T')[0] <= this.filterForm.controls['EndDate'].value))
        && ((this.filterForm.controls['rfcChangeNumber'].value == '' || this.filterForm.controls['rfcChangeNumber'].value == null) ?
          true : (m.crcode == this.filterForm.controls['rfcChangeNumber'].value))
        && ((this.filterForm.controls['stage'].value == '' || this.filterForm.controls['stage'].value == null) ?
          true : (m.stage == this.filterForm.controls['stage'].value))
    })
    this.totalItemsforapprover = this.filtersapprvdata.length;


    this.filtersapprvdata = this.parseAndSortResponse(this.filtersapprvdata)
    this.filtersapprvdata = this.filtersapprvdata.slice(this.pageIndexforapprover * this.pageSizeforapprover, (this.pageIndexforapprover + 1) * this.pageSizeforapprover);

  }

  isassigntome: any[] = [];

  gettingassigntome() {
    this.isassigntome = this.changeapprover.filter((item: any) => (item.approver1 === parseInt(this.getsupportid) || item.approver2 === parseInt(this.getsupportid) || item.approver3 === parseInt(this.getsupportid)));
    this.isassigntome = this.isassigntome.filter((item: any) => (item.status.trim() !== "Approved") && (item.status.trim() !== "Completed"));
    this.isassigntome = this.parseAndSortResponse(this.isassigntome);
  }

  allcrdata: boolean = true;
  assignedtodata: boolean = false;
  isassignbutton() {

    this.gettingassigntome();
    this.allcrdata = false;
    this.assignedtodata = true;
  }


  resetfn() {
    this.statusfilter = '';
    this.plantscode = '';
    this.categoryids = '';
    this.classificationid = '';
    this.prioritytypeid = '';
    this.fromDt = '';
    this.endDt = '';
    this.searchrfcnumber = '';
    this.filterflag = false;

    this.filterForm.reset()
    this.filterChangeCr()
    this.filterapprover()
    this.filtersupportengineer()
    if (this.isapprover) {
      this.changeapprovers();
      this.allcrdata = true;
      this.assignedtodata = false;
    }
    else if (this.issupportegineer) {
      this.getsupportemgineers();
      this.isengineerasign = false;
      this.allengineer = true;
    }
    else {
      this.getviewcrdata();
    }
  }

  checkAccess() {
    if (this.isapprover || this.issupportegineer) {
      window.alert("You don't have access to new requests.");
    }
  }
  deleteconfirmation: boolean = false;
  deletesupportid: any;
  deletesupportassignid: any;
  deleteempid: any;
  deletespassign: any;
  deleteplantid: any;
  deletecategoryid: any;
  deleteclassificationid: any;

  deleteinprogress: Boolean = false;
  deleteinmessage: any = '';
  deletecrid: any = '';

  deleteRow(crid: any, crCODE: any) {
    this.deletecrid = crid;
    this.getcrcode = crCODE;
    this.deleteconfirmation = true
  }

  deleteyes() {
    this.deleteconfirmation = false
    this.deleteSupportTeam()
  }

  deleteno() {
    this.deleteconfirmation = false
  }

  deletesuccess: boolean = false;
  deletemessage: any = '';
  messageerror: boolean = false;
  errormessage: any;
  errorresponse: any;

  deleteSupportTeam() {
    const apiUrl = this.apiurl + "/ChangeRequest/InsertChangeRequest";
    const requestBody = {
      "type": "D",
      "itcrid": this.deletecrid,
      "supportId": 0,
      "classificationId": 0,
      "categoryId": 0,
      "categoryTypeId": 0,
      "crowner": 0,
      "crdate": "2024-05-22T17:43:44.652Z",
      "crrequestedBy": 0,
      "crrequestedDt": "2024-05-22T17:43:44.652Z",
      "crinitiatedFor": 0,
      "status": "Cancelled",
      "referenceId": 0,
      "referenceTyp": 0,
      "natureOfChange": 0,
      "priorityType": 0,
      "plantId": 0,
      "gxpclassification": true,
      "gxpplantId": 0,
      "changeControlNo": "string",
      "changeControlDt": "2024-05-22",
      "changeControlAttach": true,
      "changeDesc": "string",
      "reasonForChange": "string",
      "alternateConsidetation": "string",
      "impactNotDoing": "string",
      "businessImpact": "string",
      "triggeredBy": "string",
      "benefits": "string",
      "estimatedCost": 0,
      "estimatedCostCurr": "string",
      "estimatedEffort": 0,
      "estimatedEffortUnit": "string",
      "estimatedDateCompletion": "2024-05-22",
      "rollbackPlan": "string",
      "backoutPlan": "string",
      "downTimeRequired": true,
      "downTimeFromDate": "2024-05-22T17:43:44.653Z",
      "downTimeToDate": "2024-05-22T17:43:44.653Z",
      "impactedLocation": "string",
      "impactedDept": "string",
      "imactedFunc": "string",
      "isSubmitted": true,
      "isApproved": true,
      "isImplemented": true,
      "isReleased": true,
      "createdBy": this.supportid
    };
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    setTimeout(() => {
      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
          this.errorresponse = response.type
          if (this.errorresponse == "E") {
            this.deleteinprogress = true;
            this.deleteinmessage = "There are open items it can't be deleted"
          } else if (this.errorresponse == "S") {
            this.deletesuccess = true;
            this.deletemessage = "RFC Code: " + this.getcrcode + " Deleted Successfully"
          }
        },
        (error: any) => {
          this.messageerror = true;
          this.errormessage = error;
        }
      );
    }, 500);
  }

  navigatesuccess() {
    this.deletesuccess = false;
    window.location.reload();
  }


}

function round(): number {
  throw new Error('Function not implemented.');
}
