import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  private loginurls = environment.loginurl;
  constructor() { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    let isLoggedIn = localStorage.getItem('isLoggedin');
    if (isLoggedIn === 'true') {
      return true;
    } else {
        if (confirm("You're Not Authenticated!")) {
          localStorage.removeItem('token');
          localStorage.setItem('isLoggedin', 'false');
          window.location.href = this.loginurls + '#' + '/login';
        }
      return false;
    }
  }
}
