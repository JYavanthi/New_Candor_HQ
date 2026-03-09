import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-common-asset-history',
  templateUrl: './common-asset-history.component.html',
  styleUrl: './common-asset-history.component.css'
})
export class CommonAssetHistoryComponent {
  historyList: any;
  assetId: any;
  spareId: any;

  constructor(public activeRoute: ActivatedRoute, public httpSer: HttpServiceService) {
    this.activeRoute.queryParamMap.subscribe(param => {
      this.assetId = param.get('assetid');
      this.spareId = param.get('spareid');
      let body;
      let URL;
      if (param.get('spareid')) {
        body = { ID: param.get('spareid') }
        URL = '/ITSpareRequest/GetSpareHistoryBYID';
      }
      if (param.get('assetid')) {
        body = { ID: param.get('assetid') }
        URL = '/AssetRequest/GetAssetHistoryBYID';
      }
      if (body) {
        this.httpSer.httpGet(URL, body).subscribe(
          (response: any) => {
            this.historyList = response?.data
          }
        )
      }
    })
  }

}
