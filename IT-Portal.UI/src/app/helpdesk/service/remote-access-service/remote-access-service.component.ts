import { Component } from '@angular/core';

@Component({
  selector: 'app-remote-access-service',
  templateUrl: './remote-access-service.component.html',
  styleUrl: './remote-access-service.component.css'
})
export class RemoteAccessServiceComponent {

  RequestFor: string = '';
  showProvideNewAccess: boolean = false;
  showRemoveAccess: boolean = false;
  today!: Date;
  check: boolean = false;



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
