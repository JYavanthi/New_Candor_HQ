import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
//import { debug } from 'console';
import { PasscrdataService } from '../passcrdata.service';import { environment } from '@environments/environment';

@Component({
  selector: 'app-execute',
  templateUrl: './execute.component.html',
  styleUrls: ['./execute.component.css']
})
export class ExecuteComponent {

  isActive: string = 'implement'; 
  crData: any;
  itcrid: any = '';
  crData1: any;

  setActiveTab(tab: string): void {
    this.isActive = tab;
  }
  showInitiator: boolean = false;
  showRiskQ: boolean = false;
  activeflag: boolean = true;

  tabs: any[] = [];
  numberOfTabs: number = 1;
  plantData: any[] = [];
  status: any = '';
  approver: any = '';
  appdate: any = '';
  attach: any = '';
  remark: any = '';
  comment: any = '';
  crid: any = '';
  getstatus: any = '';
  isApproved: any = '';
  isImplemented: any = '';
  isReleased: any = '';
  isSubmitted: any = '';
  isCompleted: any = '';
  getstage: any = '';
  getRejData: string = '';
  constructor(private http: HttpClient, private router: Router,
    private route: ActivatedRoute, private routeservice: PasscrdataService) {
    this.routeservice.crdata.subscribe(data => {
      this.crid = data?.report?.value
      //this.crid = this.crid.itcrid;
      this.getstatus = this.crid?.status?.trim();
      
      this.getstage = this.crid?.stage?.trim();
      this.isApproved = this.crid?.isApproved;
      this.isImplemented = this.crid?.isImplemented;
      this.isReleased = this.crid?.isReleased;
      this.isSubmitted = this.crid?.isSubmitted;
      this.itcrid = this.route.snapshot.paramMap.get('id');
     })

    this.routeservice?.RejectDta?.subscribe(data => {
      this.getRejData = data?.actvFlg?.activeFlg;
      if (this.getRejData == 'false') {
        this.activeflag = false
      } else {
        this.activeflag = true
      }
    })
  }

  
  private apiurl = environment.apiurls

  async getviewcrdata() {
    const apiUrls = this.apiurl + '/ViewChangeRequest/ViewChangerequest';

    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        // this.getviewcrdataList = response;
        this.crData1 = response.filter((m:any)=>m.itcrid==this.itcrid)[0]
        //this.crfilter = response.filter((item: any) => item.changeRequestor === parseInt(this.supportid));
      } else {
        console.error('Response is undefined or null');
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }
  
  removeTab() {
    if (this.tabs.length > 0) {
      this.tabs.pop();
    }
  }
 
  handleFileInput(event: any, index: number) {
    const file = event.target.files[0];
    this.plantData[index].attachment = file;
  }

  uniqueLandscapes: string[]=[];

  type: any = '';
  data: any = [];
  items: any[] = [];
  selectedCategory: string = '';
  filteredData: any[] = [];
  landscapeOptions: number[] = [];
  exectivevalue: any[] = [];
  checkstatus: any = '';
  
  ngOnInit(): void {
    this.getupdatyevalue()
    this.getviewcrdata()
    // Extract unique sysLandscape values from data
    this.landscapeOptions = this.value.map((item: { sysLandscape: any; }) => item.sysLandscape)
      .filter((value: any, index: any, self: string | any[]) => self.indexOf(value) === index);
    this.checkstatus = this.getstatus?.trim();
  }

  value: any[] = [];

  
  async getupdatyevalue() {
    
    const apiUrls: any = this.apiurl + '/ChangeRequest/Getrequest';
    try {
      const response: any = await this.http.get(apiUrls).toPromise();

      if (response) {
        
      this.crData = response.filter((item: any) => item.itcrid.toString() === this.itcrid.toString())[0]
      this.getstatus = this.crData?.status.trim();
      this.getstage = this.crData?.stage.trim();
      if(this.getstatus != 'Rejected'){
        this.activeflag = true
      }else{
        this.activeflag = false
      }
      }
    } catch (error) {
      console.error('GET request failed', error);
    }
  }
  getvalue() {
    const apiUrl = this.apiurl + '/Crexecute/GetExecute';
    const requestBody = {
    }
    this.http.get(apiUrl, requestBody).subscribe(
      (response: any) => {
        this.value = response;
      },
      (error: any) => {
        console.error('POST request failed', error);
      });
  }
  /*Common texts*/
}
