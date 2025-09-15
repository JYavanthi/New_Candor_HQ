import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Component, HostListener,ElementRef } from '@angular/core';
import { PasscrdataService } from '../change-request/passcrdata.service';
import { Router } from '@angular/router';import { environment } from '@environments/environment';
import { UserInfoSerService } from 'app/services/user-info-ser.service';

@Component({
  selector: 'app-headers',
  templateUrl: './headers.component.html',
  styleUrl: './headers.component.css'
})
export class HeadersComponent {
  logedInUser: any;
constructor(private http: HttpClient,
  private userSer: UserInfoSerService,private route: Router, private elementRef: ElementRef) {
    this.logedInUser  = userSer.getUser()
}
@HostListener('document:click', ['$event'])
  onClick(event: Event) {
    if (!this.elementRef.nativeElement.contains(event.target)) {
     
    }
  }

 showDropdown: boolean = false;

toggleDropdown() {
    this.showDropdown = !this.showDropdown;
  }



ngOnInit(): void {
}
  private apiurl = environment.apiurls
  private loginurls = environment.loginurl
  idofemployee: any;
  urls: string = '';

  async logout() {
    this.idofemployee = '';
    localStorage.removeItem('token');
    localStorage.setItem('isLoggedin', 'false');
    this.urls = this.loginurls + '#' + '/login'
    window.location.href = this.urls
  }
}
