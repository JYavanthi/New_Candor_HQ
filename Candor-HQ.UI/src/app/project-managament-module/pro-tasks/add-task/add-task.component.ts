import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { PrAttachmentComponent } from 'app/project-managament-module/pr-attachment/pr-attachment.component';
import { FormValidationService } from 'app/services/form-validation.service';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css', '../../promanagement.css']
})
export class AddTaskComponent {

  taskForm!: FormGroup;
  user: any
  MemberList: any
  projectId: any
  mileStoneList: any
  parentTaskList: any
  parentTaskData: any
  newParentTaskList: any
  taskData: any
  taskId: any
  showReAssignOptions: boolean = false;
  reAssignList: any;
  milestonestartDt: any;
  milestoneendDt: any;
  disabledAngularEditor: boolean = false;
  attachMentList: any
  projectdetails: any
  employeeList: any;
  @ViewChild(PrAttachmentComponent) attachent!: PrAttachmentComponent
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
    /*uploadUrl: 'v1/image',*/
    /*upload: (file: File) => { ... }
  uploadWithCredentials: false,
  sanitize: true,
  toolbarPosition: 'top'*/
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
  constructor(private fb: FormBuilder, public httpSer: HttpServiceService, public userInfoSer: UserInfoSerService,
    public formValidationService: FormValidationService, public activeRoute: ActivatedRoute,
    public router: Router, private employeeInfo: GetEmployeeInfoService
  ) {
    this.formInit();
    this.user = this.userInfoSer.getUser()
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.projectId = m['projectId'];
      this.taskId = m['taskId']
      if (this.taskId) {

        this.editorConfig.editable = false
      }
    });
  }

  ngOnInit() {
    this.getMemberList();
    this.getMileStoneList()
    this.getParentTaskList()
    this.getProjectDetails()
    this.taskForm.controls['milestone'].valueChanges.subscribe(() => {
      this.onMilestoneChange();
    });
  }


  clearForm() {
    this.taskForm.patchValue(this.allFieldValues);
    this.attachMentList = []
    this.attachent.attach = ''
    this.attachent.selectedFiles = undefined
    this.attachent.attachmentsList = []
    this.taskForm.controls['dueDate'].disable()
  }

  formInit() {
    this.taskForm = this.fb.group({
      taskTitle: ['', Validators.required],
      plannedCost: [''],
      actualCost: [''],
      milestone: ['', Validators.required],
      ProjectPhase: ['', Validators.required],
      isThisSubtask: ['', Validators.required],
      assignedTo: [''],
      parentTask: [''],
      Discription: ['', Validators.required],
      workHours: [''],
      status: ['', Validators.required],
      startDate: [{ value: '', disabled: true }, Validators.required],
      dueDate: [{ value: '', disabled: true }, Validators.required],
      duration: ['', Validators.required],
      attachment: [''],
      Dependency: [''],
      AdditionalNotes: [''],
      priority: ['', Validators.required],
      reAssignTo: [''],
      ActualStartDate: [''],
      ActualDueDate: [{ value: '', disabled: true }]
    });
  }


  allFieldValues = {
    milestone: '',
    ProjectPhase: '',
    isThisSubtask: '',
    taskTitle: '',
    plannedCost: '',
    actualCost: '',
    assignedTo: '',
    parentTask: '',
    Discription: '',
    workHours: '',
    status: '',
    startDate: '',
    dueDate: '',
    actualStartDate: '',
    actualDueDate: '',
    duration: '',
    attachment: '',
    Dependency: '',
    AdditionalNotes: '',
    priority: ''
  };

  onDateChange() {
    this.taskForm.controls['dueDate'].reset();
    this.taskForm.controls['dueDate'].enable();
  }
  changeParenttask() {
    this.parentTaskData = this.parentTaskList.filter((m: any) => this.taskForm.controls['parentTask'].value == m.taskId)[0]
   
  }

  onDateChangeA() {
    this.taskForm.controls['ActualDueDate'].reset();
    this.taskForm.controls['ActualDueDate'].enable()
  }

  onWorkHour() {
    this.taskForm.controls['workHours'].disable()
  }

  onActualCost() {
    this.taskForm.controls['actualCost'].disable()
  }


  async patchFormValues() {

    if (this.taskData?.startDt?.split('T')[0] == '2025-03-08') {
      this.taskData['startDt'] = ''
    }


    if (this.taskData?.endDt?.split('T')[0] == '2025-03-08') {
      this.taskData['endDt'] = ''
    }

    this.taskForm.patchValue({
      milestone: this.taskData?.milestoneId,
      ProjectPhase: this.taskData?.projectphase,
      isThisSubtask: this.taskData?.isSubtask,
      parentTask: this.taskData?.parentTaskId,
      assignedTo: this.taskData?.assignTo,
      taskTitle: this.taskData?.taskTitle,
      plannedCost: this.taskData?.plannedCost,
      actualCost: this.taskData?.actualCost == 0 ? '' : this.taskData?.actualCost,
      Discription: this.taskData?.taskDesc,
      workHours: this.taskData?.workHours,
      status: this.taskData?.status,
      startDate: this.taskData?.startDt?.split('T')[0],
      dueDate: this.taskData?.endDt?.split('T')[0],
      actualStartDate: this.taskData?.actualStartDate,
      actualDueDate: this.taskData?.actualDueDate,
      duration: this.taskData?.duration,
      attachment: this.taskData?.attachment,
      Dependency: this.taskData?.dependency,
      AdditionalNotes: this.taskData?.additionalNotes,
      priority: this.taskData?.taskPriority,
      ActualStartDate: this.taskData?.actualStartDt?.split('T')[0],
      ActualDueDate: this.taskData?.actualEndDt?.split('T')[0],

    });

    this.getmilestonetask({ target: { value: this.taskData.milestoneId } })
    this.taskData ? this.disabledAngularEditor = true : this.disabledAngularEditor = false

    if (this.taskId) {
      this.taskForm.disable();
      this.taskForm.controls['reAssignTo'].enable();
      this.taskForm.controls['status'].enable();
      this.taskForm.controls['ActualStartDate'].enable();
      this.taskForm.controls['ActualDueDate'].enable();
      this.taskForm.controls['assignedTo'].enable();
      this.taskForm.controls['Discription'].enable();
      this.taskForm.controls['AdditionalNotes'].enable();
    }
    if (this.taskData?.status == 'Resolved') {
      this.taskForm.disable()
    }
  }
  submitTask(status: string = 'Open', reAssignTo = false) {
    if(this.taskForm.controls["isThisSubtask"].value
      && this.taskForm.controls["parentTask"].value===''){
      alert('Select Parent Task')
      return;
    }
    
    let assignTo: any;
    if (reAssignTo) {
      assignTo = Number(this.taskForm.controls['reAssignTo'].value)
    } else {
      assignTo = Number(this.taskForm.controls['assignedTo'].value)
    }
    if (this.formValidationService.validateForm(this.taskForm)) {
      const requestBodyForSubmitMilestone = {
        "flag": this.taskId ? 'U' : 'I',
        "taskID": this.taskId ? Number(this.taskId) : 0,
        "milestoneID": Number(this.taskForm.value.milestone),
        "projectID": Number(this.projectId),
        "owner": 0,
        "empID": 0,
        "assignTo": assignTo || 0,
        "duration": Number(this.taskForm.value.duration),
        "responsible": true,
        "accountable": true,
        "consulted": true,
        "plannedCost": this.taskForm.controls['plannedCost'].value || 0,
        "actualCost": this.taskForm.controls['actualCost'].value || 0,
        "informed": true,
        "Projectphase": this.taskForm.controls['ProjectPhase'].value,
        "taskTitle": this.taskForm.controls['taskTitle'].value,
        "dependency": this.taskForm.controls['Dependency'].value,
        "isSubtask": this.taskForm.controls['isThisSubtask'].value,
        "taskDesc": this.taskForm.controls['Discription'].value,
        "priority": this.taskForm.controls['priority'].value,
        "workHours": this.taskForm.controls['workHours'].value,
        "status": status == 'Open' ? this.taskForm.controls['status'].value : status,
        "actualStartDt": this.taskForm.controls['ActualStartDate'].value || null,
        "actualEndDt": this.taskForm.controls['ActualDueDate'].value || null,
        "startDt": this.taskForm.controls['startDate'].value || "2025-03-08T11:48:20.968Z",
        "endDt": this.taskForm.controls['dueDate'].value || "2025-03-08T11:48:20.968Z",
        "isActive": true,
        "createdBy": parseInt(this.user.empData.employeeNo),
        "modifiedBy": 0,
        "parentTaskId": this.taskForm.controls['parentTask'].value || 0,
        "addditionalNotes": this.taskForm?.controls['AdditionalNotes'].value,
        "attachmentIds": this.attachMentList?.map((m: any) => m.attachId),

      };
      this.httpSer.httpPost('/projectTask/saveProjectTask', requestBodyForSubmitMilestone).subscribe((response: any) => {
        if (response.type == 'S') {
          alert('Submitted Successfully!');
          this.navigateTo()
        }
        else if (response.type == "E") {
          var error = response.message
          alert(error)
        }
        else {
          alert('Submit failed');
        }
      })
    }
  }
  reassignToggle(stage: string) {
    this.showReAssignOptions = !this.showReAssignOptions;
    this.getMemberList()
  }

  selectItem(item: any) {
    if (item.length !== 0) {
      this.taskForm.patchValue({
        owner: item.employeeId?.trim() + '-' + item.employeeName?.trim(),
      })
    }
    this.employeeList = [];
  }

  orgEmployeeList: any;
  async filterItem(editable) {

    await this.employeeInfo.empList()
    var filter = this.taskForm.value.owner.toUpperCase().trim();
    //alert(filter);
    this.employeeList = this.employeeInfo?.EmpList?.filter((item: any) =>
      (item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
      ) &&
      this.MemberList.map((m: any) => m.empId).includes(Number(item.employeeId))

    );
    this.orgEmployeeList = this.employeeList
    this.selectItem(this.employeeList);

    if (this.employeeList.length === 0) {
      this.employeeList = [];
      this.taskForm.get('owner')?.setValue('');
      alert('Enter Valid Employee');
      return;
    } else if (filter === '') {
      this.employeeList.length = 0;
    }

  }

  getMemberList() {

    this.httpSer.httpGet('/projectManagement/getMemberByProId', { projectid: Number(this.projectId) }).subscribe((response: any) => {
      this.MemberList = response.data.filter((value: any, index: any, self: any) => index === self.findIndex((t: any) => (t.empId == value.empId)));
      if (this.taskId) {
        this.reAssignList = this.MemberList.filter((m: any) => m.prMemberId != this.taskData?.assignTo)
        this.taskForm.patchValue({
          assignedTo: this.taskData?.assignTo,
        });
      }
    })
  }

  tasklist: any

  async getmilestonetask(event: any) {
    
    this.tasklist = this.parentTaskList.filter((m: any) => m.milestoneId == event.target.value)
    this.taskForm.controls['startDate'].enable()
    
  }

  getMileStoneList() {
    this.httpSer.httpGet('/projectMilestone/getMilestoneByProjectId?id=' + this.projectId).subscribe((response: any) => {
      this.mileStoneList = response.data.filter((milestone: any) => milestone.milestoneStatus !== 'Completed');

      if (this.taskData) {
        this.taskForm.patchValue({
          milestone: this.taskData?.milestoneId,

        })
      }
    });
  }

  onMilestoneChange() {
    const selectedMilestone = this.mileStoneList?.find((m: any) => m.projMilestoneId === Number(this.taskForm.controls['milestone'].value));
    this.milestonestartDt = selectedMilestone.startDt.split('T')[0]
    this.milestoneendDt = selectedMilestone.endDt.split('T')[0]
  }

  getParentTaskList() {
    this.httpSer.httpGet('/projectTask/getTask?proId=' + this.projectId).subscribe((response: any) => {

      this.parentTaskList = response.data.filter((task: any) => task.status !== undefined);
      this.newParentTaskList = this.parentTaskList.filter((a: any) => a.parentTaskId == 0)
      this.taskData = this.parentTaskList.filter((m: any) => {
        return m.taskId == this.taskId
      })[0]
      if (!this.taskId) {
        return
      }

      setTimeout(() => {
        this.patchFormValues();
      }, 500);

      
    })
  }


  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.projectId }).subscribe((response: any) => {
      this.projectdetails = response.data;
      if (this.projectdetails?.projectStatus == 'Cancel' || this.projectdetails?.projectStatus == 'Discontinue' || this.projectdetails?.projectStatus == 'Completed'
        || this.projectdetails?.projectStatus == 'Approved'
      ) {
        this.taskForm.disable()
      }
    })
  }
  navigateTo(id = null) {
    //this.router.navigate(['/projectmanagement/projecttask'], { queryParams: { projectId: id } })
    this.router.navigate(['/projectmanagement/projecttask'], { queryParams: { projectId: this.projectId } })
  }

  removeAttchment(event: any) {
    this.attachMentList = this.attachMentList.filter((m: any) => m.attachId != event)
  }

  getAttchmentList(event: any) {
    this.attachMentList = event
  }

}
