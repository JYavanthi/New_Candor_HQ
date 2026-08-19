import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-software-version-master',
  templateUrl: './software-version-master.component.html',
  styleUrl: './software-version-master.component.css'
})
export class SoftwareVersionMasterComponent {

  softwareList:any
  searchText:any
  softwareVersinList:any
  constructor(public httpser:HttpServiceService,public route: Router){
    this.getSoftwareList()
    this.getVersionData()
  }

  deleteRow(id:any) {
    let param={
      "flag": "D",
      "softwareName": "String",
      "softVersionName": "String",
      "isActive": true,
      "softVersionID": id,
      "createdBy": 0
    }

    this.httpser.httpPost('/SoftwareVersion/PostSoftwareVersion',param).subscribe((res:any)=>{
      alert('Software Version Deleted Successfully.')
      this.route.navigate(['/softwareMaster']);
  
    })
  }
  filterData(){

  }

  getSoftwareList() {
    this.httpser.httpGet('/SoftwareLibrary/GetSoftwarevalue').subscribe((res:any)=>{
      this.softwareList=res
    })
  }

  getVersionData(){
    this.httpser.httpGet('/SoftwareVersion/GetSoftwareversionValue').subscribe(res=>{
      this.softwareVersinList=res
    })
  }
  navigateTo(id:any) {
    this.route.navigate(['/newsoftwareVersionMaster'], { queryParams: {id:id} });
  }
}
