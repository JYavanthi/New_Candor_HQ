import { Injectable } from '@angular/core';import { environment } from '@environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserConfigurationComponent } from 'app/master-module/user-configuration/user-configuration.component';
import { UserInfoSerService } from './user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Injectable({
  providedIn: 'root'
})
export class SendEmailServiceService {
  user:any
  constructor(public http:HttpClient, public userInfo:UserInfoSerService,
    public httpSer:HttpServiceService) { 
    this.user=this.userInfo.getUser()?.empData
  }

  private apiurl = environment.apiurls;
  
  serviceTitlesWithAPI: { [key: string]: { title: string, apiUrl: string } } = {
    '/services/software': { title: 'Software', apiUrl: '/serviceMaster/getSoftware' },
    '/services/domain': { title: 'Domain', apiUrl: '/serviceMaster/getDomain' },
    '/services/email': { title: 'Email', apiUrl: '/SREmail/GetSREmailByID' },
    '/services/externaldriveaccess': { title: 'External Drive Access', apiUrl: '/SRExternalDrive/GetSRExternal' },
    '/services/ftpaccess': { title: 'FTP Access', apiUrl: '/SRFTPAccess/GetFTPAccess' },
    '/services/usbaccess': { title: 'USB Access', apiUrl: '/SRUSBAccess/GetSRUSBIDValue' },
    '/services/citrixaccess': { title: 'Citrix Access', apiUrl: '/SRCitrixAccess/GetCrtirixValue' },
    '/services/windowslogin': { title: 'Windows Login', apiUrl: '/SRWindowLogin/GetWindowValue' },
    '/services/vpnaccess': { title: 'VPN Access', apiUrl: '/SRVPNAccess/GetVPNAccessValue' },
    '/services/urlorinternetaccess': { title: 'URL/Internet Access', apiUrl: '/SRURLAccess/GetURLAccessValue' },
    '/services/wifiaccess': { title: 'Wifi Access', apiUrl: '/SRWIFIAccess/GetWIFIAccess' },
    '/services/fileserveroraccessforfolderaccess': { title: 'File Server / Access For Folders', apiUrl: '/SRFileAccess/GetFileAccessValue' },
    '/services/backuprestoration': { title: 'Backup & Restoration', apiUrl: '/SRRestoration/GetSRRestorationbyID' },
    '/services/remoteaccess': { title: 'Remote Access', apiUrl: '/SRRemoteAccess/GetSRRemoteAccessById' },
    '/services/antivirus': { title: 'Antivirus', apiUrl: '/SRAntivirus/GetAntivirus' },
    '/services/virtualmeeting': { title: 'Virtual Meeting', apiUrl: '/SRVirtual/GetVirtual' }
  };

  async sendemailfrom(srData:any){
     
    const apiUrl = this.apiurl + '/Email';
    const output = this.readHtmlFile('assets/newSREmail.html');

    const populatedOutput = output
      .replace('@SubmitterName', srData?.srraiseBy)
      .replace('@serviceCode', srData?.srcode)
      .replace('@RequestorName', srData?.srraiseFor)
      .replace('@requestedDateTime', srData?.supportCreatedDate)
      .replace('@Status', srData?.status)
      .replace('@requestedDateTime', srData?.supportCreatedDate)
      .replace('@approver1', srData?.rpmToName)
      .replace('@approver1Status', srData?.status=='Pending Approval'?'Pending':'Approved')
      .replace('@approver2', srData?.rpmToName)
      .replace('@approver2Status', srData?.status=='Pending Approval'||srData?.status=='Pending HOD Approval'?'Pending':'Approved')


      
      const requestBody = {
        // "to": (srData.srraisedByEmail).replace(/^,+|,+$/g, '').trim().replace(/\s+/g, ' '),
        // "cc": (srData.srraisedForEmail+','+srData.srraisedByEmail+','+
        // (srData?.hodToName==srData?.rpmToName)?srData?.hodEmail:srData?.hodEmail+','+srData?.rpmEmail).replace(/^,+|,+$/g, '').trim().replace(/\s+/g, ' '),
        // "subject": `Unnati: IT Service Request: ${srData?.srcode}`,
        "to":'vijay.r@techvaraha.com',
        "cc":"rodagevijay69@gmail.com",
        "body": populatedOutput
      }
  
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };
      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
        },
        (error: any) => {
        });
  }
  
  getData(srId:any,currentUrl:any) {
    this.httpSer.httpGet(this.serviceTitlesWithAPI[currentUrl], { 'srid': srId }).subscribe((res: any) => {
      this.sendemailfrom(res.data)
    });
}
  sendApproverEmail(srData:any){
    const apiUrl = this.apiurl + '/Email';
    const output = this.readHtmlFile('assets/srApprover.html');


    const populatedOutput = output
      .replace('@approvedBy', this.user.firstName+' '+this.user.middleName+' '+this.user.lastName+'('+(this.user.employeeNo)+')')
      .replace('@RequestorName', srData?.srraiseFor)
      .replace('@approvedBy', this.user.firstName+' '+this.user.middleName+' '+this.user.lastName+'('+(this.user.employeeNo)+')')
      .replace('@serviceCode', srData?.srcode)
      .replace('@RequestorName', srData?.srraiseFor)
      .replace('@requestedDateTime', srData?.supportCreatedDate)
      .replace('@Status', srData?.status)
      .replace('@approver1', srData?.rpmToName)
      .replace('@approver1Status', srData?.status=='Pending Approval'?'Pending':'Approved')
      .replace('@approver2', srData?.rpmToName)
      .replace('@approver2Status', srData?.status=='Pending Approval'||srData?.status=='Pending HOD Approval'?'Pending':'Approved')

      
      const requestBody = {
        "to": (srData.srraisedByEmail).replace(/^,+|,+$/g, '').trim().replace(/\s+/g, ' '),
        "cc": (srData.srraisedForEmail+','+srData.srraisedByEmail+','+
        (srData?.hodToName==srData?.rpmToName)?srData?.hodEmail:srData?.hodEmail+','+srData?.rpmEmail).replace(/^,+|,+$/g, '').trim().replace(/\s+/g, ' '),
        "subject": `Unnati: IT Service Request: ${srData?.srcode}`,
        "body": populatedOutput
      }
  
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };
      this.http.post(apiUrl, requestBody, httpOptions).subscribe(
        (response: any) => {
        },
        (error: any) => {
        });
  }

  
  readHtmlFile(file: string): string {
    const xhr = new XMLHttpRequest();
    xhr.open('GET', file, false);
    xhr.send();
    if (xhr.status === 200) {
      return xhr.responseText;
    } else {
      console.error('Failed to read HTML file:', file);
      return '';
    }
  }
}
