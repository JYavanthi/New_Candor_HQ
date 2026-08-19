import { Component, EventEmitter, ViewChild, Input, Output, SimpleChanges, SecurityContext } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Event, Router } from '@angular/router';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { FormValidationService } from 'app/services/form-validation.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { merge } from 'chart.js/dist/helpers/helpers.core';
import { HttpServiceService } from 'shared/services/http-service.service';
import { AngularEditorComponent } from '@kolkov/angular-editor';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-projectlesson',
  templateUrl: './projectlesson.component.html',
  styleUrls: ['./projectlesson.component.css', '../promanagement.css']
})
export class ProjectlessonComponent {
  @ViewChild('editor') editor!: AngularEditorComponent;

  extractPlainText(html: string): string {
    const sanitized = this.sanitizer.sanitize(SecurityContext.HTML, html);
    const doc = new DOMParser().parseFromString(sanitized || '', 'text/html');
    return doc.body.textContent || '';
  }
  lessonForm!: FormGroup;
  projectId: any;
  saveTemplate: any;
  isRequired: any
  taskList: any;
  milestoneList: any;
  userDetails: any;
  templateList: any
  predefinedTemplate: any
  templateDetailsList: any
  projectTemplateResponseList: any = []
  fields: any = []
  lessonData: any
  tempResData: any
  showTemplateView: boolean = false;
  showAppTemplate: boolean = false;
  showClear = true
  editorConfig: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: 'auto',
    minHeight: '0',
    maxHeight: 'auto',
    width: 'auto',
    minWidth: '0',
    translate: 'yes',
    enableToolbar: true,
    showToolbar: true,
    defaultParagraphSeparator: '',
    defaultFontName: '',
    defaultFontSize: '',
    fonts: [
      { class: 'arial', name: 'Arial' },
      { class: 'times-new-roman', name: 'Times New Roman' },
      { class: 'calibri', name: 'Calibri' },
      { class: 'comic-sans-ms', name: 'Comic Sans MS' }
    ],
    customClasses: [
      {
        name: 'quote',
        class: 'quote',
      },
      {
        name: 'redText',
        class: 'redText'
      },
      {
        name: 'titleText',
        class: 'titleText',
        tag: 'h1',
      },
    ],
    toolbarHiddenButtons: [
      ['fontSize',
        'subscript',
        'superscript',
        'indent',
        'outdent',
        'heading',
        'fontName',
        'fontSize',
        'link',
        'unlink',
        'insertVideo',
        'insertHorizontalRule',
        'removeFormat',
        'toggleEditorMode',
        'customClasses',
        'insertUnorderedList',
        'insertOrderedList',
      ]
    ]
  };
  projectdetails: any;
  @Input() proLessonData: any;
  @Output() isAddTemplate = new EventEmitter<any>()
  proLessonDataID: any = 0;
  lesonLearId: any

  constructor(private fb: FormBuilder, private formValidation: FormValidationService, private activateRoute: ActivatedRoute,
    private httpSer: HttpServiceService, private userInfo: UserInfoSerService, public route: Router,
    private sanitizer: DomSanitizer
  ) {
    this.formInit();
    this.userDetails = this.userInfo.getUser().empData;
    this.activateRoute.queryParams.subscribe((m: any) => {
      this.projectId = m['projectId']
      this.saveTemplate = m['saveTemplate']
      this.lesonLearId = m['lesonLearId']
      if (this.projectId) {
        this.getLessonData()
      }

      if (this.saveTemplate == 'true') {
        this.showTemplateView = false;
        this.showAppTemplate = false;
        this.getLessonTemplateList();

        this.route.navigate([], {
          relativeTo: this.activateRoute,
          queryParams: { saveTemplate: null },
          queryParamsHandling: 'merge'
        })
      }
    })
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['proLessonData']) {
      if (this.proLessonData != undefined) {
        this.proLessonDataID = this.proLessonData;
      }
    }
  }

  ngOnInit() {
    this.getLessonTemplateList()
    this.getMilestoneList();
    this.getProjectDetails()
    this.lessonForm.get('predefinedTemplate')?.valueChanges.subscribe(() => {
      this.getTmeplateDetailsList();
    });
  }


  getTmeplateDetailsList() {
    const selectedTemplateId = this.lessonForm.controls['predefinedTemplate'].value;

    if (selectedTemplateId) {
      this.httpSer.httpGet('/ProjectTemplate/getProjectTemplateDetails?templateId=' + selectedTemplateId)
        .subscribe((response: any) => {
          this.templateDetailsList = response.data;

          if (this.tempResData && this.lesonLearId) {
            const filteredResponses = this.tempResData.filter((res: any) =>
              res.templateId == selectedTemplateId && res.lessonLearnedId == this.lesonLearId
            );

            this.templateDetailsList.forEach((field: any) => {
              const matchedRes = filteredResponses.find((res: any) => res.templateDtlsId === field.templateDtlsId);
              console.log("matchedRes", matchedRes);
              if (matchedRes) {
                field.templateDtlsID = matchedRes.templateDtlsId;
                if (field.type?.trim() === 'Checkbox') {
                  field.answer = matchedRes.response === 'true';
                } else if (field.type?.trim() === 'Input') {
                  field.answer = matchedRes.response;
                } else if (field.type?.trim() === 'Radio' || field.type?.trim() === 'Dropdown') {
                  field.response = matchedRes.response;
                }
              }
            });
          }
        });
    }
  }

  getTmeplateDetailsListWithRes() {
    const selectedTemplateId = this.lessonForm.controls['predefinedTemplate'].value;

    if (selectedTemplateId) {
      this.httpSer.httpGet('/ProjectTemplate/getProjectTemplateDetails?templateId=' + selectedTemplateId)
        .subscribe((response: any) => {
          this.templateDetailsList = response.data;

          if (this.tempResData && this.lesonLearId) {
            const filteredResponses = this.tempResData.filter((res: any) =>
              res.templateId == selectedTemplateId && res.lessonLearnedId == this.lesonLearId
            );

            this.templateDetailsList.forEach((field: any) => {
              console.log("templateDtlsId", filteredResponses);
              console.log("prtemplateDtlsId", this.templateDetailsList);
              const matchedRes = filteredResponses.find((res: any) => res.templateDtlsId === field.prtemplateDtlsId);
              console.log("matchedRes", matchedRes);
              if (matchedRes) {
                field.templateDtlsID = matchedRes.templateDtlsId;

                if (field.type?.trim() === 'Checkbox') {
                  field.answer = matchedRes.response === 'true';
                } else if (field.type?.trim() === 'Input') {
                  field.answer = matchedRes.response;
                } else if (field.type?.trim() === 'Radio' || field.type?.trim() === 'Dropdown') {
                  field.response = matchedRes.response;
                }
              }

            });
          }
        });
    }
  }

  addTemplate() {
    this.showTemplateView = true;
    this.isAddTemplate.emit(true)
  }

  formInit() {
    this.lessonForm = this.fb.group({
      milestone: ['', Validators.required],
      task: ['', Validators.required],
      category: ['', Validators.required],
      problem: [''],
      Closer: [''],
      lessonType: ['', Validators.required],
      lessonTypeDescription: ['', Validators.required],
      impactDescription: ['', Validators.required],
      recommendationDescription: ['', Validators.required],
      Phase: ['', Validators.required],
      predefinedTemplate: ['']
    })
  }

  getTaskList(event: any = null) {
     this.lessonForm.controls['task']?.reset();
      this.lessonForm.controls['task']?.setValue('');
    const selectedMilestone = this.lessonData ? this.lessonForm.controls['milestone'].value : event.target.value;
    this.httpSer.httpGet('/projectManagement/getTask?proId=' + Number(this.projectId)).subscribe((response: any) => {
      this.taskList = response.data?.filter((m: any) => m.milestoneId == Number(selectedMilestone) && m.parentTaskId == 0)
      if (this.lessonData) {
        this.lessonForm.patchValue({
          task: this.lessonData?.taskId
        })
      }
    })
  }

  parenttask: any

  // getTaskList(event: any = null) {
  //   const selectedMilestone = this.lessonData ? this.lessonForm.controls['milestone'].value : event.target.value;
  //   this.httpSer.httpGet('/projectManagement/getTask?proId=' + Number(this.projectId)).subscribe((response: any) => {
  //     this.taskList = response.data?.filter((task: any) => task.milestoneId == Number(selectedMilestone));
  //     if (this.lessonData) {
  //       const taskId = this.lessonData?.taskId;
  //       const isTaskAvailable = this.taskList.some((task: { taskId: any }) => task.taskId === taskId);
  //       if (isTaskAvailable) {
  //         this.lessonForm.patchValue({
  //           task: taskId
  //         });
  //       }
  //     }
  //   });
  //   this.parenttask = this.taskList.filter((a: any) => a.parentTaskId == 0)
  // }

  async getMilestoneList() {
    this.httpSer.httpGet('/projectMilestone/getMilestoneByProjectId?', { id: Number(this.projectId) }).subscribe((response: any) => {
      this.milestoneList = response.data;
      if (this.lessonData) {
        const milestoneId = this.lessonData?.milestoneId;

        const isValidMilestone = this.milestoneList.some((m: any) => m.projMilestoneId == milestoneId);

        if (isValidMilestone) {
          this.lessonForm.patchValue({
            milestone: milestoneId
          });

          this.getTaskList();
        }
      }
    });
  }

  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.projectId }).subscribe((response: any) => {
      this.projectdetails = response.data;
      if (this.projectdetails?.projectStatus == 'Cancel' || this.projectdetails?.projectStatus == 'Discontinue' || this.projectdetails?.projectStatus == 'Completed'
        || this.projectdetails?.projectStatus == 'Approved'
      ) {
      }
    })
  }

  getLessonTemplateList(callback?: () => void) {
    this.httpSer.httpGet('/ProjectTemplate/getProjectTemplate').subscribe((response: any) => {
      this.templateList = response.data;
      if (this.lessonData) {
        this.lessonForm.patchValue({
          predefinedTemplate: this.lessonData.templateId || ''
        })
        this.getTmeplateDetailsListWithRes()
      }
    })

  }

  clearAllFields() {
    this.lessonForm.patchValue(this.allFieldValues);
    this.templateDetailsList = []
    this.fields = []
  }

  allFieldValues = {
    task: '',
    milestone: '',
    Phase: '',
    category: '',
    problem: '',
    lessonType: '',
    Closer: '',
    lessonTypeDescription: '',
    impactDescription: '',
    predefinedTemplate: '',
    recommendationDescription: ''
  }
  // addTemplate() {
  //   this.route.navigate(['/projectmanagement/templateview']);
  // }

  updateFieldValue(event: any, field: any) {

  }



  navigateToLesonLearned() {
    this.route.navigate(['/projectmanagement/lessonlearned'], { queryParams: { projectId: this.projectId } });
  }

  submitLesson() {
    this.isRequired = false;
    this.projectTemplateResponseList=[];
    // this.templateDetailsList?.forEach((m: any, i: any) => {
    //   if (m.type?.trim() === 'Input' || m.type?.trim() === 'Checkbox') {
    //     if (m.mandatory && !m.answer) {
    //      alert(m.question + ' is required.')
    //       this.isRequired = true
    //       return;
    //     }
    //   }
    //   else {
    //       if (m.mandatory && !m.response) {
    //       alert(m.question + ' is required.')
    //       this.isRequired = true
    //       return;
    //     }

    //     if (this.isRequired) {      return;   }
    //   }
    // })

    for (const m of this.templateDetailsList || []) {
    if (m.type?.trim() === 'Input' || m.type?.trim() === 'Checkbox') {
      if (m.mandatory && !m.answer) {
        alert(m.question + ' is required.');
        this.isRequired = true;
        return; 
      }
      
    } else {
      if (m.mandatory && !m.response) {
        alert(m.question + ' is required.');
        this.isRequired = true;
        return; 
    }}
  }
    this.templateDetailsList?.forEach((element: any, i: any) => {
      console.log('Element:', element);
      //alert('element.response'+ element.answer + 'response' + element.response);
      const isInputOrCheckbox = element.type?.trim() === 'Input' || element.type?.trim() === 'Checkbox';
      const value = isInputOrCheckbox ? element.answer : element.response;

     if (value !== undefined) {
          this.projectTemplateResponseList.push({  
          
          "flag": element.trid ? 'U' : 'I',
          "templateID": +this.lessonForm.controls['predefinedTemplate'].value || 0,
          "prID": +this.projectId,
          "lessonLearnedId": this.lesonLearId,
          "templateDtlsID": element.prtemplateDtlsId,
          "trid": element.trid ?? 0,
          "response": (
            element.type?.trim() === 'Input' || element.type?.trim() === 'Checkbox'
              ? element.answer?.toString()
              : element.response?.toString()
          ),
          "createdBy": +this.userDetails.employeeNo
        })
      }
    });

    if (this.formValidation.validateForm(this.lessonForm)) {

      const requestBodyForLesson = {

        "flag": this.lessonData ? 'U' : "I",
        "prLessonsID": this.lessonData ? this.lessonData?.prlessonsId : 0,
        "projectID": Number(this.projectId),
        "templateID": +this.lessonForm.controls['predefinedTemplate'].value,
        "taskID": Number(this.lessonForm.controls['task'].value),
        "milestoneID": Number(this.lessonForm.controls['milestone'].value) || 0,
        "category": this.lessonForm.controls['category'].value,
        "problem": this.lessonForm.controls['problem'].value,
        "lessons_Type": this.lessonForm.controls['lessonType'].value,
        "description": this.lessonForm.controls['lessonTypeDescription'].value,
        "impact": this.extractPlainText(this.lessonForm.controls['impactDescription'].value),
        "recommendation": this.extractPlainText(this.lessonForm.controls['recommendationDescription'].value),
        "projCloserAccept": this.lessonForm.controls['Closer'].value,
        "createdBy": +this.userDetails.employeeNo,
        "projectTemplateResponseList": this.projectTemplateResponseList,

      }

      this.httpSer.httpPost('/ProjectLessons/PostProjectLesson', requestBodyForLesson).subscribe((response: any) => {
        if (response.type == 'S') {
          alert('Submitted Successfully!');
          this.navigateTo()
        } else {
          alert('Submit failed');
        }
      })
    }
  }
  // successflg: boolean;
  // submitLesson() {
  //   this.projectTemplateResponseList = [];

  //   for (const element of this.templateDetailsList || []) {
  //     const isInputOrCheckbox = element.type?.trim() === 'Input' || element.type?.trim() === 'Checkbox';
  //     const value = isInputOrCheckbox ? element.answer : element.response;

      
  //     if (element.mandatory && (value === null || value === undefined || value.toString().trim() === '')) {
  //       alert(element.question + ' is required.');
  //       return;
  //     }

    
  //     if (value !== null && value !== undefined && value.toString().trim() !== '') {
        
  //       this.projectTemplateResponseList.push({
  //         flag: element.trid ? 'U' : 'I',
  //         templateID: +this.lessonForm.controls['predefinedTemplate'].value || 0,
  //         prID: +this.projectId,
  //         lessonLearnedId: this.lesonLearId,
  //         templateDtlsID: element.prtemplateDtlsId,
  //         trid: element.trid ?? 0,
  //         response: value.toString(),
  //         createdBy: +this.userDetails.employeeNo
  //       });
  //     }
  //     console.log(this.projectTemplateResponseList);
  //     if (this.formValidation.validateForm(this.lessonForm)) {

  //       const requestBodyForLesson = {

  //         "flag": this.lessonData ? 'U' : "I",
  //         "prLessonsID": this.lessonData ? this.lessonData?.prlessonsId : 0,
  //         "projectID": Number(this.projectId),
  //         "templateID": +this.lessonForm.controls['predefinedTemplate'].value,
  //         "taskID": Number(this.lessonForm.controls['task'].value),
  //         "milestoneID": Number(this.lessonForm.controls['milestone'].value) || 0,
  //         "category": this.lessonForm.controls['category'].value,
  //         "problem": this.lessonForm.controls['problem'].value,
  //         "lessons_Type": this.lessonForm.controls['lessonType'].value,
  //         "description": this.lessonForm.controls['lessonTypeDescription'].value,
  //         "impact": this.extractPlainText(this.lessonForm.controls['impactDescription'].value),
  //         "recommendation": this.extractPlainText(this.lessonForm.controls['recommendationDescription'].value),
  //         "projCloserAccept": this.lessonForm.controls['Closer'].value,
  //         "createdBy": +this.userDetails.employeeNo,
  //         "projectTemplateResponseList": this.projectTemplateResponseList,

  //       }

  //       this.httpSer.httpPost('/ProjectLessons/PostProjectLesson', requestBodyForLesson).subscribe((response: any) => {
  //         if (response.type == 'S') {
  //           this.successflg = true;
  //         } else {
  //           this.successflg = false;
  //           // alert('Submit failed');
  //           return;
  //         }
  //       })
  //     }
  //     if (this.successflg) {
  //     alert('Submitted Successfully');
  //     this.navigateTo();
  //    }
  //   }
    
    
  // }

  getLessonData() {
    this.httpSer.httpGet('/ProjectLessons/getProjectLessonsByProjectId?projectid=' + this.projectId).subscribe((response: any) => {
      this.lessonData = response?.data?.lessonData?.find((item: any) => item.prlessonsId == Number(this.lesonLearId));
      this.tempResData = response?.data?.templateData;
      const templateIDItem = this.templateList?.find((item: any) => item.prtemplateId == Number(this.lessonData.prtemplateId))
      if (this.lessonData) {
        if (this.templateList) {
          this.lessonForm.patchValue({
            predefinedTemplate: this.lessonData.templateId || ''
          })
        }

        this.lessonForm.patchValue({
          task: this.lessonData?.taskId,
          milestone: this.lessonData?.milestoneId,
          category: this.lessonData?.category,
          problem: this.lessonData?.problem || '',
          lessonType: this.lessonData?.lessonsType,
          lessonTypeDescription: this.lessonData?.description,
          impactDescription: this.lessonData?.impact,
          Closer: this.lessonData?.projCloserAccept,
          recommendationDescription: this.lessonData?.recommendation,
        })
        this.showClear = false
        // this.getMilestoneList();
        this.getTmeplateDetailsListWithRes();

      }
    })
  }

  navigateTo() {
    this.route.navigate(['/projectmanagement/lessonlearned'], { queryParams: { projectId: this.projectId } });
  }


  navigateToTemplate() {
    this.route.navigate(['/projectmanagement/lessonlearned'], { queryParams: { projectId: this.projectId } });
  }
}
