import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { FormValidationService } from 'app/services/form-validation.service';


@Component({
  selector: 'app-create-project-group',
  templateUrl: './create-project-group.component.html',
  styleUrl: './create-project-group.component.css'
})
export class CreateProjectGroupComponent {

  myForm!: FormGroup
  id: any
  projectGroupData: any
  user: any
  constructor(public httpSer: HttpServiceService,private formValidationService: FormValidationService, public fb: FormBuilder, public route: Router, public router: ActivatedRoute,
    public httpser: HttpServiceService, public userInfoSer: UserInfoSerService
  ) {
    this.router.queryParams.subscribe(params => {
      this.id = params['id'];
    });

    this.user = this.userInfoSer.getUser()
    this.formInit()
    this.getData()
  }
  formInit() {
    this.myForm = this.fb.group({
      groupName: ['', Validators.required],
      active: [true, Validators.required]
    });
  }

  getData() {
    this.httpser.httpGet('/projectGroup/getProjectGropByID', { id: this.id }).subscribe((res:any) => {
      this.projectGroupData = res['data']
      if (this.id) {
        this.patchValue();
      }
    })
  }
  patchValue() {
    this.myForm.patchValue({
      groupName: this.projectGroupData.projectGroupName,
      active: this.projectGroupData.isActive
    })
  }
  saveSoftware() {

    if(this.formValidationService.validateForm(this.myForm)){
      
    let param = {
      "flag": this.id ? 'U' : "I",
      "projectGroupID": this.id??0,
      "projectGroupName": this.myForm.value.groupName,
      "isActive": this.myForm.value.active,
      "createdBy": !this.id? this.user?.empData?.employeeNo:0,
      "modifiedBy": this.id? this.user?.empData?.employeeNo:0
    }
    this.httpSer.httpPost('/projectGroup/saveProject', param).subscribe((res: any) => {
      if (res.type == 'S') {
        alert('Project Group ' + (this.id ? 'Updated' : 'Added') + ' Succesfully.')
      this.route.navigate(['/projectgroupmaster']);
      } 
      else if(res.type == "E"){
        var error = res.message
        alert(error)
      } else {
        console.error('Error occurred:', error);
    }
    })
  }
}

  back() {
    this.route.navigate(['/projectgroupmaster']);
  }
}
