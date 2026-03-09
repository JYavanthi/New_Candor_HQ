import { Component } from '@angular/core';

@Component({
  selector: 'app-internet-access-service',
  templateUrl: './internet-access-service.component.html',
  styleUrl: './internet-access-service.component.css'
})
export class InternetAccessServiceComponent {
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
