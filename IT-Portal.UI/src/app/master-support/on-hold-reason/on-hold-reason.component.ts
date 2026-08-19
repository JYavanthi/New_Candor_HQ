import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-on-hold-reason',
  templateUrl: './on-hold-reason.component.html',
  styleUrl: './on-hold-reason.component.css'
})
export class OnHoldReasonComponent {
  deleteconfirmation:any
  reasonList:any

  constructor(public httpSer:HttpServiceService,
    private route: Router){}

  ngOnInit() {
    this.getReasonList();
  }

  getReasonList(){
    this.httpSer.httpGet('/Classification/getHoldOnReason').subscribe(
      (response: any) => {
        this.reasonList = response
      },
      (error) => {
      }
    )
  }

  navigateToView(reason:any){
    this.route.navigate(['/viewOnHoldReasonnMaster'], { queryParams: { id :reason.issueOnholdCatId} });
  }
  
  deleteReasondata(reason:any){
    this.httpSer.httpGet('/Classification/deleteHoldOnReasonById',{id:reason.issueOnholdCatId}).subscribe(
      (response: any) => {
        this.getReasonList()
      },
      (error) => {
      }
    )
  }
  
}
