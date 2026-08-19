import { Component } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';import { environment } from '@environments/environment';
import { HttpServiceService } from 'shared/services/http-service.service';
import { firstValueFrom } from 'rxjs';
import { TaskTracker } from './trackSlaCal';

@Component({
  selector: 'app-slamaster',
  templateUrl: './slamaster.component.html',
  styleUrl: './slamaster.component.css'
})
export class SlamasterComponent {
  slaList: any;
  workingDays:any;
  taskStatus: any;
  constructor(private http: HttpClient, private router: Router, public httpService : HttpServiceService,
    private route: ActivatedRoute) {
  
  }
  ngOnInit() {
    this.getSlaList()
    this.taskStatus = this.getTaskStatus(new Date('2024-07-01T10:00:00'), 40);
  }

  getTaskStatus(startDate: Date, providedHours: number): string {
    const tracker = new TaskTracker(startDate, providedHours);
    return tracker.getTaskStatus();
  }


  private apiurl = environment.apiurls;

  async getSlaList() {
    const getSlaList= '/SlaMaster/GetSlaList'
    await this.httpService.httpGet(getSlaList).subscribe(res=>{
    })

    this.slaList = await firstValueFrom(this.httpService.httpGet(getSlaList));
    await this.getWorkindDays()
  }

  async getWorkindDays() {
    const getWorkingDateUrl= '/SlaMaster/GetWorkingDate'
    let param = {
      empId : 1,
      startDate :  new Date(),
      endDate :  new Date()
    }
    this.workingDays = await firstValueFrom(this.httpService.httpGet(getWorkingDateUrl, { params: param }));
    await this.calculateSla()
  }
  calculateSla(){
    try {
      const millisecondsIn1Day = 24 * 60 * 60 * 1000;
      if (Array.isArray(this.slaList)) {
      } else {
        console.warn('slaList is not an array or is undefined');
      }
    } catch (error) {
      console.error('Error calculating SLA:', error);
    }
  }

  
  deleteSLA(slaId:any) {
    const getSlaList= '/SlaMaster/deleteById'
    let param = {
      id : slaId
    }
    this.httpService.httpGet(getSlaList,param).subscribe(res=>{
      if(res){
        this.getSlaList()
      }
    })

  }

}
