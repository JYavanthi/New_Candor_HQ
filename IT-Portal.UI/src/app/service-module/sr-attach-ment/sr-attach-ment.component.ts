import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service';import { environment } from '@environments/environment';

@Component({
  selector: 'app-sr-attach-ment',
  templateUrl: './sr-attach-ment.component.html',
  styleUrls: ['./sr-attach-ment.component.css', '../servicemodule.css']
})
export class SrAttachMentComponent {

  attach: any = '';
  MAX_FILE_SIZE = 1024 * 1024 * 5
  attachmentsList: any = [];
  selectedFiles: File | undefined;
  private apiurl = environment.apiurls
  user: any
  srId: any
  @Input() title: any
  @Input() srData: any
  @Output() attachMentListEvent = new EventEmitter<any>();
  @Output() removeAttchment = new EventEmitter<any>();
  constructor(public http: HttpClient, public httpSer: HttpServiceService, public activeRoute: ActivatedRoute,
    public userInfo: UserInfoSerService) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.srId = m.srId
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
      alert('Documnet is allready present.')
      this.attach=''
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
    formData.append('srId', this.srId || 0);
    formData.append('ModifiedBy', this.user?.empData?.employeeNo);

    const apiUrl = this.apiurl + '/serviceMaster/addFile';

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
    let url = '/serviceMaster/GetFileData'

    let param = {
      srId: this.srId
    }
    this.httpSer.httpGet(url, param).subscribe(res => {
      this.attachmentsList = res
    })
  }

  downFile(fileName: any): void {

    this.http.get(`${this.apiurl}/serviceMaster/Download/${fileName.attachId}`, { responseType: 'blob' }).subscribe(
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
      this.attachmentsList = this.attachmentsList.filter((m: any) => Doc.attachId != m.attachId)
      this.removeAttchment.emit(Doc.attachId)
    })
  }
  viewFile(fileName: any): void {
    this.http.get(`${this.apiurl}/serviceMaster/View/${fileName.attachId}`, { responseType: 'blob', observe: 'response' }).subscribe(
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
