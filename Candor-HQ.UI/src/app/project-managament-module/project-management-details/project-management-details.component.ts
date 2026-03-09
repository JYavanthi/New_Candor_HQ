import { Component, Input, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { DataTransferServiceService } from 'app/data-transfer-service.service';
import { FormValidationService } from 'app/services/form-validation.service';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';
import { PrAttachmentComponent } from '../pr-attachment/pr-attachment.component';

@Component({
  selector: 'app-project-management-details',
  templateUrl: './project-management-details.component.html',
  styleUrls: ['./project-management-details.component.css', '../promanagement.css']
})
export class ProjectManagementDetailsComponent {

  detailsForm!: FormGroup
  @Input() proData: any;
  loggedInUserDetails: any;
  projectID: any;
  projectDetails: any;
  plantList: any;
  employeeList: any = []
  employeeList1: any = []
  attachMentList: any
  deliverablesList: any = []
  groupList: any
  user: any;
  orgEmpList: any
  @ViewChild(PrAttachmentComponent) attachent!: PrAttachmentComponent
  todayDate: any = new Date().toISOString().split('T')[0];

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
  constructor(private fb: FormBuilder, private employeeInfo: GetEmployeeInfoService,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute, public dataTranSer: DataTransferServiceService,
    public formValidationService: FormValidationService,
    private loggedInUserInfo: UserInfoSerService
  ) {
    this.loggedInUserDetails = this.loggedInUserInfo.getUser();
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.projectID = m.projectId;
      if (this.projectID) {

      }
    });
    this.formInit();
    this.getPlantList();
    this.employeeInfo.empList()
  }

  onProjectChange() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.projectID }).subscribe((response: any) => {
      this.projectDetails = response.data;
      this.dataTranSer.Data = this.projectDetails
      if (this.projectDetails?.projectStatus == 'Cancel' || this.projectDetails?.projectStatus == 'Discontinue' || this.projectDetails?.projectStatus == 'Completed'
        || this.projectDetails?.projectStatus == 'Approved'
      ) {
        this.detailsForm.disable()
        this.editorConfig.editable = false
      }
      this.patchFormValues(this.projectDetails);
    })
  }
  onDateChange() {
    this.detailsForm.controls['projectEndDate'].enable()
  }

  formInit() {
    this.getGroupList()
    this.detailsForm = this.fb.group({
      projectNumber: ['', [Validators.required, Validators.min(1)]],
      projectLocation: ['', Validators.required],
      projectName: ['', Validators.required],
      projectOwner: ['', Validators.required],
      projectSponsor: ['', Validators.required],
      projectStartDate: ['', Validators.required],
      projectEndDate: [{ value: '', disabled: true }, Validators.required],
      projectGroup: ['', Validators.required],
      projectAccess: ['', Validators.required],
      deliverables: [''],
      attachment: [''],
      description: ['', Validators.required],
      EstimatedCost: ['', Validators.required],
      EstimatedHrs: ['', Validators.required],
      ActualHrs: [''],
      ActualCost: [''],
      additionalNotes: ['']
    });
    this.filterItemSponser()
    this.onProjectChange()
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['proData']) {
      if (this.proData != undefined) {
        this.patchFormValues(this.proData)
      }
    }
  }

  patchFormValues(data: any) {
    if (!data) {
      return
    }
    this.detailsForm.patchValue({
      projectNumber: data?.projectCode,
      projectLocation: data?.planId,
      projectName: data?.projectName,
      projectOwner: data?.projectOwner,
      projectSponsor: data?.sponser,
      projectStartDate: data?.startDt.split('T')[0] || '',
      projectEndDate: data?.endDt.split('T')[0] || '',
      projectGroup: data?.projectGroupId,
      projectAccess: data?.projectAccess,
      attachment: '',
      description: data?.projectDesc,
      additionalNotes: data?.additionalNotes,
      EstimatedCost: data?.estimateCost,
      EstimatedHrs: data?.estimateHrs,
      ActualHrs: data?.actualHrs,
      ActualCost: data?.actualCost
    })
    this.deliverablesList = data?.deliverables?.split(','),
      // this.detailsForm.disable();

      this.detailsForm.controls['projectNumber'].disable()
    this.detailsForm.controls['projectLocation'].disable()
    this.filterItem(true)
    this.filterItemSponser(true)
    this.onDateChange()
  }

  allFieldValues = {
    projectNumber: null,
    projectLocation: '',
    projectName: '',
    projectOwner: '',
    projectSponsor: '',
    projectStartDate: '',
    projectEndDate: '',
    projectGroup: '',
    EstimatedCost: '',
    EstimatedHrs: '',
    ActualHrs: '',
    ActualCost: '',
    projectAccess: '',
    deliverables: '',
    attachment: '',
    description: '',
    additionalNotes: ''
  }

  getPlantList() {
    this.httpSer.httpGet('/Plantid').subscribe((response: any) => {
      this.plantList = response;
    })
  }


  selectItem(item: any) {
    this.detailsForm.patchValue({
      projectOwner: item.employeeId?.trim() + '-' + item.employeeName?.trim(),
    })
    this.employeeList = [];
  }


  selectSponser(item: any) {
    this.detailsForm.patchValue({
      projectSponsor: item.employeeId?.trim() + '-' + item.employeeName?.trim(),
    })
    this.employeeList1 = [];
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

  private formatOutput(text: string, urls: string[]): string {
    let formattedOutput = text + '\n\n';
    urls.forEach(url => {
      formattedOutput += 'Image URL: ' + url + '\n';
    });
    return formattedOutput.trim();
  }


  getGroupList() {
    this.httpSer.httpGet('/projectGroup/getProjectGrops').subscribe((res: any) => {
      this.groupList = res['data']
      if (this.projectDetails) {
        this.detailsForm.patchValue({
          projectGroup: this.projectDetails?.projectGroupId
        })
      }
    })
  }

  submitDeatails(flag: any) {
    if (!this.orgEmpList?.map((m: any) => m.employeeId).includes(this.detailsForm.controls['projectOwner'].value.split('-')[0]?.toString())) {
      alert('For Project Owner select valid employee.');
      return
    }

    if (!this.orgEmpList?.map((m: any) => m.employeeId).includes(this.detailsForm.controls['projectSponsor'].value.split('-')[0]?.toString())) {
      alert('For Project Sponsor select valid employee.');
      return
    }
    if (!this.deliverablesList || this.deliverablesList?.length == 0) {
      alert('Add deliverables.');
      return
    }
    if (this.formValidationService.validateForm(this.detailsForm)) {
      const plainText = this.extractPlainText(this.detailsForm.controls['description'].value);
      const imageUrls = this.extractImageUrls(this.detailsForm.controls['description'].value);
      const formattedOutput = this.formatOutput(plainText, imageUrls);
      const notes = this.formatOutput(this.extractPlainText(this.detailsForm.controls['additionalNotes'].value), this.extractImageUrls(this.detailsForm.controls['additionalNotes'].value))
      const requestBody = {
        "flag": flag,
        "projectMgmtID": this.projectID || 0,
        "supportID": 0,
        "projectCode": String(this.detailsForm?.value.projectNumber),
        "projectName": this.detailsForm?.value.projectName,
        "projectDesc": formattedOutput,
        "projectOwner": parseInt(this.detailsForm?.value.projectOwner),
        "startDt": this.detailsForm?.value.projectStartDate,
        "endDt": this.detailsForm?.value.projectEndDate,
        "approver1Remark": "",
        "approver2Remark": "",
        "actualStartDt": "2025-01-04T09:53:03.941Z",
        "actualEndDt": "2025-01-04T09:53:03.941Z",
        "isActive": true,
        "estimateHrs": this.detailsForm?.value.EstimatedHrs,
        "estimateCost": this.detailsForm?.value.EstimatedCost,
        "actualHrs": this.detailsForm?.value.ActualHrs || null,
        "actualCost": this.detailsForm?.value.ActualCost || null,
        "createdBy": parseInt(this.loggedInUserDetails.empData.employeeNo),
        "createdDt": "2025-01-04T09:53:03.941Z",
        "modifiedBy": parseInt(this.loggedInUserDetails.empData.employeeNo),
        "modifiedDt": "2025-01-04T09:53:03.941Z",
        // "plantId": this.projectID ? this.projectDetails?.PlantId : parseInt(this.detailsForm?.value.projectLocation),
        "plantId" : 3,
        "sponser": parseInt(this.detailsForm?.value.projectSponsor),
        "projectGroupId": Number(this.detailsForm?.value.projectGroup),
        "projectAccess": this.detailsForm?.value.projectAccess,
        "deliverables": this.deliverablesList.join(','),
        "additionalNotes": notes,
        "status": 'In Progress',
        "attachmentIds": this.attachMentList?.map((m: any) => m.attachId)
      }

      console.log('req', requestBody)

      this.httpSer.httpPost('/projectManagement/saveProjectMaster', requestBody).subscribe((response: any) => {
        if (response.type == 'S') {
          alert('Submitted Successfully!');
          this.router.navigate(['/projectmaster'])
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

  clearForm() {
    this.detailsForm.patchValue(this.allFieldValues)
    this.attachMentList = []
    this.attachent.attach = ''
    this.attachent.selectedFiles = undefined
    this.attachent.attachmentsList = []
    this.deliverablesList = []
  }
  addDeliverables() {
    if (!this.detailsForm.controls['deliverables'].value) {
      return
    }
    this.deliverablesList?.push(this.detailsForm.controls['deliverables'].value)
    this.detailsForm.controls['deliverables'].reset()
  }

  async filterItem(editable = false) {
    if (!editable) {
      var filter = this.detailsForm.value.projectOwner.toUpperCase().trim();
      this.employeeList = this.employeeInfo?.EmpList?.filter((item: any) =>
        item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
      );

      this.orgEmpList = this.employeeInfo?.EmpList
      if (this.employeeList.length === 0) {
        this.detailsForm.get('projectOwner')?.setValue('');
        alert('Enter Valid Project Owner');
        this.employeeList.push('');
        this.employeeList = [];
        return;

      } else if (filter === '') {
        this.employeeList.length = 0;
      }
    }
    else {
      await this.employeeInfo.empList()
      this.selectItem(this.employeeInfo?.EmpList?.filter((item: any) =>
        item.employeeId == this.projectDetails.projectOwner)[0])

      this.orgEmpList = this.employeeInfo?.EmpList
    }
  }

  // async filterItemSponser(editable = false) {
  //   if (!editable) {
  //     var filter = this.detailsForm.value.projectSponsor.toUpperCase().trim();
  //     this.employeeList1 = this.employeeInfo?.EmpList?.filter((item: any) =>
  //       item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
  //     );
  //     if (this.employeeList1.length === 0) {
  //        this.detailsForm.get('projectSponsor')?.setValue('');
  //        alert('Enter Valid Project Sponsorer');
  //        this.employeeList.push('');
  //         this.employeeList = [];
  //        return;

  //     } else if (filter === '') {
  //       this.employeeList1.length = 0;
  //     }
  //   }
  //   else {
  //     await this.employeeInfo.empList()
  //     this.selectSponser(this.employeeInfo?.EmpList?.filter((item: any) =>
  //       item.employeeId == this.projectDetails.sponser)[0])
  //   }
  // }

  async filterItemSponser(editable = false) {

    if (!editable) {

      const value = this.detailsForm.get('projectSponsor')?.value || '';
      const filter = value.toString().trim();

      if (filter.length < 2) {
        this.employeeList1 = [];
        return;
      }

      this.employeeList1 = this.employeeInfo?.EmpList?.filter((item: any) =>
        item.employeeId.toString().toUpperCase().includes(filter.toUpperCase()) ||
        item.employeeName.toUpperCase().includes(filter.toUpperCase())
      );

      if (this.employeeList1.length === 0) {
        alert('Enter Valid Project Sponsor');
        this.detailsForm.get('projectSponsor')?.setValue('');
        return;
      }

    } else {

      await this.employeeInfo.empList();
      const sponsor = this.employeeInfo?.EmpList?.find(
        (item: any) => item.employeeId == this.projectDetails.sponser
      );

      if (sponsor) {
        this.selectSponser(sponsor);
      }
    }
  }

  minusDeliverables(i: any) {
    this.deliverablesList = this.deliverablesList.filter((m: any, index: any) => i != index)
  }

  removeAttchment(event: any) {
    this.attachMentList = this.attachMentList.filter((m: any) => m.attachId != event)
  }
  getAttchmentList(event: any) {
    this.attachMentList = event
  }
}
