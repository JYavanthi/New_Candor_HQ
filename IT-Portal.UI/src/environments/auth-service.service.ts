import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MockapiserviceService } from './mockapiservice.service';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {
  private apiUrl = 'http://192.168.2.38:8082/api/api/';

  constructor(private http: HttpClient, private mockApiService: MockapiserviceService) { }

  login(username: string, password: string): Observable<any> {
    return this.mockApiService.authenticate(username, password);
  }

  setToken(username: string, password: string) {
    localStorage.setItem('username', username);
    localStorage.setItem('password', password);
  }

  logout(): Observable<any> {
    return this.http.post(`${this.apiUrl}/logout`, {});
  }
}
