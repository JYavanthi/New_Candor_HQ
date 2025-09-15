import { Component, Input, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-pro-checklist',
  templateUrl: './pro-checklist.component.html',
  styleUrls: ['./pro-checklist.component.css', '../promanagement.css']
})
export class ProChecklistComponent {
  taskForm!: FormGroup;
  @Input() proData: any;
  projectId: any
  checkList: any
  projectdetails: any
  checkListTemplate : any

  constructor(private fb: FormBuilder,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute,
    public formValidationService: FormValidationService
  ) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.projectId = m['projectId'];
    });
    this.formInit();
  }


  ngOnInit() {
    this.getcheckListList()
    this.getProjectDetails()
  }
  formInit() {
    this.taskForm = this.fb.group({
      assignedTo: ['', Validators.required],
      owner: ['', Validators.required],
      workHours: ['', Validators.required],
      status: ['', Validators.required],
      completionDate: ['', Validators.required],
      startDate: ['', Validators.required],
      dueDate: ['', Validators.required],
      duration: ['', Validators.required],
      priority: ['', Validators.required]
    });
    this.taskForm.disable();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['proData']) {
      if (this.proData != undefined) {
        this.patchFormValues(this.proData)
      }
    }
  }



  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.projectId }).subscribe((response: any) => {
      this.projectdetails = response.data;
    })
  }
  patchFormValues(data: any) {
    this.taskForm.patchValue({
      assignedTo: '',
      owner: '',
      workHours: '',
      status: '',
      completionDate: '',
      startDate: '',
      dueDate: '',
      duration: '',
      priority: '',
    })

    if (this.proData?.status?.trim() != 'Draft') {
      this.taskForm.disable();
    }
  }



  getcheckListList() {
    this.httpSer.httpGet('/projectManagement/getCheckiListByProId?projectid=' + this.projectId).subscribe((response: any) => {
      this.checkList = response.data;
    })
  }
  
  
  navigateTo(id = null) {
    this.router.navigate(['/projectmanagement/checklist/add'], { queryParams: { projectId: this.projectId, checklistId: id ? id : '' } })
  }

  navigateToTemp(id = null) {
    this.router.navigate(['/projectmanagement/projectchecklist/add'], { queryParams: { projectId: this.projectId, checklistId: id ? id : '' } })
  }

  deleteChecklist(checkListId: number) {
    this.httpSer.httpGet('/projectManagement/DeleteChecklistById?checklistId=' + checkListId).subscribe((response: any) => {
      alert('Deleted Successfully');
      this.checkList = this.checkList.filter((m: any) => m.checkListId != checkListId);
    })
  }
}
