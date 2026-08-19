import { DatePipe } from '@angular/common';
import { HttpHeaders } from '@angular/common/http';
import { Component, Input, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { filter } from 'rxjs';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-cr-approve-tab',
  templateUrl: './cr-approve-tab.component.html',
  styleUrl: './cr-approve-tab.component.css',
})
export class CrApproveTabComponent {
  public approveTabGroup!: FormGroup;
  @Input() crData: any;
  @Input() level!: number;
  @Input() stage: string = '';
  @Input() approveStage: string = '';
  @Input() approveStatus: string = '';
  populatedOutput: any = '';
  approverData: any = [];
  user: any;
  approverEmpId!: number;
  attach: any = '';
  selectedFile: any = '';

  APIURLS = {
    GetApprover: '/GetApproval/GetApprover',
    CRApprove: '/CRapprove/Approve',
    CRLession: '/CRlession'
  };
  emailData: any;

  constructor(private httpSer: HttpServiceService, private datePipe: DatePipe, 
    private router: Router,private userInfo: UserInfoSerService) {
    
    this.user = this.userInfo.getUser();

  }
  ngOnInit() {
    this.approveForm();
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log("Stage", this.stage);
    if (changes['crData']) {
      if(this.crData != undefined){
        this.getApprover();
      }
    }
  }
  getRequiredStage() {
    switch (this.stage) {
      case 'N':
        switch (this.level) {
          case 1:
            return 'Initiated';
          case 2:
            return 'Approval';
          case 3:
            return 'Approval';
          default:
            return '';
        }
      case 'R':
        switch (this.level) {
          case 1:
            return 'Implementation';
          case 2:
            return 'Release';
          case 3:
            return 'Release';
          default:
            return '';
        }
      case 'C':
        switch (this.level) {
          case 1:
            return 'Release';
          case 2:
            return 'Closure';
          case 3:
            return 'Closure';
          default:
            return '';
        }
      default:
        return '';
    }
  }
  getRequiredStatus() {
    switch (this.stage) {
      case 'N':
        switch (this.level) {
          case 1:
            return 'Pending Approval';
          case 2:
            return 'Approved level1';
          case 3:
            return 'Approved level2';
          default:
            return '';
        }
      case 'R':
        switch (this.level) {
          case 1:
            return 'Implement';
          case 2:
            return 'Approved level1';
          case 3:
            return 'Approved level2';
          default:
            return '';
        }
      case 'C':
        switch (this.level) {
          case 1:
            return 'Released';
          case 2:
            return 'Approved level1';
          case 3:
            return 'Approved level2';
          default:
            return '';
        }
      default:
        return '';
    }
  }
  approveForm() {
    const currentDate = new Date();
    const formattedDate = this.datePipe.transform(currentDate, 'dd-MM-yyyy HH:mm:ss');
    this.approveTabGroup = new FormGroup({
      approvalDate: new FormControl(formattedDate),
      approvalTextArea: new FormControl(),
      approvalAttachDocument: new FormControl()
    })
  }

  getApprover() {
    const requestBody = {
      "level": this.level,
      "stage": this.stage,
      "plantid": Number(this.crData?.plantcode),
      "categoryId": Number(this.crData?.itcategoryId),
      "classificationId": Number(this.crData?.itclassificationId)
    }
    this.httpSer.httpPost(this.APIURLS.GetApprover, requestBody).subscribe((response: any) => {
      this.approverData = response[0];
      this.approverEmpId = parseInt(this.approverData.approver1Name.split('(')[1].split(')')[0]);
    })
  }

  getattach(event: any): void {
    this.selectedFile = event.target.files[0];
  }

  getdata() {
    const requestBody = {
      "Flag": "I",
      "CRApproverID": 1,
      "PlantID": this.crData?.plantcode,
      "SupportID": 1,
      "CRID": this.crData?.itcrid,
      "approverLevel": this.level,
      "Stage": this.stage,
      "ApproverID": this.user.empData.employeeNo,
      "ApprovedDt": new Date().toISOString().slice(0, 10),
      "Remarks": this.approveTabGroup.value['approvalTextArea'],
      "Comments": '',
      "Status": this.crData?.status?.trim(),
      "Attachment": this.approveTabGroup.value['approvalAttachDocument'],
      "CreatedBy": this.user.empData.employeeNo,
      "CreatedDt": new Date().toISOString().slice(0, 10),
      "ModifiedBy": this.user.empData.employeeNo,
      "ModifiedDt": new Date().toISOString().slice(0, 10),
    }

    this.httpSer.httpPost(this.APIURLS.CRApprove, requestBody).subscribe(
      (response: any) => {
        if (response.type == "E") {
          alert(response.message);
          return;
        }
        else {
          alert("RFC Code" + " " + this.crData?.crcode + " " + ": is Successfully" + " " + this.crData?.status.trim());
          // this.addFile();
          this.emailapproversinfo()
          // this.router.navigate(['changerequest/cr-master']);
        }
      },
      (error: any) => {
        console.error('POST request failed', error);
      });
  }

  emailapproversinfo(): Promise<any> {
    const apiUrl = '/GetApproverforEmail/GetApproverEmail';   
    const requestBody = {
      "stage": "N",
      "plantid": Number(this.crData?.plantcode),
      "categoryId": Number(this.crData?.itcategoryId),
      "classificationId": Number(this.crData?.itclassificationId)
    }
    return this.httpSer.httpPost(apiUrl, requestBody).toPromise()
      .then((response: any) => {
        this.emailData = response
        this.senEmail()
      })
      .catch((error: any) => {
        throw error;
      });
  }
  addFile(): void {
    if (!this.selectedFile) {
      console.error('No file selected.');
      return;
    }

    if (!this.crData?.itcrid) {
      console.error('ITCRID is required.');
      return;
    }

    const itcrid = this.crData?.itcrid.toString();
    const formData = new FormData();

    formData.append('itcrid', itcrid);
    formData.append('file', this.selectedFile, this.selectedFile.name);


    this.httpSer.httpPost(this.APIURLS.CRLession, formData).subscribe(
      (response: any) => {
      },
      (error: any) => {
      }
    );
  }

  
  senEmail(){
    const output = this.readHtmlFile('assets/NewApproveEmail.html');
    this.populatedOutput = output
          .replace('{{requestedBy}}', this.crData?.crrequestorName)
          .replace('{{requestedBy}}', this.crData?.crrequestorName)
          .replace('{{crCode}}', this.crData?.crcode)
          .replace('{{crDate}}', this.crData?.crdate.split('T')[0])
          .replace('{{approvedBy}}', this.user?.supportTeamData?.firstName)
          .replace('{{approvedBy}}', this.user?.supportTeamData?.firstName)
          .replace('{{changeDesc}}',this.crData?.changeDesc)
          .replace('{{Approvestatus}}', 'RFC '+ (this.stage=='N'?
          'Initiation':(this.stage=='C'?'Closure':'Release')) +' Approved Level '+this.level)
          .replace('{{phase}}', 'RFC Initiation Approval')
          .replace('{{status}}', + (this.stage=='N'?
          'Initiation':(this.stage=='C'?'Closure':'Release'))+' Approved Level 1')
          .replace('{{crapprover1}}', this.emailData[0]?.approver1Name)
          .replace('{{crapprover2}}', this.emailData?.length==2?(this.emailData[0].approver1Name):'NA')
          .replace('{{crapprover3}}', this.emailData?.length==3?(this.emailData[0].approver1Name):'NA')
          .replace('{{Approval1Status}}', 'Approved')
          .replace('{{Approval2Status}}', this.emailData?.length>=2?(this.level<2?'Pending':'Approved'):'NA')
          .replace('{{Approval3Status}}', this.emailData?.length==3?(this.level<3?'Pending':'Approved'):'NA')
          // this.crData?.crremail+
          const requestBody = {
            "to": this.emailData[this.level-1].approver1Email.trim().replace(/\s+/g, ' '),
            "cc": (','+this.emailData?.approver1Email+','+this.emailData.approver1Email).trim().replace(/\s+/g, ' '),
            
            "subject" : `Unnati:IT Change Request:${this.crData?.crcode} : RFC Initiation Approved Level 1`,
            "body": this.populatedOutput
          }
    
          const httpOptions = {
            headers: new HttpHeaders({
              'Content-Type': 'application/json'
            })
          };
          this.httpSer.httpPost('/Email', requestBody).subscribe(
            (response: any) => {
            },
            (error: any) => {
              console.log('Post request failed', error);
            });
      }

      readHtmlFile(file: string): string {
        const xhr = new XMLHttpRequest();
        xhr.open('GET', file, false);
        xhr.send();
        if (xhr.status === 200) {
          return xhr.responseText
        } else {
          console.error('Failed to read HTML file:', file);
          return '';
        }
      }
}
