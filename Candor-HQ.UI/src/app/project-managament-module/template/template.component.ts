import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-template',
  templateUrl: './template.component.html',
  styleUrls: ['./template.component.css', '../promanagement.css']
})
export class TemplateComponent {
  templateForm!: FormGroup
  user: any
  templateDetailsList: any = []
  templateId: any
  Data: any
  checkListTemplate: any;
  constructor(public fb: FormBuilder, public userInfoSer: UserInfoSerService, public router: Router,
    public httpSer: HttpServiceService, public activeRoute: ActivatedRoute
  ) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.templateId = m['templateId']
    })

    this.user = userInfoSer.getUser()
    this.formInit()
  }
  formInit() {
    this.templateForm = this.fb.group({
      templateName: ['', Validators.required],
      mandatory: ['', Validators.required],
      question: ['', Validators.required],
      type: ['', Validators.required],
      value: ['', Validators.required],
      status: ['', Validators.required]
    });
  }

  
  addQuestion() {
    this.templateDetailsList.push({
      "flag": "I",
      "task": "string",
      "prTemplateID": 0,
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
      "mandatory": true,
      "createdBy": 0
    })
    this.templateForm.reset()
  }



  getLessonTemplate() {
    this.httpSer.httpGet('/ProjectTemplate/getProjectTemplate').subscribe((response: any) => {
      this.Data = response.data;
      this.templateForm.patchValue({
        templateName: this.Data?.templateName
    });
    })
  }

  
  getcheckListTeplateList() {
    this.httpSer.httpGet('/ChecklistTemplate/GetChecklistTemplate').subscribe((response: any) => {
      this.checkListTemplate = response.data;
    })
  }
  saveTemplate() {
    let param = {
      "flag": "I",
      "prTemplateID": 0,
      "templateName": this.templateForm.controls['templateName'].value,
      "isActive": true,
      "createdBy": 0,
      "templateDetailsList": this.templateDetailsList
    }
    this.httpSer.httpPost('/ProjectLessons/saveTemplate', param).subscribe((response: any) => {
      if (response.type = 'S') {
        alert('Submitted Successfully!')
        this.router.navigate(['/projectmaster'])
      } else {
        alert('Submit failed')
      }
    })
  }
}
