import { Component, Input, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-pro-members',
  templateUrl: './pro-members.component.html',
  styleUrls: ['./pro-members.component.css', '../promanagement.css']
})

export class ProMembersComponent {

  membersForm!: FormGroup
  @Input() proData: any;
  projectId : any;
  memberList : any;
  projectdetails : any

  constructor(private fb: FormBuilder,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute,
    public formValidationService: FormValidationService,
  ) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.projectId = m.projectId
      this.getMembersList( this.projectId);
    });
    this.formInit();
    this.getProjectDetails()
  }

  formInit() {
    this.membersForm = this.fb.group({
      projectName: ['', Validators.required],
      type: ['', Validators.required]
    });
    this.membersForm.disable();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['proData']) {
      if (this.proData != undefined) {
        this.patchFormValues(this.proData)
      }
    }
  }

  
  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.projectId }).subscribe((response: any) => {
      this.projectdetails = response.data;
    })
  }

  patchFormValues(data: any) {
    this.membersForm.patchValue({
      projectName: '',
      type: ''
    })

    if (this.proData?.status?.trim() != 'Draft') {
      this.membersForm.disable();
    }
  }

  allFieldValues = {
    projectName: '',
    type: ''
  }

  toggleForm() {
    if (this.membersForm.disabled) {
      this.membersForm.enable();
    } else {
      this.clearForm();
    }
  }

  clearForm() {
    this.membersForm.patchValue(this.allFieldValues);
    this.membersForm.disable();
  }

  navigateTo(){
    this.router.navigate(['/projectmanagement/projectmembers/add'], {queryParams : {projectId : this.projectId}})
  }

  getMembersList(projectId : any){
    this.httpSer.httpGet('/projectManagement/getMemberByProId', {projectid :  projectId}).subscribe((response : any)=>{
      this.memberList = response.data;
    })
  }

  navigateToView(memberId : any, projectId :any){
    this.router.navigate(['/projectmanagement/projectmembers/add'], {queryParams : {memberId : memberId,projectId : this.projectId}})
  }

  deleteMembers(memberId : any){
    this.httpSer.httpGet('/projectManagement/DeleteMembersById', { memberId : memberId}).subscribe((res : any)=>{
        //alert('Successfully Deleted.');
        // this.memberList =  this.memberList.filter((m:any)=> m.prMemberId != memberId)
        // if (res.type == 'E'){
          alert(res.message)
        this.getMembersList(this.projectId)
        // }

    })
  }
}
