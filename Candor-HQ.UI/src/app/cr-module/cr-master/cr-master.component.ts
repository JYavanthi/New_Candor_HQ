import { Component } from '@angular/core';import { environment } from '@environments/environment';
import { PasscrdataService } from 'app/change-request/passcrdata.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { PageEvent, MatPaginator } from '@angular/material/paginator';
interface DropdownItem {
  item_id: number;
  item_text: string;
}

@Component({
  selector: 'app-cr-master',
  templateUrl: './cr-master.component.html',
  styleUrl: './cr-master.component.css'
})

export class CrMasterComponent {
  viewChangeRequest: any[] = [];
  user: any;
  private apiurl = environment.apiurls;
  currentDate=new Date().toISOString().slice(0,10);
  filterForm: any;
  dropdownSettings = {
    idField: 'item_id',
    textField: 'item_text',
  };
  dropdownList: DropdownItem[] = [];
  dropdowncategroy: DropdownItem[] = [];
  classifications: any[] = [];
  prioritydata: any[] = [];
  ischangeanalyst: any;
  supportteamassign: any[] = [];
  isapprover: any;
  issupportegineer: any;
  pageIndex: number = 0;
  pageSize: number = 20;
  viewChangeRequestCount: any;
  filterexecutdata: any;
  totalItemsforsupport: any;
  pageIndexforsupport: any;
  pageSizeforsupport: any;
  supportengineers: any;
  changeapprover: any[] = [];
  filtersapprvdata: any[] = [];

  paginatedTableDataforapprover: any[] = [];
  pageIndexforapprover = 0;
  pageSizeforapprover = 10;
  totalItemsforapprover = 0;
  filteredList: any;

  constructor(private userInfo: UserInfoSerService, private httpSer: HttpServiceService, private fb: FormBuilder,
    private router: Router) {
    this.user = this.userInfo.getUser();
  }

  ngOnInit(): void {
    this.filterForm = this.fb.group({
      plantId: [],
      Category: [],
      ClassificationId: '',
      Priority: '',
      StartDate: '',
      EndDate: '',
      Status: '',
      rfcChangeNumber: ''
    })
    this.getviewcrdata();
    this.getclassification();
    this.getpriority();
    this.fetchDropdownData();
    this.fetchCategoryData();
  }

  
  onPageChangeforapprover(event: PageEvent) {
    this.pageIndexforapprover = event.pageIndex;
    this.pageSizeforapprover = event.pageSize;
    this.filterapprover();
  }

  async changeapprovers() {
    const apiUrls = this.apiurl + '/VwApproverCR/getPendingForApprovalCR?id='+this.user?.supportTeamData?.supportTeamId

    try {
      const response: any = await this.httpSer.httpGet(apiUrls,).toPromise();

      if (response) {
        this.changeapprover = response;
        
        this.filteredList = this.changeapprover
        
        // this.filtersapprvdata = this.parseAndSortResponse(this.filteredList);
        this.totalItemsforapprover = this.filteredList.length;
        this.filtersapprvdata = this.filtersapprvdata.slice(this.pageIndexforapprover * this.pageSizeforapprover, (this.pageIndexforapprover + 1) * this.pageSizeforapprover);
        this.filterapprover();
      } else {
        console.error('Response is undefined or null'); 
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }
  filterapprover() {
    this.filtersapprvdata = this.filteredList;
    this.filtersapprvdata = this.filtersapprvdata.filter(m=>{
      return ((this.filterForm.controls['plantId'].value==null||
      this.filterForm.controls['plantId'].value.length==0)?true:(this.filterForm.controls['plantId'].value.map((b:any)=>{return b.item_id}).indexOf(m.plantcode)!=-1))
      &&((this.filterForm.controls['Category'].value==null||
      this.filterForm.controls['Category'].value.length==0)?true:(this.filterForm.controls['Category'].value.map((a:any)=>{return a.item_id}).indexOf(m.itcategoryId)!=-1))
      &&((this.filterForm.controls['ClassificationId'].value==''||this.filterForm.controls['ClassificationId'].value==null)?
      true:(m.itclassificationId==this.filterForm.controls['ClassificationId'].value))
      &&((this.filterForm.controls['Priority'].value==''||this.filterForm.controls['Priority'].value==null)?
      true:(m.priorityType==this.filterForm.controls['Priority'].value))
      &&((this.filterForm.controls['Status'].value==''||this.filterForm.controls['Status'].value==null)?
      true:(m.status==this.filterForm.controls['Status'].value))
      &&((this.filterForm.controls['StartDate'].value==''||this.filterForm.controls['StartDate'].value==null)?
      true:(m.crdate.split('T')[0]>=this.filterForm.controls['StartDate'].value))
      &&((this.filterForm.controls['EndDate'].value==''||this.filterForm.controls['EndDate'].value==null)?
      true:(m.crdate.split('T')[0]<=this.filterForm.controls['EndDate'].value))
      &&((this.filterForm.controls['rfcChangeNumber'].value==''||this.filterForm.controls['rfcChangeNumber'].value==null)?
      true:(m.crcode==this.filterForm.controls['rfcChangeNumber'].value))
      &&((this.filterForm.controls['stage'].value==''||this.filterForm.controls['stage'].value==null)?
      true:(m.stage==this.filterForm.controls['stage'].value))
    })
    this.totalItemsforapprover = this.filtersapprvdata.length;

    
    // this.filtersapprvdata = this.parseAndSortResponse(this.filtersapprvdata)
    this.filtersapprvdata = this.filtersapprvdata.slice(this.pageIndexforapprover * this.pageSizeforapprover, (this.pageIndexforapprover + 1) * this.pageSizeforapprover);

  }
  getviewcrdata() {

    let param = {
      pageNumber: this.pageIndex + 1,
      pageSize: this.pageSize,
      PlantIds: this.filterForm.controls['plantId'].value == null ? [] : this.filterForm.controls['plantId'].value,
      Categories: this.filterForm.controls['Category'].value == null ? [] : this.filterForm.controls['Category'].value,
      ClassificationId: this.filterForm.controls['ClassificationId'].value,
      Priority: this.filterForm.controls['Priority'].value,
      Status: this.filterForm.controls['Status'].value,
      StartDate: this.filterForm.controls['StartDate'].value,
      EndDate: this.filterForm.controls['EndDate'].value,
      RfcChangeNumber: this.filterForm.controls['rfcChangeNumber'].value,
      crId: 0,
      changeRequestor: parseInt(this.user?.empData?.employeeNo)
    }
    const apiUrls = '/ViewChangeRequest/ViewChangerequest';
    this.httpSer.httpGet(apiUrls, param).subscribe(res => {

      let response:any = res
      this.viewChangeRequest = response.data
      this.viewChangeRequestCount = response.count
      // this.viewChangeRequest = res.filter((item: any) => item.changeRequestor === parseInt(this.user.empData.employeeNo));
    })
  }

  getclassification() {
    const apiUrls = '/Classification'
    this.httpSer.httpGet(apiUrls).subscribe(res => {
      this.classifications = res;
    },
      (error) => {
        console.error("Post failed", error)
      })
  }

  getpriority() {
    const apiUrls = '/Priority'
    this.httpSer.httpGet(apiUrls).subscribe(res => {
      this.prioritydata = res;
    },
      (error) => {
        throw error
      }
    )
  }

  onPageChange(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.getviewcrdata();
  }



  // getsupportteamassign() {
  //   const apiUrls = '/SupportteamAssigned'
  //   this.httpSer.httpGet(apiUrls).subscribe(res => {
  //     this.supportteamassign = res.filter((row: any) => row.supportTeamId === parseInt(this.user.empData.employeeNo));
  //     this.ischangeanalyst = this.supportteamassign[0]?.isChangeAnalyst
  //     this.isapprover = this.supportteamassign[0]?.isApprover
  //     this.issupportegineer = this.supportteamassign[0]?.isSupportEngineer
  //   },
  //     (error) => {
  //       throw error
  //     }
  //   )
  // }

  onclickfilter() {
      this.getviewcrdata()
  }

  filtersupportengineer() {
    this.filterexecutdata = this.supportengineers
    this.filterexecutdata = this.filterexecutdata.filter((m:any)=>{
      return (
    ((this.filterForm.controls['plantId'].value==null||
    this.filterForm.controls['plantId'].value.length==0)?true:(this.filterForm.controls['plantId'].value.map((b:any)=>{return b.item_id}).indexOf(m.plantcode)!=-1))
    &&((this.filterForm.controls['Category'].value==null||
    this.filterForm.controls['Category'].value.length==0)?true:(this.filterForm.controls['Category'].value.map((a:any)=>{return a.item_id}).indexOf(m.itcategoryId)!=-1))
    &&((this.filterForm.controls['ClassificationId'].value==''||this.filterForm.controls['ClassificationId'].value==null)?
    true:(m.itclassificationId==this.filterForm.controls['ClassificationId'].value))
    &&((this.filterForm.controls['Priority'].value==''||this.filterForm.controls['Priority'].value==null)?
    true:(m.priorityType==this.filterForm.controls['Priority'].value))
    &&((this.filterForm.controls['Status'].value==''||this.filterForm.controls['Status'].value==null)?
    true:(m.status==this.filterForm.controls['Status'].value))
    &&((this.filterForm.controls['StartDate'].value==''||this.filterForm.controls['StartDate'].value==null)?
    true:(m.crdate.split('T')[0]>=this.filterForm.controls['StartDate'].value))
    &&((this.filterForm.controls['EndDate'].value==''||this.filterForm.controls['EndDate'].value==null)?
    true:(m.crdate.split('T')[0]<=this.filterForm.controls['EndDate'].value))
    &&((this.filterForm.controls['rfcChangeNumber'].value==''||this.filterForm.controls['rfcChangeNumber'].value==null)?
    true:(m.crcode==this.filterForm.controls['rfcChangeNumber'].value))
    &&((this.filterForm.controls['stage'].value==''||this.filterForm.controls['stage'].value==null)?
    true:(m.stage==this.filterForm.controls['stage'].value))
      )
    })
  }
  // filterChangeCr() {
  //   this.viewChangeRequest = this.rptfilter
  //   this.viewChangeRequest = this.viewChangeRequest.filter(m => {
  //     return (
  //       ((this.filterForm.controls['plantId'].value == null ||
  //         this.filterForm.controls['plantId'].value.length == 0) ? true : (this.filterForm.controls['plantId'].value.map((b: any) => { return b.item_id }).indexOf(m.plantcode) != -1))
  //       && ((this.filterForm.controls['Category'].value == null ||
  //         this.filterForm.controls['Category'].value.length == 0) ? true : (this.filterForm.controls['Category'].value.map((a: any) => { return a.item_id }).indexOf(m.itcategoryId) != -1))
  //       && ((this.filterForm.controls['ClassificationId'].value == '' || this.filterForm.controls['ClassificationId'].value == null) ?
  //         true : (m.itclassificationId == this.filterForm.controls['ClassificationId'].value))
  //       && ((this.filterForm.controls['Priority'].value == '' || this.filterForm.controls['Priority'].value == null) ?
  //         true : (m.priorityType == this.filterForm.controls['Priority'].value))
  //       && ((this.filterForm.controls['Status'].value == '' || this.filterForm.controls['Status'].value == null) ?
  //         true : (m.status == this.filterForm.controls['Status'].value))
  //       && ((this.filterForm.controls['StartDate'].value == '' || this.filterForm.controls['StartDate'].value == null) ?
  //         true : (m.crdate.split('T')[0] >= this.filterForm.controls['StartDate'].value))
  //       && ((this.filterForm.controls['EndDate'].value == '' || this.filterForm.controls['EndDate'].value == null) ?
  //         true : (m.crdate.split('T')[0] <= this.filterForm.controls['EndDate'].value))
  //       && ((this.filterForm.controls['rfcChangeNumber'].value == '' || this.filterForm.controls['rfcChangeNumber'].value == null) ?
  //         true : (m.crcode == this.filterForm.controls['rfcChangeNumber'].value))
  //     )
  //   })
  // }

  fetchDropdownData(): void {
    const apiUrls = '/Plantid';
    this.httpSer.httpGet(apiUrls).subscribe(
      (data) => {
        console.log("Plant Details",data);
        this.dropdownList = data.map(item => ({
          item_id: item.id,
          item_text: item.code
        }));
      },
      (error) => {
        throw error
      }
    );
  }
  fetchCategoryData(): void {
    const apiUrls = '/Category'
    this.httpSer.httpGet(apiUrls).subscribe(
      (data) => {
        this.dropdowncategroy = data.map(item => ({
          item_id: item.itcategoryId,
          item_text: item.categoryName
        }));
      },
      (error) => {
        throw error
      }
    );
  }

  resetfn() {
    this.filterForm.reset()
    this.getviewcrdata()
    // this.filterChangeCr()
  }

  async getsupportemgineers() {
    const apiUrls = '/VwSupportEngineer'

    try {
      const response: any = await this.httpSer.httpGet(apiUrls).toPromise();

      if (response) {
        this.supportengineers = response;
        this.supportengineers = response.filter((item: any) => item.assgigntome === parseInt(this.user.empData.employeeNo));
        // this.filterexecutdata = this.parseAndSortResponse(this.supportengineers);
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

}
