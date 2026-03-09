import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-pro-template-view',
  templateUrl: './pro-template-view.component.html',
  styleUrls: ['./pro-template-view.component.css', '../promanagement.css']
})
export class ProTemplateViewComponent {

  showLessonTemplate: boolean = false;
  templateDetailsList: any;
  templateViewData: any;
  pageSize = 20;
  pageIndex = 0;
  paginatedData: any;
  projectId:any

  constructor(public httpSer: HttpServiceService, public route: Router,
    private activateRoute: ActivatedRoute
  ) {
    this.activateRoute.queryParams.subscribe((m: any) => {
      this.projectId = m['projectId'];
    });
  }

  ngOnInit() {
    this.getTmeplateDetailsList()
  }

  navigateToLesonLearned(){
    this.route.navigate(['/projectmanagement/lessonlearned'],{ queryParams: { projectId: this.projectId}});
  }
  navigateToEdit(template:any=null) {
    this.route.navigate(['/projectmanagement/templateadd'],{ queryParams: { projectId: this.projectId,
      templateId: template?.prtemplateId
    }});
  }

  delete(data: any) {
    this.httpSer.httpDelete('/ProjectLessons/DeleteTemplate', { TemplatedtID: data.prtemplateId }).subscribe((response: any) => {
      if (response.type == "S") {
        alert('Deleted Successfully!')
        this.templateDetailsList = this.templateDetailsList.filter((m: any) => m.prtemplateId != data.prtemplateId)
        this.onPageChange();
      }
      else {
        alert('Error!')
      }
    });
  }

  getTmeplateDetailsList() {
    this.httpSer.httpGet('/ProjectTemplate/getProjectTemplate').subscribe((response: any) => {
      this.templateDetailsList =response.data.sort((a:any,b:any) => {const dateA = new Date(a.createdDt); const dateB = new Date(b.createdDt);   return dateB.getTime() - dateA.getTime();})
      this.onPageChange();
    });
  }

  onPageChange(event: any = null) {
    if (event) {
      this.pageIndex = event?.pageIndex;
      this.pageSize = event?.pageSize;
    }
    this.paginatedData = this.templateDetailsList?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
  }

}
