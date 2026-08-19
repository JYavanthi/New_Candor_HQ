import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-new-hold-reason',
  templateUrl: './new-hold-reason.component.html',
  styleUrl: './new-hold-reason.component.css'
})
export class NewHoldReasonComponent {
  cateGoryList: any;
  categoryTypeList: any;
  myForm: any;
  user: any
  onHoldData:any
  support: any[] = [];
  id: any;
  reasonList:any
  parentArray:any

  constructor(public httpser:HttpServiceService,public fb: FormBuilder,private router: ActivatedRoute,private location: Location,
    public validateSer : FormValidationService,private route: Router,public userInfo : UserInfoSerService){
    this.user= userInfo.getUser();
    this.router.queryParams.subscribe(params => {
      this.id = params['id'];
  });
  }

  
  ngOnInit() {
    this.myForm = this.fb.group({
      hold_reason : ['',Validators.required],
      active : [true,Validators.required],
      supportId : [true,Validators.required]
    });
    this.getReasondata()
    this.getCategory()
    this.getsupport()
  }


  
  onModuleChange(supportId: any) {
    if (supportId?.value == '3') {
      
      this.myForm.addControl('category', this.fb.control('', Validators.required))
      this.myForm.addControl('subCategory', this.fb.control('', Validators.required))

    } else {
      this.myForm.removeControl('category');
      this.myForm.removeControl('subCategory');
    }
    this.getReasonList(Number(supportId?.value))

  }

  setValue(){
    if (this.onHoldData?.supportId == '3') {
      
      this.myForm.addControl('category', this.fb.control('', Validators.required))
      this.myForm.addControl('subCategory', this.fb.control('', Validators.required))

    } else {
      this.myForm.removeControl('category');
      this.myForm.removeControl('subCategory');
    }
    this.myForm.patchValue(
      {
        category: this.onHoldData?.categoryId,
        subCategory: this.onHoldData?.categoryTypeId,
        hold_reason: this.onHoldData?.onholdReason,
        supportId: this.onHoldData.supportId,
        active: true
      }
    )
    this.getCategoryType()
  }

  
  getsupport() {
    const apiUrls = '/ITSupport/GetSupport'
    this.httpser.httpGet(apiUrls).subscribe(
      (response: any) => {
        this.support = response;
        this.parentArray=this.support.map((m:any)=>{
          let parent:any= this.support.filter((a:any)=>{
            return m.parentId == a.supportId
          })[0]?.supportName
          
          return parent?parent:'No Parent'
        })
        if(this.onHoldData){
          this.myForm.patchValue({
            supportId: this.onHoldData.supportId,
          })
          this.categoryTypeList()
        }
      },
      (error) => {
      }
    )
  }

  getCategory() {

    const apiUrls ='/Category'
    const requestBody = {

    }
    this.httpser.httpGet(apiUrls, requestBody).subscribe(
      (response: any) => {
        this.cateGoryList = response
        if(this.onHoldData){
          this.myForm.patchValue({
            category: this.onHoldData.categoryId,
          })
          this.categoryTypeList()
        }
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  getCategoryType() {
    const apiUrls = '/CategoryTyp'
    this.httpser.httpGet(apiUrls).subscribe(
      response => {
        this.categoryTypeList = response.filter((item: any) => item.categoryId == this.myForm.value.category);
        if(this.onHoldData){
          this.myForm.patchValue({
            
        subCategory: this.onHoldData.categoryTypeId
          })
        }
      },
      (error) => {
        console.error("Post failed", error)
      }
    )
  }

  saveResaon(){

    if(!this.validateSer.validateForm(this.myForm)){
      return
    }
    let param = {
      "issueOnholdCatId": this.id??0,
      "categoryId": this.myForm.value.category,
      "categoryTypeId": this.myForm.value.subCategory,
      "onholdReason": this.myForm.value.hold_reason,
      "isActive": this.myForm.value.active,
      "createdBy": parseInt(this.user.empData.employeeNo),
      "createdDate": new Date(),
      "modifiedBy": parseInt(this.user.empData.employeeNo),
      "modifiedDate": new Date(),
      "supportId":this.myForm.value.supportId
    }

    this.httpser.httpPost('/Classification/saveHoldOnReason',param).subscribe(res=>{
      alert('Reason Added Succesfully.')
      this.route.navigate(['/onHoldReasonnMaster']);
  
    })
  }

  
  getReasonList(ParentId:any){
    this.httpser.httpGet('/Classification/getHoldOnReason',{supportId:ParentId}).subscribe(
      (response: any) => {
        this.reasonList = response
      },
      (error) => {
      }
    )
  }
  
  
  getReasondata(){
    this.httpser.httpGet('/Classification/getHoldOnReasonById',{id:this.id}).subscribe(
      (response: any) => {
        this.onHoldData=response[0]
        this.getReasonList(this.onHoldData.supportId)
        this.setValue()
      },
      (error) => {
      }
    )
  }

  
  navigateinprogress(){

  }
  deleteRow(reason:any){
  }

  back(){
    this.location.back();
  }
}
