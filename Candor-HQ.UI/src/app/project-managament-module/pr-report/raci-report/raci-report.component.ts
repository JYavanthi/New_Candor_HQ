import { trigger, state, style, transition, animate } from '@angular/animations';
import { Location } from '@angular/common';
import { Component, Input, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { GetEmployeeInfoService } from 'app/services/get-employee-info.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-raci-report',
  templateUrl: './raci-report.component.html',
  styleUrls: ['./raci-report.component.css','../../promanagement.css'],
  animations: [
    trigger('expandCollapseAnimation', [
      state('void', style({
        height: '0',
        opacity: '0'
      })),
      state('*', style({
        height: '*',
        opacity: '1'
      })),
      transition('void <=> *', animate('300ms ease-out')),
    ])
  ]
})
export class RaciReportComponent {

  membersForm!: FormGroup
  @Input() proData: any
  projectId : any
  memberList : any
  projectManagementList : any
  isVisible: any
  filterForm!: FormGroup
  supportnames: any;
  dropdownItems: any;

  constructor(private fb: FormBuilder,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute,
    public formValidationService: FormValidationService,
  ) {
    this.getProjectManagementList()
  }

  
  filterItems() {
    const filter = this.filterForm.value.assignTo.toUpperCase().trim();
    const isUseritems = this.supportnames.filter((item:any) =>
      item.employeeId.toUpperCase().toString().includes(filter) || item.employeeName.toUpperCase().toString().includes(filter)
    );
    this.dropdownItems = isUseritems.filter((row: any) => row.employeeId)

    if (this.dropdownItems.length === 0 && filter !== '') {
      this.dropdownItems = [{ employeeId: '', employeeName: 'No name found' }];
    } else if (filter === '') {
      this.dropdownItems = [];
    }
  }

  toggleVisibility() {
    this.isVisible = !this.isVisible;
  }

  onOptionSelected(event:any){
    this.getMembersList(event.target.value);
  }


  getMembersList(projectId : any){
    this.httpSer.httpGet('/projectManagement/getMemberByProId', {projectid :  projectId}).subscribe((response : any)=>{
      this.memberList = response.data;
    })
  }

  getProjectManagementList() {
    this.httpSer.httpGet('/projectManagement/getProject').subscribe((response : any)=>{
      this.projectManagementList = response.data
    })
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['proData']) {
      if (this.proData != undefined) {
        this.patchFormValues(this.proData)
      }
    }
  }

  patchFormValues(data: any) {
    this.membersForm.patchValue({
      projectName: '',
      type: ''
    })

    if (this.proData?.status?.trim() != 'Draft') {
      this.membersForm.disable();
    }
  }

  allFieldValues = {
    projectName: '',
    type: ''
  }

  toggleForm() {
    if (this.membersForm.disabled) {
      this.membersForm.enable();
    } else {
      this.clearForm();
    }
  }

  clearForm() {
    this.membersForm.patchValue(this.allFieldValues);
    this.membersForm.disable();
  }

  navigateTo(){
    this.router.navigate(['/projectmanagement/projectmembers/add'], {queryParams : {projectId : this.projectId}})
  }


}
