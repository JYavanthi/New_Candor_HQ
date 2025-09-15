import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';import { environment } from '@environments/environment';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-pr-attachment',
  templateUrl: './pr-attachment.component.html',
  styleUrl: './pr-attachment.component.css'
})
export class PrAttachmentComponent {
  attach: any = '';
  MAX_FILE_SIZE = 1024 * 1024 * 5
  attachmentsList: any = [];
  selectedFiles: File | undefined;
  private apiurl = environment.apiurls
  user: any
  prId: any
  issueId:any
  checkListId:any
  @Input() title: any
  @Input() srData: any
  @Input() tabID: any
  @Output() attachMentListEvent = new EventEmitter<any>();
  @Output() removeAttchment = new EventEmitter<any>();
  taskId: any
  prTypeFlag = 'P'

  constructor(public http: HttpClient, public httpSer: HttpServiceService, public activeRoute: ActivatedRoute,
    public userInfo: UserInfoSerService, public router: Router) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.prId = m.projectId
      this.taskId = m.taskId    
      this.issueId = m.issueId
      this.checkListId = m.checklistId
      if (this.router.url.includes('task')) {
        this.prTypeFlag = 'T'
      }
      if (this.router.url.includes('issue')) {
        this.prTypeFlag = 'I'
      }
      if(this.router.url.includes('checklist')){
        this.prTypeFlag = 'C'
      }
    });
    this.user = userInfo.getUser()
  }


  ngOnInit(): void {
    this.getFileData()
  }
  getattach(event: any): void {
    this.selectedFiles = event.target.files[0];
    if (this.selectedFiles?.type != "application/pdf" && this.selectedFiles?.type != "image/jpg" && this.selectedFiles?.type != "image/jpeg"
      && this.selectedFiles?.type != "image/png") {
      alert('Only Jpg, Jpeg, Png and Pdf is allowed.')
      return;
    }
    if (this.attachmentsList.map((m: any) => m.fileName).includes(this.selectedFiles?.name)) {
      alert('Documnet is already present.')
      this.attach = ''
      this.selectedFiles = undefined
      return;
    }
    // if (this.attachmentsList?.length == 0) {
    //   this.addFile()
    // }getattach
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
    formData.append('prId', this.prId || 0);
    formData.append('taskId', this.taskId || 0);
    formData.append('prIssueId', this.taskId || 0);
    formData.append('ModifiedBy', this.user?.empData?.employeeNo);
    formData.append('prTypeFlag', this.prTypeFlag);

    const apiUrl = this.apiurl + '/projectManagement/addFile';

    this.http.post(apiUrl, formData).subscribe(
      (response: any) => {
        this.attachmentsList.push({
          attachId: response?.attachId,
          fileName: this.selectedFiles?.name,
          file: this.selectedFiles
        })
        this.attach = ''
        this.selectedFiles = undefined

        this.attachMentListEvent.emit(this.attachmentsList);
      },
      (error: any) => {
        console.error('Error uploading files', error);
      }
    );
  }


  getFileData() {
    let url = '/projectManagement/GetFileData';
    let param = {
      prId: this.prId,
      prTypeFlag: this.prTypeFlag,
      taskId: this.taskId||0,
      prCheckListId:this.checkListId||0,
      prIssueId:this.issueId||0
    }
    this.httpSer.httpGet(url, param).subscribe((res: any) => {
      this.attachmentsList = res.data
    })
  }

  downFile(fileName: any): void {

    this.http.get(`${this.apiurl}/projectManagement/Download/${fileName.attachId}?prTypeFlag=${this.prTypeFlag}`, { responseType: 'blob' }).subscribe(
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
    let url = '/projectManagement/Delete/' + Doc.attachId
    this.httpSer.httpDelete(url).subscribe((res: any) => {
      this.attachmentsList = this.attachmentsList.filter((m: any) => Doc.attachId != m.attachId)
      this.removeAttchment.emit(Doc.attachId)
    })
  }
  viewFile(fileName: any): void {
    this.http.get(`${this.apiurl}/projectManagement/View/${fileName.attachId}?prTypeFlag=${this.prTypeFlag}`, { responseType: 'blob', observe: 'response' }).subscribe(
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
