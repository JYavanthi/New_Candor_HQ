import { Component } from '@angular/core';

@Component({
  selector: 'app-antivirus-service',
  templateUrl: './antivirus-service.component.html',
  styleUrl: './antivirus-service.component.css'
})
export class AntivirusServiceComponent {

  today!: Date;
  RequestFor: string = '';
  showInstall: boolean = false;
  showUninstall: boolean = false;
  showExcludeFolders: boolean = false;
  showIncludeFolders: boolean = false;
  




  RequestForFunc() {
    if (this.RequestFor === "Install") {
      this.showInstall = true;
      this.showUninstall = false;
      this.showExcludeFolders = false;
      this.showIncludeFolders = false;
    }
    else if (this.RequestFor === "Uninstall") {
      this.showInstall = false;
      this.showUninstall = true;
      this.showExcludeFolders = false;
      this.showIncludeFolders = false;
    }

    else if (this.RequestFor === "Exclude Folders") {
      this.showInstall = false;
      this.showUninstall = false;
      this.showExcludeFolders = true;
      this.showIncludeFolders = false;
    }
    else if (this.RequestFor === "Include Folders") {
      this.showInstall = false;
      this.showUninstall = false;
      this.showExcludeFolders = false;
      this.showIncludeFolders = true;
    }
  }

  
}
