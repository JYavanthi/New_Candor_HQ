import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-cr-history',
  templateUrl: './cr-history.component.html',
  styleUrl: './cr-history.component.css'
})
export class CrHistoryComponent {
  @Input() crId: any;
  tableData: any;

  constructor(private route: ActivatedRoute,public httpser:HttpServiceService){
    
    this.route.queryParamMap.subscribe(params => {
      this.crId =  params.get('id')
      if(this.crId){
        this.getData()
      }
    })
  }

  ngOnInit(): void {
    this.getData()
  }

  getData() {
    
    const apiUrls = '/ViewChangeHistory/GetChangeRequestHistory'

    this.httpser.httpGet(apiUrls,{id:this.crId}).subscribe(
      (response: any) => {
        this.tableData = response;
        this.tableData = this.tableData.sort((a:any, b:any) => {
          return new Date(a.crhistoryDt).getTime() - new Date(b.crhistoryDt).getTime();
        });
      },
      (error) => {
        console.error("Data fetching error", error)
      }
    )
  }
}
