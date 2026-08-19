import { Component } from '@angular/core';
import { AngularEditorConfig } from '@kolkov/angular-editor';

@Component({
  selector: 'app-soft-ser-resolution',
  templateUrl: './soft-ser-resolution.component.html',
  styleUrl: './soft-ser-resolution.component.css'
})

export class SoftSerResolutionComponent {
  Description='';
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

  ResolutionRemarks = ''
  UserRemarks = ''
  ShowUserRemarks = false
  ShowOnHold = false
  ShowAdminButtons = false
  ShowForwardTo = false
  showPanel = false
  showChatPanel = false
  selectedRowData: any[] = [];
  IssueCode: string = '';
  Status: string = '';
  Category: string = '';
  ImpactedAsset: string = '';
  images: Array<{ name: string, type: string, url: string }> = [];
  ShowSelfInputs: boolean = false;
  ShowOthers: boolean = false;
  ShowGuest: boolean = false;
  selectRowData: any[] = [];
  EmployeeID: string = '';
  Name: string = '';
  Email: string = '';
  ContactNo: string = '';
  ReportingManager: string = '';
  StaffCategory: string = '';
  Paygroup: string = '';
  Department: string = '';
  Designation: string = '';
  Role: string = '';
  Plant: string = '';
  EmployeeIDOthers: string = '';
  OthersName: string = '';
  EmailOthers: string = '';
  ContactNoOthers: string = '';
  ReportingManagerOthers: string = '';
  StaffCategoryOthers: string = '';
  PlantOthers: string = '';
  PaygroupOthers: string = '';
  DepartmentOthers: string = '';
  DesignationOthers: string = '';
  RoleOthers: string = '';
  GuestEmployeeID: string = '';
  GuestName: string = '';
  Guestemail: string = '';
  GuestContactNo: string = '';
  ReportingManagerinML: string = '';
  StaffCategoryofML: string = '';
  GuestPlant: string = '';
  PaygroupML: string = '';
  DepartmentML: string = '';
  DesignationofMLManager: string = '';
  RoleofMLManager: string = '';
  ReportingManagerEmpID: string = '';

  togglePanel() {
    this.showPanel = !this.showPanel;
  }

  toggleChatPanel() {
    this.showChatPanel = !this.showChatPanel;
  }

  Forward() {
    this.ShowForwardTo = !this.ShowForwardTo;
  }

  Assign() {
    this.ShowForwardTo = !this.ShowForwardTo;
  }
}