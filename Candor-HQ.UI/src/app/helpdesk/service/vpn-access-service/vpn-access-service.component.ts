import { Component } from '@angular/core';

@Component({
  selector: 'app-vpn-access-service',
  templateUrl: './vpn-access-service.component.html',
  styleUrl: './vpn-access-service.component.css'
})
export class VpnAccessServiceComponent {

  RequestFor: string = '';
  today!: Date;
  showProvideAccess: boolean = false;
  showRemoveAccess: boolean = false;

  RequestForFunc() {
    if (this.RequestFor === "Provide Access") {
      this.showProvideAccess = true;
      this.showRemoveAccess = false;
    }
    else if (this.RequestFor === "Remove Access") {
      this.showProvideAccess = false;
      this.showRemoveAccess = true;
    }


  }







}
