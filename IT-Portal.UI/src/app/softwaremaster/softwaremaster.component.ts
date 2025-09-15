import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-softwaremaster',
  templateUrl: './softwaremaster.component.html',
  styleUrl: './softwaremaster.component.css'
})
export class SoftwaremasterComponent {

  softwareList:any
  searchText:any
  constructor(public httpser:HttpServiceService,public route: Router){
    this.getSoftwareList()
  }

  deleteRow(id:any) {
    let param={
      "flag": "D",
      "softwareName": "String",
      "softwareLibraryID":id,
      "isActive": true,
      "createdBy": 0
    }

    this.httpser.httpPost('/SoftwareLibrary/PostSoftwareValue',param).subscribe(res=>{
      alert('Software Deleted Succesfully.')
      this.getSoftwareList()
  
    })
  }
  filterData(){

  }

  getSoftwareList() {
    this.httpser.httpGet('/SoftwareLibrary/GetSoftwarevalue').subscribe(res=>{
      this.softwareList=res
    })
  }

  
  navigateTo(id:any) {
    this.route.navigate(['/newsoftwaremaster'], { queryParams: {id:id} });
  }
}
