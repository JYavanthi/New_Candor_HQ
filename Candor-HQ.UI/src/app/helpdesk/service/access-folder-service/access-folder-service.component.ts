import { Component } from '@angular/core';

@Component({
  selector: 'app-access-folder-service',
  templateUrl: './access-folder-service.component.html',
  styleUrl: './access-folder-service.component.css'
})
export class AccessFolderServiceComponent {

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
