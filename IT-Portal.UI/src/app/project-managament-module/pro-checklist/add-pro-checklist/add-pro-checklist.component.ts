import { HttpClient } from '@angular/common/http';
import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '@environments/environment.development';
import { PrAttachmentComponent } from 'app/project-managament-module/pr-attachment/pr-attachment.component';
import { FormValidationService } from 'app/services/form-validation.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { __await } from 'tslib';

@Component({
  selector: 'app-add-pro-checklist',
  templateUrl: './add-pro-checklist.component.html',
  styleUrls: ['./add-pro-checklist.component.css', '../../promanagement.css']
})
export class AddProChecklistComponent {

  checkListForm!: FormGroup;
  user: any
  MemberList: any
  projectId: any
  mileStoneList: any
  checkListData: any
  parentTaskList: any
  childTaskList: any[] = [];
  checkListId: any
  tasklist: any
  attachMentList: any
  isSubtaskView: any
  attach = ''
  attachmentsList: any = []
  selectedFiles: any
  prdefinedTemplate: any
  private apiurl = environment.apiurls
  checkListTemplate: any
  @ViewChild(PrAttachmentComponent) attachent!: PrAttachmentComponent
  checkList: any;
  showCheckList: any;
  constructor(private fb: FormBuilder, public httpSer: HttpServiceService, public userInfoSer: UserInfoSerService,
    public formValidationService: FormValidationService, public activeRoute: ActivatedRoute, public router: Router,
    public http: HttpClient
  ) {
    this.formInit();
    this.user = this.userInfoSer.getUser()
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.projectId = m['projectId'];
      this.checkListId = m['checklistId']
    });
  }

  
  ngOnInit() {
    this.getMileStoneList();
    this.getParentTaskList(() => {
      if (this.checkListId) {
        this.getCheckListData();  // this will internally patch form values after tasks are ready
      }
    });

    this.getcheckListTeplateList();
    this.getcheckListList();

    this.getFileData();
  }


  clearForm() {
    this.checkListForm.patchValue(this.allFieldValues);
    this.attachmentsList = []
    this.getChecklistList(undefined)
    if (this.attachent) {

      this.attachent.attach = ''
      this.attachent.selectedFiles = undefined
      this.attachent.attachmentsList = []
    }
  }


  formInit() {
    this.checkListForm = this.fb.group({
      checkTitle: ['', Validators.required],
      milestone: [''],
      ProjectPhase: [''],
      Task: [''],
      SubTask: [''],
      status: [''],
      Discription: ['', Validators.required],
      template: ''
    });
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
    template: ''
  };
  taskval: number=0;
  subtaskval: number = 0;
  async patchFormValues(data: any) {
    this.taskval=data?.taskId
    this.checkListForm.patchValue({
      checkTitle: data?.checkListTitle,
      milestone: data?.mileStoneId == 0 ? '' : data?.mileStoneId,
      ProjectPhase: data?.projectLevel,
      status: data?.projectLevel,
      Task: data?.taskId == 0 ? '' : data?.taskId,
      SubTask: this.subtaskval== 0 ? '' : this.subtaskval,
      Discription: data?.description
    });
    this.checkListForm.disable();
    
    this.getmilestonetask({ target: { value: data.mileStoneId } });
    this.getChildTask({ target: { value: data.taskId } });
  }

  removeAttchment(event: any) {
    this.attachMentList = this.attachMentList.filter((m: any) => m.attachId != event)
  }
  getAttchmentList(event: any) {
    this.attachMentList = event
  }

  multipleChecklistCall() {

    this.showCheckList.forEach((m: any, i: any) => {

      const requestBodyForSubmitMilestone = {
        "flag": "I",
        "checkListId": 0,
        "checkListTital": m.checkListTitle,
        "taskId": 0,
        "projectMgmtID": this.projectId,
        "subTaskId": 0,
        "mileStoneId": 0,
        "projectLevel": m.projectLevel,
        "description": m.description,
        "createdBy": parseInt(this.user.empData.employeeNo),
        "createdDt": "2025-02-05T08:49:44.706Z",
        "modifiedBy": parseInt(this.user.empData.employeeNo),
        "modifiedDt": "2025-02-05T08:49:44.706Z",
        "attachmentIds": []
      };
      this.httpSer.httpPost('/projectManagement/saveProjectChecklist', requestBodyForSubmitMilestone).subscribe((response: any) => {
        if (response.type = 'S') {
          if (this.showCheckList.length == i + 1) {

            alert('Submitted Successfully!');
            this.navigateTo()
          }
        } else {
          alert('Submit failed');
        }
      })
    });
  }

  submitTask() {
    if (this.prdefinedTemplate) {
      this.multipleChecklistCall();
      return;
    }

    if (this.formValidationService.validateForm(this.checkListForm)) {
      const requestBodyForSubmitMilestone = {
        flag: "I",
        checkListId: 0,
        checkListTital: this.checkListForm.value.checkTitle,
        taskId: this.checkListForm.value.Task || 0,
        projectMgmtID: this.projectId,
        subTaskId: this.checkListForm.value.SubTask||0,
        mileStoneId: this.checkListForm.value.milestone,
        projectLevel: this.checkListForm.value.status,
        description: this.checkListForm.value.Discription,
        createdBy: parseInt(this.user.empData.employeeNo),
        createdDt: new Date().toISOString(),
        modifiedBy: parseInt(this.user.empData.employeeNo),
        modifiedDt: new Date().toISOString(),
        attachmentIds: this.attachMentList?.map((m: any) => m.attachId)
      };

      this.httpSer.httpPost('/projectManagement/saveProjectChecklist', requestBodyForSubmitMilestone)
        .subscribe((response: any) => {
          if (response.type === 'S') {
            alert('Submitted Successfully!');
            this.navigateTo();
          } else {
            alert('Submit failed');
          }
        });
    }
  }



  getMileStoneList() {
    this.httpSer.httpGet('/projectMilestone/getMilestoneByProjectId?id=' + this.projectId).subscribe((response: any) => {
      this.mileStoneList = response.data;

      // this.checkListForm.patchValue({
      //   milestone: this.checkListData?.milestoneId
      // });
    })
  }

  addFromPredefined() {
    this.prdefinedTemplate = true
  }


  getChecklistList(event: any) {
    if (event) {

      let checkListTemp = this.checkListTemplate.filter((m: any) => m.checklisttemplateId == event?.value)[0]?.checklistIds.split(',').map((a: any) => Number(a))

      this.showCheckList = this.checkList.filter((a: any) => checkListTemp.includes(a.checkListId))
    } else {
      this.showCheckList = []
    }
  }

  getcheckListList() {
    this.httpSer.httpGet('/ChecklistTemplate/GetChecklist').subscribe((response: any) => {
      this.checkList = response.data;
    })
  }


  getcheckListTeplateList() {
    this.httpSer.httpGet('/ChecklistTemplate/GetChecklistTemplate').subscribe((response: any) => {
      this.checkListTemplate = response.data;
    })
  }


  TaskList: any

  // getParentTaskList() {
  //   this.httpSer.httpGet('/projectTask/getTask?proId=' + this.projectId).subscribe((response: any) => {
  //     const allTasks = response.data;
  //     this.TaskList =  response.data;
  //     this.parentTaskList =response.data.filter((a: any) => a.parentTaskId == 0)
  //   });
  // }

  getParentTaskList(callback?: () => void) {
    this.httpSer.httpGet('/projectTask/getTask?proId=' + this.projectId).subscribe((response: any) => {
      this.TaskList = response.data;
      this.parentTaskList = response.data.filter((a: any) => a.parentTaskId == 0);
      this.tasklist = [...this.parentTaskList]; // Assuming used in the dropdown

      if (callback) callback(); // Run patching AFTER tasks are ready
    });
  }



  getmilestonetask(event: any) {
     this.checkListForm.controls['SubTask'].reset();
    this.checkListForm.controls['SubTask'].setValue('');
    this.checkListForm.controls['Task'].reset();
    this.checkListForm.controls['Task'].setValue('');
    this.tasklist = this.parentTaskList.filter((m: any) => m.milestoneId == Number(event.target.value));
    this.childTaskList = this.parentTaskList.filter((m: any) => m.parentTaskId == event.target.value)
    
    if (this.checkListData?.mileStoneId !== this.checkListForm.controls["milestone"].value) {
      this.checkListForm.patchValue({

        Task: '',
        SubTask: '',
      });
    } else {

      if (this.checkListData) {
        this.checkListForm.patchValue({

          milestone: this.checkListData?.mileStoneId,
          Task: this.checkListData?.taskId,
          SubTask: this.checkListData?.subTaskId,
        });
             
    }
    
   }}

   

  onTaskChange(event: any) {
   
    const selectedTaskId = event.target.value;
    this.checkListForm.controls['SubTask'].reset();
    this.checkListForm.controls['SubTask'].setValue('')

    this.checkListForm.patchValue({
      //Task: selectedTaskId,
      //SubTask: '',
    });
  }

  getChildTask(event: any) {

    this.checkListForm.get('SubTask')?.reset('');
    this.childTaskList = this.TaskList.filter((m: any) => m.parentTaskId == event.target.value)
    
     setTimeout(() => {
    this.checkListForm.patchValue({
      Task: this.taskval||event.target.value,
      SubTask: this.subtaskval || ''
    });
  });
    // this.checkListForm.patchValue({
    //     SubTask: this.subtaskval,
     
    // });
  }


  getCheckListData() {
    this.httpSer.httpGet('/projectManagement/getCheckListByCheckListId?id=' + this.checkListId).subscribe((response: any) => {
      //this.parentTaskList = response.data;
      this.checkListData = response.data;
      this.subtaskval=this.checkListData.subTaskId;
      console.log('this.checkListData subtaskid', this.checkListData.subTaskId)
      this.patchFormValues(this.checkListData);
    })
  }

  navigateTo(id = null) {
    this.router.navigate(['/projectmanagement/checklist'], { queryParams: { projectId: this.projectId } })
  }

  getattach(event: any): void {
    this.selectedFiles = event.target.files[0];
    if (this.selectedFiles?.type != "application/pdf" && this.selectedFiles?.type != "image/jpg" && this.selectedFiles?.type != "image/jpeg"
      && this.selectedFiles?.type != "image/png") {
      alert('Only Jpg, Jpeg, Png and Pdf is allowed.')
      return;
    }
    if (this.attachmentsList?.map((m: any) => m.fileName).includes(this.selectedFiles?.name)) {
      alert('Documnet is allready present.')
      this.attach = ''
      this.selectedFiles = undefined
      return;
    }
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
    formData.append('prCheckListId', this.checkListId);
    formData.append('ModifiedBy', this.user?.empData?.employeeNo);
    formData.append('prTypeFlag', 'C');

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
    if (!this.checkListId) {
      return
    }
    let param = {
      prCheckListId: this.checkListId,
      prTypeFlag: 'C'
    }
    this.httpSer.httpGet(url, param).subscribe((res: any) => {
      this.attachmentsList = res['data']
    })
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
