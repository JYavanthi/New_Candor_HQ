import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PasscrdataService } from '../change-request/passcrdata.service';
import { HttpClient} from '@angular/common/http';
import { environment } from '@environments/environment';
import { UserInfoSerService } from 'app/services/user-info-ser.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})

export class HomeComponent {
  username: string = '';
  password: string = '';
  supportid: any;
  supportempid: any;
  supportteams: any[] = [];
  private apiurl = environment.apiurls
  private loginurls = environment.loginurl;
  checkValidation: any;

  constructor(private http: HttpClient, private routeservice: PasscrdataService, private route: ActivatedRoute, private router: Router,
    private user: UserInfoSerService) {
    if (!sessionStorage.getItem('reloaded')) {
      sessionStorage.setItem('reloaded', 'true');
      window.location.reload();
    } else {
      sessionStorage.removeItem('reloaded');
    }

    this.employeeid();
  }
  idofemployee: any;

  // checkValidUSer(v:number){
  // }
  async employeeid() {
    this.route.params.subscribe(params => {
      this.idofemployee = params['this.empNumber'];
    });
    const apiUrls = this.apiurl + '/userValidate/getValidateUSer?empNum='+parseInt(this.idofemployee)
    const response: any = await this.http.get(apiUrls).toPromise();
    this.checkValidation = response
    if (this.checkValidation['isValid']) {
        localStorage.setItem('isLoggedin', 'true');
        this.user.setUser(this.checkValidation)
        this.routeservice.setEmployeeId(this.idofemployee);
        this.router.navigate(['/dashboard']);
    } 
    else {
      localStorage.setItem('isLoggedin', 'false');
      if (confirm("You're Not Authenticated!")) {
        window.location.href = this.loginurls + '#' + '/slogin';
      }
      return;
    }
    //  else {
    //   localStorage.setItem('isLoggedin', 'ture');
    //   if (confirm("You're Not Authenticated!")) {
    //     window.location.href = this.loginurls + '#' + '/slogin';
    //   }
    //   return;
    // }
  }

}
