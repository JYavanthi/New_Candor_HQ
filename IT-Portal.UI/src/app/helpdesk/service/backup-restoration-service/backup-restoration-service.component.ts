import { Component } from '@angular/core';

@Component({
  selector: 'app-backup-restoration-service',
  templateUrl: './backup-restoration-service.component.html',
  styleUrl: './backup-restoration-service.component.css'
})
export class BackupRestorationServiceComponent {


  RequestFor: string = '';
  today!: Date;
  showBackupintoTape: boolean = false;
  showBackupintoExternalDrive: boolean = false;
  showRestorationRequest: boolean = false;


  
  RequestForFunc() {
    if (this.RequestFor === "Backup into Tape") {
      this.showBackupintoTape = true;
      this.showBackupintoExternalDrive = false;
      this.showRestorationRequest= false;
    }
    
    else if (this.RequestFor === "Backup into External Drive") {
      this.showBackupintoTape = false;
      this.showBackupintoExternalDrive = true;
      this.showRestorationRequest= false;
    }

    else if (this.RequestFor === "Restoration Request") {
      this.showBackupintoTape = false;
      this.showBackupintoExternalDrive = false;
      this.showRestorationRequest= true;
    }


  }


}
