import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface State {
  id: number;
  name: string;
  stateCode: string;
  countryName: string;
}

@Injectable({
  providedIn: 'root'
})
export class StateServiceService {


  private apiUrl = 'http://localhost:5014/api/State/GetAllStates';

  constructor(private http: HttpClient) { }

  getStates(): Observable<State[]> {
    return this.http.get<State[]>(this.apiUrl);
  }
}
