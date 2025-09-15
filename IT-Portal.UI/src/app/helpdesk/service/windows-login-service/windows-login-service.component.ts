import { Component } from '@angular/core';

@Component({
  selector: 'app-windows-login-service',
  templateUrl: './windows-login-service.component.html',
  styleUrl: './windows-login-service.component.css'
})
export class WindowsLoginServiceComponent {


  today!: Date;
  RequestFor: string = '';
  showNewUsers: boolean = false;
  showChangeOU: boolean = false;
  showResetPassword: boolean = false;
  showUnlockUser: boolean = false;
  showDisableUser: boolean = false;




  RequestForFunc() {
    if (this.RequestFor === "New Users") {
      this.showNewUsers = true;
      this.showChangeOU = false;
      this.showResetPassword = false;
      this.showUnlockUser = false;
      this.showDisableUser = false;
    }
    else if (this.RequestFor === "Change OU") {
      this.showNewUsers = false;
      this.showChangeOU = true;
      this.showResetPassword = false;
      this.showUnlockUser = false;
      this.showDisableUser = false;
    }

    else if (this.RequestFor === "Reset Password") {
      this.showNewUsers = false;
      this.showChangeOU = false;
      this.showResetPassword = true;
      this.showUnlockUser = false;
      this.showDisableUser = false;
    }

    else if (this.RequestFor === "Unlock User") {
      this.showNewUsers = false;
      this.showChangeOU = false;
      this.showResetPassword = false;
      this.showUnlockUser = true;
      this.showDisableUser = false;
    }
    else if (this.RequestFor === "Disable User") {
      this.showNewUsers = false;
      this.showChangeOU = false;
      this.showResetPassword = false;
      this.showUnlockUser = false;
      this.showDisableUser = true;
    }


  }
}
