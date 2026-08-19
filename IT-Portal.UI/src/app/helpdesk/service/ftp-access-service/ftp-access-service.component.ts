import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';import { environment } from '@environments/environment';

@Component({
  selector: 'app-ftp-access-service',
  templateUrl: './ftp-access-service.component.html',
  styleUrl: './ftp-access-service.component.css'
})
export class FtpAccessServiceComponent {


  RequestFor: string = '';
  showProvideNewAccess: boolean = false;
  showRemoveAccess: boolean = false;
  today!: Date;




  RequestForFunc() {
    if (this.RequestFor === "Provide New Access") {
      this.showProvideNewAccess = true;
      this.showRemoveAccess = false;

    }
    else if (this.RequestFor === "Remove Access") {
      this.showProvideNewAccess = false;
      this.showRemoveAccess = true;

    }
  }
}
