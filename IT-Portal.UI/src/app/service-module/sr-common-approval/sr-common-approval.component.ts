import { Component, Input, SimpleChanges } from '@angular/core';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-sr-common-approval',
  templateUrl: './sr-common-approval.component.html',
  styleUrls: ['./sr-common-approval.component.css', '../servicemodule.css']
})
export class SrCommonApprovalComponent {
  approveTabIndex =0;
  @Input() srData :any;
  @Input() assetData :any;
  approverData: any;
  @Input() isAsset:any
  @Input() isSpare:any
  splitConst=' ('

  constructor(public httpSer: HttpServiceService){

  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['srData']) {
      if(this.srData != undefined){
        this.getApprover()
      }
    }
  }


getApprover(){
  this.httpSer.httpGet('/serviceMaster/getSrApprover',{id:this.srData?.srraiseFor?.split('(')[1]?.split(')')[0]}).subscribe(
    (response : any) => {
      this.approverData = response?.data[0]
    }
  )
}
}
