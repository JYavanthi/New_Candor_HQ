import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';

interface DropdownItem {
  item_id: number;
  item_text: string;
}
@Component({
  selector: 'app-approved-cr-report',
  templateUrl: './approved-cr-report.component.html',
  styleUrl: './approved-cr-report.component.css'
})
export class ApprovedCrReportComponent {
  approvedData!:any
  changeapprover: any;
  pageIndexforapprover = 0;
  pageSizeforapprover = 10;
  totalItemsforapprover = 0;
  user: any;
  filterForm!:FormGroup
  dropdownList: DropdownItem[] = [];
  dropdowncategroy: DropdownItem[] = [];
  dropdownSettings = {
    idField: 'item_id',
    textField: 'item_text',
  };
  classifications: any;
  prioritydata: any;
  constructor(private userInfo : UserInfoSerService,public httpSer : HttpServiceService,
    public fb: FormBuilder){
    this.user = userInfo.getUser()
  }
  async changeapprovers() {
    const apiUrls = '/VwApproverCR/getPendingForApprovalCR?id='+this.user?.supportTeamData?.supportTeamId

    try {
      const response: any = await this.httpSer.httpGet(apiUrls,).toPromise();

      if (response) {
        this.changeapprover = response;
        
        this.approvedData = this.changeapprovers
      } else {
        console.error('Response is undefined or null'); 
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }

  ngOnInit(): void {
  
  this.filterForm=this.fb.group({
    plantId:[],
    Category:[],
    ClassificationId:'',
    Priority:'',
    StartDate:'',
    EndDate:'',
    Status:'',
    rfcChangeNumber:'',
    stage:''
  })
  this.fetchCategoryData()
  this.getclassification()
  this.getpriority()
  
}
  filterapprover() {
    this.approvedData = this.changeapprover;
    this.approvedData = this.approvedData.filter((m:any)=>{
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

    
    this.totalItemsforapprover = this.approvedData.length;
    this.approvedData = this.approvedData.slice(this.pageIndexforapprover * this.pageSizeforapprover, (this.pageIndexforapprover + 1) * this.pageSizeforapprover);
    
  }

  resetfn(){
    this.filterForm.reset();
    this.filterapprover()
  }
  fetchCategoryData(): void {
    const apiUrl = '/Category'
    this.httpSer.httpGet(apiUrl).subscribe(
      (data:any) => {
        this.dropdowncategroy = data.map((item:any) => ({
          item_id: item.itcategoryId,
          item_text: item.categoryName
        }));
      },
      (error) => {
      }
    );
  }

  getclassification() {
    const apiUrls = '/Classification'

    this.httpSer.httpGet(apiUrls).subscribe(
      (response: any) => {
        this.classifications = response;
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  getpriority() {
    const apiUrls = '/Priority'
    this.httpSer.httpGet(apiUrls).subscribe(
      (response: any) => {
        this.prioritydata = response;
      },
      (error) => {
        throw error
      }
    )
  }
}
