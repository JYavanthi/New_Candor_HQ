import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '@environments/environment.development';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { PrAttachmentComponent } from 'app/project-managament-module/pr-attachment/pr-attachment.component';
import { FormValidationService } from 'app/services/form-validation.service';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { response } from 'express';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-add-issue',
  templateUrl: './add-issue.component.html',
  styleUrls: ['./add-issue.component.css', '../../promanagement.css']
})
export class AddIssueComponent {
  issueForm!: FormGroup;
  user: any
  MemberList: any
  employeeList: any
  projectId: any
  mileStoneList: any
  parentTaskList: any
  tasklist: any
  issueData: any
  issueId: any;
  prdefinedTemplate: any
  attach = ''
  childTaskList: any = []
  attachmentsList: any = []
  showReAssignOptions: boolean = false;
  @ViewChild(PrAttachmentComponent) attachent!: PrAttachmentComponent
  attachMentList: any
  selectedFiles: any
  projectdetails: any = []

  private apiurl = environment.apiurls

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
  orgEmployeeList: any;
  TaskList: any;
  constructor(private fb: FormBuilder, public httpSer: HttpServiceService, public userInfoSer: UserInfoSerService,
    public formValidationService: FormValidationService, public activeRoute: ActivatedRoute,
    public router: Router, public http: HttpClient,
    private employeeInfo: GetEmployeeInfoService
  ) {
    this.formInit();
    this.user = this.userInfoSer.getUser()
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.projectId = m['projectId'];
      this.issueId = m['issueId']
      if (this.issueId) {
        this.editorConfig.editable = false
      }
    });
  }

  ngOnInit() {
    this.getMemberList();
    this.getMileStoneList();
    this.getparentTaskList();
    this.getProjectDetails();
    if (this.issueId) {
      this.getTaskDetails(this.issueId);
    }

  }

  clearForm() {
    this.issueForm.patchValue(this.allFieldValues);
    this.attachmentsList = []
    this.attachent.attach = ''
    this.attachent.selectedFiles = undefined
    this.attachent.attachmentsList = []
  }

  selectItem(item: any) {
    if (item.length !== 0) {
      this.issueForm.patchValue({
        owner: item.employeeId?.trim() + '-' + item.employeeName?.trim(),
      })
    }
    this.employeeList = [];
  }

  formInit() {
    this.issueForm = this.fb.group({
      milestone: ['', Validators.required],
      owner: ['', Validators.required],
      ProjectPhase: ['', Validators.required],
      Task: ['', Validators.required],
      SubTask: [''],
      assignedTo: [''],
      completionDate: [''],
      DateOpen: [new Date().toISOString().substring(0, 10)],
      DateClosed: [''],
      duration: [''],
      Dependency: [''],
      status: ['', Validators.required],
      priority: ['', Validators.required],
      Discription: ['', Validators.required],
      AdditionalNotes: [''],
    });

    this.issueForm.controls['DateOpen'].disable()
  }

  allFieldValues = {
    milestone: '',
    ProjectPhase: '',
    Task: '',
    owner: '',
    SubTask: '',
    assignedTo: '',
    completionDate: '',
    DateClosed: '',
    duration: '',
    Dependency: '',
    Submit: '',
    status: '',
    priority: '',
    Discription: '',
    AdditionalNotes: '',
  };

  subtaskval: number = 0;
  async patchFormValues() {
    await this.issueData;
    if (!this.issueData) return;
    this.subtaskval = this.issueData.subTaskId
    this.issueForm.patchValue({
      milestone: this.issueData?.mileStoneId,
      ProjectPhase: this.issueData?.projectLevel,
      Task: this.issueData?.taskId,
      owner: this.issueData?.issueOwner,
      assignedTo: this.issueData?.assignedTo,
      completionDate: this.issueData?.completionDate?.slice(0, 10),
      DateOpen: this.issueData?.dateOpened?.slice(0, 10),
      DateClosed: this.issueData?.dateClosed?.slice(0, 10),
      duration: Number(this.issueData?.department),
      Dependency: this.issueData?.impact,
      status: this.issueData?.status,
      priority: this.issueData?.priority,
      Discription: this.issueData?.description,
      AdditionalNotes: this.issueData?.notes
    });

    this.getmilestonetask({ target: { value: Number(this.issueData.mileStoneId) } });
    this.getChildTask(this.issueData.taskId, this.issueData?.subTaskId);

    // this.filterItem(true);



    ['status', 'assignedTo', 'DateClosed', 'duration', 'Dependency', 'Discription', 'AdditionalNotes', 'SubTask']
      .forEach(field => this.issueForm.controls[field]?.enable());

    if (this.issueData?.status === 'Completed') {
      this.issueForm.disable();
    }
  }


  private extractPlainText(html: string): string {
    const doc = new DOMParser().parseFromString(html, 'text/html');
    return doc.body.innerText.trim();
  }

  private extractImageUrls(html: string): string[] {
    const doc = new DOMParser().parseFromString(html, 'text/html');
    const images = doc.body.querySelectorAll('img');
    const urls = Array.from(images).map(img => img.getAttribute('src') || '');
    return urls;
  }




  // async filterItem(editable=false) {

  //     await this.employeeInfo.empList()
  //     var filter = this.issueForm.value.owner.toUpperCase().trim();
  //     //alert(filter);
  //     this.employeeList = this.employeeInfo?.EmpList?.filter((item: any) =>
  //       (item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
  //       ) &&
  //       this.MemberList.map((m: any) => m.empId).includes(Number(item.employeeId))
  //     );
  //     this.orgEmployeeList = this.employeeList;
  //     this.selectItem(this.orgEmployeeList);
  //     if (this.employeeList.length === 0) {
  //       this.employeeList = [];
  //       this.issueForm.get('owner')?.setValue('');
  //       alert('Enter Valid Employee');
  //        return;
  //     } else if (filter === '') {
  //       this.employeeList.length = 0;
  //     }

  // }

  //orgEmployeeList: any;
  async filterItem(editable) {

    await this.employeeInfo.empList()
    let OwnerStr = String(this.issueForm.value.owner);
    var filter = OwnerStr.toUpperCase().trim();
    //alert(filter);
    this.employeeList = this.employeeInfo?.EmpList?.filter((item: any) =>
      (item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
      ) &&
      this.MemberList.map((m: any) => m.empId).includes(Number(item.employeeId))
    );

    this.orgEmployeeList = this.employeeList

    if (this.employeeList.length === 0) {
      this.employeeList = [];
      this.issueForm.get('owner')?.setValue('');
      alert('Enter Valid Employee');
      return;
    } else if (filter === '') {
      this.employeeList.length = 0;
    }
    else{
      
      this.employeeList=this.employeeInfo?.EmpList?.filter((item: any) =>
        item.employeeId == this.issueData.issueOwner[0]);
      //alert('employee list'+ this.employeeList.employeeId +'--'+this.employeeList.employeeName);
      this.selectItem(this.employeeList);
      console.log('selector ',this.employeeList)
    }

  }


  private formatOutput(text: string, urls: string[]): string {
    let formattedOutput = text + '\n\n';
    urls.forEach(url => {
      formattedOutput += 'Image URL: ' + url + '\n';
    });
    return formattedOutput.trim();
  }

  //submitIssue(status: string, reAssignTo = false) {
  submitIssue(status: string) {
    let assignTo: any;
    const plainText = this.extractPlainText(this.issueForm.controls['Discription'].value);
    const imageUrls = this.extractImageUrls(this.issueForm.controls['Discription'].value);
    const description = this.formatOutput(plainText, imageUrls);
    const additionalNotes = this.formatOutput(this.extractPlainText(this.issueForm.controls['additionalNotes']?.value), this.extractImageUrls(this.issueForm.controls['additionalNotes']?.value))
    // if (reAssignTo) {
    //   assignTo = Number(this.issueForm.controls['reAssignTo']?.value)
    // } else {
    //   assignTo = Number(this.issueForm.controls['assignedTo']?.value)
    // }
    let ownerValue = this.issueForm.controls['owner'].value ?? '';
    let ownerValueStr = String(ownerValue).trim(); // force it to be string
    let issueOwnerId: number;

    if (ownerValueStr.includes('-')) {
      issueOwnerId = Number(ownerValueStr.split('-')[0].trim());
    } else {
      issueOwnerId = Number(ownerValueStr);
    }

    if (this.formValidationService.validateForm(this.issueForm)) {
      const requestBodyForSubmitMilestone = {
        flag: this.issueId ? 'U' : 'I',
        issueId: this.issueId ? this.issueData.issueId : 0,
        taskId: Number(this.issueForm.controls['Task'].value),
        projectMgmtID: Number(this.projectId),
        subTaskId: Number(this.issueForm.controls['SubTask'].value),
        mileStoneId: Number(this.issueForm.controls['milestone'].value),
        projectLevel: this.issueForm.controls['ProjectPhase'].value || "",
        description: description,
        priority: this.issueForm.controls['priority'].value || "",
        impact: this.issueForm.controls['Dependency'].value || "",
        department: this.issueForm.controls['duration'].value?.toString() || "",
        IssueOwner: issueOwnerId,
        dateOpened: new Date().toISOString().substring(0, 10),
        dateClosed: this.issueForm.controls['DateClosed'].value || null,
        completionDate: this.issueForm.controls['completionDate'].value || null,
        status: status == 'Open' ? this.issueForm.controls['status'].value : status,
        notes: this.issueForm.controls['AdditionalNotes'].value || "",
        assignedTo: Number(this.issueForm.controls['assignedTo']?.value),
        assignedBy: parseInt(this.user.empData.employeeNo),
        assignedOn: new Date().toISOString(),
        createdBy: parseInt(this.user.empData.employeeNo),
        modifiedBy: 0,
        attachmentIds: this.attachMentList?.map((m: any) => m.attachId)
      };
      this.httpSer.httpPost('/projectIssue/saveProjectIssue', requestBodyForSubmitMilestone).subscribe((response: any) => {
        if (response.type = 'S') {
          alert('Submitted Successfully!');
          this.navigateTo()
        } else {
          alert('Submit failed');
        }
      })
    }
  }

  getMemberList() {
    this.httpSer.httpGet('/projectManagement/getMemberByProId?projectid=' + this.projectId).subscribe((response: any) => {
      this.MemberList = response.data;
      if (this.issueData) {
        this.issueForm.patchValue({
          assignedTo: this.issueData?.assignTo,
        });
      }
    })
  }


  getMileStoneList() {
    this.httpSer.httpGet('/projectMilestone/getMilestoneByProjectId?id=' + this.projectId).subscribe((response: any) => {
      this.mileStoneList = response.data.filter((milestone: any) => milestone.milestoneStatus !== 'Completed');

      if (this.issueData) {
        this.issueForm.patchValue({
          milestone: this.issueData?.mileStoneId

        });
      }
    })

  }

  // getparentTaskList() {
  //   this.httpSer.httpGet('/projectTask/getTask?proId=' + this.projectId).subscribe((response: any) => {
  //     this.TaskList = response.data;
  //     this.parentTaskList = response.data.filter((a: any) => a.parentTaskId == 0)
  //   })
  // }

  getparentTaskList() {
    this.httpSer.httpGet('/projectTask/getTask?proId=' + this.projectId).subscribe((response: any) => {
      this.TaskList = response.data;
      this.parentTaskList = response.data.filter((a: any) => a.parentTaskId == 0);
    });
    if (this.issueData) {
      this.issueForm.patchValue({
        Task: this.issueData?.taskId

      });
    }
  }

  getmilestonetask(event: any) {
    this.issueForm.controls['SubTask'].reset();
    this.issueForm.controls['SubTask']?.setValue('');

    this.issueForm.controls['Task'].reset();

    this.issueForm.controls['Task'].setValue('');

    this.tasklist = this.parentTaskList.filter((m: any) => m.milestoneId == event.target.value)

    this.childTaskList = this.parentTaskList.filter((m: any) => m.parentTaskId == event.target.value)

    if (this.issueData?.mileStoneId !== this.issueForm.controls["milestone"].value) {
      this.issueForm.patchValue({

        Task: '',
        SubTask: '',
      });
    } else {

      if (this.issueData) {
        this.issueForm.patchValue({

          milestone: this.issueData?.mileStoneId,
          Task: this.issueData?.taskId,
          SubTask: this.issueData?.subTaskId,
        });
             
    }

  }}


  getChildTask(taskId: any, subTaskId: number | null = null) {

    this.issueForm.controls['SubTask']?.reset();
    this.issueForm.controls['SubTask'].setValue('');

    const parentId = taskId?.target?.value || taskId;
    this.childTaskList = this.TaskList.filter((m: any) => m.parentTaskId == parentId);
    //this.issueForm.controls['SubTask'].setValue('');
    if (subTaskId) {
      const interval = setInterval(() => {
        if (this.childTaskList.length > 0) {
          const isValid = this.childTaskList.some((task: { taskId: number; }) => task.taskId == subTaskId);
          if (isValid) {
            this.issueForm.controls['SubTask'].setValue(subTaskId);
          }
          clearInterval(interval);
        }
      }, 100);
      this.issueForm.patchValue({

        SubTask: subTaskId,
      });
    }
    console.log('Child task', this.childTaskList)

  }

  //   getChildTask(event: any) {
  //     this.childTaskList = this.TaskList.filter((m: any) => m.parentTaskId == event.target.value)
  //     this.issueForm.controls['SubTask'].setValue('')

  //  if (this.issueData) {
  //         const taskId = this.issueData?.parentTaskId;
  //         const isTaskAvailable = this.TaskList.some((task: { parentTaskId: any }) => task.parentTaskId === taskId);
  //         if (isTaskAvailable) {
  //           this.issueData.patchValue({
  //             task: taskId
  //           });
  //         }
  //   }
  // }


  navigateTo(id = null) {
    this.router.navigate(['/projectmanagement/issuetracker'], { queryParams: { projectId: this.projectId } })
  }


  getTaskDetails(issueId: number) {
    this.httpSer.httpGet('/projectIssue/getProIssueById?id=' + issueId).subscribe((response: any) => {
      this.issueData = response.data;
      this.getparentTaskList();
      setTimeout(() => {
        this.patchFormValues();
      }, 200);
    });
  }

  reassignToggle(stage: string) {
    this.showReAssignOptions = !this.showReAssignOptions;
    this.getMemberList()
  }

  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.projectId }).subscribe((response: any) => {
      this.projectdetails = response.data;
      if (this.projectdetails?.projectStatus == 'Cancel' || this.projectdetails?.projectStatus == 'Discontinue' || this.projectdetails?.projectStatus == 'Completed') {
        this.issueForm.disable()
      }
    })
  }

  addFile(): void {
    if (!this.selectedFiles) {
      alert('Select file.')
      return;
    }
    const formData = new FormData();
    formData.append('file', this.selectedFiles, this.selectedFiles.name);
    formData.append('FileName', this.selectedFiles.name);
    formData.append('Stage', 'N');
    formData.append('CreatedBy', this.user?.empData?.employeeNo);
    formData.append('prId', this.projectId);
    formData.append('prCheckListId', this.issueId);
    formData.append('ModifiedBy', this.user?.empData?.employeeNo);
    formData.append('prTypeFlag', 'I');
    const apiUrl = this.apiurl + '/projectManagement/addFile';
    this.http.post(apiUrl, formData).subscribe(
      (response: any) => {
        this.attachmentsList?.push({
          attachId: response?.attachId,
          fileName: this.selectedFiles?.name,
          file: this.selectedFiles
        })
        this.attach = ''
        this.selectedFiles = []
        this.attachMentList = this.attachmentsList
      },
      (error: any) => {
        console.error('Error uploading files', error);
      }
    );
  }

  getFileData() {
    let url = '/projectManagement/GetFileData'
    if (!this.issueId) {
      return
    }
    let param = {
      prCheckListId: this.issueId,
      prTypeFlag: 'I'
    }
    this.httpSer.httpGet(url, param).subscribe((res: any) => {
      this.attachmentsList = res['data']
    })
  }

  removeAttchment(event: any) {
    this.attachMentList = this.attachMentList.filter((m: any) => m.attachId != event)
  }
  getAttchmentList(event: any) {
    this.attachMentList = event
  }

  downFile(fileName: any): void {

    this.http.get(`${this.apiurl}/projectManagement/Download/${fileName.attachId}?prTypeFlag=P`, { responseType: 'blob' }).subscribe(
      (response: Blob) => {
        const url = window.URL.createObjectURL(response);
        const link = document.createElement('a');
        link.href = url;
        link.download = fileName.fileName;
        link.target = '_blank';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
        window.URL.revokeObjectURL(url);
      },
      (error: any) => {
        console.error('GET request failed', error);
      }
    );
  }
  deleteDoc(Doc: any) {
    let url = '/serviceMaster/Delete/' + Doc.attachId
    this.httpSer.httpDelete(url).subscribe((res: any) => {
      this.attachmentsList = this.attachmentsList?.filter((m: any) => Doc.attachId != m.attachId)
    })
  }

  viewFile(fileName: any): void {
    this.http.get(`${this.apiurl}/projectManagement/View/${fileName.attachId}?prTypeFlag=P`, { responseType: 'blob', observe: 'response' }).subscribe(
      (response: any) => {
        const contentType = response.headers.get('Content-Type');
        const blob = response.body as Blob;
        var fileURL = window.URL.createObjectURL(blob);
        const imageWindow = window.open(fileURL, '_blank');

      },
      (error: any) => {
      }
    );
  }
}
