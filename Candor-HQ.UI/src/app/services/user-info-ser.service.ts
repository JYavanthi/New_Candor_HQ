import { isPlatformBrowser } from '@angular/common';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserInfoSerService {

  private readonly LOCAL_STORAGE_KEY = 'user';
  isBrowser: boolean;
  constructor(@Inject(PLATFORM_ID) private platformId: Object) {
    this.isBrowser = isPlatformBrowser(this.platformId);
   }

  setUser(user:any) {
    localStorage.setItem(this.LOCAL_STORAGE_KEY, JSON.stringify(user));
  }

  getUser() {
    const userString = this.isBrowser? localStorage.getItem(this.LOCAL_STORAGE_KEY):'';
    return userString ? JSON.parse(userString) : '';
  }
}
