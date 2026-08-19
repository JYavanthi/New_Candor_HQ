import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-sr-common-history',
  templateUrl: './sr-common-history.component.html',
  styleUrls: ['./sr-common-history.component.css', '../servicemodule.css']
})
export class SrCommonHistoryComponent {

  srId: any
  history: any[] = [];
  @Input() srData : any
  constructor(public activeRoute: ActivatedRoute, public httpSer: HttpServiceService) {
    this.activeRoute.queryParamMap.subscribe(param => {
      if (param.get('srId')) {
        this.srId = param.get('srId');
      }
    })
  }

  ngOnInit() {
    this.getHistoryData()
  }
  
  getHistoryData() {
    this.httpSer.httpGet('/serviceMaster/getSRHistory', { srId: this.srId }).subscribe(
      (response: any) => {
        this.history = response?.data
      }
    )
  }
}
