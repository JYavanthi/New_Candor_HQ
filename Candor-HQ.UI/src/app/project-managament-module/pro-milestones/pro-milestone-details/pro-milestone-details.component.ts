import { Location } from '@angular/common';
import { Component, Input, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { FormValidationService } from 'app/services/form-validation.service';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-pro-milestone-details',
  templateUrl: './pro-milestone-details.component.html',
  styleUrls: ['./pro-milestone-details.component.css', '../../promanagement.css']
})
export class ProMilestoneDetailsComponent {
  milestoneForm!: FormGroup
  projectdetails: any
  @Input() proData: any;
  loggedInUserDetails: any;
  todayDate: string = new Date().toISOString().split('T')[0];
  projectID: any;
  projectDetails: any;
  milestoneDetails: any;
  taskData: any;
  reAssignList: any;
  taskListData: any
  MemberList: any;
  showCompleted: any
  taskId: any;
  projectId: any;
  milestoneId: any;
  showReAssignOptions: boolean = false;
  employeeList: any

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
  orgEmpList: any;


  constructor(private fb: FormBuilder,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute,
    public formValidationService: FormValidationService,
    public userInfo: UserInfoSerService, public employeeInfo: GetEmployeeInfoService,
    private location: Location
  ) {
    this.loggedInUserDetails = this.userInfo.getUser();
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.projectID = m.projectId;
      this.milestoneId = m.milestoneId
      if (this.milestoneId) {
        this.editorConfig.editable = false
      }
      if (m.milestoneId) {
        this.getMilestoneDetails(m.milestoneId);
      }
    });
    this.formInit();
  }

  formInit() {
    this.employeeInfo.empList()
    this.milestoneForm = this.fb.group({
      proMilestonetitle: ['', Validators.required],
      description: ['', Validators.required],
      status: ['', Validators.required],
      owner: ['', Validators.required],
      scheduleStartDateFrom: ['', Validators.required],
      scheduleToDate: ['', Validators.required],
      priority: ['', Validators.required],
      actualStartDTFromDate: [''],
      actualStartDTToDate: [{ value: '', disabled: true }],
      scheduleFinishDTFromDate: ['', Validators.required],
      scheduleFinishDTToDate: ['', Validators.required],
      actualFinishDTFromDate: ['', Validators.required],
      actualFinishDTToDate: ['', Validators.required]
    });

    this.milestoneForm.controls['scheduleToDate'].disable()
    this.getProjectDetails()
  }

  ngOnInit() {
    this.getMemberList()
    this.getParentTaskList()
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['proData']) {
      if (this.proData != undefined) {
      }
    }
  }


  reassignToggle(stage: string) {
    this.showReAssignOptions = !this.showReAssignOptions;
    this.getMemberList()
  }

  getMemberList() {
    this.httpSer.httpGet('/projectManagement/getMemberByProId', { projectid: this.projectID }).subscribe((response: any) => {
      this.MemberList = response.data;
    })
  }

  patchFormValues(data: any) {
    this.milestoneForm.patchValue({
      proMilestonetitle: data?.milestoneTitle,
      description: data?.milestoneDesc,
      status: data?.milestoneStatus,
      scheduleStartDateFrom: data?.startDt?.split('T')[0] || '',
      scheduleToDate: data?.endDt?.split('T')[0] || '',
      priority: data?.priority,
      actualStartDTFromDate: data?.actualStartDt?.split('T')[0] || '',
      actualStartDTToDate: data?.actualEndDt?.split('T')[0] || '',
      scheduleFinishDTFromDate: data?.finishStartDt?.split('T')[0] || '',
      scheduleFinishDTToDate: data?.finishEndDt?.split('T')[0] || '',
      actualFinishDTFromDate: data?.actualFinishStartDt?.split('T')[0] || '',
      actualFinishDTToDate: data?.actualFinishEndDt?.split('T')[0] || ''
    })
    this.filterItem()
    this.milestoneForm.disable();
    if (!data?.milestoneStatus || data?.milestoneStatus.trim() != 'Completed') {

      this.milestoneForm.controls['status'].enable();
      this.milestoneForm.controls['actualStartDTFromDate'].enable();
      this.milestoneForm.controls['actualStartDTToDate'].enable();
      this.milestoneForm.controls['description'].enable();
    }

  }

  allFieldValues = {
    proMilestonetitle: '',
    description: '',
    status: '',
    owner: '',
    scheduleStartDateFrom: '',
    scheduleToDate: '',
    priority: '',
    actualStartDTFromDate: '',
    actualStartDTToDate: '',
    scheduleFinishDTFromDate: '',
    scheduleFinishDTToDate: '',
    actualFinishDTFromDate: '',
    actualFinishDTToDate: ''
  }

  private extractPlainText(html: string): string {
    const doc = new DOMParser().parseFromString(html, 'text/html');
    return doc.body.innerText.trim();
  }

  SOnDateChange() {
    this.milestoneForm.controls['scheduleToDate'].enable()
  }

  // aOnDateChange() {
  //   this.milestoneForm.controls['actualStartDTToDate'].enable()
  //   //this.milestoneForm.controls['actualEndDTToDate'].valueChanges.='';
  // }

  aOnDateChange() {
    const startDate = new Date(this.milestoneForm.value.actualStartDTFromDate);
    const endDate = new Date(this.milestoneForm.value.actualStartDTToDate);
    this.milestoneForm.controls['actualStartDTToDate'].enable();
    if (this.milestoneForm.value.actualStartDTToDate && endDate < startDate) {
      this.milestoneForm.patchValue({ actualStartDTToDate: '' });
    }
  }


  private extractImageUrls(html: string): string[] {
    const doc = new DOMParser().parseFromString(html, 'text/html');
    const images = doc.body.querySelectorAll('img');
    const urls = Array.from(images).map(img => img.getAttribute('src') || '');
    return urls;
  }

  private formatOutput(text: string, urls: string[]): string {
    let formattedOutput = text + '\n\n';
    urls.forEach(url => {
      formattedOutput += 'Image URL: ' + url + '\n';
    });
    return formattedOutput.trim();
  }
  getMilestoneDetails(milestoneID: any) {
    this.httpSer.httpGet('/projectMilestone/getMilestoneByMilestoneId', { id: milestoneID }).subscribe((response: any) => {
      this.milestoneDetails = response.data;
      this.patchFormValues(this.milestoneDetails);
    })
  }

  toggleForm() {
    if (this.milestoneForm.disabled) {
      this.milestoneForm.enable();
    } else {
      this.milestoneForm.disable();
      this.clearForm();
    }
  }

  clearForm() {
    this.milestoneForm.patchValue(this.allFieldValues);
    this.milestoneForm.controls['scheduleToDate'].disable()
    this.milestoneForm.controls['actualStartDTToDate'].disable()
  }

  getParentTaskList() {
    this.httpSer.httpGet('/projectTask/getTask?proId=' + this.projectID).subscribe((response: any) => {
      this.taskListData = response.data;
      this.showCompleted = this.taskListData.filter((a: any) => a.milestoneId == this.milestoneId && a.status != 'Resolved')?.length > 0
    })
  }
  async filterItem() {
    if (!this.milestoneId) {  
      var filter = this.milestoneForm.value.owner.toUpperCase().trim();
      this.employeeList = this.employeeInfo?.EmpList?.filter((item: any) => (
        item.employeeId?.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)) &&

        this.MemberList.map((m: any) => m.empId).includes(Number(item.employeeId))
      );
      this.orgEmpList = this.employeeList
      if (this.employeeList.length === 0 && filter === '') {
        this.employeeList.push('');
      } else if (filter === '') {
        this.employeeList.length = 0;
      }
    } else {
      await this.employeeInfo.empList()
      this.selectItem(this.employeeInfo?.EmpList?.filter((item: any) =>
        item.employeeId == this.milestoneDetails?.owner)[0])
    }
  }

  submitMilestone() {
    if (this.milestoneForm.controls['proMilestonetitle'].status == 'INVALID') {
      alert('Milestone Title is required.');
      return
    }
    if (this.milestoneForm.controls['status'].status == 'INVALID') {
      alert('Status is Required');
      return
    }
    if (this.milestoneForm.controls['owner'].status == 'INVALID') {
      alert('Owner is required.');
      return
    }
    if (!this.milestoneId && !this.orgEmpList?.map((m: any) => m.employeeId).includes(this.milestoneForm.controls['owner'].value.split('-')[0]?.toString())) {
      alert('Select Valid Owner For Milestone.');
      return
    }

    if (this.milestoneForm.controls['priority'].status == 'INVALID') {
      alert('Priority is required.');
      return
    }



    if (this.milestoneForm.controls['scheduleStartDateFrom'].status == 'INVALID') {
      alert('Schedule Start Date is required.');
      return
    }
    if (this.milestoneForm.controls['scheduleToDate']?.status == 'INVALID') {
      alert('Schedule End Date is required.');
      return
    }

    if (this.milestoneForm.controls['description'].status == 'INVALID') {
      alert('Description is required.');
      return
    }
    const description = this.formatOutput(this.extractPlainText(this.milestoneForm.controls['description'].value), this.extractImageUrls(this.milestoneForm.controls['description'].value))
    const requestBodyForSubmitMilestone = {
      "flag": this.milestoneId ? 'U' : "I",
      "projMilestoneID": this.milestoneId ? this.milestoneDetails?.projMilestoneId : 0,
      "projectID": Number(this.projectID),
      "milestoneTitle": this.milestoneForm?.controls['proMilestonetitle'].value,
      "milestoneDesc": description,
      "milestoneStatus": this.milestoneForm?.controls['status'].value,
      "owner": parseInt(this.milestoneForm?.controls['owner'].value),
      "priority": this.milestoneForm?.controls['priority'].value,
      "startDt": this.milestoneForm?.controls['scheduleStartDateFrom'].value,
      "endDt": this.milestoneForm?.controls['scheduleToDate'].value,
      "actualStartDt": this.milestoneForm?.controls['actualStartDTFromDate'].value || null,
      "actualEndDt": this.milestoneForm?.controls['actualStartDTToDate'].value || null,
      "finishStartDt": this.milestoneForm?.controls['scheduleStartDateFrom'].value,
      "finishEndDt": this.milestoneForm?.controls['scheduleStartDateFrom'].value,
      "actualFinishStartDt": this.milestoneForm?.controls['scheduleStartDateFrom'].value,
      "actualFinishEndDt": this.milestoneForm?.controls['scheduleStartDateFrom'].value,
      "isActive": true,
      "createdBy": parseInt(this.loggedInUserDetails.empData.employeeNo),
      "modifiedBy": parseInt(this.loggedInUserDetails.empData.employeeNo)
    }

    this.httpSer.httpPost('/projectMilestone/saveProjectMilestone', requestBodyForSubmitMilestone).subscribe((response: any) => {

      if (response.type == 'S') {
        alert('Submitted Successfully!');
        this.location.back();
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

  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.projectID }).subscribe((response: any) => {
      this.projectdetails = response.data;
      if (this.projectdetails?.projectStatus == 'Cancel' || this.projectdetails?.projectStatus == 'Discontinue' || this.projectdetails?.projectStatus == 'Completed'
        || this.projectdetails?.projectStatus == 'Approved'
      ) {
        this.milestoneForm.disable()
      }
    })
  }

  selectItem(item: any) {
    this.milestoneForm.patchValue({
      owner: item.employeeId?.trim() + '-' + item.employeeName?.trim(),
    })
    this.employeeList = [];
  }
}
