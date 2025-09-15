import { DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-sr-approver',
  templateUrl: './sr-approver.component.html',
  styleUrl: './sr-approver.component.css'
})
export class SrApproverComponent {

  public approveTabGroup!: FormGroup;
  constructor(private httpSer: HttpServiceService, private datePipe: DatePipe, 
    private router: Router,private userInfo: UserInfoSerService){

  }
  oninit(){
    
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
  
  // getApprover() {
  //   const requestBody = {
  //     "level": this.level,
  //     "stage": this.stage,
  //     "plantid": Number(this.crData?.plantcode),
  //     "categoryId": Number(this.crData?.itcategoryId),
  //     "classificationId": Number(this.crData?.itclassificationId)
  //   }
  //   this.httpSer.httpPost(this.APIURLS.GetApprover, requestBody).subscribe((response: any) => {
  //     this.approverData = response[0];
  //     this.approverEmpId = parseInt(this.approverData.approver1Name.split('(')[1].split(')')[0]);
  //   })
  // }
}
