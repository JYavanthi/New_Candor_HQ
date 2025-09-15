import { Component, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { response } from 'express';
import { HttpServiceService } from 'shared/services/http-service.service';
import { ProjectlessonComponent } from '../projectlesson.component';

@Component({
  selector: 'app-pro-lesson',
  templateUrl: './pro-lesson.component.html',
  styleUrls: ['./pro-lesson.component.css', '../../promanagement.css']
})
export class ProLessonComponent {

  paginatedData: any;
  projectdetails: any;
  lessonList: any
  milestoneList: any
  isOpenIssues = true;
  lessonListData: any;
  projectId: any
  prlessonsId: any
  lessonsType: any
  pageIndex = 0
  pageSize = 20
  showLessonLearned: boolean = false;
  proLessonData: string = '';
  showAddBack: boolean = true;
  @ViewChild(ProjectlessonComponent) projectLessonCompo!: ProjectlessonComponent;

  constructor(private httpSer: HttpServiceService, public router: Router, 
    private activeRoute: ActivatedRoute) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.projectId = m['projectId'];
      
      this.getLessonListData();
    });
    
  }

  ngOnInit() {
    this.getProjectDetails();
    this.getMilestoneList();
  }

  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.projectId }).subscribe((response: any) => {
      this.projectdetails = response.data;
      // if(this.projectdetails?.projectStatus=='Cancel'||this.projectdetails?.projectStatus=='Discontinue'||this.projectdetails?.projectStatus=='Completed'
      //   || this.projectdetails?.projectStatus == 'Approved'
      // ){
      //   this.taskForm.disable()
      // }
    })
  }


  onPageChange(event: any, defaultPage: any) {
    if (defaultPage) {
      this.paginatedData = this.lessonListData?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
    }
    else {
      this.pageIndex = event?.pageIndex;
      this.pageSize = event?.pageSize;
      this.paginatedData = this.lessonListData?.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize)
    }
  }

  // navigateTo() {
  //   this.router.navigate(['/projectmanagement/projecttask/add'], { queryParams: { projectId: this.projectId } })
  // }templateview

  navigateTo(task:any=null) {
    this.router.navigate(['/projectmanagement/lessonlearned/'], { queryParams: { projectId: this.projectId 
    } })
  }

  edit(task: any) {
    this.proLessonData = task.prlessonsId;
    this.showLessonLearned = true;
  }

  getMilestoneList() {
    this.httpSer.httpGet('/projectMilestone/getMilestoneByProjectId?', { id: Number(this.projectId) }).subscribe((response: any) => {
      this.milestoneList = response.data;
      this.getLessonListData();
    })
  }

  getLessonListData() {
    this.httpSer.httpGet('/ProjectLessons/getProjectLessonsByProjectId', { projectid: this.projectId }).subscribe((response: any) => {
      this.lessonListData = response.data.lessonData;
      this.lessonListData.forEach((lesson: any) => {
        const matchedMilestone = this.milestoneList.find((mile: any) => mile.projMilestoneId === lesson.milestoneId);
        if (matchedMilestone) {
          lesson.milestoneTitle = matchedMilestone.milestoneTitle;
        }
      });
      this.onPageChange(undefined, true)
    })
  }

  
  deleteTask(taskId: number) {
    this.httpSer.httpGet('/ProjectLessons/DeleteDeleteLesson?LesonId=' + taskId).subscribe((res: any) => {
      alert('Deleted Successfully');
      this.onPageChange(undefined, true)
    })
  }

  showTemplate(){
     this.router.navigate(['/projectmanagement/templateview'], { queryParams: { projectId: this.projectId } })
  }
  navigateToEdit(task:any=null){
    this.router.navigate(['/projectmanagement/lessonlearned/add'], { queryParams: { projectId: this.projectId,
      lesonLearId : task?.prlessonsId
    } });
  }


  getAddTemplate(value: any) {
    value == true ? this.showAddBack = false : this.showAddBack = true;
    this.getLessonListData()
  }

  delete(lessonId: any) {
    this.httpSer.httpDelete('/ProjectLessons/DeleteDeleteLesson', { LesonId : lessonId }).subscribe((res: any) => {
      alert('Lesson Learned Deleted Successfully.')
      this.getLessonListData();
    })
  }
}