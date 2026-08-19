import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { HttpServiceService } from 'shared/services/http-service.service';import { environment } from '@environments/environment';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { filter } from 'rxjs';
@Component({
  selector: 'app-support-master',
  templateUrl: './support-master.component.html',
  styleUrl: './support-master.component.css'
})
export class SupportMasterComponent {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  supportvalue: any[] = [];
  pageIndex = 0;
  pageSize = 10;
  totalItems = 0;
  deleteconfirmation: boolean = false;
  allSupportValues=[]
  constructor(private http: HttpClient, private httpSer: HttpServiceService, private router: Router) {

  }
  private apiurl = environment.apiurls;
  ngOnInit() {
    this.getsupportvalue();
  }
  getsupportvalue() {
    let param = {
      pageNumber: this.pageIndex + 1,
      pageSize: this.pageSize,
    }
    const apiUrls = '/SupportMaster/GetSupportValue';
    this.httpSer.httpGet(apiUrls, param).subscribe(res => {
      let response: any = res
      this.allSupportValues = response.data
      this.supportvalue = response.data
      this.totalItems = this.supportvalue.length;
      this.supportvalue = this.supportvalue.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize);
    })
  }

  onPageChange(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.getsupportvalue();
  }

  update(supportId: any) {
    this.router.navigate(['/mastermodule/newsupportmaster'], { queryParams: { id: supportId } });
  }

  getSupportID: any;
  deleteRow(supportId: any) {
    this.deleteconfirmation = true;
    this.getSupportID = supportId;
  }

  deleteYes() {
    this.deleteconfirmation = false;

    let param = {
      SupportID: this.getSupportID
    };

    const apiUrls = '/SupportMaster/DeleteSupport';

    this.httpSer.httpGet(apiUrls, param).subscribe(res => {
      const response = res as unknown as { type: string; message: string; data: any; count: number; };
      if (response) {
        if (response.type === "S") {
          alert('Record Deleted Successfully!');
          this.getsupportvalue();
        } else {
          alert('Error! Unable to Delete.');
        }
      }
    });
  }

  deleteNo() {
    this.deleteconfirmation = false
  }

  serach(event:any){
    this.supportvalue=this.allSupportValues.filter((m:any)=>m.supportName.includes(event.value))
  }
}