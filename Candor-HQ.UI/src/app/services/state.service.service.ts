import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface State {
  id: number;
  name: string;
  stateCode: string;
  countryName: string;
}

export interface Country {
  id: number;
  name: string;
}

export interface City {
  id: number;
  name: string;
  stateId: number;
  stateName: string;
  countryId: number;
  countryName: string;
}

export interface Pincode {
  id: number;
  pincode: string;
  officename: string;
  districtname: string;
}

@Injectable({
  providedIn: 'root'
})
export class StateServiceService {


  private baseUrl = 'http://localhost:5014/api';

  constructor(private http: HttpClient) { }


  // ✅ Countries
  getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(`${this.baseUrl}/Country/GetAllCountries`);
  }

  // ✅ States by Country
  getStatesByCountry(countryId: number) {
    return this.http.get<State[]>(
      `${this.baseUrl}/State/GetStatesByCountry?countryId=${countryId}`
    );
  }

  // ✅ Cities by State
  getCitiesByState(stateId: number) {
    return this.http.get<City[]>(
      `${this.baseUrl}/City/GetCitiesByState?stateId=${stateId}`
    );
  }

  // ✅ Pincode by City
  getPincodesByCity(cityId: number) {
    return this.http.get<Pincode[]>(
      `${this.baseUrl}/Pincode/GetPincodesByCity?cityId=${cityId}`
    );
  }

}
