import { Component } from '@angular/core';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { UserInfo } from 'os';

@Component({
  selector: 'app-change-request-report',
  templateUrl: './change-request-report.component.html',
  styleUrl: './change-request-report.component.css'
})
export class ChangeRequestReportComponent {
selectedOption: string = '';
  loggedUer: any;

constructor(public userInfo: UserInfoSerService){
  
  this.loggedUer = userInfo.getUser()
}
  onOptionSelected(option: string): void {
    this.selectedOption = option;
  }
}
