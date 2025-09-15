import { Component } from '@angular/core';

@Component({
  selector: 'app-usb-access-service',
  templateUrl: './usb-access-service.component.html',
  styleUrl: './usb-access-service.component.css'
})
export class UsbAccessServiceComponent {

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
