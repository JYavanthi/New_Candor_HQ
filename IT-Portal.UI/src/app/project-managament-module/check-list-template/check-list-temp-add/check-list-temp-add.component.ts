import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormValidationService } from 'app/services/form-validation.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-check-list-temp-add',
  templateUrl: './check-list-temp-add.component.html',
  styleUrls: ['./check-list-temp-add.component.css', '../../promanagement.css']
})

export class CheckListTempAddComponent {

  checkListTemForm !: FormGroup
  checkList !: any
  dropdownListDepartment: any[] = [];
  selectedObj : any
  user : any
  
  dropdownDepartmentSettings = {
    textField: 'checkListTitle',
    idField : 'checkListId'
  };
  dropdownListCHecklist: any;
  checkListTemplate: any;
  constructor(public fb: FormBuilder, public httpSer: HttpServiceService,
    public formValidationService: FormValidationService, public userInfo: UserInfoSerService
  ) {
    this.inItForm()
    this.getcheckListList()
    this.getcheckListTeplateList()

    this.user = userInfo.getUser()
  }
  inItForm() {
    this.checkListTemForm = this.fb.group({
      templateName: ['', Validators.required],
      checklistSelected : [[], Validators.required]
    });
  }


  getcheckListList() {
    this.httpSer.httpGet('/ChecklistTemplate/GetChecklist').subscribe((response: any) => {
      this.checkList = response.data;
      this.dropdownListCHecklist = this.checkList
    })
  }

  getcheckListTeplateList() {
    this.httpSer.httpGet('/ChecklistTemplate/GetChecklistTemplate').subscribe((response: any) => {
      this.checkListTemplate = response.data;
    })
  }

  navigateToEdit(event:any){
    this.selectedObj = event

    let selectedChecklist = event.checklistIds.split(',').map((a:any)=>Number(a))
    let checkList=this.dropdownListCHecklist.filter((a:any)=>{
      return selectedChecklist.includes(a.checkListId)
    })
    this.checkListTemForm.patchValue({
      templateName : event.templateName,
      checklistSelected : checkList
    })
  }
  deleteTemplate(event:any){
    
    this.httpSer.httpGet('/ChecklistTemplate/DeleteTemplateChecklist', {id : event.checklisttemplateId}).subscribe((response: any) => {
      if (response.type = 'S') {
        alert('Deleted Successfully!');
        this.getcheckListTeplateList()
      } else {
        alert('Delete failed');
      }
    })
  }
  clearForm() {
    this.checkListTemForm.patchValue(this.allFieldValues);
    this.selectedObj = {}
  }

  
  allFieldValues = {
    checkTitle: '',
    milestone: '',
    ProjectPhase: '',
    Task: '',
    status: '',
    attachmentList: '',
    SubTask: '',
    Discription: '',
    templateName:'',
    checklistSelected:''
  };
  submitTemplate() {
    if(!this.selectedObj&&this.checkListTemplate.map((m:any)=>m.templateName).includes(this.checkListTemForm.controls['templateName'].value)){
      alert('Template name is already present.')
      return
    }
    if (this.formValidationService.validateForm(this.checkListTemForm)) {
      const requestChecklistTemp = {
        "flag": this.selectedObj?"U" : "I",
        "checklisttemplateId": this.selectedObj? this.selectedObj?.checklisttemplateId : 0,
        "checklistIDs": this.checkListTemForm.controls['checklistSelected'].value.map((m:any)=>m.checkListId)?.join(','),
        "templateName": this.checkListTemForm.controls['templateName'].value,
        "createdBy": Number(this.user.empData.employeeNo)
      };

      this.httpSer.httpPost('/ChecklistTemplate/PostCheklistTemplate', requestChecklistTemp).subscribe((response: any) => {
        if (response.type = 'S') {
          alert('Submitted Successfully!');
          this.getcheckListTeplateList()
          this.selectedObj = {}
          this.checkListTemForm.reset()
        } else {
          alert('Submit failed');
        }
      })
    }
  }
}
