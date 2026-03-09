import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-pro-history',
  templateUrl: './pro-history.component.html',
  styleUrls: ['./pro-history.component.css', '../promanagement.css']
})
export class ProHistoryComponent {
  proId: any
  historyList: any;
  @Input() srData : any
  constructor(public activeRoute: ActivatedRoute, public httpSer: HttpServiceService) {
    this.activeRoute.queryParams.subscribe((m: any) => {
     this.proId = m['projectId']
    })
  }

  ngOnInit() {
    this.getHistoryData()
  }

  getHistoryData() {
  this.httpSer.httpGet('/projectManagement/getPrHistory', { projectid: +this.proId }).subscribe(
    (response: any) => {
      this.historyList = (response?.data || []).sort((a, b) => {
        return new Date(b.modifiedDt).getTime() - new Date(a.modifiedDt).getTime();
      });
      console.log(this.historyList);
    }
  );
}



}
