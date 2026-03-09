import { Location } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-new-software-master',
  templateUrl: './new-software-master.component.html',
  styleUrl: './new-software-master.component.css'
})
export class NewSoftwareMasterComponent {
  myForm!:FormGroup
  id:any
  softwareList:any
  softData:any
  constructor(public httpSer:HttpServiceService,public fb:FormBuilder,public route: Router,public router: ActivatedRoute,
    public httpser:HttpServiceService, private location :Location
  ){
    this.router.queryParams.subscribe(params => {
      this.id = params['id'];
  });
  this.formInit( )
  this.getData()
  }
formInit(){
  this.myForm = this.fb.group({
    softwareName : ['',Validators.required],
    softwareVersionName : ['',Validators.required],
    active : [true,Validators.required]
  });
}

getData(){
  this.httpser.httpGet('/SoftwareLibrary/GetSoftwarevalue').subscribe(res=>{
    this.softwareList=res
    if(this.id){
      this.softData = this.softwareList.filter((m:any)=>m.softwareLibraryId==this.id)[0]

      this.patchValu();
    }
  })
}



patchValu(){
  this.myForm.patchValue({
    softwareName : this.softData.softwareName,
    active : this.softData.isActive
  })
}
  saveSoftware(){

    let param={
      "flag": this.id?"U":"I",
      "softwareLibraryID":this.id??0,
      "softwareName": this.myForm.value.softwareName,
      "isActive": this.myForm.value.active,
      "createdBy": 0
    }
    this.httpSer.httpPost('/SoftwareLibrary/PostSoftwareValue',param).subscribe(res=>{
      alert('Software Added Succesfully.')
      this.route.navigate(['/softwareMaster']);
    })
  }
  
  back(){
this.location.back();
  }
}
