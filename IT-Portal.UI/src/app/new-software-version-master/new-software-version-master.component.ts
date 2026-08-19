import { Location } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-new-software-version-master',
  templateUrl: './new-software-version-master.component.html',
  styleUrl: './new-software-version-master.component.css'
})

export class NewSoftwareVersionMasterComponent {
  myForm!: FormGroup
  id: any
  softwareList: any
  softData:any
  constructor(public httpSer: HttpServiceService, public fb: FormBuilder, public route: Router, public router: ActivatedRoute,
    public httpser: HttpServiceService, public location: Location
  ) {
    this.router.queryParams.subscribe(params => {
      this.id = params['id'];
    });
    this.formInit()
    this.getVersionData()
    this.getData()
  }
  formInit() {
    this.myForm = this.fb.group({
      softwareName: ['', Validators.required],
      softwareVersion: ['', Validators.required],
      active: [true, Validators.required]
    });
  }

  getData() {
    this.httpser.httpGet('/SoftwareLibrary/GetSoftwarevalue').subscribe((res: any) => {
      this.softwareList = res
      if(this.id){
        this.patchValu()
      }
    })
  }

  saveSoftware() {

    let param = {

      "flag": this.id?"U":"I",
      "softVersionID": this.id??0,
      "softwareLibraryID": this.myForm.value.softwareName,
      "softVersionName": this.myForm.value.softwareVersion,
      "isActive": true,
      "createdBy": 0
    }
    this.httpSer.httpPost('/SoftwareVersion/PostSoftwareVersion', param).subscribe((res: any) => {
      alert('Software Version Added Succesfully.')
      this.route.navigate(['/softwareVersionMaster']);
    })
  }

  getVersionData(){
    this.httpser.httpGet('/SoftwareVersion/GetSoftwareversionValue').subscribe(res=>{
      if(this.id){
        this.softData = res?.filter((m:any)=>m.softVersionId==this.id)[0]
        this.patchValu();
      }
    })
  }
  patchValu(){
    this.myForm.patchValue({
      softwareName : this.softData?.softwareLibraryId,
      active : this.softData?.isActive,
      softwareVersion : this.softData?.softVersionName
    })
  } 

  back() {
    this.location.back();
  }
}
