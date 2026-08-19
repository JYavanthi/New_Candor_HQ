import { Component, Input, SimpleChanges } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { HttpServiceService } from '../../../shared/services/http-service.service';

@Component({
  selector: 'app-cr-approve',
  templateUrl: './cr-approve.component.html',
  styleUrl: './cr-approve.component.css'
})
export class CrApproveComponent {
  @Input() crData: any;
  @Input() stage: string ='';
  changeRequestData: any;
  GetApproverResponse: any[] = [];
  approveTabIndex= 0;
  historyDetails:any

  constructor(private formBuilder: FormBuilder, private httpSer: HttpServiceService) {

  }

  ngOnInit() {
  this.getHistortDetails()
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['crData']) {
      if(this.crData){
      }
      // this.getapproverslevel();

    }
  }

  APIURLS = {
    GetApprover: '/GetApproval/GetApprover',
  };

  // getapproverslevel() {
  //   const requestBody = {
  //     "level": /*Number(this.APILevel)*/'',
  //     "stage": "N",
  //     "plantid": Number(this.crData?.plantId),
  //     "categoryId": Number(this.crData?.categoryId),
  //     "classificationId": Number(this.crData?.classificationId)
  //   }
  //   this.httpSer.httpPost(this.APIURLS.GetApprover, requestBody).subscribe((response: any) => {

  //   })
  // }

  
  getHistortDetails() {
    const apiUrls = '/ViewChangeHistory/GetCrApproverHistory?id=' + this.crData?.itcrid
    
    this.httpSer.httpGet(apiUrls).subscribe(
      (response: any) => {
        this.historyDetails = response;
        this.historyDetails = this.historyDetails.sort((a:any, b:any) => {
          return new Date(a.crhistoryDt).getTime() - new Date(b.crhistoryDt).getTime();
        });
      }
    )
  }
}




