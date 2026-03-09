import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-history-tab',
  templateUrl: './history-tab.component.html',
  styleUrl: './history-tab.component.css'
})
export class HistoryTabComponent {
  projectid: any
  history: any;
  @Input() srData: any
  constructor(public activeRoute: ActivatedRoute, public httpSer: HttpServiceService) {
    this.activeRoute.queryParamMap.subscribe(param => {
      if (param.get('projectid')) {
        this.projectid = param.get('projectid');
      }
    })
  }

  ngOnInit() {
    this.getHistoryData()
  }

  getHistoryData() {
    this.httpSer.httpGet('/projectManagement/getPrHistory', { projectid: 4 }).subscribe(
      (response: any) => {
        this.history = response?.data
        console.log(this.history)
      }
    )
  }
}
