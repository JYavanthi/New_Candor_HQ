import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataTransferServiceService {

  constructor() { }
  Data: any
  setData(data: any) {
    this.Data = data
  }

  getData() {
    return this.Data
  }
  proManagementTitles: { [key: string]: { title: string } } = {
    '/projectmanagement/report/projectreport': { title: 'Project Report' },
  };

}
