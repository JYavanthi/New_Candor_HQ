import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '@environments/environment.development';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { resolve } from 'dns';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-cr-implement',
  templateUrl: './cr-implement.component.html',
  styleUrl: './cr-implement.component.css'
})
export class CrImplementComponent {

  crId: any;
  changeRequestData: any;
  activeTabIndex = 0;
  executeIndex =0;
  releaseIndex =0;
  closureIndex =0;
  releaseComment=''
  selectedFileRelease: any;
  attachfile: any;
  private apiurl = environment.apiurl;
  releaseFeedBack: any;
  closerStatus: any;
  constructor(private router: Router, private getSupportList: GetEmployeeInfoService,private userInfo: UserInfoSerService,
    private route: ActivatedRoute,private httpService: HttpServiceService,private http: HttpClient ){

    this.route.queryParamMap.subscribe(params => {
      this.crId =  params.get('id')
      if(this.crId){
        this.getCRData()
      }
    })
  }

  ngOnInit(): void {
  }

  getAttachRelease(event: any): void {
    this.selectedFileRelease = event.target.files[0];
  }

  submitCloser() {
    
    const apiUrl = this.apiurl + '/Crcloser/Closer';
    const requestBody = {
      "itcrid": this.changeRequestData.itcrid,
      "closureRemarks": this.releaseComment,
      // "closedBy": Number(this.supportid),
      "closedDt": "2024-06-12T13:22:17.307Z",
      "feedback": this.releaseFeedBack,
      // "createdBy": Number(this.supportid),
      "closedStatus":this.closerStatus,
      // "sendemailfrom":this.sendemailfrom,
    }
    // const httpOptions = {
    //   headers: new HttpHeaders({
    //     'Content-Type': 'application/json'
    //   })
    // };
    this.http.post(apiUrl, requestBody).subscribe(
      (response: any) => {
        if (response.type == "E") {
          alert(response.message);
          return;
        }
        else {
          alert("RFC Code" + " " + this.changeRequestData.crcode + " " + ": is Completed");
          this.router.navigate(['/change-request']);
        }
      },
      (error: any) => {
        console.log('Post request failed', error);
      });
  }



getStageStatusCode() {
  if(!this.changeRequestData){
    return 0
  }
  switch (this.changeRequestData?.stage) {
    case 'Initiated':
      if (this.changeRequestData?.status === 'Draft') return 0;
      if (this.changeRequestData?.status === 'Pending Approval') return 1;
      break;
      
    case 'Approval':
      if (this.changeRequestData?.status === 'Approved level1') return 1;
      if (this.changeRequestData?.status === 'Approved level2') return 1;
      if (this.changeRequestData?.status === 'Approved') return 2;
      break;
      
    case 'Implementation':
      if (this.changeRequestData?.status === 'Implement') return 2;
      break;
      
    case 'Release':

      if (this.changeRequestData?.status === 'Approved level1') return 2;
      if (this.changeRequestData?.status === 'Approved level2') return 2;
      if (this.changeRequestData?.status === 'Approved') return 2;
      if (this.changeRequestData?.status === 'Released') return 2;
      break;
      
    case 'Closure':
      if (this.changeRequestData?.status === 'Completed') return 2;
      if (this.changeRequestData?.status === 'Approved level1') return 2;
      if (this.changeRequestData?.status === 'Approved level2') return 2;
      break;

    default:
      throw new Error('Unknown stage');
  }
  throw new Error('Unknown status for the given stage');
}
  getCRData(){
    let param = {
      crId : this.crId
    }
    const apiUrls = '/ViewChangeRequest/ViewChangerequest';
    this.httpService.httpGet(apiUrls,param).subscribe(res => {
      const response = res as any;
        this.changeRequestData = response.data[0];
    })
  }

  submitRelease() {
    this.attachfile = this.selectedFileRelease.name;
    if (this.attachfile == undefined) {
      this.attachfile = '';
    }

    if (this.releaseComment.trim() == '') {
      alert(' Enter Release Comments')

    } else {
      const apiUrl = "/CRrelease/Releaser";
      const requestBody = {
        "flag": "I",
        "itcrid": this.changeRequestData?.itcrid,
        "crReleaseID": 0,
        "sysLandscape": 1,
        "releaseComments": this.releaseComment,
        "assignedTo": 1,
        "releaseDt": new Date(),
        "attachments": this.attachfile,
        "status": "Released",
        "approvedBy": 1,
        "approvedDt": new Date(),
        "createdBy": 1
      }
      this.httpService.httpPost(apiUrl, requestBody).subscribe(
        (response: any) => {
          if (response.type == "E") {
          alert(response.message);
          return;
        }else{
          alert("RFC Code" + this.changeRequestData.crcode + " " + "Released for Approval");
          this.addFile();
          this.router.navigate(['/change-request']);
        }
          
        },
        (error: any) => {
          console.log('Post request failed', error);
        }
      );
    }
  }
  addFile(): void {
    if (!this.selectedFileRelease) {
      console.error('No file selected.');
      return;
    }

    if (!this.changeRequestData.itcrid) {
      console.error('ITCRID is required.');
      return;
    }

    const itcrid = this.changeRequestData.itcrid.toString();
    const formData = new FormData();
    formData.append('itcrid', itcrid);
    formData.append('file', this.selectedFileRelease, this.selectedFileRelease.name);
    const apiUrl = '/CRlession';

    this.httpService.httpPost(apiUrl, formData).subscribe(
      (response: any) => {
      },
      (error: any) => {
        console.error('POST request failed', error);
      }
    );
  }
  viewFile(itcrid: string, fileName: string): void {
    const apiUrl = `${this.apiurl}/CRlession/GetFile?itcrid=${itcrid}&fileName=${fileName}`;

    this.http.get(apiUrl, { responseType: 'blob' }).subscribe(
      (response: Blob) => {
        const url = window.URL.createObjectURL(response);
        const link = document.createElement('a');
        link.href = url;
        link.download = fileName;
        link.target = '_blank';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
        window.URL.revokeObjectURL(url);
      },
      (error: any) => {
      }
    );
  }
 
  ApprovalLevelCount(){

  }
}
