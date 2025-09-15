import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-chat-box',
  templateUrl: './chat-box.component.html',
  styleUrl: './chat-box.component.css'
})
export class ChatBoxComponent {

  srId:any
  remarkList:any
  assetId:any
  spareId:any

  constructor(private activeRoute: ActivatedRoute,public httpSer :HttpServiceService){

  }

  ngOnInit() {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.srId = m.srId
    });
    this.getComments()
  }

  getComments(){
    if(this.srId){
    this.httpSer.httpGet('/serviceMaster/getSRResolution', { srId:this.srId }).subscribe((res: any) => {
      this.remarkList = res?.data;
    })
    }else{
      this.activeRoute.queryParamMap.subscribe(param => {
        this.assetId = param.get('assetid');
        this.spareId = param.get('spareid');
        let body;
        let URL;
        if (this.spareId) {
          body = { ID: Number(param.get('spareid')) }
          URL = '/ITSpareRequest/GetSpareHistoryBYID';
        }
        if (this.assetId) {
          body = { ID: param.get('assetid') }
          URL = '/AssetRequest/GetAssetHistoryBYID';
        }
        if (body) {
          this.httpSer.httpGet(URL, body).subscribe(
            (response: any) => {
              this.remarkList = response?.data
            }
          )
        }
      })
    }
  }
}
