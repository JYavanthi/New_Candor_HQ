import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';import { environment } from '@environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpServiceService {
  apiUrl = environment.apiurls;
  headers= new HttpHeaders({
    'Content-Type': 'application/json'
  })
  constructor(private http: HttpClient) { }

  httpGet(apiUrls:any, param:any={}): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}${apiUrls}`, { params: param });
  }

  httpDelete(apiUrls:any, param:any={}): Observable<any[]> {
    return this.http.delete<any[]>(`${this.apiUrl}${apiUrls}`, { params: param });
  }

  httpPost(apiUrls:any, param:any): Observable<any[]> {
    return this.http.post<any[]>(`${this.apiUrl}${apiUrls}`, param,{headers : this.headers});
  }

  httpPut(apiUrls:any, param:any): Observable<any[]> {
    return this.http.put<any[]>(`${this.apiUrl}${apiUrls}`, param,{headers : this.headers});
  }

}
