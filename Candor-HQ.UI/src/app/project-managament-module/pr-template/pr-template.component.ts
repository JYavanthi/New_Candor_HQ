import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-pr-template',
  templateUrl: './pr-template.component.html',
  styleUrls: ['./pr-template.component.css', '../promanagement.css']
})
export class PrTemplateComponent {
  @Input() templateViewData: any;
  @Output() childTemplateData = new EventEmitter<any>();
  templateForm!: FormGroup
  user: any;
  templateDetailsList: any[] = []
  selectedTemplateIndex: number | null = null;
  templateId:any
  projectId:any

  constructor(public fb: FormBuilder, private formValidationService: FormValidationService, public userInfoSer: UserInfoSerService, public router: Router,
    public httpSer: HttpServiceService, public activeRoute: ActivatedRoute
  ) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.templateId = m['templateId']
      this.projectId = m['projectId'];
    });
    if(this.templateId){
      this.getLessonTemplate(this.templateId);
    }

    this.user = userInfoSer.getUser()
    this.formInit()
  }

  formInit() {
    this.templateForm = this.fb.group({
      templateName: ['', Validators.required],
      mandatory: [false],
      question: ['', Validators.required],
      type: ['', Validators.required],
      value: ['', Validators.required]
    });
    this.templateForm.get('type')?.valueChanges.subscribe(value => {
      this.templateForm.patchValue({ 'value': '' })
      this.updateValidators(value);
    })
  }

  updateValidators(value: any) {
    const valueControl = this.templateForm.controls['value'].value;
    if (value == "Dropdown") {
      valueControl?.setValidators([Validators.required]);
    }
    else {
      valueControl?.clearValidators();
    }
    valueControl?.updateValueAndValidity();
  }


  // ngOnInit() {
  //   this.getTmeplateDetailsList()
  // }

  edit(value: any, index: number) {
    this.selectedTemplateIndex = index;
    this.templateForm.patchValue({
      mandatory: value.mandatory,
      question: value.question,
      type: value.type,
      value: value.value
    })
  }

  addQuestion() {
    if (this.formValidationService.validateForm(this.templateForm)) {
      if (this.selectedTemplateIndex != null) {
        this.templateDetailsList[this.selectedTemplateIndex] = {
          ...this.templateDetailsList[this.selectedTemplateIndex],
          question: this.templateForm.controls['question'].value,
          mandatory: this.templateForm.controls['mandatory'].value,
          type: this.templateForm.controls['type'].value,
          value: this.templateForm.controls['value'].value
        }
      }
      else {
        const mandatory = this.templateForm.controls['mandatory'].value;
        this.templateDetailsList.push({
          "flag": "I",
          "task": "string",
          "prTemplateID": 0,
          "prTemplateDetailsID": 0,
          "category": "string",
          "lessonType": "string",
          "description": "string",
          "impact": "string",
          "recommendation": "string",
          "taskID": 0,
          "milestoneID": 0,
          "question": this.templateForm.controls['question'].value,
          "type": this.templateForm.controls['type'].value,
          "value": this.templateForm.controls['value'].value,
          "mandatory": mandatory == null || mandatory == false ? false : true,
          "createdBy": Number(this.user.empData.employeeNo)
        })
      }
      const templateName = this.templateForm.controls['templateName'].value;
      this.templateForm.reset();
      this.templateForm.patchValue({ 'templateName': templateName, 'type': "" });
      this.selectedTemplateIndex = null;
    }
  }

  getLessonTemplate(id: any) {
    this.httpSer.httpGet('/ProjectTemplate/getProjectTemplateByTemplateId', { templateId: id }).subscribe((response: any) => {
      if (response.data.length > 0) {
        this.templateForm.patchValue({ templateName: response.data[0].templateName });
        this.getProjectTemplateDetails(response.data[0].prtemplateId);
      }
    })
  }

  getProjectTemplateDetails(id: any) {
    this.httpSer.httpGet('/ProjectTemplate/getProjectTemplateDetails', { templateId: id }).subscribe((response: any) => {
      if (response.data.length > 0) {
        this.templateDetailsList = response.data;
        this.templateForm.get('templateName')?.disable();
      }
    })
  }

  delete(data: any, i: any) {
    if (data.prTemplateID) {
      this.httpSer.httpDelete('/ProjectLessons/DeleteTemplateDtl', { TemplatedtlID: data.prTemplateID }).subscribe((response: any) => {
        if (response.type == "S") {
          alert('Deleted Successfully!')
          this.templateDetailsList = this.templateDetailsList.filter((m: any) => m.prTemplateID != data.prTemplateID)
        }
        else {
          alert('Error!')
        }
      });
    } else {
      this.templateDetailsList = this.templateDetailsList.filter((m: any, index: any) => index != i)
    }
  }

  
  navigateToLesonLearned(){
    this.router.navigate(['/projectmanagement/templateview'],{ queryParams: { projectId: this.projectId}});
  }

  saveTemplate() {
    if (this.templateDetailsList.length == 0) {
      return alert('No question available!');
    }

    this.templateDetailsList.forEach((item) => { if (item.prtemplateId > 0) { item.flag = "U"; } })
    let param = {
      "flag": this.templateId ? "U" : "I" ,
      "prTemplateID": this.templateId ?? 0 ,
      "templateName": this.templateForm.controls['templateName'].value,
      "isActive": true,
      "createdBy": this.templateViewData == undefined ? Number(this.user.empData.employeeNo) : Number(this.templateViewData.createdBy),
      "templateDetailsList": this.templateDetailsList
    }

    this.httpSer.httpPost('/ProjectLessons/saveTemplate', param).subscribe((response: any) => {
      if (response.type == 'S') {
        alert('Submitted Successfully!');
        this.router.navigate(['/projectmanagement/templateview'], {
          queryParams: {
            projectId: this.activeRoute.snapshot.queryParamMap.get('projectId')
          }
        })
      } else {
        alert('Submit failed')
      }
    })
  }
}
