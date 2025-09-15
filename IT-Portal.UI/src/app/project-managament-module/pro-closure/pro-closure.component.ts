import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { UserInfoSerService } from 'app/services/user-info-ser.service';
import { HttpServiceService } from 'shared/services/http-service.service'; import { environment } from '@environments/environment';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-pro-closure',
  templateUrl: './pro-closure.component.html',
  styleUrls: ['./pro-closure.component.css', '../promanagement.css']
})
export class ProClosureComponent {
  closureForm!: FormGroup;
  user: any
  MemberList: any
  mileStoneList: any
  parentTaskList: any
  checkListData: any
  checkListId: any
  attachMentList: any
  attach: any = '';
  MAX_FILE_SIZE = 1024 * 1024 * 5
  attachmentsList: any = [];
  selectedFiles: File | undefined;
  private apiurl = environment.apiurls;
  prId: any
  closureDetails: any;
  projectdetails: any;

  constructor(private fb: FormBuilder, public httpSer: HttpServiceService, public userInfoSer: UserInfoSerService, public http: HttpClient,
    public formValidationService: FormValidationService, public activeRoute: ActivatedRoute, public router: Router) {
    this.formInit();
    this.user = this.userInfoSer.getUser()
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.prId = m['projectId'];
    });
  }

  ngOnInit() {
    this.getFileData();
    this.getClosueDetails(this.prId);
    this.getProjectDetails()
    
  }

  clearForm() {
    this.closureForm.patchValue(this.allFieldValues);
    this.attachmentsList = []
    this.attach = ''
    this.selectedFiles = undefined
    this.attachmentsList = []
  }


  formInit() {
    this.closureForm = this.fb.group({
      
      status: [this.projectdetails?.projectStatus || '', Validators.required],
      remarks: ['', Validators.required],
     // status: ['', Validators.required],
    });
  }

  allFieldValues = {
    remarks: '',
    status: '',
  };

  patchFormValues() {
    this.closureForm.patchValue({

    });
  }
  submitClosuer() {
    if (this.formValidationService.validateForm(this.closureForm)) {
      const requestBodyForSubmitMilestone = {
        "flag": "I",
        "closureID": 0,
        "projectID": +this.prId,
        "status": this.closureForm.controls['status'].value,
        "remarks": this.closureForm.controls['remarks'].value,
        "attachment": "string",
        "lessonsLearnt": "string",
        "task": "string",
        "category": "string",
        "problemsStatement": "string",
        "impact": "string",
        "recommendation": "string",
        "feedback": "string",
        "isSponsor": true,
        "createdBy": parseInt(this.user.empData.employeeNo),
        "attachmentIds": this.attachmentsList?.map((m: any) => m.attachId)
      };

      this.httpSer.httpPost('/ProjectClosure/PostProjectclosure', requestBodyForSubmitMilestone).subscribe((response: any) => {
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

  openLessonLearn() {

  }
  removeAttchment(event: any) {
    this.attachMentList = this.attachMentList.filter((m: any) => m.attachId != event)
  }
  getAttchmentList(event: any) {
    this.attachMentList = event
  }
  navigateTo(id = null) {
    this.router.navigate(['/projectmaster'], { queryParams: { projectId: this.prId } })
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
    formData.append('ModifiedBy', this.user?.empData?.employeeNo);
    formData.append('prTypeFlag', 'Cr');

    const apiUrl = this.apiurl + '/projectManagement/addFile';
    this.http.post(apiUrl, formData).subscribe(
      (response: any) => {
        debugger
        this.attachmentsList.push({
          attachId: response?.attachId,
          fileName: this.selectedFiles?.name,
          file: this.selectedFiles
        })
        this.attach = ''
        this.selectedFiles = undefined
      },
      (error: any) => {
        console.error('Error uploading files', error);
      }
    );
  }
  getFileData() {
    let url = '/projectManagement/GetFileData'
    let param = {
      prId: this.prId,
      prTypeFlag: 'Cr'
    }
    this.httpSer.httpGet(url, param).subscribe((res: any) => {
      this.attachmentsList = res['data'] || []
    })
  }

  downFile(fileName: any): void {
    this.http.get(`${this.apiurl}/projectManagement/Download/${fileName.attachId}?prTypeFlag=Cr`, { responseType: 'blob' }).subscribe(
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
    })
  }
  viewFile(fileName: any): void {
    this.http.get(`${this.apiurl}/projectManagement/View/${fileName.attachId}?prTypeFlag=Cr`, { responseType: 'blob', observe: 'response' }).subscribe(
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

  getClosueDetails(projectId: string) {
    this.httpSer.httpGet('/ProjectClosure/getClosureByProjectId?projectid=' + +projectId).subscribe((response: any) => {
      this.closureDetails = response.data[0];
      if (this.closureDetails) {
        this.patchClosureFieldValues(this.closureDetails);
      }
    })
  }


  getProjectDetails() {
    this.httpSer.httpGet('/projectManagement/getProjectById', { id: this.prId }).subscribe((response: any) => {
      this.projectdetails = response.data;

      if (this.projectdetails?.projectStatus == 'In Progress') {
        this.closureForm.controls['status'].enable();
        this.closureForm.controls['remarks'].enable();
      }
    })
  }
  patchClosureFieldValues(data: any) {
    this.closureForm.patchValue({
      remarks: data?.remarks,
      status: data?.status,
      
    
    })
      
    this.closureForm.disable();
  }

}
