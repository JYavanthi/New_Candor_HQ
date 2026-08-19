import { Component } from '@angular/core';

@Component({
  selector: 'app-wifi-access-service',
  templateUrl: './wifi-access-service.component.html',
  styleUrl: './wifi-access-service.component.css'
})
export class WifiAccessServiceComponent {


  RequestFor: string = '';
  today!: Date;
  showProvideNewAccess: boolean = false;
  showRemoveAccess: boolean = false;

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
