import { Component, Input, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { id } from '@swimlane/ngx-charts';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-pro-tasks',
  templateUrl: './pro-tasks.component.html',
  styleUrls: ['./pro-tasks.component.css', '../promanagement.css']
})
export class ProTasksComponent {
  @Input() proData: any;
  projectId: any;
  taskList: any;
  isOpenIssues = true;
  taskListData: any;
  paginatedTableData: any;
  isSubtaskView: any;
  pageSize = 20;
  pageIndex = 0;
  paginatedData: any;
  projectdetails: any;
  childtaskList: any;

  constructor(
    private fb: FormBuilder,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute,
    public formValidationService: FormValidationService
  ) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.projectId = m['projectId'];
    });
  }

  ngOnInit() {
    this.getParentTaskList();
    this.getProjectDetails();
  }

  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.projectId }).subscribe((response: any) => {
      this.projectdetails = response.data;
    });
  }

  getParentTaskList() {
    this.httpSer.httpGet('/projectTask/getTask?proId=' + this.projectId).subscribe((response: any) => {
      this.taskListData = response.data?.filter((m: any) => m.parentTaskId == 0);
      this.childtaskList = response.data.filter((m: any) => m.parentTaskId != 0);
      this.filterMilestoneList('Pending');
    });
  }

  viewSubtask(taskId: any) {
    this.paginatedData = this.childtaskList.filter((m: any) => m.parentTaskId == taskId);
    this.isSubtaskView = true;
  }

  filterMilestoneList(status: string) {
    if (status == 'Pending') {
      this.isOpenIssues = true;
      this.taskList = this.taskListData?.filter((m: any) => m.status != 'Resolved');
    }
    if (status == 'Closed') {
      this.isOpenIssues = false;
      this.taskList = this.taskListData?.filter((m: any) => m.status == 'Resolved');
    }
    this.onPageChange(undefined, true);
  }

  onPageChange(event: any, defaultPage: any) {
    if (defaultPage) {
      this.paginatedData = this.taskList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize);
    } else {
      this.pageIndex = event?.pageIndex;
      this.pageSize = event?.pageSize;
      this.paginatedData = this.taskList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize);
    }
  }

  navigateTo(id = null) {
    this.router.navigate(['/projectmanagement/projecttask/add'], {
      queryParams: { projectId: this.projectId, taskId: id ? id : '' }
    });
  }

  deleteTask(taskId: number) {
    this.httpSer.httpGet('/projectTask/deleteTaskById?taskId=' + taskId).subscribe((res: any) => {
      alert('Deleted Successfully');
      this.onPageChange(undefined, true);
      this.ngOnInit();
    });
  }

  goBack() {
    this.getParentTaskList();
    this.isSubtaskView = false;
  }

  isViewingSubtasks(): boolean {
    return this.isSubtaskView;
  }

  // ✅ This method was missing
  hasSubtasks(taskId: number): boolean {
    return this.childtaskList?.some((task: any) => task.parentTaskId === taskId);
  }
}

